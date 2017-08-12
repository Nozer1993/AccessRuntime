using AccessRuntime.Bin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AccessRuntime
{
    public partial class FrmTest : Form
    {
        public FrmTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            //AccessUtils au = new AccessUtils("tjgabl",null);
            //MessageBox.Show(au.ExecuteSql("create table testa(id int)").ToString());

            //            string sql = @"create table a(123) /*go*/ create table b(222) /*go*/ c
            ///*go*/ddd/*go*//*go*/";
            //            string[] ss = sql.Split(new string[1] { "/*go*/" }, StringSplitOptions.RemoveEmptyEntries);
            //            foreach (string s in ss)
            //            {
            //                var temps = s.Trim().Replace("\r\n", "");
            //                if (!string.IsNullOrEmpty(temps))
            //                {
            //                    textBox1.Text += temps + "\r\n";
            //                }
            //            }

            if (AccessTool.ExecuteSqlByFile(openFileDialog1.FileName,"tjgabl"))
                MessageBox.Show("成功");
            else
                MessageBox.Show("失败:");
        }
    }
}
