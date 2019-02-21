angular.module("umbraco").controller("NewsListBlock.Controller", function($scope, dialogService, newsListBlockConfig) {

	function Item() {
		this.dataSources = [];
	}

	$scope.control.value = $scope.control.value || new Item();
	$scope.config = {};

	newsListBlockConfig.getEditorConfig()
		.then(function (json) {
			$scope.config = json.data;
		});

	$scope.control.openOverlay = function () {
		dialogService.treePicker({
			filterCssClass: 'not-allowed not-published',
			filter: $scope.config.NewsListAlias,
			treeAlias: 'content',
			section: 'content',
			multiPicker: true,
			callback: function (data) {
				if (data) {
					$scope.control.value.dataSources = data;
				}
			}
		});
	}

	$scope.remove = function(index) {
		$scope.control.value.dataSources.splice(index, 1);
	};
});
