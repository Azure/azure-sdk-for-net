// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    /// <summary> The categories of resource that is at risk when the assessment is unhealthy. </summary>
    [CodeGenSuppress("Iot")]
    public readonly partial struct SecurityAssessmentResourceCategory : IEquatable<SecurityAssessmentResourceCategory>
    {
        /// <summary> IoT. </summary>
        public static SecurityAssessmentResourceCategory IoT { get; } = new SecurityAssessmentResourceCategory(IotValue);
    }
}
