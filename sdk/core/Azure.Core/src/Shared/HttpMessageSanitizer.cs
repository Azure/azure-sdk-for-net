// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#nullable enable

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Azure.Core;

internal class HttpMessageSanitizer
{
    private const string LogAllValue = "*";
    private readonly bool _logAllHeaders;
    private readonly bool _logFullQueries;
    private readonly string[] _allowedQueryParameters;
    private readonly string _redactedPlaceholder;
    private readonly HashSet<string> _allowedHeaders;

    [ThreadStatic]
    private static StringBuilder? s_cachedStringBuilder;
    private const int MaxCachedStringBuilderCapacity = 1024;

    internal static HttpMessageSanitizer Default = new HttpMessageSanitizer(Array.Empty<string>(), Array.Empty<string>());

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

        // PERF: Avoid allocations in this heavily-used method:
        // 1. Use ReadOnlySpan<char> to avoid creating substrings.
        // 2. Defer creating a StringBuilder until absolutely necessary.
        // 3. Use a rented StringBuilder to avoid allocating a new one
        //    each time.

        // Create the StringBuilder only when necessary (when we encounter
        // a query parameter that needs to be redacted)
        StringBuilder? stringBuilder = null;

        // Keeps track of the number of characters we've processed so far
        // so that, if we need to create a StringBuilder, we know how many
        // characters to copy over from the original URL.
        int lengthSoFar = indexOfQuerySeparator + 1;

        ReadOnlySpan<char> query = url.AsSpan(indexOfQuerySeparator + 1); // +1 to skip the '?'

        while (query.Length > 0)
        {
            int endOfParameterValue = query.IndexOf('&');
            int endOfParameterName = query.IndexOf('=');
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

            ReadOnlySpan<char> parameterName = query.Slice(0, endOfParameterName);

            bool isAllowed = false;
            foreach (string name in _allowedQueryParameters)
            {
                if (parameterName.Equals(name.AsSpan(), StringComparison.OrdinalIgnoreCase))
                {
                    isAllowed = true;
                    break;
                }
            }

            int valueLength = endOfParameterValue;
            int nameLength = endOfParameterName;

            if (isAllowed || noValue)
            {
                if (stringBuilder is null)
                {
                    lengthSoFar += valueLength;
                }
                else
                {
                    AppendReadOnlySpan(stringBuilder, query.Slice(0, valueLength));
                }
            }
            else
            {
                // Encountered a query value that needs to be redacted.
                // Create the StringBuilder if we haven't already.
                stringBuilder ??= RentStringBuilder(url.Length).Append(url, 0, lengthSoFar);

                AppendReadOnlySpan(stringBuilder, query.Slice(0, nameLength))
                    .Append('=')
                    .Append(_redactedPlaceholder);

                if (query[endOfParameterValue - 1] == '&')
                {
                    stringBuilder.Append('&');
                }
            }

            query = query.Slice(valueLength);
        }

        return stringBuilder is null ? url : ToStringAndReturnStringBuilder(stringBuilder);

        static StringBuilder AppendReadOnlySpan(StringBuilder builder, ReadOnlySpan<char> span)
        {
#if NET6_0_OR_GREATER
            return builder.Append(span);
#else
            foreach (char c in span)
            {
                builder.Append(c);
            }

            return builder;
#endif
        }
    }

    private static StringBuilder RentStringBuilder(int capacity)
    {
        if (capacity <= MaxCachedStringBuilderCapacity)
        {
            StringBuilder? builder = s_cachedStringBuilder;
            if (builder is not null && builder.Capacity >= capacity)
            {
                s_cachedStringBuilder = null;
                return builder;
            }
        }

        return new StringBuilder(capacity);
    }

    private static string ToStringAndReturnStringBuilder(StringBuilder builder)
    {
        string result = builder.ToString();
        if (builder.Capacity <= MaxCachedStringBuilderCapacity)
        {
            s_cachedStringBuilder = builder.Clear();
        }

        return result;
    }
}
