// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Internal;

/// <summary>
/// A minimal PipelineResponse implementation used internally by static
/// collection result types returned from factory methods like
/// <see cref="CollectionResult{T}.FromPages"/>.
/// </summary>
internal class StaticPipelineResponse : PipelineResponse
{
    private readonly BinaryData _content;
    private Stream? _contentStream;
    private bool _disposed;

    public StaticPipelineResponse(BinaryData? content = null, int pageIndex = 0)
    {
        _content = content ?? new BinaryData(Array.Empty<byte>());
        PageIndex = pageIndex;
    }

    internal int PageIndex { get; }

    public override int Status => 200;

    public override string ReasonPhrase => "OK";

    protected override PipelineResponseHeaders HeadersCore { get; } =
        new StaticResponseHeaders();

    public override Stream? ContentStream
    {
        get => _contentStream ??= _content.ToStream();
        set => throw new NotSupportedException("StaticPipelineResponse is immutable; ContentStream cannot be set.");
    }

    public override BinaryData Content => _content;

    public override BinaryData BufferContent(CancellationToken cancellationToken = default)
        => _content;

    public override ValueTask<BinaryData> BufferContentAsync(CancellationToken cancellationToken = default)
        => new(_content);

    public override void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (disposing && !_disposed)
        {
            _contentStream?.Dispose();
            _contentStream = null;
            _disposed = true;
        }
    }

    private class StaticResponseHeaders : PipelineResponseHeaders
    {
        public override IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            yield break;
        }

        public override bool TryGetValue(string name, out string? value)
        {
            value = null;
            return false;
        }

        public override bool TryGetValues(string name, out IEnumerable<string>? values)
        {
            values = null;
            return false;
        }
    }
}
