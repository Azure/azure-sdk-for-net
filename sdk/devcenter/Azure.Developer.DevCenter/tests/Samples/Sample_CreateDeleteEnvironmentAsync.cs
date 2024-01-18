// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Developer.DevCenter.Models;

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
            await foreach (DevCenterProject project in devCenterClient.GetProjectsAsync())
            {
                projectName = project.Name;
            }

            if (projectName is null)
            {
                throw new InvalidOperationException($"No valid project resources found in DevCenter {endpoint}.");
            }

            // Create deployment environments client
            var environmentsClient = new DeploymentEnvironmentsClient(endpoint, credential);

            #region Snippet:Azure_DevCenter_GetCatalogs_Scenario
            string catalogName = null;

            await foreach (DevCenterCatalog catalog in environmentsClient.GetCatalogsAsync(projectName))
            {
                catalogName = catalog.Name;
            }
            #endregion

            if (catalogName is null)
            {
                throw new InvalidOperationException($"No valid catalog resources found in Project {projectName}/DevCenter {endpoint}.");
            }

            #region Snippet:Azure_DevCenter_GetEnvironmentDefinitionsFromCatalog_Scenario
            string environmentDefinitionName = null;
            await foreach (EnvironmentDefinition environmentDefinition in environmentsClient.GetEnvironmentDefinitionsByCatalogAsync(projectName, catalogName))
            {
                environmentDefinitionName = environmentDefinition.Name;
            }
            #endregion

            if (environmentDefinitionName is null)
            {
                throw new InvalidOperationException($"No valid environment definitions were found in Project {projectName}/DevCenter {endpoint}.");
            }

            #region Snippet:Azure_DevCenter_GetEnvironmentTypes_Scenario
            string environmentTypeName = null;
            await foreach (DevCenterEnvironmentType environmentType in environmentsClient.GetEnvironmentTypesAsync(projectName))
            {
                environmentTypeName = environmentType.Name;
            }
            #endregion

            if (environmentTypeName is null)
            {
                throw new InvalidOperationException($"No valid environment type resources found in Project {projectName}/DevCenter {endpoint}.");
            }

            #region Snippet:Azure_DevCenter_CreateEnvironment_Scenario
            var requestEnvironment = new DevCenterEnvironment
            (
                environmentTypeName,
                catalogName,
                environmentDefinitionName
            );

            // Deploy the environment
            Operation<DevCenterEnvironment> environmentCreateOperation = await environmentsClient.CreateOrUpdateEnvironmentAsync(
                WaitUntil.Completed,
                projectName,
                "me",
                "DevEnvironment",
                requestEnvironment);

            DevCenterEnvironment environment = await environmentCreateOperation.WaitForCompletionAsync();
            Console.WriteLine($"Completed provisioning for environment with status {environment.ProvisioningState}.");
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
