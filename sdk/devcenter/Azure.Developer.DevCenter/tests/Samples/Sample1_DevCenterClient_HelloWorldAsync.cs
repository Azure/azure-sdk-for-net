// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Azure_DevCenter_BasicImport
using System;
using Azure.Developer.DevCenter;
using Azure.Developer.DevCenter.Models;
using Azure.Identity;
#endregion
using Azure.Core.TestFramework;
using System.Threading.Tasks;

namespace Azure.Developer.DevCenter.Tests.Samples
{
    public partial class DevCenterSamples : SamplesBase<DevCenterClientTestEnvironment>
    {
        public async Task GetProject()
        {
            #region Snippet:Azure_DevCenter_CreateDevCenterClient
            string devCenterUri = "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com";
            var endpoint = new Uri(devCenterUri);
            var credential = new DefaultAzureCredential();

            var devCenterClient = new DevCenterClient(endpoint, credential);
            #endregion

            #region Snippet:Azure_DevCenter_GetProjectAsync
            DevCenterProject project = await devCenterClient.GetProjectAsync("MyProject");
            Console.WriteLine(project.Name);
            #endregion

        }
    }
}
