-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 15 Bulan Mei 2024 pada 16.41
-- Versi server: 10.4.28-MariaDB
-- Versi PHP: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `pa`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `akun`
--

CREATE TABLE `akun` (
  `id` int(11) NOT NULL,
  `username` text NOT NULL,
  `password` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `akun`
--

INSERT INTO `akun` (`id`, `username`, `password`) VALUES
(1, 'qwe', 'qwe'),
(2, 'Agus', '123'),
(3, 'Nabil', '032');

-- --------------------------------------------------------

--
-- Struktur dari tabel `cart`
--

CREATE TABLE `cart` (
  `id_cart` int(11) NOT NULL,
  `id_akun` int(11) NOT NULL,
  `jenis_roti` text NOT NULL,
  `nama_roti` text NOT NULL,
  `jmlRoti` int(11) NOT NULL,
  `harga_roti` int(11) NOT NULL,
  `expired` date NOT NULL,
  `total_harga` int(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Struktur dari tabel `dbrasa`
--

CREATE TABLE `dbrasa` (
  `idrasa` text NOT NULL,
  `rasa` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `dbrasa`
--

INSERT INTO `dbrasa` (`idrasa`, `rasa`) VALUES
('1', 'Roti Daging'),
('2', 'Roti Tawar'),
('4', 'Roti Asin');

-- --------------------------------------------------------

--
-- Struktur dari tabel `dbroti`
--

CREATE TABLE `dbroti` (
  `id_roti` int(11) NOT NULL,
  `nama_roti` text NOT NULL,
  `harga_roti` int(11) NOT NULL,
  `stok_roti` int(11) NOT NULL,
  `jenis_roti` text NOT NULL,
  `tekstur_roti` text NOT NULL,
  `expired` date NOT NULL,
  `gambar` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `dbroti`
--

INSERT INTO `dbroti` (`id_roti`, `nama_roti`, `harga_roti`, `stok_roti`, `jenis_roti`, `tekstur_roti`, `expired`, `gambar`) VALUES
(1, 'Roti Hehe', 12000, 18, 'Roti Tawar', 'Lembut', '2024-06-01', 'Roti Hehe.jpg'),
(2, 'Roti Cokelat', 5000, 22, 'Roti Tawar', 'Lembut', '2024-06-08', 'Roti Cokelat.jpg'),
(3, 'RotSong', 6000, 50, 'Roti Tawar', 'Kering', '2024-05-29', 'RotSong.jpg'),
(4, 'Roti A', 6000, 44, 'Roti Daging', 'Renyah', '2024-05-24', 'Roti A.jpg'),
(5, 'Roti B', 4000, 70, 'Roti Asin', 'Kering', '2024-06-01', 'Roti B.jpg'),
(6, 'Roti C', 12412, 5, 'Roti Daging', 'Chewy', '2024-05-12', 'Roti C.jpg'),
(7, 'awnfja', 12415, 20, 'Roti Tawar', 'Renyah', '2024-06-08', 'awnfja.jpg'),
(8, 'qrwf', 42112, 10, 'Roti Daging', 'Chewy', '2024-06-01', 'qrwf.jpg'),
(9, 'QWRTGSV', 1256, 20, 'Roti Asin', 'Lembut', '2024-05-23', 'QWRTGSV.jpg'),
(10, 'zxczv', 7564, 10, 'Roti Tawar', 'Lembut', '2024-05-12', 'zxczv.jpg'),
(11, 'Roti Hehe', 12000, 18, 'Roti Tawar', 'Lembut', '2024-06-01', 'Roti Hehe.jpg'),
(12, 'qrwf', 42112, 10, 'Roti Daging', 'Chewy', '2024-06-01', 'qrwf.jpg'),
(13, 'RotSong', 6000, 50, 'Roti Tawar', 'Kering', '2024-05-29', 'RotSong.jpg'),
(14, 'Roti C', 12412, 5, 'Roti Daging', 'Chewy', '2024-05-12', 'Roti C.jpg');

-- --------------------------------------------------------

--
-- Struktur dari tabel `transaksi`
--

CREATE TABLE `transaksi` (
  `id_transaksi` int(11) NOT NULL,
  `id_akun` int(11) NOT NULL,
  `nama_pembeli` text NOT NULL,
  `tanggal_transaksi` datetime NOT NULL,
  `nama_roti` text NOT NULL,
  `jumlah` int(11) NOT NULL,
  `harga_satuan` int(11) NOT NULL,
  `total_harga` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `transaksi`
--

INSERT INTO `transaksi` (`id_transaksi`, `id_akun`, `nama_pembeli`, `tanggal_transaksi`, `nama_roti`, `jumlah`, `harga_satuan`, `total_harga`) VALUES
(3, 2, 'Agus', '2024-05-15 20:16:41', 'Roti Cokelat', 2, 5000, 10000),
(4, 2, 'Agus', '2024-05-15 20:16:41', 'Roti B', 5, 4000, 20000);

-- --------------------------------------------------------

--
-- Struktur dari tabel `transaksi_detail`
--

CREATE TABLE `transaksi_detail` (
  `id_transaksi` int(11) NOT NULL,
  `nama_roti` text NOT NULL,
  `jumlah` int(11) NOT NULL,
  `harga_satuan` int(11) NOT NULL,
  `total_harga` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `transaksi_detail`
--

INSERT INTO `transaksi_detail` (`id_transaksi`, `nama_roti`, `jumlah`, `harga_satuan`, `total_harga`) VALUES
(1, 'Roti Hehe', 2, 12000, 24000),
(2, 'Roti Cokelat', 2, 5000, 10000),
(2, 'Roti B', 5, 4000, 20000),
(2, 'Roti A', 6, 6000, 36000);

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `akun`
--
ALTER TABLE `akun`
  ADD PRIMARY KEY (`id`);

--
-- Indeks untuk tabel `cart`
--
ALTER TABLE `cart`
  ADD PRIMARY KEY (`id_cart`);

--
-- Indeks untuk tabel `dbrasa`
--
ALTER TABLE `dbrasa`
  ADD PRIMARY KEY (`idrasa`(11));

--
-- Indeks untuk tabel `dbroti`
--
ALTER TABLE `dbroti`
  ADD PRIMARY KEY (`id_roti`);

--
-- Indeks untuk tabel `transaksi`
--
ALTER TABLE `transaksi`
  ADD PRIMARY KEY (`id_transaksi`);

--
-- AUTO_INCREMENT untuk tabel yang dibuang
--

--
-- AUTO_INCREMENT untuk tabel `akun`
--
ALTER TABLE `akun`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT untuk tabel `cart`
--
ALTER TABLE `cart`
  MODIFY `id_cart` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT untuk tabel `transaksi`
--
ALTER TABLE `transaksi`
  MODIFY `id_transaksi` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
