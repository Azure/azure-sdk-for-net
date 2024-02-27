// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Models;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals
{
    /// <summary>
    /// Manages a thread-safe collection of DocumentIngress objects with a fixed capacity.
    /// </summary>
    internal class DocumentBuffer
    {
        private readonly ConcurrentQueue<DocumentIngress> _documents = new();
        private readonly int _capacity = 20;
        // ConcurrentQueue<T>.Count is not used because it is not an O(1) operation. Instead, we use a separate counter.
        // Atomic counter for the number of documents in the queue.
        private int _count = 0;

        public void Add(DocumentIngress document)
        {
            // Ensure the queue does not exceed capacity.
            if (Interlocked.CompareExchange(ref _count, 0, 0) < _capacity)
            {
                _documents.Enqueue(document);
                Interlocked.Increment(ref _count);
            }
            else
            {
                LiveMetricsExporterEventSource.Log.DroppedDocument(documentType: document.DocumentType);
            }
        }

        public IEnumerable<DocumentIngress> ReadAllAndClear()
        {
            // There is no need to decrement the count since we are clearing the queue. After this operation, the instance will not be used anymore.
            // The method 'Add' is not called while this method is running; therefore, the count will remain unchanged.
            while (_documents.TryDequeue(out DocumentIngress item))
            {
                yield return item;
            }
        }
    }
}
