// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;

namespace System.ClientModel.Primitives;

public abstract class PipelineResponseHeaders : IEnumerable<KeyValuePair<string, string>>
{
    public abstract bool TryGetValue(string name, out string? value);

    public abstract bool TryGetValues(string name, out IEnumerable<string>? values);

    public abstract IEnumerator<KeyValuePair<string, string>> GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
