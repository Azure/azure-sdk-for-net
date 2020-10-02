// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    internal partial class DataFeedDetailPatch
    {
        private IList<string> _rollUpColumns;
        private IList<string> _admins;
        private IList<string> _viewers;

        public IList<string> RollUpColumns { get => _rollUpColumns; set => _rollUpColumns = value ?? new ChangeTrackingList<string>(); }

        /// <summary> the identification value for the row of calculated all-up value. </summary>
        public IList<string> Admins { get => _admins; set => _admins = value ?? new ChangeTrackingList<string>(); }

        /// <summary> data feed viewer. </summary>
        public IList<string> Viewers { get => _viewers; set => _viewers = value ?? new ChangeTrackingList<string>(); }
    }
}
