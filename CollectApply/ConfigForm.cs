using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using OpenPOP.POP3;
namespace CollectApply
{
    public partial class ConfigForm : Form
    {
        private POPClient popClient;
        private ConfigData config;
        private Boolean isPopOK;
        public ConfigData Config
        {
            get { return config; }
            set { config = value; }
        }
        public ConfigForm()
        {
            InitializeComponent();
        }

        private Boolean testPOPConection(
            String ServerAddr,
            String Port ,
            String Email ,
            String PWD
            )
        {
            Utility.Log = true;
          
            Boolean res = false;
            try
            {
                popClient.Connect(ServerAddr, int.Parse(Port));
                popClient.Authenticate(Email, PWD);
                res = true;
            }
            catch (OpenPOP.POP3.PopServerNotFoundException)
            {
                showMsg("未找到服务器");
                isPopOK = false;
                btnTestPop.Text = "测试连接邮箱服务器";
                btnTestPop.Enabled = true;
            }
            catch (OpenPOP.POP3.PopServerNotAvailableException)
            {
                showMsg("无法连接到服务器");
                isPopOK = false;
                btnTestPop.Text = "测试连接邮箱服务器";
                btnTestPop.Enabled = true;
            }
            catch (OpenPOP.POP3.InvalidPasswordException)
            {
                showMsg("密码错误");
                isPopOK = false;
                btnTestPop.Text = "测试连接邮箱服务器";
                btnTestPop.Enabled = true;
            }
            catch (OpenPOP.POP3.InvalidLoginException)
            {
                showMsg("邮箱错误");
                isPopOK = false;
                btnTestPop.Text = "测试连接邮箱服务器";
                btnTestPop.Enabled = true;
            }
            catch (OpenPOP.POP3.InvalidLoginOrPasswordException)
            {
                showMsg("邮箱或密码错误");
                isPopOK = false;
                btnTestPop.Text = "测试连接邮箱服务器";
                btnTestPop.Enabled = true;
            }
            return res;
        }
        private void popClient_CommunicationBegan(object sender, EventArgs e)
        {
            showMsg("开始连接");
        }
        private void popClient_CommunicationLost(object sender, EventArgs e)
        {
            showMsg("连接失败");
        }
        private void popClient_CommunicationOccured(object sender, EventArgs e)
        {
            showMsg("连接到服务器");
        }

        private void popClient_AuthenticationBegan(object sender, EventArgs e)
        {
            showMsg("验证授权");
        }

        private void popClient_AuthenticationFinished(object sender, EventArgs e)
        {
            showMsg("验证成功");
            btnTestPop.Text = "测试连接邮箱服务器";
            btnTestPop.Enabled = true;
            isPopOK = true;
        }
		
        private void showMsg(String strEvent)
        {
            this.textBoxResult.Text = strEvent;
        }

        private void btnTestPop_Click(object sender, System.EventArgs e)
        {
            btnTestPop.Text = "正在测试服务器连接...";
            btnTestPop.Enabled = false;           
            String ServerAddr = this.textBoxServerAddr.Text;
            String Port = this.textBoxPort.Text;
            String Email = this.textBoxEmail.Text;
            String PWD = this.textBoxPWD.Text;
            testPOPConection(ServerAddr, Port, Email, PWD);

        }
        
        private void ConfigForm_Load(object sender, System.EventArgs e)
        {
            this.textBoxServerAddr.Text = config.ServerAddr;
            this.textBoxPort.Text = config.Port;
            this.textBoxEmail.Text = config.Email;
            this.textBoxPWD.Text = config.PWD;
            popClient = new POPClient();
            popClient.AuthenticationBegan += new EventHandler(popClient_AuthenticationBegan);
            popClient.AuthenticationFinished += new EventHandler(popClient_AuthenticationFinished);
            popClient.CommunicationBegan += new EventHandler(popClient_CommunicationBegan);
            popClient.CommunicationOccured += new EventHandler(popClient_CommunicationOccured);
            popClient.CommunicationLost += new EventHandler(popClient_CommunicationLost);
            isPopOK = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isPopOK == false)
            {
                //数据库连接异常
                string message = "未连接到服务器，是否依然保存？";
                string caption = "系统提示";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                if (result == DialogResult.Yes)
                {
                    //保存
                    fillConifg();
                    //关闭对话框
                    this.DialogResult = DialogResult.Ignore;
                    this.Close();
                }

            }
            else
            {
                //保存配置
                fillConifg();
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }
        private void fillConifg()
        {
            config.ServerAddr = this.textBoxServerAddr.Text;
            config.Port = this.textBoxPort.Text;
            config.Email = this.textBoxEmail.Text;
            config.PWD = this.textBoxPWD.Text;
        }
      

        private void ConfigForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            popClient.Disconnect();
        }

       

    }
}
