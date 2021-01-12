// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;
using Azure.Core;
using AccountSetting = System.Collections.Generic.KeyValuePair<string, System.Func<string, bool>>;
using ConnectionStringFilter = System.Func<System.Collections.Generic.IDictionary<string, string>, System.Collections.Generic.IDictionary<string, string>>;

namespace Azure.Data.Tables
{
    internal class TableConnectionString
    {
        /// <summary>
        /// Gets the endpoints for the Table service at the primary and secondary location, as configured for the storage account.
        /// </summary>
        /// <value>A <see cref="System.Uri"/> containing the Table service endpoints.</value>
        public (Uri PrimaryUri, Uri SecondaryUri) TableStorageUri { get; set; }

        /// <summary>
        /// Gets the credentials used to create this <see cref="TableConnectionString"/> object.
        /// </summary>
        /// <value>A StorageCredentials object.</value>
        public object Credentials { get; set; }

        /// <summary>
        /// True if the user used a constructor that auto-generates endpoints.
        /// </summary>
        internal bool DefaultEndpoints { get; set; }

        /// <summary>
        /// The storage service hostname suffix set by the user, if any.
        /// </summary>
        internal string EndpointSuffix { get; set; }

        /// <summary>
        /// The connection string parsed into settings.
        /// </summary>
        internal ConnectionString Settings { get; set; }

        /// <summary>
        /// Indicates whether this account is a development storage account.
        /// </summary>
        internal bool IsDevStoreAccount { get; set; }

        /// <summary>
        /// Private record of the account name for use in ToString(bool).
        /// </summary>
        internal string _accountName;

        /// <summary>
        /// Singleton instance for the development storage account.
        /// </summary>
        private static TableConnectionString s_devStoreAccount;

        /// <summary>
        /// Initializes a new instance of the <see cref="TableConnectionString"/> class using the specified
        /// account credentials and service endpoints.
        /// </summary>
        /// <param name="storageCredentials">A StorageCredentials object.</param>
        /// <param name="tableStorageUri">A <see cref="System.Uri"/> specifying the Table service endpoint or endpoints.</param>
        public TableConnectionString(
            object storageCredentials,
            (Uri, Uri) tableStorageUri)
        {
            Credentials = storageCredentials;
            TableStorageUri = tableStorageUri;
            DefaultEndpoints = false;
        }

        /// <summary>
        /// Gets a <see cref="TableConnectionString"/> object that references the well-known development storage account.
        /// </summary>
        /// <value>A <see cref="TableConnectionString"/> object representing the development storage account.</value>
        public static TableConnectionString DevelopmentStorageAccount
        {
            get
            {
                if (s_devStoreAccount == null)
                {
                    s_devStoreAccount = GetDevelopmentStorageAccount(null);
                }

                return s_devStoreAccount;
            }
        }

        /// <summary>
        /// Parses a connection string and returns a <see cref="TableConnectionString"/> created
        /// from the connection string.
        /// </summary>
        /// <param name="connectionString">A valid connection string.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="connectionString"/> is null or empty.</exception>
        /// <exception cref="FormatException">Thrown if <paramref name="connectionString"/> is not a valid connection string.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="connectionString"/> cannot be parsed.</exception>
        /// <returns>A <see cref="TableConnectionString"/> object constructed from the values provided in the connection string.</returns>
        public static TableConnectionString Parse(string connectionString)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));

            if (ParseInternal(connectionString, out TableConnectionString ret, out string err))
            {
                if (err != null)
                {
                    throw new FormatException(err);
                }
                return ret;
            }

            throw new ArgumentException("Connection string parsing error");
        }

        /// <summary>
        /// Indicates whether a connection string can be parsed to return a <see cref="TableConnectionString"/> object.
        /// </summary>
        /// <param name="connectionString">The connection string to parse.</param>
        /// <param name="account">A <see cref="TableConnectionString"/> object to hold the instance returned if
        /// the connection string can be parsed.</param>
        /// <returns><b>true</b> if the connection string was successfully parsed; otherwise, <b>false</b>.</returns>
        public static bool TryParse(string connectionString, out TableConnectionString account)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                account = null;
                return false;
            }

            try
            {
                return ParseInternal(connectionString, out account, out var error);
            }
            catch (Exception)
            {
                account = null;
                return false;
            }
        }

        /// <summary>
        /// Internal implementation of Parse/TryParse.
        /// </summary>
        /// <param name="connectionString">The string to parse.</param>
        /// <param name="accountInformation">The <see cref="TableConnectionString"/> to return.</param>
        /// <param name="error">A callback for reporting errors.</param>
        /// <returns>If true, the parse was successful. Otherwise, false.</returns>
        internal static bool ParseInternal(string connectionString, out TableConnectionString accountInformation, out string error)
        {
            error = null;

            ConnectionString settings = ConnectionString.Parse(connectionString);

            // malformed settings string

            if (settings == null)
            {
                accountInformation = null;
                error = "Unable to parse connection string.";
                return false;
            }

            // helper method

            string settingOrDefault(string key)
            {
                settings.TryGetSegmentValue(key, out var result);
                return result;
            }

            // devstore case

            if (settings.TryGetSegmentValue(TableConstants.ConnectionStrings.UseDevelopmentSetting, out var useDevSettings) && useDevSettings == "true")
            {
                accountInformation =
                    settings.TryGetSegmentValue(TableConstants.ConnectionStrings.DevelopmentProxyUriSetting, out var proxyUri)
                    ? GetDevelopmentStorageAccount(new Uri(proxyUri))
                    : DevelopmentStorageAccount;

                return true;
            }

            // non-devstore case
            string sasToken = default;

            var matchesExplicitEndpointsSpec =
                settings.TryGetSegmentValue(TableConstants.ConnectionStrings.TableEndpointSetting, out var tableEndpoint) &&
                Uri.IsWellFormedUriString(tableEndpoint, UriKind.Absolute) &&
                settings.TryGetSegmentValue(TableConstants.ConnectionStrings.SharedAccessSignatureSetting, out sasToken);

            var matchesAutomaticEndpointsSpec = settings.TryGetSegmentValue(TableConstants.ConnectionStrings.AccountNameSetting, out var accountName) &&
                settings.TryGetSegmentValue(TableConstants.ConnectionStrings.AccountKeySetting, out var accountKey) &&
                    (settings.TryGetSegmentValue(TableConstants.ConnectionStrings.TableEndpointSetting, out var primary) ||
                    settings.TryGetSegmentValue(TableConstants.ConnectionStrings.EndpointSuffixSetting, out var endpointSuffix));

            if (matchesAutomaticEndpointsSpec || matchesExplicitEndpointsSpec)
            {
                if (matchesAutomaticEndpointsSpec && !settings.ContainsSegmentKey(TableConstants.ConnectionStrings.DefaultEndpointsProtocolSetting))
                {
                    settings.Add(TableConstants.ConnectionStrings.DefaultEndpointsProtocolSetting, "https");
                }

                var tableSecondaryEndpoint = settingOrDefault(TableConstants.ConnectionStrings.TableSecondaryEndpointSetting);

                // if secondary is specified, primary must also be specified

                static bool IsValidEndpointPair(string primary, string secondary) =>
                        !string.IsNullOrWhiteSpace(primary)
                        || /* primary is null, and... */ string.IsNullOrWhiteSpace(secondary);

                (Uri, Uri) createStorageUri(string primary, string secondary, string sasToken, Func<ConnectionString, (Uri, Uri)> factory)
                {
                    if (!string.IsNullOrWhiteSpace(primary))
                    {
                        Uri primaryUri = CreateUri(primary, sasToken);
                        Uri secondaryUri = CreateUri(secondary, sasToken) ?? GetSecondaryUriFromPrimary(primaryUri, accountName);

                        return (primaryUri, secondaryUri);
                    }
                    else if (matchesAutomaticEndpointsSpec && factory != null)
                    {
                        return factory(settings);
                    }
                    else
                    {
                        return (default, default);
                    }

                    static Uri CreateUri(string endpoint, string sasToken)
                    {
                        if (string.IsNullOrWhiteSpace(endpoint))
                        {
                            return default;
                        }
                        var builder = new UriBuilder(endpoint);
                        if (!string.IsNullOrEmpty(builder.Query))
                        {
                            builder.Query += "&" + sasToken;
                        }
                        else
                        {
                            builder.Query = sasToken;
                        }
                        return builder.Uri;
                    }
                }

                if (IsValidEndpointPair(tableEndpoint, tableSecondaryEndpoint))
                {
                    accountInformation =
                        new TableConnectionString(
                            GetCredentials(settings),
                            tableStorageUri: createStorageUri(tableEndpoint, tableSecondaryEndpoint, sasToken ?? string.Empty, ConstructTableEndpoint)
                            )
                        {
                            EndpointSuffix = settingOrDefault(TableConstants.ConnectionStrings.EndpointSuffixSetting),
                            Settings = settings
                        };

                    accountInformation._accountName = settingOrDefault(TableConstants.ConnectionStrings.AccountNameSetting);

                    return true;
                }
            }

            // not valid
            accountInformation = null;
            error = "No valid combination of account information found.";
            return false;
        }

        private const string TableNameGroup = "tableName";
        private static readonly Regex s_tableUriTableNameRegex = new Regex(@$"(Tables\('(?<{TableNameGroup}>\w+)'\))", RegexOptions.Compiled);

        /// <summary>
        /// Returns the table name given the <paramref name="uri"/>.
        /// </summary>
        /// <param name="uri">The primary endpoint Uri.</param>
        /// <returns></returns>
        internal static string GetTableNameFromUri(Uri uri)
        {
            var segments = uri.Segments;
            var lastSegment = segments[segments.Length - 1];

            Match match = s_tableUriTableNameRegex.Match(lastSegment);

            if (match.Success)
            {
                return match.Groups[TableNameGroup].Value;
            }
            else
            {
                UriHostNameType hostNameType = Uri.CheckHostName(uri.Host);
                int expectedSegments = hostNameType switch
                {
                    // This is a dns name such as contoso.core.windows.net/tableName
                    UriHostNameType.Dns => 2,
                    // This is most likely Azurite, which looks like this: https://126.0.0.1:10002/contoso/tableName
                    UriHostNameType.IPv4 => 3,
                    _ when uri.IsLoopback => 3,
                    _ => 0
                };

                if (segments.Length < expectedSegments)
                {
                    return string.Empty;
                }

                return lastSegment.EndsWith("/", StringComparison.OrdinalIgnoreCase) ?
                lastSegment.Substring(0, lastSegment.Length - 1) :
                lastSegment;
            }
        }

        /// <summary>
        /// Returns the account name given the <paramref name="uri"/>.
        /// </summary>
        /// <param name="uri">The primary endpoint Uri.</param>
        /// <returns></returns>
        internal static string GetAccountNameFromUri(Uri uri)
        {
            string accountName = null;
            var indexOfDot = uri.Host.IndexOf('.');
            UriHostNameType hostNameType = Uri.CheckHostName(uri.Host);

            if (indexOfDot >= 0 && hostNameType == UriHostNameType.Dns)
            {
                // This is a dns name such as contoso.core.windows.net
                accountName = uri.Host.Substring(0, indexOfDot);
            }
            else if (uri.IsLoopback || hostNameType == UriHostNameType.IPv4)
            {
                // This is most likely Azurite, which looks like this: https://127.0.0.1:10002/contoso/
                var segments = uri.Segments;

                accountName = segments[1].EndsWith("/", StringComparison.OrdinalIgnoreCase) ?
                    segments[1].Substring(0, segments[1].Length - 1) :
                    segments[1];
            }

            return accountName;
        }

        /// <summary>
        /// Generates the secondary endpoint Uri given the <paramref name="primaryUri"/>.
        /// </summary>
        /// <param name="primaryUri">The primary endpoint Uri.</param>
        /// <param name="accountName">The account name.</param>
        /// <returns></returns>
        internal static Uri GetSecondaryUriFromPrimary(Uri primaryUri, string accountName = null)
        {
            var secondaryUriBuilder = new UriBuilder(primaryUri);

            if (!string.IsNullOrEmpty(accountName))
            {
                // We've been provided the accountName, so just insert the '-secondary' suffix after it
                var indexOfAccountName = secondaryUriBuilder.Host.IndexOf(accountName, StringComparison.OrdinalIgnoreCase);
                secondaryUriBuilder.Host = secondaryUriBuilder.Host.Insert(indexOfAccountName + accountName.Length, TableConstants.ConnectionStrings.SecondaryLocationAccountSuffix);
                return secondaryUriBuilder.Uri;
            }

            var indexOfDot = secondaryUriBuilder.Host.IndexOf('.');
            UriHostNameType hostNameType = Uri.CheckHostName(secondaryUriBuilder.Host);

            if (indexOfDot >= 0 && hostNameType == UriHostNameType.Dns)
            {
                // This is a dns name such as contoso.core.windows.net
                // Insert the '-secondary' suffix after the first part of the host name
                secondaryUriBuilder.Host = secondaryUriBuilder.Host.Insert(indexOfDot, TableConstants.ConnectionStrings.SecondaryLocationAccountSuffix);
            }
            else if (primaryUri.IsLoopback || hostNameType == UriHostNameType.IPv4)
            {
                // This is most likely Azurite, which looks like this: https://127.0.0.1:10002/contoso/
                // Insert the '-secondary' suffix after the 2nd segment (the first segment is '/')
                var segments = primaryUri.Segments;
                var accountNameSegmentLength = segments[1].Length;
                var insertIndex = segments[1].EndsWith("/", StringComparison.OrdinalIgnoreCase) ? accountNameSegmentLength - 1 : accountNameSegmentLength;
                segments[1] = segments[1].Insert(insertIndex, TableConstants.ConnectionStrings.SecondaryLocationAccountSuffix);
                secondaryUriBuilder.Path = string.Join(string.Empty, segments);
            }
            else
            {
                // this is not a valid host name
                return default;
            }

            return secondaryUriBuilder.Uri;
        }

        /// <summary>
        /// Returns a <see cref="TableConnectionString"/> with development storage credentials using the specified proxy Uri.
        /// </summary>
        /// <param name="proxyUri">The proxy endpoint to use.</param>
        /// <returns>The new <see cref="TableConnectionString"/>.</returns>
        private static TableConnectionString GetDevelopmentStorageAccount(Uri proxyUri)
        {
            UriBuilder builder = proxyUri != null ?
                new UriBuilder(proxyUri.Scheme, proxyUri.Host) :
                new UriBuilder("http", TableConstants.ConnectionStrings.Localhost);

            builder.Path = TableConstants.ConnectionStrings.DevStoreAccountName;

            builder.Port = TableConstants.ConnectionStrings.TableEndpointPortNumber;
            Uri tableEndpoint = builder.Uri;

            builder.Path = TableConstants.ConnectionStrings.DevStoreAccountName + TableConstants.ConnectionStrings.SecondaryLocationAccountSuffix;

            builder.Port = TableConstants.ConnectionStrings.TableEndpointPortNumber;
            Uri tableSecondaryEndpoint = builder.Uri;

            var credentials = new TableSharedKeyCredential(TableConstants.ConnectionStrings.DevStoreAccountName, TableConstants.ConnectionStrings.DevStoreAccountKey);
            var account = new TableConnectionString(
                credentials,
                tableStorageUri: (tableEndpoint, tableSecondaryEndpoint))
            {
                Settings = ConnectionString.Empty()
            };
            account.Settings.Add(TableConstants.ConnectionStrings.UseDevelopmentSetting, "true");
            if (proxyUri != null)
            {
                account.Settings.Add(TableConstants.ConnectionStrings.DevelopmentProxyUriSetting, proxyUri.ToString());
            }

            account.IsDevStoreAccount = true;

            return account;
        }

        /// <summary>
        /// Gets a StorageCredentials object corresponding to whatever credentials are supplied in the given settings.
        /// </summary>
        /// <param name="settings">The settings to check.</param>
        /// <returns>The StorageCredentials object specified in the settings.</returns>
        private static object GetCredentials(ConnectionString settings)
        {
            settings.TryGetSegmentValue(TableConstants.ConnectionStrings.AccountNameSetting, out var accountName);
            settings.TryGetSegmentValue(TableConstants.ConnectionStrings.AccountKeySetting, out var accountKey);
            settings.TryGetSegmentValue(TableConstants.ConnectionStrings.SharedAccessSignatureSetting, out var sharedAccessSignature);

            return
                accountName != null && accountKey != null && sharedAccessSignature == null
                ? new TableSharedKeyCredential(accountName, accountKey)
                : (object)(accountKey == null && sharedAccessSignature != null
                    ? sharedAccessSignature
                    : null);
        }

        /// <summary>
        /// Construct the Primary/Secondary Uri tuple.
        /// </summary>
        /// <param name="scheme">The protocol to use.</param>
        /// <param name="accountName">The name of the storage account.</param>
        /// <param name="hostNamePrefix">Prefix that appears before the host name, e.g. "blob".</param>
        /// <param name="endpointSuffix">The Endpoint DNS suffix; use <c>null</c> for default.</param>
        /// <param name="sasToken">The sas token; use <c>null</c> for default.</param>
        /// <returns></returns>
        private static (Uri, Uri) ConstructUris(
            string scheme,
            string accountName,
            string hostNamePrefix,
            string endpointSuffix,
            string sasToken)
        {
            var primaryUriBuilder = new UriBuilder
            {
                Scheme = scheme,
                Host = string.Format(
                        CultureInfo.InvariantCulture,
                        "{0}.{1}.{2}",
                        accountName,
                        hostNamePrefix,
                        endpointSuffix),
                Query = sasToken
            };

            var secondaryUriBuilder = new UriBuilder
            {
                Scheme = scheme,
                Host = string.Format(
                        CultureInfo.InvariantCulture,
                        "{0}{1}.{2}.{3}",
                        accountName,
                        TableConstants.ConnectionStrings.SecondaryLocationAccountSuffix,
                        hostNamePrefix,
                        endpointSuffix),
                Query = sasToken
            };

            return (primaryUriBuilder.Uri, secondaryUriBuilder.Uri);
        }

        /// <summary>
        /// Gets the default table endpoint using the specified protocol and account name.
        /// </summary>
        /// <param name="scheme">The protocol to use.</param>
        /// <param name="accountName">The name of the storage account.</param>
        /// <param name="endpointSuffix">The Endpoint DNS suffix; use <c>null</c> for default.</param>
        /// <param name="sasToken">The sas token; use <c>null</c> for default.</param>
        /// <returns>The default table endpoint.</returns>
        internal static (Uri, Uri) ConstructTableEndpoint(string scheme, string accountName, string endpointSuffix, string sasToken)
        {
            if (string.IsNullOrEmpty(scheme))
            {
                throw Errors.ArgumentNull(nameof(scheme));
            }

            if (string.IsNullOrEmpty(accountName))
            {
                throw Errors.ArgumentNull(nameof(accountName));
            }

            if (string.IsNullOrEmpty(endpointSuffix))
            {
                endpointSuffix = TableConstants.ConnectionStrings.DefaultEndpointSuffix;
            }

            return ConstructUris(scheme, accountName, TableConstants.ConnectionStrings.DefaultTableHostnamePrefix, endpointSuffix, sasToken);
        }

        /// <summary>
        /// Gets the default table endpoint using the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>The default table endpoint.</returns>
        private static (Uri, Uri) ConstructTableEndpoint(ConnectionString settings) => ConstructTableEndpoint(
                settings.GetRequired(TableConstants.ConnectionStrings.DefaultEndpointsProtocolSetting),
                settings.GetRequired(TableConstants.ConnectionStrings.AccountNameSetting),
                settings.GetNonRequired(TableConstants.ConnectionStrings.EndpointSuffixSetting),
                settings.GetNonRequired(TableConstants.ConnectionStrings.SharedAccessSignatureSetting));
    }
}
