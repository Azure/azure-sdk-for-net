// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;

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

        protected async Task<VirtualMachineScaleSetCollection> GetVirtualMachineScaleSetCollectionAsync()
        {
            _genericResourceCollection = DefaultSubscription.GetGenericResources();
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
