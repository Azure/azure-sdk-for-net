// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using NUnit.Framework;

namespace Azure.Storage.Test
{
    /// <summary>
    /// The TestConfigurations lazily loads the XML config file full of Azure
    /// Storage tenants to use when executing our tests.
    /// </summary>
    /// <remarks>
    /// The TestConfigurations file contains a fixed set of names and a
    /// variable list of TenantConfiguration definitions.  Each name refers to
    /// a tenant that supports certain functionality (i.e., the OAuth tenant
    /// needs to be setup for requests that use AD to authenticate).  It's
    /// possible that each name refers to a unique tenant, but it's also
    /// possible that multiple names will refer to the same tenant (i.e., if
    /// you want to use a Premium blob with OAuth enabled as your
    /// "TargetTestTenant", "TargetPremiumBlobTenant", and "TargetOAuthTenant"
    /// simultaneously).
    /// </remarks>
    public class TestConfigurations
    {
        /// <summary>
        /// Gets or sets a mapping of tenant names to definitions.  The
        /// Target*TenantName properties define the keys to use with this
        /// dictionary.  You should only access the tenants via the GetTenant
        /// method that will Assert.Inconclusive if the desired tenant wasn't
        /// defined in this configuration.
        /// </summary>
        private IDictionary<string, TenantConfiguration> Tenants { get; set; }

        /// <summary>
        /// Gets or sets a mapping of keyvault names to definitions.  The
        /// Target*TenantName properties define the keys to use with this
        /// dictionary.  You should only access the tenants via the GetTenant
        /// method that will Assert.Inconclusive if the desired tenant wasn't
        /// defined in this configuration.
        /// </summary>
        private IDictionary<string, KeyVaultConfiguration> KeyVaults { get; set; }

        /// <summary>
        /// Gets the name of the tenant in the Tenants dictionary to use by
        /// default for our tests.
        /// </summary>
        private string TargetTenantName { get; set; }

        /// <summary>
        /// Gets the name of the tenant in the Tenants dictionary to use for
        /// any tests that require Read Access Geo-Redundant Storage to be setup.
        /// </summary>
        private string TargetSecondaryTenantName { get; set; }

        /// <summary>
        /// Gets the name of the tenant in the Tenants dictionary to use for
        /// any tests that require Premium SSDs.
        /// </summary>
        private string TargetPremiumBlobTenantName { get; set; }

        /// <summary>
        /// Gets the name of the tenant in the Tenants dictionary to use for
        /// any tests that require preview features.
        /// </summary>
        private string TargetPreviewBlobTenantName { get; set; }

        /// <summary>
        /// Gets the name of the tenant in the Tenants dictionary to use for
        /// any tests that require authentication with Azure AD.
        /// </summary>
        private string TargetOAuthTenantName { get; set; }

        /// <summary>
        /// Gets the name of the tenant in the keyvaults dictionary to use for
        /// any tests that require integration with key vault.
        /// </summary>
        private string TargetKeyVaultName { get; set; }

        /// <summary>
        /// Gets the name of the tenant in the Tenants dictionary to use for
        /// any tests that require hierarchical namespace.
        /// </summary>
        private string TargetHierarchicalNamespaceTenantName { get; set; }

        /// <summary>
        /// Gets the name of the tenant in the Tenants dictionary to use for
        /// any tests that require managed disk
        /// </summary>
        private string TargetManagedDiskTenantName { get; set; }

        /// <summary>
        /// Gets the name of the tenant in the Tenants dictionary to use for
        /// any tests related to blob and container soft delete.
        /// </summary>
        private string TargetSoftDeleteTenantName { get; set; }

        /// <summary>
        /// Gets the tenant to use by default for our tests.
        /// </summary>
        public static TenantConfiguration DefaultTargetTenant =>
            GetTenant("TargetTestTenant", s_configurations.Value.TargetTenantName);

        /// <summary>
        /// Gets a tenant to use for any tests that require Read Access
        /// Geo-Redundant Storage to be setup.
        /// </summary>
        public static TenantConfiguration DefaultSecondaryTargetTenant =>
            GetTenant("TargetSecondaryTestTenant", s_configurations.Value.TargetSecondaryTenantName);

        /// <summary>
        /// Gets a tenant to use for any tests that require Premium SSDs.
        /// </summary>
        public static TenantConfiguration DefaultTargetPremiumBlobTenant =>
            GetTenant("TargetPremiumBlobTenant", s_configurations.Value.TargetPremiumBlobTenantName);

        /// <summary>
        /// Gets a tenant that uses preview features for tests that require it.
        /// </summary>
        public static TenantConfiguration DefaultTargetPreviewBlobTenant =>
            GetTenant("TargetPreviewBlobTenant", s_configurations.Value.TargetPreviewBlobTenantName);

        /// <summary>
        /// Gets a tenant to use for any tests that require authentication with
        /// Azure AD.
        /// </summary>
        public static TenantConfiguration DefaultTargetOAuthTenant =>
            GetTenant("TargetOAuthTenant", s_configurations.Value.TargetOAuthTenantName);

        /// <summary>
        /// Gets a keyvault to use for any tests that require keyvault access.
        /// </summary>
        public static KeyVaultConfiguration DefaultTargetKeyVault =>
            GetKeyVault("TargetKeyVault", s_configurations.Value.TargetKeyVaultName);

        /// <summary>
        /// Gets a tenant to use for any tests that require hierarchical namespace.
        /// </summary>
        public static TenantConfiguration DefaultTargetHierarchicalNamespaceTenant =>
            GetTenant("TargetHierarchicalNamespaceTenant", s_configurations.Value.TargetHierarchicalNamespaceTenantName);

        /// <summary>
        /// Gets a tenant to use for any tests that a managed disk account.
        /// </summary>
        public static TenantConfiguration DefaultTargetManagedDiskTenant =>
            GetTenant("TargetManagedDiskTenant", s_configurations.Value.TargetManagedDiskTenantName);


        /// <summary>
        /// Gets a tenant to use for any tests related to blob or container soft delete.
        /// </summary>
        public static TenantConfiguration DefaultTargetSoftDeleteTenant =>
            GetTenant("TargetBlobAndContainerSoftDeleteTenant", s_configurations.Value.TargetSoftDeleteTenantName);

        /// <summary>
        /// When loading our test configuration, we'll check the
        /// AZ_STORAGE_CONFIG_PATH first.
        /// </summary>
        private const string DefaultTestConfigPathEnvironmentVariable = @"AZ_STORAGE_CONFIG_PATH";

        /// <summary>
        /// When loading our test configuration, we'll check for a local file
        /// named TestConfigurations.xml second.
        /// </summary>
        private const string DefaultTestConfigFilePath = @"TestConfigurations.xml";

        /// <summary>
        /// Gets or sets the path of the file containing the live test
        /// configurations.  This is only used for throwing informative error
        /// messages to aid debugging configuration mishaps.
        /// </summary>
        private static string TestConfigurationsPath { get; set; }

        /// <summary>
        /// Lazily load the live test configuraions the first time they're
        /// required.
        /// </summary>
        private static readonly Lazy<TestConfigurations> s_configurations =
            new Lazy<TestConfigurations>(LoadTestConfigurations);

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
        private static TenantConfiguration GetTenant(string type, string name)
        {
            if (!s_configurations.Value.Tenants.TryGetValue(name, out TenantConfiguration config))
            {
                Assert.Inconclusive($"Live test configuration tenant type '{type}' named '{name}' was not found in file {TestConfigurationsPath}!");
            }
            return config;
        }

        /// <summary>
        /// Get the live test configuration for a specific key vault type, or
        /// stop running the test via Assert.Inconclusive if not found.
        /// </summary>
        /// <param name="type">
        /// The name of the key vault type (XML element) to get.
        /// </param>
        /// <param name="name">The name of the keyvault.</param>
        /// <returns>
        /// The live test configuration for a specific tenant type.
        /// </returns>
        private static KeyVaultConfiguration GetKeyVault(string type, string name)
        {
            if (!s_configurations.Value.KeyVaults.TryGetValue(name, out KeyVaultConfiguration config))
            {
                Assert.Inconclusive($"Live test configuration key vault type '{type}' named '{name}' was not found in file {TestConfigurationsPath}!");
            }
            return config;
        }

        /// <summary>
        /// Load the test configurations file from the path pointed to by the
        /// AZ_STORAGE_CONFIG_PATH environment variable or the local copy of
        /// the TestConfigurations.xml if present.  If we fail to find or load
        /// the test configurations, we'll stop running the test
        /// via Assert.Inconclusive.
        /// </summary>
        /// <returns>The test configurations.</returns>
        private static TestConfigurations LoadTestConfigurations()
        {
            // Get the live test configurations path
            TestConfigurationsPath = Environment.GetEnvironmentVariable(DefaultTestConfigPathEnvironmentVariable);
            if (string.IsNullOrEmpty(TestConfigurationsPath) || !File.Exists(TestConfigurationsPath))
            {
                TestConfigurationsPath = Path.Combine(TestContext.CurrentContext.TestDirectory, DefaultTestConfigFilePath);
                if (string.IsNullOrEmpty(TestConfigurationsPath) || !File.Exists(TestConfigurationsPath))
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
        }

        /// <summary>
        /// Parse the test configurations XML.
        /// </summary>
        /// <param name="doc">The root of the XML document.</param>
        /// <returns>The test configurations.</returns>
        private static TestConfigurations ReadFromXml(XDocument doc)
        {
            XElement config = doc.Element("TestConfigurations");
            string Get(string name) => (string)config.Element(name);
            return new TestConfigurations
            {
                TargetTenantName = Get("TargetTestTenant"),
                TargetSecondaryTenantName = Get("TargetSecondaryTestTenant"),
                TargetPremiumBlobTenantName = Get("TargetPremiumBlobTenant"),
                TargetPreviewBlobTenantName = Get("TargetPreviewBlobTenant"),
                TargetOAuthTenantName = Get("TargetOAuthTenant"),
                TargetKeyVaultName = Get("TargetKeyVault"),
                TargetHierarchicalNamespaceTenantName = Get("TargetHierarchicalNamespaceTenant"),
                TargetManagedDiskTenantName = Get("TargetManagedDiskTenant"),
                TargetSoftDeleteTenantName = Get("TargetBlobAndContainerSoftDeleteTenant"),
                Tenants =
                    config.Element("TenantConfigurations").Elements("TenantConfiguration")
                    .Select(TenantConfiguration.Parse)
                    .ToDictionary(tenant => tenant.TenantName),
                KeyVaults =
                    config.Element("KeyVaultConfigurations").Elements("KeyVaultConfiguration")
                    .Select(KeyVaultConfiguration.Parse)
                    .ToDictionary(keyvault => keyvault.VaultName)
            };
        }
    }
}
