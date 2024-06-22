Imports System.Data.SqlClient

Partial Class UbahKurir
    Inherits System.Web.UI.Page

    Private Property cn As SqlConnection
    Dim cnsql As String = ConfigurationManager.ConnectionStrings("cnsql").ConnectionString


    Protected Sub ButtonUpdate_Click(sender As Object, e As EventArgs) Handles ButtonUpdate.Click
        cn = New SqlConnection(cnsql)
        Try
            cn.Open()

            ' Perbaiki pernyataan UPDATE untuk menghindari update pada kolom identitas
            Dim sql As String = "UPDATE Kurir SET NM_KURIR=@NmKurir, UMUR=@Umur, NO_TELP=@Nomor, Email=@Email, J_KEL=@Kel, DIVISI=@Divisi WHERE NM_KURIR=@NmKurir"
            Dim cmd As SqlCommand = New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@NmKurir", TextBox2.Text)
            cmd.Parameters.AddWithValue("@Umur", TextBox3.Text)
            cmd.Parameters.AddWithValue("@Nomor", TextBox4.Text)
            cmd.Parameters.AddWithValue("@Email", TextBox5.Text)
            cmd.Parameters.AddWithValue("@Kel", DropDownList1.SelectedValue)
            cmd.Parameters.AddWithValue("@Divisi", DropDownList2.SelectedValue)

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
        End Try
    End Sub


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Not String.IsNullOrEmpty(Request.Params("NM_KURIR")) Then
                TextBox2.Text = Request.Params("NM_KURIR")
            Else
                Response.Redirect("TmbhKurir.aspx")
            End If

            cn = New SqlConnection(cnsql)
            Try
                cn.Open()
                Dim sql As String = "SELECT NM_KURIR, UMUR, NO_TELP, Email, J_KEL, DIVISI FROM Kurir WHERE NM_KURIR=@NmKurir"
                Dim cmd As SqlCommand = New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@NmKurir", TextBox2.Text)

                Dim reader As SqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    TextBox2.Text = reader.GetString(0)
                    TextBox3.Text = reader.GetInt32(1).ToString()
                    TextBox4.Text = reader.GetString(2)
                    TextBox5.Text = reader.GetString(3)
                    DropDownList1.SelectedValue = reader.GetString(4)
                    DropDownList2.SelectedValue = reader.GetString(5)
                Else
                    pesan.InnerHtml = "Record tidak ditemukan"
                End If
                reader.Close()
            Catch ex As Exception
                pesan.InnerHtml = "Error: " & ex.Message
            Finally
                cn.Close()
            End Try
        End If
    End Sub




    Protected Sub ButtonKembali_Click(sender As Object, e As EventArgs) Handles ButtonKembali.Click
        Response.Redirect("TmbhKurir.aspx")
    End Sub
End Class
