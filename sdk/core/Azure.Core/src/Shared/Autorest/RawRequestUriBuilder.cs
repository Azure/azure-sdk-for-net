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
        private static readonly char[] HostOrPort = new[] {HostSeparator, PortSeparator};

        private RawWritingPosition _position = RawWritingPosition.Scheme;

        public void AppendRaw(string value, bool escape)
        {
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
                        Host += value;
                        value = string.Empty;
                    }
                    else
                    {
                        Host += value.Substring(0, separator);

                        _position = value[separator] == HostSeparator ? RawWritingPosition.Rest : RawWritingPosition.Port;

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
                        _position = RawWritingPosition.Rest;
                    }
                }
                else
                {
                    AppendPath(value, escape);
                    value = string.Empty;
                }
            }
        }

        private enum RawWritingPosition
        {
            Scheme,
            Host,
            Port,
            Rest
        }
    }
}
