// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.HybridCompute;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.HybridCompute.Models
{
    // Backward-compat justification: the GA instance view model exposed settable flattened license profile properties.
    // These cannot be made settable only with TypeSpec @usage because the backing nested properties are marked visibility.read.
    public partial class LicenseProfileMachineInstanceView
    {
        /// <summary> Gets or sets the SoftwareAssurance. </summary>
        [WirePath("softwareAssurance")]
        private LicenseProfileMachineInstanceViewSoftwareAssurance SoftwareAssurance { get; set; }

        /// <summary> Hybrid Compute Product Profile properties. </summary>
        [WirePath("productProfile")]
        private LicenseProfileArmProductProfileProperties ProductProfile { get; set; }

        /// <summary> Specifies if this machine is licensed as part of a Software Assurance agreement. </summary>
        [WirePath("softwareAssurance.softwareAssuranceCustomer")]
        public bool? IsSoftwareAssuranceCustomer
        {
            get => SoftwareAssurance is null ? default : SoftwareAssurance.IsSoftwareAssuranceCustomer;
            set
            {
                if (SoftwareAssurance is null)
                {
                    SoftwareAssurance = new LicenseProfileMachineInstanceViewSoftwareAssurance();
                }
                SoftwareAssurance.IsSoftwareAssuranceCustomer = value;
            }
        }

        /// <summary> Indicates the subscription status of the product. </summary>
        [WirePath("productProfile.subscriptionStatus")]
        public LicenseProfileSubscriptionStatus? SubscriptionStatus
        {
            get => ProductProfile is null ? default : ProductProfile.SubscriptionStatus;
            set
            {
                if (ProductProfile is null)
                {
                    ProductProfile = new LicenseProfileArmProductProfileProperties();
                }
                ProductProfile.SubscriptionStatus = value;
            }
        }

        /// <summary> Indicates the product type of the license. </summary>
        [WirePath("productProfile.productType")]
        public LicenseProfileProductType? ProductType
        {
            get => ProductProfile is null ? default : ProductProfile.ProductType;
            set
            {
                if (ProductProfile is null)
                {
                    ProductProfile = new LicenseProfileArmProductProfileProperties();
                }
                ProductProfile.ProductType = value;
            }
        }
    }
}
