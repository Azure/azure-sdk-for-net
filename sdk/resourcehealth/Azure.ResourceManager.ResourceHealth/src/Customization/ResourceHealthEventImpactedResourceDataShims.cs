// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        // This shim is required because the generated property is IList<T>, while GA 1.0.0 exposed IReadOnlyList<T>,
        // and @@alternateType cannot change the collection interface type.
        public IReadOnlyList<ResourceHealthKeyValueItem> Info => Properties?.Info as IReadOnlyList<ResourceHealthKeyValueItem>;

        /// <summary> Identity for resource within Microsoft cloud. </summary>
        // This shim restores the GA 1.0.0 ResourceIdentifier type because the generated property is string from the Properties bag.
        public ResourceIdentifier TargetResourceId => Properties is null ? default : (Properties.TargetResourceId is null ? default : new ResourceIdentifier(Properties.TargetResourceId));

        /// <summary> Resource type within Microsoft cloud. </summary>
        // This shim restores the GA 1.0.0 ResourceType? because the generated property is string from the Properties bag.
        public ResourceType? TargetResourceType => Properties is null ? default : (Properties.TargetResourceType is null ? default : new ResourceType(Properties.TargetResourceType));
    }
}
