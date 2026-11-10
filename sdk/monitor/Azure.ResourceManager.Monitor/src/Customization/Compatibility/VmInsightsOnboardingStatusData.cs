// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.ResourceManager.Monitor.Models;

namespace Azure.ResourceManager.Monitor
{
    // Preserve the property types shipped in the GA SDK.
    public partial class VmInsightsOnboardingStatusData
    {
        // Preserve the GA nullable property: required spec fields generate non-nullable extensible enums.
        // A default enum has no underlying string and must be exposed as null, not a nullable with HasValue set.
        /// <summary> The onboarding status of the resource. </summary>
        public OnboardingStatus? OnboardingStatus => Properties?.OnboardingStatus.ToString() is null ? (OnboardingStatus?)null : Properties.OnboardingStatus;

        // Preserve the GA nullable property and expose an absent/default generated status as null.
        /// <summary> The status of VM Insights data from the resource. </summary>
        public DataStatus? DataStatus => Properties?.DataStatus.ToString() is null ? (DataStatus?)null : Properties.DataStatus;

        // Preserve the GA IReadOnlyList surface instead of the generated IList, and return an empty collection when absent.
        /// <summary> Containers that store VM Insights data for the resource. </summary>
        public IReadOnlyList<DataContainer> Data => Properties?.Data as IReadOnlyList<DataContainer> ?? Properties?.Data?.ToArray() ?? Array.Empty<DataContainer>();
    }
}
