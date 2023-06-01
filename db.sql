CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `TavolsagModel` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Megnevezes` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_TavolsagModel` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Versenyzok` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Rajtszam` int NOT NULL,
    `Nev` varchar(200) CHARACTER SET utf8mb4 NOT NULL,
    `SzuletesiDatum` datetime(6) NULL,
    `Neme` varchar(20) CHARACTER SET utf8mb4 NOT NULL,
    `TavolsagId` int NOT NULL,
    `Korosztaly` varchar(50) CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_Versenyzok` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Versenyzok_TavolsagModel_TavolsagId` FOREIGN KEY (`TavolsagId`) REFERENCES `TavolsagModel` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

INSERT INTO `TavolsagModel` (`Id`, `Megnevezes`)
VALUES (1, 'maraton');
INSERT INTO `TavolsagModel` (`Id`, `Megnevezes`)
VALUES (2, 'félmaraton');
INSERT INTO `TavolsagModel` (`Id`, `Megnevezes`)
VALUES (3, '10km');
INSERT INTO `TavolsagModel` (`Id`, `Megnevezes`)
VALUES (4, '5km');
INSERT INTO `TavolsagModel` (`Id`, `Megnevezes`)
VALUES (5, '2km');

INSERT INTO `Versenyzok` (`Id`, `Korosztaly`, `Neme`, `Nev`, `Rajtszam`, `SzuletesiDatum`, `TavolsagId`)
VALUES (1, 'senior', 'fiu', 'Sanyi', 1, NULL, 3);

CREATE UNIQUE INDEX `IX_TavolsagModel_Megnevezes` ON `TavolsagModel` (`Megnevezes`);

CREATE UNIQUE INDEX `IX_Versenyzok_Rajtszam` ON `Versenyzok` (`Rajtszam`);

CREATE INDEX `IX_Versenyzok_TavolsagId` ON `Versenyzok` (`TavolsagId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20230413102124_elso', '6.0.7');

COMMIT;

