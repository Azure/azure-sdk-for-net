// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.HybridCompute.Models
{
    // Backward-compat justification: the GA license profile patch exposed flattened properties with legacy WirePath values, while the migrated model delegates to the new nested patch shape.
    public partial class HybridComputeLicenseProfilePatch
    {
        /// <summary> Specifies if this machine is licensed as part of a Software Assurance agreement. </summary>
        [WirePath("properties.softwareAssuranceCustomer")]
        public bool? SoftwareAssuranceCustomer
        {
            get => Properties is null ? default : Properties.SoftwareAssuranceCustomer;
            set
            {
                if (Properties is null)
                {
                    Properties = new LicenseProfileUpdateProperties();
                }
                Properties.SoftwareAssuranceCustomer = value;
            }
        }

        /// <summary> The resource id of the license. </summary>
        [WirePath("properties.assignedLicense")]
        public string AssignedLicense
        {
            get => Properties is null ? default : Properties.AssignedLicense;
            set
            {
                if (Properties is null)
                {
                    Properties = new LicenseProfileUpdateProperties();
                }
                Properties.AssignedLicense = value;
            }
        }

        /// <summary> Indicates the subscription status of the product. </summary>
        [WirePath("properties.subscriptionStatus")]
        public LicenseProfileSubscriptionStatusUpdate? SubscriptionStatus
        {
            get => Properties is null ? default : Properties.SubscriptionStatus;
            set
            {
                if (Properties is null)
                {
                    Properties = new LicenseProfileUpdateProperties();
                }
                Properties.SubscriptionStatus = value;
            }
        }

        /// <summary> Indicates the product type of the license. </summary>
        [WirePath("properties.productType")]
        public LicenseProfileProductType? ProductType
        {
            get => Properties is null ? default : Properties.ProductType;
            set
            {
                if (Properties is null)
                {
                    Properties = new LicenseProfileUpdateProperties();
                }
                Properties.ProductType = value;
            }
        }

        /// <summary> The list of product feature updates. </summary>
        [WirePath("properties.productFeatures")]
        public IList<HybridComputeProductFeatureUpdate> ProductFeatures
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new LicenseProfileUpdateProperties();
                }
                return Properties.ProductFeatures;
            }
        }
    }
}