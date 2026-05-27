// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure;
using Azure.ResourceManager.HybridCompute.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.HybridCompute
{
    // Preserve previous GA WirePath attributes while delegating to the new nested license profile shape.
    public partial class HybridComputeLicenseProfileData
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
                    Properties = new LicenseProfileProperties();
                }
                Properties.SoftwareAssuranceCustomer = value;
            }
        }

        /// <summary> The guid id of the license. </summary>
        [WirePath("properties.assignedLicenseImmutableId")]
        public Guid? AssignedLicenseImmutableId => Properties is null ? default : Properties.AssignedLicenseImmutableId;

        /// <summary> The list of ESU keys. </summary>
        [WirePath("properties.esuKeys")]
        public IReadOnlyList<EsuKey> EsuKeys
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new LicenseProfileProperties();
                }
                return Properties.EsuKeys;
            }
        }

        /// <summary> The type of the Esu servers. </summary>
        [WirePath("properties.serverType")]
        public EsuServerType? ServerType => Properties is null ? default : Properties.ServerType;

        /// <summary> Indicates the eligibility state of Esu. </summary>
        [WirePath("properties.esuEligibility")]
        public EsuEligibility? EsuEligibility => Properties is null ? default : Properties.EsuEligibility;

        /// <summary> Indicates whether there is an ESU Key currently active for the machine. </summary>
        [WirePath("properties.esuKeyState")]
        public EsuKeyState? EsuKeyState => Properties is null ? default : Properties.EsuKeyState;

        /// <summary> The resource id of the license. </summary>
        [WirePath("properties.assignedLicense")]
        public string AssignedLicense
        {
            get => Properties is null ? default : Properties.AssignedLicense;
            set
            {
                if (Properties is null)
                {
                    Properties = new LicenseProfileProperties();
                }
                Properties.AssignedLicense = value;
            }
        }

        /// <summary> Indicates the subscription status of the product. </summary>
        [WirePath("properties.subscriptionStatus")]
        public LicenseProfileSubscriptionStatus? SubscriptionStatus
        {
            get => Properties is null ? default : Properties.SubscriptionStatus;
            set
            {
                if (Properties is null)
                {
                    Properties = new LicenseProfileProperties();
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
                    Properties = new LicenseProfileProperties();
                }
                Properties.ProductType = value;
            }
        }

        /// <summary> The timestamp in UTC when the user enrolls the feature. </summary>
        [WirePath("properties.enrollmentDate")]
        public DateTimeOffset? EnrollmentOn => Properties is null ? default : Properties.EnrollmentOn;

        /// <summary> The timestamp in UTC when the billing starts. </summary>
        [WirePath("properties.billingStartDate")]
        public DateTimeOffset? BillingStartOn => Properties is null ? default : Properties.BillingStartOn;

        /// <summary> The timestamp in UTC when the user disenrolled the feature. </summary>
        [WirePath("properties.disenrollmentDate")]
        public DateTimeOffset? DisenrollmentOn => Properties is null ? default : Properties.DisenrollmentOn;

        /// <summary> The timestamp in UTC when the billing ends. </summary>
        [WirePath("properties.billingEndDate")]
        public DateTimeOffset? BillingEndOn => Properties is null ? default : Properties.BillingEndOn;

        /// <summary> The errors that were encountered during the feature enrollment or disenrollment. </summary>
        [WirePath("properties.error")]
        public ResponseError Error => Properties is null ? default : Properties.Error;

        /// <summary> The list of product features. </summary>
        [WirePath("properties.productFeatures")]
        public IList<HybridComputeProductFeature> ProductFeatures
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new LicenseProfileProperties();
                }
                return Properties.ProductFeatures;
            }
        }
    }
}
