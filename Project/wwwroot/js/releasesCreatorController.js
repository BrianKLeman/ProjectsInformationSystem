(function () {
    "use strict";
    angular.module("app-projects").controller("releasesCreatorController", projectsController);

    function projectsController($http, $routeParams) {
        var vm = this;

        vm.release = {};
        vm.errorMessage = "starting create";
        vm.isBusy = true;
        vm.projectId = $routeParams.projectId;

        vm.createRelease = function () {
            vm.isBusy = true;
            vm.errorMessage = "";

            $http.post("/api/project/"+vm.projectId+"/release", vm.release).then(function (response) {
                vm.errorMessage = "created";
            }, function (errorMessage) {
                vm.errorMessage = errorMessage;
            }).finally(function () {
                vm.isBusy = false;

                $(location).attr("href", "/");
            });

        }
    }


})();