// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.ResourceManager.Automanage.Tests.Scenario
{
    internal class ServicePrincipalTests : AutomanageTestBase
    {
        public ServicePrincipalTests(bool async) : base(async, Core.TestFramework.RecordedTestMode.Record)
        {
            JsonPathSanitizers.Add("$..servicePrincipalId");
        }

        [TestCase]
        public async Task CanGetServicePrincipal()
        {
            var subscription = await ArmClient.GetDefaultSubscriptionAsync();
            var servicePrincipal = await subscription.GetServicePrincipalAsync();
            Assert.IsNotNull(servicePrincipal);
        }

        [TestCase]
        public async Task CanListServicePrincipal()
        {
            var subscription = await ArmClient.GetDefaultSubscriptionAsync();
            int cnt = 0;
            await foreach (var servicePrincipal in subscription.GetServicePrincipalsAsync())
            {
                ++cnt;
            }
            Assert.GreaterOrEqual(cnt, 0);
        }
    }
}
