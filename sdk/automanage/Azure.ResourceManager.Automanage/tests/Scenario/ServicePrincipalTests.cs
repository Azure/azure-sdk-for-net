// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.ResourceManager.Automanage.Tests.Scenario
{
    internal class ServicePrincipalTests : AutomanageTestBase
    {
        public ServicePrincipalTests(bool async) : base(async) { }

        [TestCase]
        public async Task CanGetServicePrincipal()
        {
            // arrange
            string profileName = Recording.GenerateAssetName("SDKAutomanageProfile-");

            // act
            var rg = await CreateResourceGroup("SDKAutomanage-", DefaultLocation);
            var servicePrincipal = Subscription.GetServicePrincipal();

            // assert
            Assert.IsNotNull(servicePrincipal);
        }
    }
}
