// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.Language.QuestionAnswering.Inference
{
    /// <summary> Represents a project for the Question Answering inference service. </summary>
    public class QuestionAnsweringProject
    {
        /// <summary> Initializes a new instance of the <see cref="QuestionAnsweringProject"/> class. </summary>
        /// <param name="projectName">The project name.</param>
        /// <param name="deploymentName">The deployment name.</param>
        public QuestionAnsweringProject(string projectName, string deploymentName)
        {
            ProjectName = Argument.CheckNotNull(projectName, nameof(projectName));
            DeploymentName = Argument.CheckNotNull(deploymentName, nameof(deploymentName));
        }

        /// <summary> Gets the project name. </summary>
        public string ProjectName { get; }

        /// <summary> Gets the deployment name. </summary>
        public string DeploymentName { get; }
    }
}
