var weatherController = function ($scope, $http, APIServiceFactory) {
    $scope.Customerlist = "Weather Controller";
    $scope.showCity = false;
    $scope.showCityInfo = false;
    $scope.showError=false;
    $scope.APIHit = function () {
        $scope.showCity = false;
        $scope.showError = false;
        $scope.selectcity = "";
        $scope.showSelected = false;
        var result = APIServiceFactory.getAPICalls("GetCities", $scope.Country)
         .then(function (response) {
             console.log("Data received at the client" + response.data);
             if (response.status == 200) {
                 $scope.cityList = response.data;
                 $scope.showCity = true
                 $scope.showCityInfo = false;
                 $scope.showSelected = true;
                 $scope.showError = false;
                 console.log(response.data);                
             }
             else {
                 $scope.showError = true;
                 $scope.showCityInfo = false;

             }
         });
    }

    $scope.hitAPIForCities = function () {
        if ($scope.selectcity.CityName != undefined) { 
            weatherObject = {
                "Country": $scope.Country,
                "Location": $scope.selectcity.CityName
            }
            if (weatherObject != null) {
                var result = APIServiceFactory.getAPICallsWithModel("GetCityWeatherInfo", weatherObject)
                             .then(function (response) {
                                 console.log("Data received at the client" + response.data);
                                 if (response.status == 200) {
                                     $scope.ReturnValue = response.data;
                                     $scope.showCityInfo = true;
                                     $scope.showError = false;
                                    
                                 }
                                 else {
                                     $scope.showError = true;
                                     $scope.showCityInfo = false;
                                 }
                             });
                
            }
        }
        else {
            alert("Select City Name");
            return;
        }
    }


 

}

