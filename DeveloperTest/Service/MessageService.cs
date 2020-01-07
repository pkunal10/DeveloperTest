using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeveloperTest.Models;
using DeveloperTest.Service;
using System.Data.Entity.Migrations;
using System.Data;
using System.Data.Entity;

namespace DeveloperTest.Service
{
    public class MessageService : IMessageService
    {
        DBContextMail context = new DBContextMail();
        public List<Message> GetReceivedMessageByEmailId(string emailId)
        {
            var list = context.Messages.Where(x => x.RecevierEmailId == emailId && x.IsArchive == false).OrderByDescending(y => y.SentTime).ToList();
            return list;
        }
        public List<Message> GetSentMessageByEmailId(string emailId)
        {
            var list = context.Messages.Where(x => x.SenderEmailId == emailId && x.IsArchive == false).OrderByDescending(y => y.SentTime).ToList();
            return list;
        }
        public List<Message> GetArchiveMessageByEmailId(string emailId)
        {
            var list = context.Messages.Where(x => (x.RecevierEmailId == emailId || x.SenderEmailId == emailId) && x.IsArchive == true).OrderByDescending(y => y.SentTime).ToList();
            return list;
        }
        public string AddMessage(Message message)
        {
            context.Messages.Add(message);
            context.SaveChanges();
            return "Added";
        }
        public string MakeMsgArchive(Message message)
        {
            context.Messages.AddOrUpdate(message);
            context.SaveChanges();
            return "Added";
        }
        public Message GetMsgById(int msgId)
        {
            return context.Messages.Where(x => x.MessageId == msgId).FirstOrDefault();
        }
        public string DeleteMessage(int id)
        {
            context.Messages.Remove(context.Messages.Where(x => x.MessageId == id).FirstOrDefault());
            context.SaveChanges();
            return "Deleted";
        }
        public List<String> GetEmailIdsList()
        {
            return context.Users.Select(x => x.EmailId).ToList();
        }
    }
}