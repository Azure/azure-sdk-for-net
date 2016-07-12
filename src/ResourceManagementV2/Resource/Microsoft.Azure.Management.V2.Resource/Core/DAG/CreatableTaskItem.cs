using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core.DAG
{
    internal class CreatableTaskItem : ITaskItem<IResource>
    {
        private IResourceCreator resourceCreator;
        private IResource createdResource;

        public CreatableTaskItem(IResourceCreator resourceCreator)
        {
            this.resourceCreator = resourceCreator;
        }

        public IResource Result
        {
            get
            {
                return createdResource;
            }
        }

        public async Task Execute()
        {
            if (createdResource != null)
            {
                await Task.Yield();
                return;
            }

            createdResource = await resourceCreator.CreateResourceAsync();
        }
    }
}
