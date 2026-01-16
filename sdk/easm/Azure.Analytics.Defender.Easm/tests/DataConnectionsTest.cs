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
            Assert.That(results, Is.Not.Null);
            await foreach (DataConnection result in results)
            {
                Assert.That(result.Name, Is.Not.Null);
                Assert.That(result.DisplayName, Is.Not.Null);
                Assert.That(result.Active, Is.Not.Null);
                Assert.That(result.Content, Is.Not.Null);
            }
        }

        [RecordedTest]
        public async System.Threading.Tasks.Task DataConnectionsGetTest()
        {
            var result = await client.GetDataConnectionAsync(DataConnectionName);
            DataConnection dataConnection = result.Value;
            Assert.That(dataConnection.Name, Is.EqualTo(DataConnectionName));
            Assert.That(dataConnection.DisplayName, Is.EqualTo(DataConnectionName));
            Assert.That(dataConnection.Active, Is.Not.Null);
            Assert.That(dataConnection.Content, Is.Not.Null);
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
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value.Error, Is.Null);
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
            Assert.That(response.Value.Name, Is.EqualTo(NewDataConnectionName));
            Assert.That(response.Value.DisplayName, Is.EqualTo(NewDataConnectionName));
            Assert.That(response.Value.GetType() == typeof(AzureDataExplorerDataConnection), Is.True);
            Assert.That(response.Value.Frequency, Is.EqualTo(DataConnectionFrequency.Daily));
        }
    }
}
