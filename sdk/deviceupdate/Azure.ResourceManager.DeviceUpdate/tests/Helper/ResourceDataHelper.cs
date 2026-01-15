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
            Assert.That(getResult.Data.Name, Is.EqualTo(model.Data.Name));
            Assert.That(getResult.Data.Id, Is.EqualTo(model.Data.Id));
            Assert.That(getResult.Data.ResourceType, Is.EqualTo(model.Data.ResourceType));
            Assert.That(getResult.Data.Location, Is.EqualTo(model.Data.Location));
            if (model.Data.Identity != null || getResult.Data.Identity != null)
            {
                Assert.NotNull(model.Data.Identity);
                Assert.NotNull(getResult.Data.Identity);
                Assert.That(getResult.Data.Identity.PrincipalId, Is.EqualTo(model.Data.Identity.PrincipalId));
                Assert.That(getResult.Data.Identity.TenantId, Is.EqualTo(model.Data.Identity.TenantId));
                Assert.That(getResult.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(model.Data.Identity.ManagedServiceIdentityType));
                Assert.AreEqual(model.Data.Identity.UserAssignedIdentities.Count, getResult.Data.Identity.UserAssignedIdentities.Count);
                foreach (var kv in model.Data.Identity.UserAssignedIdentities)
                {
                    Assert.That(getResult.Data.Identity.UserAssignedIdentities.ContainsKey(kv.Key), Is.True);
                    Assert.That(getResult.Data.Identity.UserAssignedIdentities[kv.Key], Is.EqualTo(kv.Value));
                }
            }
            Assert.That(getResult.Data.ProvisioningState, Is.EqualTo(model.Data.ProvisioningState));
            Assert.That(getResult.Data.HostName, Is.EqualTo(model.Data.HostName));
            Assert.That(getResult.Data.PublicNetworkAccess, Is.EqualTo(model.Data.PublicNetworkAccess));
        }

        public static void AssertValidInstance(DeviceUpdateInstanceResource model, DeviceUpdateInstanceResource getResult)
        {
            Assert.That(getResult.Data.Name, Is.EqualTo(model.Data.Name));
            Assert.That(getResult.Data.Id, Is.EqualTo(model.Data.Id));
            Assert.That(getResult.Data.ResourceType, Is.EqualTo(model.Data.ResourceType));
            Assert.That(getResult.Data.ProvisioningState, Is.EqualTo(model.Data.ProvisioningState));
            Assert.That(getResult.Data.AccountName, Is.EqualTo(model.Data.AccountName));
            for (int i = 0; i < model.Data.IotHubs.Count; ++i)
            {
                Assert.That(getResult.Data.IotHubs[i].ResourceId, Is.EqualTo(model.Data.IotHubs[i].ResourceId));
            }
            Assert.That(getResult.Data.EnableDiagnostics, Is.EqualTo(model.Data.EnableDiagnostics));
            Assert.That(getResult.Data.AccountName, Is.EqualTo(model.Data.AccountName));
            if (model.Data.DiagnosticStorageProperties != null || getResult.Data.DiagnosticStorageProperties != null)
            {
                Assert.NotNull(model.Data.DiagnosticStorageProperties);
                Assert.NotNull(getResult.Data.DiagnosticStorageProperties);
                Assert.That(getResult.Data.DiagnosticStorageProperties.AuthenticationType, Is.EqualTo(model.Data.DiagnosticStorageProperties.AuthenticationType));
                Assert.That(getResult.Data.DiagnosticStorageProperties.ConnectionString, Is.EqualTo(model.Data.DiagnosticStorageProperties.ConnectionString));
                Assert.That(getResult.Data.DiagnosticStorageProperties.ResourceId, Is.EqualTo(model.Data.DiagnosticStorageProperties.ResourceId));
            }
        }

        public static void AssertAccountUpdate(DeviceUpdateAccountResource updatedAccount, DeviceUpdateAccountPatch updateParameters)
        {
            Assert.That(updateParameters.Location, Is.EqualTo(updatedAccount.Data.Location));
            if (updatedAccount.Data.Identity != null || updateParameters.Identity != null)
            {
                Assert.NotNull(updatedAccount.Data.Identity);
                Assert.NotNull(updateParameters.Identity);
                Assert.That(updateParameters.Identity.ManagedServiceIdentityType, Is.EqualTo(updatedAccount.Data.Identity.ManagedServiceIdentityType));
            }
        }

        public static void AssertInstanceUpdate(DeviceUpdateInstanceResource updatedInstance, string key, string value)
        {
            Assert.GreaterOrEqual(updatedInstance.Data.Tags.Count, 1);
            Assert.That(updatedInstance.Data.Tags.ContainsKey(key), Is.True);
            Assert.That(value, Is.EqualTo(updatedInstance.Data.Tags[key]));
        }
    }
}
