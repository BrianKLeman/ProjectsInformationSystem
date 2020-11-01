(function () {
    "use strict";
    angular.module("app-projects").controller("projectEditorController", projectsController);

    function projectsController($http, $routeParams) {
        var vm = this;

        vm.project = {};
        vm.errorMessage = "starting create";
        vm.isBusy = true;
        

        vm.createProject = function () {
            vm.isBusy = true;
            vm.errorMessage = "";

            $http.post("/api/project", vm.project).then(function (response) {
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