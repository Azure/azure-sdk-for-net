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
    public partial class Samples_DevBoxesClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DevBoxesClientOperations_CreateDevBox_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            DevBoxesClient client = new DevBoxesClient(endpoint, credential);

            DevBox devBox = new DevBox("<devBoxName>", "<poolName>");
            Operation<DevBox> operation = client.CreateDevBox(WaitUntil.Completed, "<projectName>", "<userId>", devBox);
            DevBox responseData = operation.Value;
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DevBoxesClientOperations_CreateDevBox_ShortVersion_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            DevBoxesClient client = new DevBoxesClient(endpoint, credential);

            DevBox devBox = new DevBox("<devBoxName>", "<poolName>");
            Operation<DevBox> operation = await client.CreateDevBoxAsync(WaitUntil.Completed, "<projectName>", "<userId>", devBox);
            DevBox responseData = operation.Value;
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DevBoxesClientOperations_CreateDevBox_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            DevBoxesClient client = new DevBoxesClient(endpoint, credential);

            DevBox devBox = new DevBox("<devBoxName>", "<poolName>")
            {
                LocalAdministratorStatus = LocalAdministratorStatus.Enabled,
            };
            Operation<DevBox> operation = client.CreateDevBox(WaitUntil.Completed, "<projectName>", "<userId>", devBox);
            DevBox responseData = operation.Value;
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DevBoxesClientOperations_CreateDevBox_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            DevBoxesClient client = new DevBoxesClient(endpoint, credential);

            DevBox devBox = new DevBox("<devBoxName>", "<poolName>")
            {
                LocalAdministratorStatus = LocalAdministratorStatus.Enabled,
            };
            Operation<DevBox> operation = await client.CreateDevBoxAsync(WaitUntil.Completed, "<projectName>", "<userId>", devBox);
            DevBox responseData = operation.Value;
        }
    }
}
