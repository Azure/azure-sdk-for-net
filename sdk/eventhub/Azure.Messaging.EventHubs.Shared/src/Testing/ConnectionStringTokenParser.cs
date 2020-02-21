// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.RegularExpressions;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   General purpose parser that allows to retrieve a token in connection string.
    /// </summary>
    ///
    internal static class ConnectionStringTokenParser
    {
        /// <summary>It matches a pair "key=value" in a connection string</summary>
        private static readonly Regex TokenValueRegex = new Regex("(?<tokenkey>[^;]+)=(?<tokenvalue>[^;]+)(;|$)", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        /// <summary>It matches the name of an event hub namespace</summary>
        private static readonly Regex NamespaceNameRegex = new Regex(@"sb://(?<namespacename>.+)\.servicebus\.windows\.net", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        /// <summary>
        ///   It parses a connection string looking for the provided token name and returns its value.
        /// </summary>
        ///
        /// <param name="connectionString">An Event Hubs namespace connection string</param>
        /// <param name="tokenKey">The token to be looked for</param>
        ///
        /// <returns>The value of the token if found; otherwise, a <see cref="InvalidOperationException" /> is thrown.</returns>
        ///
        public static string ParseTokenAndReturnValue(string connectionString, string tokenKey)
        {
            string token = ParseToken(connectionString, tokenKey);

            if (string.IsNullOrEmpty(token))
            {
                throw new InvalidOperationException($"The { tokenKey } token was not found.");
            }

            string tokenValue = ParseTokenValue(token);

            if (string.IsNullOrEmpty(tokenValue))
            {
                throw new InvalidOperationException($"The { tokenKey } token is not well-formed.");
            }

            return tokenValue;
        }

        /// <summary>
        ///   It parses a connection string looking for the provided token and returns it.
        /// </summary>
        ///
        /// <param name="connectionString">An Event Hubs namespace connection string</param>
        /// <param name="tokenKey">The token key to be looked for</param>
        ///
        /// <returns>The token if found; otherwise, null.</returns>
        ///
        public static string ParseToken(string connectionString, string tokenKey)
        {
            var regex = new Regex($"(?<token>{ tokenKey }=[^;]+(;|$))", RegexOptions.IgnoreCase);

            if (regex.IsMatch(connectionString))
            {
                return regex.Match(connectionString).Groups["token"].Value;
            }

            return null;
        }

        /// <summary>
        ///   It parses a token and returns its value.
        /// </summary>
        ///
        /// <param name="token">The token to be looked for in the form "Key=Value;"</param>
        ///
        /// <returns>The value of the token if found; otherwise, null.</returns>
        ///
        public static string ParseTokenValue(string token)
        {
            if (TokenValueRegex.IsMatch(token))
            {
                return TokenValueRegex.Match(token).Groups["tokenvalue"].Value;
            }

            return null;
        }

        /// <summary>
        ///   It parses a fully qualified domain name and returns the contained namespace name.
        /// </summary>
        ///
        /// <param name="fullyQualifiedDomainName">The FQDN in the form <c>sb://{namespacename}.servicebus.windows.net/</c></param>
        ///
        /// <returns>The namespace name if found; otherwise, a <see cref="FormatException" /> is thrown.</returns>
        ///
        public static string ParseNamespaceName(string fullyQualifiedDomainName)
        {
            if (NamespaceNameRegex.IsMatch(fullyQualifiedDomainName))
            {
                return NamespaceNameRegex.Match(fullyQualifiedDomainName).Groups["namespacename"].Value;
            }

            throw new FormatException($"The fully qualified domain name could not be parsed. The value is: { fullyQualifiedDomainName }.");
        }
    }
}
