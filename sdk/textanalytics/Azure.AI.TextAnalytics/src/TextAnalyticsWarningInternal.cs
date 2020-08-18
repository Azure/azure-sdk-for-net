﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics.Models
{
    [CodeGenModel("TextAnalyticsWarning")]
    internal partial class TextAnalyticsWarningInternal
    {
        /// <summary> Warning code as string </summary>
        public string Code { get; }
    }
}
