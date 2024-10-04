// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using Azure.Monitor.OpenTelemetry.AspNetCore.Models;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.LiveMetrics.DataCollection
{
    /// <summary>
    /// Manages a thread-safe collection of DocumentIngress objects.
    /// </summary>
    internal class DocumentBuffer
    {
        private readonly ConcurrentQueue<DocumentIngress> _documents = new();

        public void Add(DocumentIngress document)
        {
            _documents.Enqueue(document);
        }

        public IEnumerable<DocumentIngress> ReadAllAndClear()
        {
            while (_documents.TryDequeue(out DocumentIngress? item))
            {
                yield return item;
            }
        }
    }
}
