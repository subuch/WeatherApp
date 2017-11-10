/**********ModuleRegistration*********/
var serverURL = "http://localhost:17261/";
var augModule = angular.module("myAug", []);

/**********ControllerRegistration*********/
augModule.controller("weather", weatherController);

/*******RegisteredFactory******/
augModule.factory("APIServiceFactory", ['$http', '$log', function ($http, $log) {


    var returnObj = {};
    returnObj.getAPICalls = function (actionName, attribute) {
        return $http.get(serverURL + actionName + "/" + attribute)
        .then(function (response) {
            $log.info(response);
            return response;
        }, function (reason) {
            $log.info(reason);
            return reason;
        })
    }

    returnObj.getAPICallsWithModel = function (method, objModel) {
       
        return $http({
            method: 'POST',
            headers: { 'Content-Type': 'Application/JSON' },
            data: objModel,
            url: serverURL + method
        })
         .then(function (response) {
             $log.info(response);
             return response;
         }, function (reason) {
             $log.info(reason);
             return reason;
         });
    }

    return returnObj;
}]);

