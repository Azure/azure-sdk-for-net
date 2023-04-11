// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.NetApp.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using FluentAssertions;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Polly.Contrib.WaitAndRetry;
using Polly;

namespace Azure.ResourceManager.NetApp.Tests.Helpers
{
    [ClientTestFixture]
    public class NetAppTestBase : NetAppManagementTestBase
    {
        public static AzureLocation DefaultLocation = AzureLocation.WestUS2;
        public static string DefaultLocationString = "westus2";
        public static AzureLocation RemoteLocation => AzureLocation.EastUS;
        public static string RemoteLocationString = "eastus";

        public static ResourceGroupResource _resourceGroup;

        public static string _namePrefix = "testNetAppNetSDKmgmt";
        public static string _accountNamePrefix = "account";
        public static long? _poolSize = 4398046511104;
        public static long _tebibyte = 1024L * 1024L * 1024L * 1024L;
        public static long _gibibyte = 1024L * 1024L * 1024L;
        public static long _defaultUsageThreshold = 100 * _gibibyte;
        public static List<string> _defaultProtocolTypes = new() { "NFSv3" };

        internal NetAppAccountResource _netAppAccount;
        internal CapacityPoolCollection _capacityPoolCollection { get => _netAppAccount.GetCapacityPools(); }
        internal CapacityPoolResource _capacityPool;
        internal NetAppVolumeCollection _volumeCollection;
        public VirtualNetworkResource DefaultVirtualNetwork { get; set; }
        public static ResourceIdentifier DefaultSubnetId { get; set; }

        public static NetAppVolumeExportPolicyRule _defaultExportPolicyRule = new()
        {
            RuleIndex = 1,
            IsUnixReadOnly = false,
            IsUnixReadWrite = true,
            AllowCifsProtocol = false,
            AllowNfsV3Protocol = true,
            AllowNfsV41Protocol = false,
            AllowedClients = "0.0.0.0/0",
            IsKerberos5ReadOnly = false,
            IsKerberos5ReadWrite = false,
            IsKerberos5iReadOnly = false,
            IsKerberos5iReadWrite = false,
            IsKerberos5pReadOnly = false,
            IsKerberos5pReadWrite = false
        };

        public static IList<NetAppVolumeExportPolicyRule> _defaultExportPolicyRuleList = new List<NetAppVolumeExportPolicyRule>()
        {
            _defaultExportPolicyRule
        };

        public static Dictionary<string, string> DefaultTags = new Dictionary<string, string>
        {
            {"key1","value1"},
            {"key2","value2"}
        };

        public static NetAppAccountActiveDirectory ActiveDirectory1 = new()
        {
            Username = "sdkuser",
            Password = "sdkpass",
            Domain = "sdkdomain",
            Dns = "192.0.2.2",
            SmbServerName = "SDKSMBSeNa"
        };

        protected NetAppTestBase(bool isAsync) : base(isAsync)
        {
        }

        public NetAppTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        protected NetAppTestBase(bool isAsync, ResourceType resourceType, string apiVersion, RecordedTestMode? mode = null)
            : base(isAsync, resourceType, apiVersion, mode)
        {
        }

        public static NetAppAccountData GetDefaultNetAppAccountParameters(string location = "", NetAppAccountActiveDirectory activeDirectory = null)
        {
            if (string.IsNullOrWhiteSpace(location))
            {
                location = DefaultLocationString;
            }
            // create the account with only the one required property location
            var netAppAccount = new NetAppAccountData(location);
            if (activeDirectory != null)
            {
                netAppAccount.ActiveDirectories.Add(activeDirectory);
            }
            netAppAccount.Tags.InitializeFrom(DefaultTags);
            return netAppAccount;
        }

        public static NetAppVolumeData GetDefaultVolumeParameters(string creationToken, long usageThreshold, ResourceIdentifier subnetId, string location = "")
        {
            if (string.IsNullOrWhiteSpace(location))
            {
                location = DefaultLocationString;
            }
            // create the account with only the one required property location
            var volumeData = new NetAppVolumeData(location, creationToken, usageThreshold, subnetId);
            volumeData.Tags.InitializeFrom(DefaultTags);
            volumeData.UsageThreshold = 100 * _gibibyte;
            foreach (string protocolType in _defaultProtocolTypes)
            {
                volumeData.ProtocolTypes.Add(protocolType);
            }
            volumeData.ExportPolicy.Rules.Add(_defaultExportPolicyRule);
            return volumeData;
        }

        [TearDown]
        public async Task waitForDeletion()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(5000);
            }
        }

        public async Task<string> CreateValidAccountNameAsync(string prefix, ResourceGroupResource resourceGroup, string location = "")
        {
            if (string.IsNullOrWhiteSpace(location))
            {
                location = DefaultLocationString;
            }

            string accountName = prefix;
            for (int i = 0; i < 10; i++)
            {
                accountName = Recording.GenerateAssetName(prefix);
                NetAppNameAvailabilityContent parameter = new(accountName, NetAppNameAvailabilityResourceType.MicrosoftNetAppNetAppAccounts, resourceGroup.Data.Name);
                NetAppCheckAvailabilityResult result = await DefaultSubscription.CheckNetAppNameAvailabilityAsync(location, parameter);
                if (result.IsAvailable == true)
                {
                    return accountName;
                }
            }
            return accountName;
        }

        public static void VerifyNetAppAccountProperties(NetAppAccountResource account, bool useDefaults, string location = "")
        {
            if (string.IsNullOrWhiteSpace(location))
            {
                location = DefaultLocationString;
            }
            Assert.NotNull(account);
            Assert.NotNull(account.Id);
            Assert.NotNull(account.Id.Name);
            Assert.NotNull(account.Data);
            Assert.NotNull(account.Data.Location);
            Assert.NotNull(account.Data.SystemData);

            if (useDefaults)
            {
                Assert.AreEqual(location, account.Data.Location.ToString());

                Assert.NotNull(account.Data.Tags);
                Assert.AreEqual(3, account.Data.Tags.Count);
                Assert.AreEqual("value1", account.Data.Tags["key1"]);
                Assert.AreEqual("value2", account.Data.Tags["key2"]);
            }
        }

        public static void VerifyVolumeProperties(NetAppVolumeResource volume, bool useDefaults)
        {
            Assert.NotNull(volume);
            Assert.NotNull(volume.Id);
            Assert.NotNull(volume.Id.Name);
            Assert.NotNull(volume.Data);
            Assert.NotNull(volume.Data.Location);

            if (useDefaults)
            {
                Assert.AreEqual(DefaultLocation, volume.Data.Location);

                Assert.NotNull(volume.Data.Tags);
                Assert.AreEqual(3, volume.Data.Tags.Count);
                Assert.AreEqual("value1", volume.Data.Tags["key1"]);
                Assert.AreEqual("value2", volume.Data.Tags["key2"]);
                Assert.AreEqual(_defaultUsageThreshold, volume.Data.UsageThreshold);
                Assert.AreEqual(DefaultSubnetId, volume.Data.SubnetId);
            }
        }

        public static void AssertNetAppAccountEqual(NetAppAccountResource account1, NetAppAccountResource account2)
        {
            Assert.AreEqual(account1.Id.Name, account2.Id.Name);
            Assert.AreEqual(account1.Id.Location, account2.Id.Location);
        }

        public static void VerifyCapacityPoolProperties(CapacityPoolResource pool, bool useDefaults)
        {
            Assert.NotNull(pool);
            Assert.NotNull(pool.Id);
            Assert.NotNull(pool.Id.Name);
            Assert.NotNull(pool.Data);
            Assert.NotNull(pool.Data.Location);
            //Assert.NotNull(pool.Data.SystemData);

            if (useDefaults)
            {
                Assert.AreEqual(DefaultLocation, pool.Data.Location);

                Assert.NotNull(pool.Data.Tags);
                Assert.AreEqual(3, pool.Data.Tags.Count);
                Assert.AreEqual("value1", pool.Data.Tags["key1"]);
                Assert.AreEqual("value2", pool.Data.Tags["key2"]);
                Assert.AreEqual(NetAppFileServiceLevel.Premium, pool.Data.ServiceLevel);
                Assert.AreEqual(_poolSize, pool.Data.Size);
            }
        }

        public async Task<ResourceGroupResource> CreateResourceGroupAsync(string name = "testNetAppDotNetSDKRG-", string location = "")
        {
            location = string.IsNullOrEmpty(location) ? DefaultLocationString : location;
            string resourceGroupName = Recording.GenerateAssetName(name);
            ArmOperation<ResourceGroupResource> operation = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(
                WaitUntil.Completed,
                resourceGroupName,
                new ResourceGroupData(location)
                {
                    Tags =
                    {
                        { "test", "env" },
                        { "Owner", "b-aubald" }
                    }
                });
            return operation.Value;
        }

        public async Task<CapacityPoolResource> CreateCapacityPool(string location, NetAppFileServiceLevel serviceLevel, long? size, string poolName = "")
        {
            location = string.IsNullOrEmpty(location) ? DefaultLocationString : location;
            if (string.IsNullOrWhiteSpace(poolName))
            {
                poolName = Recording.GenerateAssetName("pool-");
            }
            if (size == null)
            {
                size = _poolSize;
            }

            CapacityPoolData capactiyPoolData = new(location, size.Value, serviceLevel);
            capactiyPoolData.Tags.InitializeFrom(DefaultTags);
            CapacityPoolResource capactiyPoolResource1 = (await _capacityPoolCollection.CreateOrUpdateAsync(WaitUntil.Completed, poolName, capactiyPoolData)).Value;
            return capactiyPoolResource1;
        }

        public async Task<NetAppVolumeResource> CreateVolume(string location, NetAppFileServiceLevel serviceLevel, long? usageThreshold, string volumeName = "", ResourceIdentifier subnetId = null, List<string> protocolTypes = null, NetAppVolumeExportPolicyRule exportPolicyRule = null, NetAppVolumeCollection volumeCollection = null, NetAppVolumeDataProtection dataProtection = null, string snapshotId = "", string backupId = "")
        {
            location = string.IsNullOrEmpty(location) ? DefaultLocationString : location;
            if (string.IsNullOrWhiteSpace(volumeName))
            {
                volumeName = Recording.GenerateAssetName("volumeName-");
            }
            if (volumeCollection == null)
            {
                volumeCollection = _volumeCollection;
            }
            if (subnetId == null)
            {
                subnetId =  DefaultSubnetId;
            }
            usageThreshold ??= _defaultUsageThreshold;

            NetAppVolumeData volumeData = new(location, volumeName, usageThreshold.Value, subnetId);
            if (exportPolicyRule != null)
            {
                volumeData.ExportRules.Add(exportPolicyRule);
            }
            volumeData.DataProtection = dataProtection;
            if (!string.IsNullOrWhiteSpace(snapshotId))
            {
                volumeData.SnapshotId = snapshotId;
            }
            if (!string.IsNullOrWhiteSpace(backupId))
            {
                volumeData.BackupId = backupId;
            }
            if (protocolTypes != null)
            {
                foreach (string protocolType in protocolTypes)
                {
                    volumeData.ProtocolTypes.Add(protocolType);
                }
            }
            volumeData.Tags.InitializeFrom(DefaultTags);
            NetAppVolumeResource volumeResource = (await volumeCollection.CreateOrUpdateAsync(WaitUntil.Completed, volumeName, volumeData)).Value;
            return volumeResource;
        }

        public async Task<VirtualNetworkResource> CreateVirtualNetwork(string location = null, ResourceGroupResource resourceGroup = null)
        {
            if (string.IsNullOrWhiteSpace(location))
            {
                location = DefaultLocationString;
            }
            if (resourceGroup == null)
            {
                resourceGroup = _resourceGroup;
            }
            location ??= DefaultLocationString;
            var vnetName = Recording.GenerateAssetName("vnet-");
            ServiceDelegation delegation =  new() { Name = "netAppVolumes", ServiceName = "Microsoft.Netapp/volumes" } ;
            var vnet = new VirtualNetworkData()
            {
                Location = location,
                Subnets = { new SubnetData() {
                    Name = "default",
                    AddressPrefix = "10.0.1.0/24"
                }}
            };
            vnet.AddressPrefixes.Add("10.0.0.0/16");
            vnet.Subnets[0].Delegations.Add(delegation);
            VirtualNetworkCollection vnetColletion = resourceGroup.GetVirtualNetworks();
            VirtualNetworkResource virtualNetwork = (await vnetColletion.CreateOrUpdateAsync(WaitUntil.Completed, vnetName, vnet)).Value;
            SubnetData subnetResource = virtualNetwork.Data.Subnets[0];
            DefaultSubnetId = subnetResource.Id;
            //wait a bit this may take a while
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(30000);
            }
            await WaitForVnetSucceeded(vnetColletion, virtualNetwork);
            return virtualNetwork;
        }

        private async Task WaitForVnetSucceeded(VirtualNetworkCollection vNetCollection, VirtualNetworkResource virtualNetworkResource = null)
        {
            var maxDelay = TimeSpan.FromSeconds(120);
            int count = 0;
            if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Playback")
            {
                maxDelay = TimeSpan.FromMilliseconds(500);
            }

            IEnumerable<TimeSpan> delay = Backoff.DecorrelatedJitterBackoffV2(medianFirstRetryDelay: TimeSpan.FromSeconds(5), retryCount: 500)
                    .Select(s => TimeSpan.FromTicks(Math.Min(s.Ticks, maxDelay.Ticks))); // use jitter strategy in the retry algorithm to prevent retries bunching into further spikes of load, with ceiling on delays (for larger retrycount)

            Polly.Retry.AsyncRetryPolicy<bool> retryPolicy = Policy
                .HandleResult<bool>(false) // retry if delegate executed asynchronously returns false
                .WaitAndRetryAsync(delay);

            try
            {
                await retryPolicy.ExecuteAsync(async () =>
                {
                    count++;
                    VirtualNetworkResource vnet = await vNetCollection.GetAsync(virtualNetworkResource.Id.Name);
                    Console.WriteLine($"Get provisioning state for vNet {virtualNetworkResource.Id.Name} run {count} provisioning state is {vnet.Data.ProvisioningState}");
                    if (vnet.Data.ProvisioningState == NetworkProvisioningState.Succeeded || vnet.Data.ProvisioningState == NetworkProvisioningState.Failed)
                    {
                        //success stop retrying
                        return true;
                    }
                    else
                    {
                        //retry
                        return false;
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Final Throw {ex.Message}");
                throw;
            }
        }
    }
}
