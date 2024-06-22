<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="UbahKurir.aspx.vb" Inherits="UbahKurir"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
            <div class="mb-3">
                <label class="form-label" for="TextBox2">Nama Kurir</label>
                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label" for="TextBox3">Umur</label>
                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label" for="TextBox4">No. Telp</label>
                <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label" for="TextBox5">Email</label>
                <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        <label for="DropDownList1">Jenis Kelamin</label>         
        <div class="input-group mb-3">
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Laki - Laki" Value="L"></asp:ListItem>
                    <asp:ListItem Text="Perempuan" Value="P"></asp:ListItem>
                </asp:DropDownList>
        </div>

        <label class="form-label" for="DropDownList1">Divisi</label>
        <div class="input-group mb-3">
                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Silahkan Pilih Divisi"></asp:ListItem>
                    <asp:ListItem Text="HEMAT" Value="HEMAT"></asp:ListItem>
                    <asp:ListItem Text="ONE DAY" Value="ONE DAY"></asp:ListItem>
                    <asp:ListItem Text="REGULER" Value="REGULER"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="mb-3">
                &nbsp;<asp:Button ID="ButtonUpdate" runat="server" Text="Update" CssClass="btn btn-primary"  OnClick="ButtonUpdate_Click" />
                &nbsp;<asp:Button ID="ButtonKembali" runat="server" Text="Kembali" CssClass="btn btn-danger" OnClick="ButtonKembali_Click" />

                </div>
        <div id="pesan" runat="server"></div>
    </form>
</asp:Content>
