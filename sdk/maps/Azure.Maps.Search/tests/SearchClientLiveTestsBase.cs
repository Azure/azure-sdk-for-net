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
            return InstrumentClient(new MapsSearchClient(
                credential: TestEnvironment.Credential,
                clientId: TestEnvironment.MapAccountClientId,
                options: InstrumentClientOptions(new MapsSearchClientOptions())
            ));
        }
    }
}
