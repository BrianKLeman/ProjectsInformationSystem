(function () {
	"use strict";
	angular.module("app-projects").controller("projectEditorController", projectsController);

	function projectsController($http, $routeParams) {
		var vm = this;

		vm.project = {};
		vm.errorMessage = "";
        vm.isBusy = true;
        vm.stories = [];
		vm.updateProject = function () {
			vm.isBusy = true;
			vm.errorMessage = "";

			$http.put("/api/project", vm.project).then(function (response) {
				vm.errorMessage = "updated";
			}, function (errorMessage) {
				vm.errorMessage = errorMessage;
			}).finally(function () {
				vm.isBusy = false;
			});


		}

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

		$http.get("/api/project/"+$routeParams.projectId).then(function (response) {
			//success
			angular.copy(response.data, vm.project);
		}, function (error) {
			//failure
			vm.errorMessage = error;
		})
            .finally(function () {
            });

        $http.get("/api/projects/" + $routeParams.projectId +"/stories").then(function (response) {
            //success
            angular.copy(response.data, vm.stories);
        }, function (error) {
            //failure
            vm.errorMessage = error;
        })
            .finally(function () {
                vm.isBusy = false;
            });
	}


})();