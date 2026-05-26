// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.ContentUnderstanding.Tests;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;

namespace Azure.AI.ContentUnderstanding.Samples
{
    [AsyncOnly] // Ensure that each sample will only run once.
    public partial class ContentUnderstandingSamples : RecordedTestBase<ContentUnderstandingClientTestEnvironment>
    {
        public ContentUnderstandingSamples(bool isAsync) : base(isAsync)
        {
            // Disable diagnostic validation for samples (they're for documentation, not full test coverage)
            TestDiagnostics = false;

            // Configure common sanitizers (endpoint URLs, headers)
            ContentUnderstandingTestBase.ConfigureCommonSanitizers(this);

            // Configure copy operation sanitizers (resource IDs, regions)
            ContentUnderstandingTestBase.ConfigureCopyOperationSanitizers(this);
        }
    }
}
