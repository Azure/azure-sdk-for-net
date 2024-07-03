// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.Collections.Generic;

namespace ClientModel.Tests.PagingClient;

public class MockPagingData
{
    public const int Count = 16;
    public const int DefaultPageSize = 8;
    public const int DefaultOffset = 0;
    public const string DefaultOrder = "asc";

    public static IEnumerable<ValueItem> GetValues()
    {
        for (int i = 0; i < Count; i++)
        {
            yield return new ValueItem(i, $"{i}");
        }
    }

    public static ClientResult GetPageResult(IEnumerable<ValueItem> values)
        => ClientResult.FromResponse(new MockValueItemPageResponse(values));
}
