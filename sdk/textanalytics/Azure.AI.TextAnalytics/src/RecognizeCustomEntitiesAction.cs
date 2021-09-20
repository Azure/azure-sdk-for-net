// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Configurations that allow callers to specify details about how to execute
    /// a Recognize Custom Entities action in a set of documents.
    /// For example, set project name and disable deployment name.
    /// </summary>
    public class RecognizeCustomEntitiesAction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecognizeCustomEntitiesAction"/>
        /// class which allows callers to specify details about how to execute
        /// a Recognize Custom Entities action in a set of documents.
        /// For example, set project name and disable deployment name.
        /// </summary>
        public RecognizeCustomEntitiesAction()
        {
        }

        /// <summary> Gets the project name. </summary>
        public string ProjectName { get; }
        /// <summary> Gets the deployment name. </summary>
        public string DeploymentName { get; }
        /// <summary> Gets the deployment name. </summary>
        public bool? DisableServiceLogs { get; set; }
    }
}
