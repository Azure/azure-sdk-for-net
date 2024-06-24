// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;

namespace ClientModel.Tests.Mocks;

public class MockPageCollection<T> : PageCollection<T>
{
    private readonly List<T> _values;
    private readonly int _pageSize;
    private readonly List<ClientResult> _results;

    private int _current;
    private int _currentPage;

    public MockPageCollection(List<T> values, List<ClientResult> results, int pageSize)
    {
        Debug.Assert(results.Count % pageSize == 0);
        Debug.Assert(values.Count / pageSize == results.Count);

        _values = values;
        _results = results;
        _pageSize = pageSize;
        _current = 0;
    }

    public override BinaryData FirstPageToken
        => BinaryData.FromString(string.Empty);

    public override ClientPage<T> GetPage(BinaryData pageToken, RequestOptions? options = null)
    {
        int currPageSize = Math.Min(_pageSize, _values.Count - _current);

        List<T> values = _values.GetRange(_current, currPageSize);
        _current += _pageSize;

        BinaryData? nextPageToken = (_current >= _values.Count) ?
            null :
            new MockPageToken(_current).ToBytes();

        PipelineResponse response = _results[_currentPage++].GetRawResponse();

        return ClientPage<T>.Create(values, pageToken, nextPageToken, response);
    }

    private class MockPageToken
    {
        public MockPageToken(int index)
        {
            Index = index;
        }

        public int Index { get; }

        public BinaryData ToBytes() => BinaryData.FromString($"{Index}");

        public static MockPageToken FromBytes(BinaryData data)
            => new(data.ToMemory().Length == 0 ? 0 : int.Parse(data.ToString()));
    }
}
