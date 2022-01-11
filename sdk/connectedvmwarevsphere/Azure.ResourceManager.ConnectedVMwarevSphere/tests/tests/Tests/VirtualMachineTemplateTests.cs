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
    public class VirtualMachineTemplateTests : ConnectedVMwareTestBase
    {
        private VirtualMachineTemplateCollection _virtualMachineTemplateCollection;
        public VirtualMachineTemplateTests(bool isAsync) : base(isAsync)
        {
        }

        [AsyncOnly]
        [TestCase]
        [RecordedTest]
        public async Task CreateDeleteVirtualMachineTemplate()
        {
            string vmtemplateName = Recording.GenerateAssetName("testvmtemplate");
            _virtualMachineTemplateCollection = _resourceGroup.GetVirtualMachineTemplates();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                Type = EXTENDED_LOCATION_TYPE
            };
            var virtualMachineTemplateBody = new VirtualMachineTemplateData(DefaultLocation);
            virtualMachineTemplateBody.MoRefId = "vm-75";
            virtualMachineTemplateBody.VCenterId = VcenterId;
            virtualMachineTemplateBody.ExtendedLocation = _extendedLocation;
            //create virtual machine template
            VirtualMachineTemplate vmtemplate1 = (await _virtualMachineTemplateCollection.CreateOrUpdateAsync(vmtemplateName, virtualMachineTemplateBody)).Value;
            Assert.IsNotNull(vmtemplate1);
            Assert.AreEqual(vmtemplate1.Id.Name, vmtemplateName);
        }
    }
}
