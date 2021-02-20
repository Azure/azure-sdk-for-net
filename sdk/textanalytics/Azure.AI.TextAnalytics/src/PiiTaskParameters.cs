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
    internal partial class PiiTaskParameters
    {
        /// <summary>
        /// ModelVersion
        /// </summary>
        public string ModelVersion { get; set; } = "latest";

        /// <summary>
        /// StringIndexType
        /// </summary>
        public StringIndexType StringIndexType { get; set; } = StringIndexType.Utf16CodeUnit;

        /// <summary>
        /// PiiTaskParametersDomain
        /// </summary>
        public PiiTaskParametersDomain? Domain { get; set; }
    }
}
