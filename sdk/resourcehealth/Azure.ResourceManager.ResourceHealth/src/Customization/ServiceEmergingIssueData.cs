// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.ResourceHealth.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ResourceHealth
{
    // This is required because the generated property is IList<T>, while GA exposed IReadOnlyList<T>,
    // and @@alternateType cannot change the collection interface type.
    public partial class ServiceEmergingIssueData
    {
        /// <summary> The list of emerging issues of banner type. </summary>
        public IReadOnlyList<EmergingIssueBannerType> StatusBanners
        {
            get
            {
                return Properties?.StatusBanners as IReadOnlyList<EmergingIssueBannerType>;
            }
        }

        /// <summary> The list of emerging issues of active event type. </summary>
        public IReadOnlyList<EmergingIssueActiveEventType> StatusActiveEvents
        {
            get
            {
                return Properties?.StatusActiveEvents as IReadOnlyList<EmergingIssueActiveEventType>;
            }
        }
    }
}
