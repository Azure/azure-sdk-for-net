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
    public static class DataResourceHelper
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
            Assert.AreEqual(account1.Identity, account2.Identity);
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

        #region Account
        public static void AssertMappingSet(ShareDataSetMappingData data1, ShareDataSetMappingData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.Identity, data2.Identity);
            Assert.AreEqual(data1.ProvisioningState, data2.ProvisioningState);
            Assert.AreEqual(data1.UserName, data2.UserName);
            Assert.AreEqual(data1.UserEmail, data2.UserEmail);
        }
        public static ShareDataSetMappingData GetSetMapping()
        {
            var data = new BlobDataSetMapping()
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
            var data = new BlobDataSet("ContainerName", @"apple.txt", "resourcegroupName", "storageactsample", "subscriptionId")
            {
            };
            return data;
        }
        #endregion

        #region invitation
        #endregion

        #region Subscription
        #endregion

        #region SynchronizationSetting
        #endregion

        #region Datashare
        #endregion

        #region Trigger
        #endregion
    }
}
