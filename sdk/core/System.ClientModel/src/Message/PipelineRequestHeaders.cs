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

    /// <summary>
    /// Attempts to retrieve the value associated with the specified header name.
    /// </summary>
    /// <param name="name">The name of the header to retrieve.</param>
    /// <param name="value">The specified header value.</param>
    /// <returns>true if the specified header name and value are stored in the collection; otherwise false.</returns>
    public abstract bool TryGetValue(string name, out string? value);

    /// <summary>
    /// Attempts to retrieve the values associated with the specified header name.
    /// </summary>
    /// <param name="name">The name of the header to retrieve.</param>
    /// <param name="values">The specified header values.</param>
    /// <returns>true if the specified header name and values are stored in the collection; otherwise false.</returns>
    public abstract bool TryGetValues(string name, out IEnumerable<string>? values);

    public abstract IEnumerator<KeyValuePair<string, string>> GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
