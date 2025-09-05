// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.IotFirmwareDefense.Models
{
    /// <summary> Properties for a binary hardening analysis summary. </summary>
    public partial class BinaryHardeningSummary
    {
        /// <summary> NX summary percentage. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? NXPercentage => NotExecutableStackCount.HasValue ? (int)NotExecutableStackCount : null;
        /// <summary> PIE summary percentage. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? PiePercentage => PositionIndependentExecutableCount.HasValue ? (int)PositionIndependentExecutableCount : null;
        /// <summary> RELRO summary percentage. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? RelroPercentage => RelocationReadOnlyCount.HasValue ? (int)RelocationReadOnlyCount : null;
        /// <summary> Canary summary percentage. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? CanaryPercentage => StackCanaryCount.HasValue ? (int)StackCanaryCount : null;
        /// <summary> Stripped summary percentage. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? StrippedPercentage => StrippedBinaryCount.HasValue ? (int)StrippedBinaryCount : null;
    }
}
