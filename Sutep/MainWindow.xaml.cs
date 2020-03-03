using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace Sutep
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //读取配置文件选择最新程序运行
        public MainWindow()
        {
            InitializeComponent();
            StartApp();
        }
        private void StartApp()
        {
            //TODO:
            //1.读取配置文件获取当前最新版本
            //2.启动tray.exe
            //3.退出进程
            string configPath = Environment.CurrentDirectory + "//version.json";
            if (!File.Exists(configPath))
                MessageBox.Show("未找到配置文件");
            
            string verString = File.ReadAllText(configPath);
            JObject jobject = JObject.Parse(verString);
            
            string version = jobject["version"].ToString();
            var appPath = Environment.CurrentDirectory + "//" + version + "//MyEDT.WB.Tray.exe";
            if (!File.Exists(appPath))
            {
                MessageBox.Show("运行程序不存在:" + appPath);
            }
            try
            {
                Process.Start(appPath);
            }
            catch (Exception ex)
            {
                Logger.Error("程序启动失败",ex);
            }
            Environment.Exit(0);
        }
    }
}
