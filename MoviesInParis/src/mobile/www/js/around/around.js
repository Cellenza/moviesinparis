angular.module('app.around', [])
  .service('aroundService', function ($http, $q) {

    this.retrieveMovies = function (longitute, latitude) {

      var defer = $q.defer();

      $http.get('http://scenecity.azurewebsites.net/api/AroundMe/10/10')
        .then(function (res) {

          defer.resolve(res.data);
        });
      return defer.promise;

    }

  })
  .controller('aroundMeCtrl', function ($scope, aroundService) {

    $scope.movies = [];
    $scope.load = function () {

      aroundService.retrieveMovies().then(function(movies){

        $scope.movies = movies
      });
    }
  });



