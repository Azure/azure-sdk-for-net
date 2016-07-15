using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;

namespace Microsoft.Azure.Management.V2.Resource.Core.DAG
{
    public class CreatorTaskGroup : TaskGroupBase<IResource>
    {
        public CreatorTaskGroup(string rootCreatableId, IResourceCreator resourceCreator) 
            : base(rootCreatableId, new CreatorTaskItem(resourceCreator))
        {}

        public IResource CreatedResource(string key)
        {
            return TaskResult(key);
        }
    }
}
