// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace StorSimple1200Series.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    using Microsoft.Azure.Management.StorSimple1200Series;
    using Microsoft.Azure.Management.StorSimple1200Series.Models;
    using System;

    public static partial class TestUtilities
    {
        /// <summary>
        /// Initializes StorageDomain instance
        /// </summary>
        /// <param name="storageDomain"></param>
        /// <param name="sacId"></param>
        public static void Initialize(this StorageDomain storageDomain, string sacId)
        {
            var storageAccountCredentialIds = string.IsNullOrEmpty(sacId) ? null : new List<string>() { sacId };

            // StorageDomain instance
            storageDomain.StorageAccountCredentialIds = storageAccountCredentialIds;
            storageDomain.EncryptionStatus = EncryptionStatus.Disabled;
            storageDomain.EncryptionKey = null; ;
        }

        /// <summary>
        /// Creates or updates StorageDomain
        /// </summary>
        /// <param name="storageDomain"></param>
        /// <returns></returns>
        public static StorageDomain CreateOrUpdate(this StorageDomain storageDomain)
        {
            // Create StorageDomain
            var storageDomainCreated = storageDomain.Client.StorageDomains.CreateOrUpdate(
                                storageDomain.Name.GetDoubleEncoded(),
                                storageDomain,
                                storageDomain.ResourceGroupName,
                                storageDomain.ManagerName);

            // Validate StorageDomain
            Assert.True(
                storageDomain.Name == storageDomainCreated.Name &&
                storageDomain.StorageAccountCredentialIds[0].Equals(
                    storageDomainCreated.StorageAccountCredentialIds[0]) &&
                storageDomain.EncryptionStatus == storageDomainCreated.EncryptionStatus,
                "Create of StorageDomain failed in validation");

            storageDomainCreated.SetBaseResourceValues(
                storageDomain.Client,
                storageDomainCreated.ResourceGroupName,
                storageDomainCreated.ManagerName);
            return storageDomainCreated;
        }

        /// <summary>
        /// Return storage domain
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sacId"></param>
        /// <param name="client"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="managerName"></param>
        /// <returns></returns>
        public static StorageDomain GetStorageDomain(
            string name,
            string sacId,
            StorSimpleManagementClient client,
            string resourceGroupName,
            string managerName)
        {

            var storageDomains = client.StorageDomains.ListByManager(resourceGroupName, managerName);
            StorageDomain storageDomain = null;

            if (storageDomains != null)
            {
                storageDomain = storageDomains.FirstOrDefault(s => 
                s.Name.Equals(
                    name, 
                    StringComparison.CurrentCultureIgnoreCase));
            }

            if (storageDomain == null)
            {
                var sdNew = new StorageDomain(
                    client, 
                    resourceGroupName, 
                    managerName,
                    name);
                sdNew.Initialize(sacId);
                storageDomain = sdNew.CreateOrUpdate();
            }

            storageDomain.SetBaseResourceValues(client, resourceGroupName, managerName);
            return storageDomain;
        }

        /// <summary>
        /// Return StorageDomain by Id
        /// </summary>
        /// <param name="storageDomainId"></param>
        /// <param name="client"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="managerName"></param>
        /// <returns></returns>
        public static StorageDomain GetStorageDomainById(
            string storageDomainId,
            StorSimpleManagementClient client,
            string resourceGroupName,
            string managerName)
        {

            var storageDomains = client.StorageDomains.ListByManager(resourceGroupName, managerName);
            StorageDomain storageDomain = null;

            if (storageDomains != null)
            {
                storageDomain = storageDomains.FirstOrDefault(s =>
                s.Id.Equals(
                    storageDomainId,
                    StringComparison.CurrentCultureIgnoreCase));
            }

            if (storageDomain == null)
            {
                storageDomain.SetBaseResourceValues(client, resourceGroupName, managerName);
            }

            return storageDomain;
        }

        /// <summary>
        /// Delete storage domain
        /// </summary>
        /// <param name="name"></param>
        /// <param name="client"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="managerName"></param>
        public static void DeleteStorageDomain(
            string name,
            StorSimpleManagementClient client,
            string resourceGroupName,
            string managerName)
        {
            var sdToDelete = client.StorageDomains.Get(
                name,
                resourceGroupName,
                managerName);

            client.StorageDomains.Delete(name, resourceGroupName, managerName);

            var sdsAfterDelete = client.StorageDomains.ListByManager(resourceGroupName, managerName);

            Assert.True(sdsAfterDelete.FirstOrDefault(f =>
                        f.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase)) == null,
                        "Failed to delete the StorageDomain" + name);
        }
    }
}