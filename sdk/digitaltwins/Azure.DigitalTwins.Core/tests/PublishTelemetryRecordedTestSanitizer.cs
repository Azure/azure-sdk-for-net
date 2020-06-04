// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core.TestFramework;

namespace Azure.DigitalTwins.Core.Tests
{
    public class PublishTelemetryRecordedTestSanitizer : RecordedTestSanitizer
    {
        public override void SanitizeHeaders(IDictionary<string, string[]> headers)
        {
            string[] keys = new string[] { "dt-id", "dt-timestamp" };

            foreach (var key in keys)
            {
                if (headers.ContainsKey(key))
                {
                    headers[key] = new[] { SanitizeValue };
                }
            }

            base.SanitizeHeaders(headers);
        }
    }
}
