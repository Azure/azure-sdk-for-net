// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
using Azure.Analytics.Purview.Tests;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;

namespace Azure.Analytics.Purview.Scanning.Tests
{
    public class ClassificationRuleClientTestBase : RecordedTestBase<PurviewScanningTestEnvironment>
    {
        public ClassificationRuleClientTestBase(bool isAsync) : base(isAsync)
        {
            Sanitizer = new PurviewRecordedTestSanitizer();
        }

        public ClassificationRuleClientTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
            Sanitizer = new PurviewRecordedTestSanitizer();
        }

        public PurviewClassificationRuleClient GetClassificationRuleClient(string classificationRuleName)
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = (_, _, _, _) =>
            {
                return true;
            };
            var options = new PurviewScanningServiceClientOptions { Transport = new HttpClientTransport(httpHandler) };
            return InstrumentClient(new PurviewClassificationRuleClient(TestEnvironment.Endpoint,classificationRuleName,TestEnvironment.Credential, InstrumentClientOptions(options)));
        }
    }
}
