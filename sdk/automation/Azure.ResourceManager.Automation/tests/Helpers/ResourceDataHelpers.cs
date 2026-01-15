// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.Automation.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using Azure.Core;
using System;
using System.Text;
using Azure.ResourceManager.Resources;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using System.IO;

namespace Azure.ResourceManager.Automation.Tests.Helpers
{
    public static class ResourceDataHelpers
    {
        public static IDictionary<string, string> ReplaceWith(this IDictionary<string, string> dest, IDictionary<string, string> src)
        {
            dest.Clear();
            foreach (var kv in src)
            {
                dest.Add(kv);
            }

            return dest;
        }

        public static void AssertResource(ResourceData r1, ResourceData r2)
        {
            Assert.That(r2.Name, Is.EqualTo(r1.Name));
            Assert.That(r2.Id, Is.EqualTo(r1.Id));
            Assert.That(r2.ResourceType, Is.EqualTo(r1.ResourceType));
        }

        #region Credential
        public static void AssertCredential(AutomationCredentialData data1, AutomationCredentialData data2)
        {
            AssertResource(data1, data2);
            Assert.That(data2.UserName, Is.EqualTo(data1.UserName));
            Assert.That(data2.Description, Is.EqualTo(data1.Description));
        }

        public static AutomationCredentialCreateOrUpdateContent GetCredentialData(string name)
        {
            var data = new AutomationCredentialCreateOrUpdateContent(name, "userName1", "pwd1")
            {
                Description = "description of credential"
            };
            return data;
        }
        #endregion

        #region DscConfigurationData
        public static void AssertDscConfiguration(DscConfigurationData data1, DscConfigurationData data2)
        {
            AssertResource(data1, data2);
            Assert.That(data2.Location, Is.EqualTo(data1.Location));
            Assert.That(data2.Description, Is.EqualTo(data1.Description));
            Assert.That(data2.State, Is.EqualTo(data1.State));
            Assert.That(data2.JobCount, Is.EqualTo(data1.JobCount));
        }

        public static DscConfigurationCreateOrUpdateContent GetDscConfigurationData(string name)
        {
            var data = new DscConfigurationCreateOrUpdateContent(new AutomationContentSource()
            {
                Hash = new AutomationContentHash("sha256", "A9E5DB56BA21513F61E0B3868816FDC6D4DF5131F5617D7FF0D769674BD5072F"),
                Value = "Configuration "+name+@" { Node SampleConfiguration.localhost { WindowsFeature IIS { Name = ""Web - Server""; Ensure = ""Present""; }}}",
                SourceType = AutomationContentSourceType.EmbeddedContent,
                Version = "1.0.0"
            })
            {
                Description= "new sample configuration test",
                Location = AzureLocation.EastUS,
            };
            return data;
        }
        #endregion

        #region DscNodeConfigurationData
        public static void AssertDscNodeConfiguration(DscNodeConfigurationData data1, DscNodeConfigurationData data2)
        {
            AssertResource(data1, data2);
            Assert.That(data2.ConfigurationName, Is.EqualTo(data1.ConfigurationName));
            Assert.That(data2.Source, Is.EqualTo(data1.Source));
            Assert.That(data2.NodeCount, Is.EqualTo(data1.NodeCount));
        }

        public static DscNodeConfigurationCreateOrUpdateContent GetDscNodeConfigurationData(string dscconfigurationName)
        {
            var data = new DscNodeConfigurationCreateOrUpdateContent()
            {
                Name = "SampleConfiguration.localhost",
                Source = new AutomationContentSource()
                {
                    Hash = new AutomationContentHash("sha256", "6DE256A57F01BFA29B88696D5E77A383D6E61484C7686E8DB955FA10ACE9FFE5"),
                    Value = @"instance of MSFT_RoleResource as $MSFT_RoleResource1ref { ResourceID = ""[WindowsFeature]IIS""; Ensure = ""Present""; SourceInfo = ""::3::32::WindowsFeature""; Name = ""Web-Server""; ModuleName = ""PsDesiredStateConfiguration""; ModuleVersion = ""1.0""; ConfigurationName = ""SampleConfiguration""; }; instance of OMI_ConfigurationDocument { Version=""2.0.0""; MinimumCompatibleVersion = ""1.0.0""; CompatibleVersionAdditionalProperties= {""Omi_BaseResource:ConfigurationName""}; Author=""vameru""; GenerationDate=""03/30/2017 13:40:25""; GenerationHost=""VAMERU-BACKEND""; Name=""SampleConfiguration""; };",
                    SourceType = AutomationContentSourceType.EmbeddedContent,
                    Version = "1.0"
                },
                ConfigurationName = "SampleConfiguration",
                IsIncrementNodeConfigurationBuildRequired = false
            };
            return data;
        }
        #endregion

        #region Runbook

        public static AutomationRunbookCreateOrUpdateContent GetRunbookData()
        {
            var data = new AutomationRunbookCreateOrUpdateContent(AutomationRunbookType.Script)
            {
                Location = AzureLocation.EastUS
            };
            return data;
        }

        public static void AssertRunbook(AutomationRunbookData data1, AutomationRunbookData data2)
        {
            AssertResource(data1, data2);
            Assert.That(data2.Location, Is.EqualTo(data1.Location));
            Assert.That(data2.State, Is.EqualTo(data1.State));
            Assert.That(data2.Description, Is.EqualTo(data1.Description));
            Assert.That(data2.JobCount, Is.EqualTo(data1.JobCount));
        }
        #endregion

        #region SourceControl
        public static AutomationSourceControlCreateOrUpdateContent GetSourceControlData()
        {
            var data = new AutomationSourceControlCreateOrUpdateContent()
            {
                RepoUri = new Uri("https://dev.azure.com/vinkumar0563/_git/VinKumar-AzureAutomation"),
                Branch = "sdktest",
                FolderPath = "/Runbooks/PowershellScripts",
                IsAutoSyncEnabled = false,
                IsAutoPublishRunbookEnabled = true,
                SourceType = SourceControlSourceType.VsoGit,
                SecurityToken = new SourceControlSecurityTokenProperties()
                {
                    AccessToken = "stringfortoken",
                    TokenType = SourceControlTokenType.PersonalAccessToken
                },
                Description = "test creating a Source Control",
            };
            return data;
        }

        public static void AssertSourceControl(AutomationSourceControlData data1, AutomationSourceControlData data2)
        {
            AssertResource(data1, data2);
            Assert.That(data2.Description, Is.EqualTo(data1.Description));
            Assert.That(data2.Branch, Is.EqualTo(data1.Branch));
            Assert.That(data2.RepoUri, Is.EqualTo(data1.RepoUri));
            Assert.That(data2.FolderPath, Is.EqualTo(data1.FolderPath));
        }
        #endregion

        #region Variable
        public static AutomationVariableCreateOrUpdateContent GetVariableData(string name)
        {
            var data = new AutomationVariableCreateOrUpdateContent(name)
            {
                Value = "10",
                IsEncrypted = false,
            };
            return data;
        }

        public static void AssertVariable(AutomationVariableData data1, AutomationVariableData data2)
        {
            AssertResource(data1, data2);
            Assert.That(data2.Value, Is.EqualTo(data1.Value));
            Assert.That(data2.IsEncrypted, Is.EqualTo(data1.IsEncrypted));
            Assert.That(data2.CreatedOn, Is.EqualTo(data1.CreatedOn));
            Assert.That(data2.LastModifiedOn, Is.EqualTo(data1.LastModifiedOn));
            Assert.That(data2.Description, Is.EqualTo(data1.Description));
        }
        #endregion

        #region Schedule
        public static AutomationScheduleCreateOrUpdateContent GetScheduleData(string name, DateTimeOffset day)
        {
            var data = new AutomationScheduleCreateOrUpdateContent(name, day, AutomationScheduleFrequency.Hour)
            {
                Interval = BinaryData.FromString("1"),
            };
            return data;
        }

        public static void AssertSchedule(AutomationScheduleData data1, AutomationScheduleData data2)
        {
            AssertResource(data1, data2);
            Assert.That(data2.Frequency, Is.EqualTo(data1.Frequency));
            Assert.That(data2.Description, Is.EqualTo(data1.Description));
        }
        #endregion

        #region Account
        public static AutomationAccountCreateOrUpdateContent GetAccountData()
        {
            var data = new AutomationAccountCreateOrUpdateContent()
            {
                Sku = new AutomationSku("Basic"),
                Location = AzureLocation.EastUS
            };
            return data;
        }

        public static void AssertAccount(AutomationAccountData data1, AutomationAccountData data2)
        {
            AssertResource(data1, data2);
            Assert.That(data2.Location, Is.EqualTo(data1.Location));
            Assert.That(data2.Description, Is.EqualTo(data1.Description));
        }
        #endregion
    }
}
