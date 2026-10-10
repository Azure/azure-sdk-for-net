// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Containers.Apps.Sandbox.Models;

namespace Azure.Containers.Apps.Sandbox
{
    /// <summary> A read-only stream of process snapshots in the service's raw top output format. </summary>
    public class SandboxProcessStream : IDisposable, IAsyncDisposable
    {
        private readonly SandboxStream _stream;

        /// <summary> Initializes a stream for mocking. </summary>
        protected SandboxProcessStream() { }

        internal SandboxProcessStream(SandboxStream stream) =>
            _stream = stream ?? throw new ArgumentNullException(nameof(stream));

        /// <summary> Reads the next complete process snapshot, or null when the stream closes. </summary>
        public virtual async Task<string> ReadSnapshotAsync(CancellationToken cancellationToken = default)
        {
            SandboxStreamMessage message = await _stream.ReceiveMessageAsync(cancellationToken).ConfigureAwait(false);
            if (message.Type == SandboxStreamMessageType.Close)
                return null;
            if (message.Type != SandboxStreamMessageType.Text)
                throw new InvalidDataException("Process stream messages must be text.");
            return message.Data.ToString();
        }

        /// <inheritdoc />
        public void Dispose() => _stream?.Dispose();

        /// <inheritdoc />
        public virtual ValueTask DisposeAsync() => _stream?.DisposeAsync() ?? default;
    }
}
