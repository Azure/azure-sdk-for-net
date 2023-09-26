// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Net.Http;

namespace System.ServiceModel.Rest.Core;

// TODO: this does not include some members from Response (e.g. ClientRequestId). Is that OK?
public class PipelineResponse : IDisposable
{
    private readonly HttpResponseMessage? _netResponse;
    private readonly Stream? _contentStream;

    protected PipelineResponse() { }

    internal PipelineResponse(HttpResponseMessage netResponse, Stream? contentStream)//, PipelineMessage message)
    {
        _netResponse = netResponse ?? throw new ArgumentNullException(nameof(netResponse));
        //_netContent = _netResponse.Content;

        // TODO: Why do we handle these separately?
        _contentStream = contentStream;

        //IsError = message.ResponseErrorClassifier.IsErrorResponse(message);
    }

    private void EnsureValid(string name)
    {
        if (_netResponse is null)
        {
            throw new InvalidOperationException($"Must initialize response to retrieve '{name}'.");
        }
    }

    public virtual int Status
    {
        get
        {
            EnsureValid(nameof(Status));

            return (int)_netResponse!.StatusCode;
        }
    }

    public virtual string ReasonPhrase
    {
        get
        {
            EnsureValid(nameof(ReasonPhrase));

            return _netResponse!.ReasonPhrase;
        }
    }

    // TODO(matell): The .NET Framework team plans to add BinaryData.Empty in dotnet/runtime#49670, and we can use it then.
    private static readonly BinaryData s_EmptyBinaryData = new BinaryData(Array.Empty<byte>());

    // TODO: can we not duplicate this logic?  i.e. move it into the base class
    // so both this and Azure.Core Response get the same logic?
    public virtual BinaryData Content
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

    public virtual Stream? ContentStream
    {
        get => _contentStream;

        // TODO: Buffer content
        set => throw new NotSupportedException("Why?");
    }

    public virtual bool TryGetHeaderValue(string name, [NotNullWhen(true)] out string? value)
    {
        // TODO: headers
        value = default;
        return false;
    }

    /// <summary>
    /// Indicates whether the status code of the returned response is considered
    /// an error code.
    /// </summary>
    public virtual bool IsError { get; internal set; }

    public virtual void Dispose()
    {
        // TODO: implement pattern correctly
        _netResponse?.Dispose();
        _contentStream?.Dispose();
    }
}
