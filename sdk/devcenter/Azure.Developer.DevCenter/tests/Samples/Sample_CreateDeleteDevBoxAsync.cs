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
        public async Task CreateDeleteDevBoxAsync(Uri endpoint)
        {
            // Create and delete a user devbox
            #region Snippet:Azure_DevCenter_GetProjects_Scenario
            var credential = new DefaultAzureCredential();
            var devCenterClient = new DevCenterClient(endpoint, credential);
            string targetProjectName = null;
            await foreach (BinaryData data in devCenterClient.GetProjectsAsync(filter: null, maxCount: 1))
            {
                JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
                targetProjectName = result.GetProperty("name").ToString();
            }
            #endregion

            if (targetProjectName is null)
            {
                throw new InvalidOperationException($"No valid project resources found in DevCenter {endpoint}.");
            }

            // Grab a pool
            #region Snippet:Azure_DevCenter_GetPools_Scenario
            var devBoxesClient = new DevBoxesClient(endpoint, targetProjectName, credential);
            string targetPoolName = null;
            await foreach (BinaryData data in devBoxesClient.GetPoolsAsync(filter: null, maxCount: 1))
            {
                JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
                targetPoolName = result.GetProperty("name").ToString();
            }
            #endregion

            if (targetPoolName is null)
            {
                throw new InvalidOperationException($"No valid pool resources found in Project {targetProjectName}/DevCenter {endpoint}.");
            }

            // Provision your dev box in the selected pool
            #region Snippet:Azure_DevCenter_CreateDevBox_Scenario
            var content = new
            {
                poolName = targetPoolName,
            };

            Operation<BinaryData> devBoxCreateOperation = await devBoxesClient.CreateDevBoxAsync(WaitUntil.Completed, "MyDevBox", RequestContent.Create(content));
            BinaryData devBoxData = await devBoxCreateOperation.WaitForCompletionAsync();
            JsonElement devBox = JsonDocument.Parse(devBoxData.ToStream()).RootElement;
            Console.WriteLine($"Completed provisioning for dev box with status {devBox.GetProperty("provisioningState")}.");
            #endregion

            // Fetch the web connection URL to access your dev box from the browser
            #region Snippet:Azure_DevCenter_ConnectToDevBox_Scenario
            Response remoteConnectionResponse = await devBoxesClient.GetRemoteConnectionAsync("MyDevBox");
            JsonElement remoteConnectionData = JsonDocument.Parse(remoteConnectionResponse.ContentStream).RootElement;
            Console.WriteLine($"Connect using web URL {remoteConnectionData.GetProperty("webUrl")}.");
            #endregion

            // Delete your dev box when finished
            #region Snippet:Azure_DevCenter_DeleteDevBox_Scenario
            Operation devBoxDeleteOperation = await devBoxesClient.DeleteDevBoxAsync(WaitUntil.Completed, "MyDevBox");
            await devBoxDeleteOperation.WaitForCompletionResponseAsync();
            Console.WriteLine($"Completed dev box deletion.");
            #endregion
        }
    }
}
