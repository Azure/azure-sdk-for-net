// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.Data.Batch.Models;

namespace Azure.Data.Batch
{
    public partial class TaskClient : BaseClient
    {
        public virtual Response<Task> GetTask(string jobId, string taskId)
        {
            return HandleGet(jobId, taskId, GetTask, Task.DeserializeTask);
        }

        public virtual async System.Threading.Tasks.Task<Response<Task>> GetTaskAsync(string jobId, string taskId)
        {
            return await HandleGetAsync(jobId, taskId, GetTaskAsync, Task.DeserializeTask).ConfigureAwait(false);
        }

        public virtual Pageable<Task> ListTasks(string jobId, string filter = null, string select = null, string expand = null, int? maxResults = null, int? timeout = null, Guid? clientRequestId = null, bool? returnClientRequestId = null, DateTimeOffset? ocpDate = null, RequestContext context = null)
        {
            return HandleList(jobId, GetTasks, Task.DeserializeTask, filter, select, expand, maxResults, timeout, clientRequestId, returnClientRequestId, ocpDate, context);
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
