/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Compute
{

    using Microsoft.Azure.Management.V2.Resource.Core;
    /// <summary>
    /// implementation of {@link VirtualMachineScaleSetSku}.
    /// </summary>
    public partial class VirtualMachineScaleSetSkuImpl  :
        WrapperImpl<VirtualMachineScaleSetSkuInner>,
        IVirtualMachineScaleSetSku
    {
        private  VirtualMachineScaleSetSkuImpl (VirtualMachineScaleSetSkuInner inner)
        {

            //$ super(inner);
            //$ }

        }

        public string ResourceType
        {
            get
            {
            //$ return this.inner().resourceType();


                return null;
            }
        }
        public VirtualMachineScaleSetSkuTypes SkuType ()
        {

            //$ return new VirtualMachineScaleSetSkuTypes(this.inner().sku());

            return null;
        }

        public VirtualMachineScaleSetSkuCapacity Capacity
        {
            get
            {
            //$ return this.inner().capacity();


                return null;
            }
        }
    }
}