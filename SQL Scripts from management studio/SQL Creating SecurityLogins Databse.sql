USE [master]
GO

/****** Object:  Database [SecurityLogins]    Script Date: 07/12/2023 23:21:01 ******/
CREATE DATABASE [SecurityLogins]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SecurityLogins', FILENAME = N'/var/opt/mssql/data/SecurityLogins.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SecurityLogins_log', FILENAME = N'/var/opt/mssql/data/SecurityLogins_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SecurityLogins].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [SecurityLogins] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [SecurityLogins] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [SecurityLogins] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [SecurityLogins] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [SecurityLogins] SET ARITHABORT OFF 
GO

ALTER DATABASE [SecurityLogins] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [SecurityLogins] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [SecurityLogins] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [SecurityLogins] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [SecurityLogins] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [SecurityLogins] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [SecurityLogins] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [SecurityLogins] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [SecurityLogins] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [SecurityLogins] SET  ENABLE_BROKER 
GO

ALTER DATABASE [SecurityLogins] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [SecurityLogins] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [SecurityLogins] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [SecurityLogins] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [SecurityLogins] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [SecurityLogins] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [SecurityLogins] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [SecurityLogins] SET RECOVERY FULL 
GO

ALTER DATABASE [SecurityLogins] SET  MULTI_USER 
GO

ALTER DATABASE [SecurityLogins] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [SecurityLogins] SET DB_CHAINING OFF 
GO

ALTER DATABASE [SecurityLogins] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [SecurityLogins] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [SecurityLogins] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [SecurityLogins] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [SecurityLogins] SET QUERY_STORE = ON
GO

ALTER DATABASE [SecurityLogins] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO

ALTER DATABASE [SecurityLogins] SET  READ_WRITE 
GO


