// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Sql.Tests;

public class BasicSqlTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true /**/)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.sql/sql-database/main.bicep")]
    public async Task CreateSimpleSqlServerAndDatabase()
    {
        await using Trycep test = CreateBicepTest();
        await test.Define(
            ctx =>
            {
                Infrastructure infra = new();

                ProvisioningParameter dbName =
                    new(nameof(dbName), typeof(string))
                    {
                        Value = "SampleDB",
                        Description = "The name of the SQL Database."
                    };
                infra.Add(dbName);

                ProvisioningParameter adminLogin =
                    new(nameof(adminLogin), typeof(string))
                    {
                        Description = "The administrator username of the SQL logical server."
                    };
                infra.Add(adminLogin);

                ProvisioningParameter adminPass =
                    new(nameof(adminPass), typeof(string))
                    {
                        Description = "The administrator password of the SQL logical server.",
                        IsSecure = true
                    };
                infra.Add(adminPass);

                SqlServer sql =
                    new(nameof(sql))
                    {
                        AdministratorLogin = adminLogin,
                        AdministratorLoginPassword = adminPass
                    };
                infra.Add(sql);

                SqlDatabase db =
                    new(nameof(db))
                    {
                        Parent = sql,
                        Name = dbName,
                        Sku = new SqlSku { Name = "Standard", Tier = "Standard" }
                    };
                infra.Add(db);

                return infra;
            })
        .Compare(
            """
            @description('The name of the SQL Database.')
            param dbName string = 'SampleDB'

            @description('The administrator username of the SQL logical server.')
            param adminLogin string

            @secure()
            @description('The administrator password of the SQL logical server.')
            param adminPass string

            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource sql 'Microsoft.Sql/servers@2021-11-01' = {
              name: take('sql-${uniqueString(resourceGroup().id)}', 63)
              location: location
              properties: {
                administratorLogin: adminLogin
                administratorLoginPassword: adminPass
              }
            }

            resource db 'Microsoft.Sql/servers/databases@2021-11-01' = {
              name: dbName
              location: location
              sku: {
                name: 'Standard'
                tier: 'Standard'
              }
              parent: sql
            }
            """)
        .Lint()
        .ValidateAndDeployAsync();
    }
}
