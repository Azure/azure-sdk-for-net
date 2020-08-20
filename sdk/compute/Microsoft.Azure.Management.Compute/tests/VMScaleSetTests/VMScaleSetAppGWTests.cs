
namespace Compute.Tests
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Management.Compute;
    using Microsoft.Azure.Management.Compute.Models;
    using Microsoft.Azure.Management.Network;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Azure.Management.Insights;
    using Microsoft.Azure.Management.Insights.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    public class VMScaleSetAppGWTests : VMScaleSetTestsBase
    {
        [Fact]
        [Trait("Name", "VMScaleSetAppGwWithAS")]
        public void VMScaleSetAppGwWithAS()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                TestVMScaleSetAppGwWithASTests(context, VirtualMachinePriorityTypes.Regular);
            }
        }

        [Fact]
        [Trait("Name", "VMScaleSetAppGwWithAS_Spot")]
        public void VMScaleSetAppGwWithAS_Spot()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                TestVMScaleSetAppGwWithASTests(context, VirtualMachinePriorityTypes.Spot, hasManagedDisks: true);
            }
        }

        [Fact]
        [Trait("Name", "VMScaleSetAppGwWithAS_A1V2")]
        public void VMScaleSetAppGwWithAS_A1V2()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                TestVMScaleSetAppGwWithASTests(context, VirtualMachinePriorityTypes.Regular, vmssSize: VirtualMachineSizeTypes.StandardA1V2);
            }
        }

        [Fact]
        [Trait("Name", "VMScaleSetAppGwWithAS_SPG_False")]
        public void VMScaleSetAppGwWithAS_SPG_False()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                TestVMScaleSetAppGwWithASTests(context, VirtualMachinePriorityTypes.Regular, hasManagedDisks: true, hasSPG: false);
            }
        }

        private void TestVMScaleSetAppGwWithASTests(
            MockContext context,
            string priority,
            string evictionPolicy = null,
            string vmssSkuTier = "Standard",
            string vmssASMin = "1", 
            string vmssASMax = "100",
            string vmssSize = VirtualMachineSizeTypes.StandardA1,
            bool hasManagedDisks = false,
            bool hasSPG = true,
            int vmssSkuCapacity = 2,
            int AppGWMin = 2, 
            int AppGWMax = 10
            )
        {

            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");

            // Create resource group
            var rgName = TestUtilities.GenerateName(TestPrefix);
            var vmssName = TestUtilities.GenerateName("vmss");
            string storageAccountName = TestUtilities.GenerateName(TestPrefix);
            VirtualMachineScaleSet inputVMScaleSet;

            bool passed = false;
            try
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "centralus");
                EnsureClientsInitialized(context);
                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

                var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                m_CrpClient.VirtualMachineScaleSets.Delete(rgName, "VMScaleSetDoesNotExist");

                // AppGW Configuration
                var vnetResponse = CreateVNETWithSubnets(rgName, 2);
                var gatewaySubnet = vnetResponse.Subnets[0];
                var vmssSubnet = vnetResponse.Subnets[1];
                ApplicationGateway appgw = CreateApplicationGateway(rgName, gatewaySubnet);
                appgw.AutoscaleConfiguration = new ApplicationGatewayAutoscaleConfiguration(AppGWMin, AppGWMax);
                Microsoft.Azure.Management.Compute.Models.SubResource backendAddressPool = new Microsoft.Azure.Management.Compute.Models.SubResource()
                {
                    Id = appgw.BackendAddressPools[0].Id
                };
                
                var getResponse = CreateVMScaleSet_NoAsyncTracking(
                    rgName,
                    vmssName,
                    storageAccountOutput,
                    imageRef,
                    out inputVMScaleSet,
                    null,
                    (vmScaleSet) =>
                    {
                        vmScaleSet.Overprovision = true;
                        vmScaleSet.VirtualMachineProfile.Priority = priority;
                        vmScaleSet.VirtualMachineProfile.EvictionPolicy = evictionPolicy;
                        vmScaleSet.VirtualMachineProfile.NetworkProfile
                        .NetworkInterfaceConfigurations[0].IpConfigurations[0]
                        .ApplicationGatewayBackendAddressPools.Add(backendAddressPool);
                        vmScaleSet.Sku.Name = vmssSize;
                        vmScaleSet.Sku.Tier = vmssSkuTier;
                        vmScaleSet.Sku.Capacity = vmssSkuCapacity;
                    },
                    machineSizeType: vmssSize,
                    createWithManagedDisks: hasManagedDisks,
                    singlePlacementGroup: hasSPG,
                    subnet: vmssSubnet);

                AutoscaleSettingResource resource = CreateAutoscale(rgName, vmssName, "VMSS", vmssASMin, vmssASMax);

                var getGwResponse = m_NrpClient.ApplicationGateways.Get(rgName, appgw.Name);
                Assert.True(2 == getGwResponse.BackendAddressPools[0].BackendIPConfigurations.Count);

                ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks);

                var getInstanceViewResponse = m_CrpClient.VirtualMachineScaleSets.GetInstanceView(rgName, vmssName);
                Assert.NotNull(getInstanceViewResponse);
                ValidateVMScaleSetInstanceView(inputVMScaleSet, getInstanceViewResponse);

                var listResponse = m_CrpClient.VirtualMachineScaleSets.List(rgName);
                ValidateVMScaleSet(
                    inputVMScaleSet,
                    listResponse.FirstOrDefault(x => x.Name == vmssName),
                    hasManagedDisks);

                var listSkusResponse = m_CrpClient.VirtualMachineScaleSets.ListSkus(rgName, vmssName);
                Assert.NotNull(listSkusResponse);
                Assert.NotNull(resource);
                Assert.False(listSkusResponse.Count() == 0);
                Assert.Same(inputVMScaleSet.VirtualMachineProfile.Priority.ToString(), priority);

                m_CrpClient.VirtualMachineScaleSets.Delete(rgName, vmssName);
                passed = true;
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
                //Cleanup the created resources. But don't wait since it takes too long, and it's not the purpose
                //of the test to cover deletion. CSM does persistent retrying over all RG resources.
                m_ResourcesClient.ResourceGroups.Delete(rgName);
            }
            Assert.True(passed);
        }

        private AutoscaleSettingResource CreateAutoscale (
            string location, 
            string resourceUri, 
            string metricName,
            string vmssASMin,
            string vmssASMax)
        {
            var capacity = new ScaleCapacity()
            {
                DefaultProperty = "1",
                Maximum = vmssASMax,
                Minimum = vmssASMin
            };

            var recurrence = new Recurrence()
            {
                Frequency = RecurrenceFrequency.Week,
                Schedule = new RecurrentSchedule()
                {
                    Days = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" },
                    Hours = new List<int?> { 0 },
                    Minutes = new List<int?> { 10 },
                    TimeZone = "UTC-11"
                }
            };

            var rules = new ScaleRule[]
            {
                new ScaleRule()
                {
                    MetricTrigger = new MetricTrigger
                    {
                        MetricName = metricName,
                        MetricResourceUri = resourceUri,
                        Statistic = MetricStatisticType.Average,
                        Threshold = 80.0,
                        OperatorProperty = ComparisonOperationType.GreaterThan,
                        TimeAggregation = TimeAggregationType.Maximum,
                        TimeGrain = TimeSpan.FromMinutes(1),
                        TimeWindow = TimeSpan.FromHours(1)
                    },
                    ScaleAction = new ScaleAction
                    {
                        Cooldown = TimeSpan.FromMinutes(20),
                        Direction = ScaleDirection.Increase,
                        Value = "10"
                    }
                },

                new ScaleRule()
                {
                    MetricTrigger = new MetricTrigger
                    {
                        MetricName = metricName,
                        MetricResourceUri = resourceUri,
                        Statistic = MetricStatisticType.Average,
                        Threshold = 30.0,
                        OperatorProperty = ComparisonOperationType.LessThan,
                        TimeAggregation = TimeAggregationType.Maximum,
                        TimeGrain = TimeSpan.FromMinutes(1),
                        TimeWindow = TimeSpan.FromHours(1)
                    },
                    ScaleAction = new ScaleAction
                    {
                        Cooldown = TimeSpan.FromMinutes(20),
                        Direction = ScaleDirection.Decrease,
                        Value = "2"
                    }
                }
            };

            AutoscaleSettingResource setting = new AutoscaleSettingResource
            {
                Name = TestUtilities.GenerateName("autoscale"),
                AutoscaleSettingResourceName = "setting1",
                TargetResourceUri = resourceUri,
                Enabled = true,
                Profiles = new AutoscaleProfile[]
                {
                    new AutoscaleProfile()
                    {
                        Name = TestUtilities.GenerateName("profile"),
                        Capacity = capacity,
                        FixedDate = null,
                        Recurrence = recurrence,
                        Rules = rules
                    }
                },
                Location = location,
                Tags = null,
                Notifications = null
            };

            return setting;
        }
    }
}
