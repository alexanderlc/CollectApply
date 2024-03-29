﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using OpenPOP.POP3;
using Utils;
namespace CollectApply
{
    public partial class MainForm : Form
    {
        #region 属性
        private string stringDateFormat = "yyyy-MM-dd HH:mm:ss";
        private string log_name = ".\\log.txt";
        private StreamWriter logFileWriter;             //写日志     
        private ConfigData config;
        private string configName = "sysconf.sys";
        private POPClient popClient;

        #endregion
        public MainForm()
        {
            InitializeComponent();
            popClient = new POPClient();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItemConfig_Click(object sender, EventArgs e)
        {
            ConfigForm cf = new ConfigForm();
            cf.Config = this.config;
            DialogResult result;
            result = cf.ShowDialog();
            if (result == DialogResult.Yes)
            {
                WriteLog("修改系统配置");
                this.config = cf.Config;
                this.config.SaveConf(this.configName);
            }         
        }
        //写日志,并显示
        public void WriteLog(string str)
        {
            DateTime dt = DateTime.Now;
            string sDt = dt.ToString(this.stringDateFormat);

            ListViewItem item = new ListViewItem(sDt, 0);
            item.SubItems.Add(str);
            this.listViewLog.Items.AddRange(new ListViewItem[] { item });
            this.listViewLog.Items[(this.listViewLog.Items.Count) - 1].EnsureVisible();   //滚到该行
            logFileWriter.WriteLine(sDt + "    " + str);
            logFileWriter.Flush();

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string message = "确定退出？";
            string caption = "系统提示";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
            }
            else
            {
                WriteLog("程序退出");
                logFileWriter.Flush();
                logFileWriter.Close();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            String FPath = Application.StartupPath + "\\Excel";
            DirectoryInfo Dir = new DirectoryInfo(FPath);
            if (!Dir.Exists)
                Dir.Create();

            logFileWriter = File.AppendText(this.log_name);
            WriteLog("********************************************");
            WriteLog("启动程序");
            config = new ConfigData();
            config.LoadConf(this.configName);
        }

        private void ToolStripMenuItemLog_Click(object sender, EventArgs e)
        {
            //声明一个程序信息类   
            System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
            //设置外部程序名   
            Info.FileName = "notepad.exe";
            //设置外部程序的启动参数（命令行参数） 
            Info.Arguments = this.log_name;
            //设置外部程序工作目录为   
            Info.WorkingDirectory = ".\\";
            //声明一个程序类   
            System.Diagnostics.Process Proc;
            try
            {
                WriteLog("查看日志");
                //   
                //启动外部程序   
                //   
                Proc = System.Diagnostics.Process.Start(Info);
            }
            catch (System.ComponentModel.Win32Exception e1)
            {
                WriteLog("系统找不到指定的程序文件");
                WriteLog(e1.ToString());
                return;
            }
        }

        private void ToolStripMenuItemOpenFolder_Click(object sender, EventArgs e)
        {
            try
            {
                String path = Application.StartupPath + "\\Excel";
                System.Diagnostics.Process.Start("explorer.exe", path);
            }
            catch (System.ComponentModel.Win32Exception e1)
            {
                WriteLog("系统找不到指定的文件夹");
                WriteLog(e1.ToString());
                return;
            }
        }

        private void ToolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            String message = "确定要退出程序？";
            String caption = "系统提示";

            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
            if (result == DialogResult.OK)
            {
                WriteLog("程序退出");
                logFileWriter.Flush();
                logFileWriter.Close();
                Application.Exit();
            }
            else
            {
            }
        }

        private void ToolStripMenuItemGetAllMails_Click(object sender, EventArgs e)
        {
            if (this.backgroundWorkerGetAllMails.IsBusy)
            {
            }
            else
            {
                this.backgroundWorkerGetAllMails.RunWorkerAsync();
            }
        }

        private void backgroundWorkerGetAllMails_DoWork(object sender, DoWorkEventArgs e)
        {
            Utility.Log = true;
            popClient.Disconnect();
            popClient.Connect(config.ServerAddr, int.Parse(config.Port));
            popClient.Authenticate(config.Email, config.PWD);
            int Count = popClient.GetMessageCount();
            int percent=0;
            backgroundWorkerGetAllMails.ReportProgress(-1, Count);
            List<ApplyItem> list = new List<ApplyItem>();
            for (int i = Count; i > 0; i--)
            {

                OpenPOP.MIMEParser.Message m = popClient.GetMessage(i, false);
                ApplyItem item = ApplyItemController.getApplyItem(m);
                percent=percent+1;
                if (item != null)
                {
                    list.Add(item);
                   
                }
                backgroundWorkerGetAllMails.ReportProgress((int)percent*100 / Count, item);
            }
            for (int k = 0; k < list.Count; k++)
            {

            }
            String path = Application.StartupPath + "\\Excel\\"+DateTime.Now.ToString("yyyyMMdd_HHmmss")+".xls";
            ExcelCreator ec = new ExcelCreator();
            if (ec.toExcel(list, path))
            {
                e.Result = "path:"+path;
            }
            else
            {
                e.Result = "ER:生成excel失败";
            }
          
        }

        private void backgroundWorkerGetAllMails_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == -1)
            {
                int count =(int)( e.UserState);
                WriteLog("返回邮件总数："+count);
            }
            else
            {
                this.toolStripProgressBar.Visible = true;
                this.toolStripProgressBar.Value = e.ProgressPercentage;
                this.toolStripStatusLabelMsg.Text = "正在处理，" + e.ProgressPercentage + "%";
                ApplyItem item = e.UserState as ApplyItem;
                if (item != null)
                {
                    WriteLog(item.ToString());
                }
               
            }
        }

        private void backgroundWorkerGetAllMails_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            String res = e.Result.ToString();
            if (!res.StartsWith("ER:"))
            {
             
                WriteLog(res);
            }
            this.toolStripStatusLabelMsg.Text = "完成";
            this.toolStripProgressBar.Visible = false;
        }

        private void listViewLog_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listViewLog.SelectedItems.Count > 0)
            {
                String path=listViewLog.SelectedItems[0].SubItems[1].Text;
                if (path.StartsWith("path:"))
                {
                    String filePath = path.Replace("path:", "");
                    System.Diagnostics.Process.Start(filePath);
                }

            }
        }       
    }
}
