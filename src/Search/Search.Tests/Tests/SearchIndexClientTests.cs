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

                AzureOperationResponse<long> countResponse = 
                    client.Documents.CountWithHttpMessagesAsync(options).Result;
                Assert.Equal(HttpStatusCode.OK, countResponse.Response.StatusCode);

                Assert.Equal(options.ClientRequestId.Value.ToString("D"), countResponse.RequestId);
            });
        }

        [Fact]
        public void ConstructorCreatesCorrectUrl()
        {
            const string ExpectedUrl = "https://azs-test.search.windows.net/indexes('test')/";

            var client = new SearchIndexClient("azs-test", "test", new SearchCredentials("abc"));
            Assert.Equal(ExpectedUrl, client.BaseUri.AbsoluteUri);

            client = new SearchIndexClient("azs-test", "test", new SearchCredentials("abc"), new HttpClientHandler());
            Assert.Equal(ExpectedUrl, client.BaseUri.AbsoluteUri);
        }

        [Fact]
        public void ConstructorThrowsForBadParameters()
        {
            var creds = new SearchCredentials("abc");
            var searchServiceName = "abc";
            var indexName = "xyz";
            var handler = new HttpClientHandler();
            var uri = new Uri("http://tempuri.org");
            var invalidName = ")#%&/?''+&@)#*@%#";

            Assert.Throws<ArgumentNullException>("credentials", () => new SearchIndexClient(credentials: null));
            Assert.Throws<ArgumentNullException>(
                "searchServiceName",
                () => new SearchIndexClient(searchServiceName: null, indexName: indexName, credentials: creds));
            Assert.Throws<ArgumentException>(
                "searchServiceName",
                () => new SearchIndexClient(searchServiceName: String.Empty, indexName: indexName, credentials: creds));
            Assert.Throws<ArgumentException>(
                "searchServiceName",
                () => new SearchIndexClient(searchServiceName: invalidName, indexName: indexName, credentials: creds));
            Assert.Throws<ArgumentNullException>(
                "indexName",
                () => new SearchIndexClient(searchServiceName, indexName: null, credentials: creds));
            Assert.Throws<ArgumentException>(
                "indexName",
                () => new SearchIndexClient(searchServiceName, indexName: String.Empty, credentials: creds));
            Assert.Throws<ArgumentNullException>(
                "credentials",
                () => new SearchIndexClient(searchServiceName, indexName, credentials: null));
            Assert.Throws<ArgumentNullException>(
                "credentials",
                () => new SearchIndexClient(credentials: null, rootHandler: handler));
            Assert.Throws<ArgumentNullException>(() => new SearchIndexClient(credentials: creds, rootHandler: null));
            Assert.Throws<ArgumentNullException>(
                "baseUri",
                () => new SearchIndexClient(baseUri: null, credentials: creds));
            Assert.Throws<ArgumentNullException>("credentials", () => new SearchIndexClient(uri, credentials: null));
            Assert.Throws<ArgumentNullException>(
                "searchServiceName",
                () => new SearchIndexClient(searchServiceName: null, indexName: indexName, credentials: creds, rootHandler: handler));
            Assert.Throws<ArgumentException>(
                "searchServiceName",
                () => new SearchIndexClient(searchServiceName: String.Empty, indexName: indexName, credentials: creds, rootHandler: handler));
            Assert.Throws<ArgumentException>(
                "searchServiceName",
                () => new SearchIndexClient(searchServiceName: invalidName, indexName: indexName, credentials: creds, rootHandler: handler));
            Assert.Throws<ArgumentNullException>(
                "indexName",
                () => new SearchIndexClient(searchServiceName, indexName: null, credentials: creds, rootHandler: handler));
            Assert.Throws<ArgumentException>(
                "indexName",
                () => new SearchIndexClient(searchServiceName, indexName: String.Empty, credentials: creds, rootHandler: handler));
            Assert.Throws<ArgumentNullException>(
                "credentials",
                () => new SearchIndexClient(searchServiceName, indexName, credentials: null, rootHandler: handler));
            Assert.Throws<ArgumentNullException>(
                () => new SearchIndexClient(searchServiceName, indexName, creds, rootHandler: null));
            Assert.Throws<ArgumentNullException>(
                "baseUri",
                () => new SearchIndexClient(baseUri: null, credentials: creds, rootHandler: handler));
            Assert.Throws<ArgumentNullException>(
                "credentials",
                () => new SearchIndexClient(uri, credentials: null, rootHandler: handler));
            Assert.Throws<ArgumentNullException>(() => new SearchIndexClient(uri, creds, rootHandler: null));
        }
    }
}
