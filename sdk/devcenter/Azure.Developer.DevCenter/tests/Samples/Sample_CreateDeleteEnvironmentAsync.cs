// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.Developer.DevCenter.Tests.Samples
{
    public partial class DevCenterSamples: SamplesBase<DevCenterClientTestEnvironment>
    {
        public async Task CreateDeleteEnvironmentAsync(Uri endpoint)
        {
            // Create and delete a user environment
            var credential = new DefaultAzureCredential();
            var devCenterClient = new DevCenterClient(endpoint, credential);
            string projectName = null;
            await foreach (BinaryData data in devCenterClient.GetProjectsAsync(null, null, null))
            {
                JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
                projectName = result.GetProperty("name").ToString();
            }

            if (projectName is null)
            {
                throw new InvalidOperationException($"No valid project resources found in DevCenter {endpoint}.");
            }

            // Create deployment environments client
            var environmentsClient = new DeploymentEnvironmentsClient(endpoint, credential);

            #region Snippet:Azure_DevCenter_GetCatalogs_Scenario
            string catalogName = null;

            await foreach (BinaryData data in environmentsClient.GetCatalogsAsync(projectName, null, null))
            {
                JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
                catalogName = result.GetProperty("name").ToString();
            }
            #endregion

            if (catalogName is null)
            {
                throw new InvalidOperationException($"No valid catalog resources found in Project {projectName}/DevCenter {endpoint}.");
            }

            #region Snippet:Azure_DevCenter_GetEnvironmentDefinitionsFromCatalog_Scenario
            string environmentDefinitionName = null;
            await foreach (BinaryData data in environmentsClient.GetEnvironmentDefinitionsByCatalogAsync(projectName, catalogName, maxCount: 1, context: new()))
            {
                JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
                environmentDefinitionName = result.GetProperty("name").ToString();
            }
            #endregion

            if (environmentDefinitionName is null)
            {
                throw new InvalidOperationException($"No valid environemtn definitions were found in Project {projectName}/DevCenter {endpoint}.");
            }

            #region Snippet:Azure_DevCenter_GetEnvironmentTypes_Scenario
            string environmentTypeName = null;
            await foreach (BinaryData data in environmentsClient.GetEnvironmentTypesAsync(projectName, null, null))
            {
                JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
                environmentTypeName = result.GetProperty("name").ToString();
            }
            #endregion

            if (environmentTypeName is null)
            {
                throw new InvalidOperationException($"No valid environment type resources found in Project {projectName}/DevCenter {endpoint}.");
            }

            #region Snippet:Azure_DevCenter_CreateEnvironment_Scenario
            var content = new
            {
                catalogName = catalogName,
                environmentType = environmentTypeName,
                environmentDefinitionName = environmentDefinitionName,
            };

            // Deploy the environment
            Operation<BinaryData> environmentCreateOperation = await environmentsClient.CreateOrUpdateEnvironmentAsync(
                WaitUntil.Completed,
                projectName,
                "me",
                "DevEnvironment",
                RequestContent.Create(content));

            BinaryData environmentData = await environmentCreateOperation.WaitForCompletionAsync();
            JsonElement environment = JsonDocument.Parse(environmentData.ToStream()).RootElement;
            Console.WriteLine($"Completed provisioning for environment with status {environment.GetProperty("provisioningState")}.");
            #endregion

            // Delete the environment when finished
            #region Snippet:Azure_DevCenter_DeleteEnvironment_Scenario
            Operation environmentDeleteOperation = await environmentsClient.DeleteEnvironmentAsync(
                WaitUntil.Completed,
                projectName,
                "me",
                "DevEnvironment");
            await environmentDeleteOperation.WaitForCompletionResponseAsync();
            Console.WriteLine($"Completed environment deletion.");
            #endregion
        }
    }
}
