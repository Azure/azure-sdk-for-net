// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace System.ClientModel.Internal;

#pragma warning disable CS1591 // public XML comments
/// <summary>
/// Represents an operation response with streaming content that can be deserialized and enumerated while the response
/// is still being received.
/// </summary>
/// <typeparam name="T"> The data type representative of distinct, streamable items. </typeparam>
public class StreamingClientResult<T> : IAsyncEnumerable<T>
{
    private readonly PipelineResponse _response;
    private readonly Func<Stream, CancellationToken, IAsyncEnumerator<T>> _asyncEnumeratorSourceDelegate;

    private bool _disposedValue;

    /// <summary>
    /// Gets the underlying <see cref="PipelineResponse"/> that contains headers and other response-wide information.
    /// </summary>
    /// <returns>
    /// The <see cref="PipelineResponse"/> instance used in this <see cref="StreamingClientResult{T}"/>.
    /// </returns>
    public PipelineResponse GetRawResponse() => _response;

    private StreamingClientResult(PipelineResponse response, Func<Stream, CancellationToken, IAsyncEnumerator<T>> asyncEnumeratorSourceDelegate)
    {
        _response = response;
        _asyncEnumeratorSourceDelegate = asyncEnumeratorSourceDelegate;
    }

    /// <summary>
    /// Creates a new instance of <see cref="StreamingClientResult{T}"/> that will yield items of the specified type
    /// <typeparamref name="T"/> as they become available via server-sent event JSON data on the available
    /// <see cref="PipelineResponse.ContentStream"/>. This overload uses <see cref="ModelReaderWriter"/> via the
    /// <see cref="IJsonModel{T}"/> interface and only supports single-item deserialization per server-sent event data
    /// payload.
    /// </summary>
    /// <param name="response"> The base <see cref="PipelineResponse"/> for this result instance. </param>
    /// <param name="cancellationToken">
    /// The optional cancellation token used to control the enumeration.
    /// </param>
    /// <returns> A new instance of <see cref="StreamingClientResult{T}"/>. </returns>
    public static StreamingClientResult<U> Create<U>(PipelineResponse response, CancellationToken cancellationToken = default)
        where U : IJsonModel<U>
    {
        return new(response, GetServerSentEventDeserializationEnumerator<U>);
    }

    public static StreamingClientResult<TInstanceType> Create<TInstanceType, TJsonDataType>(PipelineResponse response, CancellationToken cancellationToken = default)
        where TJsonDataType : IJsonModel<TJsonDataType>
    {
        return new(response, GetServerSentEventDeserializationEnumerator<TInstanceType, TJsonDataType>);
    }

    private static IAsyncEnumerator<U> GetServerSentEventDeserializationEnumerator<U>(Stream stream, CancellationToken cancellationToken = default)
        where U : IJsonModel<U>
    {
        return GetServerSentEventDeserializationEnumerator<U, U>(stream, cancellationToken);
    }

    private static IAsyncEnumerator<TInstanceType> GetServerSentEventDeserializationEnumerator<TInstanceType, TJsonDataType>(
        Stream stream,
        CancellationToken cancellationToken = default)
            where TJsonDataType : IJsonModel<TJsonDataType>
    {
        ServerSentEventReader sseReader = null;
        AsyncServerSentEventEnumerator sseEnumerator = null;
        try
        {
            sseReader = new(stream);
            sseEnumerator = new(sseReader, cancellationToken);
            AsyncServerSentEventJsonDataEnumerator<TInstanceType, TJsonDataType> instanceEnumerator = new(sseEnumerator);
            sseEnumerator = null;
            sseReader = null;
            return instanceEnumerator;
        }
        finally
        {
            sseEnumerator?.Dispose();
            sseReader?.Dispose();
        }
    }

    IAsyncEnumerator<T> IAsyncEnumerable<T>.GetAsyncEnumerator(CancellationToken cancellationToken)
    {
        return _asyncEnumeratorSourceDelegate.Invoke(_response.ContentStream, cancellationToken);
    }
}
#pragma warning restore CS1591 // public XML comments
