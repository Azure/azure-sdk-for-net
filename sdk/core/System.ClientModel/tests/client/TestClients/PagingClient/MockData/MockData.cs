// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.Collections.Generic;
using System.Text;

namespace ClientModel.Tests.PagingClient;

internal class MockData
{
    private const int Count = 16;

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
