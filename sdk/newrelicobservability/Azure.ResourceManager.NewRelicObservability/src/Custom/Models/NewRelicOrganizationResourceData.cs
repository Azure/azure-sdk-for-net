// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.NewRelicObservability.Models
{
    [CodeGenSuppress("Properties")]
    [CodeGenSuppress("OrganizationId")]
    [CodeGenSuppress("OrganizationName")]
    [CodeGenSuppress("BillingSource")]
    public partial class NewRelicOrganizationResourceData
    {
        /// <summary> Initializes a new instance of <see cref="NewRelicOrganizationResourceData"/>. </summary>
        public NewRelicOrganizationResourceData()
        {
        }

        /// <summary> The resource-specific properties for this resource. </summary>
        [WirePath("properties")]
        internal OrganizationProperties Properties { get; set; }

        /// <summary> organization id. </summary>
        [WirePath("properties.organizationId")]
        public string OrganizationId
        {
            get => Properties?.OrganizationId;
            [EditorBrowsable(EditorBrowsableState.Never)]
            set
            {
                Properties ??= new OrganizationProperties();
                Properties.OrganizationId = value;
            }
        }

        /// <summary> organization name. </summary>
        [WirePath("properties.organizationName")]
        public string OrganizationName
        {
            get => Properties?.OrganizationName;
            [EditorBrowsable(EditorBrowsableState.Never)]
            set
            {
                Properties ??= new OrganizationProperties();
                Properties.OrganizationName = value;
            }
        }

        /// <summary> Billing source. </summary>
        [WirePath("properties.billingSource")]
        public NewRelicObservabilityBillingSource? BillingSource
        {
            get => Properties?.BillingSource;
            [EditorBrowsable(EditorBrowsableState.Never)]
            set
            {
                Properties ??= new OrganizationProperties();
                Properties.BillingSource = value;
            }
        }
    }
}
