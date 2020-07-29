// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Data.Tables.Models
{
    /// <summary> An Access policy. </summary>
    [CodeGenModel("AccessPolicy")]
    public partial class TableAccessPolicy
    {
        /// <summary> The start datetime from which the policy is active. </summary>
        [CodeGenMember("Start")]
        public DateTimeOffset StartsOn { get; set; }
        /// <summary> The datetime that the policy expires. </summary>
        [CodeGenMember("Expiry")]
        public DateTimeOffset ExpiresOn { get; set; }
    }
}
