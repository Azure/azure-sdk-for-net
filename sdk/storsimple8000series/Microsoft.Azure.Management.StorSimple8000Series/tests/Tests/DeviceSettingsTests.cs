using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Azure.Management.StorSimple8000Series;
using Microsoft.Azure.Management.StorSimple8000Series.Models;

namespace StorSimple8000Series.Tests
{
    public class DeviceSettingsTests : StorSimpleTestBase
    {
        public DeviceSettingsTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        [Fact]
        public void TestDeviceSettingsOperationsOnConfiguredDevice()
        {
            var device = Helpers.CheckAndGetConfiguredDevice(this, TestConstants.DefaultDeviceName);
            var deviceName = device.Name;

            try
            {
                //Create Time Settings
                var timeSettings = CreateAndValidateTimeSettings(deviceName);

                //Create Alert Settings
                var alertSettings = CreateAndValidateAlertSettings(deviceName);

                //Create Network Settings
                var networkSettings = CreateAndValidateNetworkSettings(deviceName);

                //Create Security Settings
                var securitySettings = CreateAndValidateSecuritySettings(deviceName);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }
      
        [Fact]
        public void TestSyncRemoteManagementCertificateAPI()
        {
            var device = Helpers.CheckAndGetConfiguredDevice(this, TestConstants.DefaultDeviceName);
            var deviceName = device.Name;

            try
            {
                //update remote management settings
                RemoteManagementSettingsPatch remoteManagementSettings = 
                    new RemoteManagementSettingsPatch(RemoteManagementModeConfiguration.HttpsAndHttpEnabled);

                SecuritySettingsPatch securitySettingsPatch = new SecuritySettingsPatch()
                {
                    RemoteManagementSettings = remoteManagementSettings
                };

                this.Client.DeviceSettings.UpdateSecuritySettings(
                    deviceName.GetDoubleEncoded(),
                    securitySettingsPatch,
                    this.ResourceGroupName,
                    this.ManagerName);

                //sync remote management certificate between appliance and service
                this.Client.DeviceSettings.SyncRemotemanagementCertificate(
                    deviceName.GetDoubleEncoded(),
                    this.ResourceGroupName,
                    this.ManagerName);

                //validation
                var securitySettings = this.Client.DeviceSettings.GetSecuritySettings(
                    deviceName.GetDoubleEncoded(),
                    this.ResourceGroupName,
                    this.ManagerName);
                var remoteManagementCertificate = securitySettings.RemoteManagementSettings.RemoteManagementCertificate;
                Assert.True(!string.IsNullOrEmpty(remoteManagementCertificate), "Remote management certificate is not synced correctly.");
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        /// <summary>
        /// Create TimeSettings on the Device.
        /// </summary>
        private TimeSettings CreateAndValidateTimeSettings(string deviceName)
        {
            TimeSettings timeSettingsToCreate = new TimeSettings("Pacific Standard Time");
            timeSettingsToCreate.PrimaryTimeServer = "time.windows.com";
            timeSettingsToCreate.SecondaryTimeServer = new List<string>() { "8.8.8.8" };

            this.Client.DeviceSettings.CreateOrUpdateTimeSettings(
                    deviceName.GetDoubleEncoded(),
                    timeSettingsToCreate,
                    this.ResourceGroupName,
                    this.ManagerName);

            var timeSettings = this.Client.DeviceSettings.GetTimeSettings(
                deviceName.GetDoubleEncoded(),
                this.ResourceGroupName,
                this.ManagerName);

            //validation
            Assert.True(timeSettings != null && timeSettings.PrimaryTimeServer.Equals("time.windows.com") &&
                timeSettings.SecondaryTimeServer[0].Equals("8.8.8.8"), "Creation of Time Setting was not successful.");

            return timeSettings;
        }

        /// <summary>
        /// Create AlertSettings on the Device.
        /// </summary>
        private AlertSettings CreateAndValidateAlertSettings(string deviceName)
        {
            AlertSettings alertsettingsToCreate = new AlertSettings(AlertEmailNotificationStatus.Enabled);
            alertsettingsToCreate.AlertNotificationCulture = "en-US";
            alertsettingsToCreate.NotificationToServiceOwners = AlertEmailNotificationStatus.Enabled;

            alertsettingsToCreate.AdditionalRecipientEmailList = new List<string>();

            this.Client.DeviceSettings.CreateOrUpdateAlertSettings(
                    deviceName.GetDoubleEncoded(),
                    alertsettingsToCreate,
                    this.ResourceGroupName,
                    this.ManagerName);

            var alertSettings = this.Client.DeviceSettings.GetAlertSettings(
                deviceName.GetDoubleEncoded(),
                this.ResourceGroupName,
                this.ManagerName);

            //validation
            Assert.True(alertSettings != null && alertSettings.AlertNotificationCulture.Equals("en-US") &&
                alertSettings.EmailNotification.Equals(AlertEmailNotificationStatus.Enabled) &&
                alertSettings.NotificationToServiceOwners.Equals(AlertEmailNotificationStatus.Enabled), "Creation of Alert Setting was not successful.");

            return alertSettings;
        }

        /// <summary>
        /// Create NetworkSettings on the Device.
        /// </summary>
        private NetworkSettings CreateAndValidateNetworkSettings(string deviceName)
        {
            var networkSettingsBeforeUpdate = this.Client.DeviceSettings.GetNetworkSettings(
                deviceName.GetDoubleEncoded(),
				this.ResourceGroupName,
				this.ManagerName
            );
            
            DNSSettings dnsSettings = new DNSSettings();
            dnsSettings.PrimaryDnsServer = networkSettingsBeforeUpdate.DnsSettings.PrimaryDnsServer;
            dnsSettings.SecondaryDnsServers = new List<string>() { "8.8.8.8" };

            NetworkSettingsPatch networkSettingsPatch = new NetworkSettingsPatch();
            networkSettingsPatch.DnsSettings = dnsSettings;
            
            return this.Client.DeviceSettings.UpdateNetworkSettings(
                    deviceName.GetDoubleEncoded(),
                    networkSettingsPatch,
                    this.ResourceGroupName,
                    this.ManagerName);
        }

        /// <summary>
        /// Create SecuritySettings on the Device.
        /// </summary>
        private SecuritySettings CreateAndValidateSecuritySettings(string deviceName)
        {
            RemoteManagementSettingsPatch remoteManagementSettings = new RemoteManagementSettingsPatch(
                RemoteManagementModeConfiguration.HttpsAndHttpEnabled);
            AsymmetricEncryptedSecret deviceAdminpassword = this.Client.Managers.GetAsymmetricEncryptedSecret(
                this.ResourceGroupName,
                this.ManagerName,
                "test-adminp13");
            AsymmetricEncryptedSecret snapshotmanagerPassword = this.Client.Managers.GetAsymmetricEncryptedSecret(
                this.ResourceGroupName,
                this.ManagerName,
                "test-ssmpas1235");

            ChapSettings chapSettings = new ChapSettings(
                "test-initiator-user",
                this.Client.Managers.GetAsymmetricEncryptedSecret(this.ResourceGroupName, this.ManagerName, "chapsetInitP124"),
                "test-target-user",
                this.Client.Managers.GetAsymmetricEncryptedSecret(this.ResourceGroupName, this.ManagerName, "chapsetTargP1235"));

            SecuritySettingsPatch securitySettingsPatch = new SecuritySettingsPatch(
                remoteManagementSettings,
                deviceAdminpassword,
                snapshotmanagerPassword,
                chapSettings);

            this.Client.DeviceSettings.UpdateSecuritySettings(
                    deviceName.GetDoubleEncoded(),
                    securitySettingsPatch,
                    this.ResourceGroupName,
                    this.ManagerName);

            var securitySettings = this.Client.DeviceSettings.GetSecuritySettings(
                deviceName.GetDoubleEncoded(),
                this.ResourceGroupName,
                this.ManagerName);

            //validation
            Assert.True(securitySettings != null &&
                securitySettings.RemoteManagementSettings.RemoteManagementMode.Equals(RemoteManagementModeConfiguration.HttpsAndHttpEnabled) &&
                securitySettings.ChapSettings.InitiatorUser.Equals("test-initiator-user") &&
                securitySettings.ChapSettings.TargetUser.Equals("test-target-user"), "Creation of Security Setting was not successful.");

            return securitySettings;
        }
    }
}
