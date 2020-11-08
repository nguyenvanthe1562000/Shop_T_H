(function (app) {

    app.controller('ProductListController', ProductListController)
    ProductListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter']
    function ProductListController($scope, apiService, notificationService, $ngBootbox, $filter) {

        $scope.product = [];
        $scope.page = 0;
        $scope.pageCount = 0
        $scope.getProduct = getProduct;
        $scope.keyWord = '';
        $scope.search = search;
        $scope.pageSize = 10;
        $scope.deleteProduct = deleteProduct;
        $scope.selectAll = selectAll;
        $scope.deleteMultiple = deleteMultiple;

        function deleteMultiple() {
            var listId = [];
            $.each($scope.selected, function (i, item) {
                listId.push(item.ID);
            });
            var config = {
                params: {
                    listProductCateogry: JSON.stringify(listId)
                }
            }
            apiService.del('/api/Product/deletemulti', config, function (result) {
                notificationService.displaySuccess('Xóa thành công ' + result.data + ' bản ghi.');
                search();
            }, function (error) {
                notificationService.displayError('Xóa không thành công');
            });
        }
        $scope.isAll = false;
        function selectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.Product, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.Product, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }
        $scope.$watch("Product", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);

        function deleteProduct(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('/api/Product/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            });
        }
        function search() {
            getProduct();
        }
        function getProduct(page) {
            page = page || 0;
            var config = {
                params:
                {
                    keyWord: $scope.keyWord,
                    page: page,
                    pageSize: $scope.pageSize
                }
            }
            apiService.get('/api/Product/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('không tìm thấy bản ghi nào');
                }

                $scope.product = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('load product faild')
            });
        }
        function getListProductCategory() {
            apiService.get('/api/productcategory/getallparents', null, function (result) {
                $scope.productCategories = result.data;
            }, function (error) { console.log('load product category faild') })
        }
        getListProductCategory();
        $scope.getProduct();
    }
}
)(angular.module('Shop_T_H.Product'));