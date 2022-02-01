// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using BenchmarkDotNet.Attributes;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Perf
{
    [InProcess]
    [MemoryDiagnoser]
    public class MgmtTelemetryPolicyBenchmark
    {
        [Params("", "test")]
        public string SDKAgentOverride;

        [Params(new string[] { }, new string[] { "foo" }, new string[] {"foo", "bar"})]
        public string[] CustomHeaders;

        [Benchmark]
        public void UserAgentOverrideBenchmark()
        {
            var requestMock = new MockRequest();
            var message = new HttpMessage(requestMock, new ResponseClassifier());
            if (!string.IsNullOrEmpty(SDKAgentOverride))
            {
                message.SetProperty("SDKUserAgent", SDKAgentOverride);
            }
            if (CustomHeaders.Length > 0)
            {
                foreach (var header in CustomHeaders)
                {
                    requestMock.Headers.Add(HttpHeader.Names.UserAgent, header);
                }
            }
            var policy = new MgmtTelemetryPolicy(message, ClientOptions.Default);
            policy.OnSendingRequest(message);
        }
    }
}
