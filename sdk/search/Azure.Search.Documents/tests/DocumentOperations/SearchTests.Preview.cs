// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if AZURE_SEARCH_PREVIEW

namespace Azure.Search.Documents.Tests
{
    /// <summary>
    /// Preview-only search operation tests. These tests only compile and run
    /// in preview builds (when the package version contains a pre-release suffix).
    ///
    /// GA Promotion Workflow:
    /// 1. Remove the #if AZURE_SEARCH_PREVIEW / #endif wrappers from this file
    /// 2. Move test methods to SearchTests.cs (or keep here without #if — team choice)
    /// 3. Change [ServiceVersion(Min = CurrentPreviewVersion)] to the new GA version
    /// 4. Update CurrentGAVersion in SearchTestBase
    /// </summary>
    public partial class SearchTests
    {
    }
}
#endif
