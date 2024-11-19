// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;
using System;
using Azure.Identity;
using Azure.ResourceManager.HybridConnectivity.Models;
using Azure.ResourceManager.Models;
using System.Collections.Generic;
using System.Xml;
using Castle.Components.DictionaryAdapter.Xml;

namespace Azure.ResourceManager.HybridConnectivity.Tests
{
    public abstract class HybridConnectivityManagementTestBase : ManagementRecordedTestBase<HybridconnectivityManagementTestEnvironment>
    {
        protected ArmClient ArmClient { get; private set; }
        protected AzureLocation DefaultLocation = AzureLocation.EastUS;
        protected const string DefaultResourceGroupPrefix = "HybridConnectivitySDKRG";
        protected const string ConnectorName = "MultiCloudSDKTestConnectorName";
        protected const string SolutionConfigurationName = "TestSolutionConfigName";
        protected const string AssetManagementType = "Microsoft.AssetManagement";

        protected HybridConnectivityManagementTestBase(bool isAsync, RecordedTestMode? mode = null)
            : base(isAsync, mode)
        {
        }

        [SetUp]
        public void CreateCommonClient()
        {
            ArmClient = GetArmClient();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup()
        {
            var subscription = await ArmClient.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName(DefaultResourceGroupPrefix);
            ResourceGroupData input = new ResourceGroupData(DefaultLocation);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<PublicCloudConnectorResource> CreatePublicCloudConnector(ResourceGroupResource rg)
        {
            var connectorData = new PublicCloudConnectorData(DefaultLocation) { };

            var awsCloudProfile = new AwsCloudProfile("123456789123") { };
            awsCloudProfile.IsOrganizationalAccount = false;

            var properties = new PublicCloudConnectorProperties(awsCloudProfile, HybridConnectivityHostType.AWS) { };

            connectorData.Properties = properties;

            var collection = rg.GetPublicCloudConnectors();
            var pcc = await collection.CreateOrUpdateAsync(WaitUntil.Completed, ConnectorName, connectorData);
            return pcc.Value;
        }
    }
}
