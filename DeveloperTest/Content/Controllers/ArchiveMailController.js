app.controller("ArchiveMailCntrl", function ($scope, growl, ArchiveMailService) {

    $("#divLoading").hide();
    getMessageList();
  
    function getMessageList() {
        ArchiveMailService.getMessageList().then(function (data) {
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