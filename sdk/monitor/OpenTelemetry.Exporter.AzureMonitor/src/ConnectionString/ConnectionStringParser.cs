// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;

namespace OpenTelemetry.Exporter.AzureMonitor.ConnectionString
{
    internal static class ConnectionStringParser
    {
        /// <summary>
        /// Parse a connection string that matches the format: "key1=value1;key2=value2;key3=value3".
        /// </summary>
        public static void GetValues(string connectionString, out string ikey, out string endpoint)
        {
            try
            {
                if (connectionString == null)
                {
                    throw new ArgumentNullException(nameof(connectionString));
                }
                else if (connectionString.Length > Constants.ConnectionStringMaxLength)
                {
                    throw new ArgumentOutOfRangeException(nameof(connectionString), $"Values greater than {Constants.ConnectionStringMaxLength} characters are not allowed.");
                }

                var connString = Azure.Core.ConnectionString.Parse(connectionString);
                ikey = connString.GetRequired(Constants.InstrumentationKeyKey);
                endpoint = GetIngestionEndpoint(connString).AbsoluteUri;
            }
            catch (Exception ex)
            {
                string message = "Connection String Error: " + ex.Message;
                //TODO: Log to ETW
                throw new Exception(message, ex);
            }
        }

        /// <summary>
        /// Will evaluate connection string and return the requested endpoint.
        /// </summary>
        /// <remarks>
        /// Parsing the connection string MUST follow these rules:
        ///     1. check for explicit endpoint (location is ignored)
        ///     2. check for endpoint suffix (location is optional)
        ///     3. use classic endpoint (location is ignored)
        /// This behavior is required by the Connection String spec.
        /// </remarks>
        /// <returns>Returns a <see cref="Uri" /> for the requested endpoint. Passing the string value through the Uri constructor will validate that it is a valid endpoint.</returns>
        internal static Uri GetIngestionEndpoint(Azure.Core.ConnectionString connectionString)
        {
            if (connectionString.TryGetNonRequiredValue(Constants.IngestionExplicitEndpointKey, out string explicitEndpoint))
            {
                if (Uri.TryCreate(explicitEndpoint, UriKind.Absolute, out var uri))
                {
                    return uri;
                }
                else
                {
                    throw new ArgumentException($"The value for {Constants.IngestionExplicitEndpointKey} is invalid. '{explicitEndpoint}'");
                }
            }
            else if (connectionString.TryGetNonRequiredValue("EndpointSuffix", out string endpointSuffix))
            {
                var location = connectionString.GetNonRequired(Constants.LocationKey);
                if (TryBuildUri(prefix: Constants.IngestionPrefix, suffix: endpointSuffix, location: location, uri: out var uri))
                {
                    return uri;
                }
                else
                {
                    throw new ArgumentException($"The value for EndpointSuffix is invalid. '{endpointSuffix}'");
                }
            }
            else
            {
                return new Uri(Constants.DefaultIngestionEndpoint);
            }

        }

        /// <summary>
        /// Construct a Uri from the possible parts.
        /// Format: "location.prefix.suffix".
        /// Example: "https://westus2.dc.applicationinsights.azure.cn/".
        /// </summary>
        /// <remarks>
        /// Will also attempt to sanitize user input. Won't fail just because the user typo-ed an extra period.
        /// </remarks>
        /// <returns>Returns a <see cref="Uri"/> built from the inputs.</returns>
        internal static bool TryBuildUri(string prefix, string suffix, out Uri uri, string location = null)
        {
            // Location and Suffix are user input fields and need to be sanitized (extra spaces or periods).
            char[] trimPeriod = new char[] { '.' };

            if (location != null)
            {
                location = location.Trim().TrimEnd(trimPeriod);

                // Location names are expected to match Azure region names. No special characters allowed.
                if (!location.All(x => char.IsLetterOrDigit(x)))
                {
                    throw new ArgumentException($"The value for Location must not contain special characters. '{location}'");
                }
            }

            var uriString = string.Concat("https://",
                string.IsNullOrEmpty(location) ? string.Empty : (location + "."),
                prefix,
                ".",
                suffix.Trim().TrimStart(trimPeriod));

            return Uri.TryCreate(uriString, UriKind.Absolute, out uri);
        }

        /// <summary>
        /// This method wraps <see cref="Azure.Core.ConnectionString.GetNonRequired(string)"/> in a null check.
        /// </summary>
        internal static bool TryGetNonRequiredValue(this Azure.Core.ConnectionString connectionString, string key, out string value)
        {
            value = connectionString.GetNonRequired(key);
            return value != null;
        }
    }
}
