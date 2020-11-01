(function () {
    "use strict";
    angular.module("app-projects").controller("releasesEditorController", projectsController);

    function projectsController($http, $routeParams) {
        var vm = this;

        vm.release = {};
        vm.releaseId = $routeParams.releaseId;
        vm.projectId = $routeParams.projectId;
        vm.errorMessage = "starting get";
        vm.isBusy = true;
        vm.updateRelease = function () {
            vm.isBusy = true;
            vm.errorMessage = "";

            $http.put("/api/project/" + vm.projectId + "/release/" + vm.releaseId, vm.release).then(function (response) {
                vm.errorMessage = "updated";
            }, function (errorMessage) {
                vm.errorMessage = errorMessage;
            }).finally(function () {
                vm.isBusy = false;
            });


        }

       

        $http.get("/api/project/" + vm.projectId + "/release/" + vm.releaseId).then(function (response) {
            //success
            angular.copy(response.data, vm.release);
            vm.release.expectedReleaseDate = "01/03/2018";
        }, function (error) {
            //failure
            vm.errorMessage = error;
        })
            .finally(function () {
                vm.isBusy = false;
            });
    }


})();