app.controller("LoginCntrl", function ($scope, growl, LoginService) {

    $("#divLoading").hide();
    

    $scope.Login = function () {

        if ($scope.EmailId == "" || $scope.EmailId== undefined) {
            growl.error("Enter EmailID.", { title: 'Error!', ttl: 2000 });
            return false;
        }
        else if ($scope.Password == "" || $scope.Password == undefined) {
            growl.error("Enter Password.", { title: 'Error!', ttl: 2000 });
            return false;
        }
        else {
            $("#divLoading").show();
            LoginService.login($scope.EmailId, $scope.Password).then(function (data) {

                if (data.data.Status == "AuthenticationFailed") {
                    growl.error(data.data.msg, { title: 'Error!', ttl: 2000 });
                    $scope.EmailId = "";
                    $scope.Password = "";
                    $("#divLoading").hide();
                }
                else {
                    location.href = 'Message/Inbox';
                }


            });
        }

    }    
});