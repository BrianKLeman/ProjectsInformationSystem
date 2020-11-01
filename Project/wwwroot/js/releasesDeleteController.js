(function () {
    "use strict";
    angular.module("app-projects").controller("releasesDeleteController", releasesController);

    function releasesController($http, $routeParams) {
        var vm = this;

        vm.errorMessage = "starting delete";
        vm.isBusy = true;
        vm.projectId = $routeParams.projectId;
        vm.releaseId = $routeParams.releaseId;
        vm.deleteRelease = function () {
            vm.isBusy = true;
            vm.errorMessage = "";

            $http.delete("/api/project/" + vm.projectId + "/release/" + vm.releaseId).then(function (response) {
                vm.errorMessage = "deleted";
            }, function (errorMessage) {
                vm.errorMessage = errorMessage;
            }).finally(function () {
                vm.isBusy = false;
                $(location).attr("href", "/");
            });

        }
    }


})();