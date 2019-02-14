(function() {

    function newsListBlockConfig($q, $http, umbRequestHelper) {
        return {
            getEditorConfig: function () {
                return $http.get(umbRequestHelper.getApiUrl("newsListBlockApi", "GetEditorConfig"));
            }
    	};
    }

    angular.module('umbraco.resources').factory('newsListBlockConfig', newsListBlockConfig);
})();