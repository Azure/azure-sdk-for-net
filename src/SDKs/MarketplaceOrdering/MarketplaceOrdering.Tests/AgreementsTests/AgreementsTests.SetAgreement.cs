// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace MarketplaceOrdering.Tests.AgreementsTests
{
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;
    using Microsoft.Azure.Management.MarketplaceOrdering.Models;
    using Microsoft.Azure.Management.MarketplaceOrdering;

    public partial class ScenarioTests
    {
        [Fact]
        public void SetMarketplaceOrderingTerms()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                InitializeClients(context);

                //get legal terms
                AgreementTerms marketplaceOrderingTerms = this.MarketplaceOrderingAgreementsClient.MarketplaceAgreements.Get(PublisherId, OfferId, PlanId);
                Assert.NotNull(marketplaceOrderingTerms);
                Assert.NotNull(marketplaceOrderingTerms.LicenseTextLink);
                Assert.NotNull(marketplaceOrderingTerms.PrivacyPolicyLink);
                Assert.NotNull(marketplaceOrderingTerms.Signature);

                //accept legal terms
                marketplaceOrderingTerms.Accepted = true;

                //save legal terms
                AgreementTerms newMarketplaceOrderingTerms = this.MarketplaceOrderingAgreementsClient.MarketplaceAgreements.Create(PublisherId, OfferId, PlanId, marketplaceOrderingTerms);
                Assert.NotNull(newMarketplaceOrderingTerms);
                Assert.NotNull(newMarketplaceOrderingTerms.LicenseTextLink);
                Assert.NotNull(newMarketplaceOrderingTerms.PrivacyPolicyLink);
                Assert.NotNull(newMarketplaceOrderingTerms.Signature);

                //check that new legal terms are accepted
                Assert.True(newMarketplaceOrderingTerms.Accepted);
            }
        }
    }
}
