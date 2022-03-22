// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.TestFramework;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Core;
using System.Linq;

namespace Azure.ResourceManager.ConnectedVMwarevSphere.Tests.Helpers
{
    [ClientTestFixture]
    public class ConnectedVMwareTestBase : ManagementRecordedTestBase<ConnectedVMwareManagementTestEnvironment>
    {
        public const string DefaultLocation = "eastus";
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }
        public const string EXTENDED_LOCATION_TYPE = "CustomLocation";
        public const string CustomLocationId  = "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/service-sdk-test/providers/Microsoft.ExtendedLocation/customLocations/service-sdk-test-cl";
        public const string VcenterId = "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/service-sdk-test/providers/Microsoft.ConnectedVMwarevSphere/VCenters/service-sdk-test-vcenter";
        public string _resourcePoolId = "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/service-sdk-test/providers/Microsoft.ConnectedVMwarevSphere/resourcePools/azcli-test-resource-pool";
        public string _vmTemplateId = "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/service-sdk-test/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineTemplates/azcli-test-vm-template";

        public static Dictionary<string, string> DefaultTags = new Dictionary<string, string>
        {
            {"key1","value1"},
            {"key2","value2"}
        };

        protected ConnectedVMwareTestBase(bool isAsync) : base(isAsync)
        {
        }

        public ConnectedVMwareTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        [SetUp]
        public async Task CreateCommonClients()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
        }

        protected async Task<ResourceGroupResource> CreateResourceGroupAsync()
        {
            var resourceGroupName = Recording.GenerateAssetName("testConnectedVMwareRG-");
            var rgOp = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(
                WaitUntil.Completed,
                resourceGroupName,
                new ResourceGroupData(DefaultLocation)
                {
                    Tags =
                    {
                        { "test", "env" }
                    }
                });
            return rgOp.Value;
        }
    }
}
