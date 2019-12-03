// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace MarketplaceOrdering.Tests.ScenarioTests
{
    using System.Net;
    using Xunit;
    using Microsoft.Azure.Management.MarketplaceOrdering;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using MarketplaceOrdering.Tests.Helpers;
    using Microsoft.Azure.Management.MarketplaceOrdering.Models;

    public class AgreementsTests : TestBase 
    {
        const string Publisher = "microsoft-ads";
        const string Product = "windows-data-science-vm";
        const string Name = "windows2016";

        [Fact]
        public void GetMarketplaceOrderingTerms()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var marketplaceOrderingAgreementsClient = MarketplaceOrderingHelper.GetMarketplaceOrderingAgreementsClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                AgreementTerms marketplaceOrderingTerms = marketplaceOrderingAgreementsClient.MarketplaceAgreements.Get(Publisher, Product, Name);
                Assert.NotNull(marketplaceOrderingTerms);
                Assert.NotNull(marketplaceOrderingTerms.LicenseTextLink);
                Assert.NotNull(marketplaceOrderingTerms.PrivacyPolicyLink);
                Assert.NotNull(marketplaceOrderingTerms.Signature);
            }
        }

        [Fact]
        public void SetMarketplaceOrderingTerms()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var marketplaceOrderingAgreementsClient = MarketplaceOrderingHelper.GetMarketplaceOrderingAgreementsClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                //get legal terms
                AgreementTerms marketplaceOrderingTerms = marketplaceOrderingAgreementsClient.MarketplaceAgreements.Get(Publisher, Product, Name);
                Assert.NotNull(marketplaceOrderingTerms);
                Assert.NotNull(marketplaceOrderingTerms.LicenseTextLink);
                Assert.NotNull(marketplaceOrderingTerms.PrivacyPolicyLink);
                Assert.NotNull(marketplaceOrderingTerms.Signature);

                //accept legal terms
                marketplaceOrderingTerms.Accepted = true;

                //save legal terms
                AgreementTerms newMarketplaceOrderingTerms = marketplaceOrderingAgreementsClient.MarketplaceAgreements.Create(Publisher, Product, Name, marketplaceOrderingTerms);
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

