CREATE TABLE Customer (
	id_customer INT PRIMARY KEY IDENTITY(1,1),
	customer_name NVARCHAR (50) NOT NULL,
	customer_firstname NVARCHAR(50) NOT NULL,
	customer_birthdate DATETIME NOT NULL,
	customer_password NVARCHAR(100) NOT NULL,
);

CREATE TABLE Product (
	id_product INT PRIMARY KEY IDENTITY(1,1),
	product_name NVARCHAR(50) NOT NULL,
	product_description NVARCHAR(1000) NOT NULL,
	product_height NVARCHAR(20) NOT NULL,
	product_width NVARCHAR(20) NOT NULL,
	product_weight NVARCHAR(20) NOT NULL,
	product_lenght NVARCHAR(20) NOT NULL,
	product_color NVARCHAR(50) NOT NULL,
	product_capacity NVARCHAR(50) NOT NULL,
	product_maker NVARCHAR(50) NOT NULL,
	product_img IMAGE NOT NULL,
	product_price FLOAT NOT NULL,
);

CREATE TABLE Shopping_cart(
cart_id INT PRIMARY KEY IDENTITY(1,1),
cart_date DATETIME NOT NULL,
cart_product_added INT NOT NULL,
cart_product_cancelled INT NOT NULL,
cart_details INT NOT NULL,
cart_shipping INT NOT NULL,
cart_price INT NULL,

);

CREATE TABLE TirelireRoles (
    RoleId INT PRIMARY KEY IDENTITY(1,1),
    RoleName NVARCHAR(50) NOT NULL
);

-- Insérer des données dans la table Roles
INSERT INTO TirelireRoles (RoleName) VALUES ('Client');
INSERT INTO TirelireRoles (RoleName) VALUES ('Admin');
INSERT INTO TirelireRoles (RoleName) VALUES ('Mod');
INSERT INTO TirelireRoles (RoleName) VALUES ('Assist');
