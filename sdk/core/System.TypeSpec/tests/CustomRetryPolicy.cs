// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ServiceModel.Rest.Core;
using System.Threading;
using System.Threading.Tasks;

namespace System.Tests;

public partial class OpenAIClientTests
{
    internal class CustomRetryPolicy : IPipelinePolicy<PipelineMessage>
    {
        private int _try = 0;

        public void Process(PipelineMessage message, PipelineEnumerator pipeline)
        {
            retry:
            try {
                _try++;
                pipeline.ProcessNext();
            }
            catch (Exception) {
                if (_try > 5) {
                    if (message.Response != null) throw new RequestErrorException(message.Response);
                    else throw;
                }
                Thread.Sleep(1000);
                goto retry;
            }
        }

        public async ValueTask ProcessAsync(PipelineMessage message, PipelineEnumerator pipeline)
        {
        retry:
            try {
                _try++;
                await pipeline.ProcessNextAsync().ConfigureAwait(false);
            }
            catch (Exception) {
                if (_try > 5) {
                    throw new RequestErrorException(message.Response);
                }
                Thread.Sleep(1000);
                goto retry;
            }
        }
    }
}
