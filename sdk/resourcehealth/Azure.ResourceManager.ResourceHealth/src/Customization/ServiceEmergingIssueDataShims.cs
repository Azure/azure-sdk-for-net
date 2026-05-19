// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.ResourceHealth.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ResourceHealth
{
    [CodeGenSuppress("StatusActiveEvents")]
    [CodeGenSuppress("StatusBanners")]
    public partial class ServiceEmergingIssueData
    {
        /// <summary> The list of emerging issues of active event type. </summary>
        // This shim is required because the generated property is IList<T>, while GA 1.0.0 exposed IReadOnlyList<T>,
        // and @@alternateType cannot change the collection interface type.
        public IReadOnlyList<EmergingIssueActiveEventType> StatusActiveEvents => EmergingIssueProperties?.StatusActiveEvents as IReadOnlyList<EmergingIssueActiveEventType>;

        /// <summary> The list of emerging issues of banner type. </summary>
        // Same IReadOnlyList<T> compatibility shim as StatusActiveEvents for the generated IList<T> property.
        public IReadOnlyList<EmergingIssueBannerType> StatusBanners => EmergingIssueProperties?.StatusBanners as IReadOnlyList<EmergingIssueBannerType>;
    }
}
