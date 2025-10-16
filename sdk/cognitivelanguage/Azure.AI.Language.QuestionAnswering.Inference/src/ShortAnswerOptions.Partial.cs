// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Language.QuestionAnswering.Inference
{
    public partial class ShortAnswerOptions
    {
        /// <summary>
        /// Number of top answers to be considered for span prediction.
        /// </summary>
        public int? Size
        {
            get => Top;
            set => Top = value;
        }
    }
}
