// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Core.Testing
{
    public class TextAnalyticsRecordedTestSanitizer : RecordedTestSanitizer
    {
        public override string SanitizeUri(string uri)
        {
            var index = uri.IndexOf(".cognitiveservices.azure.com", StringComparison.Ordinal);
            return index >= 0 ? "https://test" + uri.Substring(index) : base.SanitizeUri(uri);
        }

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
                "TEXT_ANALYTICS_ENDPOINT" => "https://test.cognitiveservices.azure.com/",
                "TEXT_ANALYTICS_SUBSCRIPTION_KEY" => SanitizeValue,
                _ => base.SanitizeVariable(variableName, environmentVariableValue)
            };
        }
    }
}
