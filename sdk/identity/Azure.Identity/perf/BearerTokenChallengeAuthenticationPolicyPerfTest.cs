// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Test.Perf;

namespace Azure.Identity.Perf
{
    public class BearerTokenChallengeAuthenticationPolicyPerfTest : PerfTest<CountOptions>
    {
        private HttpPipeline _pipeline;
        private HttpMessage _message;

        public BearerTokenChallengeAuthenticationPolicyPerfTest(CountOptions options) : base(options)
        {
            var _transport = new MockTransport((req) => new MockResponse(200));
            _pipeline = new HttpPipeline(_transport, new[] { new BearerTokenChallengeAuthenticationPolicy(new StaticCredential(), "scope") });
            _message = _pipeline.CreateMessage();
            _message.BufferResponse = true;
            _message.Request.Method = RequestMethod.Get;
            _message.Request.Uri.Reset(new Uri("https://example.com"));
        }

        public override void Run(CancellationToken cancellationToken)
        {
            _pipeline.Send(_message, cancellationToken);
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await _pipeline.SendAsync(_message, cancellationToken).ConfigureAwait(false);
        }
    }
}
