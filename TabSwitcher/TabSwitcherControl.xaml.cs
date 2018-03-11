using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TabSwitcher
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class TabSwitcherControl : UserControl
    {
        public event RoutedEventHandler btnNextClick;
        public event RoutedEventHandler btnPreviosClick;

        #region properties
        private bool m_bHideBtnPrevios = false; // будет ли скрыта кнопка "Предыдущий"
        private bool m_bHideBtnNext = false; // будет ли скрыта кнопка "Следующий"


        /// <summary>
        /// Свойство соответствующее будет ли скрыта кнопка Предыдущий.
        ///  Чтобы  Свойство  отразилось  на  PropertiesGrid  у  нашего  контрола,  его  нужно  представить именно свойством, а не полем
        /// </summary>
        public bool IsHideBtnPrevios
        {
            get => m_bHideBtnPrevios;
            set {
                m_bHideBtnPrevios = value;
                SetButtons();               // метод, который отвечает заотрисовку кнопок
            }
        }

        public bool IsHideBtnNext
        {
            get => m_bHideBtnNext;
            set
            {
                m_bHideBtnNext = value;
                SetButtons();               // метод, который отвечает заотрисовку кнопок
            }
        }

        #endregion properties


        public TabSwitcherControl()
        {
            InitializeComponent();
        }


        private void BtnPreviosFalseBtnNextFalse()
        {
            m_btnNext.Visibility = Visibility.Hidden;
            m_btnPrev.Visibility = Visibility.Hidden;
            m_btnNext.Width = 114;
            m_btnPrev.Width = 115;
        }

        private void BtnPreviosFalseBtnNextTrue()
        {
            m_btnPrev.Visibility = Visibility.Collapsed;
            m_btnNext.Visibility = Visibility.Visible;
            m_btnNext.Width = 229;
        }

        private void BtnPreviosTrueBtnNextFalse()
        {
            m_btnNext.Visibility = Visibility.Collapsed;
            m_btnPrev.Visibility = Visibility.Visible;
            m_btnPrev.Width = 229;
        }



        private void BtnPreviosTrueBtnNextTrue()
        {
            m_btnNext.Visibility = Visibility.Visible;
            m_btnPrev.Visibility = Visibility.Visible;
            m_btnNext.Width = 114;
            m_btnPrev.Width = 115;
        }

        /// <summary>
        ///  Метод который отвечает за отрисовку кнопок.
        ///  Есть четыре варианта, когда обе кнопки доступны. Доступна одна и не доступна вторая. И обе кнопки недоступны
        /// </summary>
        private void SetButtons()
        {
            if (m_bHideBtnPrevios && m_bHideBtnNext) BtnPreviosFalseBtnNextFalse();
            else if (m_bHideBtnPrevios && !m_bHideBtnNext) BtnPreviosFalseBtnNextTrue();
            else if (!m_bHideBtnPrevios && m_bHideBtnNext) BtnPreviosTrueBtnNextFalse();
            else if (!m_bHideBtnPrevios && !m_bHideBtnNext) BtnPreviosTrueBtnNextTrue();
        }

        private void m_btnPrev_Click(object sender, RoutedEventArgs e)
        {
            btnPreviosClick?.Invoke(this, e);
        }

        private void m_btnNext_Click(object sender, RoutedEventArgs e)
        {
            btnNextClick?.Invoke(this, e);
        }
    }
}
