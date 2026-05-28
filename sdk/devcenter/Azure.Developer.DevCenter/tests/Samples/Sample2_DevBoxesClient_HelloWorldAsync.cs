// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Developer.DevCenter;
using Azure.Developer.DevCenter.Models;
using Azure.Identity;
using Azure.Core.TestFramework;
using System.Threading.Tasks;

namespace Azure.Developer.DevCenter.Tests.Samples
{
    public partial class DevCenterSamples : SamplesBase<DevCenterClientTestEnvironment>
    {
        public async Task GetDevBox()
        {
            #region Snippet:Azure_DevCenter_CreateDevBoxesClient
            string devCenterUri = "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com";
            var endpoint = new Uri(devCenterUri);
            var credential = new DefaultAzureCredential();

            var devBoxesClient = new DevBoxesClient(endpoint, credential);
            #endregion

            #region Snippet:Azure_DevCenter_GetDevBoxAsync
            DevBox devBox = await devBoxesClient.GetDevBoxAsync("MyProject", "me", "MyDevBox");
            Console.WriteLine($"The dev box {devBox.Name} is located in the {devBox.Location} region.");
            #endregion

        }
    }
}
