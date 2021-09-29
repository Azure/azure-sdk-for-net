// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.Language.QuestionAnswering
{
    [CodeGenModel("KnowledgeBaseQueryOptions")]
    public partial class QueryKnowledgeBaseOptions
    {
        /// <summary>
        /// Creates a new instance of the <see cref="QueryKnowledgeBaseOptions"/> class with the specified <paramref name="question"/>.
        /// </summary>
        /// <param name="projectName">The name of the project to use.</param>
        /// <param name="deploymentName">The deployment name of the project to use, such as "test" or "prod".</param>
        /// <param name="question">The question to answer.</param>
        /// <exception cref="ArgumentException"><paramref name="question"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="projectName"/>, <paramref name="deploymentName"/>, or <paramref name="question"/> is null.</exception>
        public QueryKnowledgeBaseOptions(string projectName, string deploymentName, string question)
        {
            ProjectName = Argument.CheckNotNull(projectName, nameof(projectName));
            DeploymentName = Argument.CheckNotNull(deploymentName, nameof(deploymentName));
            Question = Argument.CheckNotNullOrEmpty(question, nameof(question));
        }

        /// <summary>
        /// Creates a new instance of the <see cref="QueryKnowledgeBaseOptions"/> class with an exact QnA ID.
        /// </summary>
        /// <param name="projectName">The name of the project to use.</param>
        /// <param name="deploymentName">The deployment name of the project to use, such as "test" or "prod".</param>
        /// <param name="qnaId">A specific question and answer ID to retrieve.</param>
        /// <exception cref="ArgumentNullException"><paramref name="projectName"/> or <paramref name="deploymentName"/> is null.</exception>
        public QueryKnowledgeBaseOptions(string projectName, string deploymentName, int qnaId)
        {
            ProjectName = Argument.CheckNotNull(projectName, nameof(projectName));
            DeploymentName = Argument.CheckNotNull(deploymentName, nameof(deploymentName));
            QnaId = qnaId;
        }

        private QueryKnowledgeBaseOptions()
        {
        }

        /// <summary>
        /// Gets the name of the project to use.
        /// </summary>
        public string ProjectName { get; }

        /// <summary>
        /// Gets the deployment name of the project to use, such as "test" or "prod".
        /// </summary>
        public string DeploymentName { get; }

        /// <summary>
        /// Exact QnA ID to fetch from the knowledgebase. This field takes priority over <see cref="Question"/>.
        /// </summary>
        public int? QnaId { get; }

        /// <summary>
        /// User question to query against the knowledge base.
        /// </summary>
        public string Question { get; }
    }
}
