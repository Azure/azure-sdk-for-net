// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core.TestFramework;

namespace Azure.AI.FormRecognizer.Tests
{
    public class FormRecognizerRecordedTestSanitizer : RecordedTestSanitizer
    {
        public FormRecognizerRecordedTestSanitizer()
            : base()
        {
            JsonPathSanitizers.Add("$..accessToken");
            JsonPathSanitizers.Add("$..source");
            SanitizedHeaders.Add(Constants.AuthorizationHeader);
        }


        public override string SanitizeVariable(string variableName, string environmentVariableValue)
        {
            return variableName switch
            {
                FormRecognizerTestEnvironment.BlobContainerSasUrlEnvironmentVariableName => SanitizedSasUri,
                _ => base.SanitizeVariable(variableName, environmentVariableValue)
            };
        }
    }
}
