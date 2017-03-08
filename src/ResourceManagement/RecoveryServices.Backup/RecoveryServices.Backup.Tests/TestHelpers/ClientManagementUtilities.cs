// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Microsoft.Azure.Management.RecoveryServices.Backup.Tests
{
    public static class ClientManagementUtilities
    {
        public static RecoveryServicesBackupClient GetBackupClient(this TestHelper testHelper, MockContext context)
        {
            return context.GetServiceClient<RecoveryServicesBackupClient>();
        }

        public static RecoveryServicesClient GetVaultClient(this TestHelper testHelper, MockContext context)
        {
            return context.GetServiceClient<RecoveryServicesClient>();
        }

        public static ResourceManagementClient GetResourcesClient(this TestHelper testHelper, MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>();
        }
    }
}
