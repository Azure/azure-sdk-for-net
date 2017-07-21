// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core
{
    public abstract class ExternalChildResourceCollection<FluentModelTImpl, IFluentModelT, InnerModelT, IParentT, ParentImplT>
        where ParentImplT : IParentT
        where IFluentModelT : class, IExternalChildResource<IFluentModelT, IParentT>
        where FluentModelTImpl : ExternalChildResource<IFluentModelT, InnerModelT, IParentT, ParentImplT>, IFluentModelT
    {
        /// <summary>
        /// Used to construct error string, this is user friendly name of the child resource (e.g. Subnet, Extension).
        /// </summary>
        protected string childResourceName;

        /// <summary>
        /// The child resource instances that this collection contains.
        /// </summary>
        protected ConcurrentDictionary<string, FluentModelTImpl> collection = new ConcurrentDictionary<string, FluentModelTImpl>();

        /// <summary>
        /// Creates a new ExternalChildResourceCollection.
        /// </summary>
        /// <param name="parent">the parent Azure resource</param>
        /// <param name="childResourceName">the child resource name</param>
        protected ExternalChildResourceCollection(ParentImplT parent, string childResourceName)
        {
            this.Parent = parent;
            this.childResourceName = childResourceName;
        }

        /**
        public Task<Observable<FluentModelTImpl>> CommitAsync(CancellationToken cacellationToken)
        {
            // This method cannot be implemented as there is no easy way to stream reources due to the 
            // absence of Rx.Net
        }
        **/

        /// <summary>
        /// Commits the changes in the external child resource collection.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>On success a task with changed child resources else a faulted task</returns>
        public Task<List<FluentModelTImpl>> CommitAndGetAllAsync(CancellationToken cancellationToken)
        {
            ConcurrentBag<Exception> exceptions = new ConcurrentBag<Exception>();
            ConcurrentBag<FluentModelTImpl> comitted = new ConcurrentBag<FluentModelTImpl>();
            List<FluentModelTImpl> resources = new List<FluentModelTImpl>();
            foreach (var resource in this.collection.Values)
            {
                resources.Add(resource);
            }

            ConcurrentBag<Task> allTasks = new ConcurrentBag<Task>();
            foreach (FluentModelTImpl resource in resources.Where(r => r.PendingOperation == PendingOperation.ToBeRemoved))
            {
                FluentModelTImpl res = resource;
                Task task = res.DeleteAsync(cancellationToken)
                .ContinueWith(deleteTask =>
                    {
                        if (deleteTask.IsFaulted)
                        {
                            if (deleteTask.Exception.InnerException != null)
                            {
                                exceptions.Add(deleteTask.Exception.InnerException);
                            } 
                            else
                            {
                                exceptions.Add(deleteTask.Exception);
                            }
                        }
                        else
                        {
                            comitted.Add(res);
                            res.PendingOperation = PendingOperation.None;
                            FluentModelTImpl val;
                            this.collection.TryRemove(res.Name(), out val);
                        }
                    },
                    cancellationToken,
                    TaskContinuationOptions.ExecuteSynchronously,
                    TaskScheduler.Default);
                allTasks.Add(task);
            }

            foreach (FluentModelTImpl resource in resources.Where(r => r.PendingOperation == PendingOperation.ToBeCreated))
            {
                FluentModelTImpl res = resource;
                Task task = res.CreateAsync(cancellationToken)
                .ContinueWith(createTask =>
                    {
                        if (createTask.IsFaulted)
                        {
                            FluentModelTImpl val;
                            this.collection.TryRemove(res.Name(), out val);
                            if (createTask.Exception.InnerException != null)
                            {
                                exceptions.Add(createTask.Exception.InnerException);
                            }
                            else
                            {
                                exceptions.Add(createTask.Exception);
                            }
                        }
                        else
                        {
                            comitted.Add(res);
                            res.PendingOperation = PendingOperation.None;
                        }
                    },
                    cancellationToken,
                    TaskContinuationOptions.ExecuteSynchronously,
                    TaskScheduler.Default);
                allTasks.Add(task);
            }

            foreach (FluentModelTImpl resource in resources.Where(r => r.PendingOperation == PendingOperation.ToBeUpdated))
            {
                FluentModelTImpl res = resource;
                Task task = res.UpdateAsync(cancellationToken)
                .ContinueWith(updateTask =>
                    {
                        if (updateTask.IsFaulted)
                        {
                            if (updateTask.Exception.InnerException != null)
                            {
                                exceptions.Add(updateTask.Exception.InnerException);
                            }
                            else
                            {
                                exceptions.Add(updateTask.Exception);
                            }
                        }
                        else
                        {
                            comitted.Add(res);
                            res.PendingOperation = PendingOperation.None;
                        }
                    },
                    cancellationToken,
                    TaskContinuationOptions.ExecuteSynchronously,
                    TaskScheduler.Default);
                allTasks.Add(task);
            }

            TaskCompletionSource<List<FluentModelTImpl>> completionSource = new TaskCompletionSource<List<FluentModelTImpl>>();
            Task.WhenAll(allTasks.ToArray())
                .ContinueWith(task =>
                {
                    if (ClearAfterCommit())
                    {
                        this.collection.Clear();
                    }

                    if (exceptions.Count > 0)
                    {
                        completionSource.SetException(new AggregateException(exceptions));
                    }
                    else
                    {
                        completionSource.SetResult(comitted.ToList());
                    }
                },
                cancellationToken,
                TaskContinuationOptions.ExecuteSynchronously,
                TaskScheduler.Default);
            return completionSource.Task;
        }

        /// <summary>
        ///  Finds a child resource with the given name.
        /// </summary>
        /// <param name="name">the key of child resource</param>
        /// <returns>the child resource if exists in the collection else null</returns>
        protected FluentModelTImpl Find(string key)
        {
            var result = this.collection.Where(ele => ele.Key.Equals(key, StringComparison.OrdinalIgnoreCase));
            if (result.Any())
            {
                return result.First().Value;
            }
            return null;
        }

        /// <returns>The parent resource of this collection of child resources.</returns>
        protected ParentImplT Parent
        {
            get; private set;
        }

        /// <returns> true if the child resource collection needs to be cleared after the commit.
        protected abstract bool ClearAfterCommit();
    }
}
