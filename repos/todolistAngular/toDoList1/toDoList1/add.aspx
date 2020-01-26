<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add.aspx.cs" Inherits="toDoList1.add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add task</title>
</head>
<body><div style="font-size:50px;text-align:center;background-color:#FFF8DC">
            Add  task
        </div>
    <form id="form1" runat="server">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" InsertCommand="INSERT INTO todolist(Work, [From], [To]) VALUES (@Work, @From , @To )" SelectCommand="SELECT * FROM [todolist]">
            <InsertParameters>
                <asp:ControlParameter ControlID="work1" Name="Work" PropertyName="Text" />
                <asp:ControlParameter ControlID="from" Name="From" PropertyName="Text" />
                <asp:ControlParameter ControlID="to" Name="To" PropertyName="Text" />
            </InsertParameters>
        </asp:SqlDataSource>
        <br />
        <asp:Label ID="Label1" runat="server" Text="work"></asp:Label>:&nbsp;

        <asp:TextBox ID="work1" runat="server" required="required"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="from:" ></asp:Label>
        &nbsp;<asp:TextBox ID="from" runat="server" placeholder="date" required="required" style="display:inline;" TextMode="Date" Width="192px" ></asp:TextBox> 
        &nbsp; 
        <asp:Label ID="Label3" runat="server" Text="to:"></asp:Label>
        &nbsp;<asp:TextBox ID="to" runat="server" placeholder="date" required="required" style="display:inline;" TextMode="Date" Width="192px"></asp:TextBox> 
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" />
        <br />
    
    
    </form>
    
    
</body>
</html>
