using Microsoft.Azure.Management.V2.Resource.Core.DAG;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core.ResourceActions
{
    public abstract class CreatableUpdatable<IFluentResourceT, InnerResourceT, FluentResourceT, IResourceT, IUpdatableT> 
        : Creatable<IFluentResourceT, InnerResourceT, FluentResourceT, IResourceT>, 
        ICreatable<IFluentResourceT>, 
        IUpdatable<IUpdatableT>,
        IResourceCreatorUpdator<IResourceT>

        where IFluentResourceT: class, IResourceT
        where FluentResourceT: class
        where IResourceT: class
        where IUpdatableT: class
    {
        protected CreatableUpdatable(string name, InnerResourceT innerObject) : base(name, innerObject)
        {
            IResourceCreatorUpdator<IResourceT> creator = this as IResourceCreatorUpdator<IResourceT>;
            CreatorTaskGroup = new CreateUpdateTaskGroup<IResourceT>(name, creator);
        }

        public CreateUpdateTaskGroup<IResourceT> CreatorTaskGroup { get; private set; }

        public abstract bool IsInCreateMode { get; }

        #region Implementation of IUpdatable interface

        public virtual IUpdatableT Update()
        {
            return this as IUpdatableT;
        }

        #endregion

        public abstract Task<IFluentResourceT> CreateResourceAsync(CancellationToken cancellationToken);

        Task<IResourceT> IResourceCreatorUpdator<IResourceT>.CreateResourceAsync(CancellationToken cancellationToken)
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

        public abstract Task<IFluentResourceT> UpdateResourceAsync(CancellationToken cancellationToken);

        Task<IResourceT> IResourceCreatorUpdator<IResourceT>.UpdateResourceAsync(CancellationToken cancellationToken)
        {
            TaskCompletionSource<IResourceT> taskCompletionSource = new TaskCompletionSource<IResourceT>();
            this.UpdateResourceAsync(cancellationToken).ContinueWith(task =>
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

        protected IResourceT CreatedResource(string key)
        {
            return CreatorTaskGroup.TaskResult(key);
        }

        protected void AddCreatableDependency(IResourceCreatorUpdator<IResourceT> creatableResource)
        {
            creatableResource.CreatorTaskGroup.Merge(CreatorTaskGroup);
        }

        public override Task<IFluentResourceT> CreateAsync(CancellationToken cancellationToken, bool multiThreaded = true)
        {
            return ExecuteTaskGroupAsync(cancellationToken, multiThreaded);
        }

        public IFluentResourceT Apply()
        {
            return ApplyAsync(CancellationToken.None, true).Result;
        }

        public virtual async Task<IFluentResourceT> ApplyAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true)
        {
            return await ExecuteTaskGroupAsync(cancellationToken, multiThreaded) as IFluentResourceT;
        }

        public Task<IFluentResourceT> ExecuteTaskGroupAsync(CancellationToken cancellationToken, bool multiThreaded = true)
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
                taskCompletionSource.SetException(new InvalidOperationException("Interal Error: CreatableUpdatable::ExecuteTaskGroupAsync can be invoked only on preparer"));
            }
            return taskCompletionSource.Task;
        }
    }

    public interface IResourceCreatorUpdator<ICUResourceT>
    {
        bool IsInCreateMode { get; }

        CreateUpdateTaskGroup<ICUResourceT> CreatorTaskGroup { get; }

        Task<ICUResourceT> CreateResourceAsync(CancellationToken cancellationToken);

        Task<ICUResourceT> UpdateResourceAsync(CancellationToken cancellationToken);
    }
}
