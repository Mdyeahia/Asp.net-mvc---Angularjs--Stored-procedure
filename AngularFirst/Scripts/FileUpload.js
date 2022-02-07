var app = angular.module('Uploadapp', ['ngFileUpload'])
app.controller('MyController', function ($scope, Upload, $timeout) {
    $scope.UploadFiles = function (files) {
        $scope.SelectedFiles = files;
        if ($scope.SelectedFiles && $scope.SelectedFiles.length) {

            Upload.Upload({
                url: '/Home/Upload',
                data: {
                    files: $scope.SelectedFiles
                }
            }).then(function (response) {
                $timeout(function () {
                    $scope.result = response.data;
                })
            }, function (response) {
                if (response.status > 0) {
                    var errormsg = response.status + ':' + response.data;
                }
            }, function (d) {
                var element = angular.element(document.querySelector('#divprogress'));
                $scope.Progress = Math.min(100, parseInt(100.0 * d.loaded / d.total));
                element.html('<div style="width:' + $scope.Progress + '%">' + $scope.Progress + '%</div>');

            });
        }
    }
})