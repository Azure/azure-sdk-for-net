// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.FormRecognizer;
using Azure.Core.TestFramework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Tests
{
    public class DocumentAnalysisRecordedTestSanitizer : RecordedTestSanitizer
    {
        public DocumentAnalysisRecordedTestSanitizer()
            : base()
        {
            JsonPathSanitizers.Add("$..accessToken");
            JsonPathSanitizers.Add("$..containerUrl");
            SanitizedHeaders.Add(Constants.AuthorizationHeader);
        }
    }
}
