(function () {
    "use strict";
    angular.module("app-projects").controller("projectsConfirmDeleteController", projectsController);

    function projectsController($http, $routeParams) {
        var vm = this;
        
        vm.errorMessage = "starting delete";
        vm.isBusy = true;
        vm.projectId = $routeParams.projectId;
        vm.projectName = $routeParams.projectName;
        vm.deleteProject = function () {
            vm.isBusy = true;
            vm.errorMessage = "";

            $http.delete("/api/project/" + vm.projectId).then(function (response) {
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