// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility: restore IReadOnlyList<T> return types for collection properties.
// GA 1.0.0 exposed these as IReadOnlyList<T> because the old AutoRest generator flattened
// properties and used read-only collections for output models. The new TypeSpec generator
// uses a Properties bag pattern with IList<T>. @@alternateType cannot change collection
// interface types (IList→IReadOnlyList), so CodeGenSuppress + manual shims are required.

using System.Collections.Generic;
using Azure.ResourceManager.ResourceHealth.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ResourceHealth
{
    [CodeGenSuppress("Faqs")]
    [CodeGenSuppress("Impact")]
    [CodeGenSuppress("Links")]
    public partial class ResourceHealthEventData
    {
        /// <summary> Frequently asked questions for the service health event. </summary>
        // GA 1.0.0 backward compatibility shim: restores IReadOnlyList<T> return type.
        // The generated property returns IList<ResourceHealthEventFaq> via the Properties bag;
        // this shim suppresses that and re-exposes it as IReadOnlyList<T> to avoid ApiCompat break.
        public IReadOnlyList<ResourceHealthEventFaq> Faqs => Properties?.Faqs as IReadOnlyList<ResourceHealthEventFaq>;

        /// <summary> List services impacted by the service health event. </summary>
        // GA 1.0.0 backward compatibility shim: restores IReadOnlyList<T> return type.
        // Same pattern as Faqs — suppresses the IList<T> generated property.
        public IReadOnlyList<ResourceHealthEventImpact> Impact => Properties?.Impact as IReadOnlyList<ResourceHealthEventImpact>;

        /// <summary> Useful links of event. </summary>
        // GA 1.0.0 backward compatibility shim: restores IReadOnlyList<T> return type.
        // Same pattern as Faqs — suppresses the IList<T> generated property.
        public IReadOnlyList<ResourceHealthEventLink> Links => Properties?.Links as IReadOnlyList<ResourceHealthEventLink>;
    }
}
