﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    [CodeGenModel("ModelSummary")]
    public partial class DocumentModelSummary
    {
        /// <summary>
        /// Date and time (UTC) when the model was created.
        /// </summary>
        [CodeGenMember("CreatedDateTime")]
        public DateTimeOffset CreatedOn { get; }

        /// <summary>
        /// Date and time (UTC) when the document model will expire.
        /// </summary>
        [CodeGenMember("ExpirationDateTime")]
        public DateTimeOffset? ExpiresOn { get; }

        /// <summary> API version used to create this model. </summary>
        internal string ApiVersion { get; }
    }
}
