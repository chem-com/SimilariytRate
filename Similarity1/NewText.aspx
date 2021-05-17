<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NewText.aspx.cs" Inherits="Similarity1.NewText" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">

        <div class="card mb-4">
            <div class="card-header">
                Fill In The Relevant Fields
            </div>
            <div class="card-body">
                <div class="row">
                    <span>Header</span>
                </div>
                <div class="row">
                    <asp:TextBox ID="txtHeader" CssClass="w-100" TextMode="MultiLine" runat="server"></asp:TextBox>
                </div>
                <div class="row mt-4">
                    <span>Context</span>
                </div>
                <div class="row">
                    <asp:TextBox ID="txtContext" CssClass="w-100 col-form-label-lg" Rows="15" TextMode="MultiLine" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="card-footer">
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary btn-user btn-block" Text="Save" OnClick="btnSave_Click"/>
            </div>
        </div>

    </div>
</asp:Content>
