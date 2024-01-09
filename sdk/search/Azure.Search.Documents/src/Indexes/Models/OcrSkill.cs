﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class OcrSkill
    {
        /// <summary> A value indicating which language code to use. Default is <see cref="OcrSkillLanguage.En"/>. </summary>
        public OcrSkillLanguage? DefaultLanguageCode { get; set; } = OcrSkillLanguage.En;

        /// <summary> A value indicating to turn orientation detection on or not. Default is <c>false</c>. </summary>
        public bool? ShouldDetectOrientation { get; set; } = false;

        /// <summary> Defines the sequence of characters to use between the lines of text recognized by the OCR skill. The default value is <see cref="Models.LineEnding.Space"/>. </summary>
        public LineEnding? LineEnding { get; set; } = Models.LineEnding.Space;
    }
}
