Imports System.Data.SqlClient
Imports System.Data

Partial Class TmbhKurir
    Inherits System.Web.UI.Page

    Dim cn As SqlConnection = Nothing
    Dim cnsql As String = ConfigurationManager.ConnectionStrings("cnsql").ConnectionString

    Protected Sub ButtonTambah_Click(sender As Object, e As EventArgs) Handles ButtonTambah.Click
        cn = New SqlConnection(cnsql)
        Try
            cn.Open()
            Dim sql As String = "INSERT INTO Kurir(NM_KURIR,UMUR,NO_TELP,Email,J_KEL,DIVISI) VALUES('" & TextBox1.Text & "'," & TextBox2.Text & ",'" & TextBox3.Text & "','" & TextBox4.Text & "','" & DropDownList1.Text & "','" & DropDownList2.Text & "')"
            Dim cmd As SqlCommand = New SqlCommand(sql, cn)
            If cmd.ExecuteNonQuery > 0 Then
                pesan.InnerHtml = "<div class='alert alert-success'>Berhasil</div>"
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                DropDownList1.Text = ""
                DropDownList2.Text = ""
            Else
                pesan.InnerHtml = "<div class='alert alert-danger'>GAGAL SIMPAN</div>"
            End If
        Catch ex As Exception
            Response.Write("")
        Finally
            cn.Close()
            cn = Nothing
        End Try
    End Sub

    Protected Sub ButtonBatal_Click(sender As Object, e As EventArgs) Handles ButtonBatal.Click
        Response.Redirect("Home.aspx")

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindGridView()
        End If
    End Sub

    Private Sub BindGridView()
        Dim dt As New DataTable()
        Using con As New SqlConnection(cnsql)
            Dim sql As String = "SELECT NM_KURIR, UMUR, NO_TELP, Email, J_KEL, DIVISI FROM Kurir"
            Using da As New SqlDataAdapter(sql, con)
                da.Fill(dt)
            End Using
        End Using

        GridViewKurir.DataSource = dt
        GridViewKurir.DataBind()
    End Sub

End Class
