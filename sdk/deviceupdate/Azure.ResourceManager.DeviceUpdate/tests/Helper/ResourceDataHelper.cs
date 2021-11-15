// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Collections.Generic;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.DeviceUpdate.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.DeviceUpdate.Tests.Helper
{
    public static class ResourceDataHelper
    {
        public static AccountData CreateAccountData() => new AccountData(Location.WestUS2);

        public static InstanceData CreateInstanceData() => new InstanceData(Location.WestUS2);

        public static void AssertValidAccount(Account model, Account getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
            Assert.AreEqual(model.Data.Location, getResult.Data.Location);
            if (model.Data.Identity != null || getResult.Data.Identity != null)
            {
                Assert.NotNull(model.Data.Identity);
                Assert.NotNull(getResult.Data.Identity);
                Assert.AreEqual(model.Data.Identity.PrincipalId, getResult.Data.Identity.PrincipalId);
                Assert.AreEqual(model.Data.Identity.TenantId, getResult.Data.Identity.TenantId);
                Assert.AreEqual(model.Data.Identity.Type, getResult.Data.Identity.Type);
                Assert.AreEqual(model.Data.Identity.UserAssignedIdentities.Count, getResult.Data.Identity.UserAssignedIdentities.Count);
                foreach (var kv in model.Data.Identity.UserAssignedIdentities)
                {
                    Assert.True(getResult.Data.Identity.UserAssignedIdentities.ContainsKey(kv.Key));
                    Assert.AreEqual(kv.Value, getResult.Data.Identity.UserAssignedIdentities[kv.Key]);
                }
            }
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            Assert.AreEqual(model.Data.HostName, getResult.Data.HostName);
            Assert.AreEqual(model.Data.PublicNetworkAccess, getResult.Data.PublicNetworkAccess);
        }

        public static void AssertValidInstance(Instance model, Instance getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            Assert.AreEqual(model.Data.AccountName, getResult.Data.AccountName);
            for (int i = 0; i < model.Data.IotHubs.Count; ++i)
            {
                Assert.AreEqual(model.Data.IotHubs[i].ResourceId, getResult.Data.IotHubs[i].ResourceId);
                Assert.AreEqual(model.Data.IotHubs[i].IoTHubConnectionString, getResult.Data.IotHubs[i].IoTHubConnectionString);
                Assert.AreEqual(model.Data.IotHubs[i].EventHubConnectionString, getResult.Data.IotHubs[i].EventHubConnectionString);
            }
            Assert.AreEqual(model.Data.EnableDiagnostics, getResult.Data.EnableDiagnostics);
            Assert.AreEqual(model.Data.AccountName, getResult.Data.AccountName);
            if (model.Data.DiagnosticStorageProperties != null || getResult.Data.DiagnosticStorageProperties != null)
            {
                Assert.NotNull(model.Data.DiagnosticStorageProperties);
                Assert.NotNull(getResult.Data.DiagnosticStorageProperties);
                Assert.AreEqual(model.Data.DiagnosticStorageProperties.AuthenticationType, getResult.Data.DiagnosticStorageProperties.AuthenticationType);
                Assert.AreEqual(model.Data.DiagnosticStorageProperties.ConnectionString, getResult.Data.DiagnosticStorageProperties.ConnectionString);
                Assert.AreEqual(model.Data.DiagnosticStorageProperties.ResourceId, getResult.Data.DiagnosticStorageProperties.ResourceId);
            }
        }

        public static void AssertAccountUpdate(Account updatedAccount, AccountUpdate updateParameters)
        {
            Assert.AreEqual(updatedAccount.Data.Tags.Count, updateParameters.Tags.Count);
            foreach (var kv in updatedAccount.Data.Tags)
            {
                Assert.True(updateParameters.Tags.ContainsKey(kv.Key));
                Assert.AreEqual(kv.Value, updateParameters.Tags[kv.Key]);
            }
        }

        public static void AssertInstanceUpdate(Instance updatedInstance, TagUpdate updateParameters)
        {
            foreach (var kv in updatedInstance.Data.Tags)
            {
                Assert.True(updateParameters.Tags.ContainsKey(kv.Key));
                Assert.AreEqual(kv.Value, updateParameters.Tags[kv.Key]);
            }
        }
    }
}
