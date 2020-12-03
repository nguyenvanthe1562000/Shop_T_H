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
using System.Web.Script.Serialization;

namespace Shop_T_H.Web.Api
{

    [RoutePrefix("api/productcategory")]
    [Authorize]
    public class ProductCategoryController : ApiControllerBase
    {
        IProductCategoryService _productCategoryService;
        public ProductCategoryController(IErrorService errorService, IProductCategoryService productCatergoryService) : base(errorService)
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

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request,int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _productCategoryService.GetById(id);

                var responseData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(model);

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

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, ProductCategoryViewModel productCategoryViewModel)
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
                    var dbproductCategory = _productCategoryService.GetById(productCategoryViewModel.ID);
                    dbproductCategory.UpdateProductCategory(productCategoryViewModel);
                    dbproductCategory.UpdatedDate = DateTime.Now;

                    _productCategoryService.Update(dbproductCategory);
                    _productCategoryService.Save();
                    var responseData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(dbproductCategory);
                    response = request.CreateResponse(HttpStatusCode.OK, responseData);
                }
                return response;
            });
        }
        [Route("delete")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
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
                    var oldProductCategory = _productCategoryService.Delete(id);
                    _productCategoryService.Save();

                    var responseData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(oldProductCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }
        [Route("deletemulti")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string listProductCategory)
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
                    var _listProductCategory = new JavaScriptSerializer().Deserialize<List<int>>(listProductCategory);

                    foreach (var item in _listProductCategory)
                    {
                         _productCategoryService.Delete(item);
                    }
                    _productCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK, _listProductCategory.Count);
                }

                return response;
            });
        }

    }

}
