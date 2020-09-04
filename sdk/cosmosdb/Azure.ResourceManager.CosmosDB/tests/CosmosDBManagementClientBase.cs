// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.TestFramework;
using Azure.Management.Resources;
using Azure.ResourceManager.TestFramework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    [RunFrequency(RunTestFrequency.Manually)]
    public abstract class CosmosDBManagementClientBase : ManagementRecordedTestBase<CosmosDBManagementTestEnvironment>
    {
        public string SubscriptionId { get; set; }
        public ResourcesManagementClient ResourcesManagementClient { get; set; }
        public ResourceGroupsOperations ResourceGroupsOperations { get; set; }
        public CosmosDBManagementClient CosmosDBManagementClient { get; set; }

        // Vars for Cassandra tests - using an existing DB account, since Account provisioning takes 10-15 minutes
        public string location = "West US";
        public string resourceGroupName;
        public string databaseAccountName = "db" + new Random().Next(10000);
        public string keyspaceName = "keyspaceName2510";
        public string keyspaceName2 = "keyspaceName22510";
        public string tableName = "tableName2510";
        public string cassandraThroughputType = "Microsoft.DocumentDB/databaseAccounts/cassandraKeyspaces/throughputSettings";
        public int sampleThroughput = 700;
        public Dictionary<string, string> additionalProperties = new Dictionary<string, string>
            {
                {"foo","bar"}
            };
        public Dictionary<string, string> tags = new Dictionary<string, string>
            {
                {"key3","value3"},
                {"key4","value4"}
            };
        protected CosmosDBManagementClientBase(bool isAsync)
            : base(isAsync)
        {
        }

        protected void InitializeClients()
        {
            SubscriptionId = TestEnvironment.SubscriptionId;
            ResourcesManagementClient = GetResourceManagementClient();
            ResourceGroupsOperations = ResourcesManagementClient.ResourceGroups;
            CosmosDBManagementClient = GetCosmosDBManagementClient();
        }

        internal CosmosDBManagementClient GetCosmosDBManagementClient()
        {
            return CreateClient<CosmosDBManagementClient>(this.SubscriptionId,
                TestEnvironment.Credential,
                Recording.InstrumentClientOptions(new CosmosDBManagementClientOptions()));
        }
    }
}
