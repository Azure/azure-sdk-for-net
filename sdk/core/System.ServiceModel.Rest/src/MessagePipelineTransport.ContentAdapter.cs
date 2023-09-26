// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Net;
using System.Net.Http;
using System.ServiceModel.Rest.Core;
using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel.Rest;

/// <summary>
/// TBD.
/// </summary>
public partial class MessagePipelineTransport : PipelineTransport<PipelineMessage>, IDisposable
{
    private sealed class HttpContentAdapter : HttpContent
    {
        private readonly RequestBody _content;
        private readonly CancellationToken _cancellationToken;

        public HttpContentAdapter(RequestBody content, CancellationToken cancellationToken)
        {
            _content = content;
            _cancellationToken = cancellationToken;
        }

        protected override async Task SerializeToStreamAsync(Stream stream, TransportContext? context)
            => await _content.WriteToAsync(stream, _cancellationToken).ConfigureAwait(false);

        protected override bool TryComputeLength(out long length)
            => _content.TryComputeLength(out length);
    }
}
