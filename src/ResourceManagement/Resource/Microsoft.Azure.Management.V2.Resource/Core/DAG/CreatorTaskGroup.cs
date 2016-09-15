using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;

namespace Microsoft.Azure.Management.V2.Resource.Core.DAG
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
