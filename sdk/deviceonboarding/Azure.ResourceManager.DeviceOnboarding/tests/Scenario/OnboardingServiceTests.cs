// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DeviceOnboarding.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DeviceOnboarding.Tests.Scenario
{
    [TestFixture]
    public class OnboardingServiceTests : DeviceOnboardingManagementTestBase
    {
        public OnboardingServiceTests() : base(true, RecordedTestMode.Playback)
        {
        }

        [TestCase]
        public async Task TestOnboardingServiceCRUD()
        {
            //create
            string subscriptionId = TestEnvironment.DeviceOnboardingSubscription;
            string resourceGroupName = TestEnvironment.DeviceOnboardingResourceGroup;
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = Client.GetResourceGroupResource(resourceGroupResourceId);
            OnboardingServiceCollection collection = resourceGroupResource.GetOnboardingServices();
            string onboardingServiceName = "testOnboardingCRUD";
            OnboardingServiceData data = new OnboardingServiceData(new AzureLocation("westus3"))
            {
                Properties = new OnboardingServiceProperties(true)
                {
                    PublicNetworkAccess = PublicNetworkAccessOption.Enabled,
                },
                Tags =
                {
                    ["key746"] = "byqsmjkgnjrqf"
                },
            };
            ArmOperation<OnboardingServiceResource> createOperation = await collection.CreateOrUpdateAsync(WaitUntil.Completed, onboardingServiceName, data);
            Assert.IsTrue(createOperation.HasCompleted);

            //read
            collection = resourceGroupResource.GetOnboardingServices();
            NullableResponse<OnboardingServiceResource> result = await collection.GetIfExistsAsync(onboardingServiceName);
            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(createOperation.Value.Data.Tags["key746"], "byqsmjkgnjrqf");

            //update
            ResourceIdentifier onboardingServiceResourceId = OnboardingServiceResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, onboardingServiceName);
            OnboardingServiceResource onboardingService = Client.GetOnboardingServiceResource(onboardingServiceResourceId);
            OnboardingServiceResource updated = await onboardingService.AddTagAsync("key286", "tlvmukslgwaaimysrkrzvc");
            OnboardingServiceData resourceData = updated.Data;
            Assert.AreEqual(resourceData.Tags["key286"], "tlvmukslgwaaimysrkrzvc");

            //delete
            ArmOperation deleteOperation = await onboardingService.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteOperation.HasCompleted);
            collection = resourceGroupResource.GetOnboardingServices();
            bool checkExistence = await collection.ExistsAsync(onboardingServiceName);
            Assert.IsFalse(checkExistence);
        }

        [TestCase]
        public async Task TestDeviceOnboarding()
        {
            //Create onboarding service
            string subscriptionId = TestEnvironment.DeviceOnboardingSubscription;
            string resourceGroupName = TestEnvironment.DeviceOnboardingResourceGroup;
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId,resourceGroupName);
            ResourceGroupResource resourceGroupResource = Client.GetResourceGroupResource(resourceGroupResourceId);
            OnboardingServiceCollection collection = resourceGroupResource.GetOnboardingServices();
            string onboardingServiceName = "testOnboardingService2";
            OnboardingServiceData osData = new OnboardingServiceData(new AzureLocation("westus3"))
            {
                Properties = new OnboardingServiceProperties(true)
                {
                    PublicNetworkAccess = PublicNetworkAccessOption.Enabled,
                },
                Tags =
                {
                    ["key746"] = "byqsmjkgnjrqf"
                },
            };
            ArmOperation<OnboardingServiceResource> osCreateOperation = await collection.CreateOrUpdateAsync(WaitUntil.Completed, onboardingServiceName, osData);

            //Create policy
            collection = resourceGroupResource.GetOnboardingServices();
            OnboardingServiceResource onboardingService = await collection.GetAsync(onboardingServiceName);
            PolicyCollection policies = onboardingService.GetPolicies();
            string policyName = "policyName";
            FdoBootstrapAuthenticationRule fdoAuth = new FdoBootstrapAuthenticationRule();
            fdoAuth.OwnershipVoucherStorage = new StorageAccountOwnershipVoucherStorage(ResourceIdentifier.Parse("/subscriptions/"+subscriptionId+"/resourceGroups/"+resourceGroupName+"/providers/Microsoft.Storage/storageAccounts/sanitized"), new Uri("https://sanitized.blob.core.windows.net/sanitized"));
            HybridComputePolicyResourceDetails deviceRegistryPolicy = new HybridComputePolicyResourceDetails();
            PolicyData pData = new PolicyData(new AzureLocation("westus3"))
            {
                Properties = new PolicyProperties(PolicyStatusOption.Enabled, fdoAuth, deviceRegistryPolicy),
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            ArmOperation<PolicyResource> lro = await policies.CreateOrUpdateAsync(WaitUntil.Started, policyName, pData);
            Response<PolicyResource> done = await lro.WaitForCompletionAsync().ConfigureAwait(false);
            PolicyResource result = lro.Value;

            //Create devicestate
            ResourceIdentifier deviceStateResourceId = DeviceStateResource.CreateResourceIdentifier("/subscriptions/"+subscriptionId+"/resourceGroups/"+resourceGroupName+"/providers/Microsoft.HybridCompute/machines/sanitized");
            DeviceStateResource deviceState = Client.GetDeviceStateResource(deviceStateResourceId);
            DeviceStateData data = new DeviceStateData
            {
                Properties = new DeviceStateProperties("registrationid", OnboardingStatus.Pending, new ResourceIdentifier("/subscriptions/"+subscriptionId+"/resourceGroups/"+resourceGroupName+"/providers/Microsoft.DeviceOnboarding/onboardingServices/"+onboardingServiceName+"/policies/"+policyName))
                {
                    DiscoveryEnabled = DiscoveryOption.True,
                    AllocatedEndpoints = { new AllocatedEndpoint("someendpoint", EndpointType.MicrosoftEventGridNamespace, "rzmawmbcdfaehwzylxshiitjlgepv") },
                },
            };
            ArmOperation<DeviceStateResource> createOperation = await deviceState.CreateOrUpdateAsync(WaitUntil.Completed, data);
            Assert.IsTrue(createOperation.HasCompleted);

            //Read device state
            DeviceStateResource created = await deviceState.GetAsync();
            Assert.IsTrue(created.HasData);

            //Update device state
            data.Properties.DiscoveryEnabled = DiscoveryOption.False;
            ArmOperation<DeviceStateResource> updateOperation = await deviceState.CreateOrUpdateAsync(WaitUntil.Completed, data);
            DeviceStateResource updatedDeviceState = updateOperation.Value;
            Assert.IsTrue(updatedDeviceState.HasData);
            Assert.AreEqual(updatedDeviceState.Data.Properties.DiscoveryEnabled, DiscoveryOption.False);

            //Delete device state
            var deleteOperation = await updatedDeviceState.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteOperation.HasCompleted);

            //Delete policy
            PolicyResource policy = await policies.GetAsync(policyName);
            ArmOperation deletePolicyOperation = await policy.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deletePolicyOperation.HasCompleted);
            policies = onboardingService.GetPolicies();
            bool checkExistence = await policies.ExistsAsync(policyName);
            Assert.IsFalse(checkExistence);

            //Delete onboarding service
            ArmOperation deleteOsOperation = await onboardingService.DeleteAsync(WaitUntil.Completed);
        }
    }
}
