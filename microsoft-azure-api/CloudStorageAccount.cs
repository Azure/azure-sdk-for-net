//-----------------------------------------------------------------------
// <copyright file="CloudStorageAccount.cs" company="Microsoft">
//    Copyright 2011 Microsoft Corporation
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
// <summary>
//    Contains code for the CloudStorageAccount class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using Microsoft.WindowsAzure.StorageClient;
    using AccountSetting = System.Collections.Generic.KeyValuePair<string, System.Func<string, bool>>;

    /// <summary>
    /// Represents a Windows Azure storage account.
    /// </summary>
    public sealed class CloudStorageAccount
    {
        /// <summary>
        /// The setting name for using the development storage.
        /// </summary>
        internal const string UseDevelopmentStorageName = "UseDevelopmentStorage";

        /// <summary>
        /// The setting name for specifying a development storage proxy Uri.
        /// </summary>
        internal const string DevelopmentStorageProxyUriName = "DevelopmentStorageProxyUri";

        /// <summary>
        /// The setting name for using the default storage endpoints with the specified protocol.
        /// </summary>
        internal const string DefaultEndpointsProtocolName = "DefaultEndpointsProtocol";

        /// <summary>
        /// The setting name for the account name.
        /// </summary>
        internal const string AccountNameName = "AccountName";

        /// <summary>
        /// The setting name for the account key.
        /// </summary>
        internal const string AccountKeyName = "AccountKey";

        /// <summary>
        /// The setting name for a custom blob storage endpoint.
        /// </summary>
        internal const string BlobEndpointName = "BlobEndpoint";

        /// <summary>
        /// The setting name for a custom queue endpoint.
        /// </summary>
        internal const string QueueEndpointName = "QueueEndpoint";

        /// <summary>
        /// The setting name for a custom table storage endpoint.
        /// </summary>
        internal const string TableEndpointName = "TableEndpoint";

        /// <summary>
        /// The setting name for a shared access key.
        /// </summary>
        internal const string SharedAccessSignatureName = "SharedAccessSignature";

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
            CloudStorageAccount.AccountNameName + "=" + DevstoreAccountName + ";" +
            CloudStorageAccount.AccountKeyName + "=" + DevstoreAccountKey;

        /// <summary>
        /// The root blob storage DNS name.
        /// </summary>
        private const string BlobBaseDnsName = "blob.core.windows.net";

        /// <summary>
        /// The root queue DNS name.
        /// </summary>
        private const string QueueBaseDnsName = "queue.core.windows.net";

        /// <summary>
        /// The root table storage DNS name.
        /// </summary>
        private const string TableBaseDnsName = "table.core.windows.net";

        /// <summary>
        /// Validator for the UseDevelopmentStorage setting. Must be "true".
        /// </summary>
        private static readonly AccountSetting UseDevelopmentStorageSetting = Setting(UseDevelopmentStorageName, "true");

        /// <summary>
        /// Validator for the DevelopmentStorageProxyUri setting. Must be a valid Uri.
        /// </summary>
        private static readonly AccountSetting DevelopmentStorageProxyUriSetting = Setting(DevelopmentStorageProxyUriName, IsValidUri);

        /// <summary>
        /// Validator for the DefaultEndpointsProtocol setting. Must be either "http" or "https".
        /// </summary>
        private static readonly AccountSetting DefaultEndpointsProtocolSetting = Setting(DefaultEndpointsProtocolName, "http", "https");
        
        /// <summary>
        /// Validator for the AccountName setting. No restrictions.
        /// </summary>
        private static readonly AccountSetting AccountNameSetting = Setting(AccountNameName);

        /// <summary>
        /// Validator for the AccountKey setting. Must be a valid base64 string.
        /// </summary>
        private static readonly AccountSetting AccountKeySetting = Setting(AccountKeyName, IsValidBase64String);

        /// <summary>
        /// Validator for the BlobEndpoint setting. Must be a valid Uri.
        /// </summary>
        private static readonly AccountSetting BlobEndpointSetting = Setting(BlobEndpointName, IsValidUri);

        /// <summary>
        /// Validator for the QueueEndpoint setting. Must be a valid Uri.
        /// </summary>
        private static readonly AccountSetting QueueEndpointSetting = Setting(QueueEndpointName, IsValidUri);

        /// <summary>
        /// Validator for the TableEndpoint setting. Must be a valid Uri.
        /// </summary>
        private static readonly AccountSetting TableEndpointSetting = Setting(TableEndpointName, IsValidUri);

        /// <summary>
        /// Validator for the SharedAccessSignature setting. No restrictions.
        /// </summary>
        private static readonly AccountSetting SharedAccessSignatureSetting = Setting(SharedAccessSignatureName);

        /// <summary>
        /// Stores the user-specified configuration setting publisher.
        /// </summary>
        private static Action<string, Func<string, bool>> configurationSettingPublisher;

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
        public CloudStorageAccount(
            StorageCredentials storageCredentials,
            Uri blobEndpoint,
            Uri queueEndpoint,
            Uri tableEndpoint)
        {
            this.Credentials = storageCredentials;
            this.BlobEndpoint = blobEndpoint;
            this.QueueEndpoint = queueEndpoint;
            this.TableEndpoint = tableEndpoint;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudStorageAccount"/> class using the specified
        /// account credentials and the default service endpoints. 
        /// </summary>
        /// <param name="storageCredentialsAccountAndKey">An object of type <see cref="StorageCredentialsAccountAndKey"/> that 
        /// specifies the account name and account key for the storage account.</param>
        /// <param name="useHttps"><c>True</c> to use HTTPS to connect to storage service endpoints; otherwise, <c>false</c>.</param>
        public CloudStorageAccount(StorageCredentialsAccountAndKey storageCredentialsAccountAndKey, bool useHttps)
            : this(
                storageCredentialsAccountAndKey,
                new Uri(GetDefaultBlobEndpoint(useHttps ? "https" : "http", storageCredentialsAccountAndKey.AccountName)),
                new Uri(GetDefaultQueueEndpoint(useHttps ? "https" : "http", storageCredentialsAccountAndKey.AccountName)),
                new Uri(GetDefaultTableEndpoint(useHttps ? "https" : "http", storageCredentialsAccountAndKey.AccountName)))
        {
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
                    devStoreAccount = GetDevelopmentStorageAccount(new Uri("http://127.0.0.1"));
                }

                return devStoreAccount;
            }
        }

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
        /// <param name="value">A valid connection string.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is null or empty.</exception>
        /// <exception cref="FormatException">Thrown if <paramref name="value"/> is not a valid connection string.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> cannot be parsed.</exception>
        /// <returns>A <see cref="CloudStorageAccount"/> object constructed from the values provided in the connection string.</returns>
        public static CloudStorageAccount Parse(string value)
        {
            CloudStorageAccount ret;

            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("value");
            }

            if (TryParse(value, out ret, err => { throw new FormatException(err); }))
            {
                return ret;
            }

            throw new ArgumentException("Error parsing", "value");
        }

        /// <summary>
        /// Create a new instance of a <see cref="CloudStorageAccount"/> object from a specified configuration
        /// setting. This method may be called only after the <see cref="SetConfigurationSettingPublisher"/> 
        /// method has been called to configure the global configuration setting publisher.
        /// </summary>
        /// <param name="settingName">The name of the configuration setting.</param>
        /// <exception cref="InvalidOperationException">Thrown if the global configuration setting
        /// publisher has not been configured, or if the configuration setting cannot be found.</exception>
        /// <returns>A <see cref="CloudStorageAccount"/> constructed from the values in the configuration string.</returns>
        public static CloudStorageAccount FromConfigurationSetting(string settingName)
        {
            if (configurationSettingPublisher == null)
            {
                throw new InvalidOperationException(SR.ConfigurationSettingPublisherError);
            }

            return (new StorageAccountConfigurationSetting(settingName)).CloudStorageAccount;
        }

        /// <summary>
        /// Indicates whether a connection string can be parsed to return a <see cref="CloudStorageAccount"/> object.
        /// </summary>
        /// <param name="value">The connection string to parse.</param>
        /// <param name="account">A <see cref="CloudStorageAccount"/> object to hold the instance returned if
        /// the connection string can be parsed.</param>
        /// <returns><b>true</b> if the connection string was successfully parsed; otherwise, <b>false</b>.</returns>
        public static bool TryParse(string value, out CloudStorageAccount account)
        {
            if (String.IsNullOrEmpty(value))
            {
                account = null;

                return false;
            }

            return TryParse(value, out account, err => { });
        }

        /// <summary>
        /// Sets the global configuration setting publisher for the storage account, which will be called when
        /// the account access keys are updated in the service configuration file.
        /// </summary>
        /// <param name="configurationSettingPublisher">The configuration setting publisher for the storage account.</param>
        public static void SetConfigurationSettingPublisher(Action<string, Func<string, bool>> configurationSettingPublisher)
        {
            CloudStorageAccount.configurationSettingPublisher = configurationSettingPublisher;
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
            var settings = new List<string>();

            if (this == DevelopmentStorageAccount)
            {
                settings.Add(String.Format("{0}=true", UseDevelopmentStorageName));
            }
            else if (this.Credentials != null &&
                     this.Credentials.AccountName == DevstoreAccountName &&
                     this.Credentials.ToString(true) == DevstoreCredentialInString &&
                     this.BlobEndpoint != null && this.QueueEndpoint != null && this.TableEndpoint != null &&
                     this.BlobEndpoint.Host == this.QueueEndpoint.Host &&
                     this.QueueEndpoint.Host == this.TableEndpoint.Host &&
                     this.BlobEndpoint.Scheme == this.QueueEndpoint.Scheme &&
                     this.QueueEndpoint.Scheme == this.TableEndpoint.Scheme)
            {
                settings.Add(String.Format("{0}=true", UseDevelopmentStorageName));
                settings.Add(String.Format("{0}={1}://{2}", DevelopmentStorageProxyUriName, this.BlobEndpoint.Scheme, this.BlobEndpoint.Host));
            }
            else if (this.BlobEndpoint != null && this.QueueEndpoint != null && this.TableEndpoint != null &&
                     this.BlobEndpoint.Host.EndsWith(BlobBaseDnsName) &&
                     this.QueueEndpoint.Host.EndsWith(QueueBaseDnsName) &&
                     this.TableEndpoint.Host.EndsWith(TableBaseDnsName) &&
                     this.BlobEndpoint.Scheme == this.QueueEndpoint.Scheme &&
                     this.QueueEndpoint.Scheme == this.TableEndpoint.Scheme)
            {
                settings.Add(String.Format("{0}={1}", DefaultEndpointsProtocolName, this.BlobEndpoint.Scheme));

                if (this.Credentials != null)
                {
                    settings.Add(this.Credentials.ToString(exportSecrets));
                }
            }
            else
            {
                if (this.BlobEndpoint != null)
                {
                    settings.Add(String.Format("{0}={1}", BlobEndpointName, this.BlobEndpoint));
                }

                if (this.QueueEndpoint != null)
                {
                    settings.Add(String.Format("{0}={1}", QueueEndpointName, this.QueueEndpoint));
                }

                if (this.TableEndpoint != null)
                {
                    settings.Add(String.Format("{0}={1}", TableEndpointName, this.TableEndpoint));
                }

                if (this.Credentials != null)
                {
                    settings.Add(this.Credentials.ToString(exportSecrets));
                }
            }

            return String.Join(";", settings.ToArray());
        }

        /// <summary>
        /// Returns a <see cref="CloudStorageAccount"/> with development storage credentials using the specified proxy Uri.
        /// </summary>
        /// <param name="proxyUri">The proxy endpoint to use.</param>
        /// <returns>The new <see cref="CloudStorageAccount"/>.</returns>
        internal static CloudStorageAccount GetDevelopmentStorageAccount(Uri proxyUri)
        {
            if (proxyUri == null)
            {
                return DevelopmentStorageAccount;
            }

            string prefix = proxyUri.Scheme + "://" + proxyUri.Host;

            return new CloudStorageAccount(
                new StorageCredentialsAccountAndKey(DevstoreAccountName, DevstoreAccountKey),
                new Uri(prefix + ":10000/devstoreaccount1"),
                new Uri(prefix + ":10001/devstoreaccount1"),
                new Uri(prefix + ":10002/devstoreaccount1"));
        }

        /// <summary>
        /// Internal implementation of Parse/TryParse.
        /// </summary>
        /// <param name="s">The string to parse.</param>
        /// <param name="accountInformation">The <see cref="CloudStorageAccount"/> to return.</param>
        /// <param name="error">A callback for reporting errors.</param>
        /// <returns>If true, the parse was successful. Otherwise, false.</returns>
        internal static bool TryParse(string s, out CloudStorageAccount accountInformation, Action<string> error)
        {
            var settings = ParseStringIntoSettings(s, error);

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
                var proxyUri = settings[DevelopmentStorageProxyUriName];

                accountInformation = GetDevelopmentStorageAccount(proxyUri == null ? null : new Uri(proxyUri));

                return true;
            }

            // automatic case
            if (MatchesSpecification(
                settings,
                AllRequired(DefaultEndpointsProtocolSetting, AccountNameSetting, AccountKeySetting),
                Optional(BlobEndpointSetting, QueueEndpointSetting, TableEndpointSetting)))
            {
                var blobEndpoint = settings[BlobEndpointName];
                var queueEndpoint = settings[QueueEndpointName];
                var tableEndpoint = settings[TableEndpointName];

                accountInformation = new CloudStorageAccount(
                    GetCredentials(settings),
                    new Uri(blobEndpoint ?? GetDefaultBlobEndpoint(settings)),
                    new Uri(queueEndpoint ?? GetDefaultQueueEndpoint(settings)),
                    new Uri(tableEndpoint ?? GetDefaultTableEndpoint(settings)));

                return true;
            }

            // explicit case
            if (MatchesSpecification(
                settings,
                AtLeastOne(BlobEndpointSetting, QueueEndpointSetting, TableEndpointSetting),
                ValidCredentials()))
            {
                var blobUri = settings[BlobEndpointName] == null ? null : new Uri(settings[BlobEndpointName]);
                var queueUri = settings[QueueEndpointName] == null ? null : new Uri(settings[QueueEndpointName]);
                var tableUri = settings[TableEndpointName] == null ? null : new Uri(settings[TableEndpointName]);

                accountInformation = new CloudStorageAccount(GetCredentials(settings), blobUri, queueUri, tableUri);

                return true;
            }

            // not valid
            accountInformation = null;

            error("No valid combination of account information found.");

            return false;
        }

        /// <summary>
        /// Tokenizes input and stores name/value pairs in a NameValueCollection.
        /// </summary>
        /// <param name="s">The string to parse.</param>
        /// <param name="error">Error reporting delegate.</param>
        /// <returns>Tokenized collection.</returns>
        private static NameValueCollection ParseStringIntoSettings(string s, Action<string> error)
        {
            var settings = new NameValueCollection();
            var pos = 0;

            while (pos < s.Length)
            {
                var equalsPos = s.IndexOf('=', pos);

                if (equalsPos == -1)
                {
                    error("Settings must be of the form \"name=value\".");
                    return null;
                }

                var name = s.Substring(pos, equalsPos - pos).Trim();

                if (settings[name] != null)
                {
                    error(String.Format("Duplicate setting '{0}' found.", name));
                    return null;
                }

                var semiPos = s.IndexOf(';', equalsPos);

                if (semiPos == -1)
                {
                    // add 1 to move past the '='
                    settings.Add(name, s.Substring(equalsPos + 1).Trim());

                    return settings;
                }
                else
                {
                    // add 1 to move past the '=', subtract one to miss the ';'
                    settings.Add(name, s.Substring(equalsPos + 1, semiPos - equalsPos - 1));
                }

                // add 1 to move past the ';'
                pos = semiPos + 1;
            }

            error("Invalid account string.");
            return null;
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

                    foreach (var validValue in validValues)
                    {
                        if (settingValue == validValue)
                        {
                            return true;
                        }
                    }

                    return false;
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
        /// Settings filter that requires all specified settings be present and valid.
        /// </summary>
        /// <param name="requiredSettings">A list of settings that must be present.</param>
        /// <returns>The remaining settings or null if the filter's requirement is not satisfied.</returns>
        private static Func<NameValueCollection, NameValueCollection> AllRequired(params AccountSetting[] requiredSettings)
        {
            return (settings) =>
            {
                var result = new NameValueCollection(settings);

                foreach (var requirement in requiredSettings)
                {
                    if (result[requirement.Key] != null && requirement.Value(result[requirement.Key]))
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
        private static Func<NameValueCollection, NameValueCollection> Optional(params AccountSetting[] optionalSettings)
        {
            return (settings) =>
            {
                var result = new NameValueCollection(settings);

                foreach (var requirement in optionalSettings)
                {
                    if (result[requirement.Key] != null && requirement.Value(result[requirement.Key]))
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
        private static Func<NameValueCollection, NameValueCollection> AtLeastOne(params AccountSetting[] atLeastOneSettings)
        {
            return (settings) =>
            {
                var result = new NameValueCollection(settings);
                bool foundOne = false;

                foreach (var requirement in atLeastOneSettings)
                {
                    if (result[requirement.Key] != null && requirement.Value(result[requirement.Key]))
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
        private static Func<NameValueCollection, NameValueCollection> ValidCredentials()
        {
            return (settings) =>
            {
                var accountName = settings[AccountNameName];
                var accountKey = settings[AccountKeyName];
                var sharedAccessSignature = settings[SharedAccessSignatureName];
                var result = settings;

                if (accountName != null && !AccountNameSetting.Value(accountName))
                {
                    return null;
                }

                if (accountKey != null && !AccountKeySetting.Value(accountKey))
                {
                    return null;
                }

                if (sharedAccessSignature != null && !SharedAccessSignatureSetting.Value(sharedAccessSignature))
                {
                    return null;
                }

                result.Remove(AccountNameName);
                result.Remove(AccountKeyName);
                result.Remove(SharedAccessSignatureName);

                // AccountAndKey
                if (accountName != null && accountKey != null && sharedAccessSignature == null)
                {
                    return result;
                }

                // SharedAccessSignature
                if (accountName == null && accountKey == null && sharedAccessSignature != null)
                {
                    return result;
                }

                // Anonymous
                if (accountName == null && accountKey == null && sharedAccessSignature == null)
                {
                    return result;
                }

                return null;
            };
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
            NameValueCollection settings,
            params Func<NameValueCollection, NameValueCollection>[] constraints)
        {
            foreach (var constraint in constraints)
            {
                var remainingSettings = constraint(settings);

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
        private static StorageCredentials GetCredentials(NameValueCollection settings)
        {
            var accountName = settings[AccountNameName];
            var accountKey = settings[AccountKeyName];
            var sharedAccessSignature = settings[SharedAccessSignatureName];

            if (accountName != null && accountKey != null && sharedAccessSignature == null)
            {
                return new StorageCredentialsAccountAndKey(accountName, Convert.FromBase64String(accountKey));
            }

            if (accountName == null && accountKey == null && sharedAccessSignature != null)
            {
                return new StorageCredentialsSharedAccessSignature(sharedAccessSignature);
            }

            return null;
        }

        /// <summary>
        /// Gets the default blob endpoint using specified settings.
        /// </summary>
        /// <param name="settings">The settings to use.</param>
        /// <returns>The default blob endpoint.</returns>
        private static string GetDefaultBlobEndpoint(NameValueCollection settings)
        {
            return GetDefaultBlobEndpoint(settings[DefaultEndpointsProtocolName], settings[AccountNameName]);
        }

        /// <summary>
        /// Gets the default blob endpoint using the specified protocol and account name.
        /// </summary>
        /// <param name="scheme">The protocol to use.</param>
        /// <param name="accountName">The name of the storage account.</param>
        /// <returns>The default blob endpoint.</returns>
        private static string GetDefaultBlobEndpoint(string scheme, string accountName)
        {
            return String.Format("{0}://{1}.{2}", scheme, accountName, BlobBaseDnsName);
        }

        /// <summary>
        /// Gets the default queue endpoint using the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>The default queue endpoint.</returns>
        private static string GetDefaultQueueEndpoint(NameValueCollection settings)
        {
            return GetDefaultQueueEndpoint(settings[DefaultEndpointsProtocolName], settings[AccountNameName]);
        }

        /// <summary>
        /// Gets the default queue endpoint using the specified protocol and account name.
        /// </summary>
        /// <param name="scheme">The protocol to use.</param>
        /// <param name="accountName">The name of the storage account.</param>
        /// <returns>The default queue endpoint.</returns>
        private static string GetDefaultQueueEndpoint(string scheme, string accountName)
        {
            return String.Format("{0}://{1}.{2}", scheme, accountName, QueueBaseDnsName);
        }

        /// <summary>
        /// Gets the default table endpoint using the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>The default table endpoint.</returns>
        private static string GetDefaultTableEndpoint(NameValueCollection settings)
        {
            return GetDefaultTableEndpoint(settings[DefaultEndpointsProtocolName], settings[AccountNameName]);
        }

        /// <summary>
        /// Gets the default table endpoint using the specified protocol and account name.
        /// </summary>
        /// <param name="scheme">The protocol to use.</param>
        /// <param name="accountName">The name of the storage account.</param>
        /// <returns>The default table endpoint.</returns>
        private static string GetDefaultTableEndpoint(string scheme, string accountName)
        {
            return String.Format("{0}://{1}.{2}", scheme, accountName, TableBaseDnsName);
        }

        /// <summary>
        /// Encapsulates a mutable storage credentials object.
        /// </summary>
        internal class StorageAccountConfigurationSetting
        {
            /// <summary>
            /// Stores the mutable storage credentials.
            /// </summary>
            private MutableStorageCredentials credentials;

            /// <summary>
            /// Initializes a new instance of the <see cref="StorageAccountConfigurationSetting"/> class.
            /// </summary>
            /// <param name="configurationSettingName">Name of the configuration setting.</param>
            public StorageAccountConfigurationSetting(string configurationSettingName)
            {
                this.ConfigurationSettingName = configurationSettingName;
                this.CloudStorageAccount = null;

                CloudStorageAccount.configurationSettingPublisher(configurationSettingName, this.SetConfigurationValue);
            }

            /// <summary>
            /// Gets or sets the name of the configuration setting from which we retrieve storage account information.
            /// </summary>
            public string ConfigurationSettingName { get; internal set; }

            /// <summary>
            /// Gets or sets the cloud storage account.
            /// </summary>
            /// <value>The cloud storage account.</value>
            public CloudStorageAccount CloudStorageAccount { get; internal set; }

            /// <summary>
            /// Sets the configuration value.
            /// </summary>
            /// <param name="value">The value.</param>
            /// <returns><c>true</c> if the value was set; otherwise, <c>false</c>.</returns>
            private bool SetConfigurationValue(string value)
            {
                if (this.CloudStorageAccount == null)
                {
                    // first time
                    CloudStorageAccount initialAccount;

                    if (CloudStorageAccount.TryParse(value, out initialAccount))
                    {
                        this.credentials = new MutableStorageCredentials(initialAccount.Credentials);

                        this.CloudStorageAccount = new CloudStorageAccount(
                            this.credentials,
                            initialAccount.BlobEndpoint,
                            initialAccount.QueueEndpoint,
                            initialAccount.TableEndpoint);
                    }
                    else
                    {
                        System.Diagnostics.Trace.TraceError("Error parsing storage account information - staying uninitialized");
                    }
                }
                else
                {
                    // key rotation
                    CloudStorageAccount newAccount;
                    if (CloudStorageAccount.TryParse(value, out newAccount))
                    {
                        if ((newAccount.BlobEndpoint != CloudStorageAccount.BlobEndpoint) ||
                            (newAccount.QueueEndpoint != CloudStorageAccount.QueueEndpoint) ||
                            (newAccount.TableEndpoint != CloudStorageAccount.TableEndpoint))
                        {
                            System.Diagnostics.Trace.TraceWarning("Rejecting change: Endpoint(s) changed when updating storage account.");
                            return false;
                        }

                        this.credentials.UpdateWith(newAccount.Credentials);
                    }
                    else
                    {
                        System.Diagnostics.Trace.WriteLine("Error parsing storage account information - staying unchanged");
                    }
                }

                return true;
            }
        }
    }
}
