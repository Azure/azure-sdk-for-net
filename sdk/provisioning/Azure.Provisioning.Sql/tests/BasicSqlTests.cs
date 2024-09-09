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
                BicepParameter dbName =
                    new(nameof(dbName), typeof(string))
                    {
                        Value = "SampleDB",
                        Description = "The name of the SQL Database."
                    };
                BicepParameter location =
                    new(nameof(location), typeof(string))
                    {
                        Value = BicepFunction.GetResourceGroup().Location,
                        Description = "The SQL Server location."
                    };
                BicepParameter adminLogin =
                    new(nameof(adminLogin), typeof(string))
                    {
                        Description = "The administrator username of the SQL logical server."
                    };
                BicepParameter adminPass =
                    new(nameof(adminPass), typeof(string))
                    {
                        Description = "The administrator password of the SQL logical server.",
                        IsSecure = true
                    };

                SqlServer sql =
                    new(nameof(sql))
                    {
                        Location = location,
                        AdministratorLogin = adminLogin,
                        AdministratorLoginPassword = adminPass
                    };

                SqlDatabase db =
                    new(nameof(db))
                    {
                        Parent = sql,
                        Name = dbName,
                        Location = location,
                        Sku = new SqlSku { Name = "Standard", Tier = "Standard" }
                    };
            })
        .Compare(
            """
            @description('The name of the SQL Database.')
            param dbName string = 'SampleDB'

            @description('The SQL Server location.')
            param location string = resourceGroup().location

            @description('The administrator username of the SQL logical server.')
            param adminLogin string

            @secure()
            @description('The administrator password of the SQL logical server.')
            param adminPass string

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
