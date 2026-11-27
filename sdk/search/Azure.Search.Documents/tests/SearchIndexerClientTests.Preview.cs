// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if AZURE_SEARCH_PREVIEW

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Tests.Utilities;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    /// <summary>
    /// Preview-only indexer tests. These tests only compile and run
    /// in preview builds (when the package version contains a pre-release suffix).
    ///
    /// GA Promotion Workflow:
    /// 1. Remove the #if AZURE_SEARCH_PREVIEW / #endif wrappers from this file
    /// 2. Move test methods to SearchIndexerClientTests.cs (or keep here without #if — team choice)
    /// 3. Change [ServiceVersion(Min = CurrentPreviewVersion)] to the new GA version
    /// 4. Update CurrentGAVersion in SearchTestBase
    /// </summary>
    public partial class SearchIndexerClientTests
    {
        // search-preview:2026-08-01-preview
        [Test]
        [ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2026_08_01_Preview)]
        public async Task CreateOrUpdateSendsCacheControlParameters()
        {
            var transport = new MockTransport(
                SearchTestHelpers.CreateMockJsonResponse(
                    200,
                    """{"name":"test-data-source","type":"azureblob","credentials":{"connectionString":"fake-connection-string"},"container":{"name":"test-container"}}"""),
                SearchTestHelpers.CreateMockJsonResponse(
                    200,
                    """{"name":"test-skillset","skills":[]}"""),
                SearchTestHelpers.CreateMockJsonResponse(
                    200,
                    """{"name":"test-indexer","dataSourceName":"test-data-source","targetIndexName":"test-index"}"""));
            var options = new SearchClientOptions(ServiceVersion)
            {
                Transport = transport,
            };
            SearchIndexerClient client = InstrumentClient(
                new SearchIndexerClient(
                    new Uri("https://fake-search.search.windows.net"),
                    new AzureKeyCredential("fake-api-key"),
                    options));

            await client.CreateOrUpdateDataSourceConnectionAsync(
                new SearchIndexerDataSourceConnection(
                    "test-data-source",
                    SearchIndexerDataSourceType.AzureBlob,
                    "fake-connection-string",
                    new SearchIndexerDataContainer("test-container")),
                ignoreCacheResetRequirements: true);
            await client.CreateOrUpdateSkillsetAsync(
                new SearchIndexerSkillset("test-skillset", Array.Empty<SearchIndexerSkill>()),
                ignoreCacheResetRequirements: true,
                disableCacheReprocessingChangeDetection: true);
            await client.CreateOrUpdateIndexerAsync(
                new SearchIndexer("test-indexer", "test-data-source", "test-index"),
                ignoreCacheResetRequirements: true,
                disableCacheReprocessingChangeDetection: true);

            Assert.That(transport.Requests[0].Uri.ToString(), Does.Contain("ignoreResetRequirements=true"));
            Assert.That(transport.Requests[1].Uri.ToString(), Does.Contain("ignoreResetRequirements=true"));
            Assert.That(transport.Requests[1].Uri.ToString(), Does.Contain("disableCacheReprocessingChangeDetection=true"));
            Assert.That(transport.Requests[2].Uri.ToString(), Does.Contain("ignoreResetRequirements=true"));
            Assert.That(transport.Requests[2].Uri.ToString(), Does.Contain("disableCacheReprocessingChangeDetection=true"));
        }
    }
}
#endif
