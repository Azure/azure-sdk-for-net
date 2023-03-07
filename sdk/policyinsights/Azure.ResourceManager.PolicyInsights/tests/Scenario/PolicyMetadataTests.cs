// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.PolicyInsights.Models;

namespace Azure.ResourceManager.PolicyInsights.Tests
{
    internal class PolicyMetadataTests : PolicyInsightsManagementTestBase
    {
        public PolicyMetadataTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var collection = DefaultTenant.GetAllPolicyMetadata();
            var query = new PolicyQuerySettings()
            {
                Top = 1,
            };
            var list = await collection.GetAllAsync(query).ToEnumerableAsync();
        }
    }
}
