// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Maps.Search.Tests
{
    public class SearchClientTestEnvironment : TestEnvironment
    {
        public MapsSearchClient CreateClient()
        {
            var subscriptionKey = System.Environment.GetEnvironmentVariable("MAPS_SUBSCRIPTION_KEY") ?? "<My Subscription Key>";
            return new MapsSearchClient(new AzureKeyCredential(subscriptionKey));
        }
    }
}
