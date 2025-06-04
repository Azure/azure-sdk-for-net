// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.Core.TestFramework;

namespace Azure.ResourceManager.SelfHelp.Tests
{
    public class SelfHelpTests : SelfHelpManagementTestBase
    {
        public SelfHelpTests(bool isAsync) : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [Test]
        public async Task GetSelfHelpTest()
        {
            var solutionId = "apollo-48996ff7-002f-47c1-85b2-df138843d5d5";
            var selfHelpData = await DefaultTenantResource.GetSelfHelpSolutionByIdAsync(solutionId);

            Assert.IsNotNull(selfHelpData);
        }
    }
}
