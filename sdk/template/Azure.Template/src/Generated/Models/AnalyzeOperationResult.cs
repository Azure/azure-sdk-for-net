// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.Template.Models
{
    /// <summary> Status and result of the queued analyze operation. </summary>
    public partial class AnalyzeOperationResult
    {
        /// <summary> Status of the queued operation. </summary>
        public OperationStatus Status { get; set; }
        /// <summary> Date and time (UTC) when the analyze operation was submitted. </summary>
        public DateTimeOffset CreatedDateTime { get; set; }
        /// <summary> Date and time (UTC) when the status was last updated. </summary>
        public DateTimeOffset LastUpdatedDateTime { get; set; }
        /// <summary> Analyze operation result. </summary>
        public AnalyzeResult AnalyzeResult { get; set; }
    }
}
