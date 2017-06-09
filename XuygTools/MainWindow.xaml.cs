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
using System.Windows.Forms;
using System.IO;

namespace XuygTools
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DragArea.MouseDown += new MouseButtonEventHandler(DragArea_mouseDown); //鼠标移动拖动窗口位置
            this.exitButton.MouseDown += new MouseButtonEventHandler(exitButton_Click); //关闭程序
            this.getPathBUT.MouseDown += new MouseButtonEventHandler(getPathBUT_Click); //关闭程序
            this.createFilesBUT.MouseDown += new MouseButtonEventHandler(createFilesBUT_Click); //创建文件夹系列

        }

        //鼠标移动
        void DragArea_mouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        ///关闭程序
        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
        ///获取路径
        private void getPathBUT_Click(object sender, RoutedEventArgs e)
        {
            var folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.filePathForProject.Text = folderBrowserDialog1.SelectedPath;
            }

        }
        ///创建文件夹系统
        private void createFilesBUT_Click(object sender, RoutedEventArgs e)
        {
            string[] configText = File.ReadAllLines(@"C:\Users\Administrator\Source\Repos\xuygtools\XuygTools\PIC\config.txt");//获取项目根目录
            var projectFileInList = new List<string>();
            var isBegin = false;
            for (int s = 0; s <= configText.Length - 1; s++)
            {
                if (configText[s] == @"KEY_WORD  PROJECT_FILE_IN_LIST_END")
                { isBegin = false; }
                if (isBegin)
                { projectFileInList.Add(configText[s]); }
                if (configText[s] == @"KEY_WORD PROJECT_FILE_IN_LIST_START")
                { isBegin = true; }
            }

            var path = filePathForProject.Text + "\\" + this.projectName.Text;
            if (!System.IO.Directory.Exists(path))
            { System.IO.Directory.CreateDirectory(path); }
            else
            { System.Windows.Forms.MessageBox.Show("文件已经存在！"); }

            for (int s = 0; s <= projectFileInList.Count-1 ; s++)
            {
                var pathNext = path + "\\" + projectFileInList[s];
                if (!System.IO.Directory.Exists(pathNext))
                {                    System.IO.Directory.CreateDirectory(pathNext);

                }
                else
                {                    System.Windows.Forms.MessageBox.Show("文件已经存在！");                }
               
            }
            System.Windows.Forms.MessageBox.Show("操作成功！");
        }



    }
}
