// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Extensions;
using Azure.Identity;
using Azure.Search.Documents.Indexes;
using Microsoft.Extensions.Azure;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    public class SearchClientBuilderExtensionsTests
    {
        [Test]
        public void TokenCredentialOverloadsRegisterClients()
        {
            var builder = new TestClientFactoryBuilder();
            var endpoint = new Uri("https://example.search.windows.net");
            var credential = new DefaultAzureCredential();

            SearchClientBuilderExtensions.AddSearchClient(builder, endpoint, "index", credential);
            Assert.That(builder.RegisteredClient, Is.TypeOf<SearchClient>());

            SearchClientBuilderExtensions.AddSearchIndexClient(builder, endpoint, credential);
            Assert.That(builder.RegisteredClient, Is.TypeOf<SearchIndexClient>());

            SearchClientBuilderExtensions.AddSearchIndexerClient(builder, endpoint, credential);
            Assert.That(builder.RegisteredClient, Is.TypeOf<SearchIndexerClient>());
        }

        private sealed class TestClientFactoryBuilder : IAzureClientFactoryBuilder
        {
            public object RegisteredClient { get; private set; }

            public IAzureClientBuilder<TClient, TOptions> RegisterClientFactory<TClient, TOptions>(
                Func<TOptions, TClient> clientFactory)
                where TOptions : class
            {
                Assert.That(typeof(TOptions), Is.EqualTo(typeof(SearchClientOptions)));
                TOptions options = (TOptions)(object)new SearchClientOptions();
                RegisteredClient = clientFactory(options);
                return new TestAzureClientBuilder<TClient, TOptions>();
            }
        }

        private sealed class TestAzureClientBuilder<TClient, TOptions> : IAzureClientBuilder<TClient, TOptions>
            where TOptions : class
        {
        }
    }
}
