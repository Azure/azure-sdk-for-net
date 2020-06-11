// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
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
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Management.KeyVault;
using Microsoft.Rest.Azure.Authentication;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Threading.Tasks;
using Microsoft.Azure.Test.HttpRecorder;
using System.Net.Http;
using Microsoft.Azure.KeyVault.WebKey;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Storage.Tests
{
    public class QueueServiceTests
    {
        // create Queue
        // delete Queue
        [Fact]
        public void QueueCreateDeleteUpdateListTest()
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
                    Sku = new Sku { Name = SkuName.StandardLRS },
                    LargeFileSharesState = LargeFileSharesState.Enabled
                };
                var account = storageMgmtClient.StorageAccounts.Create(rgName, accountName, parameters);

                // implement case
                try
                {
                    //create queue
                    string queueName = TestUtilities.GenerateName("queue1");
                    StorageQueue queue = storageMgmtClient.Queue.Create(rgName, accountName, queueName);
                    Assert.Equal(0, queue.Metadata.Count);

                    queue = storageMgmtClient.Queue.Get(rgName, accountName, queueName);
                    Assert.Equal(0, queue.Metadata.Count);

                    string queueName2 = TestUtilities.GenerateName("queue2");
                    Dictionary<string, string> metaData = new Dictionary<string, string>();
                    metaData.Add("metadata1", "true");
                    metaData.Add("metadata2", "value2");
                    StorageQueue queue2 = storageMgmtClient.Queue.Create(rgName, accountName, queueName2, metadata: metaData);
                    Assert.Equal(2, queue2.Metadata.Count);
                    Assert.Equal(metaData, queue2.Metadata);

                    queue2 = storageMgmtClient.Queue.Get(rgName, accountName, queueName2);
                    Assert.Equal(2, queue2.Metadata.Count);
                    Assert.Equal(metaData, queue2.Metadata);

                    // Update queue: Update still not so work, uncomment the case when the server works with update
                    queue = storageMgmtClient.Queue.Update(rgName, accountName, queueName, metaData);
                    Assert.Equal(2, queue.Metadata.Count);
                    Assert.Equal(metaData, queue.Metadata);

                    queue = storageMgmtClient.Queue.Get(rgName, accountName, queueName);
                    Assert.Equal(2, queue.Metadata.Count);
                    Assert.Equal(metaData, queue.Metadata);

                    //list queues
                    IPage<ListQueue> queues = storageMgmtClient.Queue.List(rgName, accountName);
                    Assert.Equal(2, queues.Count());

                    //Delete queue
                    storageMgmtClient.Queue.Delete(rgName, accountName, queueName);
                    queues = storageMgmtClient.Queue.List(rgName, accountName);
                    Assert.Equal(1, queues.Count());

                    storageMgmtClient.Queue.Delete(rgName, accountName, queueName2);
                    queues = storageMgmtClient.Queue.List(rgName, accountName);
                    Assert.Equal(0, queues.Count());
                }
                finally
                {
                    // clean up
                    storageMgmtClient.StorageAccounts.Delete(rgName, accountName);
                    resourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        // Get/Set Queue Service Properties
        [Fact]
        public void QueueServiceCorsTest()
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
                    Sku = new Sku { Name = SkuName.StandardLRS },
                    LargeFileSharesState = LargeFileSharesState.Enabled
                };
                var account = storageMgmtClient.StorageAccounts.Create(rgName, accountName, parameters);

                // implement case
                try
                {
                    QueueServiceProperties properties1 = storageMgmtClient.QueueServices.GetServiceProperties(rgName, accountName);
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

                    QueueServiceProperties properties3 = storageMgmtClient.QueueServices.SetServiceProperties(rgName, accountName, cors);

                    //Validate CORS Rules
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

                    QueueServiceProperties properties4 = storageMgmtClient.QueueServices.GetServiceProperties(rgName, accountName);

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
