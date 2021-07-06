// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    [CodeGenModel("PIIDetectionSkill")]
    public partial class PiiDetectionSkill
    {
        /// <summary> A value indicating which language code to use. Default is en. </summary>
        public string DefaultLanguageCode { get; set; } = "en";

        /// <summary> A parameter that provides various ways to mask the personal information detected in the input text. Default is &apos;none&apos;. </summary>
        public PIIDetectionSkillMaskingMode? MaskingMode { get; set; } = PIIDetectionSkillMaskingMode.None;

        /// <summary> The character used to mask the text if the maskingMode parameter is set to replace. Default is &apos;*&apos;. </summary>
        public string MaskingCharacter { get; set; }
    }
}
