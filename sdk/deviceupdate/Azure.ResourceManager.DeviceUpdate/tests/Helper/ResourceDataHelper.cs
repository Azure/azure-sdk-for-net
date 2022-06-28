// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.DeviceUpdate.Models;
using NUnit.Framework;
using Azure.Core;

namespace Azure.ResourceManager.DeviceUpdate.Tests.Helper
{
    public static class ResourceDataHelper
    {
        public static DeviceUpdateAccountData CreateAccountData()
        {
            var account = new DeviceUpdateAccountData(AzureLocation.WestUS2)
            {
                Sku = DeviceUpdateSku.Standard
            };
            return account;
        }

        public static DeviceUpdateInstanceData CreateInstanceData() => new DeviceUpdateInstanceData(AzureLocation.WestUS2);

        public static void AssertValidAccount(DeviceUpdateAccountResource model, DeviceUpdateAccountResource getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.ResourceType, getResult.Data.ResourceType);
            Assert.AreEqual(model.Data.Location, getResult.Data.Location);
            if (model.Data.Identity != null || getResult.Data.Identity != null)
            {
                Assert.NotNull(model.Data.Identity);
                Assert.NotNull(getResult.Data.Identity);
                Assert.AreEqual(model.Data.Identity.PrincipalId, getResult.Data.Identity.PrincipalId);
                Assert.AreEqual(model.Data.Identity.TenantId, getResult.Data.Identity.TenantId);
                Assert.AreEqual(model.Data.Identity.ManagedServiceIdentityType, getResult.Data.Identity.ManagedServiceIdentityType);
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

        public static void AssertValidInstance(DeviceUpdateInstanceResource model, DeviceUpdateInstanceResource getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.ResourceType, getResult.Data.ResourceType);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            Assert.AreEqual(model.Data.AccountName, getResult.Data.AccountName);
            for (int i = 0; i < model.Data.IotHubs.Count; ++i)
            {
                Assert.AreEqual(model.Data.IotHubs[i].ResourceId, getResult.Data.IotHubs[i].ResourceId);
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

        public static void AssertAccountUpdate(DeviceUpdateAccountResource updatedAccount, DeviceUpdateAccountPatch updateParameters)
        {
            Assert.AreEqual(updatedAccount.Data.Location, updateParameters.Location);
            if (updatedAccount.Data.Identity != null || updateParameters.Identity != null)
            {
                Assert.NotNull(updatedAccount.Data.Identity);
                Assert.NotNull(updateParameters.Identity);
                Assert.AreEqual(updatedAccount.Data.Identity.ManagedServiceIdentityType, updateParameters.Identity.ManagedServiceIdentityType);
            }
        }

        public static void AssertInstanceUpdate(DeviceUpdateInstanceResource updatedInstance, string key, string value)
        {
            Assert.GreaterOrEqual(updatedInstance.Data.Tags.Count, 1);
            Assert.IsTrue(updatedInstance.Data.Tags.ContainsKey(key));
            Assert.AreEqual(updatedInstance.Data.Tags[key], value);
        }
    }
}
