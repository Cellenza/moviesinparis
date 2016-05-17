angular.module('app.tour', [])
  .controller('tourCtrl', function ($scope, tourService) {
    
    
    $scope.themes =  ['romantique', 'action', 'comedie'];
    

  })
  .service('tourService', function ($http) {
    
    this.getTour = function (theme) {

      var defer = $q.defer();

      $http.get('http://scenecity.azurewebsites.net/api/AroundMe/10/10/test')
        .then(function (res) {

          defer.resolve(res.data);
        });
      return defer.promise;

    }
  })
