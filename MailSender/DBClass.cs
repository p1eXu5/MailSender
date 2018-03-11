using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    /// <summary>
    /// Для работы с базой данных
    /// </summary>
    class DBClass
    {
        private EmailsDataContext emails = new EmailsDataContext();
        public IQueryable<Sender> Emails
        {
            get
            {
                return from c in emails.Senders select c;
            }
        }
    }
}
