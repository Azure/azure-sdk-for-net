using Microsoft.Azure.Management.V2.Resource.Core;
using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.DAG
{
    public class CreatableTaskGroup : TaskGroupBase<IResource>
    {
        private RootResourceCreator rootCreate;

        public CreatableTaskGroup(string key, CreatableTaskItem rootTask, RootResourceCreator rootCreate) : base(key, rootTask)
        {
            this.rootCreate = rootCreate;
        }

        public CreatableTaskGroup(string rootCreatableId, ICreatable<IResource> rootCreatable, RootResourceCreator rootCreate) 
            : this(rootCreatableId, new CreatableTaskItem(rootCreatable), rootCreate)
        {}

        public IResource CreatedResource(string key)
        {
            return TaskResult(key);
        }

        public override async Task ExecuteRootTask(ITaskItem<IResource> taskItem)
        {
            await rootCreate.createRootResource();
        }
    }

    public interface RootResourceCreator
    {
        Task createRootResource();
    }
}
