// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Azure.Core.Testing;

namespace Azure.AI.FormRecognizer.Tests
{
    public class FormRecognizerRecordedTestSanitizer : RecordedTestSanitizer
    {
        private const string TestEndpoint = "https://test-endpoint.cognitiveservices.azure.com";
        private const string EndpointPattern = @"^.*://.*\.cognitiveservices\.azure\.com";
        private const string OperationLocationHeader = "Operation-Location";

        public override string SanitizeUri(string uri) => ReplaceEndpoint(uri);

        public override void SanitizeHeaders(IDictionary<string, string[]> headers)
        {
            if (headers.ContainsKey(Constants.AuthorizationHeader))
            {
                headers[Constants.AuthorizationHeader] = new[] { SanitizeValue };
            }

            if (headers.TryGetValue(OperationLocationHeader, out string[] operationLocationHeader))
            {
                string operationLocation = operationLocationHeader.Single();
                headers[OperationLocationHeader] = new[] { ReplaceEndpoint(operationLocation) };
            }
        }

        public override string SanitizeVariable(string variableName, string environmentVariableValue)
        {
            return variableName switch
            {
                "FORM_RECOGNIZER_ENDPOINT" => TestEndpoint,
                "FORM_RECOGNIZER_API_KEY" => SanitizeValue,
                _ => base.SanitizeVariable(variableName, environmentVariableValue)
            };
        }

        private string ReplaceEndpoint(string uri)
            => Regex.Replace(uri, EndpointPattern, TestEndpoint, RegexOptions.IgnoreCase);
    }
}
