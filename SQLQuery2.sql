CREATE TABLE TirelireRoles (
    RoleId INT PRIMARY KEY IDENTITY(1,1),
    RoleName NVARCHAR(50) NOT NULL
);

-- Insérer des données dans la table Roles
INSERT INTO TirelireRoles (RoleName) VALUES ('Client');
INSERT INTO TirelireRoles (RoleName) VALUES ('Admin');
INSERT INTO TirelireRoles (RoleName) VALUES ('Mod');
INSERT INTO TirelireRoles (RoleName) VALUES ('Assist');