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
            Assert.That(deletedVault.Data.Properties.Location, Is.EqualTo(createdVault.Location));
            Assert.That(deletedVault.Data.Name, Is.EqualTo(createdVault.Name));
            Assert.That(deletedVault.Data.Properties.VaultId, Is.EqualTo(createdVault.Id));
            Assert.That(deletedVault.Data.ResourceType, Is.EqualTo("Microsoft.KeyVault/deletedVaults"));
            Assert.That(createdVault.Tags.DictionaryEqual(deletedVault.Data.Properties.Tags.ToDictionary(kvp => kvp.Key, kvp => kvp.Value)), Is.True);
            Assert.That(deletedVault.Data.Properties.ScheduledPurgeOn, Is.Not.Null);
            Assert.That(deletedVault.Data.Properties.DeletedOn, Is.Not.Null);
            Assert.That(deletedVault.Id, Is.Not.Null);
            return true;
        }

        public static bool IsEqual(this ManagedHsmData vault1, ManagedHsmData vault2)
        {
            Assert.That(vault1.Location, Is.EqualTo(vault2.Location));
            Assert.That(vault1.Name, Is.EqualTo(vault2.Name));
            Assert.That(vault1.Id, Is.EqualTo(vault2.Id));
            Assert.That(vault2.Tags.DictionaryEqual(vault1.Tags), Is.True);

            Assert.That(vault1.Properties.HsmUri.ToString().TrimEnd('/'), Is.EqualTo(vault2.Properties.HsmUri.ToString().TrimEnd('/')));
            Assert.That(vault1.Properties.TenantId, Is.EqualTo(vault2.Properties.TenantId));
            Assert.That(vault1.Sku.Name, Is.EqualTo(vault2.Sku.Name));
            Assert.That(vault1.Sku.Family, Is.EqualTo(vault2.Sku.Family));
            Assert.That(vault1.Properties.EnableSoftDelete, Is.EqualTo(vault2.Properties.EnableSoftDelete));
            //Assert.AreEqual(vault2.Properties.CreateMode, vault1.Properties.CreateMode);
            Assert.That(vault1.Properties.EnablePurgeProtection, Is.EqualTo(vault2.Properties.EnablePurgeProtection));
            Assert.That(vault1.Properties.InitialAdminObjectIds, Is.EqualTo(vault2.Properties.InitialAdminObjectIds));
            //Assert.AreEqual(vault2.Properties.PrivateEndpointConnections, vault1.Properties.PrivateEndpointConnections);
            Assert.That(vault1.Properties.PublicNetworkAccess, Is.EqualTo(vault2.Properties.PublicNetworkAccess));
            //Assert.AreEqual(vault2.Properties.ScheduledPurgeDate, vault1.Properties.ScheduledPurgeDate);
            Assert.That(vault1.Properties.SoftDeleteRetentionInDays, Is.EqualTo(vault2.Properties.SoftDeleteRetentionInDays));
            Assert.That(vault1.Properties.TenantId, Is.EqualTo(vault2.Properties.TenantId));
            //Assert.True(vault2.Properties.NetworkAcls.IsEqual(vault1.Properties.NetworkAcls));
            return true;
        }

        public static bool IsEqual(this KeyVaultData vault1, KeyVaultData vault2)
        {
            Assert.That(vault1.Location, Is.EqualTo(vault2.Location));
            Assert.That(vault1.Name, Is.EqualTo(vault2.Name));
            Assert.That(vault1.Id, Is.EqualTo(vault2.Id));
            Assert.That(vault2.Tags.DictionaryEqual(vault1.Tags), Is.True);

            Assert.That(vault1.Properties.VaultUri.ToString().TrimEnd('/'), Is.EqualTo(vault2.Properties.VaultUri.ToString().TrimEnd('/')));
            Assert.That(vault1.Properties.TenantId, Is.EqualTo(vault2.Properties.TenantId));
            Assert.That(vault1.Properties.Sku.Name, Is.EqualTo(vault2.Properties.Sku.Name));
            Assert.That(vault1.Properties.EnableSoftDelete, Is.EqualTo(vault2.Properties.EnableSoftDelete));
            Assert.That(vault1.Properties.EnabledForTemplateDeployment, Is.EqualTo(vault2.Properties.EnabledForTemplateDeployment));
            Assert.That(vault1.Properties.EnabledForDiskEncryption, Is.EqualTo(vault2.Properties.EnabledForDiskEncryption));
            Assert.That(vault1.Properties.EnabledForDeployment, Is.EqualTo(vault2.Properties.EnabledForDeployment));
            Assert.That(vault2.Properties.AccessPolicies.IsEqual(vault1.Properties.AccessPolicies), Is.True);
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
