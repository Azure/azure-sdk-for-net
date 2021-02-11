// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Microsoft.Azure.Management.Migrate.ResourceMover.Tests
{
    public static class ClientManagementUtilities
    {
        public static IResourceMoverServiceAPIClient GetResourceMoverServiceClient(
            this TestHelper testHelper,
            MockContext context)
        {
            return context.GetServiceClient<ResourceMoverServiceAPIClient>();
        }
    }
}
