// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace MarketplaceOrdering.Tests.AgreementsTests
{
    using Microsoft.Azure.Management.MarketplaceOrdering;
    using Microsoft.Azure.Management.MarketplaceOrdering.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;
    public partial class ScenarioTests
    {
        [Fact]
        public void GetMarketplaceOrderingTerms()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                InitializeClients(context);

                AgreementTerms marketplaceOrderingTerms = this.MarketplaceOrderingAgreementsClient.MarketplaceAgreements.Get(PublisherId, OfferId, PlanId);
                Assert.NotNull(marketplaceOrderingTerms);
                Assert.NotNull(marketplaceOrderingTerms.LicenseTextLink);
                Assert.NotNull(marketplaceOrderingTerms.PrivacyPolicyLink);
                Assert.NotNull(marketplaceOrderingTerms.Signature);
            }
        }
    }
}
