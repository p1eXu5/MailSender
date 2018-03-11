using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePasswordDLL
{
    public static class CodePassword
    {
        /// <summary>
        /// Получить пароль по шифру
        /// </summary>
        /// <param name="p_sPassw">Зашифрованный пароль</param>
        /// <returns>пароль для email</returns>
        public static string getPassword(string p_sPassw)
        {
            string password = "";

            foreach (char a in p_sPassw) {
                char ch = a;
                --ch;
                password += ch;
            }

            return password;
        }


        /// <summary>
        /// Получить зашифрованный пароль
        /// </summary>
        /// <param name="p_sPassword">Незашифрованный пароль</param>
        /// <returns>Возвращает зашифрованный пароль</returns>
        public static string getCodePassword(string p_sPassword)
        {
            string sCode = "";

            foreach (char a in p_sPassword) {
                char ch = a;
                ++ch;
                sCode += ch;
            }

            return sCode;
        }
    }
}
