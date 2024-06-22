<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ListKurir.aspx.vb" Inherits="ListKurir" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Status Paket</h2>
    <form id="form1" runat="server">
        <div>
        <label for="DropDownList1">Pilih Kategori Paket :</label>
        </div>
    <div class="input-group">
        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
            <asp:ListItem Text="HEMAT" Value="HEMAT"></asp:ListItem>
            <asp:ListItem Text="ONE DAY" Value="ONE DAY"></asp:ListItem>
            <asp:ListItem Text="REGULER" Value="REGULER"></asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;
        <asp:Button ID="ButtonCari" runat="server" Text="Cari" CssClass="btn btn-primary"/>
        &nbsp;&nbsp;
        <asp:Button ID="Tambah" runat="server" Text="Tambah" CssClass="btn btn-primary" OnClick="Tambah_CLick"/>

    </div>            
        <div id="datakurir" runat="server" style="margin-top:40px"></div>             
    </form>
    
</asp:Content>

    
