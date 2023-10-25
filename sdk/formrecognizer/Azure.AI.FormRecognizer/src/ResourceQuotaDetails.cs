// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    [CodeGenModel("QuotaDetails")]
    public partial class ResourceQuotaDetails
    {
        /// <summary>
        /// Date/time when the resource quota usage will be reset.
        /// </summary>
        [CodeGenMember("QuotaResetDateTime")]
        public DateTimeOffset QuotaResetsOn { get; }
    }
}
