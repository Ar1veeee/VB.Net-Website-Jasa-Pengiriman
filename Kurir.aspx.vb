Imports System.Data.SqlClient
Imports System.Globalization

Partial Class Kurir
    Inherits System.Web.UI.Page

    Dim cn As SqlConnection = Nothing
    Dim cnsql As String = ConfigurationManager.ConnectionStrings("cnsql").ConnectionString

    Protected Sub ButtonTambah_Click(sender As Object, e As EventArgs) Handles ButtonTambah.Click
        cn = New SqlConnection(cnsql)
        Try
            cn.Open()

            Dim berat As Decimal
            If Not Decimal.TryParse(TextBox7.Text, NumberStyles.Number, CultureInfo.InvariantCulture, berat) Then
                pesan.InnerHtml = ""
                Return
            End If

            Dim jarak As Decimal
            If Not Decimal.TryParse(TextBox6.Text, NumberStyles.Number, CultureInfo.InvariantCulture, jarak) Then
                pesan.InnerHtml = ""
                Return
            End If


            Dim hargaPerKm = 10000

            Dim hargaPerKg As Decimal = 0
            Select Case DropDownList1.SelectedValue
                Case "HEMAT"
                    hargaPerKg = 10000
                Case "ONE DAY"
                    hargaPerKg = 20000
                Case "REGULER"
                    hargaPerKg = 15000
                Case Else
                    pesan.InnerHtml = "Pilih paket pengiriman terlebih dahulu."
                    Return
            End Select

            Dim hargajarak As Integer = Convert.ToInt32(Math.Round(jarak * hargaPerKm, 0))
            Dim hargaberat As Integer = Convert.ToInt32(Math.Round(berat * hargaPerKg, 0))

            Dim totalharga As Integer = Convert.ToInt32(Math.Round(hargajarak + hargaberat, 0))

            TextBox8.Text = totalharga.ToString()

            Dim sql As String = "INSERT INTO PENGIRIMAN(RESI, NM_PENGIRIM, NM_PENERIMA, ALAMAT, NM_BARANG, PAKET, BERAT, HARGA, JARAK) " & _
                                "VALUES(@Resi, @NmPengirim, @NmPenerima, @Alamat, @NmBarang, @Paket, @Berat, @Harga, @Jarak)"
            Dim cmd As SqlCommand = New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@Resi", TextBox1.Text)
            cmd.Parameters.AddWithValue("@NmPengirim", TextBox2.Text)
            cmd.Parameters.AddWithValue("@NmPenerima", TextBox3.Text)
            cmd.Parameters.AddWithValue("@Alamat", TextBox4.Text)
            cmd.Parameters.AddWithValue("@NmBarang", TextBox5.Text)
            cmd.Parameters.AddWithValue("@Paket", DropDownList1.SelectedValue)
            cmd.Parameters.AddWithValue("@Jarak", jarak)
            cmd.Parameters.AddWithValue("@Berat", berat)
            cmd.Parameters.AddWithValue("@Harga", totalharga)

            If cmd.ExecuteNonQuery() > 0 Then
                Response.Write("<div class='alert alert-success'>Berhasil</div>")
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                TextBox6.Text = ""
                TextBox7.Text = ""
                TextBox8.Text = ""
            Else
                Response.Write("<div class='alert alert-danger'>GAGAL SIMPAN</div>")
            End If

        Catch ex As Exception
            pesan.InnerHtml = "Error: " & ex.Message
        Finally
            cn.Close()
            cn = Nothing
        End Try
    End Sub


    Protected Sub ButtonBatal_Click(sender As Object, e As EventArgs) Handles ButtonBatal.Click
        Response.Redirect("ListKurir.aspx?RESI", True)
    End Sub
End Class
