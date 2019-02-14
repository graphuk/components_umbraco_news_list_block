angular.module("umbraco").controller("NewsListBlock.Controller", function($scope) {

	function Item() {
		this.dataSource = [];
	}

	$scope.control.value = $scope.control.value || new Item();

	$scope.control.openOverlay = function(){
		$scope.control.overlay = {
			view: "contentpicker",
			show: true,
			submit: function(model) {
				$scope.control.overlay.show = false;
				$scope.control.overlay = null;
				$scope.control.value.dataSource = model.selection;
			},
			close: function(oldModel) {
				$scope.control.overlay.show = false;
				$scope.control.overlay = null;
			}
		}
	};

	$scope.remove = function(index) {
        $scope.control.value.dataSource.splice(index, 1);
    };
});
