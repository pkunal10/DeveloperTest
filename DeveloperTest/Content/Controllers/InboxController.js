app.controller("InboxCntrl", function ($scope, growl, InboxService) {

    $("#divLoading").hide();
    getMessageList();
    getEmailIdsForAutoComplete();

    function getEmailIdsForAutoComplete() {

        InboxService.getEmailIdsForAutoComplete().then(function (data) {

            if (data.data.Status == "Success") {
                $scope.EmailIdsList = data.data.data;
            }

        })

    }


    $scope.complete = function (string) {

        var output = [];

        if (string == "") {
            $scope.filterEmailId = null;
        }
        else {
            angular.forEach($scope.EmailIdsList, function (emailId) {
                if (emailId.toLowerCase().indexOf(string.toLowerCase()) >= 0) {
                    output.push(emailId);
                }
            });
            $scope.filterEmailId = output;
        }

    }
    $scope.fillTextbox = function (string) {
        $scope.ReceiverEmailId = string;
        $scope.filterEmailId = null;
    }

    function getMessageList() {
        InboxService.getMessageList().then(function (data) {
            if (data.data.Status == "Success") {
                $scope.messageList = data.data.data;
            }
            else
            {
                growl.error(data.data.msg, { title: 'Error!', ttl: 3000 });
            }
        })
    }

    //$scope.openComposeModal = function () {
    //    $('#composeMsgModal').modal('show');
    //}
    $scope.SendEmail = function () {
        if ($scope.ReceiverEmailId == "" || $scope.ReceiverEmailId == undefined) {
            growl.error("Enter to email id.", { title: 'Error!', ttl: 2000 });
            return false;
        }
        if ($scope.MessageData == "" || $scope.MessageData == undefined) {
            growl.error("Enter appointment date.", { title: 'Error!', ttl: 2000 });
            return false;
        }
        var email = {
            RecevierEmailId: $scope.ReceiverEmailId,
            MessageData: $scope.MessageData,
            Subject: $scope.Subject,            
        }
        $("#divLoading").show();
        InboxService.sendEmail(email).then(function (data) {
            if (data.data.Status == "Success") {
                $("#divLoading").hide();
                $('#composeMsgModal').modal('hide');
                $scope.ReceiverEmailId = "";
                $scope.Subject = "";
                $scope.MessageData = "";                
                growl.success(data.data.msg, { title: 'Success!', ttl: 2000 });
                getMessageList();
            }
            else {
                $("#divLoading").hide();                
                growl.error(data.data.msg, { title: 'Error!', ttl: 2000 });
            }
        })
    }
    $scope.deleteMail= function (messageId) {
        $("#divLoading").show();
        InboxService.deleteMail(messageId).then(function (data) {
            if (data.data.Status == "Success") {
                $("#divLoading").hide();
                growl.success("Mail is deleted.", { title: 'Success', ttl: 3000 });
                getMessageList();
            }
        })
    }
    $scope.messageArchive= function (messageId) {
        $("#divLoading").show();
        InboxService.messageArchive(messageId).then(function (data) {
            if (data.data.Status == "Success") {
                $("#divLoading").hide();
                growl.success("Mail is archived.", { title: 'Success', ttl: 3000 });
                getMessageList();
            }
        })
    }
});