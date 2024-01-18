// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Developer.DevCenter.Models;

namespace Azure.Developer.DevCenter.Tests.Samples
{
    public partial class DevCenterSamples: SamplesBase<DevCenterClientTestEnvironment>
    {
        public async Task CreateDeleteDevBoxAsync(Uri endpoint)
        {
            // Create and delete a Dev Box
            var credential = new DefaultAzureCredential();
            var devCenterClient = new DevCenterClient(endpoint, credential);

            #region Snippet:Azure_DevCenter_GetProjects_Scenario
            string targetProjectName = null;
            await foreach (DevCenterProject project in devCenterClient.GetProjectsAsync())
            {
                targetProjectName = project.Name;
            }
            #endregion

            if (targetProjectName is null)
            {
                throw new InvalidOperationException($"No valid project resources found in DevCenter {endpoint}.");
            }

            // Create DevBox-es client
            var devBoxesClient = new DevBoxesClient(endpoint, credential);

            // Grab a pool
            #region Snippet:Azure_DevCenter_GetPools_Scenario
            string targetPoolName = null;
            await foreach (DevBoxPool pool in devBoxesClient.GetPoolsAsync(targetProjectName))
            {
                targetPoolName = pool.Name;
            }
            #endregion

            if (targetPoolName is null)
            {
                throw new InvalidOperationException($"No valid pool resources found in Project {targetProjectName}/DevCenter {endpoint}.");
            }

            // Provision your dev box in the selected pool
            #region Snippet:Azure_DevCenter_CreateDevBox_Scenario
            var content = new DevBox(targetPoolName);

            Operation<DevBox> devBoxCreateOperation = await devBoxesClient.CreateDevBoxAsync(
                WaitUntil.Completed,
                targetProjectName,
                "me",
                "MyDevBox",
                content);

            DevBox devBox = await devBoxCreateOperation.WaitForCompletionAsync();
            Console.WriteLine($"Completed provisioning for dev box with status {devBox.ProvisioningState}.");
            #endregion

            // Fetch the web connection URL to access your dev box from the browser
            #region Snippet:Azure_DevCenter_ConnectToDevBox_Scenario

            RemoteConnection remoteConnection = await devBoxesClient.GetRemoteConnectionAsync(
                targetProjectName,
                "me",
                "MyDevBox");

            Console.WriteLine($"Connect using web URL {remoteConnection.WebUri}.");
            #endregion

            // Delete your dev box when finished
            #region Snippet:Azure_DevCenter_DeleteDevBox_Scenario
            Operation devBoxDeleteOperation = await devBoxesClient.DeleteDevBoxAsync(
                WaitUntil.Completed,
                targetProjectName,
                "me",
                "MyDevBox");
            await devBoxDeleteOperation.WaitForCompletionResponseAsync();
            Console.WriteLine($"Completed dev box deletion.");
            #endregion
        }
    }
}
