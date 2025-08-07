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

            #region Snippet:Azure_DevCenter_GetCatalogs_Scenario
            // Create deployment environments client from existing DevCenter client
            var environmentsClient = devCenterClient.GetDeploymentEnvironmentsClient();

            //List all catalogs and grab the first one
            //Using foreach, but could also use a List
            string catalogName = default;
            await foreach (DevCenterCatalog catalog in environmentsClient.GetCatalogsAsync(projectName))
            {
                catalogName = catalog.Name;
                break;
            }
            Console.WriteLine($"Using catalog {catalogName}");
            #endregion

            if (catalogName is null)
            {
                throw new InvalidOperationException($"No valid catalog resources found in Project {projectName}/DevCenter {endpoint}.");
            }

            #region Snippet:Azure_DevCenter_GetEnvironmentDefinitionsFromCatalog_Scenario
            //List all environment definition for a catalog and grab the first one
            string environmentDefinitionName = default;
            await foreach (EnvironmentDefinition environmentDefinition in environmentsClient.GetEnvironmentDefinitionsByCatalogAsync(projectName, catalogName))
            {
                environmentDefinitionName = environmentDefinition.Name;
                break;
            }
            Console.WriteLine($"Using environment definition {environmentDefinitionName}");
            #endregion

            if (environmentDefinitionName is null)
            {
                throw new InvalidOperationException($"No valid environment definitions were found in Project {projectName}/DevCenter {endpoint}.");
            }

            #region Snippet:Azure_DevCenter_GetEnvironmentTypes_Scenario
            //List all environment types and grab the first one
            string environmentTypeName = default;
            await foreach (DevCenterEnvironmentType environmentType in environmentsClient.GetEnvironmentTypesAsync(projectName))
            {
                environmentTypeName = environmentType.Name;
                break;
            }
            Console.WriteLine($"Using environment type {environmentTypeName}");
            #endregion

            if (environmentTypeName is null)
            {
                throw new InvalidOperationException($"No valid environment type resources found in Project {projectName}/DevCenter {endpoint}.");
            }

            #region Snippet:Azure_DevCenter_CreateEnvironment_Scenario
            var requestEnvironment = new DevCenterEnvironment
            (
                "DevEnvironment",
                environmentTypeName,
                catalogName,
                environmentDefinitionName
            );

            // Deploy the environment
            Operation<DevCenterEnvironment> environmentCreateOperation = await environmentsClient.CreateOrUpdateEnvironmentAsync(
                WaitUntil.Completed,
                projectName,
                "me",
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
