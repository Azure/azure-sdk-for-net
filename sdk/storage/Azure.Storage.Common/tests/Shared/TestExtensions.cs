// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Azure.Storage
{
    /// <summary>
    /// Extension methods to make tests easier to author.
    /// </summary>
    public static partial class TestExtensions
    {
        /// <summary>
        /// Convert an IAsyncEnumerable into a List to make test verification
        /// easier.
        /// </summary>
        /// <typeparam name="T">The item type.</typeparam>
        /// <param name="items">The seqeuence of items.</param>
        /// <returns>A list of all the items in the sequence.</returns>
        public static async Task<IList<T>> ToListAsync<T>(this IAsyncEnumerable<T> items)
        {
            var all = new List<T>();
            await foreach (T item in items)
            {
                all.Add(item);
            }
            return all;
        }

        /// <summary>
        /// Get the first item in an IAsyncEnumerable.
        /// </summary>
        /// <typeparam name="T">The item type.</typeparam>
        /// <param name="items">The seqeuence of items.</param>
        /// <returns>
        /// The first item in the sequence or an
        /// <see cref="InvalidOperationException"/>.
        /// </returns>
        public static async Task<T> FirstAsync<T>(this IAsyncEnumerable<T> items)
        {
            await foreach (T item in items)
            {
                return item;
            }
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns a new Uri based on the supplied Uri, but with Http enabled.
        /// </summary>
        /// <param name="uri">Source Uri.</param>
        /// <returns>Http Uri.</returns>
        public static Uri ToHttp(this Uri uri)
        {
            var builder = new UriBuilder(uri)
            {
                Scheme = "http",
                Port = 80
            };
            return builder.Uri;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageConnectionString"/> class using the specified
        /// credentials, and specifies whether to use HTTP or HTTPS to connect to the storage services.
        /// </summary>
        /// <param name="storageCredentials">A StorageCredentials object.</param>
        /// <param name="useHttps"><c>true</c> to use HTTPS to connect to storage service endpoints; otherwise, <c>false</c>.</param>
        /// <remarks>Using HTTPS to connect to the storage services is recommended.</remarks>
        internal static StorageConnectionString CreateStorageConnectionString(object storageCredentials, bool useHttps) =>
           CreateStorageConnectionString(storageCredentials, null /* endpointSuffix */, useHttps);

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageConnectionString"/> class using the specified
        /// credentials and endpoint suffix, and specifies whether to use HTTP or HTTPS to connect to the storage services.
        /// </summary>
        /// <param name="storageCredentials">A StorageCredentials object.</param>
        /// <param name="endpointSuffix">The DNS endpoint suffix for all storage services, e.g. "core.windows.net".</param>
        /// <param name="useHttps"><c>true</c> to use HTTPS to connect to storage service endpoints; otherwise, <c>false</c>.</param>
        /// <remarks>Using HTTPS to connect to the storage services is recommended.</remarks>
        internal static StorageConnectionString CreateStorageConnectionString(object storageCredentials, string endpointSuffix, bool useHttps) =>
            CreateStorageConnectionString(storageCredentials, storageCredentials is StorageSharedKeyCredential sharedKeyCredentials ? sharedKeyCredentials.AccountName : default, endpointSuffix, useHttps);

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageConnectionString"/> class using the specified
        /// credentials and endpoint suffix, and specifies whether to use HTTP or HTTPS to connect to the storage services.
        /// </summary>
        /// <param name="storageCredentials">A StorageCredentials object.</param>
        /// <param name="accountName">The name of the account.</param>
        /// <param name="endpointSuffix">The DNS endpoint suffix for all storage services, e.g. "core.windows.net".</param>
        /// <param name="useHttps"><c>true</c> to use HTTPS to connect to storage service endpoints; otherwise, <c>false</c>.</param>
        /// <param name="setEndpoint">Whether or not to set the endpoint properties on the ConnectionString.</param>
        /// <remarks>Using HTTPS to connect to the storage services is recommended.</remarks>
        internal static StorageConnectionString CreateStorageConnectionString(
            object storageCredentials,
            string accountName,
            string endpointSuffix = Constants.ConnectionStrings.DefaultEndpointSuffix,
            bool useHttps = true)
        {
            var conn = new StorageConnectionString(storageCredentials);
            if (storageCredentials == null)
            {
                throw Errors.ArgumentNull(nameof(storageCredentials));
            }

            if (storageCredentials is StorageSharedKeyCredential sharedKeyCredentials && !string.IsNullOrEmpty(sharedKeyCredentials.AccountName))
            {
                if (string.IsNullOrEmpty(accountName))
                {
                    accountName = sharedKeyCredentials.AccountName;
                }
                else if (string.Compare(sharedKeyCredentials.AccountName, accountName, StringComparison.Ordinal) != 0)
                {
                    throw Errors.AccountMismatch(sharedKeyCredentials.AccountName, accountName);
                }
            }

            if (accountName == default)
            {
                throw Errors.ArgumentNull(nameof(accountName));
            }

            conn._accountName = accountName;
            var sasToken = (storageCredentials is SharedAccessSignatureCredentials sasCredentials) ? sasCredentials.SasToken : default;

            var scheme = useHttps ? Constants.Https : Constants.Http;
            conn.BlobStorageUri = StorageConnectionString.ConstructBlobEndpoint(scheme, accountName, endpointSuffix, sasToken);
            conn.QueueStorageUri = StorageConnectionString.ConstructQueueEndpoint(scheme, accountName, endpointSuffix, sasToken);
            conn.FileStorageUri = StorageConnectionString.ConstructFileEndpoint(scheme, accountName, endpointSuffix, sasToken);
            conn.Credentials = storageCredentials;
            conn.EndpointSuffix = endpointSuffix;
            conn.DefaultEndpoints = true;
            return conn;
        }

        /// <summary>
        /// Returns a connection string for the storage account, optionally with sensitive data.
        /// </summary>
        /// <param name="exportSecrets"><c>True</c> to include sensitive data in the string; otherwise, <c>false</c>.</param>
        /// <returns>A connection string.</returns>
        internal static string ToString(this StorageConnectionString conn, bool exportSecrets)
        {
            if (conn.Settings == null)
            {
                conn.Settings = new Dictionary<string, string>();

                if (conn.DefaultEndpoints)
                {
                    conn.Settings.Add(
                        Constants.ConnectionStrings.DefaultEndpointsProtocolSetting,
                        conn.BlobEndpoint.Scheme);

                    if (conn.EndpointSuffix != null)
                    {
                        conn.Settings.Add(Constants.ConnectionStrings.EndpointSuffixSetting, conn.EndpointSuffix);
                    }
                }
                else
                {
                    if (conn.BlobEndpoint != null)
                    {
                        conn.Settings.Add(Constants.ConnectionStrings.BlobEndpointSetting, conn.BlobEndpoint.ToString());
                    }

                    if (conn.QueueEndpoint != null)
                    {
                        conn.Settings.Add(Constants.ConnectionStrings.QueueEndpointSetting, conn.QueueEndpoint.ToString());
                    }

                    if (conn.FileEndpoint != null)
                    {
                        conn.Settings.Add(Constants.ConnectionStrings.FileEndpointSetting, conn.FileEndpoint.ToString());
                    }

                    if (conn.BlobStorageUri.SecondaryUri != null)
                    {
                        conn.Settings.Add(Constants.ConnectionStrings.BlobSecondaryEndpointSetting,
                            conn.BlobStorageUri.SecondaryUri.ToString());
                    }

                    if (conn.QueueStorageUri.SecondaryUri != null)
                    {
                        conn.Settings.Add(Constants.ConnectionStrings.QueueSecondaryEndpointSetting,
                            conn.QueueStorageUri.SecondaryUri.ToString());
                    }

                    if (conn.FileStorageUri.SecondaryUri != null)
                    {
                        conn.Settings.Add(Constants.ConnectionStrings.FileSecondaryEndpointSetting,
                            conn.FileStorageUri.SecondaryUri.ToString());
                    }
                }
            }

            var listOfSettings = conn.Settings.Select(pair => string.Format(CultureInfo.InvariantCulture, "{0}={1}", pair.Key, pair.Value)).ToList();

            if (conn.Credentials != null && !conn.IsDevStoreAccount)
            {
                listOfSettings.Add(ToString(conn.Credentials, exportSecrets));
            }

            if (!string.IsNullOrWhiteSpace(conn._accountName) && (conn.Credentials is StorageSharedKeyCredential sharedKeyCredentials ? string.IsNullOrWhiteSpace(sharedKeyCredentials.AccountName) : true))
            {
                listOfSettings.Add(string.Format(CultureInfo.InvariantCulture, "{0}={1}", Constants.ConnectionStrings.AccountNameSetting, conn._accountName));
            }

            return string.Join(";", listOfSettings);
        }

        private static string ToString(object credentials, bool exportSecrets)
        {
            if (credentials is StorageSharedKeyCredential sharedKeyCredentials)
            {
                return string.Format(
                    CultureInfo.InvariantCulture,
                    "{0}={1};{2}={3}",
                    Constants.ConnectionStrings.AccountNameSetting,
                    sharedKeyCredentials.AccountName,
                    Constants.ConnectionStrings.AccountKeySetting,
                    exportSecrets ? ((StorageSharedKeyCredential)credentials).ExportBase64EncodedKey() : "Sanitized");
            }
            else if (credentials is SharedAccessSignatureCredentials sasCredentials)
            {
                return string.Format(CultureInfo.InvariantCulture, "{0}={1}", Constants.ConnectionStrings.SharedAccessSignatureSetting, exportSecrets ? sasCredentials.SasToken : "[signature hidden]");
            }

            return string.Empty;
        }

        internal static string ExportBase64EncodedKey(this StorageSharedKeyCredential credential)
        {
            byte[] key = credential.GetAccountKey();
            return key == null ?
                null :
                Convert.ToBase64String(key);
        }

        // We don't want to expose the AccountKey to users to encourage them to properly manage their secrets,
        // and we don't want to expose all of Azure.Storage.Common's internals to all our tests,
        // so we're making a strategic choice to use private reflection for this field.
        internal static byte[] GetAccountKey(this StorageSharedKeyCredential credential)
        {
            Type type = credential.GetType();
            PropertyInfo prop = type.GetProperty("AccountKeyValue", BindingFlags.NonPublic | BindingFlags.Instance);
            var val = prop.GetValue(credential);
            return val as byte[];
        }
    }
}
