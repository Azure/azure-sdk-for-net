// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Azure.Core
{
    internal class HttpMessageSanitizer
    {
        private readonly bool _logAllHeaders;
        private readonly bool _logFullQueries;
        private readonly string[] _allowedQueryParameters;
        private readonly string _redactedPlaceholder;
        private readonly HashSet<string> _allowedHeaders;
        private const string LogAllValue = "*";

        public HttpMessageSanitizer(string[] allowedQueryParameters, string[] allowedHeaders, string redactedPlaceholder = "REDACTED")
        {
            _logAllHeaders = allowedHeaders.Contains(LogAllValue);
            _logFullQueries = allowedQueryParameters.Contains(LogAllValue);

            _allowedQueryParameters = allowedQueryParameters;
            _redactedPlaceholder = redactedPlaceholder;
            _allowedHeaders = new HashSet<string>(allowedHeaders, StringComparer.InvariantCultureIgnoreCase);
        }

        public string SanitizeHeader(string name, string value)
        {
            if (_logAllHeaders || _allowedHeaders.Contains(name))
            {
                return value;
            }

            return _redactedPlaceholder;
        }

        public string SanitizeUrl(string uri)
        {
            if (_logFullQueries)
            {
                return uri;
            }

            var indexOfQuerySeparator = uri.IndexOf('?');
            if (indexOfQuerySeparator == -1)
            {
                return uri;
            }

            StringBuilder stringBuilder = new StringBuilder(uri.Length);
            stringBuilder.Append(uri, 0, indexOfQuerySeparator);

            string query = uri.Substring(indexOfQuerySeparator + 1);

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
                foreach (string name in _allowedQueryParameters)
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
                        stringBuilder.Append(_redactedPlaceholder);
                        if (query[endOfParameterValue - 1] == '&')
                        {
                            stringBuilder.Append("&");
                        }
                    }
                }

                queryIndex += valueLength;

            } while (queryIndex < query.Length);

            return stringBuilder.ToString();
        }
    }
}