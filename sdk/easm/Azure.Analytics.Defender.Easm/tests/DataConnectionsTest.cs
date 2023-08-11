// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Analytics.Defender.Easm.Models;
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
            DataConnectionName = "shad-data";
            NewDataConnectionName = "sample-dc";
            ClusterName = "sample-cluster";
            DatabaseName = "sample-db";
        }

        [RecordedTest]
        public async Task DataConnectionsListTest()
        {
            Response<DataConnectionPageResult> response = await client.GetDataConnectionsAsync();
            DataConnection dataConnectionResponse = response.Value.Value[0];
            Assert.IsNotNull(dataConnectionResponse.Name);
        }

        [RecordedTest]
        public async Task DataConnectionsValidateTest()
        {
            AzureDataExplorerDataConnectionProperties properties = new AzureDataExplorerDataConnectionProperties();
            properties.ClusterName = ClusterName;
            properties.DatabaseName = DatabaseName;
            properties.Region = "eastus";
            AzureDataExplorerDataConnectionData request = new AzureDataExplorerDataConnectionData(properties);
            request.Name = NewDataConnectionName;
            request.Content = DataConnectionContent.Assets;
            request.Frequency = DataConnectionFrequency.Daily;
            Response<ValidateResult> response = await client.ValidateDataConnectionAsync(request);
            Assert.IsNull(response.Value.Error);
        }

        [RecordedTest]
        public async Task DataConnectionsGetTest()
        {
            Response<DataConnection> response = await client.GetDataConnectionAsync(DataConnectionName);
            DataConnection dataConnectionResponse = response.Value;
            Assert.AreEqual(DataConnectionName, dataConnectionResponse.Name);
            Assert.AreEqual(DataConnectionName, dataConnectionResponse.DisplayName);
        }

        [RecordedTest]
        public async Task DataConnectionsPutTest()
        {
            AzureDataExplorerDataConnectionProperties properties = new AzureDataExplorerDataConnectionProperties();
            properties.ClusterName = ClusterName;
            properties.DatabaseName = DatabaseName;
            properties.Region = "eastus";
            AzureDataExplorerDataConnectionData request = new AzureDataExplorerDataConnectionData(properties);
            //request.Name = NewDataConnectionName;
            request.Content = DataConnectionContent.Assets;
            request.Frequency = DataConnectionFrequency.Daily;
            Response<DataConnection> response = await client.PutDataConnectionAsync(NewDataConnectionName, request);
            DataConnection dataConnectionResponse = response.Value;
            Assert.AreEqual(NewDataConnectionName, dataConnectionResponse.Name);
            Assert.AreEqual(NewDataConnectionName, dataConnectionResponse.DisplayName);
        }

        [RecordedTest]
        public async Task DataConnectionsDeleteTest()
        {
            Response response = await client.DeleteDataConnectionAsync(DataConnectionName);
            Assert.AreEqual(204, response.Status);
        }
    }
}
