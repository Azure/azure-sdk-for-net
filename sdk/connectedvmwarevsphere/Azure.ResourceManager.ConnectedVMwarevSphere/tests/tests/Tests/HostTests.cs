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
    public class HostTests : ConnectedVMwareTestBase
    {
        private VMwareHostCollection _hostCollection;
        public HostTests(bool isAsync) : base(isAsync)
        {
        }

        [AsyncOnly]
        [TestCase]
        [RecordedTest]
        public async Task CreateDeleteHost()
        {
            ResourceGroup _resourceGroup = await CreateResourceGroupAsync();
            string hostName = Recording.GenerateAssetName("testhost");
            _hostCollection = _resourceGroup.GetVMwareHosts();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                Type = EXTENDED_LOCATION_TYPE
            };
            var hostBody = new VMwareHostData(DefaultLocation);
            hostBody.MoRefId = "host-33";
            hostBody.VCenterId = VcenterId;
            hostBody.ExtendedLocation = _extendedLocation;
            //create host
            VMwareHost host1 = (await _hostCollection.CreateOrUpdateAsync(hostName, hostBody)).Value;
            Assert.IsNotNull(host1);
            Assert.AreEqual(host1.Id.Name, hostName);
        }
    }
}
