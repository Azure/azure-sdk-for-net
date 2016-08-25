// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using System.Net;
    using System.Net.Http;
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

                Assert.Equal(options.ClientRequestId.Value.ToString("D"), listResponse.RequestId);
            });
        }

        [Fact]
        public void CanGetAnIndexClient()
        {
            Run(() =>
            {
                SearchServiceClient serviceClient = Data.GetSearchServiceClient();
                ISearchIndexClient indexClient = serviceClient.Indexes.GetClient("test");

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

        [Fact]
        public void ConstructorThrowsForBadParameters()
        {
            var creds = new SearchCredentials("abc");
            var searchServiceName = "abc";
            var handler = new HttpClientHandler();
            var uri = new Uri("http://tempuri.org");
            var invalidName = ")#%&/?''+&@)#*@%#";

            Assert.Throws<ArgumentNullException>("credentials", () => new SearchServiceClient(credentials: null));
            Assert.Throws<ArgumentNullException>(
                "searchServiceName", 
                () => new SearchServiceClient(searchServiceName: null, credentials: creds));
            Assert.Throws<ArgumentException>(
                "searchServiceName",
                () => new SearchServiceClient(searchServiceName: String.Empty, credentials: creds));
            Assert.Throws<ArgumentException>(
                "searchServiceName",
                () => new SearchServiceClient(searchServiceName: invalidName, credentials: creds));
            Assert.Throws<ArgumentNullException>(
                "credentials",
                () => new SearchServiceClient(searchServiceName, credentials: null));
            Assert.Throws<ArgumentNullException>(
                "credentials",
                () => new SearchServiceClient(credentials: null, rootHandler: handler));
            Assert.Throws<ArgumentNullException>(() => new SearchServiceClient(credentials: creds, rootHandler: null));
            Assert.Throws<ArgumentNullException>(
                "baseUri",
                () => new SearchServiceClient(baseUri: null, credentials: creds));
            Assert.Throws<ArgumentNullException>("credentials", () => new SearchServiceClient(uri, credentials: null));
            Assert.Throws<ArgumentNullException>(
                "searchServiceName", 
                () => new SearchServiceClient(searchServiceName: null, credentials: creds, rootHandler: handler));
            Assert.Throws<ArgumentException>(
                "searchServiceName",
                () => new SearchServiceClient(searchServiceName: String.Empty, credentials: creds, rootHandler: handler));
            Assert.Throws<ArgumentException>(
                "searchServiceName",
                () => new SearchServiceClient(searchServiceName: invalidName, credentials: creds, rootHandler: handler));
            Assert.Throws<ArgumentNullException>(
                "credentials",
                () => new SearchServiceClient(searchServiceName, credentials: null, rootHandler: handler));
            Assert.Throws<ArgumentNullException>(
                () => new SearchServiceClient(searchServiceName, creds, rootHandler: null));
            Assert.Throws<ArgumentNullException>(
                "baseUri",
                () => new SearchServiceClient(baseUri: null, credentials: creds, rootHandler: handler));
            Assert.Throws<ArgumentNullException>(
                "credentials",
                () => new SearchServiceClient(uri, credentials: null, rootHandler: handler));
            Assert.Throws<ArgumentNullException>(() => new SearchServiceClient(uri, creds, rootHandler: null));
        }
    }
}
