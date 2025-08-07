// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.ConnectedVMwarevSphere.Tests.Helpers
{
    [ClientTestFixture]
    public class ConnectedVMwareTestBase : ManagementRecordedTestBase<ConnectedVMwarevSphereManagementTestEnvironment>
    {
        protected AzureLocation DefaultLocation = AzureLocation.EastUS;
        protected const string DefaultSubscriptionId = "204898ee-cd13-4332-b9d4-55ca5c25496d";
        protected const string DefaultResourceGroupName = "azcli-test-rg";
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }
        protected ResourceGroupResource DefaultResourceGroup { get; private set; }

        protected ConnectedVMwareTestBase(bool isAsync) : base(isAsync)
        {
        }

        public ConnectedVMwareTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        protected ConnectedVMwareTestBase(bool isAsync, ResourceType resourceType, string apiVersion, RecordedTestMode? mode = null)
            : base(isAsync, resourceType, apiVersion, mode)
        {
        }

        [SetUp]
        public void CreateCommonClients()
        {
            Client = GetArmClient();
            // this example assumes you already have this ResourceGroupResource created on azure
            // for more information of creating ResourceGroupResource, please refer to the document of ResourceGroupResource
            ResourceIdentifier subscriptionId = SubscriptionResource.CreateResourceIdentifier(DefaultSubscriptionId);
            DefaultSubscription = Client.GetSubscriptionResource(subscriptionId);
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(DefaultSubscriptionId, DefaultResourceGroupName);
            DefaultResourceGroup = Client.GetResourceGroupResource(resourceGroupResourceId);
        }
    }
}
