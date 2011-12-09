//-----------------------------------------------------------------------
// <copyright file="RaceTask.cs" company="Microsoft">
//    Copyright 2011 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// <summary>
//    Contains code for the RaceTask[T] class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Tasks
{
    using System.Diagnostics;
    using System.Threading;

    /// <summary>
    /// Facilitates a scenario where numerous simultaneous tasks are active, and only the first to complete should continue.
    /// </summary>
    /// <typeparam name="T">The type of the result of the operation.</typeparam>
    internal class RaceTask<T> : Task<T>
    {
        /// <summary>
        /// Stores the abort flag.
        /// </summary>
        private int aborting;

        /// <summary>
        /// Stores the racing tasks.
        /// </summary>
        private Task<T>[] tasks;

        /// <summary>
        /// Initializes a new instance of the <see cref="RaceTask&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="tasks">The tasks.</param>
        [DebuggerNonUserCode]
        public RaceTask(params Task<T>[] tasks)
        {
            TraceHelper.WriteLine("Creating race task with count " + tasks.Length);
            this.tasks = tasks;
        }

        /// <summary>
        /// The specific implementation of the task's step.
        /// </summary>
        [DebuggerNonUserCode]
        protected override void ExecuteInternal()
        {
            TraceHelper.WriteLine("RaceTask, ExecuteInternal");

            // kick off the tasks
            foreach (Task<T> async in this.tasks)
            {
                if (this.Completed)
                {
                    break;
                }

                Task<T> a2 = async;
                a2.ExecuteStep(delegate { this.OnComplete(a2); });
            }
        }

        /// <summary>
        /// The task-specific abort that should be called.
        /// </summary>
        [DebuggerNonUserCode]
        protected override void AbortInternal()
        {
            TraceHelper.WriteLine("RaceTask, AbortInternal");

            if (this.Completed)
            {
                return;
            }

            // This is to avoid tasks trying to complete on a competing thread
            int currentlyAborting = Interlocked.CompareExchange(ref this.aborting, 1, 0);

            if (currentlyAborting == 1)
            {
                return;
            }

            // abort all inner tasks
            foreach (Task<T> innerTask in this.tasks)
            {
                innerTask.Abort();
            }
        }

        /// <summary>
        /// Called when complete.
        /// </summary>
        /// <param name="winner">The winning task.</param>
        [DebuggerNonUserCode]
        private void OnComplete(Task<T> winner)
        {
            TraceHelper.WriteLine("RaceTask, OnComplete");
            if (this.Completed)
            {
                return;
                ////throw new InvalidOperationException("completion already occurred");
            }

            int currentlyAborting = Interlocked.CompareExchange(ref this.aborting, 1, 0);

            if (currentlyAborting == 1)
            {
                // the loser tasks (ie. this) are 'completing'
                return;
            }

            // winner reaches here
            // abort the other tasks
            foreach (Task<T> loser in this.tasks)
            {
                if (!object.ReferenceEquals(loser, winner))
                {
                    loser.Abort();
                }
            }

            if (winner.Exception != null)
            {
                this.Exception = winner.Exception;
            }
            else
            {
                SetResult(() => winner.Result);
            }

            Complete(winner.CompletedSynchronously);
        }
    }
}
