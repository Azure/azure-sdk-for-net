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
    private sealed class MessagePipelineResponse : PipelineResponse, IDisposable
    {
        private readonly HttpResponseMessage _netResponse;

        //private readonly HttpContent _netContent;

        private readonly Stream? _contentStream;

        public MessagePipelineResponse(HttpResponseMessage netResponse, Stream? contentStream)
        {
            _netResponse = netResponse ?? throw new ArgumentNullException(nameof(netResponse));
            //_netContent = _netResponse.Content;

            // TODO: Why do we handle these separately?
            _contentStream = contentStream;
        }

        public override int Status => (int)_netResponse.StatusCode;

        // TODO(matell): The .NET Framework team plans to add BinaryData.Empty in dotnet/runtime#49670, and we can use it then.
        private static readonly BinaryData s_EmptyBinaryData = new BinaryData(Array.Empty<byte>());

        // TODO: can we not duplicate this logic?  i.e. move it into the base class
        // so both this and Azure.Core Response get the same logic?
        public override BinaryData Content
        {
            get
            {
                if (ContentStream == null)
                {
                    return s_EmptyBinaryData;
                }

                if (ContentStream is not MemoryStream memoryContent)
                {
                    throw new InvalidOperationException($"The response is not fully buffered.");
                }

                if (memoryContent.TryGetBuffer(out ArraySegment<byte> segment))
                {
                    return new BinaryData(segment.AsMemory());
                }
                else
                {
                    return new BinaryData(memoryContent.ToArray());
                }
            }
        }

        public override Stream? ContentStream
        {
            get => _contentStream;

            // TODO: Buffer content
            set => throw new NotSupportedException("Why?");
        }

        public override string ReasonPhrase => _netResponse.ReasonPhrase ?? string.Empty;

        public override bool TryGetHeaderValue(string name, [NotNullWhen(true)] out string? value)
        {
            // TODO: headers
            value = default;
            return false;
        }

        public void Dispose()
        {
            // TODO: implement pattern correctly
            _netResponse?.Dispose();
            _contentStream?.Dispose();
        }
    }
}
