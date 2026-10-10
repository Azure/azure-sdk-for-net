// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.ResourceHealth.Models;

namespace Azure.ResourceManager.ResourceHealth
{
    // GA exposed these collection properties as IReadOnlyList<T> while the generated flattened properties are
    // IList<T>, and no client.tsp decorator can change the collection interface. Re-expose them as
    // IReadOnlyList<T> to preserve the GA surface; the generator omits its IList<T> versions because these
    // custom members already define the names.
    public partial class ServiceEmergingIssueData
    {
        /// <summary> The list of emerging issues of banner type. </summary>
        public IReadOnlyList<EmergingIssueBannerType> StatusBanners => Properties?.StatusBanners as IReadOnlyList<EmergingIssueBannerType>;

        /// <summary> The list of emerging issues of active event type. </summary>
        public IReadOnlyList<EmergingIssueActiveEventType> StatusActiveEvents => Properties?.StatusActiveEvents as IReadOnlyList<EmergingIssueActiveEventType>;
    }
}
