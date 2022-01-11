// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ConnectedVMwarevSphere;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.ConnectedVMwarevSphere.Models;
using Azure.ResourceManager.ConnectedVMwarevSphere.Tests.Helpers;

namespace Azure.ResourceManager.ConnectedVMwarevSphere.Tests.tests.Tests
{
    public class ResourcePoolTests : ConnectedVMwareTestBase
    {
        private ResourcePoolCollection _resourcePoolCollection;
        public ResourcePoolTests(bool isAsync) : base(isAsync)
        {
        }

        [AsyncOnly]
        [TestCase]
        [RecordedTest]
        public async Task CreateDeleteResourcePool()
        {
            string resourcePoolName = Recording.GenerateAssetName("testresourcepool");
            _resourcePoolCollection = _resourceGroup.GetResourcePools();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                Type = EXTENDED_LOCATION_TYPE
            };
            var resourcePoolBody = new ResourcePoolData(DefaultLocation);
            resourcePoolBody.MoRefId = "resgroup-89261";
            resourcePoolBody.VCenterId = VcenterId;
            resourcePoolBody.ExtendedLocation = _extendedLocation;
            //create resource pool
            ResourcePool resourcePool1 = (await _resourcePoolCollection.CreateOrUpdateAsync(resourcePoolName, resourcePoolBody)).Value;
            Assert.IsNotNull(resourcePool1);
            Assert.AreEqual(resourcePool1.Id.Name, resourcePoolName);
        }
    }
}
