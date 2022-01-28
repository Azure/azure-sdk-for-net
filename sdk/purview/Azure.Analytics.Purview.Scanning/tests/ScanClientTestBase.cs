// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
using Azure.Analytics.Purview.Tests;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;

namespace Azure.Analytics.Purview.Scanning.Tests
{
    public class ScanClientTestBase : RecordedTestBase<PurviewScanningTestEnvironment>
    {
        public ScanClientTestBase(bool isAsync) : base(isAsync)
        {
            Sanitizer = new PurviewRecordedTestSanitizer();
        }

        public ScanClientTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
            Sanitizer = new PurviewRecordedTestSanitizer();
        }
        public PurviewScanClient GetPurviewScanClient(string dataSourceName,string scanName)
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = (_, _, _, _) =>
            {
                return true;
            };
            var options = new PurviewScanningServiceClientOptions { Transport = new HttpClientTransport(httpHandler) };
            return InstrumentClient(new PurviewScanClient(TestEnvironment.Endpoint, dataSourceName, scanName, TestEnvironment.Credential, InstrumentClientOptions(options)));
        }
    }
}
