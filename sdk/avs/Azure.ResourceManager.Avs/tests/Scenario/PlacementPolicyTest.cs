// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Avs.Tests.Scenario
{
    public class PlacementPolicyTest: AvsManagementTestBase
    {
        public PlacementPolicyTest(bool isAsync) : base(isAsync)
        {
        }

        protected async Task<PlacementPolicyCollection> GetPlacementPolicyCollectionAsync()
        {
            var privateCloudClusterResource = await getAvsPrivateCloudClusterResource();
            var policies = privateCloudClusterResource.GetPlacementPolicies();
            return policies;
        }
    }
}
