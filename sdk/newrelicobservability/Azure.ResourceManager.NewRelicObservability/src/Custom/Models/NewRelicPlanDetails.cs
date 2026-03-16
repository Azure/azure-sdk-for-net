// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.NewRelicObservability.Models
{
    // Backward compatibility: The generated NewRelicPlanDetails exposes BillingCycle as a raw
    // string property (NewRelicPlanBillingCycle). The previous SDK exposed it as a strongly-typed
    // NewRelicObservabilityBillingCycle? property. This partial class wraps the generated string
    // property to preserve the old public API surface.
    /// <summary> Plan data of NewRelic Monitor resource. </summary>
    public partial class NewRelicPlanDetails
    {
        /// <summary> Different billing cycles like Monthly/Weekly. </summary>
        public NewRelicObservabilityBillingCycle? BillingCycle { get => new NewRelicObservabilityBillingCycle(NewRelicPlanBillingCycle); set => NewRelicPlanBillingCycle = value.ToString(); }
    }
}
