// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Migrate;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Migrate.RegionMove.Tests
{
    public static class ClientManagementUtilities
    {
        public static IRegionMoveServiceAPIClient GetRegionMoveServiceClient(this TestHelper testHelper, MockContext context)
        {
            return context.GetServiceClient<RegionMoveServiceAPIClient>();
        }
    }
}
