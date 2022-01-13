// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.Monitor.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Monitor;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using Azure.Core;

namespace Azure.ResourceManager.Monitor.Tests
{
    public static class ResourceDataHelper
    {
        private const string dummySSHKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQC+wWK73dCr+jgQOAxNsHAnNNNMEMWOHYEccp6wJm2gotpr9katuF/ZAdou5AaW1C61slRkHRkpRRX9FA9CYBiitZgvCCz+3nWNN7l/Up54Zps/pHWGZLHNJZRYyAB6j5yVLMVHIHriY49d/GZTZVNB8GoJv9Gakwc/fuEZYYl4YDFiGMBP///TzlI4jhiJzjKnEvqPFki5p2ZRJqcbCiF4pJrxUQR/RXqVFQdbRLZgYfJ8xGB878RENq3yQ39d8dVOkq4edbkzwcUmwwwkYVPIoDGsYLaRHnG+To7FvMeyO7xDVQkMKzopTQV8AuKpyvpqu0a9pWOMaiCyDytO7GGN you@me.com";

        // Temporary solution since the one in Azure.ResourceManager.AppService is internal
        public static IDictionary<string, string> ReplaceWith(this IDictionary<string, string> dest, IDictionary<string, string> src)
        {
            dest.Clear();
            foreach (var kv in src)
            {
                dest.Add(kv);
            }

            return dest;
        }

        public static void AssertTrackedResource(TrackedResource r1, TrackedResource r2)
        {
            Assert.AreEqual(r1.Name, r2.Name);
            Assert.AreEqual(r1.Id, r2.Id);
            Assert.AreEqual(r1.Type, r2.Type);
            Assert.AreEqual(r1.Location, r2.Location);
            Assert.AreEqual(r1.Tags, r2.Tags);
        }
        #region ActionGroup
        public static void AssertActionGroup(ActionGroupData group1, ActionGroupData group2)
        {
            AssertTrackedResource(group1, group2);
            Assert.AreEqual(group1.AzureFunctionReceivers, group2.AzureFunctionReceivers);
        }

        public static ActionGroupData GetBasicActionGroupData(AzureLocation location)
        {
            var data = new ActionGroupData(location)
            {
                EmailReceivers =
                {
                    new EmailReceiver("name", "a@b.c")
                },
                Enabled = true,
                GroupShortName = "name"
            };
            return data;
        }
        #endregion

        #region ActivityLogAlert
        public static void AssertActivityLogAlert(ActivityLogAlertData alert1, ActivityLogAlertData alert2)
        {
            AssertTrackedResource(alert1, alert2);
            Assert.AreEqual(alert1.Condition, alert2.Condition);
        }

        public static ActivityLogAlertData GetBasicActivityLogAlertData(AzureLocation location, string subID)
        {
            IEnumerable<ActivityLogAlertLeafCondition> allOf;
            allOf = new List<ActivityLogAlertLeafCondition>()
            {
                new ActivityLogAlertLeafCondition( "category", "Administrative"),
                new ActivityLogAlertLeafCondition( "level", "Error")
            };
            var data = new ActivityLogAlertData(location)
            {
                Scopes =
                {
                    subID
                },
                Condition = new ActivityLogAlertAllOfCondition(allOf),
                Actions =
                {
                    ActionGroups = {}
                }
            };
            return data;
        }
        #endregion
    }
}
