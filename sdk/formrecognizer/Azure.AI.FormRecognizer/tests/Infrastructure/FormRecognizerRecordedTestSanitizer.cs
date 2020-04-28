// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core.Testing;

namespace Azure.AI.FormRecognizer.Tests
{
    public class FormRecognizerRecordedTestSanitizer : RecordedTestSanitizer
    {
        public override void SanitizeHeaders(IDictionary<string, string[]> headers)
        {
            if (headers.ContainsKey(Constants.AuthorizationHeader))
            {
                headers[Constants.AuthorizationHeader] = new[] { SanitizeValue };
            }
        }

        public override string SanitizeVariable(string variableName, string environmentVariableValue)
        {
            return variableName switch
            {
                "FORM_RECOGNIZER_API_KEY" => SanitizeValue,
                "FORM_RECOGNIZER_BLOB_CONTAINER_SAS_URL" => SanitizeSasToken(environmentVariableValue),
                _ => base.SanitizeVariable(variableName, environmentVariableValue)
            };
        }

        private string SanitizeSasToken(string sasUri)
        {
            var queryStartIndex = sasUri.IndexOf('?') + 1;

            return queryStartIndex < sasUri.Length
                ? sasUri.Remove(queryStartIndex) + SanitizeValue
                : sasUri;
        }
    }
}
