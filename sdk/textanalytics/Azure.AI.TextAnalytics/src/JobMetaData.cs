// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.TextAnalytics.Models
{
    [CodeGenModel("JobMetadata")]
    public partial class JobMetadata
    {
        [CodeGenMember("Documents")]
        internal DateTimeOffset CreatedDateTime { get; }

        [CodeGenMember("Documents")]
        internal string DisplayName { get; }

        [CodeGenMember("Documents")]
        internal DateTimeOffset? ExpirationDateTime { get; }

        [CodeGenMember("Documents")]
        internal Guid JobId { get; }

        [CodeGenMember("Documents")]
        internal DateTimeOffset LastUpdateDateTime { get; }

        [CodeGenMember("Documents")]
        internal State Status { get; }
    }
}
