app.controller('ShowNotesController', function ($scope, $location, SPACRUDSvc, empId, ShareData) {
    loadAllNotesRecords();

    function loadAllNotesRecords()
    {
        var p = SPACRUDSvc.getNotes(empId);
        
        p.then(function (pl) { $scope.Notes = pl.data },
              function (errorPl) {
                  $scope.error =  errorPl;
              });
    }

    //To Edit Note 
    $scope.editNote = function (NoteID) {
        ShareData.value = NoteID;
        $location.path("/editnote");
    }

    //To Delete a Note
    $scope.deleteNote = function (NoteID) {
        ShareData.value = NoteID;
        $location.path("/deletenote");
    }
});