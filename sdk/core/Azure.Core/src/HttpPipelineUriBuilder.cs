// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;

namespace Azure.Core
{
    public class HttpPipelineUriBuilder
    {
        private const char QuerySeparator = '?';

        private const char PathSeparator = '/';

        private readonly StringBuilder _pathAndQuery = new StringBuilder();

        private int _queryIndex = -1;

        private Uri _uri;

        private int _port;

        private string _host;

        private string _scheme;

        public string Scheme
        {
            get => _scheme;
            set
            {
                ResetUri();
                _scheme = value;
            }
        }

        public string Host
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

        public Uri Uri
        {
            get
            {
                if (_uri == null)
                {
                    _uri = new Uri(ToString());
                }
                return _uri;
            }
            set
            {
                Scheme = value.Scheme;
                Host = value.Host;
                Port = value.Port;
                Path = value.AbsolutePath;
                Query = value.Query;
                _uri = value;
            }
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
                _pathAndQuery.Insert(_queryIndex, value.Substring(startIndex, value.Length - startIndex));
                _queryIndex += value.Length;
            }
            else
            {
                _pathAndQuery.Append(value, startIndex, value.Length - startIndex);
            }
        }

        public override string ToString()
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
                stringBuilder.Append(_pathAndQuery.ToString(_queryIndex, _pathAndQuery.Length - _queryIndex));
            }

            return stringBuilder.ToString();
        }

        private bool HasDefaultPortForScheme =>
            (Port == 80 && Scheme.Equals("http", StringComparison.InvariantCultureIgnoreCase)) ||
            (Port == 443 && Scheme.Equals("https", StringComparison.InvariantCultureIgnoreCase));

        private void ResetUri()
        {
            _uri = null;
        }
    }
}
