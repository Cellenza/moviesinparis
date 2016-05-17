angular.module('app.routes', ['app.around', 'app.tour', 'app.tourScenes'])

  .config(function ($stateProvider, $urlRouterProvider) {
    // Ionic uses AngularUI Router which uses the concept of states
    // Learn more here: https://github.com/angular-ui/ui-router
    // Set up the various states which the app can be in.
    // Each state's controller can be found in controllers.js
    $stateProvider
      .state('tabsController.cameraTabDefaultPage', {
        url: '/page2',
        views: {
          'tab1': {
            templateUrl: 'templates/around-me.html',
            controller: 'aroundMeCtrl'
          }
        }
      })

      .state('tabsController.tourPage', {
        url: '/page3',
        views: {
          'tab2': {
            templateUrl: 'templates/tour-page.html',
            controller: 'tourCtrl'
          }
        }
      })

      .state('tourScenesPage', {
        url: '/tour-scenes/:theme',
        templateUrl: 'templates/tour-scenes.html',
        controller: 'tourScenesCtrl'
      })
        
      .state('cloudTabDefaultPage', {
        url: '/page4',
        templateUrl: 'templates/cloudTabDefaultPage.html',
        controller: 'cloudTabDefaultPageCtrl'
      })

      .state('tabsController', {
        url: '/page1',
        templateUrl: 'templates/tabsController.html',
        abstract: true
      })

    $urlRouterProvider.otherwise('/page1/page2')

  });
