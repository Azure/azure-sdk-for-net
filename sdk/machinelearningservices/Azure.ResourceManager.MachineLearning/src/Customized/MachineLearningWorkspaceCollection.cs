// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure;
using Azure.ResourceManager.MachineLearning.Models;

namespace Azure.ResourceManager.MachineLearning
{
    // Customized: preserve previous collection GetAll overload shapes.
    public partial class MachineLearningWorkspaceCollection
    {
        // Customized: preserve the previous list overload shape.
        public virtual AsyncPageable<MachineLearningWorkspaceResource> GetAllAsync(string kind, CancellationToken cancellationToken)
            => GetAllAsync(kind, default, default, cancellationToken);

        // Customized: preserve the previous list overload shape.
        public virtual Pageable<MachineLearningWorkspaceResource> GetAll(string kind, CancellationToken cancellationToken)
            => GetAll(kind, default, default, cancellationToken);
    }
}
