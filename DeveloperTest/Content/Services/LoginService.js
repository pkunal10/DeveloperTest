app.service("LoginService", function ($http) {


    this.login = function (uname, password) {

        var response = $http({
            method: 'post',
            url: '/Home/LoginCheck',
            params: {
                Uname: uname,
                Password: password
            }
        });
        return response;
    }


});