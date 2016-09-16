using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core.DAG
{
    internal class CreatorTaskItem<IResourceT> : ITaskItem<IResourceT>
    {
        private IResourceCreatorUpdator<IResourceT> resourceCreatorUpdator;
        private IResourceT createdResource;

        public CreatorTaskItem(IResourceCreatorUpdator<IResourceT> resourceCreator)
        {
            this.resourceCreatorUpdator = resourceCreator;
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

            if (resourceCreatorUpdator.IsInCreateMode)
            {
                createdResource = await resourceCreatorUpdator.CreateResourceAsync(cancellationToken);
            } else
            {
                createdResource = await resourceCreatorUpdator.UpdateResourceAsync(cancellationToken);
            }
        }
    }
}
