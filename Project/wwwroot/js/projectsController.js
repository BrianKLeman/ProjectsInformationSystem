(function () {
    "use strict";
    angular.module("app-projects").controller("projectsController", projectsController);

    function projectsController($http)
    {
        var vm = this;
        vm.projects = [];

        vm.project = {};
        vm.errorMessage = "starting get";
        vm.isBusy = true;
        vm.updateProject = function () 
        {
            vm.isBusy = true;
            vm.errorMessage = "";

            $http.put("/api/project", vm.project).then(function (response) {
                vm.projects.push(response.data);
            }, function (errorMessage) {
                vm.errorMessage = errorMessage;
            }).finally(function () {
                vm.isBusy = false;

                $(location).attr("href", "/");
                });


        }

        $http.get("/api/project").then(function (response) {
            //success
            angular.copy(response.data, vm.projects);
        }, function (error) {
            //failure
            vm.errorMessage = error;
        })
            .finally(function () {
                vm.isBusy = false;
            });
    }


})();