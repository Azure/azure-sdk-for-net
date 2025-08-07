// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.SelfHelp.Tests
{
    using Azure.Core.TestFramework;
    using Azure.Core;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using System;
    using Azure.ResourceManager.SelfHelp.Models;
    using System.Collections.Generic;
    using System.Linq;

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
