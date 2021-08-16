// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network;

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

        protected async Task<VirtualMachineScaleSetContainer> GetVirtualMachineScaleSetContainerAsync()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            return _resourceGroup.GetVirtualMachineScaleSets();
        }

        protected async Task<Subnet> CreateBasicDependenciesOfVirtualMachineScaleSetAsync()
        {
            await CreateVirtualNetworkAsync();
            return await CreateSubnetAsync();
        }
    }
}
