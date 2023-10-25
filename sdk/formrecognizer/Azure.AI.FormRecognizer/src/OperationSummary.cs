// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    public partial class OperationSummary
    {
        /// <summary>
        /// Date and time (UTC) when the operation was created.
        /// </summary>
        [CodeGenMember("CreatedDateTime")]
        public DateTimeOffset CreatedOn { get; }

        /// <summary>
        /// Date and time (UTC) when the operation was last updated.
        /// </summary>
        [CodeGenMember("LastUpdatedDateTime")]
        public DateTimeOffset LastUpdatedOn { get; }

        /// <summary>
        /// URI of the resource targeted by this operation.
        /// </summary>
        public Uri ResourceLocation { get; }

        /// <summary>
        /// Service version used to create this operation.
        /// </summary>
        [CodeGenMember("ApiVersion")]
        public string ServiceVersion { get; }
    }
}
