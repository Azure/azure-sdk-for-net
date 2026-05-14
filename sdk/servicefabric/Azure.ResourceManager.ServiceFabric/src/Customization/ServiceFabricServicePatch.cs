// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.ServiceFabric.Models
{
    // Backward-compatible flattened properties for ServiceFabricServicePatch.
    // ServiceResourceUpdate.properties is polymorphic (StatefulServiceUpdateProperties /
    // StatelessServiceUpdateProperties), so @@flattenProperty cannot be used in the TypeSpec.
    // These shim properties delegate to the generated Properties bag.
    //
    // PatchProxyResource is replaced with TrackedResource for C# (via @@alternateType),
    // which loses the etag property. Adding it back for backward compatibility.
    public partial class ServiceFabricServicePatch
    {
        private ServiceResourceUpdateProperties EnsureProperties()
        {
            return Properties ?? throw new NotSupportedException("Flattened ServiceFabricServicePatch properties cannot be used when Properties is null because the underlying service properties model is discriminated. Set Properties to a concrete StatefulServiceUpdateProperties or StatelessServiceUpdateProperties instance first.");
        }

        /// <summary> Azure resource etag. </summary>
        public ETag? ETag { get; }

        /// <summary> A list that describes the correlation of the service with other services. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<ServiceCorrelationDescription> CorrelationScheme => EnsureProperties().CorrelationScheme;

        /// <summary> Specifies the move cost for the service. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ApplicationMoveCost? DefaultMoveCost
        {
            get => EnsureProperties().DefaultMoveCost;
            set => EnsureProperties().DefaultMoveCost = value;
        }

        /// <summary> The placement constraints as a string. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string PlacementConstraints
        {
            get => EnsureProperties().PlacementConstraints;
            set => EnsureProperties().PlacementConstraints = value;
        }

        /// <summary> The service load metrics. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<ServiceLoadMetricDescription> ServiceLoadMetrics => EnsureProperties().ServiceLoadMetrics;

        /// <summary> A list that describes the service placement policies. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<ServicePlacementPolicyDescription> ServicePlacementPolicies => EnsureProperties().ServicePlacementPolicies;
    }
}
