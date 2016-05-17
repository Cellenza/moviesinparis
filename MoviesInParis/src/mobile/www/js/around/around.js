angular.module('app.around', [])
  .service('aroundService', function ($http, $q) {

    this.retrieveMovies = function (longitute, latitude) {

      var defer = $q.defer();

      $http.get('http://scenecity.azurewebsites.net/api/AroundMe/10/10/test')
        .then(function (res) {

          defer.resolve(res.data);
        });
      return defer.promise;

    }

  })
  .controller('aroundMeCtrl', function (aroundService, $cordovaGeolocation) {
    
    
  });



