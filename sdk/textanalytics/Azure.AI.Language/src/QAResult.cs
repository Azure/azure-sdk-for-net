// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using Azure.AI.Language.Models;

namespace Azure.AI.Language
{
    /// <summary>
    /// QAResult
    /// </summary>
    public class QAResult
    {
        internal QAResult(string answer, List<string> questions, double score)
        {
            Answer = answer;
            Score = score;
            Questions = new ReadOnlyCollection<string>(questions);
        }

        internal QAResult(QAResult qa)
        {
            Questions = qa.Questions;
            Answer = qa.Answer;
            Score = qa.Score;
        }

        /// <summary>
        /// Answer
        /// </summary>
        public string Answer { get; }

        /// <summary>
        /// Questions
        /// </summary>
        public IReadOnlyCollection<string> Questions { get; }

        /// <summary>
        /// Score
        /// </summary>
        public double Score { get; }
    }
}
