// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Developer.DevCenter.Tests.Samples
{
    public partial class DevCenterSamples: SamplesBase<DevCenterClientTestEnvironment>
    {
        #region Snippet:Azure_DevCenter_DevBox_Scenario
        public async Task CreateDeleteDevBoxAsync(string tenantId, string devCenterName)
        {
            // Create and delete a user devbox
            var credential = new DefaultAzureCredential();
            var devCenterClient = new DevCenterClient(tenantId, devCenterName, credential);
            string targetProjectName = null;
            await foreach (BinaryData data in devCenterClient.GetProjectsAsync(filter: null, top: 1))
            {
                JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
                targetProjectName = result.GetProperty("name").ToString();
            }

            if (targetProjectName is null)
            {
                throw new InvalidOperationException($"No valid project resources found in DevCenter {devCenterName}/tenant {tenantId}.");
            }

            // Grab a pool
            var devBoxesClient = new DevBoxesClient(tenantId, devCenterName, targetProjectName, credential);
            string targetPoolName = null;
            await foreach (BinaryData data in devBoxesClient.GetPoolsAsync(filter: null, top: 1))
            {
                JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
                targetPoolName = result.GetProperty("name").ToString();
            }

            if (targetPoolName is null)
            {
                throw new InvalidOperationException($"No valid pool resources found in Project {targetProjectName}/DevCenter {devCenterName}/tenant {tenantId}.");
            }

            // Provision your dev box in the selected pool
            var content = new
            {
                poolName = targetPoolName,
            };

            Operation<BinaryData> devBoxCreateOperation = await devBoxesClient.CreateDevBoxAsync(WaitUntil.Completed, "MyDevBox", RequestContent.Create(content));
            BinaryData devBoxData = await devBoxCreateOperation.WaitForCompletionAsync();
            JsonElement devBox = JsonDocument.Parse(devBoxData.ToStream()).RootElement;
            Console.WriteLine($"Completed provisioning for dev box with status {devBox.GetProperty("provisioningState")}.");

            // Fetch the web connection URL to access your dev box from the browser
            Response remoteConnectionResponse = await devBoxesClient.GetRemoteConnectionAsync("MyDevBox");
            JsonElement remoteConnectionData = JsonDocument.Parse(remoteConnectionResponse.ContentStream).RootElement;
            Console.WriteLine($"Connect using web URL {remoteConnectionData.GetProperty("webUrl")}.");

            // Delete your dev box when finished
            Operation devBoxDeleteOperation = await devBoxesClient.DeleteDevBoxAsync(WaitUntil.Completed, "MyDevBox");
            await devBoxDeleteOperation.WaitForCompletionResponseAsync();
            Console.WriteLine($"Completed dev box deletion.");
        }
        #endregion
    }
}
