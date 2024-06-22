<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Deletekurir.aspx.vb" Inherits="Deletekurir"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <form id="form1" runat="server" class="table-danger rounded container">
    <table class="table" >
        <thead >
        <tr >
            <th>
                <div>
                    <h2>Perhatian</h2>
                </div>
                <div>
            Apakah anda yakin akan menghapus data dengan Resi : 
        <asp:Label ID="LbResi" runat="server" Text="Label"></asp:Label>  &nbsp;? <br />
                </div>
            </th>
        </tr>
        </thead>
        <tbody>
        <td>
            <asp:Button ID="btYa" runat="server" Text="Ya" CssClass="btn btn-danger" />
        <asp:Button ID="btNo" runat="server" Text="Tidak" CssClass="btn btn-warning" />
        </td>
        </tbody>
    </table>
    </form>
</asp:Content>

