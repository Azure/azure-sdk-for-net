using System;
using System.Threading.Tasks;
using Microsoft.Azure.Management.V2.Resource.Core.DAG;

namespace Microsoft.Azure.Management.V2.Resource.Core.ResourceActions
{
    public interface IResourceCreator
    {
        Task<IResource> CreateResourceAsync();
        CreatableTaskGroup CreatableTaskGroup { get; }
    }


    public abstract class Creatable<IFluentResourceT, InnerResourceT, FluentResourceT> : 
        IndexableRefreshableWrapper<IFluentResourceT, InnerResourceT>,
        IRootResourceCreator,
        IResourceCreator
        where FluentResourceT : class
        where IFluentResourceT : IResource
    {
        public CreatableTaskGroup CreatableTaskGroup { get; private set; }

        protected Creatable(string name, InnerResourceT innerObject) : base(name, innerObject)
        {
            IResourceCreator creator =this as IResourceCreator;
            CreatableTaskGroup = new CreatableTaskGroup(name, creator, this);
        }

        protected void AddCreatableDependency(IResourceCreator creatableResource)
        {
            creatableResource.CreatableTaskGroup.Merge(CreatableTaskGroup);
        }

        public async Task CreateRootResourceAsync()
        {
            await CreateResourceAsync();
        }

        public async Task<FluentResourceT> CreateAsync()
        {
            if (CreatableTaskGroup.IsPreparer)
            {
                CreatableTaskGroup.Prepare();
                await CreatableTaskGroup.Execute();
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
            return CreatableTaskGroup.TaskResult(key);
        }

        public abstract Task<IResource> CreateResourceAsync();
    }
}
