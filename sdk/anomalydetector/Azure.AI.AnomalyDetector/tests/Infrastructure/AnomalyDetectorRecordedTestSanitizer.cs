// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core.TestFramework;

namespace Azure.AI.AnomalyDetector.Tests
{
    public class AnomalyDetectorRecordedTestSanitizer : RecordedTestSanitizer
    {
        public AnomalyDetectorRecordedTestSanitizer()
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
                AnomalyDetectorTestEnvironment.ApiKeyEnvironmentVariableName => SanitizeValue,
                _ => base.SanitizeVariable(variableName, environmentVariableValue)
            };
        }
    }
}
