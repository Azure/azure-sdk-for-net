// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Management.Compute.Fluent.Models;
    using Resource.Fluent.Core;
    /// <summary>
    /// implementation of VirtualMachineScaleSetSku.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVTY2FsZVNldFNrdUltcGw=
    internal partial class VirtualMachineScaleSetSkuImpl  :
        Wrapper<VirtualMachineScaleSetSku>,
        IVirtualMachineScaleSetSku
    {
        // TODO: Report bug -> autorest generator is not appending 'Inner' to type Microsoft.Azure.Management.Compute.Fluent.Models.VirtualMachineScaleSetSku
        internal VirtualMachineScaleSetSkuImpl (VirtualMachineScaleSetSku inner) : base(inner)
        {
        }

        ///GENMHASH:EC2A5EE0E9C0A186CA88677B91632991:E4D65CD18BA70B3FDD6DFA5057F1C094
        public string ResourceType()
        {
            return Inner.ResourceType;
        }

        ///GENMHASH:9EF4A08D221595621FDCAFD7FD09AFE2:CEAEE81352B41505EB71BF5E42D2A3B6
        public VirtualMachineScaleSetSkuTypes SkuType()
        {
            return new VirtualMachineScaleSetSkuTypes(this.Inner.Sku);
        }

        ///GENMHASH:F0B439C5B2A4923B3B36B77503386DA7:CBF9CEA159340D17669C03B84D2988B4
        public VirtualMachineScaleSetSkuCapacity Capacity()
        {
            return this.Inner.Capacity;
        }
    }
}