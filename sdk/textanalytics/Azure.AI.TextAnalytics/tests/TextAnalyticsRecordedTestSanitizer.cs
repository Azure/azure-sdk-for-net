// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text;

namespace Azure.Core.Testing
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
    }
}
