// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.TextAnalytics.Models
{
    [CodeGenModel("CustomClassificationTaskParameters")]
    internal partial class CustomClassificationTaskParameters
    {
        /// <summary> AppId. </summary>
        internal string AppId { get; }

        /// <summary> SlotName. </summary>
        internal string SlotName { get; }
    }
}
