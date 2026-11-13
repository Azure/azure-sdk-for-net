// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Threading;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Models;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.DataCollection
{
    /// <summary>
    /// Implements a double buffering mechanism for handling DocumentIngress objects.
    /// This allows for concurrent writes to one buffer while the other can be read from or processed.
    /// The 'WriteDocument' method is used to add documents to the current active buffer.
    /// The 'FlipDocumentBuffers' method swaps the current buffer with a new one, allowing the
    /// consumer to process the documents in the returned buffer without interference from ongoing writes.
    /// </summary>
    internal class DoubleBuffer
    {
        private ConcurrentQueue<DocumentIngress> _currentBuffer = new();

        public void WriteDocument(DocumentIngress document)
        {
            _currentBuffer.Enqueue(document);
        }

        public ConcurrentQueue<DocumentIngress> FlipDocumentBuffers()
        {
            // Atomically exchange the current buffer with a new empty buffer and return the old buffer
            return Interlocked.Exchange(ref _currentBuffer, new ConcurrentQueue<DocumentIngress>());
        }
    }
}
