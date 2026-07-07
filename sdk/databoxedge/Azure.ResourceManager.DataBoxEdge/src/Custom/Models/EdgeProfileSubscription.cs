// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Baseline had IReadOnlyList<SubscriptionRegisteredFeatures> return type.
// Generated code returns IList<SubscriptionRegisteredFeatures>.
// This shadows the property to restore IReadOnlyList for backward compatibility.

using System.Collections.Generic;

namespace Azure.ResourceManager.DataBoxEdge.Models
{
    public partial class EdgeProfileSubscription
    {
        /// <summary> Gets the registered features. </summary>
        public IReadOnlyList<SubscriptionRegisteredFeatures> RegisteredFeatures
        {
            get => Properties?.RegisteredFeatures as IReadOnlyList<SubscriptionRegisteredFeatures>;
        }
    }
}
