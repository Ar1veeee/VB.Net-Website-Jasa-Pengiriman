<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Home.aspx.vb" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <style>
    body {
      background-image: url('images/bg2.jpg');
      background-size: cover; 
      background-position: center; /* Menempatkan gambar di tengah */
      background-repeat: no-repeat; /* Tidak mengulangi gambar */
      height: 100%;
      margin: 0;
      padding: 0;
    }

    .putih {
        color: white;
    }
  </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  <!-- Main Content -->
  <div class="container my-4">
    <h1 class="text-center putih">Welcome Back Admin</h1>
    <h4 class="text-center putih">Sistem Informasi JNE EXPRESS</h4>

    <div class="row">
      <div class="col-lg-4 col-md-6 mb-4">
        <div class="card h-100">
          <img src="images/Paket.jpeg" class="card-img-top" alt="...">
          <div class="card-body">
            <h5 class="card-title">Paket</h5>
            <p class="card-text">Informasi Mengenai Pemasukan Paket.</p>
            <a href="ListKurir.aspx" class="btn btn-primary">Lihat Detail</a>
          </div>
        </div>
      </div>
      <div class="col-lg-4 col-md-6 mb-4">
        <div class="card h-100">
          <img src="images/kurir.jpeg" class="card-img-top" alt="..." style="height: 43%;">
          <div class="card-body">
            <h5 class="card-title">Kurir</h5>
            <p class="card-text">Informasi Mengenai Data Kurir & Input Data Kurir.</p>
            <a href="TmbhKurir.aspx" class="btn btn-primary">Lihat Detail</a>
          </div>
        </div>
      </div>
      <div class="col-lg-4 col-md-6 mb-4">
        <div class="card h-100">
          <img src="images/transaksi.jpeg" class="card-img-top" alt="..." style="height: 43%;">
          <div class="card-body">
            <h5 class="card-title">Transaksi</h5>
            <p class="card-text">Informasi mengenai dosen pengajar.</p>
            <a href="Transaksi.aspx" class="btn btn-primary">Lihat Detail</a>
          </div>
        </div>
      </div>
    </div>
  </div>

  <!-- Footer -->
  
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</asp:Content>