<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Editkurir.aspx.vb" Inherits="Editkurir"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">

    function HitungHarga() {
        var jarak = document.getElementById('<%= TextBox6.ClientID %>').value.replace(',', '.');
        var hargaperKm = 10000;
        var berat = document.getElementById('<%= TextBox7.ClientID %>').value.replace(',', '.');
     var hargaPerKg = 0;

     switch (document.getElementById('<%= DropDownList1.ClientID %>').value) {
        case "HEMAT":
            hargaPerKg = 10000;
            break;
        case "ONE DAY":
            hargaPerKg = 20000;
            break;
        case "REGULER":
            hargaPerKg = 15000;
            break;
        default:
            hargaPerKg = 0; // Default jika tidak ada pilihan paket yang cocok
            break;
    }

    var hargajarak = parseFloat(jarak) * hargaperKm;
    var hargaberat = parseFloat(berat) * hargaPerKg;
    var totalHarga = hargajarak + hargaberat;

    if (!isNaN(totalHarga)) {
        document.getElementById('<%= TextBox8.ClientID %>').value = totalHarga.toFixed(0);
    } else {
        document.getElementById('<%= TextBox8.ClientID %>').value = "";
    }
}
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
        <div class="container">
            <div class="mb-3">
                <label class="form-label" for="TextBox1">Resi</label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label" for="TextBox2">Nama Pengirim</label>
                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label" for="TextBox3">Nama Penerima</label>
                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
                <div class="mb-3">
                    <label class="form-label" for="TextBox4">Alamat</label>
                    <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="mb-3">
                <label class="form-label" for="TextBox5">Nama Barang</label>
                <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
            <label class="form-label" for="TextBox6">Jarak <a style="color:gray">*Satuan : Km <br> | (10.000 / Km) |</a></label>
            <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control" oninput="HitungHarga()"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label" for="TextBox7">Berat <a style="color:gray">*Satuan : Kg</a></label>
            <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control" oninput="HitungHarga()"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label" for="TextBox8">Harga <br> <a style="color:gray">| (*HEMAT = 10.000/kg) | </a><a style="color:gray">(*ONE DAY = 20.000/kg) | </a><a style="color:gray">(*Reguler = 15.000/kg) |</a></label>
            &nbsp;<asp:TextBox ID="TextBox8" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
        </div>
                <label class="form-label" for="DropDownList1">Paket</label>
            <div class="input-group mb-3">
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                    <asp:ListItem Text="HEMAT" Value="HEMAT"></asp:ListItem>
                    <asp:ListItem Text="ONE DAY" Value="ONE DAY"></asp:ListItem>
                    <asp:ListItem Text="REGULER" Value="REGULER"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Button ID="ButtonUpdate" runat="server" CssClass="btn btn-primary" Text="Simpan" />
                <asp:Button ID="ButtonKembali" runat="server" CssClass="btn btn-warning" Text="Batal"/>
            </div>
        </div>
        <div id="pesan" runat="server"></div>
    </form>
</asp:Content>
