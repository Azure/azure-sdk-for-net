// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics.Models
{
    /// <summary>
    /// EntitiesTaskParameters class.
    /// </summary>
    [CodeGenModel("EntitiesTaskParameters")]
    public partial class EntitiesTaskParameters
    {
        /// <summary>
        /// ModelVersion
        /// </summary>
        public string ModelVersion { get; set; }

        /// <summary>
        /// StringIndexType
        /// </summary>
        public StringIndexType? StringIndexType { get; set; }

    }
}
