app.controller('AddEmployeeController', function ($scope, $timeout, $location, SPACRUDSvc) {
    $scope.EmployeeID = 0;
    $scope.thumbnail = {
        dataUrl: '',
        file: {}
    };
    $scope.fileReaderSupported = window.FileReader != null;
    $scope.photoChanged = function (files) {
        if (files != null) {
            var file = files[0];
            $scope.thumbnail.file = file;
            $scope.ImgUrl = file.name;

            if ($scope.fileReaderSupported && file.type.indexOf('image') > -1) {
                $timeout(function () {
                    var fileReader = new FileReader();
                    fileReader.readAsDataURL(file);

                    fileReader.onload = function (e) {
                        $timeout(function () {

                            $scope.thumbnail.dataUrl = e.target.result;
                        });
                    }
                });
            }
        }
    };
    $scope.save = function () {
        var Employee = {
            EmployeeID: $scope.EmployeeID,
            Name: $scope.Name,
            ImgUrl: $scope.ImgUrl,
            Email: $scope.Email,
            HiredYear: $scope.HiredYear,
            City: $scope.City,
            Country: $scope.Country
        };

        var promisePost = SPACRUDSvc.post(Employee);

        promisePost.then(function (pl) {
            SPACRUDSvc.uploadFile($scope.thumbnail.file).then(function () {
//                alert("Employee saved Successfully.");
                $location.path("/showemployees");
            },
              function (errorPl) {
                  $scope.error = 'failure saving Employee', errorPl;
              }
            );
        },

        function (errorPl) {
            $scope.error = 'failure saving Employee', errorPl;
        });
    };
});