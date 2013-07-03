// -----------------------------------------------------------------------------------------
// <copyright file="CloudStorageAccount.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage
{
    using Microsoft.WindowsAzure.Storage.Auth;
    using Microsoft.WindowsAzure.Storage.Blob;
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Queue;
    using Microsoft.WindowsAzure.Storage.Table;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using AccountSetting = System.Collections.Generic.KeyValuePair<string, System.Func<string, bool>>;

    /// <summary>
    /// Represents a Windows Azure Storage account.
    /// </summary>
    public sealed class CloudStorageAccount
    {
        /// <summary>
        /// The FISMA compliance default value.
        /// </summary>
        private static bool version1MD5 = true;

        /// <summary>
        /// Gets or sets a value indicating whether the FISMA MD5 setting will be used.
        /// </summary>
        /// <value><c>false</c> to use the FISMA MD5 setting; <c>true</c> to use the .NET default implementation.</value>
#if WINDOWS_PHONE
        internal
#else
        public 
#endif 
            static bool UseV1MD5
        {
            get { return version1MD5; }
            set { version1MD5 = value; }
        }

        /// <summary>
        /// The setting name for using the development storage.
        /// </summary>
        internal const string UseDevelopmentStorageSettingString = "UseDevelopmentStorage";

        /// <summary>
        /// The setting name for specifying a development storage proxy Uri.
        /// </summary>
        internal const string DevelopmentStorageProxyUriSettingString = "DevelopmentStorageProxyUri";

        /// <summary>
        /// The setting name for using the default storage endpoints with the specified protocol.
        /// </summary>
        internal const string DefaultEndpointsProtocolSettingString = "DefaultEndpointsProtocol";

        /// <summary>
        /// The setting name for the account name.
        /// </summary>
        internal const string AccountNameSettingString = "AccountName";

        /// <summary>
        /// The setting name for the account key name.
        /// </summary>
        internal const string AccountKeyNameSettingString = "AccountKeyName";

        /// <summary>
        /// The setting name for the account key.
        /// </summary>
        internal const string AccountKeySettingString = "AccountKey";

        /// <summary>
        /// The setting name for a custom blob storage endpoint.
        /// </summary>
        internal const string BlobEndpointSettingString = "BlobEndpoint";

        /// <summary>
        /// The setting name for a custom queue endpoint.
        /// </summary>
        internal const string QueueEndpointSettingString = "QueueEndpoint";

        /// <summary>
        /// The setting name for a custom table storage endpoint.
        /// </summary>
        internal const string TableEndpointSettingString = "TableEndpoint";

        /// <summary>
        /// The setting name for a custom storage endpoint suffix.
        /// </summary>
        internal const string EndpointSuffixSettingString = "EndpointSuffix";

        /// <summary>
        /// The setting name for a shared access key.
        /// </summary>
        internal const string SharedAccessSignatureSettingString = "SharedAccessSignature";

        /// <summary>
        /// The default account name for the development storage.
        /// </summary>
        private const string DevstoreAccountName = "devstoreaccount1";

        /// <summary>
        /// The default account key for the development storage.
        /// </summary>
        private const string DevstoreAccountKey = "Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==";

        /// <summary>
        /// The credentials string used to test for the development storage credentials.
        /// </summary>
        private const string DevstoreCredentialInString =
            CloudStorageAccount.AccountNameSettingString + "=" + DevstoreAccountName + ";" +
            CloudStorageAccount.AccountKeySettingString + "=" + DevstoreAccountKey;

        /// <summary>
        /// The default storage service hostname suffix.
        /// </summary>
        private const string DefaultEndpointSuffix = "core.windows.net";

        /// <summary>
        /// The default blob storage DNS hostname prefix.
        /// </summary>
        private const string DefaultBlobHostnamePrefix = "blob";

        /// <summary>
        /// The root queue DNS name prefix.
        /// </summary>
        private const string DefaultQueueHostnamePrefix = "queue";

        /// <summary>
        /// The root table storage DNS name prefix.
        /// </summary>
        private const string DefaultTableHostnamePrefix = "table";

        /// <summary>
        /// Validator for the UseDevelopmentStorage setting. Must be "true".
        /// </summary>
        private static readonly AccountSetting UseDevelopmentStorageSetting = Setting(UseDevelopmentStorageSettingString, "true");

        /// <summary>
        /// Validator for the DevelopmentStorageProxyUri setting. Must be a valid Uri.
        /// </summary>
        private static readonly AccountSetting DevelopmentStorageProxyUriSetting = Setting(DevelopmentStorageProxyUriSettingString, IsValidUri);

        /// <summary>
        /// Validator for the DefaultEndpointsProtocol setting. Must be either "http" or "https".
        /// </summary>
        private static readonly AccountSetting DefaultEndpointsProtocolSetting = Setting(DefaultEndpointsProtocolSettingString, "http", "https");

        /// <summary>
        /// Validator for the AccountName setting. No restrictions.
        /// </summary>
        private static readonly AccountSetting AccountNameSetting = Setting(AccountNameSettingString);

        /// <summary>
        /// Validator for the AccountKey setting. No restrictions.
        /// </summary>
        private static readonly AccountSetting AccountKeyNameSetting = Setting(AccountKeyNameSettingString);

        /// <summary>
        /// Validator for the AccountKey setting. Must be a valid base64 string.
        /// </summary>
        private static readonly AccountSetting AccountKeySetting = Setting(AccountKeySettingString, IsValidBase64String);

        /// <summary>
        /// Validator for the BlobEndpoint setting. Must be a valid Uri.
        /// </summary>
        private static readonly AccountSetting BlobEndpointSetting = Setting(BlobEndpointSettingString, IsValidUri);

        /// <summary>
        /// Validator for the QueueEndpoint setting. Must be a valid Uri.
        /// </summary>
        private static readonly AccountSetting QueueEndpointSetting = Setting(QueueEndpointSettingString, IsValidUri);

        /// <summary>
        /// Validator for the TableEndpoint setting. Must be a valid Uri.
        /// </summary>
        private static readonly AccountSetting TableEndpointSetting = Setting(TableEndpointSettingString, IsValidUri);

        /// <summary>
        /// Validator for the EndpointSuffix setting. Must be a valid Uri.
        /// </summary>
        private static readonly AccountSetting EndpointSuffixSetting = Setting(EndpointSuffixSettingString, IsValidDomain);

        /// <summary>
        /// Validator for the SharedAccessSignature setting. No restrictions.
        /// </summary>
        private static readonly AccountSetting SharedAccessSignatureSetting = Setting(SharedAccessSignatureSettingString);

        /// <summary>
        /// Singleton instance for the development storage account.
        /// </summary>
        private static CloudStorageAccount devStoreAccount;

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudStorageAccount"/> class using the specified
        /// account credentials and service endpoints.
        /// </summary>
        /// <param name="storageCredentials">The account credentials.</param>
        /// <param name="blobEndpoint">The Blob service endpoint.</param>
        /// <param name="queueEndpoint">The Queue service endpoint.</param>
        /// <param name="tableEndpoint">The Table service endpoint.</param>
        public CloudStorageAccount(StorageCredentials storageCredentials, Uri blobEndpoint, Uri queueEndpoint, Uri tableEndpoint)
        {
            this.Credentials = storageCredentials;
            this.BlobEndpoint = blobEndpoint;
            this.QueueEndpoint = queueEndpoint;
            this.TableEndpoint = tableEndpoint;
            this.DefaultEndpoints = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudStorageAccount"/> class using the specified
        /// account credentials and the default service endpoints. 
        /// </summary>
        /// <param name="storageCredentials">An object of type <see cref="StorageCredentials"/> that 
        /// specifies the account name and account key for the storage account.</param>
        /// <param name="useHttps"><c>True</c> to use HTTPS to connect to storage service endpoints; otherwise, <c>false</c>.</param>
        public CloudStorageAccount(StorageCredentials storageCredentials, bool useHttps)
            : this(storageCredentials, null /* endpointSuffix */, useHttps)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudStorageAccount"/> class using the specified
        /// account credentials and the default service endpoints. 
        /// </summary>
        /// <param name="storageCredentials">An object of type <see cref="StorageCredentials"/> that 
        /// specifies the account name and account key for the storage account.</param>
        /// <param name="endpointSuffix">The DNS endpoint suffix for all storage services, e.g. "core.windows.net".</param>
        /// <param name="useHttps"><c>True</c> to use HTTPS to connect to storage service endpoints; otherwise, <c>false</c>.</param>
        public CloudStorageAccount(StorageCredentials storageCredentials, string endpointSuffix, bool useHttps)
        {
            CommonUtility.AssertNotNull("storageCredentials", storageCredentials);

            string protocol = useHttps ? "https" : "http";
            this.BlobEndpoint = new Uri(ConstructBlobEndpoint(protocol, storageCredentials.AccountName, endpointSuffix));
            this.QueueEndpoint = new Uri(ConstructQueueEndpoint(protocol, storageCredentials.AccountName, endpointSuffix));
            this.TableEndpoint = new Uri(ConstructTableEndpoint(protocol, storageCredentials.AccountName, endpointSuffix));
            this.Credentials = storageCredentials;
            this.EndpointSuffix = endpointSuffix;
            this.DefaultEndpoints = true;
        }

        /// <summary>
        /// Gets a <see cref="CloudStorageAccount"/> object that references the development storage account.
        /// </summary>
        /// <value>A reference to the development storage account.</value>
        public static CloudStorageAccount DevelopmentStorageAccount
        {
            get
            {
                if (devStoreAccount == null)
                {
                    devStoreAccount = GetDevelopmentStorageAccount(null);
                }

                return devStoreAccount;
            }
        }

        /// <summary>
        /// The storage service hostname suffix set by the user, if any.
        /// </summary>
        private string EndpointSuffix { get; set; }

        /// <summary>
        /// The connection string parsed into settings.
        /// </summary>
        private IDictionary<string, string> Settings { get; set; }

        /// <summary>
        /// True if the user used a constructor that auto-generates endpoints.
        /// </summary>
        private bool DefaultEndpoints { get; set; }

        /// <summary>
        /// Gets the endpoint for the Blob service, as configured for the storage account.
        /// </summary>
        /// <value>The Blob service endpoint.</value>
        public Uri BlobEndpoint { get; private set; }

        /// <summary>
        /// Gets the endpoint for the Queue service, as configured for the storage account.
        /// </summary>
        /// <value>The Queue service endpoint.</value>
        public Uri QueueEndpoint { get; private set; }

        /// <summary>
        /// Gets the endpoint for the Table service, as configured for the storage account.
        /// </summary>
        /// <value>The Table service endpoint.</value>
        public Uri TableEndpoint { get; private set; }

        /// <summary>
        /// Gets the credentials used to create this <see cref="CloudStorageAccount"/> object.
        /// </summary>
        /// <value>The credentials used to create the <see cref="CloudStorageAccount"/> object.</value>
        public StorageCredentials Credentials { get; private set; }

        /// <summary>
        /// Parses a connection string and returns a <see cref="CloudStorageAccount"/> created
        /// from the connection string.
        /// </summary>
        /// <param name="connectionString">A valid connection string.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="connectionString"/> is null or empty.</exception>
        /// <exception cref="FormatException">Thrown if <paramref name="connectionString"/> is not a valid connection string.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="connectionString"/> cannot be parsed.</exception>
        /// <returns>A <see cref="CloudStorageAccount"/> object constructed from the values provided in the connection string.</returns>
        public static CloudStorageAccount Parse(string connectionString)
        {
            CloudStorageAccount ret;

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("connectionString");
            }

            if (ParseImpl(connectionString, out ret, err => { throw new FormatException(err); }))
            {
                return ret;
            }

            throw new ArgumentException(SR.ParseError);
        }

        /// <summary>
        /// Indicates whether a connection string can be parsed to return a <see cref="CloudStorageAccount"/> object.
        /// </summary>
        /// <param name="connectionString">The connection string to parse.</param>
        /// <param name="account">A <see cref="CloudStorageAccount"/> object to hold the instance returned if
        /// the connection string can be parsed.</param>
        /// <returns><b>true</b> if the connection string was successfully parsed; otherwise, <b>false</b>.</returns>
        public static bool TryParse(string connectionString, out CloudStorageAccount account)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                account = null;
                return false;
            }

            try
            {
                return ParseImpl(connectionString, out account, err => { });
            }
            catch (Exception)
            {
                account = null;
                return false;
            }
        }

        /// <summary>
        /// Creates the Table service client.
        /// </summary>
        /// <returns>A client object that specifies the Table service endpoint.</returns>
        public CloudTableClient CreateCloudTableClient()
        {
            if (this.TableEndpoint == null)
            {
                throw new InvalidOperationException(SR.TableEndPointNotConfigured);
            }

            if (this.Credentials == null)
            {
                throw new InvalidOperationException(SR.MissingCredentials);
            }

            return new CloudTableClient(this.TableEndpoint, this.Credentials);
        }

        /// <summary>
        /// Creates the Queue service client.
        /// </summary>
        /// <returns>A client object that specifies the Queue service endpoint.</returns>
        public CloudQueueClient CreateCloudQueueClient()
        {
            if (this.QueueEndpoint == null)
            {
                throw new InvalidOperationException(SR.QueueEndPointNotConfigured);
            }

            if (this.Credentials == null)
            {
                throw new InvalidOperationException(SR.MissingCredentials);
            }

            return new CloudQueueClient(this.QueueEndpoint, this.Credentials);
        }

        /// <summary>
        /// Creates the Blob service client.
        /// </summary>
        /// <returns>A client object that specifies the Blob service endpoint.</returns>
        public CloudBlobClient CreateCloudBlobClient()
        {
            if (this.BlobEndpoint == null)
            {
                throw new InvalidOperationException(SR.BlobEndPointNotConfigured);
            }

            if (this.Credentials == null)
            {
                throw new InvalidOperationException(SR.MissingCredentials);
            }

            return new CloudBlobClient(this.BlobEndpoint, this.Credentials);
        }

        /// <summary>
        /// Returns a connection string for this storage account, without sensitive data.
        /// </summary>
        /// <returns>A connection string.</returns>
        public override string ToString()
        {
            return this.ToString(false);
        }

        /// <summary>
        /// Returns a connection string for the storage account, optionally with sensitive data.
        /// </summary>
        /// <param name="exportSecrets"><c>True</c> to include sensitive data in the string; otherwise, <c>false</c>.</param>
        /// <returns>A connection string.</returns>
        public string ToString(bool exportSecrets)
        {
            if (this.Settings == null)
            {
                this.Settings = new Dictionary<string, string>();
                
                if (this.DefaultEndpoints)
                {
                    this.Settings.Add(DefaultEndpointsProtocolSettingString, this.BlobEndpoint.Scheme);

                    if (this.EndpointSuffix != null)
                    {
                        this.Settings.Add(EndpointSuffixSettingString, this.EndpointSuffix);
                    }
                }
                else
                {
                    if (this.BlobEndpoint != null)
                    {
                        this.Settings.Add(BlobEndpointSettingString, this.BlobEndpoint.ToString());
                    }

                    if (this.QueueEndpoint != null)
                    {
                        this.Settings.Add(QueueEndpointSettingString, this.QueueEndpoint.ToString());
                    }

                    if (this.TableEndpoint != null)
                    {
                        this.Settings.Add(TableEndpointSettingString, this.TableEndpoint.ToString());
                    }
                }
            }

            List<string> listOfSettings = this.Settings.Select(pair => string.Format(CultureInfo.InvariantCulture, "{0}={1}", pair.Key, pair.Value)).ToList();
            
            if ((this.Credentials != null) && (this.Credentials.ToString(true) != DevstoreCredentialInString))
            {
                listOfSettings.Add(this.Credentials.ToString(exportSecrets));
            }

            return string.Join(";", listOfSettings);
        }

        /// <summary>
        /// Returns a <see cref="CloudStorageAccount"/> with development storage credentials using the specified proxy Uri.
        /// </summary>
        /// <param name="proxyUri">The proxy endpoint to use.</param>
        /// <returns>The new <see cref="CloudStorageAccount"/>.</returns>
        private static CloudStorageAccount GetDevelopmentStorageAccount(Uri proxyUri)
        {
            UriBuilder builder = proxyUri != null ?
                new UriBuilder(proxyUri.Scheme, proxyUri.Host) :
                new UriBuilder("http", "127.0.0.1");
            
            builder.Path = DevstoreAccountName;

            builder.Port = 10000;
            Uri blobEndpoint = builder.Uri;

            builder.Port = 10001;
            Uri queueEndpoint = builder.Uri;

            builder.Port = 10002;
            Uri tableEndpoint = builder.Uri;

            StorageCredentials credentials = new StorageCredentials(DevstoreAccountName, DevstoreAccountKey);
            CloudStorageAccount account = new CloudStorageAccount(credentials, blobEndpoint, queueEndpoint, tableEndpoint);

            account.Settings = new Dictionary<string, string>();
            account.Settings.Add(UseDevelopmentStorageSettingString, "true");
            if (proxyUri != null)
            {
                account.Settings.Add(DevelopmentStorageProxyUriSettingString, proxyUri.ToString());
            }

            return account;
        }

        /// <summary>
        /// Internal implementation of Parse/TryParse.
        /// </summary>
        /// <param name="connectionString">The string to parse.</param>
        /// <param name="accountInformation">The <see cref="CloudStorageAccount"/> to return.</param>
        /// <param name="error">A callback for reporting errors.</param>
        /// <returns>If true, the parse was successful. Otherwise, false.</returns>
        internal static bool ParseImpl(string connectionString, out CloudStorageAccount accountInformation, Action<string> error)
        {
            IDictionary<string, string> settings = ParseStringIntoSettings(connectionString, error);

            // malformed settings string
            if (settings == null)
            {
                accountInformation = null;

                return false;
            }

            // devstore case
            if (MatchesSpecification(
                settings,
                AllRequired(UseDevelopmentStorageSetting),
                Optional(DevelopmentStorageProxyUriSetting)))
            {
                string proxyUri = null;
                if (settings.TryGetValue(DevelopmentStorageProxyUriSettingString, out proxyUri))
                {
                    accountInformation = GetDevelopmentStorageAccount(new Uri(proxyUri));
                }
                else
                {
                    accountInformation = DevelopmentStorageAccount;
                }

                accountInformation.Settings = ValidCredentials(settings);
                return true;
            }

            // automatic case
            if (MatchesSpecification(
                settings,
                AllRequired(DefaultEndpointsProtocolSetting, AccountNameSetting, AccountKeySetting),
                Optional(BlobEndpointSetting, QueueEndpointSetting, TableEndpointSetting, AccountKeyNameSetting, EndpointSuffixSetting)))
            {
                string blobEndpoint = null;
                settings.TryGetValue(BlobEndpointSettingString, out blobEndpoint);

                string queueEndpoint = null;
                settings.TryGetValue(QueueEndpointSettingString, out queueEndpoint);

                string tableEndpoint = null;
                settings.TryGetValue(TableEndpointSettingString, out tableEndpoint);

                accountInformation = new CloudStorageAccount(
                    GetCredentials(settings),
                    new Uri(blobEndpoint ?? ConstructBlobEndpoint(settings)),
                    new Uri(queueEndpoint ?? ConstructQueueEndpoint(settings)),
                    new Uri(tableEndpoint ?? ConstructTableEndpoint(settings)));

                string endpointSuffix = null;
                if (settings.TryGetValue(EndpointSuffixSettingString, out endpointSuffix))
                {
                    accountInformation.EndpointSuffix = endpointSuffix;
                }

                accountInformation.Settings = ValidCredentials(settings);
                return true;
            }

            // explicit case
            if (MatchesSpecification(
                settings,
                AtLeastOne(BlobEndpointSetting, QueueEndpointSetting, TableEndpointSetting),
                ValidCredentials))
            {
                Uri blobUri = !settings.ContainsKey(BlobEndpointSettingString) || settings[BlobEndpointSettingString] == null ? null : new Uri(settings[BlobEndpointSettingString]);
                Uri queueUri = !settings.ContainsKey(QueueEndpointSettingString) || settings[QueueEndpointSettingString] == null ? null : new Uri(settings[QueueEndpointSettingString]);
                Uri tableUri = !settings.ContainsKey(TableEndpointSettingString) || settings[TableEndpointSettingString] == null ? null : new Uri(settings[TableEndpointSettingString]);

                accountInformation = new CloudStorageAccount(GetCredentials(settings), blobUri, queueUri, tableUri);

                accountInformation.Settings = ValidCredentials(settings);
                return true;
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
            IDictionary<string, string> settings = new Dictionary<string, string>();
            string[] splitted = connectionString.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string nameValue in splitted)
            {
                string[] splittedNameValue = nameValue.Split(new char[] { '=' }, 2);

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
        private static AccountSetting Setting(string name, params string[] validValues)
        {
            return new AccountSetting(
                name,
                (settingValue) =>
                {
                    if (validValues.Length == 0)
                    {
                        return true;
                    }

                    return validValues.Contains(settingValue);
                });
        }

        /// <summary>
        /// Encapsulates a validation rule using a func.
        /// </summary>
        /// <param name="name">The name of the setting.</param>
        /// <param name="isValid">A func that determines if the value is valid.</param>
        /// <returns>An <see cref="AccountSetting"/> representing the constraint.</returns>
        private static AccountSetting Setting(string name, Func<string, bool> isValid)
        {
            return new AccountSetting(name, isValid);
        }

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
        private static bool IsValidUri(string settingValue)
        {
            return Uri.IsWellFormedUriString(settingValue, UriKind.Absolute);
        }

        /// <summary>
        /// Validation function that validates a domain name.
        /// </summary>
        /// <param name="settingValue">Value to validate.</param>
        /// <returns><c>true</c> if the specified setting value is a valid domain; otherwise, <c>false</c>.</returns>
        private static bool IsValidDomain(string settingValue)
        {
            return Uri.CheckHostName(settingValue).Equals(UriHostNameType.Dns);
        }

        /// <summary>
        /// Settings filter that requires all specified settings be present and valid.
        /// </summary>
        /// <param name="requiredSettings">A list of settings that must be present.</param>
        /// <returns>The remaining settings or null if the filter's requirement is not satisfied.</returns>
        private static Func<IDictionary<string, string>, IDictionary<string, string>> AllRequired(params AccountSetting[] requiredSettings)
        {
            return (settings) =>
            {
                IDictionary<string, string> result = new Dictionary<string, string>(settings);

                foreach (AccountSetting requirement in requiredSettings)
                {
                    string value;
                    if (result.TryGetValue(requirement.Key, out value) && requirement.Value(value))
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
        }

        /// <summary>
        /// Settings filter that removes optional values.
        /// </summary>
        /// <param name="optionalSettings">A list of settings that are optional.</param>
        /// <returns>The remaining settings or null if the filter's requirement is not satisfied.</returns>
        private static Func<IDictionary<string, string>, IDictionary<string, string>> Optional(params AccountSetting[] optionalSettings)
        {
            return (settings) =>
            {
                IDictionary<string, string> result = new Dictionary<string, string>(settings);

                foreach (AccountSetting requirement in optionalSettings)
                {
                    string value;
                    if (result.TryGetValue(requirement.Key, out value) && requirement.Value(value))
                    {
                        result.Remove(requirement.Key);
                    }
                }

                return result;
            };
        }

        /// <summary>
        /// Settings filter that ensures that at least one setting is present.
        /// </summary>
        /// <param name="atLeastOneSettings">A list of settings of which one must be present.</param>
        /// <returns>The remaining settings or null if the filter's requirement is not satisfied.</returns>
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed.")]
        private static Func<IDictionary<string, string>, IDictionary<string, string>> AtLeastOne(params AccountSetting[] atLeastOneSettings)
        {
            return (settings) =>
            {
                IDictionary<string, string> result = new Dictionary<string, string>(settings);
                bool foundOne = false;

                foreach (AccountSetting requirement in atLeastOneSettings)
                {
                    string value;
                    if (result.TryGetValue(requirement.Key, out value) && requirement.Value(value))
                    {
                        result.Remove(requirement.Key);
                        foundOne = true;
                    }
                }

                return foundOne ? result : null;
            };
        }

        /// <summary>
        /// Settings filter that ensures that a valid combination of credentials is present.
        /// </summary>
        /// <returns>The remaining settings or null if the filter's requirement is not satisfied.</returns>
        private static IDictionary<string, string> ValidCredentials(IDictionary<string, string> settings)
        {
            string accountName;
            string accountKey;
            string accountKeyName;
            string sharedAccessSignature;
            IDictionary<string, string> result = new Dictionary<string, string>(settings);

            if (settings.TryGetValue(AccountNameSettingString, out accountName) &&
                !AccountNameSetting.Value(accountName))
            {
                return null;
            }

            if (settings.TryGetValue(AccountKeySettingString, out accountKey) &&
                !AccountKeySetting.Value(accountKey))
            {
                return null;
            }

            if (settings.TryGetValue(AccountKeyNameSettingString, out accountKeyName) &&
                !AccountKeyNameSetting.Value(accountKeyName))
            {
                return null;
            }

            if (settings.TryGetValue(SharedAccessSignatureSettingString, out sharedAccessSignature) &&
                !SharedAccessSignatureSetting.Value(sharedAccessSignature))
            {
                return null;
            }

            result.Remove(AccountNameSettingString);
            result.Remove(AccountKeySettingString);
            result.Remove(AccountKeyNameSettingString);
            result.Remove(SharedAccessSignatureSettingString);

            // AccountAndKey
            if (accountName != null && accountKey != null && sharedAccessSignature == null)
            {
                return result;
            }

            // SharedAccessSignature
            if (accountName == null && accountKey == null && accountKeyName == null && sharedAccessSignature != null)
            {
                return result;
            }

            // Anonymous
            if (accountName == null && accountKey == null && accountKeyName == null && sharedAccessSignature == null)
            {
                return result;
            }

            return null;
        }

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
            params Func<IDictionary<string, string>, IDictionary<string, string>>[] constraints)
        {
            foreach (Func<IDictionary<string, string>, IDictionary<string, string>> constraint in constraints)
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

            if (settings.Count == 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets a StorageCredentials object corresponding to whatever credentials are supplied in the given settings.
        /// </summary>
        /// <param name="settings">The settings to check.</param>
        /// <returns>The StorageCredentials object specified in the settings.</returns>
        private static StorageCredentials GetCredentials(IDictionary<string, string> settings)
        {
            string accountName;
            string accountKey;
            string accountKeyName;
            string sharedAccessSignature;

            settings.TryGetValue(AccountNameSettingString, out accountName);
            settings.TryGetValue(AccountKeySettingString, out accountKey);
            settings.TryGetValue(AccountKeyNameSettingString, out accountKeyName);
            settings.TryGetValue(SharedAccessSignatureSettingString, out sharedAccessSignature);

            if (accountName != null && accountKey != null && sharedAccessSignature == null)
            {
                return new StorageCredentials(accountName, accountKey, accountKeyName);
            }

            if (accountName == null && accountKey == null && accountKeyName == null && sharedAccessSignature != null)
            {
                return new StorageCredentials(sharedAccessSignature);
            }

            return null;
        }

        /// <summary>
        /// Gets the default blob endpoint using specified settings.
        /// </summary>
        /// <param name="settings">The settings to use.</param>
        /// <returns>The default blob endpoint.</returns>
        private static string ConstructBlobEndpoint(IDictionary<string, string> settings)
        {
            return ConstructBlobEndpoint(
                settings[DefaultEndpointsProtocolSettingString],
                settings[AccountNameSettingString],
                settings.ContainsKey(EndpointSuffixSettingString) ? settings[EndpointSuffixSettingString] : null);
        }

        /// <summary>
        /// Gets the default blob endpoint using the specified protocol and account name.
        /// </summary>
        /// <param name="scheme">The protocol to use.</param>
        /// <param name="accountName">The name of the storage account.</param>
        /// <param name="endpointSuffix">The Endpoint DNS suffix; use <c>null</c> for default.</param>
        /// <returns>The default blob endpoint.</returns>
        private static string ConstructBlobEndpoint(string scheme, string accountName, string endpointSuffix)
        {
            if (string.IsNullOrEmpty(scheme))
            {
                throw new ArgumentNullException("scheme");
            }

            if (string.IsNullOrEmpty(accountName))
            {
                throw new ArgumentNullException("accountName");
            }

            if (string.IsNullOrEmpty(endpointSuffix))
            {
                endpointSuffix = DefaultEndpointSuffix;
            }

            return string.Format(
                CultureInfo.InvariantCulture,
                "{0}://{1}.{2}.{3}/",
                scheme,
                accountName,
                DefaultBlobHostnamePrefix,
                endpointSuffix);
        }

        /// <summary>
        /// Gets the default queue endpoint using the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>The default queue endpoint.</returns>
        private static string ConstructQueueEndpoint(IDictionary<string, string> settings)
        {
            return ConstructQueueEndpoint(
                settings[DefaultEndpointsProtocolSettingString],
                settings[AccountNameSettingString],
                settings.ContainsKey(EndpointSuffixSettingString) ? settings[EndpointSuffixSettingString] : null);
        }

        /// <summary>
        /// Gets the default queue endpoint using the specified protocol and account name.
        /// </summary>
        /// <param name="scheme">The protocol to use.</param>
        /// <param name="accountName">The name of the storage account.</param>
        /// <param name="endpointSuffix">The Endpoint DNS suffix; use <c>null</c> for default.</param>
        /// <returns>The default queue endpoint.</returns>
        private static string ConstructQueueEndpoint(string scheme, string accountName, string endpointSuffix)
        {
            if (string.IsNullOrEmpty(scheme))
            {
                throw new ArgumentNullException("scheme");
            }
            
            if (string.IsNullOrEmpty(accountName))
            {
                throw new ArgumentNullException("accountName");
            }

            if (string.IsNullOrEmpty(endpointSuffix))
            {
                endpointSuffix = DefaultEndpointSuffix;
            }

            return string.Format(
                CultureInfo.InvariantCulture,
                "{0}://{1}.{2}.{3}/",
                scheme,
                accountName,
                DefaultQueueHostnamePrefix,
                endpointSuffix);
        }

        /// <summary>
        /// Gets the default table endpoint using the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>The default table endpoint.</returns>
        private static string ConstructTableEndpoint(IDictionary<string, string> settings)
        {
            return ConstructTableEndpoint(
                settings[DefaultEndpointsProtocolSettingString],
                settings[AccountNameSettingString],
                settings.ContainsKey(EndpointSuffixSettingString) ? settings[EndpointSuffixSettingString] : null);
        }

        /// <summary>
        /// Gets the default table endpoint using the specified protocol and account name.
        /// </summary>
        /// <param name="scheme">The protocol to use.</param>
        /// <param name="accountName">The name of the storage account.</param>
        /// <param name="endpointSuffix">The Endpoint DNS suffix; use <c>null</c> for default.</param>
        /// <returns>The default table endpoint.</returns>
        private static string ConstructTableEndpoint(string scheme, string accountName, string endpointSuffix)
        {
            if (string.IsNullOrEmpty(scheme))
            {
                throw new ArgumentNullException("scheme");
            } 
            
            if (string.IsNullOrEmpty(accountName))
            {
                throw new ArgumentNullException("accountName");
            }

            if (string.IsNullOrEmpty(endpointSuffix))
            {
                endpointSuffix = DefaultEndpointSuffix;
            }

            return string.Format(
                CultureInfo.InvariantCulture,
                "{0}://{1}.{2}.{3}/",
                scheme,
                accountName,
                DefaultTableHostnamePrefix,
                endpointSuffix);
        }
    }
}
