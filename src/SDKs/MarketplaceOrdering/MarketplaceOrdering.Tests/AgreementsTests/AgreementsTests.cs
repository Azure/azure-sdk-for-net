// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace MarketplaceOrdering.Tests.AgreementsTests
{
    using System.Net;
    using Microsoft.Azure.Management.MarketplaceOrdering;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using MarketplaceOrdering.Tests.Helpers;

    public partial class ScenarioTests 
    {
        private MarketplaceOrderingAgreementsClient _MarketplaceOrderingAgreementsClient;
        private RecordedDelegatingHandler handler = new RecordedDelegatingHandler();

        protected bool m_initialized = false;
        protected object m_lock = new object();
        public string PublisherId { get; set; }
        public string OfferId { get; set; }
        public string PlanId { get; set; }
               

        protected void InitializeClients(MockContext context)
        {
            if (!m_initialized)
            {
                lock (m_lock)
                {
                    if (!m_initialized)
                    {
                        _MarketplaceOrderingAgreementsClient = MarketplaceOrderingHelper.GetMarketplaceOrderingAgreementsClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                        PublisherId = "microsoft-ads";
                        OfferId = "windows-data-science-vm";
                        PlanId = "windows2016";
                    }
                }
            }
        }

        public MarketplaceOrderingAgreementsClient MarketplaceOrderingAgreementsClient
        {
            get
            {               
                return _MarketplaceOrderingAgreementsClient;
            }
        }       
    }
}
