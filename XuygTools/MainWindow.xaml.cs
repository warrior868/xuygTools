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
            this.exitButton.MouseDown +=new MouseButtonEventHandler(exitButton_Click); //关闭程序
            this.getPathBUT.MouseDown += new MouseButtonEventHandler(getPathBUT_Click); //关闭程序

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
             var  folderBrowserDialog1= new System.Windows.Forms.FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.filePathForProject.Text = folderBrowserDialog1.SelectedPath;
            }
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
