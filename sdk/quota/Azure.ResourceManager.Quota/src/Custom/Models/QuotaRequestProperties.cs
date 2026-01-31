// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.ResourceManager.Quota.Models
{
    internal partial class QuotaRequestProperties
    {
        /// <summary> Quota request details. </summary>
        [WirePath("value")]
        public IReadOnlyList<QuotaSubRequestDetail> Value { get; }
    }
}
