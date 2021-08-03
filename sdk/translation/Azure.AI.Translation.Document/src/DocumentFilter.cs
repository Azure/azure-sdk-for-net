// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.Translation.Document
{
    /// <summary>
    /// asd.
    /// </summary>
    [CodeGenModel("DocumentFilter")]
    internal partial class DocumentFilter
    {
        /// <summary>
        /// asd.
        /// </summary>
        [CodeGenMember("Prefix")]
        public string Prefix { get; set; }
        /// <summary>
        /// asd.
        /// </summary>
        [CodeGenMember("Suffix")]
        public string Suffix { get; set; }
    }
}
