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

namespace AppPlayKaraoke_WithVideo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtKaraoke1.Text = "";
            txtKaraoke2.Text = "";
            
            txtKaraoke1.ReadOnly = true;
            txtKaraoke2.ReadOnly = true;
            labelNumber.Text = "";
        }

        private void media_Enter(object sender, EventArgs e)
        {
            //------------------------------------------------------------------------------------------------------

            FolderBrowserDialog folder = new FolderBrowserDialog();
            DialogResult result = folder.ShowDialog();
            if (result == DialogResult.OK)
            {
                DirectoryInfo d = new DirectoryInfo(folder.SelectedPath);
                FileInfo[] listFile = d.GetFiles();
                if (listFile.GetLength(0) != 2)
                {
                    MessageBox.Show("Thư mục bạn chọn chỉ được phép tồn tại đúng và đủ 2 File sau :\n\n+ Video : *.mp4\n+ Text Karaoke : *.txt");
                    media_Enter(sender, e);
                    return;
                }

                string dinhdangFile1 = listFile[0].ToString().Substring(listFile[0].ToString().Length - 4, 4);
                string dinhdangFile2 = listFile[1].ToString().Substring(listFile[1].ToString().Length - 4, 4);
                if (dinhdangFile1 == ".mp4" && dinhdangFile2 == ".txt" || dinhdangFile1 == ".txt" && dinhdangFile2 == ".mp4")
                {
                    if (dinhdangFile1 == ".mp4")
                    {
                        media.URL = folder.SelectedPath + "/" + listFile[0];
                    }
                    else
                    {
                        media.URL = folder.SelectedPath + "/" + listFile[1];
                    }

                    timer1.Interval = 100;
                    timer1.Start();
                    t = 0;
                    n = 0;
                    time_xuathien = new int[500];
                    time_luuvet = new string[500];
                    kf = 0;
                    kk = 0;
                    empty = -1;

                    string s = "";

                    if (dinhdangFile1 == ".txt")
                    {
                        s = File.ReadAllText(folder.SelectedPath + "/" + listFile[0]);
                    }
                    else
                    {
                        s = File.ReadAllText(folder.SelectedPath + "/" + listFile[1]);
                    }

                    LBH = s.Split('\n');
                    int k = 0;
                    for (int i = 0; i < LBH.Length; i++)
                    {
                        string[] ss = LBH[i].Split('#');
                        time_xuathien[k] = int.Parse(ss[0]);
                        LBH[k] = ss[1];
                        if (ss[1] != "[Empty]" && ss[1] != "[Empty-X]")
                        {
                            time_luuvet[k] = ss[2];
                        }
                        k++;
                    }
                }
                else
                {
                    MessageBox.Show("Thư mục bạn chọn chỉ được phép tồn tại đúng và đủ 2 File sau :\n\n+ Video : *.mp4\n+ Text Karaoke : *.txt");
                    media_Enter(sender, e);
                    return;
                }

            }
            else
            {
                MessageBox.Show("Vui lòng chọn thư mục chứa đủ 2 file : Video - mp4 (tự chèn âm thanh thích hợp vào video) và Text Karaoke - txt để tiếp tục...");
                MessageBox.Show("Nếu hiện tại file Video của bạn không phải định dạng *.mp4 hoặc file Text Karaoke của bạn chưa phải định dạng *.txt, vui lòng thực hiện chuyển đổi phù hợp và thử lại...");
                media_Enter(sender, e);
            }
        }

        int t;
        int[] time_xuathien;
        string[] LBH;
        string[] time_luuvet;
        int n = 0;
        int kf = 0;
        int[] h_xh;
        int[] h_le;
        int kk = 0;
        int empty = -1;

        private void timer1_Tick(object sender, EventArgs e)
        {
            t++;

            if (t == time_xuathien[n])
            {
                h_xh = new int[500];
                h_le = new int[500];

                if (LBH[n] != "[Empty]" && LBH[n] != "[Empty-X]")
                {
                    string[] s = time_luuvet[n].Split(',');

                    for (int i = 0; i < s.Length; i++)
                    {
                        string[] ss = s[i].Split('-');
                        h_xh[kk] = int.Parse(ss[0]);
                        h_le[kk] = int.Parse(ss[1]);
                        kk++;
                    }
                }


                if (LBH[n] == "[Empty]" || LBH[n] == "[Empty-X]")
                {
                    txtKaraoke1.Text = "";
                    txtKaraoke2.Text = "";
                }
                else
                {
                    string[] sing = LBH[n].Split('*');
                    txtKaraoke1.Text = sing[0];
                    txtKaraoke2.Text = sing[1];

                    txtKaraoke2.Location = new Point(1400 - 35 * (txtKaraoke2.TextLength - 1), 630);
                }

                txtKaraoke1.Select(0, LBH[n].Length + 1);
                txtKaraoke1.SelectionColor = Color.White;
                txtKaraoke2.Select(0, LBH[n].Length + 1);
                txtKaraoke2.SelectionColor = Color.White;
                n++;
            }

            if (n > 1 && LBH[n - 1] == "[Empty]" && empty == -1)
            {
                empty = kf;
            }

            if (h_xh != null && (t == h_xh[0] - 8 || empty != -1 && t == h_xh[empty] - 8))
            {
                labelNumber.Text = "1";
            }

            if (h_xh != null && (t == h_xh[0] - 18 || empty != -1 && t == h_xh[empty] - 18))
            {
                labelNumber.Text = "2";
            }

            if (h_xh != null && (t == h_xh[0] - 28 || empty != -1 && t == h_xh[empty] - 28))
            {
                labelNumber.Text = "3";
            }


            string[] xinloi = txtKaraoke1.Text.Split(' ');

            if (h_xh != null && t == h_xh[kf])
            {
                if (h_le[kf] <= txtKaraoke1.TextLength + xinloi[xinloi.Length - 1].Length)
                {
                    txtKaraoke1.Select(0, h_le[kf]);
                    txtKaraoke1.SelectionColor = Color.Yellow;
                }
                else
                {
                    txtKaraoke2.Select(0, h_le[kf] - txtKaraoke1.TextLength - 2);
                    txtKaraoke2.SelectionColor = Color.Yellow;
                }
                kf++;

                labelNumber.Text = "";
            }
        }
    }
}
