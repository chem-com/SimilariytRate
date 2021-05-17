<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Similarity1.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">History</h6>
            </div>
            <div class="card-body">

                <div class="table-responsive">
                    <table class="table table-bordered" id="dataTable">
                        <asp:Repeater ID="rptList" runat="server">
                            <HeaderTemplate>

                                <thead>
                                    <tr>
                                        <th>Title</th>
                                        <th>Context</th>
                                        <th>Similarty Rate</th>
                                    </tr>
                                </thead>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tbody>

                                    <tr>
                                        <td><%#Eval("TITLE").ToString().Length>30?Eval("TITLE").ToString().Substring(0,30):Eval("TITLE").ToString() %></td>
                                        <td>
                                            <%#Eval("CONTEXT").ToString().Length>80?Eval("CONTEXT").ToString().Substring(0,80):Eval("CONTEXT").ToString()%>
                                            ....   
                                            <a href="Context.aspx?ID=<%#Eval("ID") %>">READ MORE</a>
                                        </td>
                                        <td>% <%# Convert.ToDouble(Eval("SIMILARTYRATE"))*100 %></td>
                                    </tr>
                                </tbody>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
