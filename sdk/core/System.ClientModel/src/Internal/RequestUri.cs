// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Collections.Generic;

// TODO: Linq is bad for performance
using System.Linq;

namespace System.Net.ClientModel.Internal;

public class RequestUri
{
    #region RequestUriBuilder

    private const char QuerySeparator = '?';

    private const char PathSeparator = '/';

    private readonly StringBuilder _pathAndQuery = new StringBuilder();

    private int _queryIndex = -1;

    private Uri? _uri;

    private int _port;

    private string? _host;

    private string? _scheme;

    /// <summary>
    /// Gets or sets the scheme name of the URI.
    /// </summary>
    public virtual string? Scheme
    {
        get => _scheme;
        set
        {
            ResetUri();
            _scheme = value;
        }
    }

    /// <summary>
    /// Gets or sets the Domain Name System (DNS) host name or IP address of a server.
    /// </summary>
    public virtual string? Host
    {
        get => _host;
        set
        {
            ResetUri();
            _host = value;
        }
    }

    /// <summary>
    /// Gets or sets the port number of the URI.
    /// </summary>
    public virtual int Port
    {
        get => _port;
        set
        {
            ResetUri();
            _port = value;
        }
    }

    /// <summary>
    /// Gets or sets any query information included in the URI.
    /// </summary>
    public virtual string Query
    {
        get => HasQuery ? _pathAndQuery.ToString(_queryIndex, _pathAndQuery.Length - _queryIndex) : string.Empty;
        set
        {
            ResetUri();
            if (HasQuery)
            {
                _pathAndQuery.Remove(_queryIndex, _pathAndQuery.Length - _queryIndex);
                _queryIndex = -1;
            }

            if (!string.IsNullOrEmpty(value))
            {
                _queryIndex = _pathAndQuery.Length;
                if (value[0] != QuerySeparator)
                {
                    _pathAndQuery.Append(QuerySeparator);
                }
                _pathAndQuery.Append(value);
            }
        }
    }

    /// <summary>
    /// Gets or sets the path to the resource referenced by the URI.
    /// </summary>
    public virtual string Path
    {
        get => HasQuery ? _pathAndQuery.ToString(0, _queryIndex) : _pathAndQuery.ToString();
        set
        {
            if (HasQuery)
            {
                _pathAndQuery.Remove(0, _queryIndex);
                _pathAndQuery.Insert(0, value);
                _queryIndex = value.Length;
            }
            else
            {
                _pathAndQuery.Remove(0, _pathAndQuery.Length);
                _pathAndQuery.Append(value);
            }
        }
    }

    /// <summary> Gets whether or not this instance of <see cref="RequestUri"/> has a path. </summary>
    protected bool HasPath => PathLength > 0;

    /// <summary> Gets whether or not this instance of <see cref="RequestUri"/> has a query. </summary>
    protected bool HasQuery => _queryIndex != -1;

    private int PathLength => HasQuery ? _queryIndex : _pathAndQuery.Length;

    private int QueryLength => HasQuery ? _pathAndQuery.Length - _queryIndex : 0;

    /// <summary>
    /// Gets the path and query string to the resource referenced by the URI.
    /// </summary>
    public string PathAndQuery => _pathAndQuery.ToString();

    /// <summary>
    /// Replaces values inside this instance with values provided in the <paramref name="value"/> parameter.
    /// </summary>
    /// <param name="value">The <see cref="Uri"/> instance to get values from.</param>
    public virtual void Reset(Uri value)
    {
        Scheme = value.Scheme;
        Host = value.Host;
        Port = value.Port;
        Path = value.AbsolutePath;
        Query = value.Query;
        _uri = value;
    }

    /// <summary>
    /// Gets the <see cref="System.Uri"/> instance constructed by the specified <see cref="RequestUri"/> instance.
    /// </summary>
    /// <returns>
    /// A <see cref="System.Uri"/> that contains the URI constructed by the <see cref="RequestUri"/>.
    /// </returns>
    public virtual Uri ToUri()
    {
        if (_uri == null)
        {
            // TODO: this is a bad pattern and we should fix this when we're working
            // on making this type real
            try
            {
                _uri = new Uri(ToString());
            }
            catch (UriFormatException)
            {
                _uri = new Uri("https://www.example.com");
            }
        }

        return _uri;
    }

    /// <summary>
    /// Appends a query parameter adding separator if required. Escapes the value.
    /// </summary>
    /// <param name="name">The name of parameter.</param>
    /// <param name="value">The value of parameter.</param>
    public virtual void AppendQuery(string name, string value)
    {
        AppendQuery(name, value, true);
    }

    /// <summary>
    /// Appends a query parameter adding separator if required.
    /// </summary>
    /// <param name="name">The name of parameter.</param>
    /// <param name="value">The value of parameter.</param>
    /// <param name="escapeValue">Whether value should be escaped.</param>
    public virtual void AppendQuery(string name, string value, bool escapeValue)
    {
        if (escapeValue && !string.IsNullOrEmpty(value))
        {
            // This can be optimized when https://github.com/dotnet/runtime/issues/32606 is implemented
            value = Uri.EscapeDataString(value);
        }

        AppendQuery(name.AsSpan(), value.AsSpan(), false);
    }

    /// <summary>
    /// Appends a query parameter adding separator if required.
    /// </summary>
    /// <param name="name">The name of parameter.</param>
    /// <param name="value">The value of parameter.</param>
    /// <param name="escapeValue">Whether value should be escaped.</param>
    public virtual void AppendQuery(ReadOnlySpan<char> name, ReadOnlySpan<char> value, bool escapeValue)
    {
        ResetUri();
        if (!HasQuery)
        {
            _queryIndex = _pathAndQuery.Length;
            _pathAndQuery.Append(QuerySeparator);
        }
        else if (!(QueryLength == 1 && _pathAndQuery[_queryIndex] == QuerySeparator))
        {
            _pathAndQuery.Append('&');
        }
#if NETCOREAPP2_1_OR_GREATER
        _pathAndQuery.Append(name);
#else
        _pathAndQuery.Append(name.ToString());
#endif
        _pathAndQuery.Append('=');
        if (escapeValue && !value.IsEmpty)
        {
            _pathAndQuery.Append(Uri.EscapeDataString(value.ToString()));
        }
        else
        {
#if NETCOREAPP2_1_OR_GREATER
            _pathAndQuery.Append(value);
#else
            _pathAndQuery.Append(value.ToString());
#endif
        }

        Debug.Assert(_pathAndQuery[_queryIndex] == QuerySeparator);
    }

    /// <summary>
    /// Escapes and appends the <paramref name="value"/> to <see cref="Path"/> without adding path separator.
    /// Path segments and any other characters will be escaped, e.g. ":" will be escaped as "%3a".
    /// </summary>
    /// <param name="value">The value to escape and append.</param>
    public virtual void AppendPath(string value)
    {
        AppendPath(value, escape: true);
    }

    /// <summary>
    /// Optionally escapes and appends the <paramref name="value"/> to <see cref="Path"/> without adding path separator.
    /// If <paramref name="escape"/> is true, path segments and any other characters will be escaped, e.g. ":" will be escaped as "%3a".
    /// </summary>
    /// <param name="value">The value to optionally escape and append.</param>
    /// <param name="escape">Whether value should be escaped.</param>
    public virtual void AppendPath(string value, bool escape)
    {
        if (string.IsNullOrEmpty(value))
        {
            return;
        }

        AppendPath(value.AsSpan(), escape);
    }

    /// <summary>
    /// Optionally escapes and appends the <paramref name="value"/> to <see cref="Path"/> without adding path separator.
    /// If <paramref name="escape"/> is true, path segments and any other characters will be escaped, e.g. ":" will be escaped as "%3a".
    /// </summary>
    /// <param name="value">The value to optionally escape and append.</param>
    /// <param name="escape">Whether value should be escaped.</param>
    public virtual void AppendPath(ReadOnlySpan<char> value, bool escape)
    {
        if (value.IsEmpty)
        {
            return;
        }

        ResetUri();
        int startIndex = 0;
        if (PathLength == 1 && _pathAndQuery[0] == PathSeparator && value[0] == PathSeparator)
        {
            startIndex = 1;
        }

#if NETCOREAPP2_1_OR_GREATER
        var path = value.Slice(startIndex);
#else
        var stringPath = value.Slice(startIndex).ToString();
#endif

        if (escape)
        {
            // This can be optimized when https://github.com/dotnet/runtime/issues/32606 is implemented
#if NETCOREAPP2_1_OR_GREATER
            path = Uri.EscapeDataString(path.ToString()).AsSpan();
#else
            stringPath = Uri.EscapeDataString(stringPath);
#endif
        }

        if (HasQuery)
        {
#if NETCOREAPP2_1_OR_GREATER
            _pathAndQuery.Insert(_queryIndex, path);
            _queryIndex += path.Length;
#else
            _pathAndQuery.Insert(_queryIndex, stringPath);
            _queryIndex += stringPath.Length;
#endif
        }
        else
        {
#if NETCOREAPP2_1_OR_GREATER
            _pathAndQuery.Append(path);
#else
            _pathAndQuery.Append(stringPath);
#endif
        }
    }

    public void AppendPath(bool value, bool escape = false)
        => AppendPath(TypeFormatters.ConvertToString(value), escape);

    public void AppendPath(float value, bool escape = true)
        => AppendPath(TypeFormatters.ConvertToString(value), escape);

    public void AppendPath(double value, bool escape = true)
        => AppendPath(TypeFormatters.ConvertToString(value), escape);

    public void AppendPath(int value, bool escape = true)
        => AppendPath(TypeFormatters.ConvertToString(value), escape);

    public void AppendPath(byte[] value, string format, bool escape = true)
        => AppendPath(TypeFormatters.ConvertToString(value, format), escape);

    public void AppendPath(IEnumerable<string> value, bool escape = true)
        => AppendPath(TypeFormatters.ConvertToString(value), escape);

    public void AppendPath(DateTimeOffset value, string format, bool escape = true)
        => AppendPath(TypeFormatters.ConvertToString(value, format), escape);

    public void AppendPath(TimeSpan value, string format, bool escape = true)
        => AppendPath(TypeFormatters.ConvertToString(value, format), escape);

    public void AppendPath(Guid value, bool escape = true)
        => AppendPath(TypeFormatters.ConvertToString(value), escape);

    public void AppendPath(long value, bool escape = true)
        => AppendPath(TypeFormatters.ConvertToString(value), escape);

    public void AppendQuery(string name, bool value, bool escape = false)
        => AppendQuery(name, TypeFormatters.ConvertToString(value), escape);

    public void AppendQuery(string name, float value, bool escape = true)
        => AppendQuery(name, TypeFormatters.ConvertToString(value), escape);

    public void AppendQuery(string name, DateTimeOffset value, string format, bool escape = true)
        => AppendQuery(name, TypeFormatters.ConvertToString(value, format), escape);

    public void AppendQuery(string name, TimeSpan value, string format, bool escape = true)
        => AppendQuery(name, TypeFormatters.ConvertToString(value, format), escape);

    public void AppendQuery(string name, double value, bool escape = true)
        => AppendQuery(name, TypeFormatters.ConvertToString(value), escape);

    public void AppendQuery(string name, decimal value, bool escape = true)
        => AppendQuery(name, TypeFormatters.ConvertToString(value), escape);

    public void AppendQuery(string name, int value, bool escape = true)
        => AppendQuery(name, TypeFormatters.ConvertToString(value), escape);

    public void AppendQuery(string name, long value, bool escape = true)
        => AppendQuery(name, TypeFormatters.ConvertToString(value), escape);

    public void AppendQuery(string name, TimeSpan value, bool escape = true)
        => AppendQuery(name, TypeFormatters.ConvertToString(value), escape);

    public void AppendQuery(string name, byte[] value, string format, bool escape = true)
        => AppendQuery(name, TypeFormatters.ConvertToString(value, format), escape);

    public void AppendQuery(string name, Guid value, bool escape = true)
        => AppendQuery(name, TypeFormatters.ConvertToString(value), escape);

    public void AppendQueryDelimited<T>(string name, IEnumerable<T> value, string delimiter, bool escape = true)
    {
        // TODO: Linq is bad for performance
        var stringValues = value.Select(v => TypeFormatters.ConvertToString(v));
        AppendQuery(name, string.Join(delimiter, stringValues), escape);
    }

    public void AppendQueryDelimited<T>(string name, IEnumerable<T> value, string delimiter, string format, bool escape = true)
    {
        // TODO: Linq is bad for performance
        var stringValues = value.Select(v => TypeFormatters.ConvertToString(v, format));
        AppendQuery(name, string.Join(delimiter, stringValues), escape);
    }

    /// <summary>
    /// Returns a string representation of this <see cref="RequestUri"/>.
    /// </summary>
    /// <returns>A string representation of this <see cref="RequestUri"/>.</returns>
    public override string ToString()
    {
        var stringBuilder = new StringBuilder(
            (Scheme?.Length ?? 0) +
            3 + // ://
            (Host?.Length ?? 0) +
            _pathAndQuery.Length +
            10 // optimistic padding
            );
        stringBuilder.Append(Scheme);
        stringBuilder.Append("://");
        stringBuilder.Append(Host);
        if (!HasDefaultPortForScheme)
        {
            stringBuilder.Append(':');
            stringBuilder.Append(Port);
        }

        if (_pathAndQuery.Length == 0 || _pathAndQuery[0] != PathSeparator)
        {
            stringBuilder.Append(PathSeparator);
        }

        stringBuilder.Append(_pathAndQuery);

        return stringBuilder.ToString();
    }

    private bool HasDefaultPortForScheme =>
        (Port == 80 && string.Equals(Scheme, "http", StringComparison.InvariantCultureIgnoreCase)) ||
        (Port == 443 && string.Equals(Scheme, "https", StringComparison.InvariantCultureIgnoreCase));

    private void ResetUri()
    {
        _uri = null;
    }
    #endregion

    #region RawRequestUriBuilder

    private const string SchemeSeparator = "://";
    private const char HostSeparator = '/';
    private const char PortSeparator = ':';
    private static readonly char[] HostOrPort = { HostSeparator, PortSeparator };
    private const char QueryBeginSeparator = '?';
    private const char QueryContinueSeparator = '&';
    private const char QueryValueSeparator = '=';

    private RawWritingPosition? _position;

    private static void GetQueryParts(ReadOnlySpan<char> queryUnparsed, out ReadOnlySpan<char> name, out ReadOnlySpan<char> value)
    {
        int separatorIndex = queryUnparsed.IndexOf(QueryValueSeparator);
        if (separatorIndex == -1)
        {
            name = queryUnparsed;
            value = ReadOnlySpan<char>.Empty;
        }
        else
        {
            name = queryUnparsed.Slice(0, separatorIndex);
            value = queryUnparsed.Slice(separatorIndex + 1);
        }
    }

    public void AppendRawPathOrQueryOrHostOrScheme(string value, bool escape)
    {
        AppendRaw(value.AsSpan(), escape);
    }

    private void AppendRaw(ReadOnlySpan<char> value, bool escape)
    {
        if (_position == null)
        {
            if (HasQuery)
            {
                _position = RawWritingPosition.Query;
            }
            else if (HasPath)
            {
                _position = RawWritingPosition.Path;
            }
            else if (!string.IsNullOrEmpty(Host))
            {
                _position = RawWritingPosition.Host;
            }
            else
            {
                _position = RawWritingPosition.Scheme;
            }
        }

        while (!value.IsEmpty)
        {
            if (_position == RawWritingPosition.Scheme)
            {
                int separator = value.IndexOf(SchemeSeparator.AsSpan(), StringComparison.InvariantCultureIgnoreCase);
                if (separator == -1)
                {
                    Scheme += value.ToString();
                    value = ReadOnlySpan<char>.Empty;
                }
                else
                {
                    Scheme += value.Slice(0, separator).ToString();
                    // TODO: Find a better way to map schemes to default ports
                    Port = string.Equals(Scheme, "https", StringComparison.OrdinalIgnoreCase) ? 443 : 80;
                    value = value.Slice(separator + SchemeSeparator.Length);
                    _position = RawWritingPosition.Host;
                }
            }
            else if (_position == RawWritingPosition.Host)
            {
                int separator = value.IndexOfAny(HostOrPort);
                if (separator == -1)
                {
                    if (!HasPath)
                    {
                        Host += value.ToString();
                        value = ReadOnlySpan<char>.Empty;
                    }
                    else
                    {
                        // All Host information must be written before Path information
                        // If Path already has information, we transition to writing Path
                        _position = RawWritingPosition.Path;
                    }
                }
                else
                {
                    Host += value.Slice(0, separator).ToString();
                    _position = value[separator] == HostSeparator ? RawWritingPosition.Path : RawWritingPosition.Port;
                    value = value.Slice(separator + 1);
                }
            }
            else if (_position == RawWritingPosition.Port)
            {
                int separator = value.IndexOf(HostSeparator);
                if (separator == -1)
                {
#if NETCOREAPP2_1_OR_GREATER
                    Port = int.Parse(value, NumberStyles.Integer, CultureInfo.InvariantCulture);
#else
                    Port = int.Parse(value.ToString(), CultureInfo.InvariantCulture);
#endif
                    value = ReadOnlySpan<char>.Empty;
                }
                else
                {
#if NETCOREAPP2_1_OR_GREATER
                    Port = int.Parse(value.Slice(0, separator), NumberStyles.Integer, CultureInfo.InvariantCulture);
#else
                    Port = int.Parse(value.Slice(0, separator).ToString(), CultureInfo.InvariantCulture);
#endif
                    value = value.Slice(separator + 1);
                }
                // Port cannot be split (like Host), so always transition to Path when Port is parsed
                _position = RawWritingPosition.Path;
            }
            else if (_position == RawWritingPosition.Path)
            {
                int separator = value.IndexOf(QueryBeginSeparator);
                if (separator == -1)
                {
                    AppendPath(value, escape);
                    value = ReadOnlySpan<char>.Empty;
                }
                else
                {
                    AppendPath(value.Slice(0, separator), escape);
                    value = value.Slice(separator + 1);
                    _position = RawWritingPosition.Query;
                }
            }
            else if (_position == RawWritingPosition.Query)
            {
                int separator = value.IndexOf(QueryContinueSeparator);
                if (separator == 0)
                {
                    value = value.Slice(1);
                }
                else if (separator == -1)
                {
                    GetQueryParts(value, out var queryName, out var queryValue);
                    AppendQuery(queryName, queryValue, escape);
                    value = ReadOnlySpan<char>.Empty;
                }
                else
                {
                    GetQueryParts(value.Slice(0, separator), out var queryName, out var queryValue);
                    AppendQuery(queryName, queryValue, escape);
                    value = value.Slice(separator + 1);
                }
            }
        }
    }

    private enum RawWritingPosition
    {
        Scheme,
        Host,
        Port,
        Path,
        Query
    }
    #endregion
}
