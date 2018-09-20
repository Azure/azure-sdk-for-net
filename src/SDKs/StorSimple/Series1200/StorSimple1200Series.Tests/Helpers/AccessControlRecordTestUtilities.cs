// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace StorSimple1200Series.Tests
{
    using System.Linq;

    using Microsoft.Azure.Management.StorSimple1200Series;
    using Microsoft.Azure.Management.StorSimple1200Series.Models;
    using Xunit;

    public static partial class TestUtilities
    {
        /// <summary>
        /// Initialzes AccessControlRecord instance
        /// </summary>
        /// <param name="accessControlRecord"></param>
        public static void Initialize(this AccessControlRecord accessControlRecord)
        {
            accessControlRecord.InitiatorName = "iqn.2017-06.com.contoso:ForTest";
        }

        /// <summary>
        /// Returns AccessControlRecord for given name
        /// </summary>
        /// <param name="client"></param>
        /// <param name="name"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="managerName"></param>
        /// <returns></returns>
        public static AccessControlRecord GetAccessControlRecord(
            StorSimpleManagementClient client,
            string name,
            string resourceGroupName,
            string managerName)
        {
            var acr = client.AccessControlRecords.Get(name, resourceGroupName, managerName);
            AccessControlRecord acrCreated = null;

            if (acr == null)
            {
                acr = new AccessControlRecord(client, resourceGroupName, managerName, name);
                acr.Initialize();
                acrCreated = acr.CreateOrUpdate();
                acrCreated.SetBaseResourceValues(client, resourceGroupName, managerName);
            }

            return acrCreated;
        }

        /// <summary>
        /// Create Or Updates a given AccessControlRecord
        /// </summary>
        /// <param name="acr"></param>
        /// <returns></returns>
        public static AccessControlRecord CreateOrUpdate(
            this AccessControlRecord acr)
        {
            var acrCreated = acr.Client.AccessControlRecords.CreateOrUpdate(
                acr.Name.GetDoubleEncoded(),
                acr,
                acr.ResourceGroupName,
                acr.ManagerName);

            Assert.True(acrCreated != null && acrCreated.Name.Equals(acr.Name) &&
                acrCreated.InitiatorName.Equals(acr.InitiatorName),
                "Creation of ACR failed in validation.");

            acrCreated.SetBaseResourceValues(acr.Client, acr.ResourceGroupName, acr.ManagerName);
            return acrCreated;
        }

        /// <summary>
        /// Deletes and validates deletion of the specified access control record.
        /// </summary>
        /// <param name="acr"></param>
        public static void Delete(this AccessControlRecord acr)
        {
            acr.Client.AccessControlRecords.Delete(
                acr.Name.GetDoubleEncoded(),
                acr.ResourceGroupName,
                acr.ManagerName);

            var accessControlRecords = acr.Client.AccessControlRecords.ListByManager(
                acr.ResourceGroupName,
                acr.ManagerName);

            var acrAfterDelete = accessControlRecords.FirstOrDefault(a => a.Name.Equals(acr.Name));

            Assert.True(acrAfterDelete == null, "Access control record deletion was not successful.");
        }
    }
}