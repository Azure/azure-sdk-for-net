// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Data.Batch.Models;

namespace Azure.Data.Batch.TaskManager
{
    internal class TaskManager
    {
        private JobClient jobClient;
        private TaskClient taskClient;
        private string jobId;
        private Queue<Task> pendingTasks = new Queue<Task>();
        private Queue<Task> activeTasks = new Queue<Task>();
        private Queue<Task> completedTasks = new Queue<Task>();

        public TaskManager(JobClient jobClient, TaskClient taskClient, string jobId, IEnumerable<Task> tasks)
        {
            this.jobClient = jobClient;
            this.taskClient = taskClient;

            this.jobId = jobId;

            foreach (var task in tasks)
            {
                pendingTasks.Enqueue(task);
            }
        }

        private void CheckStatus()
        {
            var tasks = taskClient.ListTasks(jobId);
        }

        private void StartTasks()
        {

        }

        private bool IsFinished()
        {
            return pendingTasks.Count == 0 && activeTasks.Count == 0;
        }
    }
}
