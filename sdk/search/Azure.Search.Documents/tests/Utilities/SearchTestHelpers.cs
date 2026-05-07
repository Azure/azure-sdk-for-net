// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    /// <summary>
    /// Centralized helpers for type-completeness, mock, and serialization tests.
    /// </summary>
    internal static class SearchTestHelpers
    {
        /// <summary>
        /// The Search SDK assembly under test.
        /// </summary>
        public static Assembly SdkAssembly { get; } = typeof(SearchClient).Assembly;

        /// <summary>
        /// ModelReaderWriter wire-format options ("J" format).
        /// </summary>
        public static ModelReaderWriterOptions WireOptions { get; } = new ModelReaderWriterOptions("W");

        /// <summary>
        /// Discovers all public, non-abstract types in the Search SDK assembly that implement
        /// <see cref="IJsonModel{T}"/>, returning the model type T for each.
        /// </summary>
        public static IEnumerable<Type> DiscoverJsonModelTypes()
        {
            var jsonModelOpenType = typeof(IJsonModel<>);
            var seen = new HashSet<Type>();

            foreach (var type in SdkAssembly.GetExportedTypes()
                .Where(t => t.IsClass && !t.IsAbstract)
                .OrderBy(t => t.FullName))
            {
                var jsonModelInterface = type.GetInterfaces()
                    .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == jsonModelOpenType);

                if (jsonModelInterface != null)
                {
                    var modelType = jsonModelInterface.GetGenericArguments()[0];
                    if (seen.Add(modelType))
                    {
                        yield return modelType;
                    }
                }
            }
        }

        /// <summary>
        /// Discovers all public, non-abstract concrete subtypes of a given abstract base type
        /// within the Search SDK assembly.
        /// </summary>
        public static IEnumerable<Type> DiscoverConcreteSubtypes(Type baseType)
        {
            return SdkAssembly.GetExportedTypes()
                .Where(t => t.IsClass && !t.IsAbstract && baseType.IsAssignableFrom(t))
                .OrderBy(t => t.FullName);
        }

        /// <summary>
        /// All known abstract polymorphic base types in the Search SDK.
        /// Used by <see cref="PolymorphicRoundtripTests"/> to discover subtypes automatically.
        /// </summary>
        public static IReadOnlyList<Type> PolymorphicBaseTypes { get; } = new[]
        {
            typeof(LexicalAnalyzer),
            typeof(LexicalTokenizer),
            typeof(TokenFilter),
            typeof(CharFilter),
            typeof(ScoringFunction),
            typeof(SimilarityAlgorithm),
            typeof(CognitiveServicesAccount),
            typeof(DataChangeDetectionPolicy),
            typeof(DataDeletionDetectionPolicy),
            typeof(SearchIndexerSkill),
            typeof(SearchIndexerDataIdentity),
            typeof(VectorSearchAlgorithmConfiguration),
            typeof(VectorSearchCompression),
            typeof(VectorSearchVectorizer),
            typeof(VectorQuery),
        };

        /// <summary>
        /// Creates a <see cref="SearchClient"/> backed by a <see cref="MockTransport"/>
        /// that returns the provided mock responses.
        /// </summary>
        public static SearchClient CreateMockSearchClient(params MockResponse[] responses)
        {
            var transport = new MockTransport(responses);
            var options = new SearchClientOptions()
            {
                Transport = transport,
            };

            return new SearchClient(
                new Uri("https://fake-search.search.windows.net"),
                "fake-index",
                new AzureKeyCredential("fake-api-key"),
                options);
        }

        /// <summary>
        /// Creates a <see cref="SearchIndexClient"/> backed by a <see cref="MockTransport"/>
        /// that returns the provided mock responses.
        /// </summary>
        public static SearchIndexClient CreateMockIndexClient(params MockResponse[] responses)
        {
            var transport = new MockTransport(responses);
            var options = new SearchClientOptions()
            {
                Transport = transport,
            };

            return new SearchIndexClient(
                new Uri("https://fake-search.search.windows.net"),
                new AzureKeyCredential("fake-api-key"),
                options);
        }

        /// <summary>
        /// Creates a <see cref="MockResponse"/> with the given status code and JSON body.
        /// </summary>
        public static MockResponse CreateMockJsonResponse(int statusCode, string jsonBody)
        {
            var response = new MockResponse(statusCode);
            response.SetContent(jsonBody);
            response.AddHeader("Content-Type", "application/json");
            return response;
        }
    }
}
