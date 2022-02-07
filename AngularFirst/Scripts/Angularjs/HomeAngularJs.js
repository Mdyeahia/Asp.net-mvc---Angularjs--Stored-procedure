var app = angular.module("Homeapp", []);

app.controller("HomeController", function ($scope,$http) {
    $scope.btntext = "Save"

    $scope.savedata = function () {
        $scope.btntext = "Please Wait....";
        $http({
            method: 'POST',
            url: '/Home/Add_record',
            data: $scope.Register,

        }).then(function (d) {
            $scope.btntext = "Save";
            $scope.Register = null;
           
        }).error(function () {
            alert('failed');
        });
    };
    $http.get("/Home/Get_data").then(function (d) {

        $scope.record = d.data;
        console.log('hi')
    }, function (error) {

        alert('Failed');

    });

});