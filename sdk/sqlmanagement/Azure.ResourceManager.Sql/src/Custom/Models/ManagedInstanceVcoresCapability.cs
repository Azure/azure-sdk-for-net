// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

#pragma warning disable CS1591
namespace Azure.ResourceManager.Sql.Models
{
    public partial class ManagedInstanceVcoresCapability
    {
        /// <summary> Memory limit MB ranges. </summary>
        [WirePath("supportedMemoryLimitsMB")]
        public MaxLimitRangeCapability SupportedMemoryLimitsInMB { get; }

        /// <summary> Memory limit MB ranges. </summary>
        [WirePath("supportedMemoryLimitsMB")]
        [Obsolete("This property is obsolete and will be removed in a future release.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MaxLimitRangeCapability SupportedMemoryLimitsMB => SupportedMemoryLimitsInMB;
    }
}
