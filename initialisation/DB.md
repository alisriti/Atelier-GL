# Base de données
Dans cet atelier, nous allons utiliser SQL Server. Il est possible d'utiliser d'autres moteurs de base de données.
## Création de la base de données
Créez une base de données et nommez-la ATELIERGL ou utilisez le script suivant :
 ```sql
USE master;
GO
IF DB_ID (N'ATELIERGL') IS NOT NULL
DROP DATABASE ATELIERGL;
GO
CREATE DATABASE ATELIERGL;
GO
```

## Création des tables
### Table PRODUITS
 ```sql
USE ATELIERGL
CREATE TABLE [dbo].[PRODUITS](
	[Id] [int] NOT NULL,
	[Designation] [varchar](50) NULL,
	[Quantite] [int] NULL,
	[Prix] [int] NULL,
	CONSTRAINT [PK_PRODUITS] PRIMARY KEY CLUSTERED ([Id] ASC)
)
```
    
### Table ENTREES
 ```sql
USE ATELIERGL
CREATE TABLE [dbo].[ENTREES](
	[ProduitId] [int] NOT NULL,
	[Quantite] [int] NULL,
	CONSTRAINT [PK_ENTREES] PRIMARY KEY CLUSTERED ([ProduitId] ASC)
)
```
## Ajout de données au tables
 ```sql
USE ATELIERGL
DECLARE @Id int = 1
WHILE (@Id<=100)
BEGIN
  INSERT PRODUITS VALUES(@Id, CONCAT('Produit ',@Id), 0,0)
  INSERT ENTREES VALUES(@Id, FLOOR(RAND()*100)+1)
  SET @Id = @Id+1	
END
```
