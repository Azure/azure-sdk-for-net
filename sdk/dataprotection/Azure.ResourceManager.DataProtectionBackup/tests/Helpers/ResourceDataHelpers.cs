// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.DataProtectionBackup.Models;
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

namespace Azure.ResourceManager.DataProtectionBackup.Tests.Helpers
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

        #region policy
        public static DataProtectionBackupPolicyData GetPolicyData()
        {
            IEnumerable<string> datasourcetypes = new List<string>()
            {
                "Microsoft.Compute/disks"
            };
            IEnumerable<string> repeating = new List<string>()
            {
                "R/2019-12-26T13:08:27.8535071Z/PT4H"
            };
            IEnumerable<DataProtectionBackupTaggingCriteria> taggingCriterias = new List<DataProtectionBackupTaggingCriteria>()
            {
                new DataProtectionBackupTaggingCriteria(true, 99, new DataProtectionBackupRetentionTag("Default"))
            };
            IEnumerable<DataProtectionBasePolicyRule> policyRules = new List<DataProtectionBackupRule>()
            {
                new DataProtectionBackupRule("sdktest", new DataStoreInfoBase(DataStoreType.OperationalStore, "DataStoreInfoBase"), new ScheduleBasedBackupTriggerContext(new DataProtectionBackupSchedule(repeating), taggingCriterias))
            };
            var data = new DataProtectionBackupPolicyData()
            {
                Properties = new RuleBasedBackupPolicy(datasourcetypes, policyRules)
            };
            return data;
        }
        #endregion
    }
}
