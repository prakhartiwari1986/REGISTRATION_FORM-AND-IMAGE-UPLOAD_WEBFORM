<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="STU1.aspx.cs" Inherits="STUTEST.STU1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>Name:</td>
                    <td><asp:TextBox ID="txtname" runat="server"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td>Status:</td>
                    <td><asp:RadioButtonList ID="rblstatus" runat="server" RepeatColumns="2" >
                        <asp:ListItem Text="Married" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Unmarried" Value="2"></asp:ListItem>
                     </asp:RadioButtonList></td>
                </tr>
                 <tr>
                    <td>Hobbies:</td>
                    <td><asp:CheckBoxList ID="cblhobbies" runat="server" RepeatColumns="5" >
                        <asp:ListItem Text="Cricket" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Dance" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Singing" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Movies" Value="4"></asp:ListItem>
                        <asp:ListItem Text="Reading" Value="5"></asp:ListItem>
                        </asp:CheckBoxList></td>
                </tr>
                
                <tr>
                    <td>Country:</td>
                    <td><asp:DropDownList ID="ddlcountry" runat="server" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged" AutoPostBack="true" >
                      
                        </asp:DropDownList></td>
                </tr>
                
                <tr>
                    <td>State:</td>
                    <td><asp:DropDownList ID="ddlstate" runat="server">

                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button ID="btninsert" runat="server" Text="Save" OnClick="btninsert_Click" /></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:GridView ID="gvshow" runat="server" OnRowCommand="gvshow_RowCommand" AutoGenerateColumns="false">
                        <Columns>
                              <asp:TemplateField HeaderText="Student Name">
                                <ItemTemplate>
                                    <%#Eval("stname") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Student Status">
                                <ItemTemplate>
                                    <%#Eval("ststatus").ToString()=="1" ? "Married" : "Unmarried" %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText="Student Hobbies">
                                <ItemTemplate>
                                    <%#Eval("sthobby") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Student country">
                                <ItemTemplate>
                                    <%#Eval("cname") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Student state">
                                <ItemTemplate>
                                    <%#Eval("sname") %> 
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField >
                                <ItemTemplate>
                                   <asp:Button ID="btndelete" runat="server"  Text="Remove" CommandName="A" CommandArgument='<%#Eval("stid") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                                <ItemTemplate>
                                   <asp:Button ID="btnedit" runat="server" Text="Improve" CommandName="B" CommandArgument='<%#Eval("stid") %>'  />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        </asp:GridView></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
