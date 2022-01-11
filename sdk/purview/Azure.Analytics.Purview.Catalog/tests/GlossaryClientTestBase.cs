// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net.Http;
using Azure.Analytics.Purview.Tests;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;

namespace Azure.Analytics.Purview.Catalog.Tests
{
    public class GlossaryClientTestBase : RecordedTestBase<PurviewCatalogTestEnvironment>
    {
        public GlossaryClientTestBase(bool isAsync) : base(isAsync)
        {
            Sanitizer = new PurviewRecordedTestSanitizer();
        }
        public GlossaryClientTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
            Sanitizer = new PurviewRecordedTestSanitizer();
        }
        public PurviewGlossaries GetGlossariesClient()
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = (_, _, _, _) =>
            {
                return true;
            };
            var options = new PurviewCatalogClientOptions { Transport = new HttpClientTransport(httpHandler) };
            var catalogclient = new PurviewCatalogClient(TestEnvironment.Endpoint, TestEnvironment.Credential, InstrumentClientOptions(options));
            return InstrumentClient(catalogclient.Glossaries);
        }
    }
}
