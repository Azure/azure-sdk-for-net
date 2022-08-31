// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.ResourceManager.Automanage.Tests.Scenario
{
    internal class BestPracticeTests : AutomanageTestBase
    {
        public BestPracticeTests(bool async) : base(async) { }

        [TestCase]
        public async Task CanGetBestPracticeProfileInfo()
        {
            // create resource group
            var rg = await CreateResourceGroup(Subscription, "SDKAutomanage-", DefaultLocation);
        }
    }
}
