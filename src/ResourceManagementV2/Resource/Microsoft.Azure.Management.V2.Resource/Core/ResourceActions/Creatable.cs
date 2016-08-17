using System;
using System.Threading.Tasks;
using Microsoft.Azure.Management.V2.Resource.Core.DAG;
using System.Threading;

namespace Microsoft.Azure.Management.V2.Resource.Core.ResourceActions
{
    /// <summary>
    /// The base class for all creatable resource.
    /// </summary>
    /// <typeparam name="IFluentResourceT">The fluent model type representing the creatable resource</typeparam>
    /// <typeparam name="InnerResourceT">The model inner type that the fluent model type wraps</typeparam>
    /// <typeparam name="FluentResourceT">The fluent model implementation type</typeparam>
    /// <typeparam name="IResourceT">The fluent resourced or one of the base interface from which inherits</typeparam>
    public abstract class Creatable<IFluentResourceT, InnerResourceT, FluentResourceT, IResourceT> :
        IndexableRefreshableWrapper<IFluentResourceT, InnerResourceT>,
        IResourceCreator<IResourceT>
        where FluentResourceT : class
        where IFluentResourceT : class, IResourceT
        where IResourceT : class
    {
        protected string Name { get; private set; }

        protected Creatable(string name, InnerResourceT innerObject) : base(name, innerObject)
        {
            Name = name;
            IResourceCreator<IResourceT> creator = this as IResourceCreator<IResourceT>;
            CreatorTaskGroup = new CreatorTaskGroup<IResourceT>(name, creator);
        }

        protected void AddCreatableDependency(IResourceCreator<IResourceT> creatableResource)
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


        protected IResourceT CreatedResource(string key)
        {
            return CreatorTaskGroup.TaskResult(key);
        }

        public CreatorTaskGroup<IResourceT> CreatorTaskGroup { get; private set; }

        public abstract Task<IFluentResourceT> CreateResourceAsync(CancellationToken cancellationToken);

        public virtual IFluentResourceT CreateResource()
        {
            return this.CreateResourceAsync(CancellationToken.None).Result;
        }

        Task<IResourceT> IResourceCreator<IResourceT>.CreateResourceAsync(CancellationToken cancellationToken)
        {
            TaskCompletionSource<IResourceT> taskCompletionSource = new TaskCompletionSource<IResourceT>();
            this.CreateResourceAsync(cancellationToken).ContinueWith(task =>
            {
                if (task.Exception != null)
                {
                    taskCompletionSource.SetException(task.Exception);
                }
                else
                {
                    taskCompletionSource.SetResult(task.Result);
                }
            });
            return taskCompletionSource.Task;
        }

        IResourceT IResourceCreator<IResourceT>.CreateResource()
        {
            return this.Create() as IResourceT;
        }
    }

    public interface IResourceCreator<IResourceT>
    {
        CreatorTaskGroup<IResourceT> CreatorTaskGroup { get; }
        Task<IResourceT> CreateResourceAsync(CancellationToken cancellationToken);
        IResourceT CreateResource();
    }
}
