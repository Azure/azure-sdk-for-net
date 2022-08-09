// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Linq;
using Azure.Core;

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
                endpoint: TestEnvironment.Endpoint,
                credential: TestEnvironment.Credential,
                clientId: TestEnvironment.MapAccountClientId,
                options: InstrumentClientOptions(new MapsSearchClientOptions())
            ));
        }
    }
}
