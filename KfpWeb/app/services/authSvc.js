angular.module('app')
  .factory('Auth', ['$http', '$location', '$rootScope', '$cookieStore', '$alert',
    function ($http, $location, $rootScope, $cookieStore, $alert) {
        $rootScope.currentUser = $cookieStore.get('user');
        //$cookieStore.remove('user');

        return {
            login: function (user, onsuccess, onerr) {
                return $http.post('/api/auth', user )
                  .success(function (data) {
                      $rootScope.currentUser = data;
                      if (onsuccess) onsuccess(data);
                  })
                  .error(function (err) {
                      console.log('[auth.js] err: ', err);
                      if (onerr) onerr(err);
                  });
            },
            logout: function () {
                return $http.get('/api/logout').success(function () {
                    $rootScope.currentUser = null;
                    $cookieStore.remove('user');
                    $alert({
                        content: 'You have been logged out.',
                        placement: 'top-right',
                        type: 'info',
                        duration: 3
                    });
                });
            }
        };
    }]);