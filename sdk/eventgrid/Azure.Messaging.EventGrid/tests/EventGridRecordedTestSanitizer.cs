// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Azure.Core.TestFramework;

namespace Azure.Messaging.EventGrid.Tests
{
    public class EventGridRecordedTestSanitizer : RecordedTestSanitizer
    {
        // These constants should eventually go in our product code, as they will be needed when creating
        // the AzureKeyCredential.
        public const string SasKeyName = "aeg-sas-key";
        public const string SasTokenName = "aeg-sas-token";

        public override void SanitizeHeaders(IDictionary<string, string[]> headers)
        {
            base.SanitizeHeaders(headers);

            if (headers.TryGetValue(SasKeyName, out var sasKey))
            {
                headers[SasKeyName] = sasKey.Select(s => SanitizeValue).ToArray();
            }
            if (headers.TryGetValue(SasTokenName, out var sasToken))
            {
                headers[SasTokenName] = sasToken.Select(s => SanitizeValue).ToArray();
            }
        }
    }
}
