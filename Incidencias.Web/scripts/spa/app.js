(function () {
    'use strict';

    angular.module('incidencias', ['common.core', 'common.ui'])
        .config(config)
        .run(run);

    config.$inject = ['$routeProvider'];
    function config($routeProvider) {
        $routeProvider
            .when("/", {
                templateUrl: "scripts/spa/home/index.html",
                controller: "indexCtrl"
            })
            .when("/login", {
                templateUrl: "scripts/spa/account/login.html",
                controller: "loginCtrl"
            })
            .when("/register", {
                templateUrl: "scripts/spa/account/register.html",
                controller: "registerCtrl"
            })
            .when("/tecnicos", {
                templateUrl: "scripts/spa/tecnicos/tecnicos.html",
                controller: "tecnicosCtrl"
            })
            .when("/tecnicos/register", {
                templateUrl: "scripts/spa/tecnicos/register.html",
                controller: "tecnicosRegCtrl",
                resolve: { isAuthenticated: isAuthenticated }
            })
            .when("/incidencias", {
                templateUrl: "scripts/spa/incidencias/incidencias.html",
                controller: "incidenciasCtrl"
            })
            .when("/incidencias/add", {
                templateUrl: "scripts/spa/incidencias/add.html",
                controller: "incidenciasAddCtrl",
                resolve: { isAuthenticated: isAuthenticated }
            })
            .when("/incidencias/:id", {
                templateUrl: "scripts/spa/incidencias/details.html",
                controller: "incidenciasDetailsCtrl",
                resolve: { isAuthenticated: isAuthenticated }
            })
            .when("/incidencias/edit/:id", {
                templateUrl: "scripts/spa/incidencias/edit.html",
                controller: "incidenciasEditCtrl"
            })
            .when("/aplicaciones", {
                templateUrl: "scripts/spa/aplicaciones/aplicaciones.html",
                controller: "aplicacionesCtrl"
            }).otherwise({ redirectTo: "/" });
    }

    run.$inject = ['$rootScope', '$location', '$cookieStore', '$http'];

    function run($rootScope, $location, $cookieStore, $http) {
        // handle page refreshes
        $rootScope.repository = $cookieStore.get('repository') || {};
        if ($rootScope.repository.loggedUser) {
            $http.defaults.headers.common['Authorization'] = $rootScope.repository.loggedUser.authdata;
        }

        $(document).ready(function () {
            //$(".fancybox").fancybox({
            //    openEffect: 'none',
            //    closeEffect: 'none'
            //});

            //$('.fancybox-media').fancybox({
            //    openEffect: 'none',
            //    closeEffect: 'none',
            //    helpers: {
            //        media: {}
            //    }
            //});

            $('[data-toggle=offcanvas]').click(function () {
                $('.row-offcanvas').toggleClass('active');
            });
        });
    }

    isAuthenticated.$inject = ['membershipService', '$rootScope', '$location'];

    function isAuthenticated(membershipService, $rootScope, $location) {
        if (!membershipService.isUserLoggedIn()) {
            $rootScope.previousState = $location.path();
            $location.path('/login');
        }
    }

})();