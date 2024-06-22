<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Transaksi.aspx.vb" Inherits="Transaksi"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
        <h3>Transaksi</h3>
        <div>
                <label class="form-label" for="TextBox3">ID Transaksi</label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
           <label for="DropDownList1">Paket</label>
        <div class="input-group mb-3">
            <asp:DropDownList ID="ddPaket" runat="server" CssClass="form-control" AutoPostBack="True">
                <asp:ListItem Text="Silahkan Pilih Paket"></asp:ListItem>
                <asp:ListItem Text="HEMAT" Value="HEMAT"></asp:ListItem>
                <asp:ListItem Text="ONE DAY" Value="ONE DAY"></asp:ListItem>
                <asp:ListItem Text="REGULER" Value="REGULER"></asp:ListItem>
            </asp:DropDownList>
        </div>
            
            <div class="mb-3">
                <label class="form-label" for="TextBox2">Tanggal Dikirim</label>
                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
            <label for="DropDownList2">Kurir</label>
            <div class="input-group mb-3">
                <asp:DropDownList ID="ddKurir" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Pilih Kurir" Value=""></asp:ListItem>
                </asp:DropDownList>
            </div>
        <h3>Daftar Paket Yang Tersedia&nbsp;&nbsp;&nbsp; </h3>

            <label for="DropDownList3">Barang</label>
            <div class="input-group mb-3">
                <asp:DropDownList ID="ddBarang" runat="server" CssClass="form-control" AutoPostBack="true">
                    <asp:ListItem Text="Pilih Barang" Value=""></asp:ListItem>
                </asp:DropDownList>
            </div>

            <asp:Table ID="tblAmbilBr" runat="server" CssClass="table table-hover" >
                <asp:TableRow runat="server" TableSection="TableHeader">
                    <asp:TableCell runat="server">Resi</asp:TableCell>
                    <asp:TableCell runat="server">Nama Barang</asp:TableCell>
                    <asp:TableCell runat="server">Nama Penerima</asp:TableCell>
                    <asp:TableCell runat="server">Alamat</asp:TableCell>
                    <asp:TableCell runat="server">Berat</asp:TableCell>
                    <asp:TableCell runat="server">Harga</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">001</asp:TableCell>
                    <asp:TableCell runat="server">HP</asp:TableCell>
                    <asp:TableCell runat="server">Ahmad</asp:TableCell>
                    <asp:TableCell runat="server">Gurawan</asp:TableCell>
                    <asp:TableCell runat="server">0</asp:TableCell>
                    <asp:TableCell runat="server">10000</asp:TableCell>
                </asp:TableRow>
            </asp:Table>

            <div class="mb-3">
                &nbsp;<asp:Button ID="ButtonBaru" runat="server" Text="Baru" CssClass="btn btn-success"  />
                &nbsp;<asp:Button ID="ButtonSimpan" runat="server" Text="Simpan" CssClass="btn btn-primary"  />
                &nbsp;<asp:Button ID="ButtonKembali" runat="server" CssClass="btn btn-danger" Text="Batal"/>
            </div>
    </form>
</asp:Content>
