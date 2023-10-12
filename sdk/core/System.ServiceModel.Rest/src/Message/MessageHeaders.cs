// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace System.ServiceModel.Rest.Core;

public abstract class MessageHeaders
{
    public abstract int Count { get; }

    public abstract bool TryGetHeader(string name, out string? value);

    public abstract bool TryGetHeaders(out IEnumerable<MessageHeader<string, object>> values);

    public abstract void Add(string name, string value);

    public abstract void Set(string name, string value);

    public abstract bool Remove(string name);
}

public readonly struct MessageHeader<TName, TValue>
{
    public MessageHeader(TName name, TValue value)
    {
        Name = name;
        Value = value;
    }

    public TName Name { get; }

    public TValue Value { get; }
}