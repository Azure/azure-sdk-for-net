// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> Input parameters necessary for a Conversation task. </summary>
    public partial class ConversationTaskParameters
    {
        /// <summary> Initializes a new instance of ConversationTaskParameters. </summary>
        /// <param name="projectName"> The name of the project to use. </param>
        /// <param name="deploymentName"> The name of the deployment to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> or <paramref name="deploymentName"/> is null. </exception>
        public ConversationTaskParameters(string projectName, string deploymentName)
        {
            Argument.AssertNotNull(projectName, nameof(projectName));
            Argument.AssertNotNull(deploymentName, nameof(deploymentName));

            ProjectName = projectName;
            DeploymentName = deploymentName;
            TargetProjectParameters = new ChangeTrackingDictionary<string, AnalysisParameters>();
        }

        /// <summary> The name of the project to use. </summary>
        public string ProjectName { get; }
        /// <summary> The name of the deployment to use. </summary>
        public string DeploymentName { get; }
        /// <summary> If true, the service will return more detailed information in the response. </summary>
        public bool? Verbose { get; set; }
        /// <summary> If true, the service will keep the query for further review. </summary>
        public bool? IsLoggingEnabled { get; set; }
        /// <summary> Specifies the method used to interpret string offsets. Set this to &quot;Utf16CodeUnit&quot; for .NET strings, which are encoded as UTF-16. </summary>
        public StringIndexType? StringIndexType { get; set; }
        /// <summary> The name of a target project to forward the request to. </summary>
        public string DirectTarget { get; set; }
        /// <summary>
        /// A dictionary representing the parameters for each target project.
        /// Please note <see cref="AnalysisParameters"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="ConversationParameters"/>, <see cref="LuisParameters"/> and <see cref="QuestionAnsweringParameters"/>.
        /// </summary>
        public IDictionary<string, AnalysisParameters> TargetProjectParameters { get; }
    }
}
