// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.Translation.Document.Models
{
    internal partial class StatusSummary
    {
        /// <summary> Number of canceled. </summary>
        [CodeGenMember("Cancelled")]
        public int Canceled { get; }
    }
}
