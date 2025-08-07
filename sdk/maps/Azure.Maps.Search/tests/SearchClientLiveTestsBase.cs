// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Maps.Search.Tests
{
    public class SearchClientLiveTestsBase: RecordedTestBase<SearchClientTestEnvironment>
    {
        public SearchClientLiveTestsBase(bool isAsync) : base(isAsync)
        {
        }

        protected MapsSearchClient CreateClient()
        {
            var subscriptionKey = System.Environment.GetEnvironmentVariable("MAPS_SUBSCRIPTION_KEY") ?? "<My Subscription Key>";
            return InstrumentClient(new MapsSearchClient(
                credential: new AzureKeyCredential(subscriptionKey),
                options: InstrumentClientOptions(new MapsSearchClientOptions())
            ));
        }
    }
}
