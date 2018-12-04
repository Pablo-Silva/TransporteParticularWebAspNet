#INSERT CLIENTE

INSERT INTO `transporteparticulartable`.`cliente_table`
(`NOME_CLIENTE`,
`DATA_NASCIMENTO`,
`SEXO`,
`CPF`,
`NUMERO_CELULAR`,
`EMAIL`,
`SENHA`,
`DATA_CADASTRO`,
`TIPO_DEFICIENCIA`)
VALUES
('Maria Garcia', '1950-05-20', 'F', '321.654.987-18', '4189654235', 'maria_garcia@gmail.com', '123456', now(),
'Visual');
SELECT * FROM transporteparticulartable.cliente_table;

#INSERT VEICULO

INSERT INTO `transporteparticulartable`.`veiculo_table`
(`MODELO_VEICULO`,
`MARCA_VEICULO`)
VALUES
('Uno', 'Fiat');

INSERT INTO `transporteparticulartable`.`veiculo_table`
(`MODELO_VEICULO`,
`MARCA_VEICULO`)
VALUES
('Palio', 'Fiat');

#INSERT DETALHES_VEICULO

INSERT INTO `transporteparticulartable`.`detalhes_veiculos_table`
(`PLACA_VEICULO`,
`COR_VEICULO`,
`ACENTOS_VEICULO`)
VALUES
('GKB-9859', 'Preto', 4);

INSERT INTO `transporteparticulartable`.`detalhes_veiculos_table`
(`PLACA_VEICULO`,
`COR_VEICULO`,
`ACENTOS_VEICULO`)
VALUES
('NEE-5026', 'Cinza', 5);


#INSERT MOTORISTA

INSERT INTO `transporteparticulartable`.`motorista_table`
(`ID_VEICULO`,
`ID_DETALHES_VEICULOS`,
`NOME_MOTORISTA`,
`DATA_NASCIMENTO`,
`SEXO`,
`CPF`,
`NUMERO_CELULAR`,
`EMAIL`,
`SENHA`,
`DATA_CADASTRO`,
`STATUS_MOTORISTA`,
`CARTEIRA_MOTORISTA`)
VALUES
(1 , 1,'Pedro da Silva', '1991-10-10', 'M', '123.456.789-00', '4199998888', 'p.silva@gmail.com', '123456', now(), 'A', '14699953857');

#INSERT VIAGEM

INSERT INTO `transporteparticulartable`.`viagem_table`
(`ID_MOTORISTA`,
`ID_CLIENTE`,
`ENDERECO_SAIDA`,
`ENDERECO_CHEGADA`,
`DATA_INICIO`,
`DATA_FIM`)
VALUES
(1, 1, 'Rua A, 200', 'Rua B, 350', now(), now());

INSERT INTO `transporteparticulartable`.`viagem_table`
(`ID_MOTORISTA`,
`ID_CLIENTE`,
`ENDERECO_SAIDA`,
`ENDERECO_CHEGADA`,
`DATA_INICIO`,
`DATA_FIM`)
VALUES
(1, 1, 'Rua B, 800', 'Rua C, 1050', now(), now());

#INSERT CARTAO

INSERT INTO `transporteparticulartable`.`cartoes_table`
(`ID_CLIENTE`,
`TIPO_CARTAO`,
`BANDEIRA_CARTAO`,
`NUMERO_CARTAO`)
VALUES
(1, 'Creito', 'Visa', 123456);

INSERT INTO `transporteparticulartable`.`cartoes_table`
(`ID_CLIENTE`,
`TIPO_CARTAO`,
`BANDEIRA_CARTAO`,
`NUMERO_CARTAO`)
VALUES
(1, 'Creito', 'Master Card', 654321);

#INSERT DINHEIRO

INSERT INTO `transporteparticulartable`.`dinheiro_table`
(`ID_CLIENTE`,
`TIPO_DINHEIRO`)
VALUES
(1, 'Real');









