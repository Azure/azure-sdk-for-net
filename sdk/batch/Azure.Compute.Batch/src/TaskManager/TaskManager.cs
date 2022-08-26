// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using Azure.Compute.Batch.Models;

namespace Azure.Compute.Batch
{
    public class TaskManager
    {
        private const int maxTaskCount = 100;

        private TaskClient taskClient;
        private string jobId;
        private Queue<Task> pendingTasks;
        private List<TaskSubmitter> activeSubmitters = new List<TaskSubmitter>();
        private int maxSubmitters;

        public TaskManager(TaskClient taskClient, string jobId, IEnumerable<Task> tasks, int maxParralelSubmitters = 1)
        {
            this.taskClient = taskClient;
            this.jobId = jobId;
            this.maxSubmitters = maxParralelSubmitters;
            this.pendingTasks = new Queue<Task>(tasks);
        }

        public void Start()
        {
            AddSubmitters();

            while (IsFinished() == false)
            {
                AddSubmitters();
            }
        }

        private void AddSubmitters()
        {
            while (pendingTasks.Count > 0 && activeSubmitters.Where(s => s.IsFinished() == false).Count() < maxSubmitters)
            {
                AddSubmitter();
            }
        }

        private void AddSubmitter()
        {
            List<Task> tasksToAdd = new List<Task>();
            while (tasksToAdd.Count < maxTaskCount && pendingTasks.Count > 0)
            {
                Task task = pendingTasks.Dequeue();
                tasksToAdd.Add(task);
                //Console.WriteLine($"Adding task {task.Id}");
            }
            activeSubmitters.Add(new TaskSubmitter(taskClient, jobId, tasksToAdd));
        }

        private bool IsFinished()
        {
            return pendingTasks.Count == 0 && activeSubmitters.Any(s => s.IsFinished() == false);
        }
    }
}
