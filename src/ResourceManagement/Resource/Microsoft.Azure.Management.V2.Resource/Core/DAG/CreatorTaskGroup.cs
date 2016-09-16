using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;

namespace Microsoft.Azure.Management.V2.Resource.Core.DAG
{
    public class CreateUpdateTaskGroup<IResourceT> : TaskGroupBase<IResourceT>
    {
        public CreateUpdateTaskGroup(string rootCreatableId, IResourceCreatorUpdator<IResourceT> resourceCreator) 
            : base(rootCreatableId, new CreatorTaskItem<IResourceT>(resourceCreator))
        {}

        public IResourceT CreatedResource(string key)
        {
            return TaskResult(key);
        }
    }
}
