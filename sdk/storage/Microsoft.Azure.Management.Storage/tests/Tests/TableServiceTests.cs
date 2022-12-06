// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using ResourceGroups.Tests;
using Storage.Tests.Helpers;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Management.KeyVault;
using Microsoft.Azure.Test.HttpRecorder;
using System;

namespace Storage.Tests
{
    public class TableServiceTests
    {
        // create Table
        // delete Table
        [Fact]
        public void TableCreateDeleteUpdateListTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgName = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = TestUtilities.GenerateName("sto");
                var parameters = new StorageAccountCreateParameters
                {
                    Location = "eastus2euap",
                    Kind = Kind.StorageV2,
                    Sku = new Sku { Name = SkuName.StandardLRS }
                };
                var account = storageMgmtClient.StorageAccounts.Create(rgName, accountName, parameters);

                // implement case
                try
                {
                    // prepare SignedIdentifier
                    List<TableSignedIdentifier> tableSi = new List<TableSignedIdentifier>();
                    tableSi.Add(new TableSignedIdentifier("PTIzNDU2Nzg5MDEyMzQ1Njc4OTAxMjM0NTY3ODklMTI", accessPolicy: new TableAccessPolicy("raud", null, DateTime.Now.AddDays(2))));
                    tableSi.Add(new TableSignedIdentifier("MTIzNDU2Nzg5MDEyMzQ1Njc4OTAxMjM0NTY3ODkwMTI", accessPolicy: new TableAccessPolicy("ra", DateTime.Now, DateTime.Now.AddDays(7))));

                    //create Table
                    string tableName = TestUtilities.GenerateName("table1");
                    Table table= storageMgmtClient.Table.Create(rgName, accountName, tableName, tableSi);
                    Assert.Equal(tableName, table.TableName);
                    Assert.Equal(2, table.SignedIdentifiers.Count);

                    table = storageMgmtClient.Table.Get(rgName, accountName, tableName);
                    Assert.Equal(tableName, table.TableName);

                    string tableName2 = TestUtilities.GenerateName("table2");
                    Table table2 = storageMgmtClient.Table.Create(rgName, accountName, tableName2);
                    Assert.Equal(tableName2, table2.TableName);
                    Assert.Equal(2, table.SignedIdentifiers.Count);

                    table2 = storageMgmtClient.Table.Get(rgName, accountName, tableName2);
                    Assert.Equal(tableName2, table2.TableName);

                    // Update Table: Update still not update any thing, will add update parameter when add things to update
                    tableSi.Add(new TableSignedIdentifier("eC1tcy1yZXF1ZXN0LWlk", accessPolicy: new TableAccessPolicy("r", DateTime.Now.AddHours(1), DateTime.Now.AddDays(70))));
                    table = storageMgmtClient.Table.Update(rgName, accountName, tableName, tableSi);
                    Assert.Equal(tableName, table.TableName);
                    Assert.Equal(3, table.SignedIdentifiers.Count);

                    //list Table
                    IPage<Table> tables = storageMgmtClient.Table.List(rgName, accountName);
                    Assert.Equal(2, tables.Count());

                    //Delete Table
                    storageMgmtClient.Table.Delete(rgName, accountName, tableName);
                    tables = storageMgmtClient.Table.List(rgName, accountName);
                    Assert.Equal(1, tables.Count());

                    storageMgmtClient.Table.Delete(rgName, accountName, tableName2);
                    tables = storageMgmtClient.Table.List(rgName, accountName);
                    Assert.Equal(0, tables.Count());
                }
                finally
                {
                    // clean up
                    storageMgmtClient.StorageAccounts.Delete(rgName, accountName);
                    resourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        // Get/Set Table Service Properties
        [Fact]
        public void TableServiceCorsTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgName = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = TestUtilities.GenerateName("sto");
                var parameters = new StorageAccountCreateParameters
                {
                    Location = "eastus2euap",
                    Kind = Kind.StorageV2,
                    Sku = new Sku { Name = SkuName.StandardLRS }
                };
                var account = storageMgmtClient.StorageAccounts.Create(rgName, accountName, parameters);

                // implement case
                try
                {
                    TableServiceProperties properties1 = storageMgmtClient.TableServices.GetServiceProperties(rgName, accountName);
                    Assert.Equal(0, properties1.Cors.CorsRulesProperty.Count);

                    CorsRules cors = new CorsRules();
                    cors.CorsRulesProperty = new List<CorsRule>();
                    cors.CorsRulesProperty.Add(new CorsRule()
                    {
                        AllowedHeaders = new string[] { "x-ms-meta-abc", "x-ms-meta-data*", "x-ms-meta-target*" },
                        AllowedMethods = new string[] { "GET", "HEAD", "POST", "OPTIONS", "MERGE", "PUT" },
                        AllowedOrigins = new string[] { "http://www.contoso.com", "http://www.fabrikam.com" },
                        ExposedHeaders = new string[] { "x-ms-meta-*" },
                        MaxAgeInSeconds = 100
                    });
                    cors.CorsRulesProperty.Add(new CorsRule()
                    {
                        AllowedHeaders = new string[] { "*" },
                        AllowedMethods = new string[] { "GET" },
                        AllowedOrigins = new string[] { "*" },
                        ExposedHeaders = new string[] { "*" },
                        MaxAgeInSeconds = 2
                    });
                    cors.CorsRulesProperty.Add(new CorsRule()
                    {
                        AllowedHeaders = new string[] { "x-ms-meta-12345675754564*" },
                        AllowedMethods = new string[] { "GET", "PUT", "CONNECT" },
                        AllowedOrigins = new string[] { "http://www.abc23.com", "https://www.fabrikam.com/*" },
                        ExposedHeaders = new string[] { "x-ms-meta-abc", "x-ms-meta-data*", "x -ms-meta-target*" },
                        MaxAgeInSeconds = 2000
                    });

                    TableServiceProperties properties3 = storageMgmtClient.TableServices.SetServiceProperties(rgName, accountName, cors);

                    //Validate CORS Rules
                    if (HttpMockServer.Mode == HttpRecorderMode.Record)
                    {
                        // Need wait for cors rules setting take effect when record case
                        System.Threading.Thread.Sleep(30000);
                    }
                    Assert.Equal(cors.CorsRulesProperty.Count, properties3.Cors.CorsRulesProperty.Count);
                    for (int i = 0; i < cors.CorsRulesProperty.Count; i++)
                    {
                        CorsRule putRule = cors.CorsRulesProperty[i];
                        CorsRule getRule = properties3.Cors.CorsRulesProperty[i];

                        Assert.Equal(putRule.AllowedHeaders, getRule.AllowedHeaders);
                        Assert.Equal(putRule.AllowedMethods, getRule.AllowedMethods);
                        Assert.Equal(putRule.AllowedOrigins, getRule.AllowedOrigins);
                        Assert.Equal(putRule.ExposedHeaders, getRule.ExposedHeaders);
                        Assert.Equal(putRule.MaxAgeInSeconds, getRule.MaxAgeInSeconds);
                    }

                    TableServiceProperties properties4 = storageMgmtClient.TableServices.GetServiceProperties(rgName, accountName);

                    //Validate CORS Rules
                    Assert.Equal(cors.CorsRulesProperty.Count, properties4.Cors.CorsRulesProperty.Count);
                    for (int i = 0; i < cors.CorsRulesProperty.Count; i++)
                    {
                        CorsRule putRule = cors.CorsRulesProperty[i];
                        CorsRule getRule = properties4.Cors.CorsRulesProperty[i];

                        Assert.Equal(putRule.AllowedHeaders, getRule.AllowedHeaders);
                        Assert.Equal(putRule.AllowedMethods, getRule.AllowedMethods);
                        Assert.Equal(putRule.AllowedOrigins, getRule.AllowedOrigins);
                        Assert.Equal(putRule.ExposedHeaders, getRule.ExposedHeaders);
                        Assert.Equal(putRule.MaxAgeInSeconds, getRule.MaxAgeInSeconds);
                    }

                }
                finally
                {
                    // clean up
                    storageMgmtClient.StorageAccounts.Delete(rgName, accountName);
                    resourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }
    }
}
