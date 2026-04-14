// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.ServiceFabric.Models
{
    // Backward-compatible flattened properties for ServiceFabricServicePatch.
    // ServiceResourceUpdate.properties is polymorphic (StatefulServiceUpdateProperties /
    // StatelessServiceUpdateProperties), so @@flattenProperty cannot be used in the TypeSpec.
    // These shim properties delegate to the generated Properties bag.
    public partial class ServiceFabricServicePatch
    {
        /// <summary> A list that describes the correlation of the service with other services. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<ServiceCorrelationDescription> CorrelationScheme => Properties?.CorrelationScheme;

        /// <summary> Specifies the move cost for the service. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ApplicationMoveCost? DefaultMoveCost
        {
            get => Properties?.DefaultMoveCost;
            set
            {
                if (Properties != null)
                    Properties.DefaultMoveCost = value;
            }
        }

        /// <summary> The placement constraints as a string. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string PlacementConstraints
        {
            get => Properties?.PlacementConstraints;
            set
            {
                if (Properties != null)
                    Properties.PlacementConstraints = value;
            }
        }

        /// <summary> The service load metrics. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<ServiceLoadMetricDescription> ServiceLoadMetrics => Properties?.ServiceLoadMetrics;

        /// <summary> A list that describes the service placement policies. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<ServicePlacementPolicyDescription> ServicePlacementPolicies => Properties?.ServicePlacementPolicies;
    }
}
