// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
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
            IgnoreApiVersionInResourcesOperations();
        }

        protected AutomanageTestBase(bool isAsync)
            : base(isAsync)
        {
            IgnoreApiVersionInResourcesOperations();
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
        /// <param name="collection">Configruation profile collection to perform actions against</param>
        /// <param name="profileName">Desired configuration profile name</param>
        /// <returns>ConfigurationProfileResource</returns>
        protected async Task<AutomanageConfigurationProfileResource> CreateConfigurationProfile(AutomanageConfigurationProfileCollection collection, string profileName)
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

            AutomanageConfigurationProfileData data = new AutomanageConfigurationProfileData(DefaultLocation)
            {
                Configuration = new BinaryData(configuration)
            };

            var newProfile = await collection.CreateOrUpdateAsync(WaitUntil.Completed, profileName, data);
            return newProfile.Value;
        }

        /// <summary>
        /// Creates an assignment between a configuration profile and a virtual machine
        /// </summary>
        /// <param name="vmId">The ID of the Virtual Machine to assign a profile to</param>
        /// <param name="profileId">ID of desired configuration profile to use</param>
        /// <returns>ConfigurationProfileAssignmentResource</returns>
        protected async Task<AutomanageVmConfigurationProfileAssignmentResource> CreateAssignment(ResourceIdentifier vmId, string profileId)
        {
            var data = new AutomanageConfigurationProfileAssignmentData()
            {
                Properties = new AutomanageConfigurationProfileAssignmentProperties() { ConfigurationProfile = new ResourceIdentifier(profileId) }
            };

            // fetch assignments collection
            var collection = ArmClient.GetAutomanageVmConfigurationProfileAssignments(vmId);
            var assignment = await collection.CreateOrUpdateAsync(WaitUntil.Completed, "default", data);

            return assignment.Value;
        }

        /// <summary>
        /// Creates a Virtual Machine from an existing ARM template
        /// </summary>
        /// <param name="vmName">Desired name of the Virtual Machine</param>
        /// <param name="rg">Resource Group to perform actions against</param>
        /// <returns>The <see cref="ResourceIdentifier"/> of the created VirtualMachineResource</returns>
        protected async Task<ResourceIdentifier> CreateVirtualMachineFromTemplate(string vmName, ResourceGroupResource rg)
        {
            // get ARM template contents
            var httpClient = new HttpClient();
            string url = "https://raw.githubusercontent.com/Azure/azure-sdk-for-net/main/sdk/automanage/deploy-vm.json";
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
            var deploymentLro = await rg.GetArmDeployments().CreateOrUpdateAsync(WaitUntil.Completed, "deployVM", deploymentContent);
            var deployment = deploymentLro.Value.Data;

            var vmId = deployment.Properties.OutputResources.Select(sub => sub.Id).First(id => id.ResourceType == VirtualMachineResource.ResourceType);

            return vmId;
        }

        private void IgnoreApiVersionInResourcesOperations()
        {
            // Ignore the api-version of deployment operations
            UriRegexSanitizers.Add(new UriRegexSanitizer(
                @"/providers/Microsoft.Resources/deployments/[^/]+(/operationStatuses/[^/]+)?pi-version=(?<group>[a-z0-9-]+)")
            {
                GroupForReplace = "group",
                Value = "**"
            });
        }
    }
}
