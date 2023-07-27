// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.FormRecognizer.DocumentAnalysis.Tests;
using Azure.Core.TestFramework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Samples
{
    [LiveOnly]
    [AsyncOnly] // Ensure that each sample will only run once.
    public partial class DocumentAnalysisSamples : RecordedTestBase<DocumentAnalysisTestEnvironment>
    {
        public DocumentAnalysisSamples(bool isAsync) : base(isAsync, RecordedTestMode.Live)
        {
        }
    }
}
