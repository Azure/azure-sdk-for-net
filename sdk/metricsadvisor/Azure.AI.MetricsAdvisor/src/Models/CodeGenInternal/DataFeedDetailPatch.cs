// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.MetricsAdvisor.Models
{
    internal partial class DataFeedDetailPatch
    {
        public IList<string> RollUpColumns { get; set; }

        /// <summary> the identification value for the row of calculated all-up value. </summary>
        public IList<string> Admins { get; set; }

        /// <summary> data feed viewer. </summary>
        public IList<string> Viewers { get; set; }
    }
}
