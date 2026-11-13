// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.ContentUnderstanding.Tests;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;

namespace Azure.AI.ContentUnderstanding.Samples
{
    [AsyncOnly] // Ensure that each sample will only run once.
    [ClientTestFixture(
        true,
        ContentUnderstandingClientOptions.ServiceVersion.V2025_11_01,
        ContentUnderstandingClientOptions.ServiceVersion.V2026_06_01_Preview)]
    public partial class ContentUnderstandingSamples : RecordedTestBase<ContentUnderstandingClientTestEnvironment>
    {
        private readonly ContentUnderstandingClientOptions.ServiceVersion _serviceVersion;

        private ContentUnderstandingModelProfile ModelProfile => TestEnvironment.GetModelProfile(_serviceVersion);

        public ContentUnderstandingSamples(bool isAsync, ContentUnderstandingClientOptions.ServiceVersion serviceVersion = default)
            : base(isAsync)
        {
            _serviceVersion = serviceVersion;

            // Disable diagnostic validation for samples (they're for documentation, not full test coverage)
            TestDiagnostics = false;

            // Configure common sanitizers (endpoint URLs, headers)
            ContentUnderstandingTestBase.ConfigureCommonSanitizers(this);

            // Configure copy operation sanitizers (resource IDs, regions)
            ContentUnderstandingTestBase.ConfigureCopyOperationSanitizers(this);
        }
    }
}
