using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeveloperTest.Models;

namespace DeveloperTest.Service
{
    public interface IMessageService
    {
        List<Message> GetReceivedMessageByEmailId(string emailId);
        List<Message> GetSentMessageByEmailId(string emailId);
        List<Message> GetArchiveMessageByEmailId(string emailId);
        string AddMessage(Message message);
        string DeleteMessage(int id);
        List<String> GetEmailIdsList();
        string MakeMsgArchive(Message message);
        Message GetMsgById(int msgId);
    }
}