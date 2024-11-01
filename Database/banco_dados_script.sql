CREATE DATABASE `tarefas_db`;
USE `tarefas_db`;

CREATE TABLE `tarefas` (
  `id_tar` int(11) NOT NULL AUTO_INCREMENT,
  `descricao_tar` text NOT NULL,
  `data_tar` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `feito_tar` tinyint(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id_tar`)
);



INSERT INTO `tarefas` (`descricao_tar`) VALUES ("Estudo de API - PART 1"), ("Estudo de API - PART 2"), ("Estudo de API - PART 3");
UPDATE tarefas SET feito_tar = TRUE WHERE id_tar = 1;

ALTER TABLE tarefas ADD column data_feito_tar datetime;

SELECT * FROM tarefas_db.tarefas;

CREATE TABLE `categorias`(
`id_cat` INT(11) NOT NULL PRIMARY KEY AUTO_INCREMENT,
`nome_cat` TEXT NOT NULL
);

SELECT * FROM tarefas_db.categorias;