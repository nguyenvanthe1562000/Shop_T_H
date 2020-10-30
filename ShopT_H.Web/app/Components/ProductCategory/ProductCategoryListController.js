(function (app) {

    app.controller('ProductCategoryListController', ProductCategoryListController)
    ProductCategoryListController.$inject = ['$scope', 'apiService','notificationService']
    function ProductCategoryListController($scope, apiService, notificationService) {

        $scope.productCategory = [];
        $scope.page = 0;
        $scope.pageCount = 0
        $scope.getProductCategory = getProductCategory;
        $scope.keyWord = '';
        $scope.search = search;
        $scope.pageSize = 10;
        function search() {
            getProductCategory();
        }
      
        function getProductCategory(page) {
            page = page || 0;
            var config = {
                params:
                {
                    keyWord: $scope.keyWord ,
                    page: page,
                    pageSize: $scope.pageSize
                }
            }
            apiService.get('/api/productcategory/getall', config, function (result) {
                if (result.data.TotalCount == 0)
                {
                    notificationService.displayWarning('không tìm thấy bản ghi nào');
                }
               
                $scope.productCategory = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('load product category faild')
            });
        }
        $scope.getProductCategory();
    }
}
)(angular.module('Shop_T_H.ProductCategory'));