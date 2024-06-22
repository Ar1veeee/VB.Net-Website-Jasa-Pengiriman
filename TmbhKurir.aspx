<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="TmbhKurir.aspx.vb" Inherits="TmbhKurir"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
            <div class="mb-3">
                <label class="form-label" for="TextBox1">Nama Kurir</label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label" for="TextBox2">Umur</label>
                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label" for="TextBox3">No. Telp</label>
                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label" for="TextBox4">Email</label>
                <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control"></asp:TextBox>
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
                &nbsp;<asp:Button ID="ButtonTambah" runat="server" Text="Tambah" CssClass="btn btn-primary"  OnClick="ButtonTambah_Click" />
                &nbsp;<asp:Button ID="ButtonBatal" runat="server" Text="Batal" CssClass="btn btn-danger" OnClick="ButtonBatal_Click" />

                </div>
            <div>

            <asp:GridView ID="GridViewKurir" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
    <Columns>
    <asp:BoundField DataField="NM_KURIR" HeaderText="Nama Kurir" />
    <asp:BoundField DataField="UMUR" HeaderText="Umur" />
    <asp:BoundField DataField="NO_TELP" HeaderText="No. Telp" />
    <asp:BoundField DataField="Email" HeaderText="Email" />
    <asp:BoundField DataField="J_KEL" HeaderText="Jenis Kelamin" />
    <asp:BoundField DataField="DIVISI" HeaderText="Divisi" />
    <asp:TemplateField HeaderText="Edit">
        <ItemTemplate>
            <a class="btn btn-warning" href='UbahKurir.aspx?NM_KURIR=<%# Eval("NM_KURIR")%>'>
                <i class="fa fa-pencil"></i>
            </a>
        </ItemTemplate>
    </asp:TemplateField><asp:TemplateField HeaderText="Hapus">
        <ItemTemplate>
            <a class="btn btn-danger" href='HapusKurir.aspx?NM_KURIR=<%# Eval("NM_KURIR")%>'>
                <i class="fa fa-trash"></i>
            </a>
        </ItemTemplate>
    </asp:TemplateField>
</Columns>

</asp:GridView>
            </div>
        <div id="pesan" runat="server"></div>
    </form>
</asp:Content>
