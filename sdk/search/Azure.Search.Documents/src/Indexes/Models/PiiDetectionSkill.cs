// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class PiiDetectionSkill
    {
        /// <summary> A value indicating which language code to use. Default is en. </summary>
        public string DefaultLanguageCode { get; set; } = "en";
    }
}
