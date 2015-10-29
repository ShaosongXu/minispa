app.controller("DeleteEmployeeController", function ($scope, $location, ShareData, SPACRUDSvc) {

    getEmployee();
    function getEmployee() {

        var promiseGetEmployee = SPACRUDSvc.getEmployee(ShareData.value);


        promiseGetEmployee.then(function (pl) {
            $scope.Employee = pl.data;
        },
              function (errorPl) {
                  $scope.error = 'failure loading Employee', errorPl;
              });
    }

    $scope.delete = function (fileName) {

        var promiseDeleteEmployee = SPACRUDSvc.delete(ShareData.value);

        promiseDeleteEmployee.then(function (pl) {
            SPACRUDSvc.removeFile(fileName);
            $location.path("/showemployees");
        },
            function (errorPl) {
                $scope.error = 'failure to deleting Employee', errorPl;
        });
   
    };

});