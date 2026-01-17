// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.Language.Conversations.Authoring
{
    // [CodeGenSuppress("GetConversationAuthoringProjectClient", typeof(string))]
    // [CodeGenSuppress("GetConversationAuthoringDeploymentClient", typeof(string), typeof(string))]
    // [CodeGenSuppress("GetConversationAuthoringExportedModelClient", typeof(string), typeof(string))]
    // [CodeGenSuppress("GetConversationAuthoringTrainedModelClient", typeof(string), typeof(string))]
    [CodeGenType("AuthoringClient")]
    public partial class ConversationAnalysisAuthoringClient
    {
        /// <summary> Initializes a new instance of ConversationAuthoringProject. </summary>
        /// <param name="projectName"> The project name to use for this subclient. </param>
        public virtual ConversationAuthoringProject GetProject(string projectName)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));

            return new ConversationAuthoringProject(ClientDiagnostics, Pipeline, _endpoint, _apiVersion, projectName);
        }

        /// <summary> Initializes a new instance of ConversationAuthoringDeployment. </summary>
        /// <param name="projectName"> The project name to use for this subclient. </param>
        /// <param name="deploymentName"> Represents deployment name. </param>
        public virtual ConversationAuthoringDeployment GetDeployment(string projectName, string deploymentName)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));

            return new ConversationAuthoringDeployment(ClientDiagnostics, Pipeline, _endpoint, _apiVersion, projectName, deploymentName);
        }

        /// <summary> Initializes a new instance of ConversationAuthoringModels. </summary>
        /// <param name="projectName"> The project name to use for this subclient. </param>
        /// <param name="exportedModelName"> The exported model name to use for this subclient. </param>
        public virtual ConversationAuthoringExportedModel GetExportedModel(string projectName, string exportedModelName)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(exportedModelName, nameof(exportedModelName));

            return new ConversationAuthoringExportedModel(ClientDiagnostics, Pipeline, _endpoint, _apiVersion, projectName, exportedModelName);
        }

        /// <summary> Initializes a new instance of ConversationAuthoringModels. </summary>
        /// <param name="projectName"> The project name to use for this subclient. </param>
        /// <param name="trainedModelLabel"> The trained model label to use for this subclient. </param>
        public virtual ConversationAuthoringTrainedModel GetTrainedModel(string projectName, string trainedModelLabel)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(trainedModelLabel, nameof(trainedModelLabel));

            return new ConversationAuthoringTrainedModel(ClientDiagnostics, Pipeline, _apiVersion, _endpoint, projectName, trainedModelLabel);
        }
    }
}
