// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Security.KeyVault.Secrets;
using NUnit.Framework;

namespace Azure.Core.Samples
{
    public class PipelineSamples
    {
        [Test]
        public void AddingPerCallPolicy()
        {
            #region Snippet:AddingPerCallPolicy
            SecretClientOptions options = new SecretClientOptions();
            options.AddPolicy(new CustomRequestPolicy(), HttpPipelinePosition.PerCall);

            options.AddPolicy(new StopwatchPolicy(), HttpPipelinePosition.PerRetry);
            #endregion
        }

        #region Snippet:StopwatchPolicy
        public class StopwatchPolicy : HttpPipelinePolicy
        {
            public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                await ProcessNextAsync(message, pipeline);

                stopwatch.Stop();

                Console.WriteLine($"Request to {message.Request.Uri} took {stopwatch.Elapsed}");
            }

            public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                ProcessNext(message, pipeline);

                stopwatch.Stop();

                Console.WriteLine($"Request to {message.Request.Uri} took {stopwatch.Elapsed}");
            }
        }
        #endregion

        #region Snippet:SyncPolicy
        public class CustomRequestPolicy : HttpPipelineSynchronousPolicy
        {
            public override void OnSendingRequest(HttpMessage message)
            {
                message.Request.Uri.AppendQuery("additional-query-parameter", "42");
                message.Request.Headers.Add("Custom-Header", "Value");
            }
        }
        #endregion
    }
}
