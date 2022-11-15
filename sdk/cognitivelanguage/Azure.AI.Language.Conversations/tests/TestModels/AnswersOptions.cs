// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> Parameters to query a knowledge base. </summary>
    public partial class AnswersOptions
    {
        /// <summary> Initializes a new instance of AnswersOptions. </summary>
        public AnswersOptions()
        {
        }

        /// <summary> Exact QnA ID to fetch from the knowledge base, this field takes priority over question. </summary>
        public int? QnaId { get; set; }
        /// <summary> User question to query against the knowledge base. </summary>
        public string Question { get; set; }
        /// <summary> Max number of answers to be returned for the question. </summary>
        public int? Top { get; set; }
        /// <summary> Unique identifier for the user. </summary>
        public string UserId { get; set; }
        /// <summary> Minimum threshold score for answers, value ranges from 0 to 1. </summary>
        public double? ConfidenceThreshold { get; set; }
        /// <summary> Context object with previous QnA&apos;s information. </summary>
        public KnowledgeBaseAnswerContext AnswerContext { get; set; }
        /// <summary> Type of ranker to be used. </summary>
        public RankerKind? RankerKind { get; set; }
        /// <summary> Filter QnAs based on given metadata list and knowledge base sources. </summary>
        public QueryFilters Filters { get; set; }
        /// <summary> To configure Answer span prediction feature. </summary>
        public ShortAnswerOptions ShortAnswerOptions { get; set; }
        /// <summary> (Optional) Flag to enable Query over Unstructured Sources. </summary>
        public bool? IncludeUnstructuredSources { get; set; }
    }
}
