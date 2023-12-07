// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace System.ClientModel.Primitives;

public abstract class MessageHeaders
{
    // TODO: why do we need this?
    public abstract int Count { get; }

    public abstract void Add(string name, string value);

    public abstract void Set(string name, string value);

    public abstract bool Remove(string name);

    public abstract bool TryGetValue(string name, out string? value);

    public abstract bool TryGetValues(string name, out IEnumerable<string>? values);

    public abstract bool TryGetHeaders(out IEnumerable<KeyValuePair<string, IEnumerable<string>>> headers);

    public abstract bool TryGetHeaders(out IEnumerable<KeyValuePair<string, string>> headers);
}
