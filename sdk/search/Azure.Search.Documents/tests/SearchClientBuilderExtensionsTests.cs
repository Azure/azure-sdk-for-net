// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using Azure.Core;
using Azure.Core.Extensions;
using Azure.Identity;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.KnowledgeBases;
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

        [TestCase(false)]
        [TestCase(true)]
        public void ApiKeyOverloadsRegisterClients(bool useCompatibilityType)
        {
            var builder = new TestClientFactoryBuilder();
            var endpoint = new Uri("https://example.search.windows.net");
            var credential = new AzureKeyCredential("fake-key");

            var searchRegistration = useCompatibilityType
                ? DocumentsClientBuilderExtensions.AddSearchClient(builder, endpoint, "index", credential)
                : SearchClientBuilderExtensions.AddSearchClient(builder, endpoint, "index", credential);
            Assert.That(builder.RegisteredClient, Is.TypeOf<SearchClient>());
            Assert.That(searchRegistration, Is.SameAs(builder.RegisteredBuilder));
            Assert.That(((SearchClient)builder.RegisteredClient).IndexName, Is.EqualTo("index"));

            var indexRegistration = useCompatibilityType
                ? DocumentsClientBuilderExtensions.AddSearchIndexClient(builder, endpoint, credential)
                : SearchClientBuilderExtensions.AddSearchIndexClient(builder, endpoint, credential);
            Assert.That(builder.RegisteredClient, Is.TypeOf<SearchIndexClient>());
            Assert.That(indexRegistration, Is.SameAs(builder.RegisteredBuilder));
            Assert.That(((SearchIndexClient)builder.RegisteredClient).Endpoint, Is.EqualTo(endpoint));

            var indexerRegistration = useCompatibilityType
                ? DocumentsClientBuilderExtensions.AddSearchIndexerClient(builder, endpoint, credential)
                : SearchClientBuilderExtensions.AddSearchIndexerClient(builder, endpoint, credential);
            Assert.That(builder.RegisteredClient, Is.TypeOf<SearchIndexerClient>());
            Assert.That(indexerRegistration, Is.SameAs(builder.RegisteredBuilder));
            Assert.That(((SearchIndexerClient)builder.RegisteredClient).Endpoint, Is.EqualTo(endpoint));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void ConfigurationOverloadsPreserveRegistration(bool useCompatibilityType)
        {
            var builder = new TestClientFactoryBuilder();
            var configuration = new object();

            var searchRegistration = useCompatibilityType
                ? DocumentsClientBuilderExtensions.AddSearchClient(builder, configuration)
                : SearchClientBuilderExtensions.AddSearchClient(builder, configuration);
            Assert.That(builder.RegisteredClientType, Is.EqualTo(typeof(SearchClient)));
            Assert.That(builder.RegisteredConfiguration, Is.SameAs(configuration));
            Assert.That(searchRegistration, Is.SameAs(builder.RegisteredBuilder));

            var indexRegistration = useCompatibilityType
                ? DocumentsClientBuilderExtensions.AddSearchIndexClient(builder, configuration)
                : SearchClientBuilderExtensions.AddSearchIndexClient(builder, configuration);
            Assert.That(builder.RegisteredClientType, Is.EqualTo(typeof(SearchIndexClient)));
            Assert.That(builder.RegisteredConfiguration, Is.SameAs(configuration));
            Assert.That(indexRegistration, Is.SameAs(builder.RegisteredBuilder));

            var indexerRegistration = useCompatibilityType
                ? DocumentsClientBuilderExtensions.AddSearchIndexerClient(builder, configuration)
                : SearchClientBuilderExtensions.AddSearchIndexerClient(builder, configuration);
            Assert.That(builder.RegisteredClientType, Is.EqualTo(typeof(SearchIndexerClient)));
            Assert.That(builder.RegisteredConfiguration, Is.SameAs(configuration));
            Assert.That(indexerRegistration, Is.SameAs(builder.RegisteredBuilder));
        }

        [Test]
        public void BuilderCredentialExtensionsRemainUnambiguous()
        {
            var builder = new TestClientFactoryBuilder();
            var endpoint = new Uri("https://example.search.windows.net");

            builder.AddSearchClient(endpoint, "index");
            Assert.That(builder.RegisteredClient, Is.TypeOf<SearchClient>());

            builder.AddSearchIndexClient(endpoint);
            Assert.That(builder.RegisteredClient, Is.TypeOf<SearchIndexClient>());

            builder.AddSearchIndexerClient(endpoint);
            Assert.That(builder.RegisteredClient, Is.TypeOf<SearchIndexerClient>());
        }

        [Test]
        public void KnowledgeBaseExtensionsRemainUnambiguous()
        {
            var builder = new TestClientFactoryBuilder();
            var endpoint = new Uri("https://example.search.windows.net");

            var keyRegistration = builder.AddKnowledgeBaseRetrievalClient(endpoint, "knowledge-base", new AzureKeyCredential("fake-key"));
            Assert.That(builder.RegisteredClient, Is.TypeOf<KnowledgeBaseRetrievalClient>());
            Assert.That(keyRegistration, Is.SameAs(builder.RegisteredBuilder));

            var tokenRegistration = builder.AddKnowledgeBaseRetrievalClient(endpoint, "knowledge-base");
            Assert.That(builder.RegisteredClient, Is.TypeOf<KnowledgeBaseRetrievalClient>());
            Assert.That(tokenRegistration, Is.SameAs(builder.RegisteredBuilder));

            var configuration = new object();
            var configurationRegistration = builder.AddKnowledgeBaseRetrievalClient(configuration);
            Assert.That(builder.RegisteredClientType, Is.EqualTo(typeof(KnowledgeBaseRetrievalClient)));
            Assert.That(builder.RegisteredConfiguration, Is.SameAs(configuration));
            Assert.That(configurationRegistration, Is.SameAs(builder.RegisteredBuilder));
        }

        [Test]
        public void CompatibilityTypeAndMembersAreHiddenWithoutLosingExtensionMetadata()
        {
            Type compatibilityType = typeof(DocumentsClientBuilderExtensions);
            Assert.That(compatibilityType.GetCustomAttribute<EditorBrowsableAttribute>()?.State, Is.EqualTo(EditorBrowsableState.Never));

            MethodInfo[] methods = compatibilityType.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
            Assert.That(methods.Length, Is.EqualTo(12));
            foreach (MethodInfo method in methods)
            {
                Assert.That(method.GetCustomAttribute<EditorBrowsableAttribute>()?.State, Is.EqualTo(EditorBrowsableState.Never), method.Name);
                Assert.That(method.IsDefined(typeof(ExtensionAttribute), false), Is.True, method.Name);
            }
        }

        private sealed class TestClientFactoryBuilder :
            IAzureClientFactoryBuilderWithConfiguration<object>,
            IAzureClientFactoryBuilderWithCredential
        {
            public object RegisteredClient { get; private set; }
            public object RegisteredBuilder { get; private set; }
            public Type RegisteredClientType { get; private set; }
            public object RegisteredConfiguration { get; private set; }

            public IAzureClientBuilder<TClient, TOptions> RegisterClientFactory<TClient, TOptions>(
                Func<TOptions, TokenCredential, TClient> clientFactory,
                bool requiresCredential = true)
                where TOptions : class =>
                RegisterClientFactory<TClient, TOptions>(options => clientFactory(options, new DefaultAzureCredential()));

            public IAzureClientBuilder<TClient, TOptions> RegisterClientFactory<TClient, TOptions>(object configuration)
                where TOptions : class
            {
                Assert.That(typeof(TOptions), Is.EqualTo(typeof(SearchClientOptions)));
                RegisteredClientType = typeof(TClient);
                RegisteredConfiguration = configuration;
                return CreateRegistration<TClient, TOptions>();
            }

            public IAzureClientBuilder<TClient, TOptions> RegisterClientFactory<TClient, TOptions>(
                Func<TOptions, TClient> clientFactory)
                where TOptions : class
            {
                Assert.That(typeof(TOptions), Is.EqualTo(typeof(SearchClientOptions)));
                TOptions options = (TOptions)(object)new SearchClientOptions();
                RegisteredClient = clientFactory(options);
                return CreateRegistration<TClient, TOptions>();
            }

            private IAzureClientBuilder<TClient, TOptions> CreateRegistration<TClient, TOptions>()
                where TOptions : class
            {
                var registration = new TestAzureClientBuilder<TClient, TOptions>();
                RegisteredBuilder = registration;
                return registration;
            }
        }

        private sealed class TestAzureClientBuilder<TClient, TOptions> : IAzureClientBuilder<TClient, TOptions>
            where TOptions : class
        {
        }
    }
}
