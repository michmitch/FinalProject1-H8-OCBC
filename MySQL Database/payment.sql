-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 03, 2021 at 03:53 AM
-- Server version: 10.1.36-MariaDB
-- PHP Version: 7.2.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `finalproject1`
--

-- --------------------------------------------------------

--
-- Table structure for table `payment2`
--

CREATE TABLE `payment2` (
  `paymentDetailId` int(11) NOT NULL,
  `cardOwnerName` varchar(255) NOT NULL,
  `cardNumber` varchar(16) NOT NULL,
  `expirationDate` varchar(255) NOT NULL,
  `securityCode` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `payment2`
--

INSERT INTO `payment2` (`paymentDetailId`, `cardOwnerName`, `cardNumber`, `expirationDate`, `securityCode`) VALUES
(1, 'Ava Elliott', '1233211233211233', '01/22', '123'),
(2, 'Hendrix Jimi', '1231231231231231', '11/24', '111'),
(4, 'tes edit', '1234333333333333', '10/23', '333');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `payment2`
--
ALTER TABLE `payment2`
  ADD PRIMARY KEY (`paymentDetailId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `payment2`
--
ALTER TABLE `payment2`
  MODIFY `paymentDetailId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
