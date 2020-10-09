// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
namespace Automanage.Tests.ScenarioTests
{
    using System.Collections.Generic;
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
        
        public ConfigurationProfilePreferencesTests()
            : base()
        {
            handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void ConfigurationProfilesPreferencesCreatesAPreference()
        {
            var thisType = this.GetType();
            var pref = GetAConfigurationProfilePreferenceObject("myNewPref");
            using (MockContext context = MockContext.Start(thisType))
            {
                var automanageClient = GetAutomanagementClient(context, handler);
                var actual = automanageClient.ConfigurationProfilePreferences.CreateOrUpdate(pref.Name, "MYNEWAMVM3", pref);
                Assert.NotNull(actual);
            }
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

        private ConfigurationProfilePreference GetAConfigurationProfilePreferenceObject(string name)
        {                        
            //var exclusions = new Dictionary<string, string>(){
            //                      {"processes", "notepad.exe"},
            //                      {"extensions", "sql"},
            //                      {"paths", "c:\\temp\\"} };

            var customAntiMalwareProps = new ConfigurationProfilePreferenceAntiMalware(
                enableRealTimeProtection: "True",
                runScheduledScan: "True",
                exclusions: null,
                scanType: "Quick",
                scanDay: "1",
                scanTimeInMinutes: "360");            

            var preferenceProperties = new ConfigurationProfilePreferenceProperties(
                vmBackup: null, antiMalware: customAntiMalwareProps);
            
            var thisAssignment = new ConfigurationProfilePreference(
                id: null,
                name: name,
                location: "eastus",
                properties: preferenceProperties);
            return thisAssignment;
        }
    }
}