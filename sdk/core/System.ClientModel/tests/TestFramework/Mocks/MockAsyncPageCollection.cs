// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ClientModel.Tests.Mocks;

public class MockAsyncPageCollection<T> : AsyncPageCollection<T>
{
    private readonly List<T> _values;
    private readonly int _pageSize;

    private int _current;

    public MockAsyncPageCollection(List<T> values, int pageSize)
    {
        _values = values;
        _pageSize = pageSize;
    }

    protected override async IAsyncEnumerator<PageResult<T>> GetAsyncEnumeratorCore(CancellationToken cancellationToken)
    {
        while (_current < _values.Count)
        {
            int pageSize = Math.Min(_pageSize, _values.Count - _current);
            List<T> pageValues = _values.GetRange(_current, pageSize);

            // Make page tokens not useful for mocks.
            ContinuationToken mockPageToken = ContinuationToken.FromBytes(BinaryData.FromString("{}"));
            yield return PageResult<T>.Create(pageValues, mockPageToken, null, new MockPipelineResponse(200));

            _current += _pageSize;

            await Task.Delay(0);
        }
    }
}
