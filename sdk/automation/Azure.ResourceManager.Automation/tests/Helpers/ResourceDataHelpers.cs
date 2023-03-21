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
            Assert.AreEqual(r1.Name, r2.Name);
            Assert.AreEqual(r1.Id, r2.Id);
            Assert.AreEqual(r1.ResourceType, r2.ResourceType);
        }

        #region Credential
        public static void AssertCredential(AutomationCredentialData data1, AutomationCredentialData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.UserName, data2.UserName);
            Assert.AreEqual(data1.Description, data2.Description);
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
        public static void AssertDscConfiguration(DscConfigurationCreateOrUpdateContent data1, DscConfigurationCreateOrUpdateContent data2)
        {
            //AssertResource(data1, data2);
            Assert.AreEqual(data1.Location, data2.Location);
            Assert.AreEqual(data1.Description, data2.Description);
            //Assert.AreEqual(data1.State, data2.State);
            //Assert.AreEqual(data1.JobCount, data2.JobCount);
        }

        public static DscConfigurationCreateOrUpdateContent GetDscConfigurationData()
        {
            var data = new DscConfigurationCreateOrUpdateContent(new AutomationContentSource()
            {
                Hash = new AutomationContentHash("sha256", "A9E5DB56BA21513F61E0B3868816FDC6D4DF5131F5617D7FF0D769674BD5072F"),
                SourceType = AutomationContentSourceType.EmbeddedContent,
                Version = "1.0.0"
            })
            {
                Description= "new sample configuration test"
            };
            return data;
        }
        #endregion

        #region DscNodeConfigurationData
        public static void AssertDscNodeConfiguration(DscNodeConfigurationData data1, DscNodeConfigurationData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.ConfigurationName, data2.ConfigurationName);
            Assert.AreEqual(data1.Configuration, data2.Configuration);
            Assert.AreEqual(data1.Source, data2.Source);
            Assert.AreEqual(data1.NodeCount, data2.NodeCount);
        }

        public static DscNodeConfigurationCreateOrUpdateContent GetDscNodeConfigurationData()
        {
            var data = new DscNodeConfigurationCreateOrUpdateContent()
            {
                Source= new AutomationContentSource()
                {
                    Hash = new AutomationContentHash("sha256", "6DE256A57F01BFA29B88696D5E77A383D6E61484C7686E8DB955FA10ACE9FFE5"),
                    SourceType = AutomationContentSourceType.EmbeddedContent,
                    Version = "1.0.0"
                },
                Configuration = new DscConfigurationAssociationProperty()
                {
                    ConfigurationName = "SampleConfiguration"
                }
            };
            return data;
        }
        #endregion

        #region Runbook

        public static AutomationRunbookCreateOrUpdateContent GetRunbookData()
        {
            var data = new AutomationRunbookCreateOrUpdateContent(AutomationRunbookType.Script)
            {
            };
            return data;
        }
        #endregion
    }
}
