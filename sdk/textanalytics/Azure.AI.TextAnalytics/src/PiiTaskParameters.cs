// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.TextAnalytics.Models;
using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// PiiTaskParameters class.
    /// </summary>
    [CodeGenModel("PiiTaskParameters")]
    public partial class PiiTaskParameters
    {
        /// <summary>
        /// ModelVersion
        /// </summary>
        public string ModelVersion { get; set; } = "latest";

        /// <summary>
        /// StringIndexType
        /// </summary>
        internal StringIndexType? StringIndexType { get; set; }

        /// <summary>
        /// PiiTaskParametersDomain
        /// </summary>
        public PiiTaskParametersDomain? Domain { get; set; }
    }
}
