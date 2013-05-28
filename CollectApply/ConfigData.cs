using System;
using System.Collections.Generic;
using System.Text;
using Utils;

namespace CollectApply
{
    public class ConfigData
    {
        private string sServerAddr;     // 服务器名称

        public string ServerAddr
        {
            get { return sServerAddr; }
            set { sServerAddr = value; }
        }
        private string sPort;          // 数据库名称

        public string Port
        {
            get { return sPort; }
            set { sPort = value; }
        }
        private string sEmail;         // 用户名

        public string Email
        {
            get { return sEmail; }
            set { sEmail = value; }
        }
        private string sPWD;           // 端口

        public string PWD
        {
            get { return sPWD; }
            set { sPWD = value; }
        }
        #region 配置文件读写
        //读取配置文件
        public bool LoadConf(string fileName)
        {
            IniFiles ini = new IniFiles(fileName);
            sServerAddr = ini.ReadString("POP3", "server", "");
            sPort = ini.ReadString("POP3", "port", "");
            sEmail = ini.ReadString("POP3", "email", "");
            sPWD = ini.ReadString("POP3", "pwd", "");
            return true;
        }
        //保存配置文件
        public bool SaveConf(string fileName)
        {
            try
            {
                IniFiles ini = new IniFiles(fileName);
                ini.WriteString("POP3", "server", sServerAddr);
                ini.WriteString("POP3", "port", sPort);
                ini.WriteString("POP3", "email", sEmail);
                ini.WriteString("POP3", "pwd", sPWD);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        }
        #endregion
    }
}
