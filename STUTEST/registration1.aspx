<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registration1.aspx.cs" Inherits="STUTEST.registration1" %>

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
                    <td>Email:</td>
                    <td><asp:TextBox ID="txtemail" runat="server" ></asp:TextBox></td>

                </tr>
                  <tr>
                    <td>Passward:</td>
                    <td><asp:TextBox ID="txtpassward" runat="server" ></asp:TextBox></td>

                </tr>
                  <tr>
                    <td>Gender:</td>
                    <td><asp:RadioButtonList ID="rblgender" runat="server" RepeatColumns="3" >
                        <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Other" Value="3"></asp:ListItem>

                        </asp:RadioButtonList></td>

                </tr>
                  <tr>
                    <td>Upload Image</td>
                    <td><asp:FileUpload ID="fuimg" runat="server" /></td>

                </tr>
                  <tr>
                    <td></td>
                    <td><asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" /></td>
                   </tr>
                <tr>
                    <td></td>
                    <td><asp:GridView ID="gvreg" runat="server" AutoGenerateColumns="false" OnRowCommand="gvreg_RowCommand" >
                        <Columns>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <%#Eval("rname") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                          
                            <asp:TemplateField HeaderText="Email">
                                <ItemTemplate>
                                    <%#Eval("remail") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                           
                            <asp:TemplateField HeaderText="Password">
                                <ItemTemplate>
                                    <%#Eval("rpassward") %>
                                </ItemTemplate>
                               </asp:TemplateField>
                            <asp:TemplateField HeaderText="Gender">
                                <ItemTemplate>
                                    <%#Eval("rgender") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Image">
                                <ItemTemplate>
                                    <asp:Image ID="img1" runat="server" Width="70px" Height="60px" ImageUrl='<%#Eval("rimage","~/img/{0}") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField >
                                <ItemTemplate>
                                   <asp:Button ID="btndelete" runat="server"  Text="Delete" CommandName="A" CommandArgument='<%#Eval("rid") + ","+Eval("rimage")  %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                              <asp:TemplateField >
                                <ItemTemplate>
                                   <asp:Button ID="btnedit" runat="server"  Text="Edit" CommandName="B" CommandArgument='<%#Eval("rid")   %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                        </Columns>

                        </asp:GridView>

                    </td>
                   </tr>

            </table>
        </div>
    </form>
</body>
</html>
