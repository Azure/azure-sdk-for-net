using System;
using System.Threading.Tasks;
using Microsoft.Azure.Management.V2.Resource.Core.DAG;

namespace Microsoft.Azure.Management.V2.Resource.Core.ResourceActions
{
    public abstract class Creatable<IFluentResourceT, InnerResourceT, FluentResourceT> : 
        IndexableRefreshableWrapper<IFluentResourceT, InnerResourceT>,
        IRootResourceCreator
        where FluentResourceT : class
    {
        private CreatableTaskGroup creatableTaskGroup;

        protected Creatable(string name, InnerResourceT innerObject) : base(name, innerObject)
        {
            ICreatable<IResource> thisCreatable = this as ICreatable<IResource>;
            creatableTaskGroup = new CreatableTaskGroup(name, thisCreatable, this);
        }

        protected void AddCreatableDependency(ICreatable<IResource> creatableResource)
        {
            CreatableTaskGroup childTaskGroup = ((Creatable<object, object, object>)creatableResource).creatableTaskGroup;
            childTaskGroup.Merge(creatableTaskGroup);
        }

        public async Task CreateRootResourceAsync()
        {
            await CreateResourceAsync();
        }

        public async Task<FluentResourceT> CreateAsync()
        {
            if (creatableTaskGroup.IsPreparer)
            {
                creatableTaskGroup.Prepare();
                await creatableTaskGroup.Execute();
            }
            else
            {
                await CreateResourceAsync();
            }
            FluentResourceT thisResource = this as FluentResourceT;
            if (thisResource == null)
            {
                throw new InvalidOperationException("Interal Error: The type of this class required to be 'of type' '" + typeof(FluentResourceT) + "', but actually it is '" + this.GetType().Namespace + "'");
            }

            return thisResource;
        }


        protected IResource CreatedResource(string key)
        {
            return creatableTaskGroup.TaskResult(key);
        }

        protected abstract Task CreateResourceAsync();
    }
}
