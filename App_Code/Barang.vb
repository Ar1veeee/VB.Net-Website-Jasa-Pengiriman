Imports Microsoft.VisualBasic

Public Class Barang
    Private _RESI As String
    Private _NMBR As String
    Private _NMPEN As String
    Private _ALAMAT As String
    Private _BERAT As Integer
    Private _HARGA As Integer

    Public Sub New()
        _RESI = ""
        _NMBR = ""
        _NMPEN = ""
        _ALAMAT = ""
        _BERAT = 0
        _HARGA = 0
    End Sub

    Public Sub setBarang(ByVal RESI As String, ByVal NMBR As String, ByVal NMPEN As String, ByVal ALAMAT As String, ByVal BERAT As Integer, ByVal HARGA As Integer)
        _RESI = RESI
        _NMBR = NMBR
        _NMPEN = NMPEN
        _ALAMAT = ALAMAT
        _BERAT = BERAT
        _HARGA = HARGA
    End Sub

    Public Function getResi() As String
        Return _RESI
    End Function

    Public Function getNmbr() As String
        Return _NMBR
    End Function

    Public Function getNmpen() As String
        Return _NMPEN
    End Function

    Public Function getAlamat() As String
        Return _ALAMAT
    End Function

    Public Function getBerat() As Integer
        Return _BERAT
    End Function

    Public Function getHarga() As Integer
        Return _HARGA
    End Function
End Class
