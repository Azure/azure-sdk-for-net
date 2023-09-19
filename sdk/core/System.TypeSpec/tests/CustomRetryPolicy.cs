// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ServiceModel.Rest;
using System.Threading;
using System.Threading.Tasks;

namespace System.Tests;

public partial class OpenAIClientTests
{
    internal class CustomRetryPolicy : PipelinePolicy
    {
        private int _try = 0;

        public override void Process(PipelineMessage message, IEnumerator<PipelinePolicy> pipeline)
        {
            retry:
            try {
                _try++;
                PipelinePolicy.ProcessNext(message, pipeline);
            }
            catch (Exception) {
                if (_try > 5) {
                    throw new RequestErrorException(message.Result);
                }
                Thread.Sleep(1000);
                goto retry;
            }
        }

        public async override ValueTask ProcessAsync(PipelineMessage message, IEnumerator<PipelinePolicy> pipeline)
        {
        retry:
            try {
                _try++;
                await PipelinePolicy.ProcessNextAsync(message, pipeline);
            }
            catch (Exception) {
                if (_try > 5) {
                    throw new RequestErrorException(message.Result);
                }
                Thread.Sleep(1000);
                goto retry;
            }
        }
    }
}
