// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.ResourceManager.KeyVault.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.KeyVault.Tests
{
    public static class Extensions
    {
        public static bool DictionaryEqual<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> first, IReadOnlyDictionary<TKey, TValue> second)
        {
            return first.DictionaryEqual(second, null);
        }

        public static bool DictionaryEqual<TKey, TValue>(
            this IReadOnlyDictionary<TKey, TValue> first, IReadOnlyDictionary<TKey, TValue> second,
            IEqualityComparer<TValue> valueComparer)
        {
            if (first == second)
                return true;
            if ((first == null) || (second == null))
                return false;
            if (first.Count != second.Count)
                return false;

            valueComparer = valueComparer ?? EqualityComparer<TValue>.Default;

            foreach (var kvp in first)
            {
                TValue secondValue;
                if (!second.TryGetValue(kvp.Key, out secondValue))
                    return false;
                if (!valueComparer.Equals(kvp.Value, secondValue))
                    return false;
            }
            return true;
        }

        public static bool DictionaryEqual<TKey, TValue>(this IDictionary<TKey, TValue> first, IDictionary<TKey, TValue> second)
        {
            return first.DictionaryEqual(second, null);
        }

        public static bool DictionaryEqual<TKey, TValue>(
            this IDictionary<TKey, TValue> first, IDictionary<TKey, TValue> second,
            IEqualityComparer<TValue> valueComparer)
        {
            if (first == second)
                return true;
            if ((first == null) || (second == null))
                return false;
            if (first.Count != second.Count)
                return false;

            valueComparer = valueComparer ?? EqualityComparer<TValue>.Default;

            foreach (var kvp in first)
            {
                TValue secondValue;
                if (!second.TryGetValue(kvp.Key, out secondValue))
                    return false;
                if (!valueComparer.Equals(kvp.Value, secondValue))
                    return false;
            }
            return true;
        }

        public static bool IsEqual(this DeletedKeyVaultResource deletedVault, KeyVaultData createdVault)
        {
            Assert.AreEqual(createdVault.Location, deletedVault.Data.Properties.Location);
            Assert.AreEqual(createdVault.Name, deletedVault.Data.Name);
            Assert.AreEqual(createdVault.Id, deletedVault.Data.Properties.VaultId);
            Assert.AreEqual("Microsoft.KeyVault/deletedVaults", deletedVault.Data.ResourceType);
            Assert.True(createdVault.Tags.DictionaryEqual(deletedVault.Data.Properties.Tags.ToDictionary(kvp => kvp.Key, kvp => kvp.Value)));
            Assert.NotNull(deletedVault.Data.Properties.ScheduledPurgeOn);
            Assert.NotNull(deletedVault.Data.Properties.DeletedOn);
            Assert.NotNull(deletedVault.Id);
            return true;
        }

        public static bool IsEqual(this ManagedHsmData vault1, ManagedHsmData vault2)
        {
            Assert.AreEqual(vault2.Location, vault1.Location);
            Assert.AreEqual(vault2.Name, vault1.Name);
            Assert.AreEqual(vault2.Id, vault1.Id);
            Assert.True(vault2.Tags.DictionaryEqual(vault1.Tags));

            Assert.AreEqual(vault2.Properties.HsmUri.ToString().TrimEnd('/'), vault1.Properties.HsmUri.ToString().TrimEnd('/'));
            Assert.AreEqual(vault2.Properties.TenantId, vault1.Properties.TenantId);
            Assert.AreEqual(vault2.Sku.Name, vault1.Sku.Name);
            Assert.AreEqual(vault2.Sku.Family, vault1.Sku.Family);
            Assert.AreEqual(vault2.Properties.EnableSoftDelete, vault1.Properties.EnableSoftDelete);
            //Assert.AreEqual(vault2.Properties.CreateMode, vault1.Properties.CreateMode);
            Assert.AreEqual(vault2.Properties.EnablePurgeProtection, vault1.Properties.EnablePurgeProtection);
            Assert.AreEqual(vault2.Properties.InitialAdminObjectIds, vault1.Properties.InitialAdminObjectIds);
            //Assert.AreEqual(vault2.Properties.PrivateEndpointConnections, vault1.Properties.PrivateEndpointConnections);
            Assert.AreEqual(vault2.Properties.PublicNetworkAccess, vault1.Properties.PublicNetworkAccess);
            //Assert.AreEqual(vault2.Properties.ScheduledPurgeDate, vault1.Properties.ScheduledPurgeDate);
            Assert.AreEqual(vault2.Properties.SoftDeleteRetentionInDays, vault1.Properties.SoftDeleteRetentionInDays);
            Assert.AreEqual(vault2.Properties.TenantId, vault1.Properties.TenantId);
            //Assert.True(vault2.Properties.NetworkAcls.IsEqual(vault1.Properties.NetworkAcls));
            return true;
        }

        public static bool IsEqual(this KeyVaultData vault1, KeyVaultData vault2)
        {
            Assert.AreEqual(vault2.Location, vault1.Location);
            Assert.AreEqual(vault2.Name, vault1.Name);
            Assert.AreEqual(vault2.Id, vault1.Id);
            Assert.True(vault2.Tags.DictionaryEqual(vault1.Tags));

            Assert.AreEqual(vault2.Properties.VaultUri.ToString().TrimEnd('/'), vault1.Properties.VaultUri.ToString().TrimEnd('/'));
            Assert.AreEqual(vault2.Properties.TenantId, vault1.Properties.TenantId);
            Assert.AreEqual(vault2.Properties.Sku.Name, vault1.Properties.Sku.Name);
            Assert.AreEqual(vault2.Properties.EnableSoftDelete, vault1.Properties.EnableSoftDelete);
            Assert.AreEqual(vault2.Properties.EnabledForTemplateDeployment, vault1.Properties.EnabledForTemplateDeployment);
            Assert.AreEqual(vault2.Properties.EnabledForDiskEncryption, vault1.Properties.EnabledForDiskEncryption);
            Assert.AreEqual(vault2.Properties.EnabledForDeployment, vault1.Properties.EnabledForDeployment);
            Assert.True(vault2.Properties.AccessPolicies.IsEqual(vault1.Properties.AccessPolicies));
            return true;
        }

        public static bool IsEqual(this IList<KeyVaultAccessPolicy> expected, IList<KeyVaultAccessPolicy> actual)
        {
            if (expected == null && actual == null)
                return true;

            if (expected == null || actual == null)
                return false;

            if (expected.Count != actual.Count)
                return false;

            KeyVaultAccessPolicy[] expectedCopy = new KeyVaultAccessPolicy[expected.Count];
            expected.CopyTo(expectedCopy, 0);

            foreach (KeyVaultAccessPolicy a in actual)
            {
                var match = expectedCopy.Where(e =>
                    e.TenantId == a.TenantId &&
                    e.ObjectId == a.ObjectId &&
                    e.ApplicationId == a.ApplicationId &&
                    ((a.Permissions.Secrets == null && e.Permissions.Secrets == null) ||
                        Enumerable.SequenceEqual(a.Permissions.Secrets, e.Permissions.Secrets)) &&
                    ((a.Permissions.Keys == null && e.Permissions.Keys == null) ||
                        Enumerable.SequenceEqual(a.Permissions.Keys, e.Permissions.Keys)) &&
                     ((a.Permissions.Certificates == null && e.Permissions.Certificates == null) ||
                      Enumerable.SequenceEqual(a.Permissions.Certificates, e.Permissions.Certificates)) &&
                    ((a.Permissions.Storage == null && e.Permissions.Storage == null) ||
                        Enumerable.SequenceEqual(a.Permissions.Storage, e.Permissions.Storage))
                    ).FirstOrDefault();
                if (match == null)
                    return false;

                expectedCopy = expectedCopy.Where(e => e != match).ToArray();
            }
            if (expectedCopy.Length > 0)
                return false;

            return true;
        }
    }
}
