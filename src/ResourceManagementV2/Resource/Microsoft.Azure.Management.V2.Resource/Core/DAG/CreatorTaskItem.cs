using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core.DAG
{
    internal class CreatorTaskItem : ITaskItem<IResource>
    {
        private IResourceCreator resourceCreator;
        private IResource createdResource;

        public CreatorTaskItem(IResourceCreator resourceCreator)
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

        public async Task ExecuteAsync()
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
