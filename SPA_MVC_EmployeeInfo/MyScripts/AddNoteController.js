app.controller('AddNoteController', function ($scope, $timeout, $location, empId, SPACRUDSvc) {
    $scope.NoteID = 0;

    $scope.save = function () {
        var Note = {
            EmployeeID: empId,
            NoteID: $scope.NoteID,
            Description: $scope.Description
        };

        var promisePost = SPACRUDSvc.postNote(Note);

        promisePost.then(function (pl) {
 //           alert("Note saved Successfully.");
                $location.path("/shownotes");
            },
            function (errorPl) {
                  $scope.error = 'failure saving Note', errorPl;
              }
        );
    };
});