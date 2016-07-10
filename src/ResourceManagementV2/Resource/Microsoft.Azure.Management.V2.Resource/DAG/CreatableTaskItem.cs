using Microsoft.Azure.Management.V2.Resource.Core;
using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.DAG
{
    public class CreatableTaskItem : ITaskItem<IResource>
    {
        private ICreatable<IResource> creatable;
        private IResource createdResource;

        public CreatableTaskItem(ICreatable<IResource> creatable)
        {
            this.creatable = creatable;
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

            createdResource = await creatable.Create();
        }
    }
}
