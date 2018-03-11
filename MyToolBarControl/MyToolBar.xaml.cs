using System.Windows.Controls;

namespace MyToolBarControl
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class MyToolBar : UserControl
    {
        public MyToolBar()
        {
            InitializeComponent();
        }

        public string Text
        {
            get => ISender.Text;
            set => ISender.Text = value;
        }

        public ComboBox CbSenderSelect
        {
            get => cbSenderSelect;
        }
    }
}
