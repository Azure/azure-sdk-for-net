// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure;
using Azure.ResourceManager.MachineLearning.Models;

namespace Azure.ResourceManager.MachineLearning
{
    // Customized: preserve previous collection GetAll overload shapes.
    public partial class MachineLearningWorkspaceConnectionCollection
    {
        // Customized: preserve the previous list overload shape.
        public virtual AsyncPageable<MachineLearningWorkspaceConnectionResource> GetAllAsync(string target, string category, CancellationToken cancellationToken)
            => GetAllAsync(target, category, default, cancellationToken);

        // Customized: preserve the previous list overload shape.
        public virtual Pageable<MachineLearningWorkspaceConnectionResource> GetAll(string target, string category, CancellationToken cancellationToken)
            => GetAll(target, category, default, cancellationToken);
    }
}
