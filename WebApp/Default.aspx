<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="scriptManager" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="updatePanel" runat="server">
            <ContentTemplate>
                <asp:GridView ID="gridView" runat="server">
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    
    </div>
    <asp:Button ID="buttonRefresh" runat="server" onclick="buttonRefresh_Click" 
        Text="Refresh" />
    </form>
</body>
</html>
