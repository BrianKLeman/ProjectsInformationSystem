(function () {
    angular.module("app-projects", ["ngRoute", "simpleControls", "directives"]).config(
        function ($routeProvider) {
            $routeProvider.when("/", {
                controller: "projectsController",
                controllerAs: "vm",
                templateUrl: "/views/projectsView.html"
            });

            $routeProvider.when("/editor/:projectId", {
                controller: "projectEditorController",
                controllerAs: "vm",
                templateUrl: "/views/projectsEditor.html"
            });

            $routeProvider.when("/create", {
                controller: "projectEditorController",
                controllerAs: "vm",
                templateUrl: "/views/projectsCreator.html"
            });

            $routeProvider.when("/delete/:projectId/:projectName", {
                controller: "projectsConfirmDeleteController",
                controllerAs: "vm",
                templateUrl: "/views/projectsDeleteView.html"
            });

            $routeProvider.when("/create/release/:projectId", {
                controller: "releasesCreatorController",
                controllerAs: "vm",
                templateUrl: "/views/releasesCreator.html"
            });

            $routeProvider.when("/view/release/:projectId", {
                controller: "releasesController",
                controllerAs: "vm",
                templateUrl: "/views/releasesView.html"
            });

            $routeProvider.when("/editRelease/:releaseId/:projectId", {
                controller: "releasesEditorController",
                controllerAs: "vm",
                templateUrl: "/views/releasesEditor.html"
            });

            $routeProvider.when("/project/:projectId/release/delete/:releaseId", {
                controller: "releasesDeleteController",
                controllerAs: "vm",
                templateUrl: "/views/releasesDelete.html"
            });

            $routeProvider.when("/project/:projectId/stories/create", {
                controller: "storiesCreateController",
                controllerAs: "storyVm",
                templateUrl: "/views/storiesCreator.html"
            });

            $routeProvider.otherwise({ redirectTo: "/" });
        }
    );
})();