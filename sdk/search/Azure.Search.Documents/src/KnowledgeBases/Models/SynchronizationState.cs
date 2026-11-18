// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Search.Documents.KnowledgeBases.Models
{
    public partial class SynchronizationState
    {
        /// <summary> The start time of the current synchronization. </summary>
        [CodeGenMember("StartsOn")]
        public DateTimeOffset StartTime { get; set; }
    }
}
