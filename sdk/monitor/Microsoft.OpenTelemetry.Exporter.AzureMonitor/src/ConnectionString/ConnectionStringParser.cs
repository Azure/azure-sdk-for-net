// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;

// This alias is necessary because it will otherwise try to default to "Microsoft.Azure.Core" which doesn't exist.
using AzureCoreConnectionString = Azure.Core.ConnectionString;

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor.ConnectionString
{
    internal static class ConnectionStringParser
    {
        /// <summary>
        /// Parse a connection string that matches the format: "key1=value1;key2=value2;key3=value3".
        /// This method will encapsulate all exception handling.
        /// </summary>
        /// <remarks>
        /// Official Doc: <a href="https://docs.microsoft.com/azure/azure-monitor/app/sdk-connection-string" />.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// Any exceptions that occur while parsing the connection string will be wrapped and re-thrown.
        /// </exception>
        public static void GetValues(string connectionString, out string instrumentationKey, out string ingestionEndpoint)
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

                var connString = AzureCoreConnectionString.Parse(connectionString);
                instrumentationKey = connString.GetInstrumentationKey();
                ingestionEndpoint = connString.GetIngestionEndpoint();
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.Write($"ConnectionStringError{EventLevelSuffix.Error}", ex);
                throw new InvalidOperationException("Connection String Error: " + ex.Message, ex);
            }
        }

        internal static string GetInstrumentationKey(this AzureCoreConnectionString connectionString) => connectionString.GetRequired(Constants.InstrumentationKeyKey);

        /// <summary>
        /// Evaluate connection string and return the requested endpoint.
        /// </summary>
        /// <remarks>
        /// Parsing the connection string MUST follow these rules:
        ///     1. check for explicit endpoint (location is ignored)
        ///     2. check for endpoint suffix (location is optional)
        ///     3. use default endpoint (location is ignored)
        /// This behavior is required by the Connection String Specification.
        /// </remarks>
        internal static string GetIngestionEndpoint(this AzureCoreConnectionString connectionString)
        {
            // Passing the user input values through the Uri constructor will verify that we've built a valid endpoint.
            Uri uri;

            if (connectionString.TryGetNonRequiredValue(Constants.IngestionExplicitEndpointKey, out string explicitEndpoint))
            {
                if (!Uri.TryCreate(explicitEndpoint, UriKind.Absolute, out uri))
                {
                    throw new ArgumentException($"The value for {Constants.IngestionExplicitEndpointKey} is invalid. '{explicitEndpoint}'");
                }
            }
            else if (connectionString.TryGetNonRequiredValue(Constants.EndpointSuffixKey, out string endpointSuffix))
            {
                var location = connectionString.GetNonRequired(Constants.LocationKey);
                if (!TryBuildUri(prefix: Constants.IngestionPrefix, suffix: endpointSuffix, location: location, uri: out uri))
                {
                    throw new ArgumentException($"The value for {Constants.EndpointSuffixKey} is invalid. '{endpointSuffix}'");
                }
            }
            else
            {
                return Constants.DefaultIngestionEndpoint;
            }

            return uri.AbsoluteUri;
        }

        /// <summary>
        /// Construct a Uri from the possible parts.
        /// Format: "location.prefix.suffix".
        /// Example: "https://westus2.dc.applicationinsights.azure.cn/".
        /// </summary>
        /// <remarks>
        /// Will also attempt to sanitize user input. Won't fail if the user typo-ed an extra period.
        /// </remarks>
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
                    throw new ArgumentException($"The value for Location must contain only alphanumeric characters. '{location}'");
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
        /// This method wraps <see cref="AzureCoreConnectionString.GetNonRequired(string)"/> in a null check.
        /// </summary>
        internal static bool TryGetNonRequiredValue(this AzureCoreConnectionString connectionString, string key, out string value)
        {
            value = connectionString.GetNonRequired(key);
            return value != null;
        }
    }
}
