using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core.DAG
{
    public class CreatableTaskGroup : TaskGroupBase<IResource>
    {
        private IRootResourceCreator rootCreate;

        public CreatableTaskGroup(string rootCreatableId, IResourceCreator resourceCreator, IRootResourceCreator rootCreate) 
            : base(rootCreatableId, new CreatableTaskItem(resourceCreator))
        {
            this.rootCreate = rootCreate;
        }

        public IResource CreatedResource(string key)
        {
            return TaskResult(key);
        }

        public override async Task ExecuteRootTask(ITaskItem<IResource> taskItem)
        {
            await rootCreate.CreateRootResourceAsync();
        }
    }

    public interface IRootResourceCreator
    {
        Task CreateRootResourceAsync();
    }
}
