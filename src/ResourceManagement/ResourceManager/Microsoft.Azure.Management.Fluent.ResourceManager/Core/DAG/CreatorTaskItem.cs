// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent.Resource.Core.ResourceActions;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Fluent.Resource.Core.DAG
{
    internal class CreatorTaskItem<IResourceT> : ITaskItem<IResourceT>
    {
        private IResourceCreator<IResourceT> resourceCreator;
        private IResourceT createdResource;

        public CreatorTaskItem(IResourceCreator<IResourceT> resourceCreator)
        {
            this.resourceCreator = resourceCreator;
        }

        public IResourceT Result
        {
            get
            {
                return createdResource;
            }
        }

        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            createdResource = await resourceCreator.CreateResourceAsync(cancellationToken);
        }
    }
}
