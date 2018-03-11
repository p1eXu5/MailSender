using System.Collections.Generic;
using CodePasswordDLL;

namespace MailSender
{
    /// <summary>
    /// Отправители
    /// </summary>
    public static class VariablesClass
    {
        public static Dictionary<string, string> Senders
        {
            get => dicSenders;
        }

        private static Dictionary<string, string> dicSenders = new Dictionary<string, string>()
        {
            {"test@ksergey.ru", CodePassword.getPassword("rxfsuz3129") },
            {"testNo@ksergey.ru", CodePassword.getPassword("rxfsuz3129") }
        };


        public static Dictionary<string, int> SmtpServers {
            get => dicSmtpServers;
        }

        private static Dictionary<string, int> dicSmtpServers = new Dictionary<string, int>()
        {
            {"smtp.yandex.ru", 25 },
            {"smtp.mail.ru", 25 }
        };
    }
}
