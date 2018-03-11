﻿using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailSendServiceClassDLL
{
    /// <summary>
    /// Класс, который непосредственно отвечает за рассылку писем
    /// </summary>
    public class EmailSendServiceClass
    {
        #region vars
        private string strLogin;                    // email, с которого будет рассылаться почта
        private string strPassword;                 // пароль к email, с которого будет рассылаться почта
        private string strSmtp = "smtp.yandex.ru";  // smtp - server
        private int iSmtpPort = 25;                 // порт для smtp - server
        private string strBody = "Hello, World";    // текст письма для отправки
        private string strSubject;                  // тема письма для отправки
        #endregion vars

        public string Body
        {
            get => strBody;
            set => strBody = value;
        }

        public string Subject
        {
            get => strSubject;
            set => strSubject = value;
        }

        public EmailSendServiceClass(string sLogin, string sPassword)
        {
            strLogin = sLogin;
            strPassword = sPassword;
        }

        public EmailSendServiceClass(string sLogin, string sPassword, string smpr_server, int port) : this(sLogin, sPassword)
        {
            if (!string.IsNullOrEmpty(smpr_server)) {
                strSmtp = smpr_server;
            }

            iSmtpPort = port;
        }

        public void SendMail(string mail, string name)  // Отправка email конкретному адресату
        {
            using (MailMessage mm = new MailMessage(strLogin, mail)) {

                mm.Subject = strSubject;
                mm.Body = strBody;
                mm.IsBodyHtml = false;
                SmtpClient sc = new SmtpClient(strSmtp, iSmtpPort);
                sc.EnableSsl = true;
                sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                sc.UseDefaultCredentials = false;
                sc.Credentials = new NetworkCredential(strLogin, strPassword);
                try {
                    sc.Send(mm);
                }
                catch (Exception ex) {
                    MessageBox.Show($"Невозможно отправить письмо {ex.ToString()}");
                }
                finally {
                    sc.Dispose();
                }
            }
        }

    }
}
