// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.ResourceManager.Quota.Models
{
    internal partial class QuotaRequestDetailData
    {
        /// <summary> Quota request details. </summary>
        [WirePath("properties.value")]
        public IReadOnlyList<QuotaSubRequestDetail> Value { get; }
    }
}
