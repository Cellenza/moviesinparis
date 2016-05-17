angular.module('app.movie', [])
  .controller('tourCtrl', function ($scope, movieService) {
    
    $scope.load = function () {
      tourService.getMovieDetails(title).then(function(movie) {
        scope.movie = movie
      })
    };

  })
  .service('movieService', function ($http) {
    
    this.getMovieDetails = function (title) {

      var defer = $q.defer();

      $http.get('http://scenecity.azurewebsites.net/api/AroundMe/10/10/test')
        .then(function (res) {

          defer.resolve(res.data);
        });
      return defer.promise;

    }
  })
