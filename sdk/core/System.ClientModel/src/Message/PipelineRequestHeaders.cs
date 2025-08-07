// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;

namespace System.ClientModel.Primitives;

/// <summary>
/// Represents the collection of HTTP headers on a <see cref="PipelineRequest"/>.
/// </summary>
public abstract class PipelineRequestHeaders : IEnumerable<KeyValuePair<string, string>>
{
    /// <summary>
    /// Adds the specified header and its value to the request's header
    /// collection. If a header with this name is already present in the
    /// collection, the value will be added to the comma-separated list of
    /// values associated with the header.
    /// </summary>
    /// <param name="name">The name of the header to add.</param>
    /// <param name="value">The value of the header.</param>
    public abstract void Add(string name, string value);

    /// <summary>
    /// Sets the specified header and its value in the request's header
    /// collection. If a header with this name is already present in the
    /// collection, the header's value will be replaced with the specified value.
    /// </summary>
    /// <param name="name">The name of the header to set.</param>
    /// <param name="value">The value of the header.</param>
    public abstract void Set(string name, string value);

    /// <summary>
    /// Removes the specified header from the request's header collection.
    /// </summary>
    /// <param name="name">The name of the header to remove.</param>
    /// <returns><c>true</c> if the header was successfully removed; otherwise
    /// <c>false</c>.</returns>
    public abstract bool Remove(string name);

    /// <summary>
    /// Attempts to retrieve the value associated with the specified header name.
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

    /// <inheritdoc/>
    public abstract IEnumerator<KeyValuePair<string, string>> GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
