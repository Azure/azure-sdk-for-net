// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;

namespace Azure.Analytics.Purview.Scanning.Tests
{
    public class DataSourceClientTestBase : RecordedTestBase<PurviewScanningTestEnvironment>
    {
        public DataSourceClientTestBase(bool isAsync) : base(isAsync)
        {
        }

        public DataSourceClientTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        public PurviewDataSourceClient GetPurviewDataSourceClient(string dataSourceName)
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = (_, _, _, _) =>
            {
                return true;
            };
            var options = new PurviewScanningServiceClientOptions { Transport = new HttpClientTransport(httpHandler) };
            return InstrumentClient(new PurviewDataSourceClient(TestEnvironment.Endpoint,dataSourceName,TestEnvironment.Credential, InstrumentClientOptions(options)));
        }
    }
}
