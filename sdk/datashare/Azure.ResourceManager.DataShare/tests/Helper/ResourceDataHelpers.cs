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
using Azure.Core.TestFramework;

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
            Assert.That(r2.Name, Is.EqualTo(r1.Name));
            Assert.That(r2.Id, Is.EqualTo(r1.Id));
            Assert.That(r2.ResourceType, Is.EqualTo(r1.ResourceType));
        }

        public static void AssertTrackedResource(TrackedResourceData r1, TrackedResourceData r2)
        {
            Assert.That(r2.Name, Is.EqualTo(r1.Name));
            Assert.That(r2.Id, Is.EqualTo(r1.Id));
            Assert.That(r2.ResourceType, Is.EqualTo(r1.ResourceType));
        }

        #region Account
        public static void AssertAccount(DataShareAccountData account1, DataShareAccountData account2)
        {
            AssertTrackedResource(account1, account2);
            Assert.That(account2.CreatedOn, Is.EqualTo(account1.CreatedOn));
            Assert.That(account2.ProvisioningState, Is.EqualTo(account1.ProvisioningState));
            Assert.That(account2.UserName, Is.EqualTo(account1.UserName));
            Assert.That(account2.UserEmail, Is.EqualTo(account1.UserEmail));
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
            Assert.That(data2.Kind, Is.EqualTo(data1.Kind));
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
            Assert.That(data2.Kind, Is.EqualTo(data1.Kind));
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
            Assert.That(data2.TargetObjectId, Is.EqualTo(data1.TargetObjectId));
            Assert.That(data2.TargetActiveDirectoryId, Is.EqualTo(data1.TargetActiveDirectoryId));
            Assert.That(data2.TargetEmail, Is.EqualTo(data1.TargetEmail));
            Assert.That(data2.InvitationStatus, Is.EqualTo(data1.InvitationStatus));
            Assert.That(data2.InvitationId, Is.EqualTo(data1.InvitationId));
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
            Assert.That(data2.ShareSubscriptionStatus, Is.EqualTo(data1.ShareSubscriptionStatus));
            Assert.That(data2.SourceShareLocation, Is.EqualTo(data1.SourceShareLocation));
            Assert.That(data2.ShareName, Is.EqualTo(data1.ShareName));
            Assert.That(data2.ShareDescription, Is.EqualTo(data1.ShareDescription));
            Assert.That(data2.InvitationId, Is.EqualTo(data1.InvitationId));
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
            Assert.That(data2.Kind, Is.EqualTo(data1.Kind));
        }
        public static DataShareSynchronizationSettingData GetSynchronizationData(DateTimeOffset day )
        {
            var data = new ScheduledSynchronizationSetting(DataShareSynchronizationRecurrenceInterval.Day, day)
            {
            };
            return data;
        }
        #endregion

        #region Datashare
        public static void AssertShareData(DataShareData data1, DataShareData data2)
        {
            AssertResource(data1, data2);
            Assert.That(data2.UserName, Is.EqualTo(data1.UserName));
            Assert.That(data2.ShareKind, Is.EqualTo(data1.ShareKind));
            Assert.That(data2.Description, Is.EqualTo(data1.Description));
            Assert.That(data2.ProvisioningState, Is.EqualTo(data1.ProvisioningState));
            Assert.That(data2.UserEmail, Is.EqualTo(data1.UserEmail));
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
            Assert.That(data2.Kind, Is.EqualTo(data1.Kind));
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
