// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Iot.Hub.Service.Tests
{
    internal class TestConnectionStringSanitizer : RecordedTestSanitizer
    {
        internal const string FAKE_HOST = "FakeHost.net";

        public override string SanitizeUri(string uri)
        {
            return uri.Replace(new Uri(uri).Host, FAKE_HOST);
        }
    }
}
