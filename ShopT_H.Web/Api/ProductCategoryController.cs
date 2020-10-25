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

namespace Shop_T_H.Web.Api
{
    [RoutePrefix("api/productcategory")]
    public class ProductCategoryController : ApiControllerBase
    {
        IProductCatergoryService _productCategoryService;
        public ProductCategoryController(IErrorService errorService, IProductCatergoryService productCatergoryService) :base(errorService)
        {
            _productCategoryService = productCatergoryService;
        }
        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _productCategoryService.GetAll();
                var responseData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
    }
}
