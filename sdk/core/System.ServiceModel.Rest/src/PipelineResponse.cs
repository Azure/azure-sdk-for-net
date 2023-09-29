// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Net.Http;

namespace System.ServiceModel.Rest.Core;

public class PipelineResponse : IDisposable
{
    // TODO: pull this out of the base class, as it brings in an HTTP dependency.
    private readonly HttpResponseMessage? _netResponse;
    private readonly Stream? _contentStream;

    private bool _disposed;

    protected PipelineResponse() { }

    internal PipelineResponse(HttpResponseMessage netResponse, Stream? contentStream)
    {
        _netResponse = netResponse ?? throw new ArgumentNullException(nameof(netResponse));

        //_netContent = _netResponse.Content;

        // TODO: Why does Azure.Core handle the System.Net response content separately?
        _contentStream = contentStream;
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
            return _netResponse!.ReasonPhrase!;
        }
    }

    // TODO(matell): The .NET Framework team plans to add BinaryData.Empty in dotnet/runtime#49670, and we can use it then.
    private static readonly BinaryData s_EmptyBinaryData = new BinaryData(Array.Empty<byte>());

    public virtual BinaryData Content
    {
        get
        {
            if (ContentStream == null)
            {
                return s_EmptyBinaryData;
            }

            // TODO: is this still a valid check for buffering?
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
    public virtual bool IsError { get; set; }

    private void EnsureValid(string name)
    {
        if (_netResponse is null)
        {
            throw new InvalidOperationException($"Must initialize response to retrieve '{name}'.");
        }
    }

    #region IDisposable

    protected virtual void Dispose(bool disposing)
    {
        if (disposing && !_disposed)
        {
            var netResponse = _netResponse;
            netResponse?.Dispose();

            var contentStream = _contentStream;
            contentStream?.Dispose();

            _disposed = true;
        }
    }

    public virtual void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    #endregion
}
