// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.AI.Language.Conversations.Authoring
{
    public partial class ConversationAuthoringCreateDeploymentDetails
    {
        // For GA 2025-11-01 shape (array of strings)
        internal IList<string> AzureResourceIdsStrings { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="ConversationAuthoringCreateDeploymentDetails"/>.
        /// This overload is for the 2025-11-01 GA shape, where the service expects
        /// azureResourceIds as an array of strings.
        /// </summary>
        /// <param name="trainedModelLabel">Represents the trained model label.</param>
        /// <param name="azureResourceIds">Resource ID strings.</param>
        public ConversationAuthoringCreateDeploymentDetails(
            string trainedModelLabel,
            IList<string> azureResourceIds)
            : this(trainedModelLabel)
        {
            Argument.AssertNotNull(azureResourceIds, nameof(azureResourceIds));

            AzureResourceIdsStrings = new ChangeTrackingList<string>(azureResourceIds);
        }
    }
}
