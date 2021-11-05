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
    using Index = Microsoft.Azure.Search.Models.Index;

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
        public void ConstructorSetsUrlRelatedProperties()
        {
            const string TestServiceName = "azs-doesnotexist";
            const string TestIndexName = "test-index";
            const string TestApiKey = "123";

            var indexClient = new SearchIndexClient(TestServiceName, TestIndexName, new SearchCredentials(TestApiKey));

            Assert.Equal(TestServiceName, indexClient.SearchServiceName);
            Assert.Equal(TestIndexName, indexClient.IndexName);
            Assert.Equal("search.windows.net", indexClient.SearchDnsSuffix);
            Assert.Equal(TestApiKey, indexClient.SearchCredentials.ApiKey);
        }

        [Fact]
        public void CanChangeIndexAfterConstructionWithoutServiceName()
        {
            Run(() =>
            {
                SearchServiceClient serviceClient = Data.GetSearchServiceClient();
                Index index = serviceClient.Indexes.Get(Data.IndexName);

                // Make sure first index works.
                SearchIndexClient indexClient = Data.GetSearchIndexClient();
                indexClient.Documents.Count();

                // Delete the first index so we know we're not accidentally using it below.
                serviceClient.Indexes.Delete(Data.IndexName);

                // Create a second index.
                string newIndexName = index.Name + "2";
                index.Name = newIndexName;

                serviceClient.Indexes.Create(index);

                // Target the second index and make sure it works too.
                indexClient.IndexName = newIndexName;
                indexClient.Documents.Count();
            });
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
        }
    }
}
