// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Education.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Education.Tests.Scenario
{
    public class GrantDetailsResourceTests : EducationManagementTestBase
    {
        public GrantDetailsResourceTests(bool isAsync)
            : base(isAsync)
        {
        }

        // Issues a real GET against the tenant-scoped grant "default" endpoint and verifies
        // the response deserializes into the expected resource data.
        [RecordedTest]
        public async Task GetGrantDetails()
        {
            ResourceIdentifier id = GrantDetailsResource.CreateResourceIdentifier("myBillingAccount", "myBillingProfile");
            GrantDetailsResource grant = Client.GetGrantDetailsResource(id);

            GrantDetailsResource result = await grant.GetAsync(includeAllocatedBudget: true);

            Assert.That(result.Data.Name, Is.EqualTo("default"));
            Assert.That(result.Data.Id.ResourceType.ToString(), Is.EqualTo("Microsoft.Education/grants"));
            Assert.That(result.Data.OfferType, Is.EqualTo(GrantType.Student));
            Assert.That(result.Data.OfferCap.Currency, Is.EqualTo("USD"));
            Assert.That(result.Data.OfferCap.Value, Is.EqualTo(100f));
        }
    }
}
