ngApp.service('HomeService', function ($http) {

    this.Add_record = function (model)
    {
        return $http.post('../Home/Add_record', { rs: model });
    }
    this.getrecordTable = function () {
        return $http.post('../Home/Get_data');
    }
    this.UpdateRecord = function (model) {
        return $http.post('../Home/Update_record', { rs: model })
    }
    this.DeleteRecord = function (id) {
        return $http.post('../Home/Delete_record', { id:id })
    }

})