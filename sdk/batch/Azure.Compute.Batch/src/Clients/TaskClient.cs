// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.Compute.Batch.Models;
using Azure.Compute.Batch;

namespace Azure.Compute.Batch
{
    public class TaskClient : SubClient
    {
        public const int MaxAddTasks = 100;

        private TaskRest taskRest;

        protected TaskClient() { }

        internal TaskClient(BatchServiceClient serviceClient)
        {
            taskRest = serviceClient.batchRest.GetTaskRestClient(serviceClient.BatchUrl.AbsoluteUri);
        }

        [ForwardsClientCalls(true)]
        public virtual Response<Task> Get(string jobId, string taskId, GetOptions options = null)
        {
            return HandleGet(jobId, taskId, options, taskRest.GetTask, Task.DeserializeTask);
        }

        [ForwardsClientCalls(true)]
        public virtual async System.Threading.Tasks.Task<Response<Task>> GetAsync(string jobId, string taskId, GetOptions options = null)
        {
            return await HandleGetAsync(jobId, taskId, options, taskRest.GetTaskAsync, Task.DeserializeTask).ConfigureAwait(false);
        }

        [ForwardsClientCalls(true)]
        public virtual Pageable<Task> List(string jobId, ListOptions options = null)
        {
            return HandleList(jobId, options, taskRest.GetTasks, Task.DeserializeTask);
        }

        [ForwardsClientCalls(true)]
        public virtual AsyncPageable<Task> ListAsync(string jobId, ListOptions options = null)
        {
            return HandleListAsync(jobId, options, taskRest.GetTasksAsync, Task.DeserializeTask);
        }

        [ForwardsClientCalls(true)]
        public virtual Response Add(string jobId, Task task)
        {
            return HandleAdd(jobId, task, taskRest.Add);
        }

        [ForwardsClientCalls(true)]
        public virtual async System.Threading.Tasks.Task<Response> AddAsync(string jobId, Task task)
        {
            return await HandleAddAsync(jobId, task, taskRest.AddAsync).ConfigureAwait(false);
        }

        [ForwardsClientCalls(true)]
        public virtual Response Add(string jobId, IEnumerable<Task> tasks)
        {
            if (tasks.Count() > MaxAddTasks)
            {
                throw new ArgumentOutOfRangeException($"Cannot add {tasks.Count()}. Maximum is {MaxAddTasks}");
            }

            TaskAddCollectionParameter addParameter = new TaskAddCollectionParameter(tasks);
            return HandleAdd(jobId, addParameter, taskRest.AddCollection);
        }

        [ForwardsClientCalls(true)]
        public virtual Response Update(string jobId, Task task)
        {
            return HandleUpdate(jobId, task.Id, task, taskRest.Update);
        }

        [ForwardsClientCalls(true)]
        public virtual async System.Threading.Tasks.Task<Response> UpdateAsync(string jobId, Task task)
        {
            return await HandleUpdateAsync(jobId, task.Id, task, taskRest.UpdateAsync).ConfigureAwait(false);
        }

        [ForwardsClientCalls(true)]
        public virtual Response Delete(string jobId, string taskId, BaseOptions options = null)
        {
            return HandleDelete(jobId, taskId, options, taskRest.Delete);
        }

        [ForwardsClientCalls(true)]
        public virtual async System.Threading.Tasks.Task<Response> DeleteAsync(string jobId, string taskId, BaseOptions options = null)
        {
            return await HandleDeleteAsync(jobId, taskId, options, taskRest.DeleteAsync).ConfigureAwait(false);
        }
    }
}
