angular.module("umbraco").controller("NewsListBlock.Controller", function($scope, dialogService) {

	function Item() {
		this.dataSource = [];
	}

	$scope.control.value = $scope.control.value || new Item();

	$scope.control.openOverlay = function () {
		dialogService.treePicker({
			filterCssClass: 'not-allowed not-published',
			filter: "NewsListPage",
			treeAlias: 'content',
			section: 'content',
			multiPicker: true,
			callback: function (data) {
				if (data) {
					$scope.control.value.dataSource = data;
				}
			}
		});
	}

	$scope.remove = function(index) {
		$scope.control.value.dataSource.splice(index, 1);
	};
});
