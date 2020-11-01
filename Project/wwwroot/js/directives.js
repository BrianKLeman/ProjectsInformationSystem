(function () {
    "use strict";
    angular.module("directives", [])
        .directive("storiesView", storiesView);

    function storiesView() {
        return {
            templateUrl: "/views/StoriesView.html"
        };

    }
})();