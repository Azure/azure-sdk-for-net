// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Iot.Hub.Service.Tests
{
    /// <summary>
    /// Custom sanitizer to remove secrets from the recorded json files used for playback tests.
    /// </summary>
    internal class CustomRequestSanitizer : RecordedTestSanitizer
    {
        internal const string FakeHost = "FakeHost.net";
        internal const string FakeStorageUri = "https://fake.blob.core.windows.net";

        public CustomRequestSanitizer()
           : base()
        {
            // Sanitize SAS tokens in request body
            JsonPathSanitizers.Add("outputBlobContainerUri");
            JsonPathSanitizers.Add("inputBlobContainerUri");
            JsonPathSanitizers.Add("..primaryKey");
            JsonPathSanitizers.Add("..secondaryKey");
        }

        public override string SanitizeUri(string uri)
        {
            return uri.Replace(new Uri(uri).Host, FakeHost);
        }
    }
}
