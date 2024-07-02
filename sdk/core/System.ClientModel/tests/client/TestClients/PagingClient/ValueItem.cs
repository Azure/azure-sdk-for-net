// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace ClientModel.Tests.PagingClient;

// A mock model that illustrate values that can be returned in a page collection
public class ValueItem
{
    public ValueItem(int id, string value)
    {
        Id = id;
        Value = value;
    }

    public int Id { get; }
    public string Value { get; }
}
