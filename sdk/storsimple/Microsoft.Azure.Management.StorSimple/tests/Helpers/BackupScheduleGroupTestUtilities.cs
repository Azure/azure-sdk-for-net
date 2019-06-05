// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace StorSimple1200Series.Tests
{
    using System;
    using System.Linq;
    using Xunit;

    using Microsoft.Azure.Management.StorSimple1200Series;
    using Microsoft.Azure.Management.StorSimple1200Series.Models;


    public static partial class TestUtilities
    {
        /// <summary>
        /// Initialize given BackupScheduleGroup instance
        /// </summary>
        /// <param name="backupScheduleGroup"></param>
        public static void Initialize(this BackupScheduleGroup backupScheduleGroup)
        {
            // Create BackupScheduleGroup
            var currentDateTime = DateTime.Now.AddMinutes(100);
            var startTime = new Time(currentDateTime.Hour, currentDateTime.Minute);
            backupScheduleGroup.StartTime = startTime;
        }


        /// <summary>
        /// Helper method to CreateOrUpdate BackupScheduleGroup
        /// </summary>
        /// <param name="bsg"></param>
        /// <param name="deviceName"></param>
        /// <returns></returns>
        public static BackupScheduleGroup CreateOrUpdate(
            this BackupScheduleGroup bsg, 
            string deviceName)
        {
            // Create BackuScheduleGroup
            var bsgCreated = bsg.Client.BackupScheduleGroups.CreateOrUpdate(
                deviceName.GetDoubleEncoded(),
                bsg.Name.GetDoubleEncoded(),
                bsg,
                bsg.ResourceGroupName,
                bsg.ManagerName);

             bsgCreated.SetBaseResourceValues(
                bsg.Client,
                bsg.ResourceGroupName,
                bsg.ManagerName);
            return bsgCreated;
        }

        /// <summary>
        /// Returns BackupScheduleGroup for a given name
        /// </summary>
        /// <param name="deviceName"></param>
        /// <param name="name"></param>
        /// <param name="client"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="managerName"></param>
        /// <returns></returns>
        public static BackupScheduleGroup GetBackupScheduleGroup(
            string deviceName,
            string name,
            StorSimpleManagementClient client,
            string resourceGroupName,
            string managerName)
        {
            var bsgs = client.BackupScheduleGroups.ListByDevice(
                deviceName,
                resourceGroupName,
                managerName);

            BackupScheduleGroup bsg = null;

            if (bsgs != null)
            {
                bsg = bsgs.FirstOrDefault(b => 
                    b.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
            }

            if (bsg == null)
            {
                // Create new one for the device
                var bsgNew = new BackupScheduleGroup(
                    client,
                    resourceGroupName,
                    managerName,
                    name);
                bsgNew.Initialize();
                bsg = bsgNew.CreateOrUpdate(deviceName);
            }

            bsg.SetBaseResourceValues(client, resourceGroupName, managerName);
            return bsg;
        }

        /// <summary>
        /// Return BackupScheduleGroup give id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="deviceName"></param>
        /// <param name="client"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="managerName"></param>
        /// <returns></returns>
        public static BackupScheduleGroup GetBackupScheduleGroupById(
            string id,
            string deviceName,
            StorSimpleManagementClient client,
            string resourceGroupName,
            string managerName)
        {
            var bsgs = client.BackupScheduleGroups.ListByDevice(
                deviceName,
                resourceGroupName,
                managerName);

            BackupScheduleGroup bsg = null;

            if (bsgs != null)
            {
                bsg = bsgs.FirstOrDefault(b =>
                    b.Id.Equals(id, StringComparison.CurrentCultureIgnoreCase));
            }

            if (bsg != null)
            {
                bsg.SetBaseResourceValues(client, resourceGroupName, managerName);
            }

            return bsg;
        }

        /// <summary>
        /// Delete give BackupScheduleGroup
        /// </summary>
        /// <param name="name"></param>
        /// <param name="deviceName"></param>
        /// <param name="client"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="managerName"></param>
        public static void DeleteBackupScheduleGroup(
            string name,
            string deviceName,
            StorSimpleManagementClient client,
            string resourceGroupName,
            string managerName)
        {
            var bsg = client.BackupScheduleGroups.Get(
                deviceName,
                name,
                resourceGroupName,
                managerName);

            client.BackupScheduleGroups.Delete(deviceName, name, resourceGroupName, managerName);
        }
    }
}