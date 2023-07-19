// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    [CodeGenModel("PIIDetectionSkill")]
    public partial class PiiDetectionSkill
    {
        private PiiDetectionSkillMaskingMode? _maskingMode = PiiDetectionSkillMaskingMode.None;

        /// <summary> A value indicating which language code to use. Default is en. </summary>
        public string DefaultLanguageCode { get; set; } = "en";

        /// <summary> A parameter that provides various ways to mask the personal information detected in the input text.
        /// Default is <see cref="PiiDetectionSkillMaskingMode.None"/>. </summary>
        public PiiDetectionSkillMaskingMode? MaskingMode
        {
            get => _maskingMode;
            set
            {
                _maskingMode = value;
                if ((_maskingMode == PiiDetectionSkillMaskingMode.Replace) && (MaskingCharacter == null))
                {
                    MaskingCharacter = "*";
                }
            }
        }
    }
}
