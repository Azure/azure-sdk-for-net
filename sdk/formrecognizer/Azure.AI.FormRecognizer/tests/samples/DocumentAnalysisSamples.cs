// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.FormRecognizer.DocumentAnalysis.Tests;
using Azure.Core.TestFramework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Samples
{
    [LiveOnly]
    [IgnoreServiceError(400, "InvalidRequest", Message = "Content is not accessible: Invalid data URL", Reason = "https://github.com/Azure/azure-sdk-for-net/issues/28923")]
    public partial class DocumentAnalysisSamples : RecordedTestBase<DocumentAnalysisTestEnvironment>
    {
        public DocumentAnalysisSamples(bool isAsync) : base(isAsync, RecordedTestMode.Live)
        {
        }
    }
}
