// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.ClientModel.Internal;

/// <summary>
/// TODO.
/// </summary>
internal class PipelineMessageSanitizer
{
    private const string LogAllValue = "*";
    private readonly bool _logAllHeaders;
    private readonly bool _logFullQueries;
    private readonly string _redactedPlaceholder;
    private readonly HashSet<string> _loggedHeaderNames;
    private readonly string[] _loggedQueryParameters;

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="allowedQueryParameters"></param>
    /// <param name="allowedHeaders"></param>
    /// <param name="redactedPlaceholder"></param>
    public PipelineMessageSanitizer(string[] allowedQueryParameters, string[] allowedHeaders, string redactedPlaceholder = "REDACTED")
    {
        _logAllHeaders = allowedHeaders.Contains(LogAllValue);
        _logFullQueries = allowedQueryParameters.Contains(LogAllValue);

        _loggedQueryParameters = allowedQueryParameters;
        _redactedPlaceholder = redactedPlaceholder;
        _loggedHeaderNames = new HashSet<string>(allowedHeaders, StringComparer.InvariantCultureIgnoreCase);
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string SanitizeHeader(string name, string value)
    {
        if (_logAllHeaders || _loggedHeaderNames.Contains(name))
        {
            return value;
        }

        return _redactedPlaceholder;
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public string SanitizeUrl(string url)
    {
        if (_logFullQueries)
        {
            return url;
        }

#if NET5_0_OR_GREATER
        int indexOfQuerySeparator = url.IndexOf('?', StringComparison.Ordinal);
#else
        int indexOfQuerySeparator = url.IndexOf('?');
#endif

        if (indexOfQuerySeparator == -1)
        {
            return url;
        }

        StringBuilder stringBuilder = new StringBuilder(url.Length);
        stringBuilder.Append(url, 0, indexOfQuerySeparator);

        string query = url.Substring(indexOfQuerySeparator);

        int queryIndex = 1;
        stringBuilder.Append('?');

        do
        {
            int endOfParameterValue = query.IndexOf('&', queryIndex);
            int endOfParameterName = query.IndexOf('=', queryIndex);
            bool noValue = false;

            // Check if we have parameter without value
            if (endOfParameterValue == -1 && endOfParameterName == -1 ||
                endOfParameterValue != -1 && (endOfParameterName == -1 || endOfParameterName > endOfParameterValue))
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
            foreach (string name in _loggedQueryParameters)
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
                    stringBuilder.Append('=');
                    stringBuilder.Append(_redactedPlaceholder);
                    if (query[endOfParameterValue - 1] == '&')
                    {
                        stringBuilder.Append('&');
                    }
                }
            }

            queryIndex += valueLength;
        } while (queryIndex < query.Length);

        return stringBuilder.ToString();
    }
}
