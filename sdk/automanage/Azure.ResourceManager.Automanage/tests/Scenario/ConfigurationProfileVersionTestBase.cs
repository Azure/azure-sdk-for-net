// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.ResourceManager.Automanage.Tests.Scenario
{
    internal class ConfigurationProfileVersionTestBase : AutomanageTestBase
    {
        public ConfigurationProfileVersionTestBase(bool async) : base(async) { }

        /// <summary>
        /// Creates a configuration profile version
        /// </summary>
        /// <param name="collection">Configruation profile version collection to perform actions against</param>
        /// <param name="versionName">Desired configuration profile version name</param>
        /// <returns>ConfigurationProfileVersionResource</returns>
        protected async Task<ConfigurationProfileVersionResource> CreateConfigurationProfileVersion(ConfigurationProfileVersionCollection collection, string versionName)
        {
            string configuration = "{" +
                "\"Antimalware/Enable\":true," +
                "\"Antimalware/EnableRealTimeProtection\":true," +
                "\"Antimalware/RunScheduledScan\":true," +
                "\"Backup/Enable\":true," +
                "\"WindowsAdminCenter/Enable\":false," +
                "\"VMInsights/Enable\":true," +
                "\"AzureSecurityCenter/Enable\":true," +
                "\"UpdateManagement/Enable\":true," +
                "\"ChangeTrackingAndInventory/Enable\":true," +
                "\"GuestConfiguration/Enable\":true," +
                "\"AutomationAccount/Enable\":true," +
                "\"LogAnalytics/Enable\":true," +
                "\"BootDiagnostics/Enable\":true" +
            "}";

            ConfigurationProfileData data = new ConfigurationProfileData(DefaultLocation)
            {
                Configuration = new BinaryData(configuration)
            };

            var newProfile = await collection.CreateOrUpdateAsync(WaitUntil.Completed, versionName, data);
            return newProfile.Value;
        }

        /// <summary>
        /// Asserts multiple values
        /// </summary>
        /// <param name="version">ConfigurationProfileVersionResource to assert</param>
        /// <param name="versionName">ConfigurationProfileVersionResource name to verify</param>
        protected void AssertValues(ConfigurationProfileVersionResource version, string versionName)
        {
            Assert.NotNull(version);
            Assert.True(version.HasData);
            Assert.AreEqual(versionName, version.Id.Name);
            Assert.NotNull(version.Id);
            Assert.NotNull(version.Data);
            Assert.NotNull(version.Data.Configuration);
        }
    }
}
