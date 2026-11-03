// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Monitor.Models;

namespace Azure.ResourceManager.Monitor
{
    // Preserve the property types shipped in the GA SDK.
    public partial class VmInsightsOnboardingStatusData
    {
        /// <summary> The resource identifier whose onboarding status is represented. </summary>
        public ResourceIdentifier ResourceId => Properties?.ResourceId is string resourceId ? new ResourceIdentifier(resourceId) : null;

        /// <summary> The onboarding status of the resource. </summary>
        public OnboardingStatus? OnboardingStatus => Properties?.OnboardingStatus.ToString() is null ? (OnboardingStatus?)null : Properties.OnboardingStatus;

        /// <summary> The status of VM Insights data from the resource. </summary>
        public DataStatus? DataStatus => Properties?.DataStatus.ToString() is null ? (DataStatus?)null : Properties.DataStatus;

        /// <summary> Containers that store VM Insights data for the resource. </summary>
        public IReadOnlyList<DataContainer> Data => Properties?.Data as IReadOnlyList<DataContainer> ?? Properties?.Data?.ToArray() ?? Array.Empty<DataContainer>();
    }
}
