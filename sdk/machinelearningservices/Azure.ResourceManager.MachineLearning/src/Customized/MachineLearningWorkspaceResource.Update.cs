// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager.MachineLearning.Models;

namespace Azure.ResourceManager.MachineLearning
{
    // Customized: restore GA update overloads that accepted MachineLearningWorkspacePatch. The
    // generated operation now takes WorkspacePatch, so these bridge the shipped request model.
    public partial class MachineLearningWorkspaceResource
    {
        /// <summary> Updates a machine learning workspace. </summary>
        public virtual Task<ArmOperation<MachineLearningWorkspaceResource>> UpdateAsync(WaitUntil waitUntil, MachineLearningWorkspacePatch patch, CancellationToken cancellationToken = default)
            => UpdateAsync(waitUntil, (WorkspacePatch)patch, cancellationToken);

        /// <summary> Updates a machine learning workspace. </summary>
        public virtual ArmOperation<MachineLearningWorkspaceResource> Update(WaitUntil waitUntil, MachineLearningWorkspacePatch patch, CancellationToken cancellationToken = default)
            => Update(waitUntil, (WorkspacePatch)patch, cancellationToken);
    }
}
