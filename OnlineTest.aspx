<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="OnlineTest.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>在线考试</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
       <h2>在线考试</h2>
            <p>说明：在文本框中输入答案，点击“提交答案”按钮可看结果，同时自动生成新题目。</p>
       <hr />
            题目：<asp:Label ID="lblTest" runat="server" Font-Bold="True" ForeColor="#000099"></asp:Label>
        <br />
        <br />
                答案：<asp:TextBox ID="txtUserInput" runat="server"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" Text="提交答案" 
            onclick="btnSubmit_Click" />
       <hr />
       
    </div>
    <p>
        <asp:Label ID="lblPrompt" runat="server" Font-Bold="True"></asp:Label>
    </p>
    <p>
        <asp:Label ID="lblStatistic" runat="server" Font-Bold="True" 
            ForeColor="#000099"></asp:Label>
    </p>
    </form>
    </body>
</html>
