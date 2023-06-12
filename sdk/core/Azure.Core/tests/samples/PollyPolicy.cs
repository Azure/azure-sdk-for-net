// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Polly;

namespace Azure.Core.Samples
{
    #region Snippet:PollyPolicy
    internal class PollyPolicy : HttpPipelinePolicy
    {
        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            Policy.Handle<IOException>()
                .Or<RequestFailedException>(ex => ex.Status == 0)
                .OrResult<Response>(r => r.Status >= 400)
                .WaitAndRetry(
                    new[]
                    {
                        // some custom retry delay pattern
                        TimeSpan.FromSeconds(1),
                        TimeSpan.FromSeconds(2),
                        TimeSpan.FromSeconds(3)
                    },
                    onRetry: (result, _) =>
                    {
                        // Since we are overriding the RetryPolicy, it is our responsibility to increment the RetryNumber
                        // that other policies in the pipeline may be depending on.
                        var context = message.ProcessingContext;
                        context.RetryNumber++;
                    }
                )
                .Execute(() =>
                {
                    ProcessNext(message, pipeline);
                    return message.Response;
                });
        }

#if SNIPPET
        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            // async version omitted for brevity
            throw new NotImplementedException();
        }
#else
        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            await Policy.Handle<IOException>()
                .Or<RequestFailedException>(ex => ex.Status == 0)
                .OrResult<Response>(r => r.Status >= 400)
                .WaitAndRetryAsync(
                    new[]
                    {
                        // some custom retry delay pattern
                        TimeSpan.FromSeconds(1),
                        TimeSpan.FromSeconds(2),
                        TimeSpan.FromSeconds(3)
                    },
                    onRetry: (result, _) =>
                    {
                        // Since we are overriding the RetryPolicy, it is our responsibility to increment the RetryNumber
                        // that other policies in the pipeline may be depending on.
                        var context = message.ProcessingContext;
                        context.RetryNumber++;
                    })
                .ExecuteAsync(async () =>
                {
                    await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
                    return message.Response;
                });
        }
#endif
    }
    #endregion
}
