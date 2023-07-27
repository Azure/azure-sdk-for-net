// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Azure.Core
{
    /// <summary>
    /// Provides a custom builder for Uniform Resource Identifiers (URIs) and modifies URIs for the <see cref="System.Uri" /> class.
    /// </summary>
    public class RequestUriBuilder
    {
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
        public string? Scheme
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
        public string? Host
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
        public int Port
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
        public string Query
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
        public string Path
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

        /// <summary> Gets whether or not this instance of <see cref="RequestUriBuilder"/> has a path. </summary>
        protected bool HasPath => PathLength > 0;

        /// <summary> Gets whether or not this instance of <see cref="RequestUriBuilder"/> has a query. </summary>
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
        public void Reset(Uri value)
        {
            Scheme = value.Scheme;
            Host = value.Host;
            Port = value.Port;
            Path = value.AbsolutePath;
            Query = value.Query;
            _uri = value;
        }

        /// <summary>
        /// Gets the <see cref="System.Uri"/> instance constructed by the specified <see cref="RequestUriBuilder"/> instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.Uri"/> that contains the URI constructed by the <see cref="RequestUriBuilder"/>.
        /// </returns>
        public Uri ToUri()
        {
            if (_uri == null)
            {
                _uri = new Uri(ToString());
            }

            return _uri;
        }

        /// <summary>
        /// Appends a query parameter adding separator if required. Escapes the value.
        /// </summary>
        /// <param name="name">The name of parameter.</param>
        /// <param name="value">The value of parameter.</param>
        public void AppendQuery(string name, string value)
        {
            AppendQuery(name, value, true);
        }

        /// <summary>
        /// Appends a query parameter adding separator if required.
        /// </summary>
        /// <param name="name">The name of parameter.</param>
        /// <param name="value">The value of parameter.</param>
        /// <param name="escapeValue">Whether value should be escaped.</param>
        public void AppendQuery(string name, string value, bool escapeValue)
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
        public void AppendQuery(ReadOnlySpan<char> name, ReadOnlySpan<char> value, bool escapeValue)
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
        public void AppendPath(string value)
        {
            AppendPath(value, escape: true);
        }

        /// <summary>
        /// Optionally escapes and appends the <paramref name="value"/> to <see cref="Path"/> without adding path separator.
        /// If <paramref name="escape"/> is true, path segments and any other characters will be escaped, e.g. ":" will be escaped as "%3a".
        /// </summary>
        /// <param name="value">The value to optionally escape and append.</param>
        /// <param name="escape">Whether value should be escaped.</param>
        public void AppendPath(string value, bool escape)
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
        public void AppendPath(ReadOnlySpan<char> value, bool escape)
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

        /// <summary>
        /// Returns a string representation of this <see cref="RequestUriBuilder"/>.
        /// </summary>
        /// <returns>A string representation of this <see cref="RequestUriBuilder"/>.</returns>
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
    }
}
