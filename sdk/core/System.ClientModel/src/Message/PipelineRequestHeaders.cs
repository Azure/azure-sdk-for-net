// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;

namespace System.ClientModel.Primitives;

public abstract class PipelineRequestHeaders : IEnumerable<KeyValuePair<string, string>>
{
    public abstract void Add(string name, string value);

    public abstract void Set(string name, string value);

    public abstract bool Remove(string name);

    public abstract bool TryGetValue(string name, out string? value);

    public abstract bool TryGetValues(string name, out IEnumerable<string>? values);

    public abstract IEnumerator<KeyValuePair<string, string>> GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
