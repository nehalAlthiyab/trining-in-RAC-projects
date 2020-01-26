<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="doList.aspx.cs" Inherits="toDoList1.doList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> do list</title>
    <style type="text/css">
        .newStyle1 {
            border-color: #000000;
        }
    </style>
</head>
<body>
    <div style="font-size:50px;text-align:center;background-color:#FFF8DC">


            to do list
            <br />


        </div>
    <form id="form1" runat="server">
        <br />
        
        <div >

            <asp:Button ID="add" runat="server" Text="Add task" OnClick="add_Click"  />
            <br />
            <br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [todolist] WHERE [Id] = @Id" InsertCommand="INSERT INTO [todolist] ([Work], [From], [To]) VALUES (@Work, @From, @To)" SelectCommand="SELECT * FROM [todolist]" UpdateCommand="UPDATE [todolist] SET [Work] = @Work, [From] = @From, [To] = @To WHERE [Id] = @Id">
                <DeleteParameters>
                    <asp:Parameter Name="Id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Work" Type="String" />
                    <asp:Parameter DbType="Date" Name="From" />
                    <asp:Parameter DbType="Date" Name="To" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Work" Type="String" />
                    <asp:Parameter DbType="Date" Name="From" />
                    <asp:Parameter DbType="Date" Name="To" />
                    <asp:Parameter Name="Id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <asp:ListView ID="ListView1" runat="server" DataKeyNames="Id" DataSourceID="SqlDataSource1" >
                <AlternatingItemTemplate>
                    <li style="background-color: #FFF8DC;">Id:
                        <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                        <br />
                        Work:
                        <asp:Label ID="WorkLabel" runat="server" Text='<%# Eval("Work") %>' />
                        <br />
                        From:
                        <asp:Label ID="FromLabel" runat="server" Text='<%# Eval("From") %>' />
                        <br />
                        To:
                        <asp:Label ID="ToLabel" runat="server" Text='<%# Eval("To") %>' />
                        <br />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete"  OnClientClick="return confirm('Are you certain you want to delete?');"/>
                    </li>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <li style="background-color: #008A8C;color: #FFFFFF;">Id:
                        <asp:Label ID="IdLabel1" runat="server" Text='<%# Eval("Id") %>' />
                        <br />
                        Work:
                        <asp:TextBox ID="WorkTextBox" runat="server" Text='<%# Bind("Work") %>' />
                        <br />
                        From:
                        <asp:TextBox ID="FromTextBox" runat="server" Text='<%# Bind("From") %>' />
                        <br />
                        To:
                        <asp:TextBox ID="ToTextBox" runat="server" Text='<%# Bind("To") %>' />
                        <br />
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                    </li>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    No data was returned.
                </EmptyDataTemplate>
                <InsertItemTemplate>
                    <li style="">Work:
                        <asp:TextBox ID="WorkTextBox" runat="server" Text='<%# Bind("Work") %>' />
                        <br />From:
                        <asp:TextBox ID="FromTextBox" runat="server" Text='<%# Bind("From") %>' />
                        <br />To:
                        <asp:TextBox ID="ToTextBox" runat="server" Text='<%# Bind("To") %>' />
                        <br />
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                    </li>
                </InsertItemTemplate>
                <ItemSeparatorTemplate>
<br />
                </ItemSeparatorTemplate>
                <ItemTemplate>
                    <li style="background-color: #DCDCDC;color: #000000;">Id:
                        <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                        <br />
                        Work:
                        <asp:Label ID="WorkLabel" runat="server" Text='<%# Eval("Work") %>' />
                        <br />
                        From:
                        <asp:Label ID="FromLabel" runat="server" Text='<%# Eval("From") %>' />
                        <br />
                        To:
                        <asp:Label ID="ToLabel" runat="server" Text='<%# Eval("To") %>' />
                        <br />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you certain you want to delete?');"/>
                    </li>
                </ItemTemplate>
                <LayoutTemplate>
                    <ul id="itemPlaceholderContainer" runat="server" style="font-family: Verdana, Arial, Helvetica, sans-serif;">
                        <li runat="server" id="itemPlaceholder" />
                    </ul>
                    <div style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                    </div>
                </LayoutTemplate>
                <SelectedItemTemplate>
                    <li style="background-color: #008A8C;font-weight: bold;color: #FFFFFF;">Id:
                        <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                        <br />
                        Work:
                        <asp:Label ID="WorkLabel" runat="server" Text='<%# Eval("Work") %>' />
                        <br />
                        From:
                        <asp:Label ID="FromLabel" runat="server" Text='<%# Eval("From") %>' />
                        <br />
                        To:
                        <asp:Label ID="ToLabel" runat="server" Text='<%# Eval("To") %>' />
                        <br />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete " OnClientClick="return confirm('Are you certain you want to delete?');"/>
                    </li>
                </SelectedItemTemplate>
            </asp:ListView>
            <br />
        </div>
    </form>
</body>
</html>
