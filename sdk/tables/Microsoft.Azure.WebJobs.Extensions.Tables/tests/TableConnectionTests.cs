// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Data.Tables;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Tests
{
    [LiveOnly]
    public class TableConnectionTests : TablesLiveTestBase
    {
        public TableConnectionTests(bool isAsync, bool useCosmos) : base(isAsync, useCosmos, createTable: false)
        {
        }

        [RecordedTest]
        public async Task CanConnectUsingTokenCredential()
        {
            if (UseCosmos)
            {
                Assert.Ignore();
            }

            await CallAsync<CheckConnection>(configure: hostBuilder =>
            {
                hostBuilder.ConfigureAppConfiguration(builder =>
                {
                    builder.AddInMemoryCollection(new Dictionary<string, string>()
                    {
                        {"Table", TableName},
                        {"AzureWebJobsStorage:endpoint", UseCosmos ? TestEnvironment.CosmosUri : TestEnvironment.StorageUri},
                        {"AzureWebJobsStorage:clientId", TestEnvironment.ClientId},
                        {"AzureWebJobsStorage:clientSecret", TestEnvironment.ClientSecret},
                        {"AzureWebJobsStorage:tenantId", TestEnvironment.TenantId},
                    });
                });
            });
        }

        [RecordedTest]
        public async Task CanConnectUsingAccountNameAndTokenCredential()
        {
            if (UseCosmos)
            {
                Assert.Ignore();
            }

            await CallAsync<CheckConnection>(configure: hostBuilder =>
            {
                hostBuilder.ConfigureAppConfiguration(builder =>
                {
                    builder.AddInMemoryCollection(new Dictionary<string, string>()
                    {
                        {"Table", TableName},
                        {"AzureWebJobsStorage:accountName", TestEnvironment.StorageAccountName},
                        {"AzureWebJobsStorage:clientId", TestEnvironment.ClientId},
                        {"AzureWebJobsStorage:clientSecret", TestEnvironment.ClientSecret},
                        {"AzureWebJobsStorage:tenantId", TestEnvironment.TenantId},
                    });
                });
            });
        }

        [RecordedTest]
        public async Task CanConnectUsingKeyCredential()
        {
            await CallAsync<CheckConnection>(configure: hostBuilder =>
            {
                hostBuilder.ConfigureAppConfiguration(builder =>
                {
                    builder.AddInMemoryCollection(new Dictionary<string, string>()
                    {
                        {"Table", TableName},
                        {"AzureWebJobsStorage:endpoint", UseCosmos ? TestEnvironment.CosmosUri : TestEnvironment.StorageUri},
                        {"AzureWebJobsStorage:credential:accountName", UseCosmos? TestEnvironment.CosmosAccountName : TestEnvironment.StorageAccountName},
                        {"AzureWebJobsStorage:credential:accountKey", UseCosmos? TestEnvironment.PrimaryCosmosAccountKey : TestEnvironment.PrimaryStorageAccountKey},
                    });
                });
            });
        }

        [RecordedTest]
        public async Task CanConnectUsingConnectionString()
        {
            await CallAsync<CheckConnection>(configure: hostBuilder =>
            {
                hostBuilder.ConfigureAppConfiguration(builder =>
                {
                    builder.AddInMemoryCollection(new Dictionary<string, string>()
                    {
                        {"Table", TableName},
                        {"AzureWebJobsStorage", UseCosmos ? TestEnvironment.CosmosConnectionString : TestEnvironment.StorageConnectionString}
                    });
                });
            });
        }

        public class CheckConnection
        {
            public async Task Call([Table(TableNameExpression)] TableClient client)
            {
                Assert.True(await TableExistsAsync(client));
            }
        }
    }
}