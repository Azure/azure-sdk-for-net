// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Sse
{
    // SSE specification: https://html.spec.whatwg.org/multipage/server-sent-events.html#parsing-an-event-stream
    public sealed class SseReader : IDisposable
    {
        private readonly Stream _stream;
        private readonly StreamReader _reader;
        private bool _disposedValue;

        public SseReader(Stream stream)
        {
            _stream = stream;
            _reader = new StreamReader(stream);
        }

        public SseLine? TryReadSingleFieldEvent() // CancellationToken cancellationToken = default)
        {
            while (true)
            {
                var line = TryReadLine(); // cancellationToken);
                if (line == null)
                    return null;
                if (line.Value.IsEmpty)
                    throw new InvalidDataException("event expected.");
                var empty = TryReadLine(); // cancellationToken);
                if (empty != null && !empty.Value.IsEmpty)
                    throw new NotSupportedException("Multi-filed events not supported.");
                if (!line.Value.IsComment)
                    return line; // skip comment lines
            }
        }

        public async Task<SseLine?> TryReadSingleFieldEventAsync() // CancellationToken cancellationToken = default)
        {
            while (true)
            {
                var line = await TryReadLineAsync().ConfigureAwait(false); // cancellationToken).ConfigureAwait(false);
                if (line == null)
                    return null;
                if (line.Value.IsEmpty)
                    throw new InvalidDataException("event expected.");
                var empty = await TryReadLineAsync().ConfigureAwait(false); // cancellationToken).ConfigureAwait(false);
                if (empty != null && !empty.Value.IsEmpty)
                    throw new NotSupportedException("Multi-filed events not supported.");
                if (!line.Value.IsComment)
                    return line; // skip comment lines
            }
        }

        // TODO: we should support cancellation tokens, but StreamReader does not in NS2
        public SseLine? TryReadLine() // CancellationToken cancellationToken = default)
        {
            if (_reader.EndOfStream)
                return null;
            string lineText = _reader.ReadLine();
            if (lineText.Length == 0)
                return SseLine.Empty;
            if (TryParseLine(lineText, out var line))
                return line;
            return null;
        }

        // TODO: we should support cancellation tokens, but StreamReader does not in NS2
        public async Task<SseLine?> TryReadLineAsync() // CancellationToken cancellationToken = default)
        {
            if (_reader.EndOfStream)
                return null;
            string lineText = await _reader.ReadLineAsync().ConfigureAwait(false);
            if (lineText.Length == 0)
                return SseLine.Empty;
            if (TryParseLine(lineText, out var line))
                return line;
            return null;
        }

        private static bool TryParseLine(string lineText, out SseLine line)
        {
            if (lineText.Length == 0)
            {
                line = default;
                return false;
            }

            int colonIndex = lineText.IndexOf(':');

            var lineSpan = lineText.AsSpan();
            var fieldValue = lineSpan.Slice(colonIndex + 1);

            bool hasSpace = false;
            if (fieldValue.Length > 0 && fieldValue[0] == ' ')
                hasSpace = true;
            line = new SseLine(lineText, colonIndex, hasSpace);
            return true;
        }

        private void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _reader.Dispose();
                    _stream.Dispose();
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~SseReader()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }

    public readonly struct SseLine
    {
        private readonly string _original;
        private readonly int _colonIndex;
        private readonly int _valueIndex;

        public static SseLine Empty { get; } = new SseLine(string.Empty, 0, false);

        internal SseLine(string original, int colonIndex, bool hasSpaceAfterColon)
        {
            _original = original;
            _colonIndex = colonIndex;
            _valueIndex = colonIndex + (hasSpaceAfterColon ? 2 : 1);
        }

        public bool IsEmpty => _original.Length == 0;
        public bool IsComment => !IsEmpty && _original[0] == ':';

        // TODO: we should not expose UTF16 publicly
        public ReadOnlyMemory<char> FieldName => _original.AsMemory(0, _colonIndex);
        public ReadOnlyMemory<char> FieldValue => _original.AsMemory(_valueIndex);

        public override string ToString() => _original;
    }
}
