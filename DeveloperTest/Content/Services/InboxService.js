app.service("InboxService", function ($http) {


    this.getMessageList = function () {

        var response = $http({
            method: 'post',
            url: 'GetMessageListForInbox',           
        });
        return response;
    }

    this.getEmailIdsForAutoComplete= function (id) {
        var response = $http({
            method: "post",
            url: "GetEmailIdsForAutoComplete",
        });
        return response;
    }
    this.sendEmail = function (model) {
        var response = $http({
            method: "post",
            url: "MessageSend",
            data: model,
            dataType: JSON.stringify
        });
        return response;
    }

    this.deleteMail = function (id) {
        var response = $http({
            method: "post",
            url: "DeleteMail",
            params: {
                messageId: id
            }
        });
        return response;
    }    

    this.messageArchive= function (id) {
        var response = $http({
            method: "post",
            url: "MakeMailArchive",
            params: {
                messageId: id
            }
        });
        return response;
    }    
});