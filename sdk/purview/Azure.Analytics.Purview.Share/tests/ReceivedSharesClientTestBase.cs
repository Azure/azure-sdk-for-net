// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.Http;
using Azure.Analytics.Purview.Tests;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;

namespace Azure.Analytics.Purview.Share.Tests
{
    public class ReceivedSharesClientTestBase : RecordedTestBase<PurviewShareTestEnvironment>
    {
        public ReceivedSharesClientTestBase(bool isAsync, RecordedTestMode? mode = default) : base(isAsync, mode)
        {
            this.AddPurviewSanitizers();
        }

        public ReceivedSharesClient GetReceivedSharesClient()
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = (_, _, _, _) =>
            {
                return true;
            };
            var options = new PurviewShareClientOptions { Transport = new HttpClientTransport(httpHandler) };
            return InstrumentClient(new ReceivedSharesClient(TestEnvironment.Endpoint.ToString(), TestEnvironment.Credential, InstrumentClientOptions(options)));
        }
    }
}
