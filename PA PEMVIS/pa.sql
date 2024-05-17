-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 17, 2024 at 08:45 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

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
-- Table structure for table `akun`
--

CREATE TABLE `akun` (
  `id` int(11) NOT NULL,
  `username` text NOT NULL,
  `password` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `akun`
--

INSERT INTO `akun` (`id`, `username`, `password`) VALUES
(1, 'qwe', 'qwe'),
(2, 'asd', 'asd');

-- --------------------------------------------------------

--
-- Table structure for table `cart`
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

--
-- Dumping data for table `cart`
--

INSERT INTO `cart` (`id_cart`, `id_akun`, `jenis_roti`, `nama_roti`, `jmlRoti`, `harga_roti`, `expired`, `total_harga`) VALUES
(3, 1, 'Roti Manis', 'Roti Muffin', 2, 20000, '2024-06-08', 40000);

-- --------------------------------------------------------

--
-- Table structure for table `dbrasa`
--

CREATE TABLE `dbrasa` (
  `idrasa` text NOT NULL,
  `rasa` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `dbrasa`
--

INSERT INTO `dbrasa` (`idrasa`, `rasa`) VALUES
('1', 'Roti Tawar'),
('2', 'Roti Manis');

-- --------------------------------------------------------

--
-- Table structure for table `dbroti`
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
-- Dumping data for table `dbroti`
--

INSERT INTO `dbroti` (`id_roti`, `nama_roti`, `harga_roti`, `stok_roti`, `jenis_roti`, `tekstur_roti`, `expired`, `gambar`) VALUES
(1, 'Roti Sobek', 15000, 100, 'Roti Tawar', 'Lembut', '2024-06-08', 'Roti Sobek.jpg'),
(2, 'Roti Muffin', 20000, 95, 'Roti Manis', 'Lembut', '2024-06-08', 'Roti Muffin.jpg');

-- --------------------------------------------------------

--
-- Table structure for table `transaksi`
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
-- Dumping data for table `transaksi`
--

INSERT INTO `transaksi` (`id_transaksi`, `id_akun`, `nama_pembeli`, `tanggal_transaksi`, `nama_roti`, `jumlah`, `harga_satuan`, `total_harga`) VALUES
(1, 2, 'asd', '2024-05-18 01:51:56', 'Roti Muffin', 5, 20000, 100000);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `akun`
--
ALTER TABLE `akun`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `cart`
--
ALTER TABLE `cart`
  ADD PRIMARY KEY (`id_cart`);

--
-- Indexes for table `dbrasa`
--
ALTER TABLE `dbrasa`
  ADD PRIMARY KEY (`idrasa`(11));

--
-- Indexes for table `dbroti`
--
ALTER TABLE `dbroti`
  ADD PRIMARY KEY (`id_roti`);

--
-- Indexes for table `transaksi`
--
ALTER TABLE `transaksi`
  ADD PRIMARY KEY (`id_transaksi`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `akun`
--
ALTER TABLE `akun`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `cart`
--
ALTER TABLE `cart`
  MODIFY `id_cart` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `transaksi`
--
ALTER TABLE `transaksi`
  MODIFY `id_transaksi` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
