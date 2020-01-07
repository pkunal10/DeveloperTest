using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeveloperTest.Models;
using DeveloperTest.Service;

namespace DeveloperTest.Controllers
{
    public class MessageController : Controller
    {
        private readonly IHomeService _homeService = new HomeService();
        private readonly IMessageService _MessageService = new MessageService();
        // GET: Message
        #region inbox
        public ActionResult Inbox()
        {
            if (Convert.ToString(Session["Userid"]) == "")
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }
        public JsonResult GetMessageListForInbox()
        {

            var msgList = _MessageService.GetReceivedMessageByEmailId(_homeService.GetUserById(Convert.ToInt32(Session["Userid"])).EmailId);
            if (msgList.Count != 0 && msgList != null)
            {
                foreach (var msg in msgList)
                {
                    msg.SentTimeDisplay = msg.SentTime.ToString("dd/MM/yyyy hh:mm tt");
                }
                return new JsonResult { Data = new { Status = "Success", data = msgList }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            else
            {
                return new JsonResult { Data = new { Status = "NoMsg", msg="No Email yet." }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        public JsonResult GetEmailIdsForAutoComplete()
        {
            var list = _MessageService.GetEmailIdsList();
            return new JsonResult { Data = new { Status = "Success", data = list }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult MessageSend(Message modal)
        {
            User user = new User();
            user = _homeService.GetUserById(Convert.ToInt32(Session["UserId"]));
            modal.SenderEmailId = user.EmailId;
            modal.SentTime = DateTime.Now;
            modal.IsArchive = false;
            _MessageService.AddMessage(modal);
            return new JsonResult { Data = new { Status = "Success", msg="Email sent." }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult DeleteMail(string messageId)
        {
            _MessageService.DeleteMessage(Convert.ToInt32(messageId));
            return new JsonResult { Data = new { Status = "Success" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult MakeMailArchive(string messageId)
        {
            Message message = new Message();
            message = _MessageService.GetMsgById(Convert.ToInt32(messageId));
            message.IsArchive = true;
            _MessageService.MakeMsgArchive(message);

            return new JsonResult { Data = new { Status = "Success",msg="Message Archived." }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        #endregion

        #region sentMail
        public ActionResult SentMail()
        {
            if (Convert.ToString(Session["Userid"]) == "")
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        public JsonResult GetMessageListForSentMail()
        {

            var msgList = _MessageService.GetSentMessageByEmailId(_homeService.GetUserById(Convert.ToInt32(Session["Userid"])).EmailId);
            if (msgList.Count != 0 && msgList != null)
            {
                foreach (var msg in msgList)
                {
                    msg.SentTimeDisplay = msg.SentTime.ToString("dd/MM/yyyy hh:mm tt");
                }
                return new JsonResult { Data = new { Status = "Success", data = msgList }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            else
            {
                return new JsonResult { Data = new { Status = "NoMsg", msg = "No Email yet." }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        #endregion

        #region ArchiveMail
        public ActionResult ArchiveMail()
        {
            if (Convert.ToString(Session["Userid"]) == "")
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        public JsonResult GetMessageListArchiveMail()
        {

            var msgList = _MessageService.GetArchiveMessageByEmailId(_homeService.GetUserById(Convert.ToInt32(Session["Userid"])).EmailId);
            if (msgList.Count != 0 && msgList != null)
            {
                foreach (var msg in msgList)
                {
                    msg.SentTimeDisplay = msg.SentTime.ToString("dd/MM/yyyy hh:mm tt");
                }
                return new JsonResult { Data = new { Status = "Success", data = msgList }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            else
            {
                return new JsonResult { Data = new { Status = "NoMsg", msg = "No Email yet." }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        #endregion
    }
}