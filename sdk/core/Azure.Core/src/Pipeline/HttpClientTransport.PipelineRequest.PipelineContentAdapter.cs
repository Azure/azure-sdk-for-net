// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    public partial class HttpClientTransport
    {
        private sealed partial class PipelineRequest : Request
        {
            private sealed class PipelineContentAdapter : HttpContent
            {
                private readonly RequestContent _pipelineContent;
                private readonly CancellationToken _cancellationToken;

                public PipelineContentAdapter(RequestContent pipelineContent, CancellationToken cancellationToken)
                {
                    _pipelineContent = pipelineContent;
                    _cancellationToken = cancellationToken;
                }

                protected override async Task SerializeToStreamAsync(Stream stream, TransportContext? context) => await _pipelineContent.WriteToAsync(stream, _cancellationToken).ConfigureAwait(false);

                protected override bool TryComputeLength(out long length) => _pipelineContent.TryComputeLength(out length);

#if NET5_0_OR_GREATER
                protected override async Task SerializeToStreamAsync(Stream stream, TransportContext? context, CancellationToken cancellationToken)
                {
                    await _pipelineContent!.WriteToAsync(stream, cancellationToken).ConfigureAwait(false);
                }

                protected override void SerializeToStream(Stream stream, TransportContext? context, CancellationToken cancellationToken)
                {
                    _pipelineContent.WriteTo(stream, cancellationToken);
                }
#endif
            }
        }
    }
}
