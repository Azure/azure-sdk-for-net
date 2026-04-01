// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.NewRelicObservability.Models
{
    // Backward compatibility: the previous (AutoRest) SDK exposed a public
    // parameterless constructor and setters on the flattened properties.
    // These are response-only models that are never sent to the API, so the
    // setters are non-functional, but removing them would break source
    // compatibility for existing consumers.
    public partial class NewRelicOrganizationResourceData
    {
        /// <summary> Initializes a new instance of <see cref="NewRelicOrganizationResourceData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
