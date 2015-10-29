app.controller("EditNoteController", function ($scope, $timeout, $location, ShareData, empId, SPACRUDSvc) {

    getNote();

    function getNote() {
        var p = SPACRUDSvc.getNote(empId, ShareData.value);

        p.then(function (pl)
        {
            $scope.Note = pl.data;
        },
            function (errorPl) {
                $scope.error = 'failure loading Note', errorPl;
        });
    }

    $scope.save = function () {
        var Note = {
            EmployeeID: $scope.Note.employeeID,
            NoteID: $scope.Note.noteID,
            Description: $scope.Note.description
        };

        var p = SPACRUDSvc.putNote($scope.Note.noteID, Note);
        p.then(function (pl) {
            $location.path("/shownotes");
        },
            function (errorPl) {
                $scope.error = 'failure saving Note', errorPl;
            }
        );
    };
});