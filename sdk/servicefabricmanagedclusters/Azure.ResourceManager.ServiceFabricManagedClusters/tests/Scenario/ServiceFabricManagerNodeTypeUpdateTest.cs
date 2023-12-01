// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ServiceFabricManagedClusters.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ServiceFabricManagedClusters.Tests
{
    internal class ServiceFabricManagerNodeTypeUpdateTest : ServiceFabricManagedClustersManagementTestBase
    {
        private ServiceFabricManagedClusterResource _cluster;
        private ServiceFabricManagedNodeTypeCollection _nodeTypeCollection;
        private ServiceFabricManagedNodeTypeResource _nodeTypeResource;
        public ServiceFabricManagerNodeTypeUpdateTest(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var resourceGroup = (await DefaultSubscription.GetResourceGroupAsync("testClusterRG-9503")).Value;
            _cluster = await resourceGroup.GetServiceFabricManagedClusterAsync("sfmctest5490");
            _nodeTypeCollection = _cluster.GetServiceFabricManagedNodeTypes();
            _nodeTypeResource = await _cluster.GetServiceFabricManagedNodeTypeAsync("node4968");
        }

        [Test]
        public async Task UpdateTest()
        {
            //Update
            var updateNodetype_lro = await _nodeTypeResource.UpdateAsync(new ServiceFabricManagedNodeTypePatch()
            {
                Tags =
                {
                    ["UpdateKey1"] = "UpdateValue1",
                    ["UpdateKey2"] = "UpdateValue2",
                }
            });
            var updateNodetype = updateNodetype_lro.Value;
        }
    }
}
