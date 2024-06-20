// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;

namespace System.ClientModel.Primitives;

/// <summary>
/// A collection of HTTP response headers and their values.
/// </summary>
public abstract class PipelineResponseHeaders : IEnumerable<KeyValuePair<string, string>>
{
    /// <summary>
    /// Attempts to retrieve the value associated with the specified header
    /// name.
    /// </summary>
    /// <param name="name">The name of the header to retrieve.</param>
    /// <param name="value">The specified header value.</param>
    /// <returns><c>true</c> if the specified header name and value are stored
    /// in the collection; otherwise <c>false</c>.</returns>
    public abstract bool TryGetValue(string name, out string? value);

    /// <summary>
    /// Attempts to retrieve the values associated with the specified header name.
    /// </summary>
    /// <param name="name">The name of the header to retrieve.</param>
    /// <param name="values">The specified header values.</param>
    /// <returns><c>true</c> if the specified header name and values are stored
    /// in the collection; otherwise <c>false</c>.</returns>
    public abstract bool TryGetValues(string name, out IEnumerable<string>? values);

    /// <summary>
    /// Gets an enumerator that iterates through the <see cref="PipelineResponseHeaders"/>.
    /// </summary>
    /// <returns>An enumerator that iterates through the <see cref="PipelineResponseHeaders"/>.</returns>
    public abstract IEnumerator<KeyValuePair<string, string>> GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
