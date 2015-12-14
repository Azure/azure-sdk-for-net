// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using System.Globalization;
    using System.Net;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Azure.Search.Tests.Utilities;
    using Microsoft.Rest.Azure;
    using Xunit;

    public sealed class SearchIndexClientTests : SearchTestBase<IndexFixture>
    {
        [Fact]
        public void RequestIdIsReturnedInResponse()
        {
            Run(() =>
            {
                SearchIndexClient client = Data.GetSearchIndexClient();

                // We need to use a constant GUID so that this test will still work in playback mode.
                var options = new SearchRequestOptions(new Guid("c4cfce79-eb42-4e61-9909-84510c04706f"));

                AzureOperationResponse<long?> countResponse = 
                    client.Documents.CountWithHttpMessagesAsync(options).Result;
                Assert.Equal(HttpStatusCode.OK, countResponse.Response.StatusCode);

                Assert.Equal(options.RequestId.Value.ToString("D"), countResponse.RequestId);
            });
        }
    }
}
