// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility: restore IReadOnlyList<T> for Info, ResourceIdentifier for TargetResourceId,
// and ResourceType? for TargetResourceType.
// GA 1.0.0 exposed these with stronger types. The TypeSpec generator uses string and IList<T> in
// the Properties bag. @@alternateType could fix TargetResourceId and TargetResourceType individually,
// but since Info still requires CodeGenSuppress for IList→IReadOnlyList (which @@alternateType cannot do),
// all three are handled together in this shim file for consistency.

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.ResourceHealth.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ResourceHealth
{
    [CodeGenSuppress("Info")]
    [CodeGenSuppress("TargetResourceId")]
    [CodeGenSuppress("TargetResourceType")]
    public partial class ResourceHealthEventImpactedResourceData
    {
        /// <summary> Additional information. </summary>
        // GA 1.0.0 backward compatibility shim: restores IReadOnlyList<T> return type.
        // The generated property returns IList<ResourceHealthKeyValueItem> via the Properties bag;
        // @@alternateType cannot change collection interface types, so CodeGenSuppress is required.
        public IReadOnlyList<ResourceHealthKeyValueItem> Info => Properties?.Info as IReadOnlyList<ResourceHealthKeyValueItem>;

        /// <summary> Identity for resource within Microsoft cloud. </summary>
        // GA 1.0.0 backward compatibility shim: converts string to ResourceIdentifier.
        // The generated property is string (from the Properties bag). The GA SDK exposed this as
        // ResourceIdentifier. Could alternatively use @@alternateType in client.tsp, but kept here
        // alongside the Info shim for cohesion.
        public ResourceIdentifier TargetResourceId => Properties is null ? default : (Properties.TargetResourceId is null ? default : new ResourceIdentifier(Properties.TargetResourceId));

        /// <summary> Resource type within Microsoft cloud. </summary>
        // GA 1.0.0 backward compatibility shim: converts string to ResourceType?.
        // Same rationale as TargetResourceId — the GA SDK exposed this as ResourceType? but the
        // TypeSpec generator emits string.
        public ResourceType? TargetResourceType => Properties is null ? default : (Properties.TargetResourceType is null ? default : new ResourceType(Properties.TargetResourceType));
    }
}