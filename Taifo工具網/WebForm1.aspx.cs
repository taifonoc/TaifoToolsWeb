using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Net;
using Renci.SshNet;
using System.Threading;
using Microsoft.VisualBasic;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace Taifo工具網
{




    public partial class WebForm1 : System.Web.UI.Page
    {

        string[] TD_area = { "北市區", "北北區", "北南區", "北西區" };


        string[] T100 = { "T100-011", "T100-021", "T100-031", "T100-041", "T100-061", "T100-071" };
        string[] T103 = { "T103-001", "T103-011", "T103-021", "T103-031", "T103-041", "T103-051" };
        string[] T104 = { "T104-001", "T104-011", "T104-031", "T104-041", "T104-051", "T104-061", "T104-071", "T104-081" };
        string[] T105 = { "T105-001", "T105-011", "T105-021", "T105-031", "T105-041", "T105-051", "T105-061", "T105-071", "T105-081" };
        string[] T106 = { "T106-001", "T106-011", "T106-021", "T106-031", "T106-041", "T106-051", "T106-061", "T106-071", "T106-081", "T106-101", "T106-121" };
        string[] T108 = { "T108-011", "T108-021", "T108-031", "T108-041", "T108-051", "T108-061" };
        string[] T110 = { "T110-001", "T110-021", "T110-031", "T110-041", "T110-051", "T110-061", "T110-081", "T110-091", "T110-101" };
        string[] T111 = { "T111-001", "T111-011", "T111-021", "T111-031", "T111-041", "T111-061", "T111-071", "T111-081", "T111-091", "T111-101", "T111-111" };
        string[] T112 = { "T112-001", "T112-011", "T112-031", "T112-041", "T112-051", "T112-061", "T112-071", "T112-081" };
        string[] T114 = { "T114-001", "T114-002", "T114-004", "T114-011", "T114-021", "T114-031", "T114-041", "T114-051", "T114-061", "T114-071", "T114-081", "T114-091", "T114-101" };
        string[] T115 = { "T115-011", "T115-021", "T115-031", "T115-041", "T115-051", "T115-061" };
        string[] T116 = { "T116-011", "T116-021", "T116-031", "T116-041", "T116-051", "T116-061", "T116-071", "T116-081", "T116-091", "T116-101" };

        protected void Main_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Main_DropDownList.SelectedItem.ToString())
            {
                case "台電查詢":
                    {
                        Panel1.Visible = false;
                        Panel2.Visible = true;
                    }
                    break;
                case "Profile生成器":
                    {
                        Panel2.Visible = false;
                        Panel1.Visible = true;
                    }
                    break;

            }
        }

        protected void TD_button_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
        }

        protected void Profile_button_Click(object sender, EventArgs e)
        {
            Panel2.Visible = false;
            Panel1.Visible = true;
        }


        protected void Panel1_Init(object sender, EventArgs e)
        {
            Pr_Case_DropDownList.Items.Add("自定義");
            Pr_Case_DropDownList.Items.Add("MN (固定IP)");
            Pr_Case_DropDownList.Items.Add("資訊局 (Routing)");
            Pr_Case_DropDownList.Items.Add("資訊局 (Bridge)");
            Pr_Case_DropDownList.Items.Add("圖書館 (Bridge)");
            Pr_Case_DropDownList.Items.Add("民防 (Routing)");
            Pr_Case_DropDownList.Items.Add("停管處 (Routing)");
            Pr_Case_DropDownList.Items.Add("停管處 (Bridge)");

            Pr_Area_DropDownList.Items.Add("T100 (中正區)");
            Pr_Area_DropDownList.Items.Add("T103 (大同區)");
            Pr_Area_DropDownList.Items.Add("T104 (中山區)");
            Pr_Area_DropDownList.Items.Add("T105 (松山區)");
            Pr_Area_DropDownList.Items.Add("T106 (大安區)");
            Pr_Area_DropDownList.Items.Add("T108 (萬華區)");
            Pr_Area_DropDownList.Items.Add("T110 (信義區)");
            Pr_Area_DropDownList.Items.Add("T111 (士林區)");
            Pr_Area_DropDownList.Items.Add("T112 (北投區)");
            Pr_Area_DropDownList.Items.Add("T114 (內湖區)");
            Pr_Area_DropDownList.Items.Add("T115 (南港區)");
            Pr_Area_DropDownList.Items.Add("T116 (文山區)");

            Main_DropDownList.Items.Add("台電查詢");
            Main_DropDownList.Items.Add("Profile生成器");

            // ComboBox　預設顯示值為 
            Pr_Case_DropDownList.SelectedIndex = 0;
            this.Pr_Case_DropDownList.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //========================================自動開通========================================
        // 桌布更換設定
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        protected static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam);




        //  OLT 選單




        // ====================================主要按鈕====================================
        protected void grow_button_Click(object sender, EventArgs e)
        {
            Pr_auto_button.Enabled = true;

            ONT_Profile.Slot = Pr_Slot_Box.Text;
            ONT_Profile.Port = Pr_Port_Box.Text;
            ONT_Profile.Onuid = Pr_Onu_Box.Text;
            ONT_Profile.Sn = Pr_SN_Box.Text;
            ONT_Profile.Des = Pr_Des_Box.Text;
            ONT_Profile.mode = Pr_Mode_Box.Text;
            ONT_Profile.Svlan = Pr_Svlan_Box.Text;
            ONT_Profile.Cvlan = Pr_Cvlan_Box.Text;
            ONT_Profile.Bw_Up = Pr_UP_Box.Text;
            ONT_Profile.Bw_Down = Pr_Down_Box.Text;
            ONT_Profile.Ip = Pr_IP_Box.Text;
            ONT_Profile.Gw = Pr_GW_Box.Text;
            ONT_Profile.Bw_Per = Pr_Percen_Box.Text;
            if (Pr_Des_Box.Text != "" && Pr_Des_Box.Text.Length == 10)
            {
                ONT_Profile.MV = Pr_Des_Box.Text.Substring(6, 4);
            }
            else
            {
                //MessageBox.Show("你電路編號是不是填錯阿!");
            }

            ONT_Profile.Group7750();


            ONT_Profile.ip1 = Pr_IP1_textBox.Text;

            ONT_Profile.ip2 = Pr_IP2_textBox.Text;


            ONT_Profile.ip3 = Pr_IP3_textBox.Text;


            ONT_Profile.ip4 = Pr_IP4_textBox.Text;


            ONT_Profile.ip5 = Pr_IP5_textBox.Text;


            ONT_Profile.ip6 = Pr_IP6_textBox.Text;


            string total =
                "====================OLT部分====================\r\n" +
                ONT_Profile.Dba_profile() +"\r\n"+
                ONT_Profile.Vlan_profile() + "\r\n" +
                ONT_Profile.Traffic_profile() + "\r\n" +
                ONT_Profile.Onu_profile() + "\r\n" +
                ONT_Profile.GPON_OLT() + "\r\n" +
                ONT_Profile.OLT_Vlan() + "\r\n" +
                "\r\n====================10K部分====================\r\n" +
                ONT_Profile.K10() + "\r\n" +
                "\r\n====================7750或7450部分====================\r\n" +
                ONT_Profile.ALU7750()+"\r\n" 
                ;










            Pr_output_richTextBox.Text = total;







            if (Pr_Passwd_Box.Text == "zong")
            {
                //MessageBox.Show("Right!!");

                int Desktop = 0;

                Desktop = SystemParametersInfo(20, 1, $@"{AppDomain.CurrentDomain.BaseDirectory}DATA/PIC01.jpg");






            }
            else if (Pr_Passwd_Box.Text == "yuqin")
            {
                if (Pr_auto_button.Visible == false)
                {
                    //WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
                    //wplayer.URL = $@"{AppDomain.CurrentDomain.BaseDirectory}DATA/MIC04.mp3";
                    //wplayer.controls.play();
                    //Thread.Sleep(2000);
                    //wplayer.URL = $@"{AppDomain.CurrentDomain.BaseDirectory}DATA/MIC07.mp3";
                    //wplayer.controls.play();
                    //MessageBox.Show("恭喜開通：一鍵開通功能!");

                    Pr_auto_button.Visible = true;
                }
                else if (Pr_auto_button.Visible == true)
                {
                    Pr_auto_button.Enabled = true;
                }

            }


            else if (Pr_Passwd_Box.Text != "")
            {
                //WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
                //wplayer.URL = $@"{AppDomain.CurrentDomain.BaseDirectory}DATA/MIC01.mp3";
                //wplayer.controls.play();
                //MessageBox.Show("密碼提示：每個同事的英文名字都可能有不同效果");


            }

        }







        // 行政區 → OLT 選單
        protected void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Pr_Area_DropDownList.SelectedItem.ToString())
            {
                case @"T100 (中正區)":
                    ONT_Profile.Area = "100";
                    Pr_Olt_DropDownList.Items.Clear();
                    //Pr_Olt_DropDownList.ResetText();
                    if (Pr_Case_DropDownList.Text == "MN (固定IP)")
                    {
                        Pr_Svlan_Box.Text = "尚未選擇OLT";
                    }
                    foreach (var item in T100)
                    {

                        Pr_Olt_DropDownList.Items.Add(item);
                    }
                    break;
                case @"T103 (大同區)":
                    ONT_Profile.Area = "103";
                    Pr_Olt_DropDownList.Items.Clear();
                    //Pr_Olt_DropDownList.ResetText();
                    if (Pr_Case_DropDownList.Text == "MN (固定IP)")
                    {
                        Pr_Svlan_Box.Text = "尚未選擇OLT";
                    }
                    foreach (var item in T103)
                    {
                        Pr_Olt_DropDownList.Items.Add(item);
                    }
                    break;
                case @"T104 (中山區)":
                    ONT_Profile.Area = "104";
                    Pr_Olt_DropDownList.Items.Clear();
                    //Pr_Olt_DropDownList.ResetText();
                    if (Pr_Case_DropDownList.Text == "MN (固定IP)")
                    {
                        Pr_Svlan_Box.Text = "尚未選擇OLT";
                    }
                    foreach (var item in T104)
                    {
                        Pr_Olt_DropDownList.Items.Add(item);
                    }
                    break;
                case @"T105 (松山區)":
                    ONT_Profile.Area = "105";
                    Pr_Olt_DropDownList.Items.Clear();
                    //Pr_Olt_DropDownList.ResetText();
                    if (Pr_Case_DropDownList.Text == "MN (固定IP)")
                    {
                        Pr_Svlan_Box.Text = "尚未選擇OLT";
                    }
                    foreach (var item in T105)
                    {
                        Pr_Olt_DropDownList.Items.Add(item);
                    }
                    break;
                case @"T106 (大安區)":
                    ONT_Profile.Area = "106";
                    Pr_Olt_DropDownList.Items.Clear();
                    //Pr_Olt_DropDownList.ResetText();
                    if (Pr_Case_DropDownList.Text == "MN (固定IP)")
                    {
                        Pr_Svlan_Box.Text = "尚未選擇OLT";
                    }
                    foreach (var item in T106)
                    {
                        Pr_Olt_DropDownList.Items.Add(item);
                    }
                    break;
                case @"T108 (萬華區)":
                    ONT_Profile.Area = "108";
                    Pr_Olt_DropDownList.Items.Clear();
                    //Pr_Olt_DropDownList.ResetText();
                    if (Pr_Case_DropDownList.Text == "MN (固定IP)")
                    {
                        Pr_Svlan_Box.Text = "尚未選擇OLT";
                    }
                    foreach (var item in T108)
                    {
                        Pr_Olt_DropDownList.Items.Add(item);
                    }
                    break;
                case @"T110 (信義區)":
                    ONT_Profile.Area = "110";
                    Pr_Olt_DropDownList.Items.Clear();
                    //Pr_Olt_DropDownList.ResetText();
                    if (Pr_Case_DropDownList.Text == "MN (固定IP)")
                    {
                        Pr_Svlan_Box.Text = "尚未選擇OLT";
                    }
                    foreach (var item in T110)
                    {
                        Pr_Olt_DropDownList.Items.Add(item);
                    }
                    break;
                case @"T111 (士林區)":
                    ONT_Profile.Area = "111";
                    Pr_Olt_DropDownList.Items.Clear();
                    //Pr_Olt_DropDownList.ResetText();
                    if (Pr_Case_DropDownList.Text == "MN (固定IP)")
                    {
                        Pr_Svlan_Box.Text = "尚未選擇OLT";
                    }
                    foreach (var item in T111)
                    {
                        Pr_Olt_DropDownList.Items.Add(item);
                    }
                    break;
                case @"T112 (北投區)":
                    ONT_Profile.Area = "112";
                    Pr_Olt_DropDownList.Items.Clear();
                    //Pr_Olt_DropDownList.ResetText();
                    if (Pr_Case_DropDownList.Text == "MN (固定IP)")
                    {
                        Pr_Svlan_Box.Text = "尚未選擇OLT";
                    }
                    foreach (var item in T112)
                    {
                        Pr_Olt_DropDownList.Items.Add(item);
                    }
                    break;
                case @"T114 (內湖區)":
                    ONT_Profile.Area = "114";
                    Pr_Olt_DropDownList.Items.Clear();
                    //Pr_Olt_DropDownList.ResetText();
                    if (Pr_Case_DropDownList.Text == "MN (固定IP)")
                    {
                        Pr_Svlan_Box.Text = "尚未選擇OLT";
                    }
                    foreach (var item in T114)
                    {
                        Pr_Olt_DropDownList.Items.Add(item);
                    }
                    break;
                case @"T115 (南港區)":
                    ONT_Profile.Area = "115";
                    Pr_Olt_DropDownList.Items.Clear();
                    //Pr_Olt_DropDownList.ResetText();
                    if (Pr_Case_DropDownList.Text == "MN (固定IP)")
                    {
                        Pr_Svlan_Box.Text = "尚未選擇OLT";
                    }
                    foreach (var item in T115)
                    {
                        Pr_Olt_DropDownList.Items.Add(item);
                    }
                    break;
                case @"T116 (文山區)":
                    ONT_Profile.Area = "116";
                    Pr_Olt_DropDownList.Items.Clear();
                    //Pr_Olt_DropDownList.ResetText();
                    if (Pr_Case_DropDownList.Text == "MN (固定IP)")
                    {
                        Pr_Svlan_Box.Text = "尚未選擇OLT";
                    }
                    foreach (var item in T116)
                    {
                        Pr_Olt_DropDownList.Items.Add(item);
                    }
                    break;
                default:
                    break;
            }

            if (Pr_Case_DropDownList.Text == "MN (固定IP)" && Pr_Olt_DropDownList.Text != "")
            {
                Pr_Svlan_Box.Text = ((int.Parse(ONT_Profile.Area) - 100) * 100 + (((int.Parse(Pr_Olt_DropDownList.Text.Substring(5, 3)) - 1) / 10) * 4 + 1) + 1000).ToString();
            }
        }



        // ====================================專案選單====================================
        protected void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Pr_Case_DropDownList.SelectedItem.ToString())
            {
                case "自定義":
                    Pr_Slot_Box.Text="";
                    Pr_Port_Box.Text = "";
                    Pr_Onu_Box.Text = "";
                    Pr_SN_Box.Text = "";
                    Pr_Des_Box.Text = "";
                    Pr_Mode_Box.Text = "";
                    Pr_Svlan_Box.Text = "";
                    Pr_Cvlan_Box.Text = "";
                    Pr_UP_Box.Text = "";
                    Pr_Down_Box.Text = "";
                    Pr_IP_Box.Text = "";
                    Pr_GW_Box.Text = "";
                    Pr_IP1_textBox.Text = "";
                    Pr_IP6_textBox.Text = "";
                    Pr_IP3_textBox.Text = "";
                    Pr_IP6_textBox.Text="";
                    Pr_IP5_textBox.Text="";
                    Pr_IP4_textBox.Text = "";
                    Pr_Percen_Box.Enabled = true;
                    Pr_Onu_Box.Enabled = true;
                    Pr_SN_Box.Enabled = true;
                    Pr_Des_Box.Enabled = true;
                    Pr_Mode_Box.Enabled = true;
                    Pr_Svlan_Box.Enabled = true;
                    Pr_Cvlan_Box.Enabled = true;
                    Pr_UP_Box.Enabled = true;
                    Pr_IP_Box.Enabled = true;
                    Pr_GW_Box.Enabled = true;
                    Pr_Percen_Box.Enabled = true;
                    Pr_IP1_textBox.Enabled = true;
                    Pr_IP2_textBox.Enabled = true;
                    Pr_IP3_textBox.Enabled = true;
                    Pr_IP6_textBox.Enabled = true;
                    Pr_IP5_textBox.Enabled = true;
                    Pr_IP4_textBox.Enabled = true;
                    break;

                case "資訊局 (Routing)":
                    Pr_Svlan_Box.Text = "602";
                    Pr_Svlan_Box.Enabled = false;
                    Pr_Mode_Box.Text = "4";
                    Pr_Mode_Box.Enabled = false;
                    Pr_IP1_textBox.Enabled = false;
                    Pr_IP2_textBox.Enabled = false;
                    Pr_IP3_textBox.Enabled = false;
                    Pr_IP6_textBox.Enabled = false;
                    Pr_IP5_textBox.Enabled = false;
                    Pr_IP4_textBox.Enabled = false;
                    Pr_IP_Box.Enabled = true;
                    Pr_GW_Box.Enabled = true;
                    Pr_Cvlan_Box.Enabled = true;
                    Pr_Cvlan_Box.Text = "";
                    break;
                case "資訊局 (Bridge)":
                    Pr_Svlan_Box.Text = "602";
                    Pr_Svlan_Box.Enabled = false;
                    Pr_Mode_Box.Text = "0";
                    Pr_Mode_Box.Enabled = false;
                    Pr_IP1_textBox.Enabled = false;
                    Pr_IP2_textBox.Enabled = false;
                    Pr_IP3_textBox.Enabled = false;
                    Pr_IP6_textBox.Enabled = false;
                    Pr_IP5_textBox.Enabled = false;
                    Pr_IP4_textBox.Enabled = false;
                    Pr_Cvlan_Box.Text = "";
                    Pr_IP_Box.Text="";
                    Pr_GW_Box.Text = "";
                    Pr_IP_Box.Enabled = false;
                    Pr_GW_Box.Enabled = false;
                    Pr_Cvlan_Box.Enabled = true;
                    break;
                case "MN (固定IP)":
                    if (Pr_Area_DropDownList.Text == "" || Pr_Olt_DropDownList.Text == "")
                    {
                        Pr_Svlan_Box.Text = "尚未選擇OLT";
                        Pr_Cvlan_Box.Text = "尚未填入完整Port位";
                        Pr_Svlan_Box.Enabled = false;
                        Pr_Cvlan_Box.Enabled = false;
                        Pr_Mode_Box.Text = "0";
                        Pr_Mode_Box.Enabled = false;
                        Pr_IP1_textBox.Enabled = false;
                        Pr_IP2_textBox.Enabled = false;
                        Pr_IP3_textBox.Enabled = false;
                        Pr_IP6_textBox.Enabled = false;
                        Pr_IP5_textBox.Enabled = false;
                        Pr_IP4_textBox.Enabled = false;
                        Pr_IP_Box.Text="";
                        Pr_GW_Box.Text = "";
                        Pr_IP_Box.Enabled = false;
                        Pr_GW_Box.Enabled = false;
                        Pr_IP1_textBox.Enabled = true;
                        Pr_IP2_textBox.Enabled = true;
                        Pr_IP3_textBox.Enabled = true;
                        Pr_IP6_textBox.Enabled = true;
                        Pr_IP5_textBox.Enabled = true;
                        Pr_IP4_textBox.Enabled = true;
                    }
                    else
                    {
                        Pr_Svlan_Box.Text = ((int.Parse(ONT_Profile.Area) - 100) * 100 + (((int.Parse(Pr_Olt_DropDownList.Text.Substring(5, 3)) - 1) / 10) * 4 + 1) + 1000).ToString();
                        if (Pr_Case_DropDownList.Text == "MN (固定IP)" && Pr_Port_Box.Text != "" && Pr_Slot_Box.Text != "" && Pr_Onu_Box.Text != "")
                        {
                            Pr_Cvlan_Box.Text = ((((int.Parse(Pr_Slot_Box.Text) - 1) * 4 + int.Parse(Pr_Port_Box.Text)) - 1) * 32 + (int.Parse(Pr_Onu_Box.Text) - 1) + 1000).ToString();
                        }
                        Pr_Svlan_Box.Enabled = false;
                        Pr_Cvlan_Box.Enabled = false;
                        Pr_Mode_Box.Text = "0";
                        Pr_Mode_Box.Enabled = false;
                        Pr_IP1_textBox.Enabled = false;
                        Pr_IP2_textBox.Enabled = false;
                        Pr_IP3_textBox.Enabled = false;
                        Pr_IP6_textBox.Enabled = false;
                        Pr_IP5_textBox.Enabled = false;
                        Pr_IP4_textBox.Enabled = false;
                        Pr_IP_Box.Text="";
                        Pr_GW_Box.Text = "";
                        Pr_IP_Box.Enabled = false;
                        Pr_GW_Box.Enabled = false;
                        Pr_IP1_textBox.Enabled = true;
                        Pr_IP2_textBox.Enabled = true;
                        Pr_IP3_textBox.Enabled = true;
                        Pr_IP6_textBox.Enabled = true;
                        Pr_IP5_textBox.Enabled = true;
                        Pr_IP4_textBox.Enabled = true;
                    }

                    break;
                case "圖書館 (Bridge)":
                    Pr_Svlan_Box.Text = "605";
                    Pr_Svlan_Box.Enabled = false;
                    Pr_Mode_Box.Text = "0";
                    Pr_Mode_Box.Enabled = false;
                    Pr_IP1_textBox.Enabled = false;
                    Pr_IP2_textBox.Enabled = false;
                    Pr_IP3_textBox.Enabled = false;
                    Pr_IP6_textBox.Enabled = false;
                    Pr_IP5_textBox.Enabled = false;
                    Pr_IP4_textBox.Enabled = false;
                    Pr_Cvlan_Box.Text = "";
                    Pr_IP_Box.Text="";
                    Pr_GW_Box.Text = "";
                    Pr_IP_Box.Enabled = false;
                    Pr_GW_Box.Enabled = false;
                    Pr_Cvlan_Box.Enabled = true;
                    break;
                case "民防 (Routing)":
                    Pr_Svlan_Box.Text = "424";
                    Pr_Svlan_Box.Enabled = false;
                    Pr_Mode_Box.Text = "4";
                    Pr_Mode_Box.Enabled = false;
                    Pr_IP1_textBox.Enabled = false;
                    Pr_IP2_textBox.Enabled = false;
                    Pr_IP3_textBox.Enabled = false;
                    Pr_IP6_textBox.Enabled = false;
                    Pr_IP5_textBox.Enabled = false;
                    Pr_IP4_textBox.Enabled = false;
                    Pr_IP_Box.Enabled = true;
                    Pr_GW_Box.Enabled = true;
                    Pr_Cvlan_Box.Enabled = true;
                    Pr_Cvlan_Box.Text = "";
                    break;
                case "停管處 (Routing)":
                    Pr_Svlan_Box.Text = "610";
                    Pr_Svlan_Box.Enabled = false;
                    Pr_Mode_Box.Text = "4";
                    Pr_Mode_Box.Enabled = false;
                    Pr_IP1_textBox.Enabled = false;
                    Pr_IP2_textBox.Enabled = false;
                    Pr_IP3_textBox.Enabled = false;
                    Pr_IP6_textBox.Enabled = false;
                    Pr_IP5_textBox.Enabled = false;
                    Pr_IP4_textBox.Enabled = false;
                    Pr_IP_Box.Enabled = true;
                    Pr_GW_Box.Enabled = true;
                    Pr_Cvlan_Box.Enabled = true;
                    Pr_Cvlan_Box.Text = "";
                    break;
                case "停管處 (Bridge)":
                    Pr_Svlan_Box.Text = "610";
                    Pr_Svlan_Box.Enabled = false;
                    Pr_Mode_Box.Text = "0";
                    Pr_Mode_Box.Enabled = false;
                    Pr_IP1_textBox.Enabled = false;
                    Pr_IP2_textBox.Enabled = false;
                    Pr_IP3_textBox.Enabled = false;
                    Pr_IP6_textBox.Enabled = false;
                    Pr_IP5_textBox.Enabled = false;
                    Pr_IP4_textBox.Enabled = false;
                    Pr_Cvlan_Box.Text = "";
                    Pr_IP_Box.Text = "";
                    Pr_GW_Box.Text="";
                    Pr_IP_Box.Enabled = false;
                    Pr_GW_Box.Enabled = false;
                    Pr_Cvlan_Box.Enabled = true;
                    break;

                default:
                    break;
            }
        }










        // ====================================按鈕切換判斷====================================

        protected void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Pr_Case_DropDownList.Text == "MN (固定IP)" && Pr_Area_DropDownList.Text != "")
            {
                Pr_Svlan_Box.Text = ((int.Parse(ONT_Profile.Area) - 100) * 100 + (((int.Parse(Pr_Olt_DropDownList.Text.Substring(5, 3)) - 1) / 10) * 4 + 1) + 1000).ToString();
            }
        }

        protected void Slot_Box_TextChanged(object sender, EventArgs e)
        {
            if (Pr_Case_DropDownList.Text == "MN (固定IP)" && Pr_Port_Box.Text != "" && Pr_Slot_Box.Text != "" && Pr_Onu_Box.Text != "")
            {
                Pr_Cvlan_Box.Text = ((((int.Parse(Pr_Slot_Box.Text) - 1) * 4 + int.Parse(Pr_Port_Box.Text)) - 1) * 32 + (int.Parse(Pr_Onu_Box.Text) - 1) + 1000).ToString();
            }
            if (Pr_Case_DropDownList.Text == "MN (固定IP)")
            {
                if (Pr_Port_Box.Text == "" || Pr_Slot_Box.Text == "" || Pr_Onu_Box.Text == "")
                {
                    Pr_Cvlan_Box.Text = "尚未填入完整Port位";
                }

            }

        }

        protected void Port_Box_TextChanged(object sender, EventArgs e)
        {
            if (Pr_Case_DropDownList.Text == "MN (固定IP)" && Pr_Port_Box.Text != "" && Pr_Slot_Box.Text != "" && Pr_Onu_Box.Text != "")
            {
                Pr_Cvlan_Box.Text = ((((int.Parse(Pr_Slot_Box.Text) - 1) * 4 + int.Parse(Pr_Port_Box.Text)) - 1) * 32 + (int.Parse(Pr_Onu_Box.Text) - 1) + 1000).ToString();
            }
            if (Pr_Case_DropDownList.Text == "MN (固定IP)")
            {
                if (Pr_Port_Box.Text == "" || Pr_Slot_Box.Text == "" || Pr_Onu_Box.Text == "")
                {
                    Pr_Cvlan_Box.Text = "尚未填入完整Port位";
                }

            }

            if (Pr_Port_Box.Text != "")
            {
                if (int.Parse(Pr_Port_Box.Text) > 4)
                {
                    //WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
                    //wplayer.URL = $@"{AppDomain.CurrentDomain.BaseDirectory}DATA/MIC02.mp3";
                    //wplayer.controls.play();
                    //MessageBox.Show("哇賽 你的OLT 超過4個Portㄝ");
                }
            }
        }

        protected void OnuID_Box_TextChanged(object sender, EventArgs e)
        {
            if (Pr_Case_DropDownList.Text == "MN (固定IP)" && Pr_Port_Box.Text != "" && Pr_Slot_Box.Text != "" && Pr_Onu_Box.Text != "")
            {
                Pr_Cvlan_Box.Text = ((((int.Parse(Pr_Slot_Box.Text) - 1) * 4 + int.Parse(Pr_Port_Box.Text)) - 1) * 32 + (int.Parse(Pr_Onu_Box.Text) - 1) + 1000).ToString();
            }
            if (Pr_Case_DropDownList.Text == "MN (固定IP)")
            {
                if (Pr_Port_Box.Text == "" || Pr_Slot_Box.Text == "" || Pr_Onu_Box.Text == "")
                {
                    Pr_Cvlan_Box.Text = "尚未填入完整Port位";
                }

            }
        }



















     




        // ====================================開通按鈕====================================
        protected void auto_button_Click(object sender, EventArgs e)
        {

            OLT_DIC OLTIP = new OLT_DIC();
            string old = "";
            string GP =
                                    $@"
en
config t
gp
"
;

            string GP_Port =
                $@"
gp {ONT_Profile.Slot}/{ONT_Profile.Port}
"
;
            string Show_Old =
$@"
show running-config gpon-olt {ONT_Profile.Slot}/{ONT_Profile.Port}
"
;


            using (var client = new SshClient(OLTIP.Find_DIC(Pr_Olt_DropDownList.Text), 22, "admin", "123"))
            {
                // 建立連線
                client.Connect();

                // 連線參數
                var stream = client.CreateShellStream("", 0, 0, 0, 0, 0);





                Thread.Sleep(4500);
                stream.WriteLine(GP);
                Thread.Sleep(1000);
                stream.WriteLine(GP_Port);
                Thread.Sleep(1000);
                stream.WriteLine(Show_Old);
                Thread.Sleep(2000);
                stream.WriteLine(Environment.NewLine);
                Thread.Sleep(2000);



                // 輸出結果
                string line;
                while ((line = stream.ReadLine(TimeSpan.FromSeconds(2))) != null)
                {
                    int id = line.IndexOf("8272OLT");
                    if (id < 0)
                    {
                        Console.WriteLine(line);
                        old += line + "\r\n";
                    }

                }
                // 結束連線
                stream.Close();
                client.Disconnect();

            }
            Thread.Sleep(1000);
            using (var client = new SshClient(OLTIP.Find_DIC(Pr_Olt_DropDownList.Text), 22, "admin", "123"))
            {
                // 建立連線
                client.Connect();

                // 連線參數
                var stream = client.CreateShellStream("", 0, 0, 0, 0, 0);





                Thread.Sleep(4500);
                stream.WriteLine(GP);
                Thread.Sleep(1500);
                stream.WriteLine(ONT_Profile.Dba_profile());
                Thread.Sleep(1500);
                stream.WriteLine(ONT_Profile.Vlan_profile());
                Thread.Sleep(1500);
                stream.WriteLine(ONT_Profile.Traffic_profile());
                Thread.Sleep(1500);
                stream.WriteLine(ONT_Profile.Onu_profile());
                Thread.Sleep(1500);
                stream.WriteLine(GP_Port);
                Thread.Sleep(1500);
                stream.WriteLine(ONT_Profile.GPON_OLT());
                Thread.Sleep(1500);
                stream.WriteLine("exit");
                stream.WriteLine("bridge");
                Thread.Sleep(1500);
                stream.WriteLine(ONT_Profile.OLT_Vlan());


                // 輸出結果
                string line;
                while ((line = stream.ReadLine(TimeSpan.FromSeconds(2))) != null)
                {
                    Console.WriteLine(line);
                }

                // 結束連線
                stream.Close();
                client.Disconnect();
                //MessageBox.Show("開通完畢!");

                



                StreamWriter str1 = new StreamWriter($@"{AppDomain.CurrentDomain.BaseDirectory}Profile輸出.txt");
                str1.WriteLine(Pr_output_richTextBox.Text);
                str1.Close();

                StreamWriter str2 = new StreamWriter($@"{AppDomain.CurrentDomain.BaseDirectory}OLD_Detail.txt");
                str2.WriteLine(old);
                str2.Close();


                Pr_auto_button.Enabled = false;












            }
        }

        // 探測ONU-ID
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {



                if (Pr_Slot_Box.Text != "" && Pr_Port_Box.Text != "" && Pr_Area_DropDownList.Text != "" && Pr_Olt_DropDownList.Text != "")
                {



                    OLT_DIC OLTIP = new OLT_DIC();


                    using (var client = new SshClient(OLTIP.Find_DIC(Pr_Olt_DropDownList.Text), 22, "admin", "123"))
                    {
                        // 建立連線
                        client.Connect();

                        // 連線參數
                        var stream = client.CreateShellStream("", 0, 0, 0, 0, 0);

                        string GP =
                                                $@"
en
config t
gp
"
        ;

                        string GP_Port =
                            $@"
gp {Pr_Slot_Box.Text}/{Pr_Port_Box.Text}
"
        ;



                        Thread.Sleep(3000);
                        stream.WriteLine(GP);
                        Thread.Sleep(500);
                        stream.WriteLine(GP_Port);
                        Thread.Sleep(500);
                        stream.WriteLine("sh onu info");
                        Thread.Sleep(500);
                        stream.WriteLine(Environment.NewLine);
                        Thread.Sleep(500);
                        int x = 0;
                        int y = 0;
                        // 輸出結果
                        string line;
                        int[] count = new int[38];
                        while ((line = stream.ReadLine(TimeSpan.FromSeconds(2))) != null)
                        {

                            int id = line.IndexOf("ctive");
                            if (id != -1)
                            {
                                Console.WriteLine(line);
                                var lines = line.Split('|');
                                //Console.WriteLine(lines[1]);
                                Console.WriteLine(int.Parse(lines[1].Substring(2, 2)));

                                int id2 = line.IndexOf("Active");
                                {
                                    if (id2 != -1)
                                    {
                                        if (line.Substring(64, 1) == " ")
                                        {
                                            count[37] = int.Parse(lines[1].Substring(2, 2));
                                            y = 1;
                                            Console.WriteLine(line.Substring(64, 1));
                                            Console.WriteLine("印出!!!");

                                        }
                                    }

                                }


                                count[int.Parse(lines[1].Substring(2, 2))] = int.Parse(lines[1].Substring(2, 2));
                                x++;

                            }



                        }
                        // 結束連線
                        if (x == 0)
                        {
                            Pr_Onu_Box.Text = "1";
                        }
                        else
                        {
                            if (y != 1)
                            {
                                for (int i = 1; i < 37; i++)
                                {
                                    Console.WriteLine(count[2]);
                                    Console.WriteLine(count[1]);
                                    if (count[2] != 0 && count[1] == 0)
                                    {
                                        x = 1;
                                        break;
                                    }
                                    else if (count[i] != 0)
                                    {
                                        x = count[i];

                                    }
                                    else
                                    {
                                        x++;
                                        break;
                                    }

                                }
                                Pr_Onu_Box.Text = "" + (x);
                                Console.WriteLine(x);
                            }
                            else
                                Pr_Onu_Box.Text = "" + count[37];

                        }

                    }

                    //WMPLib.WindowsMediaPlayer wplayer1 = new WMPLib.WindowsMediaPlayer();
                    //wplayer1.URL = $@"{AppDomain.CurrentDomain.BaseDirectory}DATA/MIC06.mp3";
                    //wplayer1.controls.play();
                }



                else
                {
                    //MessageBox.Show("你 OLT位置 或 Slot 或 Port 沒填?");
                }


            }
            catch (Exception)
            {
           
            }


        }


        //=====================================台電查詢=====================================
        protected void Button2_Click(object sender, EventArgs e)
        {
            TD_TextBox2.Text="";
            DateTime d = DateTime.Now;
            //string t = textBox1.Text.ToString();
            string t = Strings.StrConv(TD_textbox.Text.ToString(), VbStrConv.Wide);
            int count = 0;
            DateTime yday = d.AddDays(1);//明天
            string yyday = yday.ToString("yyyyMMdd");   //明天轉字串
            string day = d.ToString("yyyyMMdd");    //今天轉字串
            string line;
            string[] SecrH = new string[500];
            string[] text1 = new string[5000];
            int num = 0;
            int Dnum = 0;
            int cos = 0;
            int Tcos = 0;
            text1[0] = " ";
            string Sameday = d.GetDateTimeFormats('D')[1].ToString();
            foreach (var item in TD_area)
            {

                try
                {

                    StreamReader str = new StreamReader($@"{AppDomain.CurrentDomain.BaseDirectory}\{item}\{Sameday}-{item}.txt");
                    while ((line = str.ReadLine()) != null)
                    {
                        //  Console.WriteLine(line);
                        //text.Add(line);
                        if (num == 0 || num < 5000)
                        {
                            text1[num] = line;


                            int dayd = line.IndexOf(yyday); // 文本中搜尋明天

                            int ttd = line.IndexOf(day);//文本搜尋今天
                            int td = line.IndexOf("日期:");
                            int time = line.IndexOf("分 至");

                            int r = line.IndexOf(t);


                            if (ttd != -1)           //當搜尋到今天日期 count=1
                            {
                                count = 1;
                                //richTextBox2.Text += $"{text1[num]}" + Environment.NewLine;
                                if (Tcos == 0)
                                {
                                    TD_TextBox2.Text += $"{DateTime.Now.ToString("yyyy/MM/dd")}" + Environment.NewLine;
                                    Tcos = 1;
                                }
                            }
                            else if (td != -1)
                            {
                                count = 0;
                            }
                            // Console.WriteLine(line);

                            if (time != -1)
                            {
                                SecrH[Dnum] = text1[num];
                                Dnum++;
                                cos = 1;
                            }


                            switch (count)
                            {
                                case 1:
                                    if (r != -1)  //當搜尋到"日期"  "文字格中的字串" "自"  和count=1
                                    {                                             //輸出



                                        //richTextBox2.Text += $"{text1[num]}" + Environment.NewLine; 顯示區域
                                        if (cos == 1)
                                        {
                                            TD_TextBox2.Text += $"===============================" +
                                                    $"============================================" +
                                                    $"==========================================" +
                                                    $"\n{SecrH[Dnum - 1]}" + Environment.NewLine;

                                        }

                                        TD_TextBox2.Text += $"{text1[num]}" + Environment.NewLine;


                                        cos = 0;
                                    }

                                    break;
                                default:
                                    break;
                            }

                            num++;
                        }

                    }
                    str.Close();

                }
                catch (Exception)
                {
                    UrlAddress N = new UrlAddress();
                    N.Urladdress("https://branch.taipower.com.tw/Content/NoticeBlackout/bulletin.aspx?&SiteID=564732646551216421&MmmID=616371300113254267");
                    N.area("北市區");
                    N.Html_Original();



                    UrlAddress NN = new UrlAddress();
                    NN.Urladdress("https://branch.taipower.com.tw/Content/NoticeBlackout/bulletin.aspx?&SiteID=564732636524040174&MmmID=616371300130136031");
                    NN.area("北北區");
                    NN.Html_Original();


                    UrlAddress NS = new UrlAddress();
                    NS.Urladdress("https://branch.taipower.com.tw/Content/NoticeBlackout/bulletin.aspx?&SiteID=564732646356736245&MmmID=616371300115522273");
                    NS.area("北南區");
                    NS.Html_Original();


                    UrlAddress NW = new UrlAddress();
                    NW.Urladdress("https://branch.taipower.com.tw/Content/NoticeBlackout/bulletin.aspx?&SiteID=564766277367364243&MmmID=616371300000777256");
                    NW.area("北西區");
                    NW.Html_Original();


                }



            }
        }

    }
}