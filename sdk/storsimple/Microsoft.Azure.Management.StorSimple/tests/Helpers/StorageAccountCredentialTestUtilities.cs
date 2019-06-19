// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace StorSimple1200Series.Tests
{
    using System.Linq;
    using Xunit;

    using Microsoft.Azure.Management.StorSimple1200Series;
    using Microsoft.Azure.Management.StorSimple1200Series.Models;
    using System;

    public static partial class TestUtilities
    {
        /// <summary>
        /// Initializes StorageAccountCredential instance
        /// </summary>
        /// <param name="sac"></param>
        public static void Initialize(this StorageAccountCredential sac)
        {
            sac.EndPoint = TestConstants.DefaultStorageAccountEndPoint;
            sac.EnableSSL = SslStatus.Enabled;
            sac.Login = TestConstants.TestSacLogin;
            sac.Location = "West US";
            sac.AccessKey = sac.Client.Managers.GetAsymmetricEncryptedSecret(
                    sac.ResourceGroupName,
                    sac.ManagerName,
                    TestConstants.TestSacAccessKey);
        }

        /// <summary>
        /// Creates or updates a StorageAccountCredential
        /// </summary>
        /// <param name="sac"></param>
        /// <returns></returns>
        public static StorageAccountCredential CreateOrUpdate(
            this StorageAccountCredential sac)
        {
            var sacCreated = sac.Client.StorageAccountCredentials.CreateOrUpdate(
                sac.Name.GetDoubleEncoded(),
                sac,
                sac.ResourceGroupName,
                sac.ManagerName);

            Assert.True(sacCreated != null && sacCreated.Name.Equals(sac.Name) &&
                        sacCreated.EnableSSL.Equals(SslStatus.Enabled) &&
                        sacCreated.EndPoint.Equals(sac.EndPoint),
                        "Creation of StorageAccountCredential failed in validation");

            sacCreated.SetBaseResourceValues(sac.Client, sac.ResourceGroupName, sac.ManagerName);
            return sacCreated;
        }

        /// <summary>
        /// Returns StorageAccountCredential given a name
        /// </summary>
        /// <param name="client"></param>
        /// <param name="name"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="managerName"></param>
        /// <returns></returns>
        public static StorageAccountCredential GetStorageAccountCredential(
            StorSimpleManagementClient client,
            string name,
            string resourceGroupName,
            string managerName)
        {
            StorageAccountCredential sac = null;

            try
            {
                sac = client.StorageAccountCredentials.Get(name, resourceGroupName, managerName);
            }
            catch (Exception)
            {
                // Since it's not present, create
                sac = new StorageAccountCredential(
                    client, 
                    resourceGroupName, 
                    managerName,
                    TestConstants.DefaultSacName);
                sac.Initialize();
                sac = sac.CreateOrUpdate();
            }

            sac.SetBaseResourceValues(client, resourceGroupName, managerName);
            return sac;
        }

        /// <summary>
        /// Deletes and validates deletion of the specified storage account credential.
        /// </summary>
        /// <param name="sac"></param>
        public static void Delete(this StorageAccountCredential sac)
        {
            sac.Client.StorageAccountCredentials.Delete(
                sac.Name.GetDoubleEncoded(),
                sac.ResourceGroupName,
                sac.ManagerName);

            var storageAccountCredentials = sac.Client.StorageAccountCredentials.ListByManager(
                sac.ResourceGroupName,
                sac.ManagerName);

            var sacAfterDelete = storageAccountCredentials.FirstOrDefault(s => 
                        s.Name.Equals(sac.Name));

            Assert.True(
                sacAfterDelete == null, 
                "Deletion of storage account credential was not successful.");
        }
    }
}