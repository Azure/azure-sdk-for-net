// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Security.KeyVault.Secrets;
using Moq;
using NUnit.Framework;

namespace Azure.Core.Samples
{
    public class PipelineSamples
    {
        [Test]
        public void AddPolicies()
        {
            #region Snippet:AddPerCallPolicy
            SecretClientOptions options = new SecretClientOptions();
            options.AddPolicy(new CustomRequestPolicy(), HttpPipelinePosition.PerCall);
            #endregion

            #region Snippet:AddPerRetryPolicy
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

        private class RequestFailedDetailsParserSample
        {
            public SampleClientOptions options;
            private readonly HttpPipeline _pipeline;

            public RequestFailedDetailsParserSample()
            {
                options = new();
                #region Snippet:RequestFailedDetailsParser
                var pipelineOptions = new HttpPipelineOptions(options)
                {
                    RequestFailedDetailsParser = new FooClientRequestFailedDetailsParser()
                };

                _pipeline = HttpPipelineBuilder.Build(pipelineOptions);
                #endregion
                if (_pipeline == null)
                { throw new Exception(); };
            }
        }

        private class SampleClientOptions : ClientOptions { }
        private class SampleClient
        {
            public SampleClient(Uri endpoint, TokenCredential credential, SampleClientOptions options = default)
            {
            }
        }

        private class FooClientRequestFailedDetailsParser : RequestFailedDetailsParser
        {
            public override bool TryParse(Response response, out ResponseError error, out IDictionary<string, string> data)
            {
                throw new NotImplementedException();
            }
        }
    }
}
