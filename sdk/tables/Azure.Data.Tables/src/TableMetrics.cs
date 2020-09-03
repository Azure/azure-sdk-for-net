// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Azure.Core;

namespace Azure.Data.Tables.Models
{
    [CodeGenModel("Metrics")]
    public partial class TableMetrics
    {
        /// <summary> Indicates whether metrics should generate summary statistics for called API operations. </summary>
        [CodeGenMember("IncludeAPIs")]
        public bool? IncludeApis { get; set; }
    }
}
