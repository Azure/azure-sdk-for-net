// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.TextAnalytics.Models
{
    internal class AnalyzeTextJobStatusResult
    {
        public string DisplayName { get; set; }
        public string NextLink { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset LastModifiedOn { get; set; }
        public DateTimeOffset? ExpiresOn { get; set; }
        public TextAnalyticsOperationStatus Status { get; set; }
        public int ActionsFailed { get; set; }
        public int AcionsSucceeded { get; set; }
        public int AcionsInProgress { get; set; }
        public int ActionsTotal { get; set; }
        public List<Error> Errors { get; } = new();
        public AnalyzeActionsResult Result { get; set; }
    }
}
