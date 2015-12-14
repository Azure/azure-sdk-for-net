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

    public sealed class SearchServiceClientTests : SearchTestBase<SearchServiceFixture>
    {
        [Fact]
        public void RequestIdIsReturnedInResponse()
        {
            Run(() =>
            {
                SearchServiceClient client = Data.GetSearchServiceClient();
                
                // We need to use a constant GUID so that this test will still work in playback mode.
                var options = new SearchRequestOptions(new Guid("c4cfce79-eb42-4e61-9909-84510c04706f"));

                AzureOperationResponse<IndexListResult> listResponse =
                    client.Indexes.ListWithHttpMessagesAsync(searchRequestOptions: options).Result;
                Assert.Equal(HttpStatusCode.OK, listResponse.Response.StatusCode);

                Assert.Equal(options.RequestId.Value.ToString("D"), listResponse.RequestId);
            });
        }

        [Fact]
        public void CanGetAnIndexClient()
        {
            Run(() =>
            {
                SearchServiceClient serviceClient = Data.GetSearchServiceClient();
                SearchIndexClient indexClient = serviceClient.Indexes.GetClient("test");

                Assert.Equal(serviceClient.SearchCredentials.ApiKey, indexClient.SearchCredentials.ApiKey);
                Assert.Equal(new Uri(serviceClient.BaseUri, "/indexes('test')"), indexClient.BaseUri);
            });
        }

        [Fact]
        public void CanGetAnIndexClientAfterUsingServiceClient()
        {
            Run(() =>
            {
                SearchServiceClient serviceClient = Data.GetSearchServiceClient();
                serviceClient.Indexes.Delete("thisindexdoesnotexist");

                // Should not throw.
                serviceClient.Indexes.GetClient("test");
            });
        }
    }
}
