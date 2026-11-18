// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Search.Documents.KnowledgeBases.Models
{
    public partial class CompletedSynchronizationState
    {
        /// <summary> The start time of the last completed synchronization. </summary>
        [CodeGenMember("StartsOn")]
        public DateTimeOffset StartTime { get; set; }

        /// <summary> The end time of the last completed synchronization. </summary>
        [CodeGenMember("EndsOn")]
        public DateTimeOffset EndTime { get; set; }
    }
}
