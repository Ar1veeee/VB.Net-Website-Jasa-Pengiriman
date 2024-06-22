Imports System.Data.SqlClient

Partial Class ListKurir
    Inherits System.Web.UI.Page

    Dim cn As SqlConnection = Nothing
    Dim cnsql As String = ConfigurationManager.ConnectionStrings("cnsql").ConnectionString

    Protected Sub ButtonCari_Click(sender As Object, e As EventArgs) Handles ButtonCari.Click
        cn = New SqlConnection(cnsql)
        Try
            cn.Open()
            Dim sql As String = "SELECT * FROM PENGIRIMAN WHERE Paket = @Paket"
            Dim cmd As SqlCommand = New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@Paket", DropDownList1.SelectedValue)
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            Dim tmp As String = "<table class='table'>"
            tmp &= "<thead><tr>"
            tmp &= "<th>RESI</th>"
            tmp &= "<th>Nama Pengirim</th>"
            tmp &= "<th>Nama Penerima</th>"
            tmp &= "<th>Alamat Penerima</th>"
            tmp &= "<th>Nama Barang</th>"
            tmp &= "<th>Jarak</th>"
            tmp &= "<th>Berat</th>"
            tmp &= "<th>Harga</th>"
            tmp &= "<th>Paket</th>"
            tmp &= "<th>Edit</th>"
            tmp &= "<th>Delete</th>"
            tmp &= "</tr></thead><tbody>"

            If reader.HasRows Then
                While reader.Read()
                    tmp &= "<tr>"
                    tmp &= "<td>" & reader("RESI").ToString() & "</td>"
                    tmp &= "<td>" & reader("NM_PENGIRIM").ToString() & "</td>"
                    tmp &= "<td>" & reader("NM_PENERIMA").ToString() & "</td>"
                    tmp &= "<td>" & reader("ALAMAT").ToString() & "</td>"
                    tmp &= "<td>" & reader("NM_BARANG").ToString() & "</td>"
                    tmp &= "<td>" & reader("JARAK").ToString() & "</td>"
                    tmp &= "<td>" & reader("BERAT").ToString() & "</td>"
                    tmp &= "<td>" & reader("HARGA").ToString() & "</td>"
                    tmp &= "<td>" & reader("PAKET").ToString() & "</td>"
                    tmp &= "<td><a class='btn btn-warning' href='Editkurir.aspx?RESI=" & reader("RESI").ToString() & "'><i class='fa fa-pencil'></i></a></td>"
                    tmp &= "<td><a class='btn btn-danger' href='Deletekurir.aspx?RESI=" & reader("RESI").ToString() & "'><i class='fa fa-trash' style='color:white'></i></a></td>"
                    tmp &= "</tr>"
                End While
                tmp &= "</tbody></table>"
                datakurir.InnerHtml = tmp
            Else
                datakurir.InnerHtml = "<p>Data Barang kosong</p>"
            End If
        Catch ex As Exception
            Response.Write("ERROR: " & ex.Message)
        Finally
            cn.Close()
            cn = Nothing
        End Try
    End Sub

    Protected Sub Tambah_Click(sender As Object, e As EventArgs) Handles Tambah.Click
        Response.Redirect("Kurir.aspx?RESI", True)
    End Sub
End Class
