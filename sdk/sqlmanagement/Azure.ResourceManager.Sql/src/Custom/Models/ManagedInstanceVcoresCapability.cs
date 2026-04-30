// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Sql.Models
{
    public partial class ManagedInstanceVcoresCapability
    {
        /// <summary>
        /// Supported memory sizes in MB. Deprecated, use SupportedMemoryLimitsInMB.
        /// </summary>
        [Obsolete("This property is deprecated and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("supportedMemoryLimitsMB")]
        public MaxLimitRangeCapability SupportedMemoryLimitsMB
        {
            get
            {
                return SupportedMemoryLimitsInMB;
            }
        }
    }
}
