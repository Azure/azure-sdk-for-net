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
    public class DatastoreTests : ConnectedVMwareTestBase
    {
        private VMwareDatastoreCollection _datastoreCollection;
        public DatastoreTests(bool isAsync) : base(isAsync)
        {
        }

        [AsyncOnly]
        [TestCase]
        [RecordedTest]
        public async Task CreateDeleteDatastore()
        {
            ResourceGroup _resourceGroup = await CreateResourceGroupAsync();
            string datastoreName = Recording.GenerateAssetName("testdatastore");
            _datastoreCollection = _resourceGroup.GetVMwareDatastores();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                Type = EXTENDED_LOCATION_TYPE
            };
            var datastoreBody = new VMwareDatastoreData(DefaultLocation);
            datastoreBody.MoRefId = "datastore-11";
            datastoreBody.VCenterId = VcenterId;
            datastoreBody.ExtendedLocation = _extendedLocation;
            //create datastore
            VMwareDatastore datastore1 = (await _datastoreCollection.CreateOrUpdateAsync(datastoreName, datastoreBody)).Value;
            Assert.IsNotNull(datastore1);
            Assert.AreEqual(datastore1.Id.Name, datastoreName);
        }
    }
}
