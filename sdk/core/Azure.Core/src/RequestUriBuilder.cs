// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;

namespace Azure.Core
{
    /// <summary>
    /// Provides a custom constructor for uniform resource identifiers (URIs) and modifies URIs for the <see cref="System.Uri" /> class.
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
        /// Gets or sets the password associated with the user that accesses the URI and the query information.
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

        private bool HasQuery => _queryIndex != -1;

        private int QueryLength => HasQuery ? _pathAndQuery.Length - _queryIndex : 0;

        private int PathLength => HasQuery ? _queryIndex : _pathAndQuery.Length;

        /// <summary>
        /// Gets the path to the resource referenced by the URI.
        /// </summary>
        public string PathAndQuery => _pathAndQuery.ToString();

        /// <summary>
        /// Replaces values inside this instance with values provided in <paramref name="value"/> parameter.
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
        /// Gets the <see cref="System.Uri"></see> instance constructed by the specified <see cref="RequestUriBuilder"/> instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.Uri"></see> that contains the URI constructed by the <see cref="RequestUriBuilder"/>.
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
            ResetUri();
            if (!HasQuery)
            {
                _pathAndQuery.Append(QuerySeparator);
                _queryIndex = _pathAndQuery.Length;
            }
            else if (!(QueryLength == 1 && _pathAndQuery[_queryIndex] == QuerySeparator))
            {
                _pathAndQuery.Append('&');
            }

            _pathAndQuery.Append(name);
            _pathAndQuery.Append('=');
            if (escapeValue && !string.IsNullOrEmpty(value))
            {
                value = Uri.EscapeDataString(value);
            }
            _pathAndQuery.Append(value);
        }

        /// <summary>
        /// Appends escaped <paramref name="value"/> to <see cref="Path"/> without adding path separator.
        /// </summary>
        /// <param name="value">The value to append.</param>
        public void AppendPath(string value)
        {
            AppendPath(value, escape: true);
        }

        /// <summary>
        /// Appends optionally escaped <paramref name="value"/> to <see cref="Path"/> without adding path separator.
        /// </summary>
        /// <param name="value">The value to append.</param>
        /// <param name="escape">Whether value should be escaped.</param>
        public void AppendPath(string value, bool escape)
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            ResetUri();
            int startIndex = 0;
            if (PathLength == 1 && _pathAndQuery[0] == PathSeparator && value[0] == PathSeparator)
            {
                startIndex = 1;
            }
            if (HasQuery)
            {
                string substring = value.Substring(startIndex, value.Length - startIndex);
                if (escape)
                {
                    substring = Uri.EscapeDataString(substring);
                }
                _pathAndQuery.Insert(_queryIndex - 1, substring);
                _queryIndex += value.Length;
            }
            else
            {
                if (escape)
                {
                    string substring = value.Substring(startIndex, value.Length - startIndex);
                    substring = Uri.EscapeDataString(substring);
                    _pathAndQuery.Append(substring);
                }
                else
                {
                    _pathAndQuery.Append(value, startIndex, value.Length - startIndex);
                }
            }
        }

        /// <summary>
        /// Returns a string representation of this <see cref="RequestUriBuilder"/> i.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ToString(null, string.Empty);
        }

        internal string ToString(string[]? allowedQueryParameters, string redactedValue)
        {
            var stringBuilder = new StringBuilder();
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

            // TODO: Escaping can be done in-place
            if (!HasQuery)
            {
                stringBuilder.Append(_pathAndQuery);
            }
            else
            {
                stringBuilder.Append(_pathAndQuery.ToString(0, _queryIndex));
                if (allowedQueryParameters == null)
                {
                    stringBuilder.Append(_pathAndQuery.ToString(_queryIndex, _pathAndQuery.Length - _queryIndex));
                }
                else
                {
                    AppendRedactedQuery(stringBuilder, allowedQueryParameters, redactedValue);
                }
            }

            return stringBuilder.ToString();
        }

        private void AppendRedactedQuery(StringBuilder stringBuilder, string[] allowedQueryParameters, string redactedValue)
        {
            string query = _pathAndQuery.ToString(_queryIndex, _pathAndQuery.Length - _queryIndex);
            int queryIndex = 1;
            stringBuilder.Append('?');

            do
            {
                int endOfParameterValue = query.IndexOf('&', queryIndex);
                int endOfParameterName = query.IndexOf('=', queryIndex);
                bool noValue = false;

                // Check if we have parameter without value
                if ((endOfParameterValue == -1 && endOfParameterName == -1) ||
                    (endOfParameterValue != -1 && (endOfParameterName == -1 || endOfParameterName > endOfParameterValue)))
                {
                    endOfParameterName = endOfParameterValue;
                    noValue = true;
                }

                if (endOfParameterName == -1)
                {
                    endOfParameterName = query.Length;
                }

                if (endOfParameterValue == -1)
                {
                    endOfParameterValue = query.Length;
                }
                else
                {
                    // include the separator
                    endOfParameterValue++;
                }

                ReadOnlySpan<char> parameterName = query.AsSpan(queryIndex, endOfParameterName - queryIndex);

                bool isAllowed = false;
                foreach (string name in allowedQueryParameters)
                {
                    if (parameterName.Equals(name.AsSpan(), StringComparison.OrdinalIgnoreCase))
                    {
                        isAllowed = true;
                        break;
                    }
                }

                int valueLength = endOfParameterValue - queryIndex;
                int nameLength = endOfParameterName - queryIndex;

                if (isAllowed)
                {
                    stringBuilder.Append(query, queryIndex, valueLength);
                }
                else
                {
                    if (noValue)
                    {
                        stringBuilder.Append(query, queryIndex, valueLength);
                    }
                    else
                    {
                        stringBuilder.Append(query, queryIndex, nameLength);
                        stringBuilder.Append("=");
                        stringBuilder.Append(redactedValue);
                        if (query[endOfParameterValue - 1] == '&')
                        {
                            stringBuilder.Append("&");
                        }
                    }
                }

                queryIndex += valueLength;

            } while (queryIndex < query.Length);

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
