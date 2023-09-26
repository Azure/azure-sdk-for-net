// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Net.Http;
using System.ServiceModel.Rest.Core;

namespace System.ServiceModel.Rest;

/// <summary>
/// TBD.
/// </summary>
public partial class MessagePipelineTransport : PipelineTransport<PipelineMessage>, IDisposable
{
    private sealed class MessagePipelineResponse : PipelineResponse
    {
        private readonly HttpResponseMessage _netResponse;

        private readonly HttpContent _netContent;

        private Stream? _contentStream;

        public MessagePipelineResponse(HttpResponseMessage netResponse, Stream? contentStream)
        {
            _netResponse = netResponse ?? throw new ArgumentNullException(nameof(netResponse));
            _netContent = _netResponse.Content;

            // TODO: Why do we handle these separately?
            _contentStream = contentStream;
        }

        public override int Status => (int)_netResponse.StatusCode;

        public override BinaryData Content => throw new NotImplementedException();

        public override Stream? ContentStream { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override string ReasonPhrase => _netResponse.ReasonPhrase ?? string.Empty;

        public override bool TryGetHeaderValue(string name, [NotNullWhen(true)] out string? value)
        {
            // TODO: headers
            value = default;
            return false;
        }

        // TODO: What about Dispose?
    }
}
