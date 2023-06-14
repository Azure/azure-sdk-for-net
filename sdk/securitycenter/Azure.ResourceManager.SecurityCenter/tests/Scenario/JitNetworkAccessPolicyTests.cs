// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.IotHub;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.SecurityCenter.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityCenter.Tests
{
    internal class JitNetworkAccessPolicyTests : SecurityCenterManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private JitNetworkAccessPolicyCollection _jitNetworkAccessPolicyCollection;

        public JitNetworkAccessPolicyTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            DefaultLocation = AzureLocation.CentralUS;
            _resourceGroup = await CreateResourceGroup();
            _jitNetworkAccessPolicyCollection = _resourceGroup.GetJitNetworkAccessPolicies("centralus");
        }

        private async Task<JitNetworkAccessPolicyResource> CreateJitNetworkAccessPolicy(string jitNetworkAccessPolicyName)
        {
            // create vm
            string interfaceName = Recording.GenerateAssetName("networkInterface");
            string vmName = Recording.GenerateAssetName("vm");
            var networkInterface = await CreateNetworkInterface(_resourceGroup, interfaceName);
            var vm = await CreateVirtualMachine(_resourceGroup, networkInterface.Id, vmName);

            var jitVirtualMachines = new List<JitNetworkAccessPolicyVirtualMachine>()
            {
                new JitNetworkAccessPolicyVirtualMachine(vm.Id, new List<JitNetworkAccessPortRule>() { new JitNetworkAccessPortRule(8080, JitNetworkAccessPortProtocol.Tcp, TimeSpan.FromHours(5)) { AllowedSourceAddressPrefix = "192.168.0.5" } })
            };
            JitNetworkAccessPolicyData data = new JitNetworkAccessPolicyData(jitVirtualMachines)
            {
                Kind = "Basic",
            };
            var jitNetworkAccessPolicy = await _jitNetworkAccessPolicyCollection.CreateOrUpdateAsync(WaitUntil.Completed, jitNetworkAccessPolicyName, data);
            return jitNetworkAccessPolicy.Value;
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string jitNetworkAccessPolicyName = Recording.GenerateAssetName("jit");
            var jitNetworkAccessPolicy = await CreateJitNetworkAccessPolicy(jitNetworkAccessPolicyName);
            ValidateJitNetworkAccessPolicyResource(jitNetworkAccessPolicy, jitNetworkAccessPolicyName);
        }

        [RecordedTest]
        public async Task Exist()
        {
            string jitNetworkAccessPolicyName = Recording.GenerateAssetName("jit");
            var jitNetworkAccessPolicy = await CreateJitNetworkAccessPolicy(jitNetworkAccessPolicyName);
            bool flag = await _jitNetworkAccessPolicyCollection.ExistsAsync(jitNetworkAccessPolicyName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            string jitNetworkAccessPolicyName = Recording.GenerateAssetName("jit");
            await CreateJitNetworkAccessPolicy(jitNetworkAccessPolicyName);
            var jitNetworkAccessPolicy = await _jitNetworkAccessPolicyCollection.GetAsync(jitNetworkAccessPolicyName);
            ValidateJitNetworkAccessPolicyResource(jitNetworkAccessPolicy, jitNetworkAccessPolicyName);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            string jitNetworkAccessPolicyName = Recording.GenerateAssetName("jit");
            var jitNetworkAccessPolicy = await CreateJitNetworkAccessPolicy(jitNetworkAccessPolicyName);
            var list = await _jitNetworkAccessPolicyCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateJitNetworkAccessPolicyResource(list.First(item => item.Data.Name == jitNetworkAccessPolicyName), jitNetworkAccessPolicyName);
        }

        [RecordedTest]
        public async Task Delete()
        {
            string jitNetworkAccessPolicyName = Recording.GenerateAssetName("jit");
            var jitNetworkAccessPolicy = await CreateJitNetworkAccessPolicy(jitNetworkAccessPolicyName);
            bool flag = await _jitNetworkAccessPolicyCollection.ExistsAsync(jitNetworkAccessPolicyName);
            Assert.IsTrue(flag);

            await jitNetworkAccessPolicy.DeleteAsync(WaitUntil.Completed);
            flag = await _jitNetworkAccessPolicyCollection.ExistsAsync(jitNetworkAccessPolicyName);
            Assert.IsFalse(flag);
        }

        private void ValidateJitNetworkAccessPolicyResource(JitNetworkAccessPolicyResource jitNetworkAccessPolicy, string jitNetworkAccessPolicyName)
        {
            Assert.IsNotNull(jitNetworkAccessPolicy);
            Assert.IsNotNull(jitNetworkAccessPolicy.Data.Id);
            Assert.AreEqual(jitNetworkAccessPolicyName, jitNetworkAccessPolicy.Data.Name);
            Assert.AreEqual("Basic", jitNetworkAccessPolicy.Data.Kind);
            Assert.AreEqual(DefaultLocation, jitNetworkAccessPolicy.Data.Location);
            Assert.AreEqual(1, jitNetworkAccessPolicy.Data.VirtualMachines.Count);
            Assert.AreEqual(8080, jitNetworkAccessPolicy.Data.VirtualMachines.First().Ports.First().Number);
            Assert.AreEqual("TCP", jitNetworkAccessPolicy.Data.VirtualMachines.First().Ports.First().Protocol.ToString());
            Assert.AreEqual(8080, jitNetworkAccessPolicy.Data.VirtualMachines.First().Ports.First().Number);
        }
    }
}
