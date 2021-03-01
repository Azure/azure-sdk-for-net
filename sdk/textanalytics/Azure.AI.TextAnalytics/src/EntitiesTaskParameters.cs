// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.TextAnalytics.Models;
using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// EntitiesTaskParameters class.
    /// </summary>
    [CodeGenModel("EntitiesTaskParameters")]
    internal partial class EntitiesTaskParameters
    {
        /// <summary>
        /// ModelVersion
        /// </summary>
        public string ModelVersion { get; set; } = "latest";

        /// <summary>
        /// StringIndexType
        /// </summary>
        public StringIndexType StringIndexType { get; set; } = StringIndexType.Utf16CodeUnit;
    }
}
