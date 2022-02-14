ngApp.service('HomeService', function ($http) {

    this.Add_record = function (model)
    {
        return $http.post('../Home/Add_record', { rs: model });
    }
    this.getrecordTable = function () {
        return $http.post('../Home/Get_data');
    }

})