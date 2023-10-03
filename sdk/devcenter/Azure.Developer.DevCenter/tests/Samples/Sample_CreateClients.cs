// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Developer.DevCenter.Tests.Samples
{
    public partial class DevCenterSamples : SamplesBase<DevCenterClientTestEnvironment>
    {
        public void CreateClients(Uri endpoint)
        {
            #region Snippet:Azure_DevCenter_CreateClients_Scenario
            var credential = new DefaultAzureCredential();

            var devCenterClient = new DevCenterClient(endpoint, credential);
            var devBoxesClient = new DevBoxesClient(endpoint, credential);
            var environmentsClient = new DeploymentEnvironmentsClient(endpoint, credential);
            #endregion
        }
    }
}
