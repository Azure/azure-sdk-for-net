using System;
using System.Threading.Tasks;
using Microsoft.Azure.Management.V2.Resource.Core.DAG;
using System.Threading;

namespace Microsoft.Azure.Management.V2.Resource.Core.ResourceActions
{
    public abstract class Creatable<IFluentResourceT, InnerResourceT, FluentResourceT> :
        IndexableRefreshableWrapper<IFluentResourceT, InnerResourceT>,
        IResourceCreator
        where FluentResourceT : class
        where IFluentResourceT : class, IResource
    {
        protected Creatable(string name, InnerResourceT innerObject) : base(name, innerObject)
        {
            IResourceCreator creator =this as IResourceCreator;
            CreatorTaskGroup = new CreatorTaskGroup(name, creator);
        }

        protected void AddCreatableDependency(IResourceCreator creatableResource)
        {
            creatableResource.CreatorTaskGroup.Merge(CreatorTaskGroup);
        }

        public IFluentResourceT Create()
        {
            return CreateAsync(CancellationToken.None).Result;
        }

        public Task<IFluentResourceT> CreateAsync(CancellationToken cancellationToken, bool multiThreaded = true)
        {
            TaskCompletionSource<IFluentResourceT> taskCompletionSource = new TaskCompletionSource<IFluentResourceT>();
            if (CreatorTaskGroup.IsPreparer)
            {
                CreatorTaskGroup.Prepare();
                CreatorTaskGroup.ExecuteAsync(cancellationToken, multiThreaded).ContinueWith(task =>
                {
                    if (task.Exception != null)
                    {
                        taskCompletionSource.SetException(task.Exception.InnerExceptions);
                    }
                    else
                    {
                        IFluentResourceT thisResource = this as IFluentResourceT;
                        if (thisResource == null)
                        {
                            taskCompletionSource.SetException(new InvalidOperationException("Interal Error: Expected 'of type' '" + typeof(IFluentResourceT) + "', but got '" + this.GetType().Namespace + "'"));
                        }
                        else
                        {
                            taskCompletionSource.SetResult(thisResource);
                        }
                    }
                });
            }
            else
            {
                taskCompletionSource.SetException(new InvalidOperationException("Interal Error: Creatable::CreateAsync can be invoked only on preparer"));
            }
            return taskCompletionSource.Task;
        }


        protected IResource CreatedResource(string key)
        {
            return CreatorTaskGroup.TaskResult(key);
        }

        #region Implementation of IResourceCreator

        public CreatorTaskGroup CreatorTaskGroup { get; private set; }

        public abstract Task<IResource> CreateResourceAsync(CancellationToken cancellationToken);

        public abstract IResource CreateResource();

        #endregion
    }

    public interface IResourceCreator
    {
        Task<IResource> CreateResourceAsync(CancellationToken cancellationToken);
        IResource CreateResource();
        CreatorTaskGroup CreatorTaskGroup { get; }
    }
}
