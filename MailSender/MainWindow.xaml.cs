using System;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using EmailSendServiceClassDLL;

namespace MailSender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int m_cSheduleTab = 1;
        const int m_cLetterTab = 2;

        public MainWindow()
        {
            InitializeComponent();

            miClose.Click += delegate { this.Close(); };

            m_tscTabSwitcher.btnNextClick += (s,e) => tbcTabs.SelectedIndex = 1;
            m_tscSchedule.btnNextClick += (s, e) => tbcTabs.SelectedIndex = 2;
            m_tscSchedule.btnPreviosClick += (s, e) => tbcTabs.SelectedIndex = 0;
            m_tscLetter.btnNextClick += (s, e) => tbcTabs.SelectedIndex = 3;
            m_tscLetter.btnPreviosClick += (s, e) => tbcTabs.SelectedIndex = 1;
            m_tscStatistic.btnPreviosClick += (s, e) => tbcTabs.SelectedIndex = 2;
            //btnToSchedule.Click += delegate
            //{
            //    tbcTabs.SelectedIndex = m_cSheduleTab;
            //};



            m_mtbSenderToolBar.CbSenderSelect.Items.Clear();
            m_mtbSenderToolBar.CbSenderSelect.ItemsSource = VariablesClass.Senders;
            m_mtbSenderToolBar.CbSenderSelect.DisplayMemberPath = "Key";
            m_mtbSenderToolBar.CbSenderSelect.SelectedValuePath = "Value";

            m_mtbSmtpToolBar.CbSenderSelect.Items.Clear();
            m_mtbSmtpToolBar.CbSenderSelect.ItemsSource = VariablesClass.SmtpServers;
            m_mtbSmtpToolBar.CbSenderSelect.DisplayMemberPath = "Key";
            m_mtbSmtpToolBar.CbSenderSelect.SelectedValuePath = "Value";

            rtbLetter.Document.Blocks.Clear();

            DBClass db = new DBClass();
            dgEmails.ItemsSource = db.Emails;
        }


        /// <summary>
        /// Обработчик кнопки "Отправить сразу"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendAtOnse_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckTextLetter())
            {
                MessageBox.Show("Письмо не заполнено!");
                tbcTabs.SelectedIndex = m_cLetterTab;
                return;
            }


            string strLogin = m_mtbSenderToolBar.CbSenderSelect.Text;
            string strPassword = m_mtbSenderToolBar.CbSenderSelect.SelectedValue.ToString();

            if (string.IsNullOrEmpty(strLogin) || string.IsNullOrEmpty(strPassword)) {

                MessageBox.Show("Выберите отправителя");
                return;
            }

            EmailSendServiceClass emailSender = new EmailSendServiceClass(strLogin, 
                                                                          strPassword,
                                                                          m_mtbSmtpToolBar.CbSenderSelect.Text, 
                                                                          (int)m_mtbSmtpToolBar.CbSenderSelect.SelectedValue);

            TextRange tr = new TextRange(rtbLetter.Document.ContentStart, rtbLetter.Document.ContentEnd);
            emailSender.Body = tr.Text;

            emailSender.SendMails((IQueryable<Sender>)dgEmails.ItemsSource);
        }


        /// <summary>
        /// Обработчик кнопки "Отправить запланированно"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckTextLetter())
            {
                MessageBox.Show("Письмо не заполнено!");
                tbcTabs.SelectedIndex = m_cLetterTab;
                return;
            }

            SchedulerClass sc = new SchedulerClass();
            TimeSpan tsSendTime = sc.GetSendTime(tbTimePicker.Text);        // Интервал, указанный в TextBox tbTimePicker Планировщика

            if (tsSendTime == TimeSpan.Zero) {

                MessageBox.Show("Некорректный формат даты");
                return;
            }

            DateTime dtSendDateTime = (cldScheduleDateTimes.SelectedDate ?? DateTime.Today).Add(tsSendTime);

            if (dtSendDateTime < DateTime.Now) {

                MessageBox.Show("Дата и время отправки писем не могут быть раньше, чем настоящее время");
                return;
            }

            EmailSendServiceClass emailSender = new EmailSendServiceClass(m_mtbSenderToolBar.CbSenderSelect.Text, m_mtbSenderToolBar.CbSenderSelect.SelectedValue.ToString(),
                                                                          m_mtbSmtpToolBar.CbSenderSelect.Text, (int)m_mtbSmtpToolBar.CbSenderSelect.SelectedValue);

            TextRange tr = new TextRange(rtbLetter.Document.ContentStart, rtbLetter.Document.ContentEnd);
            emailSender.Body = tr.Text;

            sc.SendEmails(/*dtSendDateTime, */emailSender, (IQueryable<Sender>)dgEmails.ItemsSource);
        }


        /// <summary>
        /// Проверка RichTextBox на наличие текста
        /// </summary>
        /// <returns>true, если имеется текст</returns>
        private bool CheckTextLetter()
        {
            TextRange tr = new TextRange(rtbLetter.Document.ContentStart, rtbLetter.Document.ContentEnd);
            return !string.IsNullOrEmpty(tr.Text);
        }
    }
}
