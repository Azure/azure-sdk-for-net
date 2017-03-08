// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Microsoft.Azure.Batch
{
    using System.Collections.Generic;
    using System.Linq;

    public partial class TaskDependencies
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaskDependencies"/> class.
        /// </summary>
        /// <param name="taskIds">The list of task ids that must complete before this task can be scheduled. null is treated as an empty list.</param>
        /// <param name="taskIdRanges">The list of task ranges that must complete before this task can be scheduled. null is treated as an empty list.</param>
        /// <remarks>This constructor provides the most general way of initializing a TaskDependencies object.
        /// In practice, most dependencies are on a single task, a list of task ids, or a single range of
        /// tasks. You can express these dependencies more clearly using <see cref="OnId"/>, <see cref="OnIds(string[])"/>,
        /// <see cref="OnTasks(CloudTask[])"/>, and <see cref="OnIdRange"/> methods.</remarks>
        public TaskDependencies(IEnumerable<string> taskIds, IEnumerable<TaskIdRange> taskIdRanges)
        {
            if (taskIds == null)
            {
                taskIds = Enumerable.Empty<string>();
            }

            if (taskIdRanges == null)
            {
                taskIdRanges = Enumerable.Empty<TaskIdRange>();
            }

            this.taskIds = new List<string>(taskIds).AsReadOnly();
            this.taskIdRanges = new List<TaskIdRange>(taskIdRanges).AsReadOnly();
        }

        /// <summary>
        /// Gets a <see cref="TaskDependencies"/> representing dependency on a single task.
        /// </summary>
        /// <param name="id">The task to depend on.</param>
        /// <returns>A <see cref="TaskDependencies"/> representing dependency on a single task.</returns>
        public static TaskDependencies OnId(string id)
        {
            return new TaskDependencies(new[] { id }, null);
        }

        /// <summary>
        /// Gets a <see cref="TaskDependencies"/> representing dependency on a list of task ids.
        /// </summary>
        /// <param name="ids">The tasks to depend on.</param>
        /// <returns>A <see cref="TaskDependencies"/> representing dependency on the specified tasks.</returns>
        public static TaskDependencies OnIds(IEnumerable<string> ids)
        {
            return new TaskDependencies(ids, null);
        }

        /// <summary>
        /// Gets a <see cref="TaskDependencies"/> representing dependency on a list of task ids.
        /// </summary>
        /// <param name="ids">The tasks to depend on.</param>
        /// <returns>A <see cref="TaskDependencies"/> representing dependency on the specified tasks.</returns>
        public static TaskDependencies OnIds(params string[] ids)
        {
            return new TaskDependencies(ids, null);
        }

        /// <summary>
        /// Gets a <see cref="TaskDependencies"/> representing dependency on a list of tasks.
        /// </summary>
        /// <param name="tasks">The tasks to depend on.</param>
        /// <returns>A <see cref="TaskDependencies"/> representing dependency on the specified tasks.</returns>
        public static TaskDependencies OnTasks(IEnumerable<CloudTask> tasks)
        {
            return new TaskDependencies(tasks.Select(t => t.Id), null);
        }

        /// <summary>
        /// Gets a <see cref="TaskDependencies"/> representing dependency on a list of tasks.
        /// </summary>
        /// <param name="tasks">The tasks to depend on.</param>
        /// <returns>A <see cref="TaskDependencies"/> representing dependency on the specified tasks.</returns>
        public static TaskDependencies OnTasks(params CloudTask[] tasks)
        {
            return new TaskDependencies(tasks.Select(t => t.Id), null);
        }

        /// <summary>
        /// Gets a <see cref="TaskDependencies"/> representing dependency on a range of task ids.
        /// </summary>
        /// <param name="start">The first task id in the range to depend on.</param>
        /// <param name="end">The last task id in the range to depend on.</param>
        /// <returns>A <see cref="TaskDependencies"/> representing dependency on the specified range of tasks.</returns>
        public static TaskDependencies OnIdRange(int start, int end)
        {
            return new TaskDependencies(null, new[] { new TaskIdRange(start, end) });
        }
    }
}