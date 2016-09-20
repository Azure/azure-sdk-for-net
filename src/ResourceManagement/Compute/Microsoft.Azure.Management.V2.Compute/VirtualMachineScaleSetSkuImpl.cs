/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Compute
{
    using Management.Compute.Models;
    using Microsoft.Azure.Management.V2.Resource.Core;
    /// <summary>
    /// implementation of {@link VirtualMachineScaleSetSku}.
    /// </summary>
    public partial class VirtualMachineScaleSetSkuImpl  :
        Wrapper<VirtualMachineScaleSetSku>,
        IVirtualMachineScaleSetSku
    {
        // TODO: Report bug -> autorest generator is not appendeing 'Inner' to type Microsoft.Azure.Management.Compute.Models.VirtualMachineScaleSetSku
        private VirtualMachineScaleSetSkuImpl (VirtualMachineScaleSetSku inner) : base(inner)
        {
        }

        public string ResourceType
        {
            get
            {
                return Inner.ResourceType;
            }
        }

        public VirtualMachineScaleSetSkuTypes SkuType ()
        {
            return new VirtualMachineScaleSetSkuTypes(this.Inner.Sku);
        }

        public VirtualMachineScaleSetSkuCapacity Capacity
        {
            get
            {
                return this.Inner.Capacity;
            }
        }
    }
}