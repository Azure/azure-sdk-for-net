// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace System.ClientModel.Internal;

internal class AsyncServerSentEventJsonDataEnumerator<T> : AsyncServerSentEventJsonDataEnumerator<T, T>
    where T : IJsonModel<T>
{
    public AsyncServerSentEventJsonDataEnumerator(AsyncServerSentEventEnumerator eventEnumerator) : base(eventEnumerator)
    { }
}

internal class AsyncServerSentEventJsonDataEnumerator<TInstanceType, TJsonDataType> : IAsyncEnumerator<TInstanceType>, IDisposable, IAsyncDisposable
    where TJsonDataType : IJsonModel<TJsonDataType>
{
    private readonly AsyncServerSentEventEnumerator _eventEnumerator;
    private IEnumerator<TInstanceType>? _currentInstanceEnumerator;

    private TInstanceType? _current;

    // TODO: is null supression the correct pattern here?
    public TInstanceType Current { get => _current!; }

    public AsyncServerSentEventJsonDataEnumerator(AsyncServerSentEventEnumerator eventEnumerator)
    {
        Argument.AssertNotNull(eventEnumerator, nameof(eventEnumerator));

        _eventEnumerator = eventEnumerator;
    }

    public async ValueTask<bool> MoveNextAsync()
    {
        if (_currentInstanceEnumerator?.MoveNext() == true)
        {
            _current = _currentInstanceEnumerator.Current;
            return true;
        }

        if (await _eventEnumerator.MoveNextAsync().ConfigureAwait(false))
        {
            using JsonDocument eventDocument = JsonDocument.Parse(_eventEnumerator.Current.Data);
            BinaryData eventData = BinaryData.FromObjectAsJson(eventDocument.RootElement);
            TJsonDataType? jsonData = ModelReaderWriter.Read<TJsonDataType>(eventData);

            if (jsonData is null)
            {
                _current = default;
                return false;
            }

            if (jsonData is TInstanceType singleInstanceData)
            {
                _current = singleInstanceData;
                return true;
            }

            if (jsonData is IEnumerable<TInstanceType> instanceCollectionData)
            {
                _currentInstanceEnumerator = instanceCollectionData.GetEnumerator();
                if (_currentInstanceEnumerator.MoveNext() == true)
                {
                    _current = _currentInstanceEnumerator.Current;
                    return true;
                }
            }
        }
        return false;
    }

    public async ValueTask DisposeAsync()
    {
        await _eventEnumerator.DisposeAsync().ConfigureAwait(false);
    }

    public void Dispose()
    {
        _eventEnumerator.Dispose();
    }
}
