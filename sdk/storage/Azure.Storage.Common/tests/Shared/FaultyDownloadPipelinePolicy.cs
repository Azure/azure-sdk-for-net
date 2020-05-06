// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Storage.Test.Shared
{
    internal sealed class FaultyDownloadPipelinePolicy : HttpPipelinePolicy
    {
        private readonly int _raiseExceptionAt;
        private readonly Exception _exceptionToRaise;
        private readonly Action _onFault;
        private bool _injectFault = true;

        public FaultyDownloadPipelinePolicy(int raiseExceptionAt, Exception exceptionToRaise, Action onFault)
        {
            _raiseExceptionAt = raiseExceptionAt;
            _exceptionToRaise = exceptionToRaise;
            _onFault = onFault;
        }

        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            if (_injectFault)
            {
                await InjectFaultAsync(message, async: true).ConfigureAwait(false);
            }
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessNext(message, pipeline);
            if (_injectFault)
            {
                InjectFaultAsync(message, async: false).EnsureCompleted();
            }
        }

        private async Task InjectFaultAsync(HttpMessage message, bool async)
        {
            if (message.Response != null)
            {
                // Copy to a MemoryStream first because RetriableStreamImpl
                // doesn't support Position
                var intermediate = new MemoryStream();
                if (message.Response.ContentStream != null)
                {
                    if (async)
                    {
                        await message.Response.ContentStream.CopyToAsync(intermediate).ConfigureAwait(false);
                    }
                    else
                    {
                        message.Response.ContentStream.CopyTo(intermediate);
                    }

                    intermediate.Seek(0, SeekOrigin.Begin);
                }

                // Use a faulty stream for the Response Content
                message.Response.ContentStream = new FaultyStream(
                    intermediate,
                    _raiseExceptionAt,
                    1,
                    _exceptionToRaise,
                    () =>
                    {
                        _onFault?.Invoke();
                        _injectFault = false;
                    });
            }
        }
    }
}
