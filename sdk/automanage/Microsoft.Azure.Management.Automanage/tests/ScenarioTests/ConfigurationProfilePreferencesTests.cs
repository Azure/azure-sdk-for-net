// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
namespace Automanage.Tests.ScenarioTests
{
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using Automanage.Tests.Helpers;
    using Microsoft.Azure.Management.Automanage;
    using Microsoft.Azure.Management.Automanage.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;    
    using Xunit;
    using Xunit.Abstractions;

    public class ConfigurationProfilePreferencesTests : TestBase
    {
        private RecordedDelegatingHandler handler;
        private string vmName = "mynewamvmVM2";
        private string vmID = "/subscriptions/cdd53a71-7d81-493d-bce6-224fec7223a9/resourceGroups/mynewamvmVM_group/providers/Microsoft.Compute/virtualMachines/mynewamvmVM2";
        private string automanageAccountId = "/subscriptions/cdd53a71-7d81-493d-bce6-224fec7223a9/resourceGroups/AMVM-SubLib-017_group/providers/Microsoft.Automanage/accounts/AMVM-SubLib-017-ABP";
        public ConfigurationProfilePreferencesTests()
            : base()
        {
            handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void ConfigurationProfilesPreferencesListsPreferences()
        {
            var thisType = this.GetType();
            using (MockContext context = MockContext.Start(thisType))
            {
                var automanageClient = GetAutomanagementClient(context, handler);
                var actual = automanageClient.ConfigurationProfilePreferences.ListByResourceGroup("MYNEWAMVM3");
                Assert.NotNull(actual);                
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void ConfigurationProfilesPreferencesGetReturnsExpectedPreferences()
        {
            var thisType = this.GetType();
            using (MockContext context = MockContext.Start(thisType))
            {
                var automanageClient = GetAutomanagementClient(context, handler);
                var actual = automanageClient.ConfigurationProfilePreferences.Get("MyNewCustomPrefs", "MYNEWAMVM3");
                Assert.NotNull(actual);
            }
        }

        private ConfigurationProfilePreference GetAConfigurationProfilePreferenceObject()
        {
            var customAntiMalwareProps = new ConfigurationProfilePreferenceAntiMalware(
                enableRealTimeProtection: "True",
                exclusions: new[] { "C:\\temp", "notepad.exe" },
                scanType: "Quick",
                scanDay: "1",
                scanTimeInMinutes: "360");
            var vmBackupProps = new ConfigurationProfilePreferenceVmBackup("Pacific Standard Time", 14, null, null);

            var preferenceProperties = new ConfigurationProfilePreferenceProperties(
                vmBackup: vmBackupProps, antiMalware: customAntiMalwareProps);
            
            var thisAssignment = new ConfigurationProfilePreference(
                id: null,
                name: "default",
                location: "West US 2",
                properties: preferenceProperties);
            return thisAssignment;
        }
    }
}