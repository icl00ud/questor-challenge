-- ************************************************************
-- Antares - SQL Client
-- Version 0.7.14
-- 
-- https://antares-sql.app/
-- https://github.com/antares-sql/antares
-- 
-- Host: 127.0.0.1 (PostgreSQL 16.0)
-- Database: public
-- Generation time: 2023-10-15T15:28:00-03:00
-- ************************************************************


SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;





-- Dump of table Bancos
-- ------------------------------------------------------------

DROP TABLE IF EXISTS "public"."Bancos";


CREATE TABLE "public"."Bancos"(
   "Id" integer NOT NULL,
   "Name" text NOT NULL,
   "Code" text NOT NULL,
   "InterestPercentage" numeric NOT NULL
);

CREATE UNIQUE INDEX "PK_Bancos" ON public."Bancos" USING btree ("Id");


INSERT INTO "public"."Bancos" ("Id", "Name", "Code", "InterestPercentage") VALUES (3, 'Banco Santander', 'SAN', 0.5);
INSERT INTO "public"."Bancos" ("Id", "Name", "Code", "InterestPercentage") VALUES (4, 'Banco Bradesco', 'BRA', 0.35);
INSERT INTO "public"."Bancos" ("Id", "Name", "Code", "InterestPercentage") VALUES (5, 'Banco do Brasil', 'BR', 0.75);
INSERT INTO "public"."Bancos" ("Id", "Name", "Code", "InterestPercentage") VALUES (6, 'NuBank', 'NU', 0.12);




-- Dump of table Boletos
-- ------------------------------------------------------------

DROP TABLE IF EXISTS "public"."Boletos";


CREATE TABLE "public"."Boletos"(
   "Id" integer NOT NULL,
   "BankId" integer NOT NULL,
   "PayerName" text NOT NULL,
   "PayerIdentification" text NOT NULL,
   "BeneficiaryName" text NOT NULL,
   "BeneficiaryIdentification" text NOT NULL,
   "Value" double precision NOT NULL,
   "DueDate" timestamp with time zone NOT NULL,
   "Observation" text NOT NULL
);

CREATE UNIQUE INDEX "PK_Boletos" ON public."Boletos" USING btree ("Id");


INSERT INTO "public"."Boletos" ("Id", "BankId", "PayerName", "PayerIdentification", "BeneficiaryName", "BeneficiaryIdentification", "Value", "DueDate", "Observation") VALUES (22, 5, 'Israel', '068.609.309-77', 'Israel', '068.609.309-77', 1000, '2023-10-13 16:49:16.915000', 'Esse é um teste');
INSERT INTO "public"."Boletos" ("Id", "BankId", "PayerName", "PayerIdentification", "BeneficiaryName", "BeneficiaryIdentification", "Value", "DueDate", "Observation") VALUES (23, 3, 'string', '068.609.309-77', 'string', '068.609.309-77', 1000, '2023-10-13 21:00:54.454000', 'string');
INSERT INTO "public"."Boletos" ("Id", "BankId", "PayerName", "PayerIdentification", "BeneficiaryName", "BeneficiaryIdentification", "Value", "DueDate", "Observation") VALUES (24, 5, 'string', '068.609.309-77', 'string', '068.609.309-77', 1000, '2023-10-13 21:00:54.454000', 'string');
INSERT INTO "public"."Boletos" ("Id", "BankId", "PayerName", "PayerIdentification", "BeneficiaryName", "BeneficiaryIdentification", "Value", "DueDate", "Observation") VALUES (25, 6, 'string', '068.609.309-77', 'string', '068.609.309-77', 1000, '2023-10-13 21:00:54.454000', 'string');
INSERT INTO "public"."Boletos" ("Id", "BankId", "PayerName", "PayerIdentification", "BeneficiaryName", "BeneficiaryIdentification", "Value", "DueDate", "Observation") VALUES (26, 4, 'string', '068.609.309-77', 'string', '068.609.309-77', 1000, '2023-10-13 21:00:54.454000', 'string');




-- Dump of table __EFMigrationsHistory
-- ------------------------------------------------------------

DROP TABLE IF EXISTS "public"."__EFMigrationsHistory";


CREATE TABLE "public"."__EFMigrationsHistory"(
   "MigrationId" character varying(150) NOT NULL,
   "ProductVersion" character varying(32) NOT NULL
);

CREATE UNIQUE INDEX "PK___EFMigrationsHistory" ON public."__EFMigrationsHistory" USING btree ("MigrationId");


INSERT INTO "public"."__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES ('20231014070659_CriacaoDasTabelas', '7.0.12');




-- Dump of functions
-- ------------------------------------------------------------






-- Dump completed on 2023-10-15T15:28:01-03:00