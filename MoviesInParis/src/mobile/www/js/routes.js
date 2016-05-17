angular.module('app.routes', ['app.around', 'app.tour', 'app.tourScenes'])

  .config(function ($stateProvider, $urlRouterProvider) {
    // Ionic uses AngularUI Router which uses the concept of states
    // Learn more here: https://github.com/angular-ui/ui-router
    // Set up the various states which the app can be in.
    // Each state's controller can be found in controllers.js
    $stateProvider
      .state('tab', {
        url: '/page1',
        templateUrl: 'templates/tabsController.html',
        abstract: true
      })
      .state('tab.cameraTabDefaultPage', {
        url: '/page2',
        views: {
          'tab1': {
            templateUrl: 'templates/around-me.html',
            controller: 'aroundMeCtrl'
          }
        }
      })

      .state('tab.tourPage', {
        url: '/page3',
        views: {
          'tab2': {
            templateUrl: 'templates/tour-page.html',
            controller: 'tourCtrl'
          }
        }
      })

      .state('tab.tourScenesPage', {
        url: '/tour-scenes/:theme',
        views: {
          'tab2': {
            templateUrl: 'templates/tour-scenes.html',
            controller: 'tourScenesCtrl'
          }
        }
        //  templateUrl: 'templates/tour-scenes.html'
      })

      .state('cloudTabDefaultPage', {
        url: '/page4',
        templateUrl: 'templates/cloudTabDefaultPage.html',
        controller: 'cloudTabDefaultPageCtrl'
      })



    $urlRouterProvider.otherwise('/page1/page2')

  });
