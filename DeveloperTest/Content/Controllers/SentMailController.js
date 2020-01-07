app.controller("SentMailCntrl", function ($scope, growl, SentMailService) {

    $("#divLoading").hide();
    getMessageList();
  
    function getMessageList() {
        SentMailService.getMessageList().then(function (data) {
            if (data.data.Status == "Success") {
                $scope.messageList = data.data.data;
            }
            else
            {
                growl.error(data.data.msg, { title: 'Error!', ttl: 3000 });
            }
        })
    }
});