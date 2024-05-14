// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;

#nullable enable

namespace Azure.Core
{
    /// <summary>
    /// A helper class for parsing Authorization challenge headers.
    /// </summary>
    internal static class AuthorizationChallengeParser
    {
        /// <summary>
        /// Parses the specified parameter from a challenge hearder found in the specified <see cref="Response"/>.
        /// </summary>
        /// <param name="response">The <see cref="Response"/> to parse.</param>
        /// <param name="challengeScheme">The challenge scheme containing the <paramref name="challengeParameter"/>. For example: "Bearer"</param>
        /// <param name="challengeParameter">The parameter key name containing the value to return.</param>
        /// <returns>The value of the parameter name specified in <paramref name="challengeParameter"/> if it is found in the specified <paramref name="challengeScheme"/>.</returns>
        public static string? GetChallengeParameterFromResponse(Response response, string challengeScheme, string challengeParameter)
        {
            if (response.Status != (int)HttpStatusCode.Unauthorized || !response.Headers.TryGetValue(HttpHeader.Names.WwwAuthenticate, out string? headerValue))
            {
                return null;
            }

            ReadOnlySpan<char> scheme = challengeScheme.AsSpan();
            ReadOnlySpan<char> parameter = challengeParameter.AsSpan();
            ReadOnlySpan<char> headerSpan = headerValue.AsSpan();

            // Iterate through each challenge value.
            while (TryGetNextChallenge(ref headerSpan, out var challengeKey))
            {
                // Enumerate each key-value parameter until we find the parameter key on the specified scheme challenge.
                while (TryGetNextParameter(ref headerSpan, out var key, out var value))
                {
                    if (challengeKey.Equals(scheme, StringComparison.OrdinalIgnoreCase) && key.Equals(parameter, StringComparison.OrdinalIgnoreCase))
                    {
                        return value.ToString();
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Iterates through the challenge schemes present in a challenge header.
        /// </summary>
        /// <param name="headerValue">
        /// The header value which will be sliced to remove the first parsed <paramref name="challengeKey"/>.
        /// </param>
        /// <param name="challengeKey">The parsed challenge scheme.</param>
        /// <returns>
        /// <c>true</c> if a challenge scheme was successfully parsed.
        /// The value of <paramref name="headerValue"/> should be passed to <see cref="TryGetNextParameter"/> to parse the challenge parameters if <c>true</c>.
        /// </returns>
        internal static bool TryGetNextChallenge(ref ReadOnlySpan<char> headerValue, out ReadOnlySpan<char> challengeKey)
        {
            challengeKey = default;

            headerValue = headerValue.TrimStart(' ');
            int endOfChallengeKey = headerValue.IndexOf(' ');

            if (endOfChallengeKey < 0)
            {
                return false;
            }

            challengeKey = headerValue.Slice(0, endOfChallengeKey);

            // Slice the challenge key from the headerValue
            headerValue = headerValue.Slice(endOfChallengeKey + 1);

            return true;
        }

        /// <summary>
        /// Iterates through a challenge header value after being parsed by <see cref="TryGetNextChallenge"/>.
        /// </summary>
        /// <param name="headerValue">The header value after being parsed by <see cref="TryGetNextChallenge"/>.</param>
        /// <param name="paramKey">The parsed challenge parameter key.</param>
        /// <param name="paramValue">The parsed challenge parameter value.</param>
        /// <param name="separator">The challenge parameter key / value pair separator. The default is '='.</param>
        /// <returns>
        /// <c>true</c> if the next available challenge parameter was successfully parsed.
        /// <c>false</c> if there are no more parameters for the current challenge scheme or an additional challenge scheme was encountered in the <paramref name="headerValue"/>.
        /// The value of <paramref name="headerValue"/> should be passed again to <see cref="TryGetNextChallenge"/> to attempt to parse any additional challenge schemes if <c>false</c>.
        /// </returns>
        internal static bool TryGetNextParameter(ref ReadOnlySpan<char> headerValue, out ReadOnlySpan<char> paramKey, out ReadOnlySpan<char> paramValue, char separator = '=')
        {
            paramKey = default;
            paramValue = default;
            var spaceOrComma = " ,".AsSpan();

            // Trim any separater prefixes.
            headerValue = headerValue.TrimStart(spaceOrComma);

            int nextSpace = headerValue.IndexOf(' ');
            int nextSeparator = headerValue.IndexOf(separator);

            if (nextSpace < nextSeparator && nextSpace != -1)
            {
                // we encountered another challenge value.
                return false;
            }

            if (nextSeparator < 0)
                return false;

            // Get the paramKey.
            paramKey = headerValue.Slice(0, nextSeparator).Trim();

            // Slice to remove the 'paramKey=' from the parameters.
            headerValue = headerValue.Slice(nextSeparator + 1);

            // The start of paramValue will usually be a quoted string. Find the first quote.
            int quoteIndex = headerValue.IndexOf('\"');

            // Get the paramValue, which is delimited by the trailing quote.
            headerValue = headerValue.Slice(quoteIndex + 1);
            if (quoteIndex >= 0)
            {
                // The values are quote wrapped
                paramValue = headerValue.Slice(0, headerValue.IndexOf('\"'));
            }
            else
            {
                //the values are not quote wrapped (storage is one example of this)
                // either find the next space indicating the delimiter to the next value, or go to the end since this is the last value.
                int trailingDelimiterIndex = headerValue.IndexOfAny(spaceOrComma);
                if (trailingDelimiterIndex >= 0)
                {
                    paramValue = headerValue.Slice(0, trailingDelimiterIndex);
                }
                else
                {
                    paramValue = headerValue;
                }
            }

            // Slice to remove the '"paramValue"' from the parameters.
            if (headerValue != paramValue)
                headerValue = headerValue.Slice(paramValue.Length + 1);

            return true;
        }
    }
}
