// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Education.Tests.Scenario
{
    public class GrantDetailsResourceTests : EducationManagementTestBase
    {
        public GrantDetailsResourceTests(bool isAsync)
            : base(isAsync)
        {
        }

        // Lists Education grants at tenant scope end to end. Tenants with no grants get an
        // empty page, which is still a valid service round-trip to record and replay.
        [RecordedTest]
        public async Task ListGrantsAtTenantScope()
        {
            TenantResource tenant = await GetTenantAsync();

            List<GrantDetailsResource> grants = await tenant.GetAllAsync(includeAllocatedBudget: true).ToEnumerableAsync();

            Assert.That(grants, Is.Not.Null);
        }
    }
}
