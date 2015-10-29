app.controller("DeleteNoteController", function ($scope, $location, ShareData, empId, SPACRUDSvc) {

    getNote();
    function getNote() {

        var p = SPACRUDSvc.getNote(empId, ShareData.value);


        p.then(function (pl) {
            $scope.Note = pl.data;
        },
            function (errorPl) {
                $scope.error = 'failure loading Note', errorPl;
        });
    }

    $scope.delete = function () {

        var p = SPACRUDSvc.deleteNote(ShareData.value);

        p.then(function (pl) {
            $location.path("/shownotes");
        },
            function (errorPl) {
                $scope.error = 'failure to deleting Note', errorPl;
        });
   
    };

});