// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Compute.Batch.Models;

namespace Azure.Compute.Batch
{
    internal class TaskSubmitter
    {
        private readonly TaskClient taskClient;
        private readonly string jobId;
        private readonly int total;
        private int completedCount;

        public TaskSubmitter(TaskClient taskClient, string jobId, IEnumerable<Task> pendingTasks)
        {
            this.taskClient = taskClient;
            this.jobId = jobId;
            total = pendingTasks.Count();

            new System.Threading.Thread(() =>
            {
                AddTasks(pendingTasks.ToList());
            }).Start();
        }

        protected void AddTasks(List<Task> tasks)
        {
            try
            {
                Response<TaskHeaders> result = taskClient.Add(jobId, tasks);
                completedCount += tasks.Count;
            }
            catch (Azure.RequestFailedException exception)
            {
                if (exception.Status == 413)
                {
                    Split(tasks.ToList());
                }
                else
                {
                    throw;
                }
            }
        }

        protected void Split(List<Task> tasks)
        {
            int count = tasks.Count;
            int half = count / 2; // integer division rounds down.
            AddTasks(tasks.GetRange(0, half));
            AddTasks(tasks.GetRange(half, count - half));
        }

        public bool IsFinished()
        {
            return completedCount == total;
        }
    }
}
