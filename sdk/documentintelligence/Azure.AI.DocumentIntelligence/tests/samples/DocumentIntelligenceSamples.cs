// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.DocumentIntelligence.Tests;
using Azure.Core.TestFramework;

namespace Azure.AI.DocumentIntelligence.Samples
{
    [LiveOnly]
    [AsyncOnly] // Ensure that each sample will only run once.
    public partial class DocumentIntelligenceSamples : RecordedTestBase<DocumentIntelligenceTestEnvironment>
    {
        public DocumentIntelligenceSamples(bool isAsync) : base(isAsync, RecordedTestMode.Live)
        {
        }
    }
}
