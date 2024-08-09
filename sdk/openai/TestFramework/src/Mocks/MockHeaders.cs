// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace OpenAI.TestFramework.Mocks;

/// <summary>
/// Basic implementation of headers.
/// </summary>
public class MockHeaders
{
    private IDictionary<string, IList<string>> _headers =
        new Dictionary<string, IList<string>>(StringComparer.OrdinalIgnoreCase);

    /// <summary>
    /// Adds a header value.
    /// </summary>
    /// <param name="name">The name of the header.</param>
    /// <param name="value">The value to add.</param>
    public virtual void Add(string name, string value)
    {
        IList<string>? existing;
        if (!_headers.TryGetValue(name, out existing))
        {
            existing = new List<string>();
            _headers[name] = existing;
        }

        existing.Add(value);
    }

    /// <summary>
    /// Removes all values of a header.
    /// </summary>
    /// <param name="name">The name of the header to remove.</param>
    /// <returns>True if we removed a value, false otherwise.</returns>
    public virtual bool Remove(string name) => _headers.Remove(name);

    /// <summary>
    /// Sets the value for a header. This will override all existing values.
    /// </summary>
    /// <param name="name">The name of the header.</param>
    /// <param name="value">The value to set.</param>
    public virtual void Set(string name, string value) => _headers[name] = new List<string>() { value };

    /// <summary>
    /// Gets an enumerator for the header values. In the case of a header with more than one value, they will be joined into
    /// a single comma separated string.
    /// </summary>
    /// <returns>The enumerator.</returns>
    public virtual IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        => _headers
            .Select(kvp => new KeyValuePair<string, string>(kvp.Key, string.Join(",", kvp.Value)))
            .GetEnumerator();

    /// <summary>
    /// Gets the value for a header. In the case of a header with more than one value, they will be joined into a single comma
    /// separated string.
    /// </summary>
    /// <param name="name">The name of the header.</param>
    /// <param name="value">The value of the headers</param>
    /// <returns>True if the header was found, false otherwise.</returns>
    public virtual bool TryGetValue(string name, out string? value)
    {
        if (_headers.TryGetValue(name, out IList<string>? existing))
        {
            value = string.Join(",", existing);
            return true;
        }

        value = null;
        return false;
    }

    /// <summary>
    /// Gets the values for a header.
    /// </summary>
    /// <param name="name">The name of the header.</param>
    /// <param name="values">All of the values for the header.</param>
    /// <returns>True if the header was found, false otherwise.</returns>
    public virtual bool TryGetValues(string name, out IEnumerable<string>? values)
    {
        if (_headers.TryGetValue(name, out IList<string>? existing))
        {
            values = existing;
            return true;
        }

        values = null;
        return false;
    }
}
