﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using NUnit.Framework;

namespace Azure.Developer.DevCenter.Tests.Samples
{
    public partial class DevCenterSamples: SamplesBase<DevCenterClientTestEnvironment>
    {
        public async Task CreateDeleteEnvironmentAsync(string tenantId, string devCenterName)
        {
            // Create and delete a user environment
            var credential = new DefaultAzureCredential();
            var devCenterClient = new DevCenterClient(tenantId, devCenterName, credential);
            string projectName = null;
            await foreach (BinaryData data in devCenterClient.GetProjectsAsync(filter: null, maxCount: 1))
            {
                JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
                projectName = result.GetProperty("name").ToString();
            }

            if (projectName is null)
            {
                throw new InvalidOperationException($"No valid project resources found in DevCenter {devCenterName}/tenant {tenantId}.");
            }

            #region Snippet:Azure_DevCenter_GetCatalogItems_Scenario
            var environmentsClient = new EnvironmentsClient(tenantId, devCenterName, projectName, credential);
            string catalogItemName = null;
            await foreach (BinaryData data in environmentsClient.GetCatalogItemsAsync(maxCount: 1))
            {
                JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
                catalogItemName = result.GetProperty("name").ToString();
            }
            #endregion

            if (catalogItemName is null)
            {
                throw new InvalidOperationException($"No valid catalog item resources found in Project {projectName}/DevCenter {devCenterName}/tenant {tenantId}.");
            }

            #region Snippet:Azure_DevCenter_GetEnvironmentTypes_Scenario
            string environmentTypeName = null;
            await foreach (BinaryData data in environmentsClient.GetEnvironmentTypesAsync(maxCount: 1))
            {
                JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
                environmentTypeName = result.GetProperty("name").ToString();
            }
            #endregion

            if (environmentTypeName is null)
            {
                throw new InvalidOperationException($"No valid catalog item resources found in Project {projectName}/DevCenter {devCenterName}/tenant {tenantId}.");
            }

            #region Snippet:Azure_DevCenter_CreateEnvironment_Scenario
            var content = new
            {
                environmentType = environmentTypeName,
                catalogItemName = catalogItemName,
            };

            // Deploy the environment
            Operation<BinaryData> environmentCreateOperation = await environmentsClient.CreateOrUpdateEnvironmentAsync(WaitUntil.Completed, "DevEnvironment", RequestContent.Create(content));
            BinaryData environmentData = await environmentCreateOperation.WaitForCompletionAsync();
            JsonElement environment = JsonDocument.Parse(environmentData.ToStream()).RootElement;
            Console.WriteLine($"Completed provisioning for environment with status {environment.GetProperty("provisioningState")}.");
            #endregion

            // Fetch and output the deployment artifacts
            await foreach (BinaryData data in environmentsClient.GetArtifactsByEnvironmentAsync(projectName, "DevEnvironment"))
            {
                JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("name").ToString());
                Console.WriteLine(result.GetProperty("isDirectory").ToString());
                Console.WriteLine(result.GetProperty("downloadUri").ToString());
            }

            // Delete the environment when finished
            #region Snippet:Azure_DevCenter_DeleteEnvironment_Scenario
            Operation environmentDeleteOperation = await environmentsClient.DeleteEnvironmentAsync(WaitUntil.Completed, projectName, "DevEnvironment");
            await environmentDeleteOperation.WaitForCompletionResponseAsync();
            Console.WriteLine($"Completed environment deletion.");
            #endregion
        }
    }
}
