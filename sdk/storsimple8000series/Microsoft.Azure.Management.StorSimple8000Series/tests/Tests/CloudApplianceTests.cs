using System;
using Microsoft.Azure.Management.StorSimple8000Series;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Network;
using System.Collections.Generic;
using Microsoft.Azure.Management.StorSimple8000Series.Models;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Compute.Models;
using System.Text;
using Xunit;
using System.Linq;
using Xunit.Abstractions;
using Microsoft.Rest.Azure;
using System.Threading;

namespace StorSimple8000Series.Tests
{
    public class CloudApplianceTests : StorSimpleTestBase
    {
        private const string DefaultModelNumber = "8020";
        protected ComputeManagementClient ComputeClient { get; set; }
        protected NetworkManagementClient NetworkClient { get; set; }

        public CloudApplianceTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            this.ComputeClient = this.Context.GetServiceClient<ComputeManagementClient>();
            this.NetworkClient = this.Context.GetServiceClient<NetworkManagementClient>();
        }

        [Fact]
        public void TestCreateStorSimpleCloudAppliance()
        {
            var deviceName = TestConstants.DeviceForSCATests;
            try
            {
                // Prepare
                // Get Activation Key, to be used as Device Registration Key for Cloud Appliance.
                var activationKey = this.Client.Managers.GetActivationKey(this.ResourceGroupName, this.ManagerName);

                // Get Cloud Appliance Configurations
                var configuration = this.GetScaConfigurationForModel();

                // Create Vnet if not exist already
                this.CreateDefaultVnetIfNotExist();

                // Act
                // Trigger Cloud Appliance creation Job
                var jobName = this.TriggerScaCreationAndReturnName(deviceName);

                //Create NIC required for VM creation
                var nicId = this.CreateNicAndReturnId(deviceName);

                //Create VM
                this.CreateVm(deviceName, activationKey.ActivationKey, nicId, configuration);

                // Validate                
                // Track job to completion on the basis of device status
                var device = this.TrackScaJobByDeviceStatus(deviceName);
                // Validate device status to be Ready to Setup
                Assert.NotNull(device);
                Assert.Equal(device.Status, DeviceStatus.ReadyToSetup);

                // Get job and validate if status is succeeded
                var job = this.Client.Jobs.Get(deviceName, jobName, this.ResourceGroupName, this.ManagerName);
                Assert.Equal(job.JobType, JobType.CreateCloudAppliance);
                Assert.Equal(job.Status, JobStatus.Succeeded);
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            finally
            {
                try
                {
                    // Deactivate device
                    this.Client.Devices.Deactivate(deviceName, this.ResourceGroupName, this.ManagerName);

                    // Delete device
                    this.Client.Devices.Delete(deviceName, this.ResourceGroupName, this.ManagerName);

                    // Delete VM
                    this.ComputeClient.VirtualMachines.Delete(this.ResourceGroupName, deviceName);

                    // Delete NIC
                    this.NetworkClient.NetworkInterfaces.Delete(this.ResourceGroupName, deviceName);
                }
                catch (Exception ex)
                {
                    Assert.True(false, ex.Message);
                }
            }
        }

        [Fact]
        public void TestConfigureCloudAppliance()
        {
            //checking for prerequisites
            var device = Helpers.CheckAndGetDevice(this, DeviceType.Series8000VirtualAppliance, DeviceStatus.ReadyToSetup);
            var deviceName = device.Name;

            //the service data encryption key from rollovered device
            var serviceDataEncryptionKey = "ZJOCJNA3k0g5WSHqskiMug==";

            try
            {
                // Device admin password and snapshot manager password
                AsymmetricEncryptedSecret deviceAdminpassword = this.Client.Managers.GetAsymmetricEncryptedSecret(this.ResourceGroupName, this.ManagerName, "test-adminp13");
                AsymmetricEncryptedSecret snapshotmanagerPassword = this.Client.Managers.GetAsymmetricEncryptedSecret(this.ResourceGroupName, this.ManagerName, "test-ssmpas1235");

                //cloud appliance settings
                CloudApplianceSettings cloudApplianceSettings = new CloudApplianceSettings();
                cloudApplianceSettings.ServiceDataEncryptionKey = EncryptSecretUsingDEK(this.ResourceGroupName, this.ManagerName, deviceName, serviceDataEncryptionKey);
                var managerExtendedInfo = this.Client.Managers.GetExtendedInfo(this.ResourceGroupName, this.ManagerName);
                cloudApplianceSettings.ChannelIntegrityKey = EncryptSecretUsingDEK(this.ResourceGroupName, this.ManagerName, deviceName, managerExtendedInfo.IntegrityKey);

                //security settings patch
                SecuritySettingsPatch securitySettingsPatch = new SecuritySettingsPatch()
                {
                    DeviceAdminPassword = deviceAdminpassword,
                    SnapshotPassword = snapshotmanagerPassword,
                    CloudApplianceSettings = cloudApplianceSettings
                };

                //update security settings - this will configure the SCA too.
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
                Assert.True(securitySettings != null, "Creation of Security Setting was not successful.");

                //validate that SCA got configured, by checking device is online now.
                Helpers.CheckAndGetConfiguredDevice(this, deviceName);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }


        [Fact]
        public void TestUpdateServiceDataEncryptionKeyOnCloudAppliance()
        {
            //checking for prerequisites
            var device = Helpers.CheckAndGetDevice(this, DeviceType.Series8000VirtualAppliance);
            var deviceName = device.Name;

            //the new service data encryption key from rollovered device
            var newServiceDataEncryptionKey = "ZJOCJNA3k0g5WSHqskiMug==";

            try
            {
                //cloud appliance settings
                CloudApplianceSettings cloudApplianceSettings = new CloudApplianceSettings();
                cloudApplianceSettings.ServiceDataEncryptionKey = EncryptSecretUsingDEK(this.ResourceGroupName, this.ManagerName, deviceName, newServiceDataEncryptionKey);
                var managerExtendedInfo = this.Client.Managers.GetExtendedInfo(this.ResourceGroupName, this.ManagerName);
                cloudApplianceSettings.ChannelIntegrityKey = EncryptSecretUsingDEK(this.ResourceGroupName, this.ManagerName, deviceName, managerExtendedInfo.IntegrityKey);

                //security settings patch
                SecuritySettingsPatch securitySettingsPatch = new SecuritySettingsPatch()
                {
                    CloudApplianceSettings = cloudApplianceSettings
                };

                //update security settings
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
                Assert.True(securitySettings != null, "Creation of Security Setting was not successful.");
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        #region Helper methods

        public Device TrackScaJobByDeviceStatus(string deviceName)
        {
            Device device = null;

            //wait till device status changes to 'ReadyToSetup' state
            while(true)
            {
                device = this.Client.Devices.Get(deviceName, this.ResourceGroupName, this.ManagerName);
                if (device != null && device.Status == DeviceStatus.ReadyToSetup)
                {
                    break;
                }

                //wait and then retry
                Thread.Sleep(DefaultWaitingTimeInMs);
            }

            return device;
        }

        protected string TriggerScaCreationAndReturnName(string name)
        {
            var cloudAppliance = new CloudAppliance()
            {
                Name = name,
                ModelNumber = DefaultModelNumber,
                VnetRegion = "West US" // hardcoding as no funcitonal significance
            };

            this.Client.CloudAppliances.BeginProvision(cloudAppliance, this.ResourceGroupName, this.ManagerName);

            // Only one job will be there for this device
            var deviceJobs = this.Client.Jobs.ListByDevice(name, this.ResourceGroupName, this.ManagerName);
            return deviceJobs.ElementAt(0).Name;
        }

        protected CloudApplianceConfiguration GetScaConfigurationForModel(string modelNumber = DefaultModelNumber)
        {
            var configurations = this.Client.CloudAppliances.ListSupportedConfigurations(this.ResourceGroupName, this.ManagerName);
            return configurations.FirstOrDefault(c => c.ModelNumber == modelNumber);
        }

        protected string CreateNicAndReturnId(string name, string vnetName = TestConstants.DefaultVirtualNetworkName, string subnetName = TestConstants.DefaultSubnetName)
        {
            var subnet = this.NetworkClient.Subnets.Get(this.ResourceGroupName, vnetName, subnetName);
            var availableIpAddress = this.NetworkClient.VirtualNetworks.CheckIPAddressAvailability(this.ResourceGroupName,
                vnetName, subnet.AddressPrefix.Split('/')[0]);
            var nic = this.NetworkClient.NetworkInterfaces.CreateOrUpdate(this.ResourceGroupName, name, new NetworkInterface()
            {
                Location = "West US",
                IpConfigurations = new List<NetworkInterfaceIPConfiguration>()
                {
                    new NetworkInterfaceIPConfiguration()
                    {
                        Name = "ipconfig1",
                        PrivateIPAllocationMethod = "Static",
                        PrivateIPAddress = availableIpAddress.AvailableIPAddresses[0],
                        Subnet = subnet
                    }
                }
            });

            return nic.Id;
        }

        protected void CreateVm(string deviceName, string activationKey, string networkInterfaceId, CloudApplianceConfiguration configuration)
        {
            this.ComputeClient.VirtualMachines.CreateOrUpdate(this.ResourceGroupName, deviceName, new VirtualMachine()
            {
                Location = "West US",
                OsProfile = new OSProfile()
                {
                    AdminUsername = "hcstestuser",
                    AdminPassword = "StorSime1StorSim1",
                    ComputerName = deviceName,
                    CustomData = GetVmCustomData(deviceName, activationKey, configuration)
                },
                HardwareProfile = new HardwareProfile()
                {
                    VmSize = configuration.SupportedVmTypes[0]
                },
                NetworkProfile = new NetworkProfile()
                {
                    NetworkInterfaces = new List<NetworkInterfaceReference>()
                    {
                        new NetworkInterfaceReference()
                        {
                            Id = networkInterfaceId
                        }
                    }
                },
                StorageProfile = new StorageProfile()
                {
                    ImageReference = new ImageReference()
                    {
                        Offer = configuration.SupportedVmImages[0].Offer,
                        Publisher = configuration.SupportedVmImages[0].Publisher,
                        Sku = configuration.SupportedVmImages[0].Sku,
                        Version = configuration.SupportedVmImages[0].Version
                    },
                    OsDisk = new OSDisk()
                    {
                        Name = deviceName + "os",
                        CreateOption = DiskCreateOptionTypes.FromImage,
                        Caching = CachingTypes.ReadWrite,
                        ManagedDisk = new ManagedDiskParameters()
                        {
                            StorageAccountType = StorageAccountTypes.PremiumLRS //configuration.SupportedStorageAccountTypes[0]
                        }
                    },
                    DataDisks = GetVmDataDisks(4, configuration, deviceName)
                }
            });
        }

        protected void CreateDefaultVnetIfNotExist()
        {
            VirtualNetwork vnet = null;
            try
            {
                vnet = this.NetworkClient.VirtualNetworks.Get(this.ResourceGroupName, TestConstants.DefaultVirtualNetworkName);
            }
            catch (CloudException ex)
            {
                // Error code is not ResourceNotFound, then unexpected failure and hence rethrowing exception
                if (ex.Body.Code != "ResourceNotFound")
                {
                    throw;
                }
            }

            if (vnet == null)
            {
                var vnetName = TestConstants.DefaultVirtualNetworkName;
                var subnetName = TestConstants.DefaultSubnetName;
                this.NetworkClient.VirtualNetworks.CreateOrUpdate(this.ResourceGroupName, vnetName, new VirtualNetwork()
                {
                    Location = "West US",
                    AddressSpace = new AddressSpace()
                    {
                        AddressPrefixes = new List<string> { "10.1.0.0/16" }
                    },
                    Subnets = new List<Subnet>{
                        new Subnet(){
                            Name = subnetName,
                            AddressPrefix = "10.1.0.0/24"
                        }
                    }
                });
            }
        }

        private static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        private static string GetVmCustomData(string trackingDetails, string activationKey, CloudApplianceConfiguration configuration)
        {
            var strBuilder = new StringBuilder();
            strBuilder.AppendLine();
            strBuilder.AppendLine($"ModelNumber={configuration.ModelNumber}");
            strBuilder.AppendLine($"TrackingId={Guid.NewGuid()}");
            strBuilder.AppendLine($"RegistrationKey={activationKey}");
            return Base64Encode(strBuilder.ToString());
        }

        private static IList<DataDisk> GetVmDataDisks(int numberOfDisks, CloudApplianceConfiguration configuration, string name)
        {
            var disks = new List<DataDisk>();
            for (int i = 0; i < numberOfDisks; i++)
            {
                disks.Add(new DataDisk()
                {
                    CreateOption = DiskCreateOptionTypes.Empty,
                    Lun = i,
                    Name = name + "datadisk" + (i + 1),
                    ManagedDisk = new ManagedDiskParameters()
                    {
                        StorageAccountType = StorageAccountTypes.PremiumLRS //configuration.SupportedStorageAccountTypes[0]
                    },
                    DiskSizeGB = 1023
                });
            }

            return disks;
        }

        private AsymmetricEncryptedSecret EncryptSecretUsingDEK(string resourceGroupName, string managerName, string deviceName, string plainTextSecret)
        {
            PublicKey devicePublicEncryptionInfo = this.Client.Managers.GetDevicePublicEncryptionKey(deviceName.GetDoubleEncoded(), resourceGroupName, managerName);
            var encryptedSecret = CryptoHelper.EncryptSecretRSAPKCS(plainTextSecret, devicePublicEncryptionInfo.Key);
            AsymmetricEncryptedSecret secret = new AsymmetricEncryptedSecret(encryptedSecret, EncryptionAlgorithm.RSAESPKCS1V15, String.Empty);

            return secret;
        }
        #endregion

        // Dispose all disposable objects
        public override void Dispose()
        {
            this.NetworkClient.Dispose();
            this.ComputeClient.Dispose();
            base.Dispose();
        }
    }
}
