// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace StorSimple1200Series.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Xunit;

    using Microsoft.Azure.Management.StorSimple1200Series;
    using Microsoft.Azure.Management.StorSimple1200Series.Models;
    using Microsoft.Rest.Azure.OData;

    public static partial class TestUtilities
    {
        public static void Initialize(
            this ChapSettings chapSettings)
        {
            chapSettings.Password = chapSettings.Client.Managers.GetAsymmetricEncryptedSecret(
                    chapSettings.ResourceGroupName,
                    chapSettings.ManagerName,
                    TestConstants.DefaultChapSettingPwd);
        }

        /// <summary>
        /// Creates ChapSettings
        /// </summary>
        /// <param name="chapSettings"></param>
        /// <param name="deviceName"></param>
        /// <returns></returns>
        public static ChapSettings CreateOrUpdate(
            this ChapSettings chapSettings,
            string deviceName)
        {
            var chapSettingsToReturn = chapSettings.Client.ChapSettings.CreateOrUpdate(
                deviceName,
                chapSettings.Name,
                chapSettings,
                chapSettings.ResourceGroupName,
                chapSettings.ManagerName);

            chapSettingsToReturn.SetBaseResourceValues(
                chapSettings.Client,
                chapSettings.ResourceGroupName,
                chapSettings.ManagerName);

            return chapSettings;
        }

        /// <summary>
        /// Returns ChapSettings given the device and chapuser name
        /// </summary>
        /// <param name="chapUserName"></param>
        /// <param name="deviceName"></param>
        /// <param name="client"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="managerName"></param>
        /// <returns></returns>
        public static ChapSettings GetChapSettings(
            string chapUserName,
            string deviceName,
            StorSimpleManagementClient client,
            string resourceGroupName,
            string managerName)
        {
            var chapSettings = client.ChapSettings.Get(deviceName, chapUserName, resourceGroupName, managerName);

            chapSettings.SetBaseResourceValues(
                client,
                resourceGroupName,
                managerName);

            return chapSettings;
        }

        /// <summary>
        /// Returns chap settings for the given device
        /// </summary>
        /// <param name="iscsiServer"></param>
        /// <param name="deviceName"></param>
        /// <returns></returns>
        public static IEnumerable<ChapSettings> GetChapSettings(
            this ISCSIServer iscsiServer,
            string deviceName)
        {
            var chapSettings = iscsiServer.Client.ChapSettings.ListByDevice(
                deviceName,
                iscsiServer.ResourceGroupName,
                iscsiServer.ManagerName);

            return chapSettings;
        }

        /// <summary>
        /// Deleted given chap name
        /// </summary>
        /// <param name="chapUserName"></param>
        /// <param name="deviceName"></param>
        /// <param name="client"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="managerName"></param>
        public static void DeleteChapSettings(
            string chapUserName,
            string deviceName,
            StorSimpleManagementClient client,
            string resourceGroupName,
            string managerName)
        {
            client.ChapSettings.Delete(deviceName, chapUserName, resourceGroupName, managerName);
        }
    }
}