// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.ResourceHealth.Models;

namespace Azure.ResourceManager.ResourceHealth
{
    // This is required because the generated property is IList<T>, while GA exposed IReadOnlyList<T>,
    // and @@alternateType cannot change the collection interface type.
    public partial class ResourceHealthEventData
    {
        /// <summary> Frequently asked questions for the service health event. </summary>
        public IReadOnlyList<ResourceHealthEventFaq> Faqs => Properties?.Faqs as IReadOnlyList<ResourceHealthEventFaq>;

        /// <summary> List services impacted by the service health event. </summary>
        // Same IReadOnlyList<T> compatibility shim as Faqs for the generated IList<T> property.
        public IReadOnlyList<ResourceHealthEventImpact> Impact => Properties?.Impact as IReadOnlyList<ResourceHealthEventImpact>;

        /// <summary> Useful links of event. </summary>
        // Same IReadOnlyList<T> compatibility shim as Faqs for the generated IList<T> property.
        public IReadOnlyList<ResourceHealthEventLink> Links => Properties?.Links as IReadOnlyList<ResourceHealthEventLink>;

        /// <summary> Azure Resource Graph query to fetch the affected resources from their existing Azure Resource Graph locations. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ArgQuery { get; }

        /// <summary> Unique identifier for planned maintenance event. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string MaintenanceId { get; }

        /// <summary> The type of planned maintenance event. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string MaintenanceType { get; }
    }
}
