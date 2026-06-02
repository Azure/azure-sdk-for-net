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
    public partial class NewRelicPlanData
    {
        /// <summary> Initializes a new instance of <see cref="NewRelicPlanData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NewRelicPlanData()
        {
        }

        /// <summary> The resource-specific properties for this resource. </summary>
        [WirePath("properties")]
        internal PlanDataProperties Properties { get; set; }

        /// <summary> Plan details. </summary>
        [WirePath("properties.planData")]
        public NewRelicPlanDetails PlanData
        {
            get => Properties?.PlanData;
            [EditorBrowsable(EditorBrowsableState.Never)]
            set
            {
                Properties ??= new PlanDataProperties();
                Properties.PlanData = value;
            }
        }

        /// <summary> Source of org creation. </summary>
        [WirePath("properties.orgCreationSource")]
        public NewRelicObservabilityOrgCreationSource? OrgCreationSource
        {
            get => Properties?.OrgCreationSource;
            [EditorBrowsable(EditorBrowsableState.Never)]
            set
            {
                Properties ??= new PlanDataProperties();
                Properties.OrgCreationSource = value;
            }
        }

        /// <summary> Source of account creation. </summary>
        [WirePath("properties.accountCreationSource")]
        public NewRelicObservabilityAccountCreationSource? AccountCreationSource
        {
            get => Properties?.AccountCreationSource;
            [EditorBrowsable(EditorBrowsableState.Never)]
            set
            {
                Properties ??= new PlanDataProperties();
                Properties.AccountCreationSource = value;
            }
        }
    }
}
