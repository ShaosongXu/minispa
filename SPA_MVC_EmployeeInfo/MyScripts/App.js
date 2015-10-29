var app = angular.module("App", ["ngRoute"]);

app.factory("ShareData", function () {
    return { value: 0 }
});

//Showing Routing
app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    debugger;
    $routeProvider.when('/showemployees',
                        {
                            templateUrl: 'ManageEmployeeInfo/ShowEmployees',
                            controller: 'ShowEmployeesController'
                        });
    $routeProvider.when('/addemployee',
                        {
                            templateUrl: 'ManageEmployeeInfo/AddNewEmployee',
                            controller: 'AddEmployeeController'
                        });
    $routeProvider.when("/editEmployee",
                        {
                            templateUrl: 'ManageEmployeeInfo/EditEmployee',
                            controller: 'EditEmployeeController'
                        });
    $routeProvider.when('/deleteEmployee',
                        {
                            templateUrl: 'ManageEmployeeInfo/DeleteEmployee',
                            controller: 'DeleteEmployeeController'
                        });
    $routeProvider.when('/shownotes',
                        {
                            templateUrl: 'ManageEmployeeNote/ShowNotes',
                            controller: 'ShowNotesController'
                        });
    $routeProvider.when('/addnote',
                        {
                            templateUrl: 'ManageEmployeeNote/AddNewNote',
                            controller: 'AddNoteController'
                        });
    $routeProvider.when("/editnote",
                        {
                            templateUrl: 'ManageEmployeeNote/EditNote',
                            controller: 'EditNoteController'
                        });
    $routeProvider.when('/deletenote',
                        {
                            templateUrl: 'ManageEmployeeNote/DeleteNote',
                            controller: 'DeleteNoteController'
                        });
    $routeProvider.otherwise(
                        {
                            redirectTo: '/'
                        });
    
    $locationProvider.html5Mode(true).hashPrefix('!')
}]);