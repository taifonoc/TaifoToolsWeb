<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Taifo工具網.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body style="height: 1169px">
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="Main_DropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Main_DropDownList_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <asp:Panel ID="Panel2" runat="server" Height="754px">
                <br />
                <asp:TextBox ID="TD_textbox" runat="server"></asp:TextBox>
                <asp:Button ID="TD_secr" runat="server" OnClick="Button2_Click" Text="搜尋" />
                <br />
                <br />
                <asp:TextBox ID="TD_TextBox2" runat="server" Height="550px" TextMode="MultiLine" Width="876px"></asp:TextBox>
            </asp:Panel>
            <br />
        </div>
        <asp:Panel ID="Panel1" runat="server" Height="609px" OnInit="Panel1_Init" Visible="False">
            <asp:Label ID="Pr_Case_comboBox" runat="server" Text="專案類型：" Style="margin-left: auto"></asp:Label>
            <asp:Label ID="Pr_Area_label" runat="server" Text="行政區：" Style="margin-left: 50px"></asp:Label>
            <asp:Label ID="Pr_Olt_label" runat="server" Text="OLT：" Style="margin-left: 70px"></asp:Label>
            <br />
            
            <asp:DropDownList ID="Pr_Case_DropDownList" Style="margin-top: 10px" runat="server" Height="25px" Width="120px" AutoPostBack="True" OnSelectedIndexChanged="ComboBox1_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:DropDownList ID="Pr_Area_DropDownList" runat="server" Style="margin-left: 10px" Height="25px" Width="120px" AutoPostBack="True" OnSelectedIndexChanged="ComboBox2_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:DropDownList ID="Pr_Olt_DropDownList" runat="server" Style="margin-left: 10px" Height="25px" Width="120px" AutoPostBack="True" OnSelectedIndexChanged="ComboBox3_SelectedIndexChanged">
            </asp:DropDownList>

            <br  />

            <asp:Label ID="Pr_Slot_label" runat="server" Style="margin-left: auto;margin-top:100px " Text="Slot："></asp:Label>
            <asp:Label ID="Pr_Port_label" runat="server" Style="margin-left: 80px" Text="Port："></asp:Label>
            <asp:Label ID="Pr_Onu_label" runat="server" Style="margin-left: 80px" Text="OnuID："></asp:Label>

            <br />

            <asp:TextBox ID="Pr_Slot_Box"  runat="server" Height="15px" Width="100px"  Style="margin-left: auto;margin-top: 10px" OnTextChanged="Slot_Box_TextChanged"  ></asp:TextBox>
            <asp:TextBox ID="Pr_Port_Box" runat="server" Height="15px" Width="100px"  Style="margin-left: 20px" OnTextChanged="Port_Box_TextChanged" ></asp:TextBox>
            <asp:TextBox ID="Pr_Onu_Box" runat="server" Height="15px" Width="100px" Style="margin-left: 20px" OnTextChanged="OnuID_Box_TextChanged" ></asp:TextBox>

            <asp:Button ID="Button2" runat="server" OnClick="Button1_Click" Style="margin-left: 20px; margin-top: 0px;" Text="探測OnuID" Width="106px" />

            <br />

            <asp:Label ID="Pr_SN_label" runat="server" Style="margin-left: auto;margin-top:100px " Text="S/N："></asp:Label>
            <asp:Label ID="Pr_Des_label" runat="server" Style="margin-left: 80px" Text="Discription："></asp:Label>
            <asp:Label ID="Pr_UP_label" runat="server" Style="margin-left: 35px" Text="UpStream："></asp:Label>
            <asp:Label ID="Pr_Down_label" runat="server" Style="margin-left: 45px" Text="DownStream："></asp:Label>
            <asp:Label ID="Pr_Percen_label" runat="server" Style="margin-left: 25px" Text="Bw%："></asp:Label>
            <br />
            <asp:TextBox ID="Pr_SN_Box" runat="server" Height="15px" Style="margin-left: auto;margin-top: 10px" Width="100px" ></asp:TextBox>
            <asp:TextBox ID="Pr_Des_Box" runat="server" Height="15px" Style="margin-left: 20px" Width="100px" ></asp:TextBox>
            <asp:TextBox ID="Pr_UP_Box" runat="server" Height="15px" Style="margin-left: 20px" Width="100px" ></asp:TextBox>
            <asp:TextBox ID="Pr_Down_Box" runat="server" Height="15px" Style="margin-left: 20px" Width="100px" ></asp:TextBox>
            <asp:TextBox ID="Pr_Percen_Box" runat="server" Height="15px" Style="margin-left: 20px" Width="100px" >10</asp:TextBox>
            <br />
            <asp:Label ID="Pr_Svlan_label" runat="server" Style="margin-left: auto;margin-top:100px " Text="Svlan："></asp:Label>
            <asp:Label ID="Pr_Cvlan_label" runat="server" Style="margin-left: 70px" Text="Cvlan："></asp:Label>
            <asp:Label ID="Pr_Mode_label" runat="server" Style="margin-left: 70px" Text="Port Mode(幾n)："></asp:Label>
            <asp:Label ID="Pr_IP_label" runat="server" Style="margin-left: 5px" Text="Host2_IP/MASK："></asp:Label>
            <asp:Label ID="Pr_GW_label" runat="server"  Text="Host2_GW："></asp:Label>
            <br />
            <asp:TextBox ID="Pr_Svlan_Box" runat="server" Height="15px" Style="margin-left: auto;margin-top: 10px" Width="100px" ></asp:TextBox>
            <asp:TextBox ID="Pr_Cvlan_Box" runat="server" Height="15px" Style="margin-left: 20px" Width="100px" ></asp:TextBox>
            <asp:TextBox ID="Pr_Mode_Box" runat="server" Height="15px" Style="margin-left: 20px" Width="100px" ></asp:TextBox>
            <asp:TextBox ID="Pr_IP_Box" runat="server" Height="15px" Style="margin-left: 20px" Width="100px"></asp:TextBox>
            <asp:TextBox ID="Pr_GW_Box" runat="server" Height="15px" Style="margin-left: 20px" Width="100px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Pr_fixed_label" runat="server" Text="固定IP："></asp:Label>
            <br />

            <asp:TextBox ID="Pr_IP1_textBox" runat="server" Width="100px"></asp:TextBox>
            <asp:TextBox ID="Pr_IP2_textBox" runat="server" Width="100px"></asp:TextBox>
            <asp:TextBox ID="Pr_IP3_textBox" runat="server" Width="100px"></asp:TextBox>
            <asp:TextBox ID="Pr_IP4_textBox" runat="server" Width="100px"></asp:TextBox>
            <asp:TextBox ID="Pr_IP5_textBox" runat="server" Width="100px"></asp:TextBox>
            <asp:TextBox ID="Pr_IP6_textBox" runat="server" Width="100px"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="Pr_output_richTextBox" runat="server" Height="283px" Width="875px" TextMode="MultiLine">1.
選擇專案類型，只支援最新的Proflie 類型，可自定義，但輸出Proflie依然是新的。
2.
Port Mode 只需要輸入Nat Port。例如：我要4n0b 就是填入4，若0n4b就是 0 。
3.
MN 會自動換算OLT位置 的Svlan 及 Cvlan ，請選擇好相關資訊 
4.
由於缺少資料，只支援部分到7750，6860等還未支援，
但至少可以當ONT的Profile生成器用
5.
新增Onu ID 探測，按下後會自動找出 空的Onu ID 位置，就不用進設備看了!
如果入戶插上去ONT，也就是空的Profile 也算是空的位置，
這點確保現場入戶已經接上了

# 有部分的防呆，會讓你無法輸入英文或中文，只有數字可以輸入，別擔心不是壞掉!
# 但依然有些沒防呆的部分，本來就知道該填什麼，如果會錯，手開一樣會錯

</asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" Text="輸出Profile" OnClick="grow_button_Click" />
            <asp:Button ID="Pr_auto_button" runat="server" Text="一鍵開通" OnClick="auto_button_Click" Visible="False" />
            <br />
            <asp:Label ID="Pr_Passwd_label" runat="server" Text="開通密碼："></asp:Label>
            <br />
            <asp:TextBox ID="Pr_Passwd_Box" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
            <br />

        </asp:Panel>
    </form>
</body>
</html>
