DROP TABLE IF EXISTS public.empresas;
DROP TABLE IF EXISTS public.responsaveis;
DROP TABLE IF EXISTS public.situacao_cadastral;


create table public.responsaveis (
	id serial not null,
    nome VARCHAR(255),
    cpf VARCHAR(14),
    email VARCHAR(255),
    telefone VARCHAR(15),
    CONSTRAINT responsaveis_pk PRIMARY KEY (id),
    CONSTRAINT responsaveis_unique UNIQUE (id)
);

create table public.situacao_cadastral(
	id INT,
	descricao VARCHAR(255),
	CONSTRAINT situacao_cadastral_pk PRIMARY KEY (id),
	CONSTRAINT situacao_cadastral_unique UNIQUE (id)
);

CREATE TABLE public.empresas (
	id serial4 NOT NULL,
	cnpj varchar(14) NOT NULL,
	razao_social varchar(255) NULL,
	data_abertura date NOT NULL,
	data_termino date NULL,
	responsavel_fiscal_id int4 NULL,
	situacao_cadastral_id int4 NOT NULL,
	cnae varchar(10) NULL,
	fap numeric(5, 2) NULL,
	rat numeric(5, 2) NULL,
	CONSTRAINT empresas_pk PRIMARY KEY (id),
	CONSTRAINT empresas_unique UNIQUE (cnpj),
	CONSTRAINT empresas_responsaveis_fk FOREIGN KEY (responsavel_fiscal_id) REFERENCES public.responsaveis(id),
	CONSTRAINT situacao_cadastral_fk FOREIGN KEY (situacao_cadastral_id) REFERENCES public.situacao_cadastral(id)
);


INSERT INTO public.situacao_cadastral (id,descricao) VALUES	 (1,'Ativo',);
INSERT INTO public.situacao_cadastral (id,descricao) VALUES	 (2,'Cancelado',);
INSERT INTO public.situacao_cadastral (id,descricao) VALUES	 (3,'Inativa',);
INSERT INTO public.situacao_cadastral (id,descricao) VALUES	 (4,'Extinta');
