angular.module('app.tourScenes', [])
  .controller('tourScenesCtrl', function ($scope, $stateParams, tourScenesService) {
    
    $scope.load = function () {
      tourScenesService.getTour($stateParams.theme).then(function(scenes) {
        
        scenes.scenes = scenes;
      })
    };
   
    
  })
  .service('tourScenesService', function ($http, $q) {
    
    this.getTour = function (theme) {

      var defer = $q.defer();

      $http.get('http://scenecity.azurewebsites.net/api/Tour/1/1/' + theme)
        .then(function (res) {

          defer.resolve(res.data);
        });
      return defer.promise;

    }
  })
