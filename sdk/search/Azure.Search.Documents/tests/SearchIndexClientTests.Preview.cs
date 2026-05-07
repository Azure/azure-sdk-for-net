// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if AZURE_SEARCH_PREVIEW
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    /// <summary>
    /// Preview-only index management tests. These tests only compile and run
    /// in preview builds (when the package version contains a pre-release suffix).
    ///
    /// GA Promotion Workflow:
    /// 1. Remove the #if AZURE_SEARCH_PREVIEW / #endif wrappers from this file
    /// 2. Move test methods to SearchIndexClientTests.cs (or keep here without #if — team choice)
    /// 3. Change [ServiceVersion(Min = CurrentPreviewVersion)] to the new GA version
    /// 4. Update CurrentGAVersion in SearchTestBase
    /// </summary>
    public partial class SearchIndexClientTests
    {
        // This file intentionally contains no tests in GA releases.
        // It is scaffolding for the next preview API version and should not be counted as active coverage.
        //
        // Add preview-only index management tests here.
        // Each test should have [ServiceVersion(Min = CurrentPreviewVersion)] to ensure
        // it only runs against the preview API version in the test matrix.
        //
        // Example:
        // [Test]
        // [ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2026_05_01_Preview)]
        // public async Task PreviewIndexFeature()
        // {
        //     await using SearchResources resources = await SearchResources.CreateWithHotelsIndexAsync(this);
        //     SearchIndexClient client = resources.GetIndexClient();
        //     // ... test preview-only index behavior
        // }
    }
}
#endif
