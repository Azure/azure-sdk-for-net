// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Maps.Search;
using System.Linq;

namespace Azure.Maps.Search.Tests
{
    public class SearchClientLiveTests: RecordedTestBase<SearchClientTestEnvironment>
    {
        public SearchClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        private SearchClient CreateClient()
        {
            return InstrumentClient(new SearchClient(
                endpoint: new Uri(TestEnvironment.Endpoint),
                credential: TestEnvironment.Credential,
                clientId: null,
                options: InstrumentClientOptions(new SearchClientOptions())
            ));
        }

        [RecordedTest]
        public async Task CanSearchAddress()
        {
            var client = CreateClient();
            var searchResult = await client.SearchAddressAsync("Seattle");
            Assert.AreEqual("Washington", searchResult.Value.Results.First()?.Address?.CountrySubdivisionName);
        }
    }
}
