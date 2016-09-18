/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Compute
{


    /// <summary>
    /// Scale set virtual machine sku types.
    /// </summary>
    public partial class VirtualMachineScaleSetSkuTypes 
    {
        public VirtualMachineScaleSetSkuTypes STANDARD_A0;
        public VirtualMachineScaleSetSkuTypes STANDARD_A1;
        public VirtualMachineScaleSetSkuTypes STANDARD_A2;
        public VirtualMachineScaleSetSkuTypes STANDARD_A3;
        public VirtualMachineScaleSetSkuTypes STANDARD_A4;
        public VirtualMachineScaleSetSkuTypes STANDARD_A5;
        public VirtualMachineScaleSetSkuTypes STANDARD_A6;
        public VirtualMachineScaleSetSkuTypes STANDARD_A7;
        public VirtualMachineScaleSetSkuTypes STANDARD_A8;
        public VirtualMachineScaleSetSkuTypes STANDARD_A9;
        public VirtualMachineScaleSetSkuTypes STANDARD_A10;
        public VirtualMachineScaleSetSkuTypes STANDARD_A11;
        public VirtualMachineScaleSetSkuTypes STANDARD_D1;
        public VirtualMachineScaleSetSkuTypes STANDARD_D2;
        public VirtualMachineScaleSetSkuTypes STANDARD_D3;
        public VirtualMachineScaleSetSkuTypes STANDARD_D4;
        public VirtualMachineScaleSetSkuTypes STANDARD_D11;
        public VirtualMachineScaleSetSkuTypes STANDARD_D12;
        public VirtualMachineScaleSetSkuTypes STANDARD_D13;
        public VirtualMachineScaleSetSkuTypes STANDARD_D14;
        public VirtualMachineScaleSetSkuTypes STANDARD_D1_V2;
        public VirtualMachineScaleSetSkuTypes STANDARD_D2_V2;
        public VirtualMachineScaleSetSkuTypes STANDARD_D3_V2;
        public VirtualMachineScaleSetSkuTypes STANDARD_D4_V2;
        public VirtualMachineScaleSetSkuTypes STANDARD_D5_V2;
        public VirtualMachineScaleSetSkuTypes STANDARD_D11_V2;
        public VirtualMachineScaleSetSkuTypes STANDARD_D12_V2;
        public VirtualMachineScaleSetSkuTypes STANDARD_D13_V2;
        public VirtualMachineScaleSetSkuTypes STANDARD_D14_V2;
        public VirtualMachineScaleSetSkuTypes STANDARD_D15_V2;
        public VirtualMachineScaleSetSkuTypes STANDARD_DS1;
        public VirtualMachineScaleSetSkuTypes STANDARD_DS2;
        public VirtualMachineScaleSetSkuTypes STANDARD_DS3;
        public VirtualMachineScaleSetSkuTypes STANDARD_DS4;
        public VirtualMachineScaleSetSkuTypes STANDARD_DS11;
        public VirtualMachineScaleSetSkuTypes STANDARD_DS12;
        public VirtualMachineScaleSetSkuTypes STANDARD_DS13;
        public VirtualMachineScaleSetSkuTypes STANDARD_DS14;
        public VirtualMachineScaleSetSkuTypes STANDARD_DS1_V2;
        public VirtualMachineScaleSetSkuTypes STANDARD_DS2_V2;
        public VirtualMachineScaleSetSkuTypes STANDARD_DS3_V2;
        public VirtualMachineScaleSetSkuTypes STANDARD_DS4_V2;
        public VirtualMachineScaleSetSkuTypes STANDARD_DS5_V2;
        public VirtualMachineScaleSetSkuTypes STANDARD_DS11_V2;
        public VirtualMachineScaleSetSkuTypes STANDARD_DS12_V2;
        public VirtualMachineScaleSetSkuTypes STANDARD_DS13_V2;
        public VirtualMachineScaleSetSkuTypes STANDARD_DS14_V2;
        public VirtualMachineScaleSetSkuTypes STANDARD_DS15_V2;
        public VirtualMachineScaleSetSkuTypes STANDARD_F1S;
        public VirtualMachineScaleSetSkuTypes STANDARD_F2S;
        public VirtualMachineScaleSetSkuTypes STANDARD_F4S;
        public VirtualMachineScaleSetSkuTypes STANDARD_F8S;
        public VirtualMachineScaleSetSkuTypes STANDARD_F16S;
        public VirtualMachineScaleSetSkuTypes STANDARD_F1;
        public VirtualMachineScaleSetSkuTypes STANDARD_F2;
        public VirtualMachineScaleSetSkuTypes STANDARD_F4;
        public VirtualMachineScaleSetSkuTypes STANDARD_F8;
        public VirtualMachineScaleSetSkuTypes STANDARD_F16;
        private Sku sku;
        private string value;
        /// <summary>
        /// Creates a custom value for VirtualMachineSizeTypes.
        /// </summary>
        /// <param name="skuName">skuName the sku name</param>
        /// <param name="skuTier">skuTier thr sku tier</param>
        public  VirtualMachineScaleSetSkuTypes (string skuName, string skuTier)
        {

            //$ this(new Sku().withName(skuName).withTier(skuTier));
            //$ }

        }

        /// <summary>
        /// Creates a custom value for VirtualMachineSizeTypes.
        /// </summary>
        /// <param name="sku">sku the sku</param>
        public  VirtualMachineScaleSetSkuTypes (Sku sku)
        {

            //$ this.sku = sku;
            //$ this.value = this.sku.name();
            //$ if (this.sku.tier() != null) {
            //$ this.value = this.value + "_" + this.sku.tier();
            //$ }
            //$ }

        }

        /// <returns>the sku</returns>
        public Sku Sku
        {
            get
            {
            //$ return this.sku;
            //$ }


                return this.sku;
            }
        }
        public string ToString
        {
            get
            {
            //$ return this.value;


                return null;
            }
        }
        public int? HashCode
        {
            get
            {
            //$ return this.value.hashCode();


                return null;
            }
        }
        public bool? Equals (object obj)
        {

            //$ String value = this.toString();
            //$ if (!(obj instanceof VirtualMachineScaleSetSkuTypes)) {
            //$ return false;
            //$ }
            //$ if (obj == this) {
            //$ return true;
            //$ }
            //$ VirtualMachineScaleSetSkuTypes rhs = (VirtualMachineScaleSetSkuTypes) obj;
            //$ if (value == null) {
            //$ return rhs.value == null;
            //$ } else {
            //$ return value.equals(rhs.value);
            //$ }

            return false;
        }

    }
}