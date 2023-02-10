using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppCreateKaraoke
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtDoXet.ReadOnly = true;
        }

        int t = 0;

        private void txtLBH_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            t++;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                media.URL = file.FileName;
                t = 0;
                timer1.Interval = 100;
                timer1.Start();

                //--------------------------------

                LBH = txtLBH.Text.Split('\n');
                time_XuatHien = new int[500];
                time_LuuVet = new string[500];
                n = 0;
                k = 0;
                nn = 0;
                textBox1.Focus();
            }
        }

        string[] LBH;
        int[] time_XuatHien;
        string[] time_LuuVet;
        int n;
        int k;
        int nn;

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //textBox1.Visible = false;
            textBox1.ReadOnly = true;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string[] lbh = txtDoXet.Text.Split(' ');
                nn += lbh[k].Length + 1;
                txtDoXet.Select(0, nn);
                txtDoXet.SelectionColor = Color.Blue;
                time_LuuVet[n-1] += t + "-" + nn;
                if (k < lbh.Length - 1)
                    time_LuuVet[n - 1] += ",";
                    k++;
            }

            if (e.KeyCode == Keys.Space)
            {
                k = 0;
                nn = 0;
                txtDoXet.Text = LBH[n];
                time_XuatHien[n] = t;
                n++;
                txtDoXet.Select(0, txtDoXet.Text.Length +1);
                txtDoXet.SelectionColor = Color.Black;
            }
        }

        private void XONG_Click(object sender, EventArgs e)
        {
            if (txtFileName.TextLength == 0)
            {
                MessageBox.Show("Vui lòng nhập tên file TXT xử lý Karaoke cần lưu...");
                return;
            }

            string ss = "";
            for (int i = 0; i<LBH.Length;i++)
            {
                if (LBH[i] != "[Empty]")
                {
                    if (cbSplit.Checked == false)
                    ss += time_XuatHien[i] + "#" + LBH[i] + "#" + time_LuuVet[i];
                    else
                    {
                        string[] lbh = LBH[i].Split(' ');
                            string kk = "";
                            for (int j = 0; j< lbh.Length;j++)
                            {
                                kk += lbh[j];
                                if (j < lbh.Length - 1 && j != (lbh.Length / 2) - 1)
                                    kk += " ";
                                if (j == (lbh.Length / 2) - 1)
                                    kk += "*";
                            }
                            ss += time_XuatHien[i] + "#" + kk + "#" + time_LuuVet[i];
                    }
                }
                else
                    ss += time_XuatHien[i] + "#" + LBH[i];
                if (i < LBH.Length - 1)
                    ss += "\n";
            }
            timer1.Stop();
            File.WriteAllText("D:/" + txtFileName.Text+".txt", ss);
            MessageBox.Show("Thành công...\nVui lòng kiểm tra, thực hiện lại và quay lại sau, xin cảm ơn !");
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("+ Bước 1 : Thả toàn bộ (đầy đủ) lời bài hát và phù hợp Media.\n+ Bước 2 : Chọn và Play Media phù hợp, mục đích để dễ dàng dò xét và lưu vết Karaoke.\n+ Bước 3 : Khi Media vừa được chọn cũng là lúc nó đã Play và bắt đầu...\n+ Bước 4 : Sau khi Start, bạn không nên thao tác hay hành động gì khác. Trong lúc này, bạn chỉ có thể sử dụng nút phím [Space] hoặc [Enter] để thao tác theo hướng dẫn.\n+ Bước 5 : Sau khi hoàn tất, cứ việc lưu tên file TXT xử lý Karaoke và thành công !\nP/s : Nếu có vấn đề hay lỗi xảy ra, phiền bạn đóng ứng dụng và thực hiện lại --> phải thật cẩn thận !\n\n==> Sau này bạn có thể sữ dụng file Karaoke đã xử lý để có thể PLay Karaoke ở ứng dụng khác...");
        }
    }
}
