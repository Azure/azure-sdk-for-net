// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> The request body. </summary>
    [CodeGenModel("ConversationAnalysisOptions")]
    public partial class AnalyzeConversationOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnalyzeConversationOptions"/> class.
        /// </summary>
        /// <param name="projectName">The name of the project to use.</param>
        /// <param name="deploymentName">The deployment name of the project to use, such as "test" or "production".</param>
        /// <param name="query">The conversation utterance to be analyzed.</param>
        /// <exception cref="ArgumentNullException"><paramref name="projectName"/>, <paramref name="deploymentName"/>, or <paramref name="query"/> is null.</exception>
        public AnalyzeConversationOptions(string projectName, string deploymentName, string query) : this(query)
        {
            ProjectName = Argument.CheckNotNull(projectName, nameof(projectName));
            DeploymentName = Argument.CheckNotNull(deploymentName, nameof(deploymentName));
        }

        internal AnalyzeConversationOptions(string query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            Query = query;
            Parameters = new ChangeTrackingDictionary<string, AnalysisParameters>();
        }

        /// <summary>
        /// Gets the name of the project to use.
        /// </summary>
        public string ProjectName { get; }

        /// <summary>
        /// Gets the deployment name of the project to use, such as "test" or "production".
        /// </summary>
        public string DeploymentName { get; }
    }
}
