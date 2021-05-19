// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Iot.TimeSeriesInsights.Tests
{
    internal class TestUrlSanitizer : RecordedTestSanitizer
    {
        internal const string FAKE_URL = "https://fakeHost.api.wus2.timeseriesinsights.azure.com";
        internal const string FAKE_HOST = "fakeHost.api.wus2.timeseriesinsights.azure.com";

        public override string SanitizeUri(string uri)
        {
            return uri.Replace(new Uri(uri).Host, FAKE_HOST);
        }
    }
}
