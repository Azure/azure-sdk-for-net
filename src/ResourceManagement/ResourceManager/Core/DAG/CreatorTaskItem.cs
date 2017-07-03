// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core.DAG
{
    internal class CreatorTaskItem<IResourceT> : ITaskItem<IResourceT>
    {
        private IResourceCreator<IResourceT> resourceCreator;

        public CreatorTaskItem(IResourceCreator<IResourceT> resourceCreator)
        {
            this.resourceCreator = resourceCreator;
        }

        public IResourceT CreatedResource { get; private set; }

        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            CreatedResource = await resourceCreator.CreateResourceAsync(cancellationToken);
        }
    }
}
