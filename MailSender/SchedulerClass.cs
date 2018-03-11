using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows;
using EmailSendServiceClassDLL;

namespace MailSender
{
    /// <summary>
    /// Класс-планировщик, который создаёт расписание, следит за его выполнением и напоминает о событиях
    /// Также помогает автоматизировать рассылку писем в соответствии с расписанием
    /// </summary>
    public class SchedulerClass
    {
        DispatcherTimer timer = new DispatcherTimer();  // Таймер
        EmailSendServiceClass emailSender;              // Экземпляр класса, отвечающего за отправку писем
        DateTime dtSend;                                // Дата и время отправки
        IQueryable<Sender> emails;                      // коллекция email'ов-адресатов


        Dictionary<DateTime, string> dicDates = new Dictionary<DateTime, string>();

        public Dictionary<DateTime, string> DatesEmailTexts
        {
            get => dicDates;
            set
            {
                dicDates = value;
                dicDates = dicDates.OrderBy(pair => pair.Key).ToDictionary(pair => pair.Key, pair => pair.Value);
            }
        }

        /// <summary>
        /// Метод, в котором превращаем строку из tbTimePicker в TimeSpan
        /// </summary>
        /// <param name="strSendTime"></param>
        /// <returns></returns>
        public TimeSpan GetSendTime(string strSendTime)
        {
            TimeSpan tsSendTime = new TimeSpan();

            try {
                tsSendTime = TimeSpan.Parse(strSendTime);
            }
            catch { }

            return tsSendTime;
        }


        /// <summary>
        /// Непосредственно отправка писем
        /// </summary>
        /// <param name="dtSend"></param>
        /// <param name="emailSender"></param>
        /// <param name="emails"></param>
        public void SendEmails(/*DateTime dtSend, */EmailSendServiceClass emailSender, IQueryable<Sender> emails)
        {
            this.emailSender = emailSender;
            //this.dtSend = dtSend;
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            if (dicDates.Count == 0) {

                timer.Stop();
                MessageBox.Show("Письма отправлены.");
            }
            else if (dicDates.Keys.First<DateTime>().ToShortTimeString() == DateTime.Now.ToShortTimeString()) {

                emailSender.Body = dicDates[dicDates.Keys.First()];
                emailSender.Subject = $"Рассылка от {dicDates.Keys.First().ToShortTimeString()}";
                emailSender.SendMails(emails);

                dicDates.Remove(dicDates.Keys.First());
            }

            #region lesson_3
            //if (dtSend.ToShortTimeString() == DateTime.Now.ToShortTimeString()) {

            //    emailSender.SendMails(emails);
            //    timer.Stop();
            //    MessageBox.Show("Письма отправлены");
            //}
            #endregion lesson_3
        }

    } // End of class -----------------------
}
