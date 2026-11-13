// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.Language.QuestionAnswering.Inference
{
    public partial class ShortAnswerOptions
    {
        /// <summary>
        /// Number of top answers to be considered for span prediction from 1 to 10.
        /// </summary>
        [CodeGenMember("Top")]
        public int? Size { get; set; }
    }
}
