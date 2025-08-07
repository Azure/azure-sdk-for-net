// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    [CodeGenModel("PIIDetectionSkill")]
    public partial class PiiDetectionSkill
    {
        /// <summary> A value indicating which language code to use. Default is en. </summary>
        public string DefaultLanguageCode { get; set; } = "en";
    }
}
