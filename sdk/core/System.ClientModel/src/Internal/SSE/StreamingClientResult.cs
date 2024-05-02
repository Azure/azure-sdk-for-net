// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace System.ClientModel.Internal;

/// <summary>
/// Represents an operation response with streaming content that can be deserialized and enumerated while the response
/// is still being received.
/// </summary>
/// <typeparam name="T"> The data type representative of distinct, streamable items. </typeparam>
internal class StreamingClientResult<T> : AsyncClientResultCollection<T>
{
    private readonly Func<Stream, CancellationToken, IAsyncEnumerator<T>> _asyncEnumeratorSourceDelegate;

    // TODO: use?
    //private bool _disposedValue;

    private StreamingClientResult(PipelineResponse response, Func<Stream, CancellationToken, IAsyncEnumerator<T>> asyncEnumeratorSourceDelegate)
        : base(response)
    {
        Argument.AssertNotNull(response, nameof(response));

        if (response.ContentStream is null)
        {
            throw new ArgumentException("Unable to create result from response with null ContentStream", nameof(response));
        }

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
        ServerSentEventReader? sseReader = null;
        AsyncServerSentEventEnumerator? sseEnumerator = null;
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

    public override IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken)
    {
        return _asyncEnumeratorSourceDelegate.Invoke(GetRawResponse().ContentStream!, cancellationToken);
    }
}
