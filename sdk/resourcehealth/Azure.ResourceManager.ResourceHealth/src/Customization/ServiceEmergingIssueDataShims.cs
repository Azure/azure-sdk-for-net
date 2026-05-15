// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility: restore IReadOnlyList<T> return types for collection properties.
// GA 1.0.0 exposed these as IReadOnlyList<T>. The TypeSpec generator uses IList<T> in the
// Properties bag (EmergingIssueProperties). @@alternateType cannot change collection interface
// types, so CodeGenSuppress + manual shims are required.

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
        // GA 1.0.0 backward compatibility shim: restores IReadOnlyList<T> return type.
        // The generated property delegates to EmergingIssueProperties.StatusActiveEvents which is IList<T>.
        public IReadOnlyList<EmergingIssueActiveEventType> StatusActiveEvents => EmergingIssueProperties?.StatusActiveEvents as IReadOnlyList<EmergingIssueActiveEventType>;

        /// <summary> The list of emerging issues of banner type. </summary>
        // GA 1.0.0 backward compatibility shim: restores IReadOnlyList<T> return type.
        // Same pattern as StatusActiveEvents.
        public IReadOnlyList<EmergingIssueBannerType> StatusBanners => EmergingIssueProperties?.StatusBanners as IReadOnlyList<EmergingIssueBannerType>;
    }
}
