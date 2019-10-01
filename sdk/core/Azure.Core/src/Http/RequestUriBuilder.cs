// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;

namespace Azure.Core.Http
{
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

        public string? Scheme
        {
            get => _scheme;
            set
            {
                ResetUri();
                _scheme = value;
            }
        }

        public string? Host
        {
            get => _host;
            set
            {
                ResetUri();
                _host = value;
            }
        }

        public int Port
        {
            get => _port;
            set
            {
                ResetUri();
                _port = value;
            }
        }

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

        public string PathAndQuery => _pathAndQuery.ToString();

        public void Assign(Uri value)
        {
            Scheme = value.Scheme;
            Host = value.Host;
            Port = value.Port;
            Path = value.AbsolutePath;
            Query = value.Query;
            _uri = value;
        }

        public Uri ToUri()
        {
            if (_uri == null)
            {
                _uri = new Uri(ToString());
            }

            return _uri;
        }

        public void AppendQuery(string name, string value)
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
            _pathAndQuery.Append(value);
        }

        public void AppendPath(string value)
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
                _pathAndQuery.Insert(_queryIndex - 1, value.Substring(startIndex, value.Length - startIndex));
                _queryIndex += value.Length;
            }
            else
            {
                _pathAndQuery.Append(value, startIndex, value.Length - startIndex);
            }
        }

        public override string ToString()
        {
            return ToString(null);
        }

        internal string ToString(string[]? allowedQueryParameters)
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
                stringBuilder.Append(Uri.EscapeUriString(_pathAndQuery.ToString()));
            }
            else
            {
                stringBuilder.Append(Uri.EscapeUriString(_pathAndQuery.ToString(0, _queryIndex)));
                if (allowedQueryParameters == null)
                {
                    stringBuilder.Append(_pathAndQuery.ToString(_queryIndex, _pathAndQuery.Length - _queryIndex));
                }
                else
                {
                    AppendSanitizedQuery(stringBuilder, allowedQueryParameters);
                }
            }

            return stringBuilder.ToString();
        }

        private void AppendSanitizedQuery(StringBuilder stringBuilder, string[] allowedQueryParameters)
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
                        stringBuilder.Append("=*");
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
