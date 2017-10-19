﻿using System;
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
using System.Windows.Shapes;
using System.ComponentModel;

using static View_Spot_of_City.UIControls.Form.MessageboxMaster;

namespace View_Spot_of_City.UIControls.Form
{
    /// <summary>
    /// MyMessageBox.xaml 的交互逻辑
    /// </summary>
    public partial class MyMessageBox : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 显示按钮
        /// </summary>
        private MyMessageBoxButtons? _ButtonPanel = null;
        /// <summary>
        /// 显示按钮
        /// </summary>
        public MyMessageBoxButtons? ButtonPanel
        {
            get { return _ButtonPanel; }
            set
            {
                if(_ButtonPanel != value)
                {
                    _ButtonPanel = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ButtonPanel"));
                }
            }
        }

        /// <summary>
        /// 窗口关闭返回值
        /// </summary>
        private DialogResults _DialogResult = DialogResults.Cancel;
        /// <summary>
        /// 窗口关闭返回值
        /// </summary>
        public DialogResults WindowResult
        {
            get { return _DialogResult; }
        }

        private MyMessageBox(string message)
        {
            InitializeComponent();
            messagetextBox.Text = message == null ? string.Empty : message ;
            Title = string.Empty;
            ButtonPanel = MyMessageBoxButtons.Ok;
        }

        private MyMessageBox(string message, string title)
        {
            InitializeComponent();
            messagetextBox.Text = message == null ? string.Empty : message;
            Title = title == null ? string.Empty : title;
            ButtonPanel = MyMessageBoxButtons.Ok;
        }

        private MyMessageBox(string message, string title, MyMessageBoxButtons buttons)
        {
            InitializeComponent();
            messagetextBox.Text = message == null ? string.Empty : message;
            Title = title == null ? string.Empty : title;
            ButtonPanel = buttons;
        }

        /// <summary>
        /// 显示消息框
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <returns>点击OK这返回DialogResults.Ok，否则返回DialogResults.Cancel</returns>
        internal static DialogResults ShowMyDialog(string message)
        {
            MyMessageBox mymesaagebox = new MyMessageBox(message);
            bool? dialogresult = mymesaagebox.ShowDialog();
            return mymesaagebox.WindowResult;
        }

        /// <summary>
        /// 显示消息框
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <param name="title">标题</param>
        /// <returns>点击OK这返回DialogResults.Ok，否则返回DialogResults.Cancel</returns>
        internal static DialogResults ShowMyDialog(string message, string title)
        {
            MyMessageBox mymesaagebox = new MyMessageBox(message, title);
            bool? dialogresult = mymesaagebox.ShowDialog();
            return mymesaagebox.WindowResult;
        }

        /// <summary>
        /// 显示消息框
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <param name="title">标题</param>
        /// <param name="buttons">显示哪些按钮</param>
        /// <returns>点击OK这返回DialogResults.Ok，点击Yes返回DialogResults.Yes，点击No返回DialogResults.No，否则返回DialogResults.Cancel</returns>
        internal static DialogResults ShowMyDialog(string message, string title, MyMessageBoxButtons buttons)
        {
            MyMessageBox mymesaagebox = new MyMessageBox(message, title, buttons);
            bool? dialogresult = mymesaagebox.ShowDialog();
            return mymesaagebox.WindowResult;
        }

        private void OKCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                this._DialogResult = DialogResults.Ok;
                this.DialogResult = true;
            }
            catch { }
        }

        private void CancelCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                this._DialogResult = DialogResults.Cancel;
                this.Close();
            }
            catch { }
        }

        private void YesCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                this._DialogResult = DialogResults.Yes;
                this.DialogResult = true;
            }
            catch { }
        }

        private void NoCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                this._DialogResult = DialogResults.No;
                this.DialogResult = false;
            }
            catch { }
        }

        [Obsolete]
        private new void Show()
        {
            throw new NotImplementedException();
        }
    }
}