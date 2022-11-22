// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> This is a set of request parameters for Question Answering knowledge bases. </summary>
    public partial class QuestionAnsweringParameters : AnalysisParameters
    {
        /// <summary> Initializes a new instance of QuestionAnsweringParameters. </summary>
        public QuestionAnsweringParameters()
        {
            TargetProjectKind = TargetProjectKind.QuestionAnswering;
        }

        /// <summary> The options sent to a Question Answering KB. </summary>
        public AnswersOptions CallingOptions { get; set; }
    }
}
