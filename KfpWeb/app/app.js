﻿angular.module('app',
    ['ngCookies',
    'ngResource',
    /*'ngMessages',*/
    'ngRoute',
    'mgcrea.ngStrap'])

.config(['$locationProvider', '$routeProvider',

    function ($locationProvider, $routeProvider) {

        $locationProvider.html5Mode(true);

        $routeProvider
            .when('/', {
                templateUrl: 'app/picks/picks.html',
                controller: 'picksCtrl'
            })
            .when('/login', {
                templateUrl: 'app/login/login.html',
                controller: 'loginCtrl'
            })
            .otherwise({
                redirectTo: '/'
            });
    }]);