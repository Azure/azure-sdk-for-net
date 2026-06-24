// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.ResourceHealth.Models;

namespace Azure.ResourceManager.ResourceHealth
{
    // GA exposed these collection properties as IReadOnlyList<T>, but the generated flattened properties
    // are IList<T> and no client.tsp decorator can change the collection interface. Re-expose them as
    // IReadOnlyList<T> to preserve the GA surface; the generator omits its IList<T> versions because these
    // custom members already define the names.
    public partial class ResourceHealthEventData
    {
        /// <summary> Useful links of event. </summary>
        public IReadOnlyList<ResourceHealthEventLink> Links => Properties?.Links as IReadOnlyList<ResourceHealthEventLink>;

        /// <summary> List services impacted by the service health event. </summary>
        public IReadOnlyList<ResourceHealthEventImpact> Impact => Properties?.Impact as IReadOnlyList<ResourceHealthEventImpact>;

        /// <summary> Frequently asked questions for the service health event. </summary>
        public IReadOnlyList<ResourceHealthEventFaq> Faqs => Properties?.Faqs as IReadOnlyList<ResourceHealthEventFaq>;
    }
}
