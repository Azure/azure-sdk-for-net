// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Inference.Telemetry;

namespace Azure.Core.Sse
{
    internal static class SseAsyncEnumerator<T>
    {
        internal static async IAsyncEnumerable<T> EnumerateFromSseStream(
            Stream stream,
            Func<JsonElement, IEnumerable<T>> multiElementDeserializer,
            OpenTelemetryScope scope,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            try
            {
                using SseReader sseReader = new(stream);
                while (!cancellationToken.IsCancellationRequested)
                {
                    SseLine? sseEvent = null;
                    try
                    {
                        sseEvent = await sseReader.TryReadSingleFieldEventAsync().ConfigureAwait(false);
                    }
                    catch (Exception ex)
                    {
                        scope?.RecordError(ex);
                        throw;
                    }
                    if (sseEvent is not null)
                    {
                        ReadOnlyMemory<char> name = sseEvent.Value.FieldName;
                        if (!name.Span.SequenceEqual("data".AsSpan()))
                        {
                            throw new InvalidDataException();
                        }
                        ReadOnlyMemory<char> value = sseEvent.Value.FieldValue;
                        if (value.Span.SequenceEqual("[DONE]".AsSpan()))
                        {
                            break;
                        }
                        using JsonDocument sseMessageJson = JsonDocument.Parse(value);
                        IEnumerable<T> newItems = multiElementDeserializer.Invoke(sseMessageJson.RootElement);
                        foreach (T item in newItems)
                        {
                            scope?.UpdateStreamResponse(item);
                            yield return item;
                        }
                    }
                }
                if (cancellationToken.IsCancellationRequested)
                {
                    scope?.RecordCancellation();
                }
            }
            finally
            {
                // Always dispose the stream immediately once enumeration is complete for any reason
                stream.Dispose();
                scope?.Dispose();
            }
        }

        internal static IAsyncEnumerable<T> EnumerateFromSseStream(
            Stream stream,
            Func<JsonElement, T> elementDeserializer,
            OpenTelemetryScope scope,
            CancellationToken cancellationToken = default)
            => EnumerateFromSseStream(
                stream,
                (element) => new T[] { elementDeserializer.Invoke(element) },
                scope,
                cancellationToken);
    }
}
