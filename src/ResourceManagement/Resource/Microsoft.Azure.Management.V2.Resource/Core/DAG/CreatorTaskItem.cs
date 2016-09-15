using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core.DAG
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
            if (createdResource != null)
            {
                await Task.Yield();
                return;
            }

            createdResource = await resourceCreator.CreateResourceAsync(cancellationToken);
        }
    }
}
