// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using AccountSetting = System.Collections.Generic.KeyValuePair<string, System.Func<string, bool>>;
using ConnectionStringFilter = System.Func<System.Collections.Generic.IDictionary<string, string>, System.Collections.Generic.IDictionary<string, string>>;

#pragma warning disable SA1402  // File may only contain a single type

namespace Azure.Storage
{
    internal class StorageConnectionString
    {
        /// <summary>
        /// Gets or sets a value indicating whether the FISMA MD5 setting will be used.
        /// </summary>
        /// <value><c>false</c> to use the FISMA MD5 setting; <c>true</c> to use the .NET default implementation.</value>
        internal static bool UseV1MD5 => true;

        /// <summary>
        /// Validator for the UseDevelopmentStorage setting. Must be "true".
        /// </summary>
        private static readonly AccountSetting s_useDevelopmentStorageSetting = Setting(Constants.ConnectionStrings.UseDevelopmentSetting, "true");

        /// <summary>
        /// Validator for the DevelopmentStorageProxyUri setting. Must be a valid Uri.
        /// </summary>
        private static readonly AccountSetting s_developmentStorageProxyUriSetting = Setting(Constants.ConnectionStrings.DevelopmentProxyUriSetting, IsValidUri);

        /// <summary>
        /// Validator for the DefaultEndpointsProtocol setting. Must be either "http" or "https".
        /// </summary>
        private static readonly AccountSetting s_defaultEndpointsProtocolSetting = Setting(Constants.ConnectionStrings.DefaultEndpointsProtocolSetting, "http", "https");

        /// <summary>
        /// Validator for the AccountName setting. No restrictions.
        /// </summary>
        private static readonly AccountSetting s_accountNameSetting = Setting(Constants.ConnectionStrings.AccountNameSetting);

        /// <summary>
        /// Validator for the AccountKey setting. No restrictions.
        /// </summary>
        private static readonly AccountSetting s_accountKeyNameSetting = Setting(Constants.ConnectionStrings.AccountKeyNameSetting);

        /// <summary>
        /// Validator for the AccountKey setting. Must be a valid base64 string.
        /// </summary>
        private static readonly AccountSetting s_accountKeySetting = Setting(Constants.ConnectionStrings.AccountKeySetting, IsValidBase64String);

        /// <summary>
        /// Validator for the BlobEndpoint setting. Must be a valid Uri.
        /// </summary>
        private static readonly AccountSetting s_blobEndpointSetting = Setting(Constants.ConnectionStrings.BlobEndpointSetting, IsValidUri);

        /// <summary>
        /// Validator for the QueueEndpoint setting. Must be a valid Uri.
        /// </summary>
        private static readonly AccountSetting s_queueEndpointSetting = Setting(Constants.ConnectionStrings.QueueEndpointSetting, IsValidUri);

        /// <summary>
        /// Validator for the FileEndpoint setting. Must be a valid Uri.
        /// </summary>
        private static readonly AccountSetting s_fileEndpointSetting = Setting(Constants.ConnectionStrings.FileEndpointSetting, IsValidUri);

        /// <summary>
        /// Validator for the TableEndpoint setting. Must be a valid Uri.
        /// </summary>
        private static readonly AccountSetting s_tableEndpointSetting = Setting(Constants.ConnectionStrings.TableEndpointSetting, IsValidUri);

        /// <summary>
        /// Validator for the BlobSecondaryEndpoint setting. Must be a valid Uri.
        /// </summary>
        private static readonly AccountSetting s_blobSecondaryEndpointSetting = Setting(Constants.ConnectionStrings.BlobSecondaryEndpointSetting, IsValidUri);

        /// <summary>
        /// Validator for the QueueSecondaryEndpoint setting. Must be a valid Uri.
        /// </summary>
        private static readonly AccountSetting s_queueSecondaryEndpointSetting = Setting(Constants.ConnectionStrings.QueueSecondaryEndpointSetting, IsValidUri);

        /// <summary>
        /// Validator for the FileSecondaryEndpoint setting. Must be a valid Uri.
        /// </summary>
        private static readonly AccountSetting s_fileSecondaryEndpointSetting = Setting(Constants.ConnectionStrings.FileSecondaryEndpointSetting, IsValidUri);

        /// <summary>
        /// Validator for the TableSecondaryEndpoint setting. Must be a valid Uri.
        /// </summary>
        private static readonly AccountSetting s_tableSecondaryEndpointSetting = Setting(Constants.ConnectionStrings.TableSecondaryEndpointSetting, IsValidUri);

        /// <summary>
        /// Validator for the EndpointSuffix setting. Must be a valid Uri.
        /// </summary>
        private static readonly AccountSetting s_endpointSuffixSetting = Setting(Constants.ConnectionStrings.EndpointSuffixSetting, IsValidDomain);

        /// <summary>
        /// Validator for the SharedAccessSignature setting. No restrictions.
        /// </summary>
        private static readonly AccountSetting s_sharedAccessSignatureSetting = Setting(Constants.ConnectionStrings.SharedAccessSignatureSetting);

        /// <summary>
        /// Singleton instance for the development storage account.
        /// </summary>
        private static StorageConnectionString s_devStoreAccount;

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageConnectionString"/> class using the specified
        /// account credentials and service endpoints.
        /// </summary>
        /// <param name="storageCredentials">A StorageCredentials object.</param>
        /// <param name="blobStorageUri">A <see cref="System.Uri"/> specifying the Blob service endpoint or endpoints.</param>
        /// <param name="queueStorageUri">A <see cref="System.Uri"/> specifying the Queue service endpoint or endpoints.</param>
        /// <param name="tableStorageUri">A <see cref="System.Uri"/> specifying the Table service endpoint or endpoints.</param>
        /// <param name="fileStorageUri">A <see cref="System.Uri"/> specifying the File service endpoint or endpoints.</param>
        public StorageConnectionString(
            object storageCredentials,
            (Uri, Uri) blobStorageUri = default,
            (Uri, Uri) queueStorageUri = default,
            (Uri, Uri) tableStorageUri = default,
            (Uri, Uri) fileStorageUri = default)
        {
            Credentials = storageCredentials;
            BlobStorageUri = blobStorageUri;
            QueueStorageUri = queueStorageUri;
            TableStorageUri = tableStorageUri;
            FileStorageUri = fileStorageUri;
            DefaultEndpoints = false;
        }

        /// <summary>
        /// Gets a <see cref="StorageConnectionString"/> object that references the well-known development storage account.
        /// </summary>
        /// <value>A <see cref="StorageConnectionString"/> object representing the development storage account.</value>
        public static StorageConnectionString DevelopmentStorageAccount
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
        /// Indicates whether this account is a development storage account.
        /// </summary>
        internal bool IsDevStoreAccount { get; set; }

        /// <summary>
        /// The storage service hostname suffix set by the user, if any.
        /// </summary>
        internal string EndpointSuffix { get; set; }

        /// <summary>
        /// The connection string parsed into settings.
        /// </summary>
        internal IDictionary<string, string> Settings { get; set; }

        /// <summary>
        /// True if the user used a constructor that auto-generates endpoints.
        /// </summary>
        internal bool DefaultEndpoints { get; set; }

        /// <summary>
        /// Gets the primary endpoint for the Blob service, as configured for the storage account.
        /// </summary>
        /// <value>A <see cref="System.Uri"/> containing the primary Blob service endpoint.</value>
        public Uri BlobEndpoint => BlobStorageUri.PrimaryUri;

        /// <summary>
        /// Gets the primary endpoint for the Queue service, as configured for the storage account.
        /// </summary>
        /// <value>A <see cref="System.Uri"/> containing the primary Queue service endpoint.</value>
        public Uri QueueEndpoint => QueueStorageUri.PrimaryUri;

        /// <summary>
        /// Gets the primary endpoint for the Table service, as configured for the storage account.
        /// </summary>
        /// <value>A <see cref="System.Uri"/> containing the primary Table service endpoint.</value>
        public Uri TableEndpoint => TableStorageUri.PrimaryUri;

        /// <summary>
        /// Gets the primary endpoint for the File service, as configured for the storage account.
        /// </summary>
        /// <value>A <see cref="System.Uri"/> containing the primary File service endpoint.</value>
        public Uri FileEndpoint => FileStorageUri.PrimaryUri;

        /// <summary>
        /// Gets the endpoints for the Blob service at the primary and secondary location, as configured for the storage account.
        /// </summary>
        /// <value>A <see cref="System.Uri"/> containing the Blob service endpoints.</value>
        public (Uri PrimaryUri, Uri SecondaryUri) BlobStorageUri { get; set; }

        /// <summary>
        /// Gets the endpoints for the Queue service at the primary and secondary location, as configured for the storage account.
        /// </summary>
        /// <value>A <see cref="System.Uri"/> containing the Queue service endpoints.</value>
        public (Uri PrimaryUri, Uri SecondaryUri) QueueStorageUri { get; set; }

        /// <summary>
        /// Gets the endpoints for the Table service at the primary and secondary location, as configured for the storage account.
        /// </summary>
        /// <value>A <see cref="System.Uri"/> containing the Table service endpoints.</value>
        public (Uri PrimaryUri, Uri SecondaryUri) TableStorageUri { get; set; }

        /// <summary>
        /// Gets the endpoints for the File service at the primary and secondary location, as configured for the storage account.
        /// </summary>
        /// <value>A <see cref="System.Uri"/> containing the File service endpoints.</value>
        public (Uri PrimaryUri, Uri SecondaryUri) FileStorageUri { get; set; }

        /// <summary>
        /// Gets the credentials used to create this <see cref="StorageConnectionString"/> object.
        /// </summary>
        /// <value>A StorageCredentials object.</value>
        public object Credentials { get; set; }

        /// <summary>
        /// Private record of the account name for use in ToString(bool).
        /// </summary>
        internal string _accountName;

        /// <summary>
        /// Parses a connection string and returns a <see cref="StorageConnectionString"/> created
        /// from the connection string.
        /// </summary>
        /// <param name="connectionString">A valid connection string.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="connectionString"/> is null or empty.</exception>
        /// <exception cref="FormatException">Thrown if <paramref name="connectionString"/> is not a valid connection string.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="connectionString"/> cannot be parsed.</exception>
        /// <returns>A <see cref="StorageConnectionString"/> object constructed from the values provided in the connection string.</returns>
        public static StorageConnectionString Parse(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw Errors.ArgumentNull(nameof(connectionString));
            }

            if (ParseCore(connectionString, out StorageConnectionString ret, err => { throw Errors.InvalidFormat(err); }))
            {
                return ret;
            }

            throw Errors.ParsingConnectionStringFailed();
        }

        /// <summary>
        /// Indicates whether a connection string can be parsed to return a <see cref="StorageConnectionString"/> object.
        /// </summary>
        /// <param name="connectionString">The connection string to parse.</param>
        /// <param name="account">A <see cref="StorageConnectionString"/> object to hold the instance returned if
        /// the connection string can be parsed.</param>
        /// <returns><b>true</b> if the connection string was successfully parsed; otherwise, <b>false</b>.</returns>
        public static bool TryParse(string connectionString, out StorageConnectionString account)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                account = null;
                return false;
            }

            try
            {
                return ParseCore(connectionString, out account, err => { });
            }
            catch (Exception)
            {
                account = null;
                return false;
            }
        }

        ///// <summary>
        ///// Returns a shared access signature for the account.
        ///// </summary>
        ///// <param name="policy">A <see cref="SharedAccessAccountPolicy"/> object specifying the access policy for the shared access signature.</param>
        ///// <returns>A shared access signature, as a URI query string.</returns>
        ///// <remarks>The query string returned includes the leading question mark.</remarks>
        //public string GetSharedAccessSignature(SharedAccessAccountPolicy policy)
        //{
        //    if (!this.Credentials.IsSharedKey)
        //    {
        //        var errorMessage = String.Format(CultureInfo.CurrentCulture, SR.CannotCreateSASWithoutAccountKey);
        //        throw new InvalidOperationException(errorMessage);
        //    }

        //    StorageAccountKey accountKey = this.Credentials.Key;

        //    string signature = SharedAccessSignatureHelper.GetHash(policy, this.Credentials.AccountName, Constants.HeaderConstants.TargetStorageVersion, accountKey.KeyValue);
        //    UriQueryBuilder builder = SharedAccessSignatureHelper.GetSignature(policy, signature, accountKey.KeyName, Constants.HeaderConstants.TargetStorageVersion);
        //    return builder.ToString();
        //}

        /// <summary>
        /// Returns a <see cref="StorageConnectionString"/> with development storage credentials using the specified proxy Uri.
        /// </summary>
        /// <param name="proxyUri">The proxy endpoint to use.</param>
        /// <returns>The new <see cref="StorageConnectionString"/>.</returns>
        private static StorageConnectionString GetDevelopmentStorageAccount(Uri proxyUri)
        {
            UriBuilder builder = proxyUri != null ?
                new UriBuilder(proxyUri.Scheme, proxyUri.Host) :
                new UriBuilder("http", "127.0.0.1");

            builder.Path = Constants.ConnectionStrings.DevStoreAccountName;

            builder.Port = Constants.ConnectionStrings.BlobEndpointPortNumber;
            Uri blobEndpoint = builder.Uri;

            builder.Port = Constants.ConnectionStrings.TableEndpointPortNumber;
            Uri tableEndpoint = builder.Uri;

            builder.Port = Constants.ConnectionStrings.QueueEndpointPortNumber;
            Uri queueEndpoint = builder.Uri;

            builder.Path = Constants.ConnectionStrings.DevStoreAccountName + Constants.ConnectionStrings.SecondaryLocationAccountSuffix;

            builder.Port = Constants.ConnectionStrings.BlobEndpointPortNumber;
            Uri blobSecondaryEndpoint = builder.Uri;

            builder.Port = Constants.ConnectionStrings.QueueEndpointPortNumber;
            Uri queueSecondaryEndpoint = builder.Uri;

            builder.Port = Constants.ConnectionStrings.TableEndpointPortNumber;
            Uri tableSecondaryEndpoint = builder.Uri;

            var credentials = new StorageSharedKeyCredential(Constants.ConnectionStrings.DevStoreAccountName, Constants.ConnectionStrings.DevStoreAccountKey);
#pragma warning disable IDE0017 // Simplify object initialization
            var account = new StorageConnectionString(
                credentials,
                blobStorageUri: (blobEndpoint, blobSecondaryEndpoint),
                queueStorageUri: (queueEndpoint, queueSecondaryEndpoint),
                tableStorageUri: (tableEndpoint, tableSecondaryEndpoint),
                fileStorageUri: (default, default) /* fileStorageUri */);
#pragma warning restore IDE0017 // Simplify object initialization

#pragma warning disable IDE0028 // Simplify collection initialization
            account.Settings = new Dictionary<string, string>();
#pragma warning restore IDE0028 // Simplify collection initialization
            account.Settings.Add(Constants.ConnectionStrings.UseDevelopmentSetting, "true");
            if (proxyUri != null)
            {
                account.Settings.Add(Constants.ConnectionStrings.DevelopmentProxyUriSetting, proxyUri.ToString());
            }

            account.IsDevStoreAccount = true;

            return account;
        }

        /// <summary>
        /// Internal implementation of Parse/TryParse.
        /// </summary>
        /// <param name="connectionString">The string to parse.</param>
        /// <param name="accountInformation">The <see cref="StorageConnectionString"/> to return.</param>
        /// <param name="error">A callback for reporting errors.</param>
        /// <returns>If true, the parse was successful. Otherwise, false.</returns>
        internal static bool ParseCore(string connectionString, out StorageConnectionString accountInformation, Action<string> error)
        {
            IDictionary<string, string> settings = ParseStringIntoSettings(connectionString, error);

            // malformed settings string

            if (settings == null)
            {
                accountInformation = null;

                return false;
            }

            // helper method

            string settingOrDefault(string key)
            {
                settings.TryGetValue(key, out var result);

                return result;
            }

            // devstore case

            if (MatchesSpecification(
                settings,
                AllRequired(s_useDevelopmentStorageSetting),
                Optional(s_developmentStorageProxyUriSetting)))
            {
                accountInformation =
                    settings.TryGetValue(Constants.ConnectionStrings.DevelopmentProxyUriSetting, out var proxyUri)
                    ? GetDevelopmentStorageAccount(new Uri(proxyUri))
                    : DevelopmentStorageAccount;

                accountInformation.Settings = s_validCredentials(settings);

                return true;
            }

            // non-devstore case

            ConnectionStringFilter endpointsOptional =
                Optional(
                    s_blobEndpointSetting, s_blobSecondaryEndpointSetting,
                    s_queueEndpointSetting, s_queueSecondaryEndpointSetting,
                    s_fileEndpointSetting, s_fileSecondaryEndpointSetting,
                    s_tableEndpointSetting, s_tableSecondaryEndpointSetting // not supported but we don't want default connection string from portal to fail
                    );

            ConnectionStringFilter primaryEndpointRequired =
                AtLeastOne(
                    s_blobEndpointSetting,
                    s_queueEndpointSetting,
                    s_fileEndpointSetting,
                    s_tableEndpointSetting
                    );

            ConnectionStringFilter secondaryEndpointsOptional =
                Optional(
                    s_blobSecondaryEndpointSetting,
                    s_queueSecondaryEndpointSetting,
                    s_fileSecondaryEndpointSetting,
                    s_tableSecondaryEndpointSetting
                    );

            ConnectionStringFilter automaticEndpointsMatchSpec =
                MatchesExactly(MatchesAll(
                    MatchesOne(
                        MatchesAll(AllRequired(s_accountKeySetting), Optional(s_accountKeyNameSetting)), // Key + Name, Endpoints optional
                        AllRequired(s_sharedAccessSignatureSetting) // SAS + Name, Endpoints optional
                    ),
                    AllRequired(s_accountNameSetting), // Name required to automatically create URIs
                    endpointsOptional,
                    Optional(s_defaultEndpointsProtocolSetting, s_endpointSuffixSetting)
                    ));

            ConnectionStringFilter explicitEndpointsMatchSpec =
                MatchesExactly(MatchesAll( // Any Credentials, Endpoints must be explicitly declared
                    s_validCredentials,
                    primaryEndpointRequired,
                    secondaryEndpointsOptional
                    ));

            var matchesAutomaticEndpointsSpec = MatchesSpecification(settings, automaticEndpointsMatchSpec);
            var matchesExplicitEndpointsSpec = MatchesSpecification(settings, explicitEndpointsMatchSpec);

            if (matchesAutomaticEndpointsSpec || matchesExplicitEndpointsSpec)
            {
                if (matchesAutomaticEndpointsSpec && !settings.ContainsKey(Constants.ConnectionStrings.DefaultEndpointsProtocolSetting))
                {
                    settings.Add(Constants.ConnectionStrings.DefaultEndpointsProtocolSetting, "https");
                }

                var blobEndpoint = settingOrDefault(Constants.ConnectionStrings.BlobEndpointSetting);
                var queueEndpoint = settingOrDefault(Constants.ConnectionStrings.QueueEndpointSetting);
                var tableEndpoint = settingOrDefault(Constants.ConnectionStrings.TableEndpointSetting);
                var fileEndpoint = settingOrDefault(Constants.ConnectionStrings.FileEndpointSetting);
                var blobSecondaryEndpoint = settingOrDefault(Constants.ConnectionStrings.BlobSecondaryEndpointSetting);
                var queueSecondaryEndpoint = settingOrDefault(Constants.ConnectionStrings.QueueSecondaryEndpointSetting);
                var tableSecondaryEndpoint = settingOrDefault(Constants.ConnectionStrings.TableSecondaryEndpointSetting);
                var fileSecondaryEndpoint = settingOrDefault(Constants.ConnectionStrings.FileSecondaryEndpointSetting);
                var sasToken = settingOrDefault(Constants.ConnectionStrings.SharedAccessSignatureSetting);

                // if secondary is specified, primary must also be specified

                static bool s_isValidEndpointPair(string primary, string secondary) =>
                        !string.IsNullOrWhiteSpace(primary)
                        || /* primary is null, and... */ string.IsNullOrWhiteSpace(secondary);

                (Uri, Uri) createStorageUri(string primary, string secondary, string sasToken, Func<IDictionary<string, string>, (Uri, Uri)> factory)
                {
                    return
                        !string.IsNullOrWhiteSpace(secondary) && !string.IsNullOrWhiteSpace(primary)
                            ? (CreateUri(primary, sasToken), CreateUri(secondary, sasToken))
                        : !string.IsNullOrWhiteSpace(primary)
                            ? (CreateUri(primary, sasToken), default)
                        : matchesAutomaticEndpointsSpec && factory != null
                            ? factory(settings)
                        : (default, default);

                    static Uri CreateUri(string endpoint, string sasToken)
                    {
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

                if (
                    s_isValidEndpointPair(blobEndpoint, blobSecondaryEndpoint)
                    && s_isValidEndpointPair(queueEndpoint, queueSecondaryEndpoint)
                    && s_isValidEndpointPair(tableEndpoint, tableSecondaryEndpoint)
                    && s_isValidEndpointPair(fileEndpoint, fileSecondaryEndpoint)
                    )
                {
                    accountInformation =
                        new StorageConnectionString(
                            GetCredentials(settings),
                            blobStorageUri: createStorageUri(blobEndpoint, blobSecondaryEndpoint, sasToken, ConstructBlobEndpoint),
                            queueStorageUri: createStorageUri(queueEndpoint, queueSecondaryEndpoint, sasToken, ConstructQueueEndpoint),
                            tableStorageUri: createStorageUri(tableEndpoint, tableSecondaryEndpoint, sasToken, ConstructTableEndpoint),
                            fileStorageUri: createStorageUri(fileEndpoint, fileSecondaryEndpoint, sasToken, ConstructFileEndpoint)
                            )
                        {
                            EndpointSuffix = settingOrDefault(Constants.ConnectionStrings.EndpointSuffixSetting),
                            Settings = s_validCredentials(settings)
                        };

                    accountInformation._accountName = settingOrDefault(Constants.ConnectionStrings.AccountNameSetting);

                    return true;
                }
            }

            // not valid
            accountInformation = null;

            error("No valid combination of account information found.");

            return false;
        }

        /// <summary>
        /// Tokenizes input and stores name value pairs.
        /// </summary>
        /// <param name="connectionString">The string to parse.</param>
        /// <param name="error">Error reporting delegate.</param>
        /// <returns>Tokenized collection.</returns>
        private static IDictionary<string, string> ParseStringIntoSettings(string connectionString, Action<string> error)
        {
            IDictionary<string, string> settings = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            var splitted = connectionString.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var nameValue in splitted)
            {
                var splittedNameValue = nameValue.Split(new char[] { '=' }, 2);

                if (splittedNameValue.Length != 2)
                {
                    error("Settings must be of the form \"name=value\".");
                    return null;
                }

                if (settings.ContainsKey(splittedNameValue[0]))
                {
                    error(string.Format(CultureInfo.InvariantCulture, "Duplicate setting '{0}' found.", splittedNameValue[0]));
                    return null;
                }

                settings.Add(splittedNameValue[0], splittedNameValue[1]);
            }

            return settings;
        }

        /// <summary>
        /// Encapsulates a validation rule for an enumeration based account setting.
        /// </summary>
        /// <param name="name">The name of the setting.</param>
        /// <param name="validValues">A list of valid values for the setting.</param>
        /// <returns>An <see cref="AccountSetting"/> representing the enumeration constraint.</returns>
        private static AccountSetting Setting(string name, params string[] validValues) =>
            new AccountSetting(
                name,
                (settingValue) => validValues.Length == 0 ? true : validValues.Contains(settingValue, StringComparer.OrdinalIgnoreCase)
                );

        /// <summary>
        /// Encapsulates a validation rule using a func.
        /// </summary>
        /// <param name="name">The name of the setting.</param>
        /// <param name="isValid">A func that determines if the value is valid.</param>
        /// <returns>An <see cref="AccountSetting"/> representing the constraint.</returns>
        private static AccountSetting Setting(string name, Func<string, bool> isValid) => new AccountSetting(name, isValid);

        /// <summary>
        /// Determines whether the specified setting value is a valid base64 string.
        /// </summary>
        /// <param name="settingValue">The setting value.</param>
        /// <returns><c>true</c> if the specified setting value is a valid base64 string; otherwise, <c>false</c>.</returns>
        private static bool IsValidBase64String(string settingValue)
        {
            try
            {
                Convert.FromBase64String(settingValue);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        /// <summary>
        /// Validation function that validates Uris.
        /// </summary>
        /// <param name="settingValue">Value to validate.</param>
        /// <returns><c>true</c> if the specified setting value is a valid Uri; otherwise, <c>false</c>.</returns>
        private static bool IsValidUri(string settingValue) => Uri.IsWellFormedUriString(settingValue, UriKind.Absolute);

        /// <summary>
        /// Validation function that validates a domain name.
        /// </summary>
        /// <param name="settingValue">Value to validate.</param>
        /// <returns><c>true</c> if the specified setting value is a valid domain; otherwise, <c>false</c>.</returns>
        private static bool IsValidDomain(string settingValue) => Uri.CheckHostName(settingValue).Equals(UriHostNameType.Dns);

        /// <summary>
        /// Settings filter that requires all specified settings be present and valid.
        /// </summary>
        /// <param name="requiredSettings">A list of settings that must be present.</param>
        /// <returns>The remaining settings or <c>null</c> if the filter's requirement is not satisfied.</returns>
        private static ConnectionStringFilter AllRequired(params AccountSetting[] requiredSettings) =>
            (settings) =>
            {
                IDictionary<string, string> result = new Dictionary<string, string>(settings, StringComparer.OrdinalIgnoreCase);

                foreach (AccountSetting requirement in requiredSettings)
                {
                    if (result.TryGetValue(requirement.Key, out var value) && requirement.Value(value))
                    {
                        result.Remove(requirement.Key);
                    }
                    else
                    {
                        return null;
                    }
                }

                return result;
            };

        /// <summary>
        /// Settings filter that removes optional values.
        /// </summary>
        /// <param name="optionalSettings">A list of settings that are optional.</param>
        /// <returns>The remaining settings or <c>null</c> if the filter's requirement is not satisfied.</returns>
        private static ConnectionStringFilter Optional(params AccountSetting[] optionalSettings) =>
            (settings) =>
            {
                IDictionary<string, string> result = new Dictionary<string, string>(settings, StringComparer.OrdinalIgnoreCase);

                foreach (AccountSetting requirement in optionalSettings)
                {
                    if (result.TryGetValue(requirement.Key, out var value) && requirement.Value(value))
                    {
                        result.Remove(requirement.Key);
                    }
                }

                return result;
            };

        /// <summary>
        /// Settings filter that ensures that at least one setting is present.
        /// </summary>
        /// <param name="atLeastOneSettings">A list of settings of which one must be present.</param>
        /// <returns>The remaining settings or <c>null</c> if the filter's requirement is not satisfied.</returns>
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed.")]
        private static ConnectionStringFilter AtLeastOne(params AccountSetting[] atLeastOneSettings) =>
            (settings) =>
            {
                IDictionary<string, string> result = new Dictionary<string, string>(settings, StringComparer.OrdinalIgnoreCase);
                var foundOne = false;

                foreach (AccountSetting requirement in atLeastOneSettings)
                {
                    if (result.TryGetValue(requirement.Key, out var value) && requirement.Value(value))
                    {
                        result.Remove(requirement.Key);
                        foundOne = true;
                    }
                }

                return foundOne ? result : null;
            };

        /// <summary>
        /// Settings filter that ensures that none of the specified settings are present.
        /// </summary>
        /// <param name="atLeastOneSettings">A list of settings of which one must not be present.</param>
        /// <returns>The remaining settings or <c>null</c> if the filter's requirement is not satisfied.</returns>
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed.")]
        private static ConnectionStringFilter None(params AccountSetting[] atLeastOneSettings) =>
            (settings) =>
            {
                IDictionary<string, string> result = new Dictionary<string, string>(settings, StringComparer.OrdinalIgnoreCase);
                var foundOne = false;

                foreach (AccountSetting requirement in atLeastOneSettings)
                {
                    if (result.TryGetValue(requirement.Key, out var value) && requirement.Value(value))
                    {
                        foundOne = true;
                    }
                }

                return foundOne ? null : result;
            };

        /// <summary>
        /// Settings filter that ensures that all of the specified filters match.
        /// </summary>
        /// <param name="filters">A list of filters of which all must match.</param>
        /// <returns>The remaining settings or <c>null</c> if the filter's requirement is not satisfied.</returns>
        private static ConnectionStringFilter MatchesAll(params ConnectionStringFilter[] filters) =>
            (settings) =>
            {
                IDictionary<string, string> result = new Dictionary<string, string>(settings, StringComparer.OrdinalIgnoreCase);

                foreach (ConnectionStringFilter filter in filters)
                {
                    if (result == null)
                    {
                        break;
                    }

                    result = filter(result);
                }

                return result;
            };

        /// <summary>
        /// Settings filter that ensures that exactly one filter matches.
        /// </summary>
        /// <param name="filters">A list of filters of which exactly one must match.</param>
        /// <returns>The remaining settings or <c>null</c> if the filter's requirement is not satisfied.</returns>
        private static ConnectionStringFilter MatchesOne(params ConnectionStringFilter[] filters) =>
            (settings) =>
            {
                IDictionary<string, string>[] results =
                    filters
                    .Select(filter => filter(new Dictionary<string, string>(settings)))
                    .Where(result => result != null)
                    .Take(2)
                    .ToArray();

                return results.Length != 1 ? null : results.First();
            };

        /// <summary>
        /// Settings filter that ensures that the specified filter is an exact match.
        /// </summary>
        /// <param name="filter">A list of filters of which ensures that the specified filter is an exact match.</param>
        /// <returns>The remaining settings or <c>null</c> if the filter's requirement is not satisfied.</returns>
        private static ConnectionStringFilter MatchesExactly(ConnectionStringFilter filter) =>
            (settings) =>
            {
                IDictionary<string, string> results = filter(settings);

                return results == null || results.Any() ? null : results;
            };

        /// <summary>
        /// Settings filter that ensures that a valid combination of credentials is present.
        /// </summary>
        /// <returns>The remaining settings or <c>null</c> if the filter's requirement is not satisfied.</returns>
        private static readonly ConnectionStringFilter s_validCredentials =
            MatchesOne(
                MatchesAll(AllRequired(s_accountNameSetting, s_accountKeySetting), Optional(s_accountKeyNameSetting), None(s_sharedAccessSignatureSetting)),    // AccountAndKey
                MatchesAll(AllRequired(s_sharedAccessSignatureSetting), Optional(s_accountNameSetting), None(s_accountKeySetting, s_accountKeyNameSetting)),    // SharedAccessSignature (AccountName optional)
                None(s_accountNameSetting, s_accountKeySetting, s_accountKeyNameSetting, s_sharedAccessSignatureSetting)                                        // Anonymous
            );

        /// <summary>
        /// Tests to see if a given list of settings matches a set of filters exactly.
        /// </summary>
        /// <param name="settings">The settings to check.</param>
        /// <param name="constraints">A list of filters to check.</param>
        /// <returns>
        /// If any filter returns null, false.
        /// If there are any settings left over after all filters are processed, false.
        /// Otherwise true.
        /// </returns>
        private static bool MatchesSpecification(
            IDictionary<string, string> settings,
            params ConnectionStringFilter[] constraints)
        {
            foreach (ConnectionStringFilter constraint in constraints)
            {
                IDictionary<string, string> remainingSettings = constraint(settings);

                if (remainingSettings == null)
                {
                    return false;
                }
                else
                {
                    settings = remainingSettings;
                }
            }

            return !settings.Any();
        }

        /// <summary>
        /// Gets a StorageCredentials object corresponding to whatever credentials are supplied in the given settings.
        /// </summary>
        /// <param name="settings">The settings to check.</param>
        /// <returns>The StorageCredentials object specified in the settings.</returns>
        private static object GetCredentials(IDictionary<string, string> settings)
        {
            settings.TryGetValue(Constants.ConnectionStrings.AccountNameSetting, out var accountName);
            settings.TryGetValue(Constants.ConnectionStrings.AccountKeySetting, out var accountKey);
            settings.TryGetValue(Constants.ConnectionStrings.SharedAccessSignatureSetting, out var sharedAccessSignature);

            // The accountKeyName isn't used
            //settings.TryGetValue(Constants.ConnectionStrings.AccountKeyNameSetting, out var accountKeyName);

            return
                accountName != null && accountKey != null && sharedAccessSignature == null
                ? new StorageSharedKeyCredential(accountName, accountKey/*, accountKeyName */)
                : (object)(accountKey == null /* && accountKeyName == null */ && sharedAccessSignature != null
                    ? new SharedAccessSignatureCredentials(sharedAccessSignature)
                    : null);
        }

        /// <summary>
        /// Gets the default blob endpoint using specified settings.
        /// </summary>
        /// <param name="settings">The settings to use.</param>
        /// <returns>The default blob endpoint.</returns>
        private static (Uri, Uri) ConstructBlobEndpoint(IDictionary<string, string> settings) => ConstructBlobEndpoint(
                settings[Constants.ConnectionStrings.DefaultEndpointsProtocolSetting],
                settings[Constants.ConnectionStrings.AccountNameSetting],
                settings.ContainsKey(Constants.ConnectionStrings.EndpointSuffixSetting) ? settings[Constants.ConnectionStrings.EndpointSuffixSetting] : null,
                settings.ContainsKey(Constants.ConnectionStrings.SharedAccessSignatureSetting) ? settings[Constants.ConnectionStrings.SharedAccessSignatureSetting] : null);

        /// <summary>
        /// Gets the default blob endpoint using the specified protocol and account name.
        /// </summary>
        /// <param name="scheme">The protocol to use.</param>
        /// <param name="accountName">The name of the storage account.</param>
        /// <param name="endpointSuffix">The Endpoint DNS suffix; use <c>null</c> for default.</param>
        /// <param name="sasToken">The sas token; use <c>null</c> for default.</param>
        /// <returns>The default blob endpoint.</returns>
        internal static (Uri, Uri) ConstructBlobEndpoint(string scheme, string accountName, string endpointSuffix, string sasToken)
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
                endpointSuffix = Constants.ConnectionStrings.DefaultEndpointSuffix;
            }

            return ConstructUris(scheme, accountName, Constants.ConnectionStrings.DefaultBlobHostnamePrefix, endpointSuffix, sasToken);
        }

        /// <summary>
        /// Gets the default file endpoint using specified settings.
        /// </summary>
        /// <param name="settings">The settings to use.</param>
        /// <returns>The default file endpoint.</returns>
        private static (Uri, Uri) ConstructFileEndpoint(IDictionary<string, string> settings) => ConstructFileEndpoint(
                settings[Constants.ConnectionStrings.DefaultEndpointsProtocolSetting],
                settings[Constants.ConnectionStrings.AccountNameSetting],
                settings.ContainsKey(Constants.ConnectionStrings.EndpointSuffixSetting) ? settings[Constants.ConnectionStrings.EndpointSuffixSetting] : null,
                settings.ContainsKey(Constants.ConnectionStrings.SharedAccessSignatureSetting) ? settings[Constants.ConnectionStrings.SharedAccessSignatureSetting] : null);

        /// <summary>
        /// Gets the default file endpoint using the specified protocol and account name.
        /// </summary>
        /// <param name="scheme">The protocol to use.</param>
        /// <param name="accountName">The name of the storage account.</param>
        /// <param name="endpointSuffix">The Endpoint DNS suffix; use <c>null</c> for default.</param>
        /// <param name="sasToken">The sas token; use <c>null</c> for default.</param>
        /// <returns>The default file endpoint.</returns>
        internal static (Uri, Uri) ConstructFileEndpoint(string scheme, string accountName, string endpointSuffix, string sasToken)
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
                endpointSuffix = Constants.ConnectionStrings.DefaultEndpointSuffix;
            }

            return ConstructUris(scheme, accountName, Constants.ConnectionStrings.DefaultFileHostnamePrefix, endpointSuffix, sasToken);
        }

        /// <summary>
        /// Gets the default queue endpoint using the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>The default queue endpoint.</returns>
        private static (Uri, Uri) ConstructQueueEndpoint(IDictionary<string, string> settings) => ConstructQueueEndpoint(
                settings[Constants.ConnectionStrings.DefaultEndpointsProtocolSetting],
                settings[Constants.ConnectionStrings.AccountNameSetting],
                settings.ContainsKey(Constants.ConnectionStrings.EndpointSuffixSetting) ? settings[Constants.ConnectionStrings.EndpointSuffixSetting] : null,
                settings.ContainsKey(Constants.ConnectionStrings.SharedAccessSignatureSetting) ? settings[Constants.ConnectionStrings.SharedAccessSignatureSetting] : null);

        /// <summary>
        /// Gets the default queue endpoint using the specified protocol and account name.
        /// </summary>
        /// <param name="scheme">The protocol to use.</param>
        /// <param name="accountName">The name of the storage account.</param>
        /// <param name="endpointSuffix">The Endpoint DNS suffix; use <c>null</c> for default.</param>
        /// <param name="sasToken">The sas token; use <c>null</c> for default.</param>
        /// <returns>The default queue endpoint.</returns>
        internal static (Uri, Uri) ConstructQueueEndpoint(string scheme, string accountName, string endpointSuffix, string sasToken)
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
                endpointSuffix = Constants.ConnectionStrings.DefaultEndpointSuffix;
            }

            return ConstructUris(scheme, accountName, Constants.ConnectionStrings.DefaultQueueHostnamePrefix, endpointSuffix, sasToken);
        }

        /// <summary>
        /// Gets the default table endpoint using the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>The default table endpoint.</returns>
        private static (Uri, Uri) ConstructTableEndpoint(IDictionary<string, string> settings) => ConstructTableEndpoint(
                settings[Constants.ConnectionStrings.DefaultEndpointsProtocolSetting],
                settings[Constants.ConnectionStrings.AccountNameSetting],
                settings.ContainsKey(Constants.ConnectionStrings.EndpointSuffixSetting) ? settings[Constants.ConnectionStrings.EndpointSuffixSetting] : null,
                settings.ContainsKey(Constants.ConnectionStrings.SharedAccessSignatureSetting) ? settings[Constants.ConnectionStrings.SharedAccessSignatureSetting] : null);

        /// <summary>
        /// Gets the default queue endpoint using the specified protocol and account name.
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
                endpointSuffix = Constants.ConnectionStrings.DefaultEndpointSuffix;
            }

            return ConstructUris(scheme, accountName, Constants.ConnectionStrings.DefaultTableHostnamePrefix, endpointSuffix, sasToken);
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
                        Constants.ConnectionStrings.SecondaryLocationAccountSuffix,
                        hostNamePrefix,
                        endpointSuffix),
                Query = sasToken
            };

            return (primaryUriBuilder.Uri, secondaryUriBuilder.Uri);
        }
    }
}
