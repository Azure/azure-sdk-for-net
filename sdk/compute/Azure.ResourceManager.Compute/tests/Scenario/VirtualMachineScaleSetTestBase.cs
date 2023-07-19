// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.Core;

namespace Azure.ResourceManager.Compute.Tests
{
    public class VirtualMachineScaleSetTestBase : VirtualMachineTestBase
    {
        public VirtualMachineScaleSetTestBase(bool isAsync) : base(isAsync)
        {
        }

        public VirtualMachineScaleSetTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        protected VirtualMachineScaleSetTestBase(bool isAsync, ResourceType resourceType, string apiVersion, RecordedTestMode? mode = null)
            : base(isAsync, resourceType, apiVersion, mode)
        {
        }

        protected async Task<VirtualMachineScaleSetCollection> GetVirtualMachineScaleSetCollectionAsync()
        {
            _genericResourceCollection = Client.GetGenericResources();
            _resourceGroup = await CreateResourceGroupAsync();
            return _resourceGroup.GetVirtualMachineScaleSets();
        }

        protected async Task<GenericResource> CreateBasicDependenciesOfVirtualMachineScaleSetAsync()
        {
            var vnet = await CreateVirtualNetwork();
            return vnet;
        }
    }
}
