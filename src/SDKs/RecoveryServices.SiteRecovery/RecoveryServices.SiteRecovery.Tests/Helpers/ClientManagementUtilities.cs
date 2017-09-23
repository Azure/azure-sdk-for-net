// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.RecoveryServices.SiteRecovery;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace RecoveryServices.SiteRecovery.Tests
{
    public static class ClientManagementUtilities
    {
        public static SiteRecoveryManagementClient GetSiteRecoveryClient(this TestHelper testHelper, MockContext context)
        {
            return context.GetServiceClient<SiteRecoveryManagementClient>();
        }
    }
}
