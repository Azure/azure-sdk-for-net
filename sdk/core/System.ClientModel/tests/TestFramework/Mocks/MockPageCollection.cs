// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;

namespace ClientModel.Tests.Mocks;

public class MockPageCollection<T> : PageCollection<T>
{
    private readonly List<T> _values;
    private readonly int _pageSize;

    private int _current;

    public MockPageCollection(List<T> values, int pageSize)
    {
        _values = values;
        _pageSize = pageSize;
    }

    protected override PageResult<T> GetCurrentPageCore()
        => GetPageFromCurrentState();

    protected override IEnumerator<PageResult<T>> GetEnumeratorCore()
    {
        while (_current < _values.Count)
        {
            yield return GetPageFromCurrentState();

            _current += _pageSize;
        }
    }

    private PageResult<T> GetPageFromCurrentState()
    {
        int pageSize = Math.Min(_pageSize, _values.Count - _current);
        List<T> pageValues = _values.GetRange(_current, pageSize);

        // Make page tokens not useful for mocks.
        ContinuationToken mockPageToken = ContinuationToken.FromBytes(BinaryData.FromString("{}"));
        return PageResult<T>.Create(pageValues, mockPageToken, null, new MockPipelineResponse(200));
    }
}
