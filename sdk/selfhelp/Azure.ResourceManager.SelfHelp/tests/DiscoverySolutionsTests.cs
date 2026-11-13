// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.SelfHelp.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Azure.Core;
    using Azure.Core.TestFramework;
    using Azure.ResourceManager.SelfHelp.Models;
    using NUnit.Framework;

    public class DiscoverySolutionsTests : SelfHelpManagementTestBase
    {
        public DiscoverySolutionsTests(bool isAsync) : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [Test]
        public async Task ListDisocverySolutionsTest()
        {
            var listDisocverySolutionsData = DefaultTenantResource.DiscoverSolutionsAsync("ProblemClassificationId eq 'a93e16a3-9f43-a003-6ac0-e5f6caa90cb9'");
            var response = await listDisocverySolutionsData.ToEnumerableAsync();
            Assert.NotNull(response.First());
        }
    }
}
