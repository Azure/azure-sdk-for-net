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
        public int? NXPercentage => (int)NotExecutableStackCount;
        /// <summary> PIE summary percentage. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? PiePercentage => (int)PositionIndependentExecutableCount;
        /// <summary> RELRO summary percentage. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? RelroPercentage => (int)RelocationReadOnlyCount;
        /// <summary> Canary summary percentage. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? CanaryPercentage => (int)StackCanaryCount;
        /// <summary> Stripped summary percentage. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? StrippedPercentage => (int)StrippedBinaryCount;
    }
}
