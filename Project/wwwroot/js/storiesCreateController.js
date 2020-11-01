(function () {
    "use strict";
    angular.module("app-projects").controller("storiesCreateController", storiesCreateController);

    function storiesCreateController($http, $routeParams) {
        var storyVm = this;

        storyVm.story = {};
        storyVm.errorMessage = "starting create";
        storyVm.isBusy = false;
        storyVm.projectId = $routeParams.projectId;

        storyVm.createStory = function () {
            storyVm.isBusy = true;
            storyVm.errorMessage = "";

            $http.post("api/Projects/" +storyVm.projectId+"/Stories/", storyVm.story).then(function (response) {
                storyVm.errorMessage = "created";
            }, function (errorMessage) {
                storyVm.errorMessage = errorMessage;
            }).finally(function () {
                storyVm.isBusy = false;

                //$(location).attr("href", "/");
                });
            
        }

        storyVm.deleteStory = function () {
            storyVm.isBusy = true;
            storyVm.errorMessage = "";

            $http.delete("api/Projects/" + storyVm.projectId + "/Stories/", storyVm.story.StoryId).then(function (response) {
                storyVm.errorMessage = "deleted";
            }, function (errorMessage) {
                storyVm.errorMessage = errorMessage;
            }).finally(function () {
                storyVm.isBusy = false;

                //$(location).attr("href", "/");
            });
        }
    }


})();