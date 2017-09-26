// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace MarketplaceOrdering.Tests.Helpers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.MarketplaceOrdering;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Newtonsoft.Json;
    using System.Security.Cryptography;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Serialization;
    using Newtonsoft.Json.Converters;

    public static class MarketplaceOrderingHelper
    {
        public static MarketplaceOrderingAgreementsClient GetMarketplaceOrderingAgreementsClient(MockContext context, RecordedDelegatingHandler handler)
        {
            if (handler != null)
            {
                handler.IsPassThrough = true;
                MarketplaceOrderingAgreementsClient marketplaceOrderingAgreementsClient = context.GetServiceClient<MarketplaceOrderingAgreementsClient>(handlers: handler);
                return marketplaceOrderingAgreementsClient;
            }

            return null;
        }
    }
}