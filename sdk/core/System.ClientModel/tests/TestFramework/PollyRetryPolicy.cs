// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Polly;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ClientModel.Tests
{
    public class PollyRetryPolicy : PipelinePolicy
    {
        public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            Policy.Handle<IOException>()
                .Or<ClientResultException>(ex => ex.Status == 0)
                .OrResult<PipelineResponse>(r => r.Status >= 400)
                .WaitAndRetry(
                    new[]
                    {
                        // some custom retry delay pattern
                        TimeSpan.FromSeconds(1),
                        TimeSpan.FromSeconds(2),
                        TimeSpan.FromSeconds(3)
                    })
                .Execute(() =>
                {
                    ProcessNext(message, pipeline, currentIndex);
                    return message.Response!;
                });
        }

        public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            await Policy.Handle<IOException>()
                .Or<ClientResultException>(ex => ex.Status == 0)
                .OrResult<PipelineResponse>(r => r.Status >= 400)
                .WaitAndRetryAsync(
                    new[]
                    {
                        // some custom retry delay pattern
                        TimeSpan.FromSeconds(1),
                        TimeSpan.FromSeconds(2),
                        TimeSpan.FromSeconds(3)
                    })
                .ExecuteAsync(async () =>
                {
                    await ProcessNextAsync(message, pipeline, currentIndex).ConfigureAwait(false);
                    return message.Response!;
                });
        }
    }
}
