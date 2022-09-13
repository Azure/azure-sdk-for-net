﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Automanage.Models;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Automanage.Tests
{
    public class AutomanageTestBase : ManagementRecordedTestBase<AutomanageTestEnvironment>
    {
        public ArmClient ArmClient { get; private set; }
        public SubscriptionResource Subscription { get; set; }
        protected ResourceGroupCollection ResourceGroups { get; private set; }
        public static AzureLocation DefaultLocation => AzureLocation.EastUS;

        protected AutomanageTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected AutomanageTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            ArmClient = GetArmClient();
            Subscription = await ArmClient.GetDefaultSubscriptionAsync();
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        /// <summary>
        /// Creates a resource group
        /// </summary>
        /// <param name="rgNamePrefix">Prefix of the resource group</param>
        /// <param name="location">Location of the resource group</param>
        /// <returns></returns>
        protected async Task<ResourceGroupResource> CreateResourceGroup(string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData data = new ResourceGroupData(location);
            var rg = await Subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, data);
            return rg.Value;
        }

        /// <summary>
        /// Creates a custom configuration profile
        /// </summary>
        /// <param name="collection">Configruation Profile Collection to perform actions against</param>
        /// <param name="profileName">Desired name of the Configuration Profile</param>
        /// <returns>ConfigurationProfileResource</returns>
        protected async Task<ConfigurationProfileResource> CreateConfigurationProfile(ConfigurationProfileCollection collection, string profileName)
        {
            string configuration = "{" +
                "\"Antimalware/Enable\":true," +
                "\"Antimalware/EnableRealTimeProtection\":true," +
                "\"Antimalware/RunScheduledScan\":true," +
                "\"Backup/Enable\":true," +
                "\"WindowsAdminCenter/Enable\":false," +
                "\"VMInsights/Enable\":true," +
                "\"AzureSecurityCenter/Enable\":true," +
                "\"UpdateManagement/Enable\":true," +
                "\"ChangeTrackingAndInventory/Enable\":true," +
                "\"GuestConfiguration/Enable\":true," +
                "\"AutomationAccount/Enable\":true," +
                "\"LogAnalytics/Enable\":true," +
                "\"BootDiagnostics/Enable\":true" +
            "}";

            ConfigurationProfileData data = new ConfigurationProfileData(DefaultLocation)
            {
                Configuration = new BinaryData(configuration)
            };

            var newProfile = await collection.CreateOrUpdateAsync(WaitUntil.Completed, profileName, data);
            return newProfile.Value;
        }

        /// <summary>
        /// Creates an assignment between a configuration profile and a virtual machine
        /// </summary>
        /// <param name="vm">Virtual Machine to assign a profile to</param>
        /// <param name="profileId">ID of desired configuration profile to use</param>
        /// <param name="scope">Scope to create the assignment under</param>
        /// <returns>ConfigurationProfileAssignmentResource</returns>
        protected async Task<ConfigurationProfileAssignmentResource> CreateAssignment(VirtualMachineResource vm, string profileId)
        {
            var data = new ConfigurationProfileAssignmentData();
            data.Properties = new ConfigurationProfileAssignmentProperties() { ConfigurationProfile = profileId };

            // fetch assignments collection
            var collection = ArmClient.GetConfigurationProfileAssignments(vm.Id);
            var assignment = await collection.CreateOrUpdateAsync(WaitUntil.Completed, "default", data);

            return assignment.Value;
        }

        /// <summary>
        /// Creates a Virtual Machine from an existing ARM template
        /// </summary>
        /// <param name="vmName">Desired name of the Virtual Machine</param>
        /// <param name="rg">Resource Group to perform actions against</param>
        /// <returns>VirtualMachineResource</returns>
        protected async Task<VirtualMachineResource> CreateVirtualMachineFromTemplate(string vmName, ResourceGroupResource rg)
        {
            // get ARM template contents
            var httpClient = new HttpClient();
            //string url = "https://raw.githubusercontent.com/Azure/azure-sdk-for-net/main/sdk/automanage/deploy-vm.json";
            string url = "https://raw.githubusercontent.com/AndrewCS149/azure-sdk-for-net/andrsmith/automanageSDKTests/sdk/automanage/deploy-vm.json";
            var templateContent = await httpClient.GetAsync(url).Result.Content.ReadAsStringAsync();

            var deploymentContent = new ArmDeploymentContent(new ArmDeploymentProperties(ArmDeploymentMode.Incremental)
            {
                Template = BinaryData.FromString(templateContent),
                Parameters = BinaryData.FromObjectAsJson(new
                {
                    vmName = new { value = vmName }
                })
            });

            // create vm
            await rg.GetArmDeployments().CreateOrUpdateAsync(WaitUntil.Completed, "deployVM", deploymentContent);

            // fetch vm
            var vm = rg.GetVirtualMachineAsync(vmName).Result.Value;
            return vm;
        }
    }
}
