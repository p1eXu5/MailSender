using System.Windows;
using System.Windows.Input;
using CodePasswordDLL;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void m_tbPassword_KeyUp(object sender, KeyEventArgs e)
        {
            m_tbCipher.Text = CodePassword.getCodePassword(m_tbPassword.Text);
        }
    }
}
