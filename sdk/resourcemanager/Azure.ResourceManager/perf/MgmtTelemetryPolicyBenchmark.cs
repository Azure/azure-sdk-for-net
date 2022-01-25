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
        public string UserAgentOverride;

        [Params(new string[] { }, new string[] { "foo" }, new string[] {"foo", "bar"})]
        public string[] CustomHeaders;

        private MgmtTelemetryPolicy policy;
        private HttpMessage message;

        [IterationSetup]
        public void GlobalSetup()
        {
            var requestMock = new MockRequest();
            message = new HttpMessage(requestMock, new ResponseClassifier());
            if (!string.IsNullOrEmpty(UserAgentOverride))
            {
                message.SetProperty("SDKUserAgent", UserAgentOverride);
            }
            if (CustomHeaders.Length > 0)
            {
                foreach (var header in CustomHeaders)
                {
                    requestMock.Headers.Add(HttpHeader.Names.UserAgent, header);
                }
            }
            policy = new MgmtTelemetryPolicy(message, ClientOptions.Default);
        }

        [Benchmark]
        public void UserAgentOverrideBenchmark()
        {
            policy.OnSendingRequest(message);
        }
    }
}
