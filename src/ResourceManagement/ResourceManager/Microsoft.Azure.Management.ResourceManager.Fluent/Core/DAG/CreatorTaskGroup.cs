// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core.DAG
{
    public class CreatorTaskGroup<IResourceT> : TaskGroupBase<IResourceT>
    {
        public CreatorTaskGroup(string rootCreatableId, IResourceCreator<IResourceT> resourceCreator) 
            : base(rootCreatableId, new CreatorTaskItem<IResourceT>(resourceCreator))
        {}

        public IResourceT CreatedResource(string key)
        {
            return TaskResult(key);
        }
    }
}
