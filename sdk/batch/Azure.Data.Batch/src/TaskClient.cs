// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.Data.Batch.Models;
using Azure.Data.Batch;

namespace Azure.Data.Batch
{
    public partial class TaskClient : BaseClient
    {
        public const int MaxAddTasks = 100;

        public virtual Response<Task> GetTask(string jobId, string taskId, GetOptions options = null)
        {
            return HandleGet(jobId, taskId, options, GetTask, Task.DeserializeTask);
        }

        public virtual async System.Threading.Tasks.Task<Response<Task>> GetTaskAsync(string jobId, string taskId, GetOptions options = null)
        {
            return await HandleGetAsync(jobId, taskId, options, GetTaskAsync, Task.DeserializeTask).ConfigureAwait(false);
        }

        public virtual Pageable<Task> ListTasks(string jobId, ListOptions options = null)
        {
            return HandleList(jobId, options, GetTasks, Task.DeserializeTask);
        }

        private static Response<Task> GetResponse(Response response)
        {
            JsonDocument json = JsonDocument.Parse(response.Content);
            Task task = Task.DeserializeTask(json.RootElement);
            return Response.FromValue(task, response);
        }

        public virtual Response<TaskHeaders> AddTask(string jobId, Task task)
        {
            return HandleAdd<TaskHeaders>(jobId, task, Add);
        }

        public virtual async System.Threading.Tasks.Task<Response<TaskHeaders>> AddTaskAsync(string jobId, Task task)
        {
            return await HandleAddAsync<TaskHeaders>(jobId, task, AddAsync).ConfigureAwait(false);
        }

        public virtual Response<TaskHeaders> AddTasks(string jobId, IEnumerable<Task> tasks)
        {
            if (tasks.Count() > MaxAddTasks)
            {
                throw new ArgumentOutOfRangeException($"Cannot add {tasks.Count()}. Maximum is {MaxAddTasks}");
            }

            TaskAddCollectionParameter addParameter = new TaskAddCollectionParameter(tasks);
            return HandleAdd<TaskHeaders>(jobId, addParameter, AddCollection);
        }

        public virtual Response<TaskHeaders> UpdateTask(string jobId, Task task)
        {
            return HandleUpdate<TaskHeaders>(jobId, task.Id, task, Update);
        }

        public virtual async System.Threading.Tasks.Task<Response<TaskHeaders>> UpdateTaskAsync(string jobId, Task task)
        {
            return await HandleUpdateAsync<TaskHeaders>(jobId, task.Id, task, UpdateAsync).ConfigureAwait(false);
        }

        public virtual Response<TaskHeaders> DeleteTask(string jobId, string taskId)
        {
            return HandleDelete<TaskHeaders>(jobId, taskId, Delete);
        }

        public virtual async System.Threading.Tasks.Task<Response<TaskHeaders>> DeleteTaskAsync(string jobId, string taskId)
        {
            return await HandleDeleteAsync<TaskHeaders>(jobId, taskId, DeleteAsync).ConfigureAwait(false);
        }
    }
}
