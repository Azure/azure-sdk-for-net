// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Storage.Test
{
    /// <summary>
    /// Defines all the configuration values for a Storage Account to use when
    /// executing our tests.  Our tests require different types of Storage
    /// accounts and you can choose between them using the TestConfigurations
    /// class.
    /// </summary>
    public class TenantConfiguration
    {
        static TenantConfiguration()
        {
            propertyCount = typeof(TenantConfiguration).GetProperties(BindingFlags.Instance | BindingFlags.Public).Length;
        }
        private static int propertyCount { get; }

        private const string SanitizeValue = "Sanitized";

        public string TenantName { get; private set; }
        public string AccountName { get; private set; }
        public string AccountKey { get; private set; }
        public string BlobServiceEndpoint { get; private set; }
        public string FileServiceEndpoint { get; private set; }
        public string QueueServiceEndpoint { get; private set; }
        public string TableServiceEndpoint { get; private set; }
        public string BlobSecurePortOverride { get; private set; }
        public string FileSecurePortOverride { get; private set; }
        public string TableSecurePortOverride { get; private set; }
        public string QueueSecurePortOverride { get; private set; }
        public string BlobServiceSecondaryEndpoint { get; private set; }
        public string FileServiceSecondaryEndpoint { get; private set; }
        public string QueueServiceSecondaryEndpoint { get; private set; }
        public string TableServiceSecondaryEndpoint { get; private set; }
        public TenantType TenantType { get; private set; }
        public string ConnectionString { get; private set; }
        public string EncryptionScope { get; private set; }
        public string ResourceGroupName { get; private set; }
        public string SubscriptionId { get; private set; }

        /// <summary>
        /// Build a connection string for any tenant configuration that didn't
        /// provide one.
        /// </summary>
        /// <param name="sanitize">
        /// Whether to sanitize the AccountKey out of the connection string.
        /// The default value is true.
        /// </param>
        /// <returns>A connnection string for this tenant.</returns>
        private string BuildConnectionString(bool sanitize = true)
        {
            var connection = new StorageConnectionString(
                storageCredentials: new StorageSharedKeyCredential(AccountName, AccountKey),
                blobStorageUri: (AsUri(BlobServiceEndpoint), AsUri(BlobServiceSecondaryEndpoint)),
                fileStorageUri: (AsUri(FileServiceEndpoint), AsUri(FileServiceSecondaryEndpoint)),
                tableStorageUri: (AsUri(TableServiceEndpoint), AsUri(TableServiceSecondaryEndpoint)),
                queueStorageUri: (AsUri(QueueServiceEndpoint), AsUri(QueueServiceSecondaryEndpoint)));
            return connection.ToString(exportSecrets: !sanitize);
            Uri AsUri(string text) => !string.IsNullOrWhiteSpace(text) ? new Uri(text) : default;
        }

        /// <summary>
        /// Sloppily serialize the tenant configuration as a string with one
        /// property per line.  This is only used for test recording.
        /// </summary>
        /// <param name="config">The tenant configuration.</param>
        /// <param name="sanitize">
        /// Whether to santize AccountKeys in the serialized value.  The
        /// default is true.
        /// </param>
        /// <returns>A string represenation of the tenant configuration.</returns>
        public static string Serialize(TenantConfiguration config, bool sanitize = true) =>
            string.Join(
                "\n",
                // Keep these in the same order as Parse below!
                config.TenantName,
                config.AccountName,
                !sanitize ?
                    config.AccountKey :
                    Convert.ToBase64String(Encoding.UTF8.GetBytes(SanitizeValue)),
                config.BlobServiceEndpoint,
                config.FileServiceEndpoint,
                config.QueueServiceEndpoint,
                config.TableServiceEndpoint,
                config.BlobSecurePortOverride,
                config.FileSecurePortOverride,
                config.TableSecurePortOverride,
                config.QueueSecurePortOverride,
                config.BlobServiceSecondaryEndpoint,
                config.FileServiceSecondaryEndpoint,
                config.QueueServiceSecondaryEndpoint,
                config.TableServiceSecondaryEndpoint,
                config.TenantType.ToString(),
                !sanitize ?
                    config.ConnectionString :
                    config.BuildConnectionString(sanitize),
                config.EncryptionScope,
                config.ResourceGroupName,
                config.SubscriptionId);

        /// <summary>
        /// Parse a TenantType and ignore case.
        /// </summary>
        /// <param name="text">The string to parse.</param>
        /// <returns>A TenantType value.</returns>
        private static TenantType ParseTenantType(string text) =>
            (TenantType)Enum.Parse(typeof(TenantType), text, true);

        /// <summary>
        /// Parse a string representation created by Serialize into a
        /// TenantConfiguration value.
        /// </summary>
        /// <param name="text">The string to parse.</param>
        /// <returns>A TenantConfiguration value.</returns>
        public static TenantConfiguration Parse(string text)
        {
            var values = text?.Split('\n');
            if (values == null || values.Length != propertyCount)
            {
                const string nullString = "<null>";
                throw new ArgumentException($"Values count: {values?.Length.ToString() ?? nullString}. Expected: {propertyCount}", nameof(text));
            }

            return new TenantConfiguration
            {
                // Keep these in the same order as Serialize above!
                TenantName = values[0],
                AccountName = values[1],
                AccountKey = values[2],
                BlobServiceEndpoint = values[3],
                FileServiceEndpoint = values[4],
                QueueServiceEndpoint = values[5],
                TableServiceEndpoint = values[6],
                BlobSecurePortOverride = values[7],
                FileSecurePortOverride = values[8],
                TableSecurePortOverride = values[9],
                QueueSecurePortOverride = values[10],
                BlobServiceSecondaryEndpoint = values[11],
                FileServiceSecondaryEndpoint = values[12],
                QueueServiceSecondaryEndpoint = values[13],
                TableServiceSecondaryEndpoint = values[14],
                TenantType = ParseTenantType(values[15]),
                ConnectionString = values[16],
                EncryptionScope = values[17],
                ResourceGroupName = values[18],
                SubscriptionId = values[19]
            };
        }

        /// <summary>
        /// Parse an XML representation into a TenantConfiguration value.
        /// </summary>
        /// <param name="tenant">The XML element to parse.</param>
        /// <returns>A TenantConfiguration value.</returns>
        public static TenantConfiguration Parse(XElement tenant)
        {
            string Get(string name) => (string)tenant.Element(name);

            var config = new TenantConfiguration
            {
                TenantName = Get("TenantName"),
                AccountName = Get("AccountName"),
                AccountKey = Get("AccountKey"),
                BlobServiceEndpoint = Get("BlobServiceEndpoint"),
                FileServiceEndpoint = Get("FileServiceEndpoint"),
                QueueServiceEndpoint = Get("QueueServiceEndpoint"),
                TableServiceEndpoint = Get("TableServiceEndpoint"),
                BlobServiceSecondaryEndpoint = Get("BlobServiceSecondaryEndpoint"),
                FileServiceSecondaryEndpoint = Get("FileServiceSecondaryEndpoint"),
                QueueServiceSecondaryEndpoint = Get("QueueServiceSecondaryEndpoint"),
                TableServiceSecondaryEndpoint = Get("TableServiceSecondaryEndpoint"),
                TenantType = ParseTenantType(Get("TenantType")),
                BlobSecurePortOverride = Get("BlobSecurePortOverride"),
                FileSecurePortOverride = Get("FileSecurePortOverride"),
                QueueSecurePortOverride = Get("QueueSecurePortOverride"),
                TableSecurePortOverride = Get("TableSecurePortOverride"),
                ConnectionString = Get("ConnectionString"),
                EncryptionScope = Get("EncryptionScope"),
                ResourceGroupName = Get("ResourceGroupName"),
                SubscriptionId = Get("SubscriptionId")
            };

            // Build a connection string from the other properties if one
            // wasn't provided with the configuration
            if (string.IsNullOrWhiteSpace(config.ConnectionString))
            {
                config.ConnectionString = config.BuildConnectionString(false);
            }

            return config;
        }
    }
}
