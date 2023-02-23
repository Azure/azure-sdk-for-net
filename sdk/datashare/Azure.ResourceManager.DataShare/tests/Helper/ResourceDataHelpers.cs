// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.DataShare.Models;
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

namespace Azure.ResourceManager.DataShare.Tests.Helper
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

        public static void AssertTrackedResource(TrackedResourceData r1, TrackedResourceData r2)
        {
            Assert.AreEqual(r1.Name, r2.Name);
            Assert.AreEqual(r1.Id, r2.Id);
            Assert.AreEqual(r1.ResourceType, r2.ResourceType);
        }

        #region Account
        public static void AssertAccount(DataShareAccountData account1, DataShareAccountData account2)
        {
            AssertTrackedResource(account1, account2);
            Assert.AreEqual(account1.CreatedOn, account2.CreatedOn);
            Assert.AreEqual(account1.ProvisioningState, account2.ProvisioningState);
            Assert.AreEqual(account1.UserName, account2.UserName);
            Assert.AreEqual(account1.UserEmail, account2.UserEmail);
        }
        public static DataShareAccountData GetAccount()
        {
            var data = new DataShareAccountData(AzureLocation.EastUS, new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned))
            {
            };
            return data;
        }
        #endregion

        #region DataSetMapping
        public static void AssertMappingSet(ShareDataSetMappingData data1, ShareDataSetMappingData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.Kind, data2.Kind);
        }
        public static ShareDataSetMappingData GetSetMapping()
        {
            var data = new BlobDataSetMapping("C1", new Guid(), @"apple.txt", "resourcegroupName", "storageactsample", "0f3dcfc3-18f8-4099-b381-8353e19d43a7")
            {
            };
            return data;
        }
        #endregion

        #region DataSet
        public static void AssertDataSet(ShareDataSetData data1, ShareDataSetData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.Kind, data2.Kind);
        }
        public static ShareDataSetData GetDataSetData()
        {
            var data = new BlobDataSet("app-testapplication-1066-f068f8cd66e04b4da186b5bed0a34e96", @"apple.txt", "AutoRestResources2", "20220725datafactory", "db1ab6f0-4769-4b27-930e-01e2ef9c123c")
            {
            };
            return data;
        }
        #endregion

        #region invitation
        public static void AssertInvitationData(DataShareInvitationData data1, DataShareInvitationData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.TargetObjectId, data2.TargetObjectId);
            Assert.AreEqual(data1.TargetActiveDirectoryId, data2.TargetActiveDirectoryId);
            Assert.AreEqual(data1.TargetEmail, data2.TargetEmail);
            Assert.AreEqual(data1.InvitationStatus, data2.InvitationStatus);
            Assert.AreEqual(data1.InvitationId, data2.InvitationId);
        }
        public static DataShareInvitationData GetInvitationData()
        {
            var data = new DataShareInvitationData()
            {
                TargetActiveDirectoryId = "tenantId",
                TargetObjectId = "9c1d7b62-8746-48cf-b7d8-f1bda6d9efd0"
            };
            return data;
        }
        #endregion

        #region Subscription
        public static void AssertSubscriptionData(ShareSubscriptionData data1, ShareSubscriptionData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.ShareSubscriptionStatus, data2.ShareSubscriptionStatus);
            Assert.AreEqual(data1.SourceShareLocation, data2.SourceShareLocation);
            Assert.AreEqual(data1.ShareName, data2.ShareName);
            Assert.AreEqual(data1.ShareDescription, data2.ShareDescription);
            Assert.AreEqual(data1.InvitationId, data2.InvitationId);
        }
        public static ShareSubscriptionData GetSubscriptionData(Guid invitationId)
        {
            var data = new ShareSubscriptionData(invitationId, AzureLocation.EastUS)
            {
            };
            return data;
        }
        #endregion

        #region SynchronizationSetting
        public static void AssertSynchronizationData(DataShareSynchronizationSettingData data1, DataShareSynchronizationSettingData data2)
        {
            AssertResource(data1, data2);
        }
        public static DataShareSynchronizationSettingData GetSynchronizationData()
        {
            var data = new ScheduledSynchronizationSetting(DataShareSynchronizationRecurrenceInterval.Day, DateTime.Today.AddDays(1))
            {
            };
            return data;
        }
        #endregion

        #region Datashare
        public static void AssertShareData(DataShareData data1, DataShareData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.UserName, data2.UserName);
            Assert.AreEqual(data1.ShareKind, data2.ShareKind);
            Assert.AreEqual(data1.Description, data2.Description);
            Assert.AreEqual(data1.ProvisioningState, data2.ProvisioningState);
            Assert.AreEqual(data1.UserEmail, data2.UserEmail);
        }
        public static DataShareData GetShareData()
        {
            var data = new DataShareData()
            {
                ShareKind = DataShareKind.CopyBased
            };
            return data;
        }
        #endregion

        #region Trigger
        public static void AssertTriggerData(DataShareTriggerData data1, DataShareTriggerData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.Kind, data2.Kind);
        }
        public static DataShareTriggerData GetTriggerData()
        {
            var data = new ScheduledTrigger(DataShareSynchronizationRecurrenceInterval.Day, DateTime.Today)
            {
            };
            return data;
        }
        #endregion
    }
}
