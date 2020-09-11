// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Globalization;

namespace Azure.Core
{
    internal class RawRequestUriBuilder: RequestUriBuilder
    {
        private const string SchemeSeparator = "://";
        private const char HostSeparator = '/';
        private const char PortSeparator = ':';
        private static readonly char[] HostOrPort = { HostSeparator, PortSeparator };
        private const char QueryBeginSeparator = '?';
        private const char QueryContinueSeparator = '&';
        private const char QueryValueSeparator = '=';

        private RawWritingPosition? _position;

        private static (string Name, string Value) GetQueryParts(string queryUnparsed)
        {
            int separatorIndex = queryUnparsed.IndexOf(QueryValueSeparator);
            if (separatorIndex == -1)
            {
                return (queryUnparsed, string.Empty);
            }
            return (queryUnparsed.Substring(0, separatorIndex), queryUnparsed.Substring(separatorIndex + 1));
        }

        public void AppendRaw(string value, bool escape)
        {
            if (_position == null)
            {
                if (!string.IsNullOrEmpty(Query))
                {
                    _position = RawWritingPosition.Query;
                }
                else if (!string.IsNullOrEmpty(Path))
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
            while (!string.IsNullOrWhiteSpace(value))
            {
                if (_position == RawWritingPosition.Scheme)
                {
                    int separator = value.IndexOf(SchemeSeparator, StringComparison.InvariantCultureIgnoreCase);
                    if (separator == -1)
                    {
                        Scheme += value;
                        value = string.Empty;
                    }
                    else
                    {
                        Scheme += value.Substring(0, separator);
                        // TODO: Find a better way to map schemes to default ports
                        Port = string.Equals(Scheme, "https", StringComparison.OrdinalIgnoreCase) ? 443 : 80;
                        value = value.Substring(separator + SchemeSeparator.Length);
                        _position = RawWritingPosition.Host;
                    }
                }
                else if (_position == RawWritingPosition.Host)
                {
                    int separator = value.IndexOfAny(HostOrPort);
                    if (separator == -1)
                    {
                        if (string.IsNullOrEmpty(Path))
                        {
                            Host += value;
                            value = string.Empty;
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
                        Host += value.Substring(0, separator);
                        _position = value[separator] == HostSeparator ? RawWritingPosition.Path : RawWritingPosition.Port;
                        value = value.Substring(separator + 1);
                    }
                }
                else if (_position == RawWritingPosition.Port)
                {
                    int separator = value.IndexOf(HostSeparator);
                    if (separator == -1)
                    {
                        Port = int.Parse(value, CultureInfo.InvariantCulture);
                        value = string.Empty;
                    }
                    else
                    {
                        Port = int.Parse(value.Substring(0, separator), CultureInfo.InvariantCulture);
                        value = value.Substring(separator + 1);
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
                        value = string.Empty;
                    }
                    else
                    {
                        AppendPath(value.Substring(0, separator), escape);
                        value = value.Substring(separator + 1);
                        _position = RawWritingPosition.Query;
                    }
                }
                else if (_position == RawWritingPosition.Query)
                {
                    int separator = value.IndexOf(QueryContinueSeparator);
                    if (separator == 0)
                    {
                        value = value.Substring(1);
                    }
                    else if (separator == -1)
                    {
                        (string queryName, string queryValue) = GetQueryParts(value);
                        AppendQuery(queryName, queryValue, escape);
                        value = string.Empty;
                    }
                    else
                    {
                        (string queryName, string queryValue) = GetQueryParts(value.Substring(0, separator));
                        AppendQuery(queryName, queryValue, escape);
                        value = value.Substring(separator + 1);
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

        public void AppendRawNextLink(string nextLink, bool escape)
        {
            // If it is an absolute link, we use the nextLink as the entire url
            if (nextLink.StartsWith(Uri.UriSchemeHttp, StringComparison.InvariantCultureIgnoreCase))
            {
                Reset(new Uri(nextLink));
                return;
            }

            AppendRaw(nextLink, escape);
        }
    }
}
