using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmailSendServiceClassDLL;

namespace MailSender
{
    public static class EmailSendExtend
    {
        public static void SendMails(this EmailSendServiceClass essc, IQueryable<Sender> emails)
        {
            foreach (Sender email in emails) {
                essc.SendMail(email.Email, email.Name);
            };
        }
    }
}
