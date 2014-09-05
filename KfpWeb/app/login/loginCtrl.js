angular.module('app')
  .controller('loginCtrl', ['$scope', 'Auth', '$cookieStore',
      function ($scope, Auth, $cookieStore) {

          $scope.status = "Login";

          // get last values from cookie
          var lastUser = $cookieStore.get("lastUser");
          if (lastUser) {
              $scope.username = lastUser.username;
              $scope.password = lastUser.password;
          }

          $scope.loginClick = function () {

              if (!$scope.username || $scope.username.indexOf('@') < 0 || $scope.username.indexOf('.') < 0) {
                  alert('Please enter a vaild email address.')
              } else if (!$scope.password) {
                  alert('Please enter a password.')
              } else {
                  // attempt login
                  $scope.waiting = true;
                  $scope.status = "logging in...";
                  Auth.login({
                      username: $scope.username,
                      password: $scope.password
                  },
                  // SUCCESS!
                  function (data) {
                      $.cookie("lastUser", JSON.stringify(data), { expires: 365, path: '/' } );
                      $scope.waiting = false;
                      $scope.status = "Logged in.";
                  }, 
                  /// ERROR
                  function (err) {
                      $scope.waiting = false;
                      $scope.status = err.ExceptionMessage;
                  });
              }
          };
      }]);

