// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Sql.Models
{
    /// <summary> The managed instance virtual cores capability. </summary>
    public partial class ManagedInstanceVcoresCapability
    {
        /// <summary>
        /// Supported memory sizes in MB. Deprecated, use SupportedMemorySizesInGB.
        /// </summary>
        [Obsolete("This property is deprecated and will be removed in a future release.")]
        [WirePath("supportedMemoryLimitsMB")]
        public MaxLimitRangeCapability SupportedMemoryLimitsMB
        {
            get
            {
                return ConvertFromGBtoMB(SupportedMemorySizesInGB);
            }
        }

        private MaxLimitRangeCapability ConvertFromGBtoMB(MaxLimitRangeCapability value)
        {
            return new MaxLimitRangeCapability(
                minValue: value.MinValue.HasValue ? value.MinValue.Value * 1024 : null,
                maxValue: value.MaxValue.HasValue ? value.MaxValue.Value * 1024 : null,
                scaleSize: value.ScaleSize.HasValue ? value.ScaleSize.Value * 1024 : null,
                status: value.Status,
                reason: value.Reason,
                serializedAdditionalRawData: null);
        }
    }
}
