// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.MachineLearningServices.Tests.Extensions
{
    public class ResourceDataCreationHelper
    {
        private readonly MachineLearningServicesManagerTestBase _testBase;

        public ResourceDataCreationHelper(MachineLearningServicesManagerTestBase testBase)
        {
            _testBase = testBase;
        }

        public WorkspaceData GenerateWorkspaceData()
        {
            return new WorkspaceData
            {
                Location = Location.WestUS2,
                ApplicationInsights = _testBase.CommonAppInsightId,
                ContainerRegistry = _testBase.CommonAcrId,
                StorageAccount = _testBase.CommonStorageId,
                KeyVault = _testBase.CommonKeyVaultId,
                Identity = new Models.Identity { Type = (Models.ResourceIdentityType?)ResourceIdentityType.SystemAssigned }
            };
        }
    }
}
