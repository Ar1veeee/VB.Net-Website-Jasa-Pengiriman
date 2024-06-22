Imports System.Data.SqlClient
Imports System.Data

Partial Class Transaksi
    Inherits System.Web.UI.Page

    Dim cn As SqlConnection = Nothing
    Dim cnsql As String = ConfigurationManager.ConnectionStrings("cnsql").ConnectionString
    Dim ListBarang As List(Of Barang)

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Session("ListBarang") = New List(Of Barang)()
        End If
        ListBarang = CType(Session("ListBarang"), List(Of Barang))
        TampilBr()
    End Sub

    Protected Sub ddPaket_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddPaket.SelectedIndexChanged
        ' Membersihkan ListBarang dan Session
        ListBarang.Clear()
        Session("ListBarang") = ListBarang

        ' Membersihkan tampilan tabel
        TampilBr()

        ' Memuat kembali kurir dan barang yang sesuai dengan paket baru
        LoadKurir()
        LoadBarang()
    End Sub

    Private Sub LoadKurir()
        cn = New SqlConnection(cnsql)
        Try
            cn.Open()
            Dim sql As String = "SELECT * FROM Kurir WHERE DIVISI=@Divisi"
            Dim cmd As SqlCommand = New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@Divisi", ddPaket.SelectedValue)
            Dim reader As SqlDataReader = cmd.ExecuteReader

            ddKurir.Items.Clear()
            ddKurir.Items.Add(New ListItem("Pilih Kurir", String.Empty))

            If reader.HasRows Then
                While reader.Read
                    ddKurir.Items.Add(New ListItem(reader.GetString(1), reader.GetString(6)))
                End While
            End If
            reader.Close()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub LoadBarang()
        cn = New SqlConnection(cnsql)
        Try
            cn.Open()
            Dim sql As String = "SELECT * FROM PENGIRIMAN WHERE PAKET=@Paket"
            Dim cmd As SqlCommand = New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@Paket", ddPaket.SelectedValue)
            Dim reader As SqlDataReader = cmd.ExecuteReader

            ddBarang.Items.Clear()
            ddBarang.Items.Add(New ListItem("Pilih Barang", String.Empty))

            If reader.HasRows Then
                While reader.Read
                    ddBarang.Items.Add(New ListItem(reader.GetString(5) & " " & reader.GetString(0) & " " & reader.GetString(4), reader.GetString(0)))
                End While
            End If
            reader.Close()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub TampilBr()
        tblAmbilBr.Rows.Clear()
        Dim BarisJudul As TableRow = New TableRow()
        BarisJudul.TableSection = TableRowSection.TableHeader

        Dim judul1 As TableCell = New TableCell()
        judul1.Text = "Resi"
        BarisJudul.Cells.Add(judul1)

        Dim judul2 As TableCell = New TableCell()
        judul2.Text = "Nama Barang"
        BarisJudul.Cells.Add(judul2)

        Dim judul3 As TableCell = New TableCell()
        judul3.Text = "Nama Penerima"
        BarisJudul.Cells.Add(judul3)

        Dim judul4 As TableCell = New TableCell()
        judul4.Text = "Alamat"
        BarisJudul.Cells.Add(judul4)

        Dim judul5 As TableCell = New TableCell()
        judul5.Text = "Berat"
        BarisJudul.Cells.Add(judul5)

        Dim judul6 As TableCell = New TableCell()
        judul6.Text = "Harga"
        BarisJudul.Cells.Add(judul6)

        tblAmbilBr.Rows.Add(BarisJudul)

        For Each barang In ListBarang
            Dim barisdata As TableRow = New TableRow()
            barisdata.TableSection = TableRowSection.TableBody

            Dim data1 As TableCell = New TableCell()
            data1.Text = barang.getResi()
            barisdata.Cells.Add(data1)

            Dim data2 As TableCell = New TableCell()
            data2.Text = barang.getNmbr()
            barisdata.Cells.Add(data2)

            Dim data3 As TableCell = New TableCell()
            data3.Text = barang.getNmpen()
            barisdata.Cells.Add(data3)

            Dim data4 As TableCell = New TableCell()
            data4.Text = barang.getAlamat()
            barisdata.Cells.Add(data4)

            Dim data5 As TableCell = New TableCell()
            data5.Text = barang.getBerat().ToString()
            barisdata.Cells.Add(data5)

            Dim data6 As TableCell = New TableCell()
            data6.Text = barang.getHarga().ToString()
            barisdata.Cells.Add(data6)

            tblAmbilBr.Rows.Add(barisdata)
        Next

        Dim tothrg As Integer = ListBarang.Sum(Function(b) b.getHarga())
        Dim barisfooter As TableRow = New TableRow()
        barisfooter.TableSection = TableRowSection.TableFooter

        Dim cf1 As TableCell = New TableCell()
        cf1.Text = ""
        barisfooter.Cells.Add(cf1)

        Dim cf2 As TableCell = New TableCell()
        cf2.Text = ""
        barisfooter.Cells.Add(cf2)

        Dim cf3 As TableCell = New TableCell()
        cf3.Text = ""
        barisfooter.Cells.Add(cf3)

        Dim cf4 As TableCell = New TableCell()
        cf4.Text = "Total Harga"
        barisfooter.Cells.Add(cf4)

        Dim cf5 As TableCell = New TableCell()
        cf5.Text = tothrg.ToString()
        barisfooter.Cells.Add(cf5)

        Dim cf6 As TableCell = New TableCell()
        cf6.Text = tothrg.ToString()
        barisfooter.Cells.Add(cf6)

        tblAmbilBr.Rows.Add(barisfooter)
    End Sub

    Protected Sub ddBarang_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddBarang.SelectedIndexChanged
        cn = New SqlConnection(cnsql)
        Try
            cn.Open()
            Dim sql As String = "SELECT * FROM PENGIRIMAN WHERE RESI=@Resi"
            Dim cmd As SqlCommand = New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@Resi", ddBarang.SelectedValue)
            Dim reader As SqlDataReader = cmd.ExecuteReader

            If reader.HasRows Then
                reader.Read()
                Dim br As Barang = New Barang()
                br.setBarang(reader.GetString(0), reader.GetString(4), reader.GetString(3), reader.GetString(2), reader.GetInt32(6), reader.GetInt32(7))

                ListBarang.Add(br)
                Session("ListBarang") = ListBarang
            End If
            reader.Close()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try

        TampilBr()
    End Sub

    Protected Sub ButtonKembali_Click(sender As Object, e As EventArgs) Handles ButtonKembali.Click
        Response.Redirect("ListKurir.aspx")
    End Sub
End Class
