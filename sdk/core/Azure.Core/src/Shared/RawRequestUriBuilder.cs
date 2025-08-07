// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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

        public void AppendRaw(string value, bool escape)
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

        public void AppendQuery(string name, bool value, bool escape = true) => AppendQuery(name, TypeFormatters.ConvertToString(value), escape);

        public void AppendQuery(string name, float value, bool escape = true) => AppendQuery(name, TypeFormatters.ConvertToString(value), escape);

        public void AppendQuery(string name, DateTimeOffset value, string format, bool escape = true) => AppendQuery(name, TypeFormatters.ConvertToString(value, format), escape);

        public void AppendQuery(string name, TimeSpan value, string format, bool escape = true) => AppendQuery(name, TypeFormatters.ConvertToString(value, format), escape);

        public void AppendQuery(string name, double value, bool escape = true) => AppendQuery(name, TypeFormatters.ConvertToString(value), escape);

        public void AppendQuery(string name, decimal value, bool escape = true) => AppendQuery(name, TypeFormatters.ConvertToString(value), escape);

        public void AppendQuery(string name, int value, bool escape = true) => AppendQuery(name, TypeFormatters.ConvertToString(value), escape);

        public void AppendQuery(string name, long value, bool escape = true) => AppendQuery(name, TypeFormatters.ConvertToString(value), escape);

        public void AppendQuery(string name, TimeSpan value, bool escape = true) => AppendQuery(name, TypeFormatters.ConvertToString(value), escape);

        public void AppendQuery(string name, byte[] value, string format, bool escape = true) => AppendQuery(name, TypeFormatters.ConvertToString(value, format), escape);

        public void AppendQuery(string name, Guid value, bool escape = true) => AppendQuery(name, TypeFormatters.ConvertToString(value), escape);

        public void AppendQueryDelimited<T>(string name, IEnumerable<T> value, string delimiter, string? format = null, bool escape = true)
        {
            delimiter ??= ",";
            IEnumerable<string> stringValues = value.Select(v => TypeFormatters.ConvertToString(v, format));
            AppendQuery(name, string.Join(delimiter, stringValues), escape);
        }

        public void AppendPathDelimited<T>(IEnumerable<T> value, string delimiter, string? format = null, bool escape = true)
        {
            delimiter ??= ",";
            IEnumerable<string> stringValues = value.Select(v => TypeFormatters.ConvertToString(v, format));
            AppendPath(string.Join(delimiter, stringValues), escape);
        }
    }
}
