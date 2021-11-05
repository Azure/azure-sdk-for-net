// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class LanguageDetectionSkill
    {
        /// <summary> The version of the model to use when calling the Text Analytics service.
        /// It will default to the latest available when not specified. We recommend you do not specify this value unless absolutely necessary.
        /// </summary>
        internal string ModelVersion { get; set; }
    }
}
