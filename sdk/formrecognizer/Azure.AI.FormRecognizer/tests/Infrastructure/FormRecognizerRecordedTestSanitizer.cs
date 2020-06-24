// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core.TestFramework;

namespace Azure.AI.FormRecognizer.Tests
{
    public class FormRecognizerRecordedTestSanitizer : RecordedTestSanitizer
    {
        private const string SanitizedSasUri = "https://sanitized.blob.core.windows.net";

        public FormRecognizerRecordedTestSanitizer()
            : base()
        {
            JsonPathSanitizers.Add("$..accessToken");
            JsonPathSanitizers.Add("$..source");
        }

        public override void SanitizeHeaders(IDictionary<string, string[]> headers)
        {
            if (headers.ContainsKey(Constants.AuthorizationHeader))
            {
                headers[Constants.AuthorizationHeader] = new[] { SanitizeValue };
            }

            base.SanitizeHeaders(headers);
        }

        public override string SanitizeVariable(string variableName, string environmentVariableValue)
        {
            return variableName switch
            {
                FormRecognizerTestEnvironment.ApiKeyEnvironmentVariableName => SanitizeValue,
                FormRecognizerTestEnvironment.BlobContainerSasUrlEnvironmentVariableName => SanitizedSasUri,
                _ => base.SanitizeVariable(variableName, environmentVariableValue)
            };
        }
    }
}
