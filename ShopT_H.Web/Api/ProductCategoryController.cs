using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Shop_T_H.Model.Models;
using Shop_T_H.Service;
using Shop_T_H.Web.Infrastructure.Core;
using Shop_T_H.Web.Models;
using Shop_T_H.Web.Infrastructure.Extensions;

namespace Shop_T_H.Web.Api
{
    [RoutePrefix("api/productcategory")]
    public class ProductCategoryController : ApiControllerBase
    {
        IProductCatergoryService _productCategoryService;
        public ProductCategoryController(IErrorService errorService, IProductCatergoryService productCatergoryService) : base(errorService)
        {
            _productCategoryService = productCatergoryService;
        }
        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyWord, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _productCategoryService.GetAll(keyWord);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(query);
                var paginationSet = new PaginationSet<ProductCategoryViewModel>()
                {
                    Items = responseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }

        [Route("getallparents")]
        [HttpGet]
        public HttpResponseMessage GetAllParents(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _productCategoryService.GetAll();

                var responseData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
                
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });

        }

        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, ProductCategoryViewModel productCategoryViewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newProductCategory = new ProductCategory();
                    newProductCategory.UpdateProductCategory(productCategoryViewModel);
                    _productCategoryService.Add(newProductCategory);
                    _productCategoryService.Save();
                    var responseData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(newProductCategory);
                    response = request.CreateResponse(HttpStatusCode.OK, responseData);
                }
                return response;
            });
        }
    }

}
