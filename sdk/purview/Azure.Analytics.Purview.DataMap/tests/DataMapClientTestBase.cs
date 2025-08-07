// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
using Azure.Analytics.Purview.Tests;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.Analytics.Purview.DataMap.Tests
{
    public class DataMapClientTestBase : RecordedTestBase<PurviewDataMapTestEnvironment>
    {
        public DataMapClientTestBase(bool isAsync, RecordedTestMode? mode = RecordedTestMode.Playback) : base(isAsync, mode)
        {
            this.AddPurviewSanitizers();
        }

        public DataMapClient GetDataMapClient()
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = (_, _, _, _) =>
            {
                return true;
            };
            var options = new DataMapClientOptions { Transport = new HttpClientTransport(httpHandler) };
            var client = InstrumentClient(
                new DataMapClient(TestEnvironment.Endpoint, TestEnvironment.Credential, InstrumentClientOptions(options)));
            return client;
        }
    }
}
