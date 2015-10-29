app.controller("EditEmployeeController", function ($scope, $timeout, $location, ShareData, SPACRUDSvc) {
    $scope.thumbnail = {
        dirty: false,
        dataUrl: '',
        file: {}
    };
    getEmployee();

    function getEmployee() {
        var promiseGetEmployee = SPACRUDSvc.getEmployee(ShareData.value);

        promiseGetEmployee.then(function (pl)
        {
            $scope.Employee = pl.data;
        },
              function (errorPl) {
                  $scope.error = 'failure loading Employee', errorPl;
              });
    }

    $scope.fileReaderSupported = window.FileReader != null;
    $scope.photoChanged = function (files) {
        if (files != null) {
            var file = files[0];

            if (file.name === $scope.Employee.imgUrl)
                return;

            if ($scope.fileReaderSupported && file.type.indexOf('image') > -1) {
                $timeout(function () {
                    var fileReader = new FileReader();
                    fileReader.readAsDataURL(file);

                    fileReader.onload = function (e) {
                        $timeout(function () {
                            $scope.thumbnail.dirty = true;
                            $scope.thumbnail.file = file;
                            $scope.thumbnail.dataUrl = e.target.result;
                            $scope.$apply();
                        });
                    }
                });
            }
        }
    };
    $scope.save = function () {
        var Employee = {
            EmployeeID: $scope.Employee.employeeID,
            Name: $scope.Employee.name,
            ImgUrl: $scope.thumbnail.dirty ? $scope.thumbnail.file.name : $scope.Employee.imgUrl,
            Email: $scope.Employee.email,
            HiredYear: $scope.Employee.hiredYear,
            City: $scope.Employee.city,
            Country: $scope.Employee.country
        };

        if ($scope.thumbnail.dirty) {
            SPACRUDSvc.uploadFile($scope.thumbnail.file).then(function (pl) {
                $scope.thumbnail.dirty = true;
                SPACRUDSvc.removeFile($scope.Employee.imgUrl);
                var promisePutEmployee = SPACRUDSvc.put($scope.Employee.employeeID, Employee);
                promisePutEmployee.then(function (pl) {
                    $location.path("/showemployees");
                },
                    function (errorPl) {
                        $scope.error = 'failure saving Employee', errorPl;
                    }
                );
            },
              function (errorPl) {
                  $scope.error = 'failure saving Employee', errorPl;
              }
            );
        }
        else
        {
            var promisePutEmployee = SPACRUDSvc.put($scope.Employee.employeeID, Employee);
            promisePutEmployee.then(function (pl) {
                $location.path("/showemployees");
            },
                function (errorPl) {
                    $scope.error = 'failure saving Employee', errorPl;
                }
            );
        }

    };

});