// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Analytics.Defender.Easm;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Defender.Easm.Tests
{
    internal class DataConnectionsTest : EasmClientTest
    {
        private string DataConnectionName;
        private string NewDataConnectionName;
        private string ClusterName;
        private string DatabaseName;

        public DataConnectionsTest(bool isAsync) : base(isAsync)
        {
            DataConnectionName = "new-sample-dc";
            NewDataConnectionName = "new-sample-dc";
            ClusterName = "sample-cluster";
            DatabaseName = "sample-db";
        }

        [RecordedTest]
        public async System.Threading.Tasks.Task DataConnectionsListTest()
        {
            var results = client.GetDataConnectionsAsync();
            var asyncNumerator = results.GetAsyncEnumerator();
            Assert.IsNotNull(results);
            await foreach (DataConnection result in results)
            {
                Assert.IsNotNull(result.Name);
                Assert.IsNotNull(result.DisplayName);
                Assert.IsNotNull(result.Active);
                Assert.IsNotNull(result.Content);
            }
        }

        [RecordedTest]
        public async System.Threading.Tasks.Task DataConnectionsGetTest()
        {
            var result = await client.GetDataConnectionAsync(DataConnectionName);
            DataConnection dataConnection = result.Value;
            Assert.AreEqual(DataConnectionName, dataConnection.Name);
            Assert.AreEqual(DataConnectionName, dataConnection.DisplayName);
            Assert.IsNotNull(dataConnection.Active);
            Assert.IsNotNull(dataConnection.Content);
        }

        [RecordedTest]
        public async System.Threading.Tasks.Task DataConnectionsValidateTest()
        {
            AzureDataExplorerDataConnectionProperties properties = new AzureDataExplorerDataConnectionProperties();
            properties.ClusterName = ClusterName;
            properties.DatabaseName = DatabaseName;
            properties.Region = "eastus";
            AzureDataExplorerDataConnectionPayload request = new AzureDataExplorerDataConnectionPayload(properties);
            request.Name = DatabaseName;
            request.Content = DataConnectionContent.Assets;
            request.Frequency = DataConnectionFrequency.Daily;
            var response = await client.ValidateDataConnectionAsync(request).ConfigureAwait(false);
            Assert.IsNotNull(response);
            Assert.IsNull(response.Value.Error);
        }

        [RecordedTest]
        public async System.Threading.Tasks.Task DataConnectionsCreateOrReplaceTest()
        {
            AzureDataExplorerDataConnectionProperties properties = new AzureDataExplorerDataConnectionProperties();
            properties.ClusterName = ClusterName;
            properties.DatabaseName = DatabaseName;
            properties.Region = "eastus";
            AzureDataExplorerDataConnectionPayload request = new AzureDataExplorerDataConnectionPayload(properties);
            request.Name = NewDataConnectionName;
            request.Content = DataConnectionContent.Assets;
            request.Frequency = DataConnectionFrequency.Daily;
            var response = await client.CreateOrReplaceDataConnectionAsync(NewDataConnectionName, request).ConfigureAwait(false);
            Assert.AreEqual(NewDataConnectionName, response.Value.Name);
            Assert.AreEqual(NewDataConnectionName, response.Value.DisplayName);
            Assert.True(response.Value.GetType() == typeof(AzureDataExplorerDataConnection));
            Assert.AreEqual(DataConnectionFrequency.Daily, response.Value.Frequency);
        }
    }
}
