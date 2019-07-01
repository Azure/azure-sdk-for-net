// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Azure.Storage.Test
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using Azure.Storage.Common;
    using NUnit.Framework;

    public class TestConfigurations
    {
        /// <summary>
        /// Add a static TestEventListener which will redirect SDK logging
        /// to Console.Out for easy debugging.
        /// 
        /// This is only here to run before any of our tests make requests.
        /// </summary>
#pragma warning disable IDE0052 // Remove unread private members
        static readonly TestEventListener _logging = new TestEventListener();
#pragma warning restore IDE0052 // Remove unread private members

        /// <summary>
        /// We'll check DefaultTestConfigPathEnvironmentVariable first for
        /// live test configuration settings.
        /// </summary>
        const string DefaultTestConfigPathEnvironmentVariable = @"AZ_STORAGE_CONFIG_PATH";

        /// <summary>
        /// We'll check DefaultTestConfigFilePath second for live test
        /// configuration settings.
        /// </summary>
        const string DefaultTestConfigFilePath = @"TestConfigurations.xml";
        
        /// <summary>
        /// Path of the file containing the live test configurations.
        /// </summary>
        public static string TestConfigurationsPath { get; private set; }

        static TestConfigurations DefaultTestConfigurations => defaultTestConfigurations.Value;

        static IEnumerable<TenantConfiguration> DefaultTenantConfigurations => defaultTestConfigurations.Value.TenantConfigurations;

        /// <summary>
        /// Lazily load the live test configuraions the first time they're
        /// required.
        /// </summary>
        static readonly Lazy<TestConfigurations> defaultTestConfigurations = new Lazy<TestConfigurations>(
            () =>
            {
                // Get the live test configurations path
                TestConfigurationsPath = Environment.GetEnvironmentVariable(DefaultTestConfigPathEnvironmentVariable);
                if (String.IsNullOrEmpty(TestConfigurationsPath) || !File.Exists(TestConfigurationsPath))
                {
                    TestConfigurationsPath = DefaultTestConfigFilePath;
                    if (String.IsNullOrEmpty(TestConfigurationsPath) || !File.Exists(TestConfigurationsPath))
                    {
                        Assert.Inconclusive($"Live test configuration not found at file {TestConfigurationsPath}!");
                    }
                }

                // Load the live test configurations
                try
                {
                    return ReadFromXml(XDocument.Load(TestConfigurationsPath));
                }
                catch (Exception ex)
                {
                    Assert.Inconclusive($"Live test configuration failed to load from file {TestConfigurationsPath}!\n{ex.ToString()}");
                    return null;
                }
            });

        public string TargetTenantName { get; private set; }
        public string TargetSecondaryTenantName { get; private set; }
        public string TargetPremiumBlobTenantName { get; private set; }
        public string TargetPreviewBlobTenantName { get; private set; }
        public string TargetOAuthTenantName { get; private set; }

        public static TenantConfiguration DefaultTargetTenant => GetTenantConfiguration("TargetTestTenant", DefaultTestConfigurations.TargetTenantName);
        public static TenantConfiguration DefaultSecondaryTargetTenant => GetTenantConfiguration("TargetSecondaryTestTenant", DefaultTestConfigurations.TargetSecondaryTenantName);
        public static TenantConfiguration DefaultTargetPremiumBlobTenant => GetTenantConfiguration("TargetPremiumBlobTenant", DefaultTestConfigurations.TargetPremiumBlobTenantName);
        public static TenantConfiguration DefaultTargetPreviewBlobTenant => GetTenantConfiguration("TargetPreviewBlobTenant", DefaultTestConfigurations.TargetPreviewBlobTenantName);
        public static TenantConfiguration DefaultTargetOAuthTenant => GetTenantConfiguration("OAuthTenant", DefaultTestConfigurations.TargetOAuthTenantName);

        public IEnumerable<TenantConfiguration> TenantConfigurations { get; private set; }

        /// <summary>
        /// Get the live test configuration for a specific tenant type, or
        /// stop running the test via Assert.Inconclusive if not found.
        /// </summary>
        /// <param name="type">
        /// The name of the tenant type (XML element) to get.
        /// </param>
        /// <param name="name">The name of the tenant.</param>
        /// <returns>
        /// The live test configuration for a specific tenant type.
        /// </returns>
        private static TenantConfiguration GetTenantConfiguration(string type, string name)
        {
            var config = DefaultTenantConfigurations.SingleOrDefault(c => c.TenantName == name);
            if (config == null)
            {
                Assert.Inconclusive($"Live test configuration tenant type '{type}' named '{name}' was not found in file {TestConfigurationsPath}!");
            }
            return config;
        }

        public static TestConfigurations ReadFromXml(XDocument testConfigurationsDoc)
            => ReadFromXml(testConfigurationsDoc.Element("TestConfigurations"));

        public static TestConfigurations ReadFromXml(XElement testConfigurationsElement)
            =>
                new TestConfigurations
                {
                    TargetTenantName = (string)testConfigurationsElement.Element("TargetTestTenant"),
                    TargetSecondaryTenantName = (string)testConfigurationsElement.Element("TargetSecondaryTestTenant"),
                    TargetPremiumBlobTenantName = (string)testConfigurationsElement.Element("TargetPremiumBlobTenant"),
                    TargetPreviewBlobTenantName = (string)testConfigurationsElement.Element("TargetPreviewBlobTenant"),
                    TargetOAuthTenantName = (string)testConfigurationsElement.Element("TargetOAuthTenant"),

                    TenantConfigurations =
                        testConfigurationsElement.Element("TenantConfigurations").Elements("TenantConfiguration")
                        .Select(
                            tenantConfigurationElement
                            =>
                            new TenantConfiguration
                            {
                                TenantName = (string)tenantConfigurationElement.Element("TenantName"),
                                AccountName = (string)tenantConfigurationElement.Element("AccountName"),
                                AccountKey = (string)tenantConfigurationElement.Element("AccountKey"),
                                BlobServiceEndpoint = (string)tenantConfigurationElement.Element("BlobServiceEndpoint"),
                                FileServiceEndpoint = (string)tenantConfigurationElement.Element("FileServiceEndpoint"),
                                QueueServiceEndpoint = (string)tenantConfigurationElement.Element("QueueServiceEndpoint"),
                                TableServiceEndpoint = (string)tenantConfigurationElement.Element("TableServiceEndpoint"),
                                BlobServiceSecondaryEndpoint = (string)tenantConfigurationElement.Element("BlobServiceSecondaryEndpoint"),
                                FileServiceSecondaryEndpoint = (string)tenantConfigurationElement.Element("FileServiceSecondaryEndpoint"),
                                QueueServiceSecondaryEndpoint = (string)tenantConfigurationElement.Element("QueueServiceSecondaryEndpoint"),
                                TableServiceSecondaryEndpoint = (string)tenantConfigurationElement.Element("TableServiceSecondaryEndpoint"),
                                TenantType = (TenantType)Enum.Parse(typeof(TenantType), (string)tenantConfigurationElement.Element("TenantType"), true),
                                BlobSecurePortOverride = (string)tenantConfigurationElement.Element("BlobSecurePortOverride"),
                                FileSecurePortOverride = (string)tenantConfigurationElement.Element("FileSecurePortOverride"),
                                QueueSecurePortOverride = (string)tenantConfigurationElement.Element("QueueSecurePortOverride"),
                                TableSecurePortOverride = (string)tenantConfigurationElement.Element("TableSecurePortOverride"),
                                ActiveDirectoryApplicationId = (string)tenantConfigurationElement.Element("ActiveDirectoryApplicationId"),
                                ActiveDirectoryApplicationSecret = (string)tenantConfigurationElement.Element("ActiveDirectoryApplicationSecret"),
                                ActiveDirectoryTenantId = (string)tenantConfigurationElement.Element("ActiveDirectoryTenantId"),
                                ActiveDirectoryAuthEndpoint = (string)tenantConfigurationElement.Element("ActiveDirectoryAuthEndpoint"),
                                ConnectionString = 
                                    !String.IsNullOrWhiteSpace((string)tenantConfigurationElement.Element("ConnectionString"))
                                    ? (string)tenantConfigurationElement.Element("ConnectionString")
                                    : new StorageConnectionString(
                                        storageCredentials: new SharedKeyCredentials(
                                            accountName: (string)tenantConfigurationElement.Element("AccountName"),
                                            accountKey: (string)tenantConfigurationElement.Element("AccountKey")
                                            ),
                                        blobStorageUri: (GetUriOrDefault((string)tenantConfigurationElement.Element("BlobServiceEndpoint")), GetUriOrDefault((string)tenantConfigurationElement.Element("BlobServiceSecondaryEndpoint"))),
                                        fileStorageUri: (GetUriOrDefault((string)tenantConfigurationElement.Element("FileServiceEndpoint")), GetUriOrDefault((string)tenantConfigurationElement.Element("FileServiceSecondaryEndpoint"))),
                                        queueStorageUri: (GetUriOrDefault((string)tenantConfigurationElement.Element("QueueServiceEndpoint")), GetUriOrDefault((string)tenantConfigurationElement.Element("QueueServiceSecondaryEndpoint"))),
                                        tableStorageUri: (GetUriOrDefault((string)tenantConfigurationElement.Element("TableServiceEndpoint")), GetUriOrDefault((string)tenantConfigurationElement.Element("TableServiceSecondaryEndpoint")))
                                        ).ToString(exportSecrets: true)
                            }
                            )
                            .ToArray()
                };

        static Uri GetUriOrDefault(string uriString)
            => !String.IsNullOrWhiteSpace(uriString)
            ? new Uri(uriString)
            : default;
    }
}
