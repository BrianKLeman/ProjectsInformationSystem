(function () {
    "use strict";
    angular.module("app-projects").controller("releasesController", projectsController);

    function projectsController($http, $routeParams) {
        var vm = this;
        vm.releases = [];
        vm.projectId = $routeParams.projectId;
        vm.project = {};
        vm.errorMessage = "starting get";
        vm.isBusy = true;
        vm.updateRelease = function () {
            vm.isBusy = true;
            vm.errorMessage = "";

            $http.put("/api/project/" + $routeParams.projectId + "/release", vm.project).then(function (response) {
                vm.projects.push(response.data);
            }, function (errorMessage) {
                vm.errorMessage = errorMessage;
            }).finally(function () {
                vm.isBusy = false;

                $(location).attr("href", "/");
            });


        }

        $http.get("/api/project/" + $routeParams.projectId + "/release").then(function (response) {
            //success
            angular.copy(response.data, vm.releases);
        }, function (error) {
            //failure
            vm.errorMessage = error;
        })
            .finally(function () {
                vm.isBusy = false;
            });
    }


})();