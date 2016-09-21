using Microsoft.Azure.Management.V2.Resource.Core;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core
{
    public abstract class ExternalChildResources<FluentModelTImpl, FluentModelT, InnerModelT, ParentImplT>
        where FluentModelT : IExternalChildResource<FluentModelT>
        where FluentModelTImpl : ExternalChildResource<FluentModelT, InnerModelT, ParentImplT>
    {
        /// <summary>
        /// Used to construct error string, this is user friendly name of the child resource (e.g. Subnet, Extension).
        /// </summary>
        private string childResourceName;

        /// <summary>
        /// The child resource instances that this collection contains.
        /// </summary>
        private ConcurrentDictionary<string, FluentModelTImpl> collection = new ConcurrentDictionary<string, FluentModelTImpl>();

        /// <summary>
        /// Creates a new ExternalChildResourcesImpl.
        /// </summary>
        /// <param name="parent">the parent Azure resource</param>
        /// <param name="childResourceName">the child resource name</param>
        protected ExternalChildResources(ParentImplT parent, string childResourceName)
        {
            this.Parent = parent;
            this.childResourceName = childResourceName;
        }

        /// <returns>The parent resource of this collection of child resources.</returns>
        protected ParentImplT Parent
        {
            get; private set;
        }

        /// <returns>the child resource collection as a read-only dictionary.</returns>
        protected IDictionary<string, FluentModelTImpl> Collection
        {
            get
            {
                return new ReadOnlyDictionary<string, FluentModelTImpl>(this.collection);
            }
        }

        /// <summary>
        /// Refresh the collection.
        /// </summary>
        public void Refresh()
        {
            InitializeCollection();
        }

        /**
        public Task<Observable<FluentModelTImpl>> CommitAsync(CancellationToken cacellationToken)
        {
            // This method cannot be implemented as there is no easy way to stream reources due to the 
            // absense of Rx.Net
        }
        **/

        /// <summary>
        /// Commits the changes in the external child resource collection.
        /// </summary>
        /// <param name="cacellationToken"></param>
        /// <returns>On success a task with changed child resources else a faulted task</returns>
        public Task<List<FluentModelTImpl>> CommitAndGetAllAsync(CancellationToken cacellationToken)
        {
            ConcurrentBag<Exception> exceptions = new ConcurrentBag<Exception>();
            ConcurrentBag<FluentModelTImpl> comitted = new ConcurrentBag<FluentModelTImpl>();
            List<FluentModelTImpl> resources = new List<FluentModelTImpl>();
            foreach(var resource in this.collection.Values)
            {
                resources.Add(resource);
            }

            List<Task> allTasks = new List<Task>();
            foreach(FluentModelTImpl resource in resources.Where(r => r.State == State.ToBeRemoved))
            {
                FluentModelTImpl res = resource;
                Task task = res.DeleteAsync(cacellationToken).ContinueWith(deleteTask =>
                {
                    if (deleteTask.IsFaulted)
                    {
                        exceptions.Add(deleteTask.Exception);
                    }
                    else
                    {
                        comitted.Add(res);
                        res.State = State.None;
                        FluentModelTImpl val;
                        this.collection.TryRemove(res.Name, out val);
                    }
                });
                allTasks.Add(task);
            }

            foreach (FluentModelTImpl resource in resources.Where(r => r.State == State.ToBeCreated))
            {
                FluentModelTImpl res = resource;
                Task task = res.CreateAsync(cacellationToken).ContinueWith(createTask =>
                {
                    if (createTask.IsFaulted)
                    {
                        FluentModelTImpl val;
                        this.collection.TryRemove(res.Name, out val);
                        exceptions.Add(createTask.Exception);
                    }
                    else
                    {
                        comitted.Add(res);
                        res.State = State.None;
                    }
                });
                allTasks.Add(task);
            }

            foreach (FluentModelTImpl resource in resources.Where(r => r.State == State.ToBeUpdated))
            {
                FluentModelTImpl res = resource;
                Task task = res.CreateAsync(cacellationToken).ContinueWith(updateTask =>
                {
                    if (updateTask.IsFaulted)
                    {
                        exceptions.Add(updateTask.Exception);
                    }
                    else
                    {
                        comitted.Add(res);
                        res.State = State.None;
                    }
                });
                allTasks.Add(task);
            }

            TaskCompletionSource<List<FluentModelTImpl>> completionSource = new TaskCompletionSource<List<FluentModelTImpl>>();
            Task.WhenAll(allTasks.ToArray())
                .ContinueWith(task =>
                {
                    if (exceptions.Count > 0)
                    {
                        completionSource.SetException(exceptions);
                    }
                    else
                    {
                        completionSource.SetResult(comitted.ToList());
                    }
                });
            return completionSource.Task;
        }

        /// <summary>
        /// Prepare for definition of a new external child resource.
        /// </summary>
        /// <param name="name">the name for the new external child resource</param>
        /// <returns>the child resource</returns>
        protected FluentModelTImpl PrepareDefine(string name)
        {
            if (Find(name) != null)
            {
                throw new ArgumentException("A child resource ('" + childResourceName + "') with name  '" + name + "' already exists");
            }
            FluentModelTImpl childResource = NewChildResource(name);
            childResource.State = State.ToBeCreated;
            return childResource;
        }

        /// <summary>
        /// Prepare for an external child resource update.
        /// </summary>
        /// <param name="name">the name of the external child resource</param>
        /// <returns>the external child resource to be updated</returns>
        protected FluentModelTImpl PrepareUpdate(String name)
        {
            FluentModelTImpl childResource = Find(name);
            if (childResource == null
                    || childResource.State == State.ToBeCreated)
            {
                throw new ArgumentException("A child resource ('" + childResourceName + "') with name  '" + name + "' not found");
            }
            if (childResource.State == State.ToBeRemoved)
            {
                throw new ArgumentException("A child resource ('" + childResourceName + "') with name  '" + name + "' is marked for deletion");
            }
            childResource.State = State.ToBeUpdated;
            return childResource;
        }

        /// <summary>
        /// Mark an external child resource with given name as to be removed.
        /// </summary>
        /// <param name="name">the name of the external child resource</param>
        protected void PrepareRemove(String name)
        {
            FluentModelTImpl childResource = Find(name);
            if (childResource == null
                    || childResource.State == State.ToBeCreated)
            {
                throw new ArgumentException("A child resource ('" + childResourceName + "') with name  '" + name + "' not found");
            }
            childResource.State = State.ToBeRemoved;
        }

        /// <summary>
        /// Adds an external child resource to the collection.
        /// </summary>
        /// <param name="childResource">childResource the external child resource</param>
        protected void AddChildResource(FluentModelTImpl childResource)
        {
            this.collection.AddOrUpdate(childResource.Name,
                key => childResource,
                (string key, FluentModelTImpl oldVal) => { return childResource; });
        }


        /// <summary>
        /// Initializes the external child resource collection.
        /// </summary>
        protected void InitializeCollection()
        {
            this.collection.Clear();
            foreach (FluentModelTImpl childResource in this.ListChildResources())
            {
                this.collection.AddOrUpdate(childResource.Name, 
                    key => childResource, 
                    (string key, FluentModelTImpl oldVal) => { return childResource;});
            }
        }

        /// <summary>
        /// Gets the list of external child resources.
        /// </summary>
        /// <returns>the list of external child resources</returns>
        protected abstract IList<FluentModelTImpl> ListChildResources();

        /// <summary>
        /// Gets a new external child resource model instance.
        /// </summary>
        /// <param name="name">the name for the new child resource</param>
        /// <returns>the new child resource</returns>
        protected abstract FluentModelTImpl NewChildResource(string name);

        /**
         * Finds a child resource with the given name.
         *
         * @param name the child resource name
         * @return null if no child resource exists with the given name else the child resource
         */
        private FluentModelTImpl Find(string name)
        {
            var result =  this.collection.Where(ele => ele.Key.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (result.Any())
            {
                return result.First().Value;
            }
            return null;
        }
    }
}
