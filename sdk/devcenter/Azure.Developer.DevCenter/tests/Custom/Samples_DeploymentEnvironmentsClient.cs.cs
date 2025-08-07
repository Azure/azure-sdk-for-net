// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Developer.DevCenter.Models;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Developer.DevCenter.Samples
{
    public partial class Samples_DeploymentEnvironmentsClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EnvironmentClientOperations_CreateOrUpdateEnvironment_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            DeploymentEnvironmentsClient client = new DeploymentEnvironmentsClient(endpoint, credential);

            DevCenterEnvironment environment = new DevCenterEnvironment("<environmentName>", "<environmentType>", "<catalogName>", "<environmentDefinitionName>");
            Operation<DevCenterEnvironment> operation = client.CreateOrUpdateEnvironment(WaitUntil.Completed, "<projectName>", "<userId>", environment);
            DevCenterEnvironment responseData = operation.Value;
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EnvironmentClientOperations_CreateOrUpdateEnvironment_ShortVersion_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            DeploymentEnvironmentsClient client = new DeploymentEnvironmentsClient(endpoint, credential);

            DevCenterEnvironment environment = new DevCenterEnvironment("<environmentName>", "<environmentType>", "<catalogName>", "<environmentDefinitionName>");
            Operation<DevCenterEnvironment> operation = await client.CreateOrUpdateEnvironmentAsync(WaitUntil.Completed, "<projectName>", "<userId>", environment);
            DevCenterEnvironment responseData = operation.Value;
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_EnvironmentClientOperations_CreateOrUpdateEnvironment_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            DeploymentEnvironmentsClient client = new DeploymentEnvironmentsClient(endpoint, credential);

            DevCenterEnvironment environment = new DevCenterEnvironment("<environmentName>", "<environmentType>", "<catalogName>", "<environmentDefinitionName>")
            {
                Parameters =
                {
                    ["key"] = BinaryData.FromObjectAsJson(new object())
                },
            };
            Operation<DevCenterEnvironment> operation = client.CreateOrUpdateEnvironment(WaitUntil.Completed, "<projectName>", "<userId>", environment);
            DevCenterEnvironment responseData = operation.Value;
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_EnvironmentClientOperations_CreateOrUpdateEnvironment_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            DeploymentEnvironmentsClient client = new DeploymentEnvironmentsClient(endpoint, credential);

            DevCenterEnvironment environment = new DevCenterEnvironment("<environmentName>", "<environmentType>", "<catalogName>", "<environmentDefinitionName>")
            {
                Parameters =
                {
                    ["key"] = BinaryData.FromObjectAsJson(new object())
                },
            };
            Operation<DevCenterEnvironment> operation = await client.CreateOrUpdateEnvironmentAsync(WaitUntil.Completed, "<projectName>", "<userId>", environment);
            DevCenterEnvironment responseData = operation.Value;
        }
    }
}
