angular.module('app')
  .controller('picksCtrl', ['$rootScope', '$scope', 'Auth', '$cookieStore', '$location', 'Game', 'Pick',
      function ($rootScope, $scope, Auth, $cookieStore, $location, Game, Pick) {

          var user;

          /// TRY TO AUTHENTICATE
          if ($rootScope.currentUser) {
              user = $rootScope.currentUser;
              console.log('[picksCtrl.js] Authorized');
          }
          else if ($cookieStore.get("lastUser")) {
              $rootScope.currentUser = $cookieStore.get("lastUser"); 
              user = $rootScope.currentUser;
              console.log('[picksCtrl.js] Re-Authorized');
          }
          else {
              $location.path('/login');
          }

          Date.prototype.addHours = function (h) {
              this.setHours(this.getHours() + h);
              return this;
          }


          $scope.teamClick = function (game, team) {

              if ($scope.pick.pick5TeamId == null) {
                  $scope.pick.pick5Team = team;
                  $scope.pick.pick5TeamId = team.id;
              }
              else if ($scope.pick.pick3TeamId == null) {
                  $scope.pick.pick3Team = team;
                  $scope.pick.pick3TeamId = team.id;
                  return;
              }
              else if ($scope.pick.pick2TeamId == null) {
                  $scope.pick.pick2Team = team;
                  $scope.pick.pick2TeamId = team.id;
                  return;
              }
          }

          $scope.week = 1;
          $scope.currentTime = new Date();


          // Cutoff time
          $scope.cutoffTime = new Date().addHours(1);
          $scope.isCutoff = function (kickoff, cutoff) {
              kickoff = new Date(kickoff);
              cutoff = new Date(cutoff);
              return (kickoff < cutoff);
          }


          // is date different
          var _date;
          $scope.isDifferent = function (date) {
              if (_date == date) return false;
              _date = date;
              return true;
          }


          Pick.get({ week: $scope.week, username: user.username },
              function (resp) {
                  console.log(resp);
                  $scope.pick_pristine = angular.copy($scope.pick);
                  console.log($scope.pick);
                  console.log($scope.pick_pristine);
              });
          $scope.games = Game.query({ week: $scope.week });

      }]);