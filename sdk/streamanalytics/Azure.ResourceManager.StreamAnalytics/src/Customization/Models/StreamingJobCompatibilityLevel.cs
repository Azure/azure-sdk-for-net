// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.StreamAnalytics.Models
{
    /// <summary>
    /// Controls certain runtime behaviors of the streaming job.
    /// </summary>
    public readonly partial struct StreamingJobCompatibilityLevel : IEquatable<StreamingJobCompatibilityLevel>
    {
#pragma warning disable CA1707
        /// <summary> 1.0 </summary>
        [CodeGenMember("One0")]
        public static StreamingJobCompatibilityLevel Level1_0 { get; } = new StreamingJobCompatibilityLevel(Level1_0Value);
        /// <summary> 1.2 </summary>
        [CodeGenMember("One2")]
        public static StreamingJobCompatibilityLevel Level1_2 { get; } = new StreamingJobCompatibilityLevel(Level1_2Value);
#pragma warning restore CA1707
    }
}
