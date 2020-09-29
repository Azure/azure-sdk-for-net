// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenTelemetry.Exporter.AzureMonitor.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace OpenTelemetry.Exporter.AzureMonitor.HttpParsers
{
    public class AzureSearchHttpParserTests
    {
        [Fact]
        public void AzureSearchHttpParserConvertsValidDependencies()
        {
            Dictionary<string, string> defaultProperties = null;
            var indexProperties = new Dictionary<string, string> { ["Index"] = "myindex" };
            var datasourceProperties = new Dictionary<string, string> { ["Data Source"] = "mydatasource" };
            var indexerProperties = new Dictionary<string, string> { ["Indexer"] = "myindexer" };
            var skillsetProperties = new Dictionary<string, string> { ["Skillset"] = "myskillset" };
            var synonymProperties = new Dictionary<string, string> { ["Synonymmap"] = "mysynonym" };

            var testCases = new List<Tuple<string, string, string, Dictionary<string, string>>>
            {
                // Index operations
                Tuple.Create("Create index", "POST", "https://myaccount.search.windows.net/indexes?api-version=2017-11-11", defaultProperties),
                Tuple.Create("Update index", "PUT", "https://myaccount.search.windows.net/indexes/myindex?api-version=2017-11-11", indexProperties),
                Tuple.Create("List indexes", "GET", "https://myaccount.search.windows.net/indexes?api-version=2017-11-11", defaultProperties),
                Tuple.Create("Get index", "GET", "https://myaccount.search.windows.net/indexes/myindex?api-version=2017-11-11", indexProperties),
                Tuple.Create("Delete index", "DELETE", "https://myaccount.search.windows.net/indexes/myindex?api-version=2017-11-11", indexProperties),
                Tuple.Create("Get index statistics", "GET", "https://myaccount.search.windows.net/indexes/myindex/stats?api-version=2017-11-11", indexProperties),
                Tuple.Create("Analyze text", "POST", "https://myaccount.search.windows.net/indexes/myindex/analyze?api-version=2017-11-11", indexProperties),

                // Document operations
                Tuple.Create("Add/update/delete documents", "POST", "https://myaccount.search.windows.net/indexes/myindex/docs/index?api-version=2017-11-11", indexProperties),
                Tuple.Create("Search documents", "GET", "https://myaccount.search.windows.net/indexes/myindex/docs?search=abc", indexProperties),
                Tuple.Create("Search documents", "POST", "https://myaccount.search.windows.net/indexes/myindex/docs/search?api-version=2017-11-11", indexProperties),
                Tuple.Create("Suggestions", "GET", "https://myaccount.search.windows.net/indexes/myindex/docs/suggest?search=abc", indexProperties),
                Tuple.Create("Suggestions", "POST", "https://myaccount.search.windows.net/indexes/myindex/docs/suggest?api-version=2017-11-11", indexProperties),
                Tuple.Create("Autocomplete", "GET", "https://myaccount.search.windows.net/indexes/myindex/docs/autocomplete?search=abc", indexProperties),
                Tuple.Create("Autocomplete", "POST", "https://myaccount.search.windows.net/indexes/myindex/docs/autocomplete?api-version=2017-11-11", indexProperties),
                Tuple.Create("Lookup document", "GET", "https://myaccount.search.windows.net/indexes/myindex/docs/abc?api-version=2017-11-11", indexProperties),
                Tuple.Create("Count documents", "GET", "https://myaccount.search.windows.net/indexes/myindex/docs/$count?api-version=2017-11-11", indexProperties),

                // Document operations (OData)
                Tuple.Create("Add/update/delete documents", "POST", "https://myaccount.search.windows.net/indexes('myindex')/docs/index?api-version=2017-11-11", indexProperties),
                Tuple.Create("Add/update/delete documents", "POST", "https://myaccount.search.windows.net/indexes('myindex')/docs/search.index?api-version=2017-11-11", indexProperties),
                Tuple.Create("Search documents", "GET", "https://myaccount.search.windows.net/indexes('myindex')/docs?search=abc", indexProperties),
                Tuple.Create("Suggestions", "GET", "https://myaccount.search.windows.net/indexes('myindex')/docs/suggest?search=abc", indexProperties),
                Tuple.Create("Lookup document", "GET", "https://myaccount.search.windows.net/indexes('myindex')/docs('abc')?api-version=2017-11-11", indexProperties),
                Tuple.Create("Count documents", "GET", "https://myaccount.search.windows.net/indexes('myindex')/docs/$count?api-version=2017-11-11", indexProperties),

                // Indexer operations
                Tuple.Create("Create data source", "POST", "https://myaccount.search.windows.net/datasources?api-version=2017-11-11", defaultProperties),
                Tuple.Create("Create indexer", "POST", "https://myaccount.search.windows.net/indexers?api-version=2017-11-11", defaultProperties),
                Tuple.Create("Delete data source", "DELETE", "https://myaccount.search.windows.net/datasources/mydatasource?api-version=2017-11-11", datasourceProperties),
                Tuple.Create("Delete indexer", "DELETE", "https://myaccount.search.windows.net/indexers/myindexer?api-version=2017-11-11", indexerProperties),
                Tuple.Create("Get data source", "GET", "https://myaccount.search.windows.net/datasources/mydatasource?api-version=2017-11-11", datasourceProperties),
                Tuple.Create("Get indexer", "GET", "https://myaccount.search.windows.net/indexers/myindexer?api-version=2017-11-11", indexerProperties),
                Tuple.Create("Get indexer status", "GET", "https://myaccount.search.windows.net/indexers/myindexer/status?api-version=2017-11-11", indexerProperties),
                Tuple.Create("List data sources", "GET", "https://myaccount.search.windows.net/datasources?api-version=2017-11-11", defaultProperties),
                Tuple.Create("List indexers", "GET", "https://myaccount.search.windows.net/indexers?api-version=2017-11-11", defaultProperties),
                Tuple.Create("Reset indexer", "POST", "https://myaccount.search.windows.net/indexers/myindexer/reset?api-version=2017-11-11", indexerProperties),
                Tuple.Create("Run indexer", "POST", "https://myaccount.search.windows.net/indexers/myindexer/run?api-version=2017-11-11", indexerProperties),
                Tuple.Create("Update data source", "PUT", "https://myaccount.search.windows.net/datasources/mydatasource?api-version=2017-11-11", datasourceProperties),
                Tuple.Create("Update indexer", "PUT", "https://myaccount.search.windows.net/indexers/myindexer?api-version=2017-11-11", indexerProperties),

                // Service operations
                Tuple.Create("Get service statistics", "GET", "https://myaccount.search.windows.net/servicestats?api-version=2017-11-11", defaultProperties),

                // Skillset operations
                Tuple.Create("Create skillset", "POST", "https://myaccount.search.windows.net/skillsets/myskillset?api-version=2017-11-11-Preview", skillsetProperties),
                Tuple.Create("Delete skillset", "DELETE", "https://myaccount.search.windows.net/skillsets/myskillset?api-version=2017-11-11-Preview", skillsetProperties),
                Tuple.Create("Get skillset", "GET", "https://myaccount.search.windows.net/skillsets/myskillset?api-version=2017-11-11-Preview", skillsetProperties),
                Tuple.Create("List skillsets", "GET", "https://myaccount.search.windows.net/skillsets?api-version=2017-11-11-Preview", defaultProperties),
                Tuple.Create("Update skillset", "PUT", "https://myaccount.search.windows.net/skillsets/myskillset?api-version=2017-11-11-Preview", skillsetProperties),

                // Synonym operations
                Tuple.Create("Create synonym map", "POST", "https://myaccount.search.windows.net/synonymmaps?api-version=2017-11-11", defaultProperties),
                Tuple.Create("Update synonym map", "PUT", "https://myaccount.search.windows.net/synonymmaps/mysynonym?api-version=2017-11-11", synonymProperties),
                Tuple.Create("List synonym maps", "GET", "https://myaccount.search.windows.net/synonymmaps?api-version=2017-11-11", defaultProperties),
                Tuple.Create("Get synonym map", "GET", "https://myaccount.search.windows.net/synonymmaps/mysynonym?api-version=2017-11-11", synonymProperties),
                Tuple.Create("Delete synonym map", "DELETE", "https://myaccount.search.windows.net/synonymmaps/mysynonym?api-version=2017-11-11", synonymProperties)
            };

            foreach (var testCase in testCases)
            {
                this.AzureSearchHttpParserConvertsValidDependenciesHelper(
                    testCase.Item1,
                    testCase.Item2,
                    testCase.Item3,
                    testCase.Item4);
            }
        }

        private void AzureSearchHttpParserConvertsValidDependenciesHelper(
            string operation,
            string verb,
            string url,
            Dictionary<string, string> properties)
        {
            var parsedUrl = new Uri(url);

            // Parse with verb
            var d = new RemoteDependencyData(
                version: 2,
                name: verb + " " + parsedUrl.AbsolutePath,
                duration: string.Empty)
            {
                Type = RemoteDependencyConstants.HTTP,
                Target = parsedUrl.Host,
                Data = parsedUrl.OriginalString
            };

            var success = AzureSearchHttpParser.TryParse(ref d);

            Assert.True(success);
            Assert.Equal(RemoteDependencyConstants.AzureSearch, d.Type);
            Assert.Equal(parsedUrl.Host, d.Target);

            if (properties != null)
            {
                foreach (var property in properties)
                {
                    Assert.True(d.Properties.TryGetValue(property.Key, out var value), operation);
                    Assert.Equal(property.Value, value);
                }
            }

            // Parse without verb
            d = new RemoteDependencyData(
                version: 2,
                name: parsedUrl.AbsolutePath,
                duration: string.Empty)
            {
                Type = RemoteDependencyConstants.HTTP,
                Target = parsedUrl.Host,
                Data = parsedUrl.OriginalString
            };

            success = AzureSearchHttpParser.TryParse(ref d);

            Assert.True(success);
            Assert.Equal(RemoteDependencyConstants.AzureSearch, d.Type);
            Assert.Equal(parsedUrl.Host, d.Target);

            if (properties != null)
            {
                foreach (var property in properties)
                {
                    Assert.True(d.Properties.TryGetValue(property.Key, out var value), operation);
                    Assert.Equal(property.Value, value);
                }
            }
        }
    }
}
