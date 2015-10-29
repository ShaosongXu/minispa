app.service("SPACRUDSvc", function ($http ) {

    //Read all Employees
    this.getEmployees = function () {

        return $http.get("/api/ManageEmployeeInfoAPI");
    };

    //Fundction to Read Employee by Employee ID
    this.getEmployee = function (id) {
        return $http.get("/api/ManageEmployeeInfoAPI/" + id);
    };

    //Function to create new Employee
    this.post = function (Employee) {
        var request = $http({
            method: "post",
            url: "/api/ManageEmployeeInfoAPI",
            data: Employee
        });
        return request;
    };

    //Edit Employee By ID 
    this.put = function (id, Employee) {
        var request = $http({
            method: "put",
            url: "/api/ManageEmployeeInfoAPI/" + id,
            data: Employee
        });
        return request;
    };

    //Delete Employee By Employee ID
    this.delete = function (id) {
        var request = $http({
            method: "delete",
            url: "/api/ManageEmployeeInfoAPI/" + id
        });
        return request;
    };

    //Read all Notes
    this.getNotes = function (id) {
        var data = $.param({
            empId: id
        });

        return $http.get("/api/ManageEmployeeNoteAPI?" + data);
    };

    //Function to Read Note by Note ID
    this.getNote = function (empId, id) {
        var data = $.param({
            empId: empId,
            id: id
        });
        return $http.get("/api/ManageEmployeeNoteAPI?" + data);
    };

    //Function to create new Note
    this.postNote = function (Note) {
        var request = $http({
            method: "post",
            url: "/api/ManageEmployeeNoteAPI",
            data: Note
        });
        return request;
    };

    //Edit Note By ID 
    this.putNote = function (id, Note) {
        var request = $http({
            method: "put",
            url: "/api/ManageEmployeeNoteAPI/" + id,
            data: Note
        });
        return request;
    };

    //Delete Note By Note ID
    this.deleteNote = function (id) {
        var request = $http({
            method: "delete",
            url: "/api/ManageEmployeeNoteAPI/" + id
        });
        return request;
    };

    //Function to upload file
    this.uploadFile = function(file){
        var fd = new FormData();
        fd.append('file', file);
        return $http.post("/api/fileupload", fd, {
            transformRequest: angular.identity,
            headers: {'Content-Type': undefined}
        });
    }

    //Function to remove file
    this.removeFile = function (fileName) {

        var data = $.param({
            fileName: fileName
        });

        var request = $http.delete('/api/FileUpload?' + data)

        return request;
    }
});








