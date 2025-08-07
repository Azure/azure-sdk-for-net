// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Azure_DevCenter_LongImports
using System;
using System.Collections.Generic;
using System.Linq;
using Azure;
using Azure.Developer.DevCenter;
using Azure.Developer.DevCenter.Models;
using Azure.Identity;
#endregion
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.Developer.DevCenter.Tests.Samples
{
    public partial class DevCenterSamples: SamplesBase<DevCenterClientTestEnvironment>
    {
        public async Task CreateDeleteDevBoxAsync()
        {
            // Create and delete a Dev Box
            #region Snippet:Azure_DevCenter_GetProjects_Scenario
            string devCenterUri = "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com";
            var endpoint = new Uri(devCenterUri);
            var credential = new DefaultAzureCredential();
            var devCenterClient = new DevCenterClient(endpoint, credential);

            List<DevCenterProject> projects = await devCenterClient.GetProjectsAsync().ToEnumerableAsync();
            var projectName = projects.FirstOrDefault().Name;
            #endregion

            if (projectName is null)
            {
                throw new InvalidOperationException($"No valid project resources found in DevCenter {endpoint}.");
            }

            #region Snippet:Azure_DevCenter_GetPools_Scenario
            // Create DevBox-es client from existing DevCenter client
            var devBoxesClient = devCenterClient.GetDevBoxesClient();

            // Grab a pool
            List<DevBoxPool> pools = await devBoxesClient.GetPoolsAsync(projectName).ToEnumerableAsync();
            var poolName = pools.FirstOrDefault().Name;
            #endregion

            if (poolName is null)
            {
                throw new InvalidOperationException($"No valid pool resources found in Project {projectName}/DevCenter {endpoint}.");
            }

            // Provision your dev box in the selected pool
            #region Snippet:Azure_DevCenter_CreateDevBox_Scenario
            var devBoxName = "MyDevBox";
            var devBox = new DevBox(devBoxName, poolName);

            Operation<DevBox> devBoxCreateOperation = await devBoxesClient.CreateDevBoxAsync(
                WaitUntil.Completed,
                projectName,
                "me",
                devBox);

            devBox = await devBoxCreateOperation.WaitForCompletionAsync();
            Console.WriteLine($"Completed provisioning for dev box with status {devBox.ProvisioningState}.");
            #endregion

            // Fetch the web connection URL to access your dev box from the browser
            #region Snippet:Azure_DevCenter_ConnectToDevBox_Scenario

            RemoteConnection remoteConnection = await devBoxesClient.GetRemoteConnectionAsync(
                projectName,
                "me",
                devBoxName);

            Console.WriteLine($"Connect using web URL {remoteConnection.WebUri}.");
            #endregion

            // Delete your dev box when finished
            #region Snippet:Azure_DevCenter_DeleteDevBox_Scenario
            Operation devBoxDeleteOperation = await devBoxesClient.DeleteDevBoxAsync(
                WaitUntil.Completed,
                projectName,
                "me",
                devBoxName);
            await devBoxDeleteOperation.WaitForCompletionResponseAsync();
            Console.WriteLine($"Completed dev box deletion.");
            #endregion
        }
    }
}
