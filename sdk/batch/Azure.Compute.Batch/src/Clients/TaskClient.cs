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

        public virtual Response<Task> Get(string jobId, string taskId, GetOptions options = null)
        {
            return HandleGet(jobId, taskId, options, taskRest.GetTask, Task.DeserializeTask);
        }

        public virtual async System.Threading.Tasks.Task<Response<Task>> GetAsync(string jobId, string taskId, GetOptions options = null)
        {
            return await HandleGetAsync(jobId, taskId, options, taskRest.GetTaskAsync, Task.DeserializeTask).ConfigureAwait(false);
        }

        public virtual Pageable<Task> List(string jobId, ListOptions options = null)
        {
            return HandleList(jobId, options, taskRest.GetTasks, Task.DeserializeTask);
        }

        public virtual Response<TaskHeaders> Add(string jobId, Task task)
        {
            return HandleAdd<TaskHeaders>(jobId, task, taskRest.Add);
        }

        public virtual async System.Threading.Tasks.Task<Response<TaskHeaders>> AddAsync(string jobId, Task task)
        {
            return await HandleAddAsync<TaskHeaders>(jobId, task, taskRest.AddAsync).ConfigureAwait(false);
        }

        public virtual Response<TaskHeaders> Add(string jobId, IEnumerable<Task> tasks)
        {
            if (tasks.Count() > MaxAddTasks)
            {
                throw new ArgumentOutOfRangeException($"Cannot add {tasks.Count()}. Maximum is {MaxAddTasks}");
            }

            TaskAddCollectionParameter addParameter = new TaskAddCollectionParameter(tasks);
            return HandleAdd<TaskHeaders>(jobId, addParameter, taskRest.AddCollection);
        }

        public virtual Response<TaskHeaders> Update(string jobId, Task task)
        {
            return HandleUpdate<TaskHeaders>(jobId, task.Id, task, taskRest.Update);
        }

        public virtual async System.Threading.Tasks.Task<Response<TaskHeaders>> UpdateAsync(string jobId, Task task)
        {
            return await HandleUpdateAsync<TaskHeaders>(jobId, task.Id, task, taskRest.UpdateAsync).ConfigureAwait(false);
        }

        public virtual Response<TaskHeaders> Delete(string jobId, string taskId)
        {
            return HandleDelete<TaskHeaders>(jobId, taskId, taskRest.Delete);
        }

        public virtual async System.Threading.Tasks.Task<Response<TaskHeaders>> DeleteAsync(string jobId, string taskId)
        {
            return await HandleDeleteAsync<TaskHeaders>(jobId, taskId, taskRest.DeleteAsync).ConfigureAwait(false);
        }
    }
}
