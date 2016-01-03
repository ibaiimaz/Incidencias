(function (app) {
    'use strict';

    app.controller('aplicacionesCtrl', aplicacionesCtrl);

    aplicacionesCtrl.$inject = ['$scope', '$modal', 'apiService', 'notificationService'];

    function aplicacionesCtrl($scope, $modal, apiService, notificationService) {

        $scope.pageClass = 'page-aplicaciones';
        $scope.loadingAplicaciones = true;
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.Aplicaciones = [];

        //$scope.search = search;
        //$scope.clearSearch = clearSearch;

        $scope.search = search;
        $scope.clearSearch = clearSearch;
        $scope.openEditDialog = openEditDialog;

        function search(page) {
            page = page || 0;

            $scope.loadingAplicaciones = true;

            var config = {
                params: {
                    page: page,
                    pageSize: 4,
                    filter: $scope.filterAplicaciones
                }
            };

            apiService.get('/api/aplicaciones/search/', config,
            aplicacionesLoadCompleted,
            aplicacionesLoadFailed);
        }

        function openEditDialog(aplicacion) {
            $scope.EditedAplicacion = aplicacion;
            $modal.open({
                templateUrl: 'scripts/spa/aplicaciones/editAplicacionModal.html',
                controller: 'aplicacionEditCtrl',
                scope: $scope
            }).result.then(function ($scope) {
                clearSearch();
            }, function () {
            });
        }

        function aplicacionesLoadCompleted(result) {
            $scope.Aplicaciones = result.data.Items;

            $scope.page = result.data.Page;
            $scope.pagesCount = result.data.TotalPages;
            $scope.totalCount = result.data.TotalCount;
            $scope.loadingAplicaciones = false;

            if ($scope.filterAplicaciones && $scope.filterAplicaciones.length) {
                notificationService.displayInfo(result.data.Items.length + ' aplicaciones encontradas');
            }

        }

        function aplicacionesLoadFailed(response) {
            notificationService.displayError(response.data);
        }

        function clearSearch() {
            $scope.filterAplicaciones = '';
            search();
        }

        $scope.search();
    }

})(angular.module('incidencias'));