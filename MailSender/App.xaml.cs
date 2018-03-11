/*
    1. По аналогии с тем, как мы создавали DLL из класса, который шифрует пароли, создать DLL из класса EmailSendServiceClass, который занимается рассылкой писем.
    
    2. Посмотреть на ToolBarTray
        Некоторые панели ToolBar очень похожи между собой. Из них можно сделать контрол и добавлять на ToolBar. Сделайте контрол из Панели «Выбрать отправителя» и добавьте его и в качестве контрола «Выбрать smtp-server». У этого контрола должна быть возможность заменить текст у лейбла, должен функционировать комбобокс и все три кнопки.
 
 * 
 * 
 * 
 * 
 *                                                                          В.Г.Лихацкий */

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MailSender
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
    }
}
