﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleTrafficManagement.Migrations
{
    public partial class AltergetAllCompanies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var dropGetAllCompaniesFunctionSql = @"
            DROP FUNCTION IF EXISTS public.getallcompanies;
            ";
            
            var createGetAllCompaniesFunctionSql = @"
            CREATE OR REPLACE FUNCTION public.getallcompanies()
            RETURNS TABLE(
                ""CompaniesId"" int,
                ""Name"" text,
                ""TradeName"" text,
                ""TaxNumber"" text,
                ""CEP"" text, 
                ""Street"" text,
                ""PropertyNumber"" text, 
                ""District"" text, 
                ""City"" text,
                ""State"" text,
                ""Country"" text,
                ""AdressComplement"" text,
                ""PhoneNumber"" text,
                ""Email"" text,
                ""Observations"" text,
                ""CompanyStatus"" int,
                ""CompanyInformationId"" int
            ) 
            LANGUAGE 'sql'
            COST 100
            VOLATILE PARALLEL UNSAFE
            ROWS 1000
            AS $BODY$
                SELECT 
                    cs.""CompaniesId"",
                    cs.""Name"",
                    cs.""TradeName"",
                    cs.""TaxNumber"",
                    ci.""CEP"",
                    ci.""Street"",
                    ci.""PropertyNumber"",
                    ci.""District"",
                    ci.""City"",
                    ci.""State"",
                    ci.""Country"",
                    ci.""AdressComplement"",
                    ci.""PhoneNumber"",
                    ci.""Email"",
                    ci.""Observations"",
                    ci.""CompanyStatus"",
                    ci.""CompanyInformationId""
                FROM ""Companies"" AS cs
                INNER JOIN ""CompanyInformation"" AS ci
                ON cs.""CompanyInformationId"" = ci.""CompanyInformationId""
            $BODY$;
            ";

            var dropGetCompanyByNameFunctionSql = @"
            DROP FUNCTION IF EXISTS public.getcompanybyname(text);
            ";

            var createGetCompanyByNameFunctionSql = @"
            CREATE OR REPLACE FUNCTION public.getcompanybyname(
	            ""paramName"" text)
            RETURNS TABLE(
                ""CompaniesId"" int,
                ""Name"" text,
                ""TradeName"" text,
                ""TaxNumber"" text,
                ""CEP"" text,
                ""Street"" text,
                ""PropertyNumber"" text,
                ""District"" text,
                ""City"" text,
                ""State"" text,
                ""Country"" text,
                ""AdressComplement"" text,
                ""PhoneNumber"" text,
                ""Email"" text,
                ""Observations"" text,
                ""CompanyStatus"" int,
                ""CompanyInformationId"" int
            ) 
            LANGUAGE 'sql'
            COST 100
            VOLATILE PARALLEL UNSAFE
            ROWS 1000
            AS $BODY$
                SELECT 
                    cs.""CompaniesId"",
                    cs.""Name"",
                    cs.""TradeName"",
                    cs.""TaxNumber"",
                    ci.""CEP"",
                    ci.""Street"",
                    ci.""PropertyNumber"",
                    ci.""District"",
                    ci.""City"",
                    ci.""State"",
                    ci.""Country"",
                    ci.""AdressComplement"",
                    ci.""PhoneNumber"",
                    ci.""Email"",
                    ci.""Observations"",
                    ci.""CompanyStatus"",
                    ci.""CompanyInformationId""
                FROM ""Companies"" AS cs
                INNER JOIN ""CompanyInformation"" AS ci
                ON cs.""CompanyInformationId"" = ci.""CompanyInformationId""
                WHERE cs.""Name"" ILIKE ""paramName"" || '%';
            $BODY$;
            ";
            migrationBuilder.Sql(dropGetAllCompaniesFunctionSql);
            migrationBuilder.Sql(createGetAllCompaniesFunctionSql);
            migrationBuilder.Sql(dropGetCompanyByNameFunctionSql);
            migrationBuilder.Sql(createGetCompanyByNameFunctionSql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var dropGetAllCompaniesFunctionSql = @"
            DROP FUNCTION IF EXISTS public.getallcompanies;
            ";

            var dropGetCompanyByNameFunctionSql = @"
            DROP FUNCTION IF EXISTS public.getcompanybyname(text);
            ";

            migrationBuilder.Sql(dropGetAllCompaniesFunctionSql);
            migrationBuilder.Sql(dropGetCompanyByNameFunctionSql);

        }
    }
}
