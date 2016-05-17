angular.module('app.tourScenes', [])
  .controller('tourScenesCtrl', function ($scope, tourScenesService) {
    
    $scope.load = function (theme) {
      tourService.getTour(theme).then(function(scenes) {
        
        scenes.scenes = scenes;
      })
    };
   
    
  })
  .service('tourScenesService', function ($http) {
    
    this.getTour = function (theme) {

      var defer = $q.defer();

      $http.get('http://scenecity.azurewebsites.net/api/Tour/10/10/' + theme)
        .then(function (res) {

          defer.resolve(res.data);
        });
      return defer.promise;

    }
  })
