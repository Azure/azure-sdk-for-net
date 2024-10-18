// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Azure.ResourceManager.ToolchainOrchestrator.Models;
using System.Xml.Linq;

namespace Azure.ResourceManager.ToolchainOrchestrator.Tests
{
    public class ToolchainOrchestratorManagementTestBase : ManagementRecordedTestBase<ToolchainOrchestratorManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }
        protected AzureLocation DefaultLocation => AzureLocation.EastUS;
        protected Stack<Action> CleanupActions { get; } = new Stack<Action>();

        protected ToolchainOrchestratorManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected ToolchainOrchestratorManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task Setup()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }
        protected async Task<SolutionResource> CreateOrUpdateSolution(string name = null, string zone = "1", bool verifyResult = false)
        {
            ResourceGroupResource ResourceGroup = await CreateResourceGroup(this.DefaultSubscription, "rg-symphonytest", DefaultLocation);
            SolutionCollection storageCacheCollectionVar = ResourceGroup.GetSolutions();
            string cacheNameVar = name ?? Recording.GenerateAssetName("testsc");
            SolutionData dataVar = new SolutionData(this.DefaultLocation, new ExtendedLocation() { Name = "/subscriptions/af54d2ce-0dcb-48f8-9d2d-ff9c53e48c8d/resourceGroups/shawntest/providers/Microsoft.ExtendedLocation/customLocations/shawncustomlo", Type = "CustomLocation"});

//            new Dictionary<string, BinaryData>
//{
//    { "foo", BinaryData.FromObjectAsJson("foo") }, // 通过对象构造 BinaryData
//    { "bar", BinaryData.FromString("\"bar\"") },   // 通过字符串构造 BinaryData
//    { "example", BinaryData.FromObjectAsJson(new { key = "value" }) }, // 构造带有键值对的对象
//    { "jsonString", BinaryData.FromString("{\"key\": \"value\"}") }    // 直接传递 JSON 字符串
//};
            ArmOperation<SolutionResource> lro = await storageCacheCollectionVar.CreateOrUpdateAsync(
                waitUntil: WaitUntil.Completed,
                solutionName: cacheNameVar,
                data: dataVar);
            this.CleanupActions.Push(async () => await lro.Value.DeleteAsync(WaitUntil.Completed));
            if (verifyResult)
            {
                this.VerifySolution(lro.Value, dataVar);
            }
            return lro.Value;
        }
        protected void VerifySolution(SolutionResource actual, SolutionData expected)
        {
            Assert.AreEqual(actual.Data.ExtendedLocation.Type, expected.ExtendedLocation.Type);
            Assert.AreEqual(actual.Data.ExtendedLocation.Name, expected.ExtendedLocation.Name);
        }
    }
}
