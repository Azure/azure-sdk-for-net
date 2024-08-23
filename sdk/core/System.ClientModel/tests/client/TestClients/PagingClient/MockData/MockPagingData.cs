// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.Collections.Generic;
using System.Linq;

namespace ClientModel.Tests.Paging;

public class MockPagingData
{
    public const int Count = 16;

    public const string DefaultOrder = "asc";
    public const int DefaultPageSize = 8;
    public const int DefaultOffset = 0;

    // Source of all the data
    public static IEnumerable<ValueItem> GetValues()
    {
        for (int i = 0; i < Count; i++)
        {
            yield return new ValueItem(i, $"{i}");
        }
    }

    // Filters on top of data source
    public static IEnumerable<ValueItem> GetValues(
        string? order,
        int? pageSize,
        int? offset)
    {
        order ??= DefaultOrder;
        pageSize ??= DefaultPageSize;
        offset ??= DefaultOffset;

        IEnumerable<ValueItem> ordered = order == "asc" ?
            GetValues() :
            GetValues().Reverse();
        IEnumerable<ValueItem> skipped = ordered.Skip(offset.Value);
        IEnumerable<ValueItem> page = skipped.Take(pageSize.Value);

        return page;
    }

    // Turn data into a page result for protocol layer
    public static ClientResult GetPageResult(IEnumerable<ValueItem> values)
        => ClientResult.FromResponse(new MockValueItemPageResponse(values));
}
