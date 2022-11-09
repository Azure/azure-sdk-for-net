// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.TextAnalytics.Models
{
    internal class HealthcareJobStatusResult
    {
        public string NextLink { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset LastModifiedOn { get; set; }
        public DateTimeOffset? ExpiresOn { get; set; }
        public TextAnalyticsOperationStatus Status { get; set; }
        public List<Error> Errors { get; } = new();
        public AnalyzeHealthcareEntitiesResultCollection Result { get; set; }
        public string DisplayName { get; set; }
    }
}
