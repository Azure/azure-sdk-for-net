// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using Microsoft.AspNetCore.WebUtilities;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal static class SignalRTriggerUtils
    {
        private const string CommaSeparator = ",";
        private static readonly char[] HeaderSeparator = { ',' };
        private static readonly string[] ClaimsSeparator = { ": " };

        public static IDictionary<string, string> GetQueryDictionary(string queryString)
        {
            if (string.IsNullOrEmpty(queryString))
            {
                return default;
            }

            // The query string looks like "?key1=value1&key2=value2"
            var queries = QueryHelpers.ParseQuery(queryString);
            return queries.ToDictionary(x => x.Key, x => x.Value.ToString());
        }

        public static IDictionary<string, string> GetClaimDictionary(string claims)
        {
            if (string.IsNullOrEmpty(claims))
            {
                return default;
            }

            // The claim string looks like "a: v, b: v"
            return claims.Split(HeaderSeparator, StringSplitOptions.RemoveEmptyEntries)
                .Select(p => p.Split(ClaimsSeparator, StringSplitOptions.RemoveEmptyEntries)).Where(l => l.Length == 2)
                .GroupBy(s => s[0].Trim(), (k, g) => new KeyValuePair<string, string>(k, g.Select(gk => gk[1].Trim()).FirstOrDefault()))
                .ToDictionary(x => x.Key, x => x.Value);
        }

        public static IReadOnlyList<string> GetSignatureList(string signatures)
        {
            if (string.IsNullOrEmpty(signatures))
            {
                return default;
            }

            return signatures.Split(HeaderSeparator, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToList();
        }

        public static IDictionary<string, string> GetHeaderDictionary(HttpRequestHeaders headers)
        {
            return headers.ToDictionary(x => x.Key, x => string.Join(CommaSeparator, x.Value.ToArray()), StringComparer.OrdinalIgnoreCase);
        }

        public static string GetConnectionNameFromAttribute(Type serverlessHubType) =>
            serverlessHubType.GetCustomAttribute<ServerlessHub.SignalRConnectionAttribute>()?.Connection ??
            serverlessHubType.GetCustomAttribute<SignalRConnectionAttribute>()?.Connection;
    }
}