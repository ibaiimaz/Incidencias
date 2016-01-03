(function (app) {
    'use strict';

    app.controller('aplicacionesRegCtrl', aplicacionesRegCtrl);

    aplicacionesRegCtrl.$inject = ['$scope', '$location', '$rootScope', 'apiService'];

    function aplicacionesRegCtrl($scope, $location, $rootScope, apiService) {

        $scope.newAplicacion = {};

        $scope.Register = Register;

        $scope.submission = {
            successMessages: ['Successfull submission will appear here.'],
            errorMessages: ['Submition errors will appear here.']
        };

        function Register() {
            apiService.post('/api/aplicaciones/register', $scope.newCustomer,
           registerCustomerSucceded,
           registerCustomerFailed);
        }

        function registerCustomerSucceded(response) {
            $scope.submission.errorMessages = ['Submition errors will appear here.'];
            console.log(response);
            var customerRegistered = response.data;
            $scope.submission.successMessages = [];
            $scope.submission.successMessages.push($scope.newCustomer.LastName + ' has been successfully registed');
            $scope.submission.successMessages.push('Check ' + customerRegistered.UniqueKey + ' for reference number');
            $scope.newCustomer = {};
        }

        function registerCustomerFailed(response) {
            console.log(response);
            if (response.status == '400')
                $scope.submission.errorMessages = response.data;
            else
                $scope.submission.errorMessages = response.statusText;
        }

        function openDatePicker($event) {
            $event.preventDefault();
            $event.stopPropagation();

            $scope.datepicker.opened = true;
        };
    }

})(angular.module('incidencias'));