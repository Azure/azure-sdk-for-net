﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.AI.TextAnalytics.Models;
using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    [CodeGenModel("KeyPhrasesTask")]
    public partial class KeyPhrasesTask
    {
        /// <summary>
        /// Parameters for KeyPhrasesTask
        /// </summary>
        public KeyPhrasesTaskParameters Parameters { get; set; }

    }
}
