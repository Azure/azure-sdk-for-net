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
    [LiveOnly]
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

        // Comment out the following code as it is not used in version 2023-03-01
        //protected async Task<HybridConnectivityPublicCloudConnectorResource> CreatePublicCloudConnector(ResourceGroupResource rg)
        //{
        //    var connectorData = new HybridConnectivityPublicCloudConnectorData(DefaultLocation) { };

        //    var awsCloudProfile = new AwsCloudProfile("123456789123") { };
        //    awsCloudProfile.IsOrganizationalAccount = false;

        //    var properties = new PublicCloudConnectorProperties(awsCloudProfile, HybridConnectivityHostType.AWS) { };

        //    connectorData.Properties = properties;

        //    var collection = rg.GetHybridConnectivityPublicCloudConnectors();
        //    var pcc = await collection.CreateOrUpdateAsync(WaitUntil.Completed, ConnectorName, connectorData);
        //    return pcc.Value;
        //}
    }
}
