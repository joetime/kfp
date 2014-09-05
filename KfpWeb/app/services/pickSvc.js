angular.module('app')
  .factory('Pick', ['$resource', function ($resource) {
      return $resource('/api/picks/:week/:username');
  }]);