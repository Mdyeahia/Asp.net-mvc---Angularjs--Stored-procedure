ngApp.controller('HomeController', ['HomeService', '$scope','$http',function (HomeService, $scope, $http) {
    "use strict";
    $scope.btntext = "Save";

    $scope.savedata = function (Register) {
        $scope.btntext = "Please Wait....";
        HomeService.Add_record(Register).then(function () {
            $scope.btntext = "Save";
            $scope.Register = null;
            $scope.datatable();
        }).error(function () {
            alert('failed');
        });
    };
    $scope.datatable = function () {
        //HomeService.getrecordTable().then(function(response) {
        //    $scope.record = response;
            window.setTimeout(function () {
                window.location.href = "../Home/Show_data";
            }, 3000)
        //}).error(function () {
        //    alert('failed');
        //});
    }
    $http.get("/Home/Get_data").then(function (d) {

        $scope.record = d.data;
        console.log('hi')
    }, function (error) {

        alert('Failed');

    });

}
]);