(function (app) {
    'use strict';

    app.controller('indexCtrl', indexCtrl);

    indexCtrl.$inject = ['$scope','apiService', 'notificationService'];

    function indexCtrl($scope, apiService, notificationService) {
        $scope.pageClass = 'page-home';
        $scope.loadingIncidencias = true;
        $scope.loadingAplicaciones = true;
        $scope.isReadOnly = true;

        $scope.latestIncidencias = [];
        $scope.loadData = loadData;

        function loadData() {
            apiService.get('/api/incidencias/latest', null,
                        incidenciasLoadCompleted,
                        incidenciasLoadFailed);

            apiService.get("/api/aplicaciones/", null,
                aplicacionesLoadCompleted,
                aplicacionesLoadFailed);
        }

        function incidenciasLoadCompleted(result) {
            $scope.latestIncidencias = result.data;
            $scope.loadingIncidencias = false;
        }        

        function incidenciasLoadFailed(response) {
            notificationService.displayError(response.data);
        }

        function aplicacionesLoadCompleted(result) {
            var aplicaciones = result.data;
            Morris.Bar({
                element: "aplicaciones-bar",
                data: aplicaciones,
                xkey: "Name",
                ykeys: ["NumberOfIncidencias"],
                labels: ["Numero de incidencias"],
                barRatio: 0.4,
                xLabelAngle: 55,
                hideHover: "auto",
                resize: 'true'
            });
            //.on('click', function (i, row) {
            //    $location.path('/genres/' + row.ID);
            //    $scope.$apply();
            //});

            $scope.loadingAplicaciones = false;
        }

        function aplicacionesLoadFailed(response) {
            notificationService.displayError(response.data);
        }

        loadData();
    }

})(angular.module('incidencias'));