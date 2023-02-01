// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Models;
using Azure.ResourceManager.Synapse.Models;

namespace Azure.ResourceManager.Synapse.Tests.Helpers
{
    public static class SynapseManagementTestUtilities
    {
        /// <summary>
        /// Create workspace create parameters.
        /// </summary>
        /// <param name="commonData"></param>
        /// <returns></returns>
        public static SynapseWorkspaceData PrepareWorkspaceCreateParams(this CommonTestFixture commonData)
        {
            return new SynapseWorkspaceData(commonData.Location)
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned),
                DefaultDataLakeStorage = new SynapseDataLakeStorageAccountDetails
                {
                    AccountUri = commonData.DefaultDataLakeStorageAccountUrl,
                    Filesystem = commonData.DefaultDataLakeStorageFilesystem
                },
                SqlAdministratorLogin = commonData.SshUsername,
                SqlAdministratorLoginPassword = commonData.SshPassword
            };
        }
    }
}
