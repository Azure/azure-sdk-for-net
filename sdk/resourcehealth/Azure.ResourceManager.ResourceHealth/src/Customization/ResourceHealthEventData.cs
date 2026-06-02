// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.ResourceHealth.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ResourceHealth
{
    public partial class ResourceHealthEventData
    {
        /// <summary> Frequently asked questions for the service health event. </summary>
        // This is required because the generated property is IList<T>, while GA exposed IReadOnlyList<T>,
        // and @@alternateType cannot change the collection interface type.
        public IReadOnlyList<ResourceHealthEventFaq> Faqs => Properties?.Faqs as IReadOnlyList<ResourceHealthEventFaq>;

        /// <summary> List services impacted by the service health event. </summary>
        // Same IReadOnlyList<T> compatibility shim as Faqs for the generated IList<T> property.
        public IReadOnlyList<ResourceHealthEventImpact> Impact => Properties?.Impact as IReadOnlyList<ResourceHealthEventImpact>;

        /// <summary> Useful links of event. </summary>
        // Same IReadOnlyList<T> compatibility shim as Faqs for the generated IList<T> property.
        public IReadOnlyList<ResourceHealthEventLink> Links => Properties?.Links as IReadOnlyList<ResourceHealthEventLink>;
    }
}
