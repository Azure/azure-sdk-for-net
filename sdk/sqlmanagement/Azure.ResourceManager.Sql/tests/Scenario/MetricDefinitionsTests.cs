// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Sql.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Sql.Tests.Scenario
{
    public class MetricDefinitionsTests : SqlManagementClientBase
    {
        private ResourceGroupResource _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;
        protected ArmClient client { get; private set; }
        public MetricDefinitionsTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, SessionRecording.GenerateAssetName("Sql-RG-"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            ArmClientOptions options = new ArmClientOptions();
            client = GetArmClient(options);
            _resourceGroup = await client.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        }

        [Test]
        [RecordedTest]
        public async Task GetMetricDefinitions()
        {
            // create Sql Server
            string serverName = Recording.GenerateAssetName("sql-server-");
            SqlServerResource sqlServer;
            ResourceIdentifier resourceId;
                resourceId = SqlServerResource.CreateResourceIdentifier("db1ab6f0-4769-4b27-930e-01e2ef9c123c", "sqlserver0523", "sqlservertest0523");
                sqlServer = client.GetSqlServerResource(resourceId);
            var collection = sqlServer.GetSqlDatabases();
            string databaseName = Recording.GenerateAssetName("sql-database-");

            // 1.CreateOrUpdate
            SqlDatabaseData data = new SqlDatabaseData(AzureLocation.EastUS) { };
            var dataBase = await collection.CreateOrUpdateAsync(WaitUntil.Completed, databaseName, data);
            var metricDefinitionsList = dataBase.Value.GetMetricDefinitionsAsync();
        }
    }
}
