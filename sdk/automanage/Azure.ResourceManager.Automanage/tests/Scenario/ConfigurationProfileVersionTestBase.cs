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
        protected async Task<AutomanageConfigurationProfileVersionResource> CreateConfigurationProfileVersion(AutomanageConfigurationProfileVersionCollection collection, string versionName)
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

            AutomanageConfigurationProfileData data = new AutomanageConfigurationProfileData(DefaultLocation)
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
        protected void AssertValues(AutomanageConfigurationProfileVersionResource version, string versionName)
        {
            Assert.That(version, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(version.HasData, Is.True);
                Assert.That(version.Id.Name, Is.EqualTo(versionName));
                Assert.That(version.Id, Is.Not.Null);
                Assert.That(version.Data, Is.Not.Null);
            });
            Assert.That(version.Data.Configuration, Is.Not.Null);
        }
    }
}
