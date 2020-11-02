// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    [CodeGenModel("PiiTask")]
    public partial class PiiTask
    {

        /// <summary>
        /// Parameters for PiiTask
        /// </summary>
        public PiiTaskParameters Parameters { get; set; }

    }
}
