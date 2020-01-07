app.service("SentMailService", function ($http) {


    this.getMessageList = function () {

        var response = $http({
            method: 'post',
            url: 'GetMessageListForSentMail',           
        });
        return response;
    }       
});