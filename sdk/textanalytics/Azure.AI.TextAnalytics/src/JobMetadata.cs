// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics.Models
{
    /// <summary>
    /// JobMetadata.
    /// </summary>
    [CodeGenModel("JobMetadata")]
    internal partial class JobMetadata
    {
        [CodeGenMember]
        public string JobId { get; }
    }
}
