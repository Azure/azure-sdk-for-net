// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> The AnalyzeConversationJobsInput. </summary>
    public partial class AnalyzeConversationJobsInput
    {
        /// <summary> Initializes a new instance of AnalyzeConversationJobsInput. </summary>
        /// <param name="analysisInput"></param>
        /// <param name="tasks">
        /// The set of tasks to execute on the input conversation.
        /// Please note <see cref="AnalyzeConversationLROTask"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="AnalyzeConversationPIITask"/>, <see cref="AnalyzeConversationalSentimentTask"/> and <see cref="AnalyzeConversationSummarizationTask"/>.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="analysisInput"/> or <paramref name="tasks"/> is null. </exception>
        public AnalyzeConversationJobsInput(MultiLanguageConversationAnalysisInput analysisInput, IEnumerable<AnalyzeConversationLROTask> tasks)
        {
            Argument.AssertNotNull(analysisInput, nameof(analysisInput));
            Argument.AssertNotNull(tasks, nameof(tasks));

            AnalysisInput = analysisInput;
            Tasks = tasks.ToList();
        }

        /// <summary> Optional display name for the analysis job. </summary>
        public string DisplayName { get; set; }
        /// <summary> Gets the analysis input. </summary>
        public MultiLanguageConversationAnalysisInput AnalysisInput { get; }
        /// <summary>
        /// The set of tasks to execute on the input conversation.
        /// Please note <see cref="AnalyzeConversationLROTask"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="AnalyzeConversationPIITask"/>, <see cref="AnalyzeConversationalSentimentTask"/> and <see cref="AnalyzeConversationSummarizationTask"/>.
        /// </summary>
        public IList<AnalyzeConversationLROTask> Tasks { get; }
    }
}
