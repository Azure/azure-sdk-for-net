// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.TextAnalytics.Models;
using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    [CodeGenModel("JobMetadata")]
    public partial class JobMetadata
    {
        /// <summary>
        /// CreatedDateTime
        /// </summary>
        [CodeGenMember("CreatedDateTime")]
        public DateTimeOffset CreatedDateTime { get; }

        /// <summary>
        /// DisplayName
        /// </summary>
        [CodeGenMember("DisplayName")]
        public string DisplayName { get; }

        /// <summary>
        /// ExpirationDateTime
        /// </summary>
        [CodeGenMember("ExpirationDateTime")]
        public DateTimeOffset? ExpirationDateTime { get; }

        /// <summary>
        /// JobId
        /// </summary>
        [CodeGenMember("JobId")]
        public Guid JobId { get; }

        /// <summary>
        /// LastUpdateDateTime
        /// </summary>
        [CodeGenMember("LastUpdateDateTime")]
        public DateTimeOffset LastUpdateDateTime { get; }

        /// <summary>
        /// Status
        /// </summary>
        [CodeGenMember("Status")]
        internal State Status { get; }
    }
}
