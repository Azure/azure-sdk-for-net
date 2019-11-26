// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace StorSimple1200Series.Tests
{
    using System.Collections.Generic;
    using System.Security.Cryptography.X509Certificates;
    using System;

    using Microsoft.Azure.Management.StorSimple1200Series;
    using Microsoft.Azure.Management.StorSimple1200Series.Models;
    using Microsoft.Rest.Azure.OData;
    using Microsoft.Rest.Azure;

    public static partial class TestUtilities
    {
        /// <summary>
        /// Initializes instance Manager
        /// </summary>
        /// <param name="manager"></param>
        public static void Initialize(this Manager manager)
        {
            manager.Location = "westus";
            manager.CisIntrinsicSettings = new ManagerIntrinsicSettings()
            {
                Type = ManagerType.HelsinkiV1
            };
        }

        /// <summary>
        /// Create or updates given Manager
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="client"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns></returns>
        public static Manager CreateOrUpdate(
            this Manager manager,
            StorSimpleManagementClient client,
            string resourceGroupName)
        {
            client.Managers.CreateOrUpdate(
                manager,
                resourceGroupName,
                manager.Name.GetDoubleEncoded());

            return client.Managers.Get(resourceGroupName, manager.Name);
        }

        /// <summary>
        /// Returns encryptionkey for a given manager name
        /// </summary>
        /// <param name="client"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="managerName"></param>
        /// <param name="channelEncryptionKey"></param>
        /// <returns></returns>
        public static SymmetricEncryptedSecret GetEncryptionKey(
                StorSimpleManagementClient client,
                string resourceGroupName,
                string managerName,
                out string channelEncryptionKey)
        {
            SymmetricEncryptedSecret encryptionKey = client.Managers.GetEncryptionKey(
                resourceGroupName,
                managerName.GetDoubleEncoded());
            channelEncryptionKey = CryptoHelper.DecryptStringAES(
                encryptionKey.Value,
                TestConstants.ChannelIntegrityKey);

            return encryptionKey;
        }

        /// <summary>
        /// Encrypts given secret
        /// </summary>
        /// <param name="secretInPlain"></param>
        /// <param name="encryptionKey"></param>
        /// <param name="channelEncryptionKey"></param>
        /// <returns></returns>
        public static AsymmetricEncryptedSecret EncryptSecret(
            string secretInPlain,
            SymmetricEncryptedSecret encryptionKey,
            string channelEncryptionKey)
        {
            return new AsymmetricEncryptedSecret()
            {
                Value = CryptoHelper.EncryptSecretRSAPKCS(secretInPlain, channelEncryptionKey),
                EncryptionCertificateThumbprint = encryptionKey.ValueCertificateThumbprint
            };
        }

        /// <summary>
        /// Returns manager given a manager name
        /// </summary>
        /// <param name="client"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="managerName"></param>
        /// <returns></returns>
        public static Manager GetManager(
            StorSimpleManagementClient client,
            string resourceGroupName, 
            string managerName)
        {
            return client.Managers.Get(resourceGroupName, managerName.GetDoubleEncoded());
        }

        /// <summary>
        /// Returns managers list for given subscription
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IEnumerable<Manager> ListManagerBySubscription(
            StorSimpleManagementClient client)
        {
            var managers = client.Managers.List();
            return managers;
        }

        /// <summary>
        /// Returns Managers for a given resourcegroup
        /// </summary>
        /// <param name="client"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns></returns>
        public static IEnumerable<Manager> ListManagerByResourceGroup(
            StorSimpleManagementClient client,
            string resourceGroupName)
        {
            var managers = client.Managers.ListByResourceGroup(resourceGroupName);
            return managers;
        }

        /// <summary>
        /// Gets and updates extended info of a given manager
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>
        public static ManagerExtendedInfo GetAndUpdateExtendedInfo(
            this Manager manager,
            StorSimpleManagementClient client,
            string resourceGroupName)
        {
            var extendedInfo = client.Managers.GetExtendedInfo(
                resourceGroupName,
                manager.Name.GetDoubleEncoded());

            extendedInfo.Algorithm = "SHA256";
            string ifMatchETag = extendedInfo.Etag;

            var updatedExtndedInfo =  client.Managers.UpdateExtendedInfo(
                extendedInfo,
                resourceGroupName,
                manager.Name.GetDoubleEncoded(),
                ifMatchETag);

            updatedExtndedInfo.SetBaseResourceValues(
                client,
                resourceGroupName,
                manager.Name.GetDoubleEncoded());

            return updatedExtndedInfo;
        }

        /// <summary>
        /// Deletes the manager-extendedInfo for the specified StorSimple Manager.
        /// </summary>
        public static void DeleteExtendedInfo(
            this Manager manager,
            StorSimpleManagementClient client,
            string resourceGroupName)
        {
            client.Managers.DeleteExtendedInfoWithHttpMessagesAsync(
                resourceGroupName, 
                manager.Name);
        }

        /// <summary>
        /// Deletes the specified StorSimple Manager and validates deletion.
        /// </summary>
        public static void Delete(
            this Manager manager, 
            StorSimpleManagementClient client,
            string resourceGroupName)
        {
            var managerToDelete = client.Managers.Get(
                resourceGroupName,
                manager.Name.GetDoubleEncoded());

            client.Managers.DeleteWithHttpMessagesAsync(
               resourceGroupName,
               managerToDelete.Name);
        }

        /// <summary>
        /// Returns devices in a given manager
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>
        public static IEnumerable<Device> ListDevices(
            this Manager manager,
            StorSimpleManagementClient client,
            string resourceGroupName)
        {
            var devices = client.Devices.ListByManager(
                resourceGroupName,
                manager.Name.GetDoubleEncoded());

            if (devices != null)
            {
                foreach (var device in devices)
                {
                    device.SetBaseResourceValues(
                        client,
                        resourceGroupName,
                        manager.Name);
                }
            }

            return devices;
        }

        #region Metrics

        /// <summary>
        /// Returns metrics definitions of a given manager
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>
        public static IEnumerable<MetricDefinition> GetMetricDefinitions(
            this Manager manager,
            StorSimpleManagementClient client,
            string resourceGroupName)
        {
            return client.Managers.ListMetricDefinition(
                resourceGroupName,
                manager.Name.GetDoubleEncoded());
        }

        /// <summary>
        /// Returns metrics of a given manager
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="odataQuery"></param>
        /// <returns></returns>
        public static IEnumerable<Metrics> GetMetrics(
            this Manager manager,
            StorSimpleManagementClient client,
            string resourceGroupName,
            ODataQuery<MetricFilter> odataQuery)
        {
            return client.Managers.ListMetrics(
                resourceGroupName,
                manager.Name.GetDoubleEncoded(),
                odataQuery);
        }

        #endregion Metrics

        #region Jobs
        /// <summary>
        /// Returns jobs for a given manager
        /// </summary>
        /// <param name="client"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="managerName"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static IEnumerable<Job> GetJobsByManager(
            StorSimpleManagementClient client,
            string resourceGroupName,
            string managerName,
            ODataQuery<JobFilter> filter)
        {
            return client.Jobs.ListByManager(resourceGroupName, managerName, filter);
        }

        /// <summary>
        /// Returns job for a given name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="deviceName"></param>
        /// <param name="client"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="managerName"></param>
        /// <returns></returns>
        public static Job GetJob(
            string name,
            string deviceName,
            StorSimpleManagementClient client,
            string resourceGroupName,
            string managerName)
        {
            return client.Jobs.Get(deviceName, name, resourceGroupName, managerName);
        }
        #endregion

        #region Deactivate and Delete

        /// <summary>
        /// Deactivates a given device
        /// </summary>
        /// <param name="client"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="managerName"></param>
        /// <param name="deviceName"></param>
        public static void DeactivateDevice(
            StorSimpleManagementClient client,
            string resourceGroupName,
            string managerName,
            string deviceName)
        {
            client.Devices.Deactivate(deviceName.GetDoubleEncoded(), resourceGroupName, managerName);
        }

        /// <summary>
        /// Deactivates a given device
        /// </summary>
        /// <param name="client"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="managerName"></param>
        /// <param name="deviceName"></param>
        public static void DeleteDevice(
            StorSimpleManagementClient client,
            string resourceGroupName,
            string managerName,
            string deviceName)
        {
            client.Devices.Delete(deviceName.GetDoubleEncoded(), resourceGroupName, managerName);
        }

        #endregion

        #region Private methods

        private static UploadCertificateResponse UploadVaultCertificate(
            StorSimpleManagementClient client,
            string resourceGroupName,
            string resourceName, 
            X509Certificate2 cert)
        {
            var request = new UploadCertificateRequest();
            request.AuthType = AuthType.AzureActiveDirectory;
            request.Certificate = Convert.ToBase64String(cert.RawData);

            var response = client.Managers.UploadRegistrationCertificate(
                "HelsinkiAutoCert", 
                request,
                resourceGroupName, 
                resourceName);

            return response;
        }

        #endregion Private methods
    }
}
