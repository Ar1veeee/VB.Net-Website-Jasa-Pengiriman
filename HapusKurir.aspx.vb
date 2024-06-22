Imports System.Data.SqlClient

Partial Class HapusKurir
    Inherits System.Web.UI.Page

    Dim cn As SqlConnection = Nothing
    Dim cnStr As String = ConfigurationManager.ConnectionStrings("cnsql").ConnectionString

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim nmKurir As String = Request.Params("NM_KURIR")
            LbNama.Text = nmKurir '

            Dim idKurir As String = Request.Params("ID_KURIR")
            LbId.Text = idKurir
        End If
    End Sub


    Protected Sub btYa_Click(sender As Object, e As EventArgs) Handles btYa.Click
        cn = New SqlConnection(cnStr)
        Try
            cn.Open()
            ' Gunakan parameterized query untuk mencegah SQL Injection
            Dim sql As String = "DELETE FROM Kurir WHERE ID_KURIR=@Id"
            Dim cmd As SqlCommand = New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@Id", LbId.Text)


            Dim jmlrec As Integer = cmd.ExecuteNonQuery()
            Response.Redirect("TmbhKurir.aspx")
        Catch ex As Exception
            Response.Write("Ada kesalahan koneksi ke database")
        Finally
            cn.Close()
        End Try
    End Sub

    Protected Sub btNo_Click(sender As Object, e As EventArgs) Handles btNo.Click
        Response.Redirect("TmbhKurir.aspx")
    End Sub
End Class
