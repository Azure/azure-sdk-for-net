namespace StorSimple1200Series.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.Azure.Management.StorSimple1200Series;
    using Microsoft.Azure.Management.StorSimple1200Series.Models;
    using Microsoft.Rest;
    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    /// Class represents Device settings tests
    /// </summary>
    public class DeviceSettingsTests : StorSimpleTestBase
    {
        #region Constructor
        public DeviceSettingsTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }
        #endregion Constructor

        #region Test methods

        /// <summary>
        /// Test method to configure device
        /// </summary>
        [Fact]
        public void TestDeviceSettings()
        {
            //Check if atleast a device is registered to the manager.
            var devices = Helpers.CheckAndGetDevicesByStatus(this, DeviceStatus.ReadyToSetup, 1);

            Assert.True(devices != null && devices.FirstOrDefault() != null,
                    "No devices were found to be registered in the manger:" + this.ManagerName);

            // Get the first device
            Device device = devices.FirstOrDefault();

            try
            {
                //Validate get Time Settings
                ValidateGetTimeSettings(device.Name);

                //Validate create or update Alert Settings
                ValidateCreateOrUpdateAlertSettings(device.Name);

                //Validate get Network Settings
                ValidateGetNetworkSettings(device.Name);

                //Validate update Security Settings
                ValidateCreateOrUpdateSecuritySettings(device.Name);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        #endregion Test methods

        #region Private methods
        /// <summary>
        /// Get TimeSettings on the Device and validate.
        /// </summary>
        private void ValidateGetTimeSettings(string deviceName)
        {
            var timeSettings = this.Client.Devices.GetTimeSettings(
                deviceName.GetDoubleEncoded(),
                this.ResourceGroupName,
                this.ManagerName);

            Assert.True(timeSettings != null);

            //validation
            timeSettings.Validate();
        }

        /// <summary>
        /// Get AlertSettings on the Device and validate.
        /// </summary>
        private void ValidateCreateOrUpdateAlertSettings(string deviceName)
        {
            //set new alert settings on the device
            AlertSettings newAlertSettings = new AlertSettings(
                this.Client,
                this.ResourceGroupName,
                this.ManagerName,
                "default")
            {
                AlertNotificationCulture = "en-US",
                EmailNotification = AlertEmailNotificationStatus.Enabled,
                NotificationToServiceOwners = ServiceOwnersAlertNotificationStatus.Disabled,
                AdditionalRecipientEmailList = new List<string>() { "testuser@abc.com" },
            };

            // Update devices Alert Settings
            this.Client.Devices.CreateOrUpdateAlertSettings(
                    deviceName.GetDoubleEncoded(),
                    newAlertSettings,
                    this.ResourceGroupName,
                    this.ManagerName);

            // Retrive the updated alert settings
            var alertSettings = this.Client.Devices.GetAlertSettings(
                deviceName.GetDoubleEncoded(),
                this.ResourceGroupName,
                this.ManagerName);

            //validation
            Assert.True(
                alertSettings != null &&
                (0 == string.Compare(
                    alertSettings.Name, newAlertSettings.Name, ignoreCase:true)) &&
                alertSettings.AlertNotificationCulture.Equals("en-US") &&
                alertSettings.EmailNotification.Equals(AlertEmailNotificationStatus.Enabled) &&
                alertSettings.NotificationToServiceOwners.Equals(ServiceOwnersAlertNotificationStatus.Disabled) &&
                (0 == string.Compare(
                    string.Join(",", alertSettings.AdditionalRecipientEmailList),
                    string.Join(",", newAlertSettings.AdditionalRecipientEmailList),
                    ignoreCase: true)),
                "Creation of Alert Setting was not successful.");
        }

        /// <summary>
        /// Get NetworkSettings on the Device and Validate.
        /// </summary>
        private void ValidateGetNetworkSettings(string deviceName)
        {
            var networkSettingsBeforeUpdate = this.Client.Devices.GetNetworkSettings(
                deviceName.GetDoubleEncoded(),
                this.ResourceGroupName,
                this.ManagerName
            );

            try
            {
                // Validate
                networkSettingsBeforeUpdate.Validate();
            }
            catch (ValidationException ex)
            {
                // Ignoring this error due to the change in the propertynames
                // as a result of swagger review
                if (ex.Rule != ValidationRules.CannotBeNull ||
                    ex.Target != "PrimaryDnsServer")
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Update SecuritySettings on the Device.
        /// </summary>
        private void ValidateCreateOrUpdateSecuritySettings(string deviceName)
        {
            AsymmetricEncryptedSecret deviceAdminpassword = 
                this.Client.Managers.GetAsymmetricEncryptedSecret(
                                this.ResourceGroupName,
                                this.ManagerName,
                                "test-adminp13");

            SecuritySettings newSecuritySettings = new SecuritySettings()
            {
                DeviceAdminPassword = deviceAdminpassword
            };

            // Update security settings for the given device
            this.Client.Devices.CreateOrUpdateSecuritySettings(
                deviceName.GetDoubleEncoded(),
                newSecuritySettings,
                this.ResourceGroupName,
                this.ManagerName);

            // No validation since there isn't GET Security Settings API
        }

        #endregion Private methods
    }
}
