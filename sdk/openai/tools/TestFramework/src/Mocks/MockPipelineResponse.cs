// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace OpenAI.TestFramework.Mocks;

/// <summary>
/// A mock implementation of a pipeline response
/// </summary>
public class MockPipelineResponse : PipelineResponse
{
    private Stream? _contentStream;
    private BinaryData? _buffered;

    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="status">(Optional) The HTTP status.</param>
    /// <param name="reasonPhrase">(Optional) The HTTP reason phrase.</param>
    /// <param name="content">(Optional) The HTTP response body content.</param>
    public MockPipelineResponse(
        int? status = null,
        string? reasonPhrase = null,
        BinaryData? content = null)
    {
        Status = status ?? 200;
        ReasonPhrase = reasonPhrase ?? "OK";
        _buffered = content;
        ContentStream = content?.ToStream();
        HeadersCore = new MockResponseHeaders();
    }

    /// <inheritdoc />
    public override int Status { get; }

    /// <inheritdoc />
    public override string ReasonPhrase { get; }

    /// <inheritdoc />
    public override Stream? ContentStream
    {
        get => _contentStream;
        set
        {
            _contentStream = value;
            _buffered = null;
        }
    }

    /// <inheritdoc />
    public override BinaryData Content => _buffered ?? throw new InvalidOperationException("Response content is not yet buffered");

    /// <inheritdoc />
    protected override PipelineResponseHeaders HeadersCore { get; }

    /// <inheritdoc />
    public override BinaryData BufferContent(CancellationToken cancellationToken = default)
        => BufferContentSyncAsync(false, cancellationToken).GetAwaiter().GetResult();

    /// <inheritdoc />
    public override ValueTask<BinaryData> BufferContentAsync(CancellationToken cancellationToken = default)
        => BufferContentSyncAsync(true, cancellationToken);

    /// <inheritdoc />
    public override void Dispose()
    {
        ContentStream?.Dispose();
    }

    private async ValueTask<BinaryData> BufferContentSyncAsync(bool isAsync, CancellationToken token)
    {
        if (_buffered != null)
        {
            return _buffered;
        }

        _buffered = ContentStream == null
            ? BinaryData.FromBytes(Array.Empty<byte>())
            : isAsync
                ? await BinaryData.FromStreamAsync(ContentStream, token).ConfigureAwait(false)
                : BinaryData.FromStream(ContentStream);

        _contentStream?.Dispose();
        _contentStream = _buffered.ToStream();
        return _buffered;
    }
}
