// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.RecoveryServices;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Tests
{
    public static class ClientManagementUtilities
    {
        public static SiteRecoveryManagementClient GetSiteRecoveryClient(this TestHelper testHelper, MockContext context)
        {
            return context.GetServiceClient<SiteRecoveryManagementClient>();
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
