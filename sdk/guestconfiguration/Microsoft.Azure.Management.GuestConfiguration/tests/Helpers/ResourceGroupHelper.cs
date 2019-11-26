// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace GuestConfiguration.Tests.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Management.GuestConfiguration;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    public static class ResourceGroupHelper
    {

        public static GuestConfigurationClient GetGuestConfigurationClient(MockContext context, RecordedDelegatingHandler handler)
        {
            return context.GetServiceClient<GuestConfigurationClient>(false, handler);
        }

        public static ResourceManagementClient GetResourcesClient(MockContext context, RecordedDelegatingHandler handler)
        {
            return context.GetServiceClient<ResourceManagementClient>(false, handler);
        }
    }
}