Imports System.Data.SqlClient
Imports System.Globalization

Partial Class Editkurir
    Inherits System.Web.UI.Page

    Dim cn As SqlConnection = Nothing
    Dim cnsql As String = ConfigurationManager.ConnectionStrings("cnsql").ConnectionString

    Protected Sub ButtonUpdate_Click(sender As Object, e As EventArgs) Handles ButtonUpdate.Click
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


            Dim sql As String = "UPDATE PENGIRIMAN SET RESI=@Resi, NM_PENGIRIM=@NmPengirim, ALAMAT=@Alamat, NM_PENERIMA=@NmPenerima, NM_BARANG=@NmBarang, PAKET=@Paket, BERAT=@Berat, HARGA=@Harga, JARAK=@Jarak WHERE RESI=@Resi"
            Dim cmd As SqlCommand = New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@Resi", TextBox1.Text)
            cmd.Parameters.AddWithValue("@NmPengirim", TextBox2.Text)
            cmd.Parameters.AddWithValue("@Alamat", TextBox4.Text)
            cmd.Parameters.AddWithValue("@NmPenerima", TextBox3.Text)
            cmd.Parameters.AddWithValue("@NmBarang", TextBox5.Text)
            cmd.Parameters.AddWithValue("@Paket", DropDownList1.Text)
            cmd.Parameters.AddWithValue("@Berat", berat)
            cmd.Parameters.AddWithValue("@Harga", totalharga)
            cmd.Parameters.AddWithValue("@Jarak", jarak)

            Dim jmlrec As Integer = cmd.ExecuteNonQuery()
            If jmlrec > 0 Then
                pesan.InnerHtml = "<div class='alert alert-success'>Berhasil</div>"
            Else
                pesan.InnerHtml = "<div class='alert alert-danger'>GAGAL SIMPAN</div>"
            End If
        Catch ex As Exception
            pesan.InnerHtml = "Error: " & ex.Message
        Finally
            cn.Close()
            cn = Nothing
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Not String.IsNullOrEmpty(Request.Params("RESI")) Then
                TextBox1.Text = Request.Params("RESI")
            Else
                Response.Redirect("ListKurir.aspx")
            End If

            cn = New SqlConnection(cnsql)
            Try
                cn.Open()
                Dim sql As String = "SELECT RESI, NM_PENGIRIM, ALAMAT, NM_PENERIMA, NM_BARANG, PAKET, HARGA, BERAT, JARAK FROM PENGIRIMAN WHERE RESI=@Resi"
                Dim cmd As SqlCommand = New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@Resi", TextBox1.Text)

                Dim reader As SqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    TextBox2.Text = reader.GetString(1)
                    TextBox3.Text = reader.GetString(3)
                    TextBox4.Text = reader.GetString(2)
                    TextBox5.Text = reader.GetString(4)
                    TextBox6.Text = reader.GetInt32(8).ToString()
                    TextBox7.Text = reader.GetInt32(7).ToString()
                    TextBox8.Text = reader.GetInt32(6).ToString()
                    DropDownList1.Text = reader.GetString(5)
                Else
                    pesan.InnerHtml = "Record tidak ditemukan"
                End If
                reader.Close()
            Catch ex As Exception
                pesan.InnerHtml = "Error: " & ex.Message
            Finally
                cn.Close()
                cn = Nothing
            End Try
        End If
    End Sub

    Protected Sub ButtonKembali_Click(sender As Object, e As EventArgs) Handles ButtonKembali.Click
        Response.Redirect("ListKurir.aspx")
    End Sub
End Class
