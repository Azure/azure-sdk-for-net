// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.VoiceServices.Tests.Tests
{
    [TestFixture]
    public class ListCommunicationsGatewaysTests : VoiceServicesManagementTestBase
    {
        private ResourceGroupResource _rg;

        public ListCommunicationsGatewaysTests() : base(true/*, RecordedTestMode.Record*/)
        {
        }

        [SetUp]
        public async Task CreateCommunicationsGateway()
        {
            _rg = await CreateResourceGroup();
            var resourceName = Recording.GenerateAssetName("SDKTest");
            var createOperation = await _rg.GetVoiceServicesCommunicationsGateways().CreateOrUpdateAsync(WaitUntil.Completed, resourceName, GetDefaultCommunicationsGatewayData());
            await createOperation.WaitForCompletionAsync();
        }

        [TestCase, Order(1)]
        public async Task TestListCommunicationsGatewaysAtSubscriptionLevel()
        {
            var communicationsGateways = Subscription.GetVoiceServicesCommunicationsGatewaysAsync();
            var comminicationsGatewaysResult = await communicationsGateways.ToEnumerableAsync();

            Assert.NotNull(comminicationsGatewaysResult);
            Assert.IsTrue(comminicationsGatewaysResult.Count >= 1);
        }

        [TestCase, Order(2)]
        public async Task TestListCommunicationsGatewaysAtResourceGroupLevel()
        {
            var communicationsGateways = _rg.GetVoiceServicesCommunicationsGateways().GetAllAsync();
            var communicationsGatewaysResult = await communicationsGateways.ToEnumerableAsync();

            Assert.NotNull(communicationsGatewaysResult);

            // Filter the result for entries in our resource group
            var filteredCommunicationsGateways = communicationsGatewaysResult.Where(cg => cg.Id.ResourceGroupName == _rg.Id.ResourceGroupName);

            // Check that we have at least one (we should at a minimum have the one we added in SetUp)
            Assert.IsTrue(filteredCommunicationsGateways.Count() >= 1);
        }
    }
}
