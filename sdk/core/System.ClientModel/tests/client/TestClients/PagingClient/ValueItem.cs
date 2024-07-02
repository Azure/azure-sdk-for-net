// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace ClientModel.Tests.PagingClient;

// A mock model that illustrate values that can be returned in a page collection
public class ValueItem
{
    public ValueItem(string id)
    {
        Id = id;
    }

    public string Id { get; }
}
