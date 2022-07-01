// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Configurations that allow callers to specify details about how to execute
    /// a Recognize Custom Entities action in a set of documents.
    /// </summary>
    public class RecognizeCustomEntitiesAction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecognizeCustomEntitiesAction"/>
        /// class which allows callers to specify details about how to execute
        /// a Recognize Custom Entities action in a set of documents.
        /// Sets the <see cref="ProjectName"/> and <see cref="DeploymentName"/> properties.
        /// </summary>
        /// <param name="projectName">Sets the value of the property corresponding to the name of the project.</param>
        /// <param name="deploymentName">Sets the value of the property corresponding to the name of the deployment.</param>
        public RecognizeCustomEntitiesAction(string projectName, string deploymentName)
        {
            ProjectName = projectName;
            DeploymentName = deploymentName;
        }

        /// <summary>
        /// Gets the value of the property corresponding to the name of the proejct.
        /// </summary>
        public string ProjectName { get; }

        /// <summary>
        /// Gets the value of the property corresponding to the name of the deployment.
        /// </summary>
        public string DeploymentName { get; }

        /// <summary>
        /// The default value of this property is 'false'. This means, the Language service logs your input text for 48 hours,
        /// solely to allow for troubleshooting issues.
        /// Setting this property to true, disables input logging and may limit our ability to investigate issues that occur.
        /// <para>
        /// Please see Cognitive Services Compliance and Privacy notes at <see href="https://aka.ms/cs-compliance"/> for additional details,
        /// and Microsoft Responsible AI principles at <see href="https://www.microsoft.com/ai/responsible-ai"/>.
        /// </para>
        /// </summary>
        public bool? DisableServiceLogs { get; set; }

        /// <summary>
        /// Gets or sets a name for this action. If not provided, the service will generate one.
        /// </summary>
        public string ActionName { get; set; }
    }
}
