Imports System.Data.SqlClient

Partial Class Deletekurir
    Inherits System.Web.UI.Page

    Dim cn As SqlConnection = Nothing
    Dim cnStr As String = ConfigurationManager.ConnectionStrings("cnsql").ConnectionString

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        LbResi.Text = Request.Params("RESI")
    End Sub

    Protected Sub btYa_Click(sender As Object, e As EventArgs) Handles btYa.Click
        cn = New SqlConnection(cnStr)
        Try
            cn.Open()
            Dim sql As String = "DELETE FROM PENGIRIMAN Where RESI='" & LbResi.Text & "'"

            Dim cmd As SqlCommand = New SqlCommand(sql, cn)
            Dim jmlrec As Integer = cmd.ExecuteNonQuery
            Response.Redirect("ListKurir.aspx")
        Catch ex As Exception
            Response.Write("Ada kesalahan koneksi ke database")
        Finally
            cn.Close()
        End Try
    End Sub

    Protected Sub btNo_Click(sender As Object, e As EventArgs) Handles btNo.Click
        Response.Redirect("ListKurir.aspx")
    End Sub
End Class
