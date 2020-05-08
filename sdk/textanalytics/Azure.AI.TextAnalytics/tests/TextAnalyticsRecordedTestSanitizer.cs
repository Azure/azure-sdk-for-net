// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Core.TestFramework
{
    public class TextAnalyticsRecordedTestSanitizer : RecordedTestSanitizer
    {
        public override void SanitizeHeaders(IDictionary<string, string[]> headers)
        {
            const string key = "Ocp-Apim-Subscription-Key";
            if (headers.ContainsKey(key))
            {
                headers[key] = new[] { SanitizeValue };
            }

            base.SanitizeHeaders(headers);
        }

        public override string SanitizeVariable(string variableName, string environmentVariableValue)
        {
            return variableName switch
            {
                "TEXT_ANALYTICS_API_KEY" => SanitizeValue,
                _ => base.SanitizeVariable(variableName, environmentVariableValue)
            };
        }
    }
}
