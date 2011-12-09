//-----------------------------------------------------------------------
// <copyright file="InvokeTaskSequenceTask.cs" company="Microsoft">
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
//    Contains code for the InvokeTaskSequenceTask and InvokeTaskSequenceTask[T] classes.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Tasks
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    using TaskSequence = System.Collections.Generic.IEnumerable<ITask>;

    /// <summary>
    /// Invokes a sequence with no return value.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Other class is a generic class with the same name.")]
    internal class InvokeTaskSequenceTask : InvokeTaskSequenceTask<NullTaskReturn>
    {
        /// <summary>
        /// Initializes a new instance of the InvokeTaskSequenceTask class for sequence without any return value.
        /// </summary>
        /// <param name="sequenceFunction">The sequence of actions to be invoked.</param>
        [DebuggerNonUserCode]
        public InvokeTaskSequenceTask(Func<TaskSequence> sequenceFunction)
            : base((a) => sequenceFunction())
        {
        }
    }

    /// <summary>
    /// Invokes a sequence of tasks.
    /// </summary>
    /// <typeparam name="T">The type of the result of the operation.</typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Other class is a non-generic specialization with the same name.")]
    internal class InvokeTaskSequenceTask<T> : Task<T>
    {
        /// <summary>
        /// Contains the function that generates a squence of tasks to be invoked.
        /// </summary>
        private Func<Action<T>, TaskSequence> sequenceGenerator;

        /// <summary>
        /// The current task that is being invoked.
        /// </summary>
        private ITask currentTask;

        /// <summary>
        /// Controls whether the abort was called.
        /// </summary>
        private bool aborting;

        /// <summary>
        /// Initializes a new instance of the InvokeTaskSequenceTask class with a task sequence that returns a value.
        /// </summary>
        /// <param name="sequenceFunction">The sequence of actions to be invoked.</param>
        [DebuggerNonUserCode]
        public InvokeTaskSequenceTask(Func<Action<T>, TaskSequence> sequenceFunction)
        {
            TraceHelper.WriteLine("InvokeTaskSequenceTask, constructor");
            this.sequenceGenerator = sequenceFunction;
        }

        /// <summary>
        /// Implements the abort logic by aborting the current task.
        /// </summary>
        [DebuggerNonUserCode]
        protected override void AbortInternal()
        {
            TraceHelper.WriteLine("InvokeTaskSequenceTask, AbortInternal");
            this.aborting = true;
            ITask task = this.currentTask;
            if (task != null)
            {
                task.Abort();
            }
        }

        /// <summary>
        /// The starting point for executing a task sequence.
        /// </summary>
        [DebuggerNonUserCode]
        protected override void ExecuteInternal()
        {
            TraceHelper.WriteLine("InvokeTaskSequenceTask, ExecuteInternal");
            TaskSequence sequence = this.sequenceGenerator((res) => this.Result = res);
            IEnumerator<ITask> en = sequence.GetEnumerator();
            this.ExecuteTaskSequence(en, true);
        }

        /// <summary>
        /// Executes a task sequence by iterating over all of the items and executing them.
        /// </summary>
        /// <param name="taskList">The sequence of tasks to execute.</param>
        /// <param name="completedSynchronously">Whether the sequence so far has completed synchronously.</param>
        [DebuggerNonUserCode]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Design",
            "CA1031:DoNotCatchGeneralExceptionTypes",
            Justification = "Exception is saved")]
        private void ExecuteTaskSequence(IEnumerator<ITask> taskList, bool completedSynchronously)
        {
            TraceHelper.WriteLine("InvokeTaskSequenceTask, ExecuteTaskSequence");
        Run:
            TraceHelper.WriteLine("InvokeTaskSequenceTask, ExecuteTaskSequence Run");

            // complete previous task
            ITask task = taskList.Current;

            // handle abort
            if (this.aborting)
            {
                return;
            }

            // move to next task
            bool hasTask;
            try
            {
                hasTask = taskList.MoveNext();
            }
            catch (Exception ex)
            {
                this.Exception = ex;

                // If this operation hasn't moved to a background thread, we should throw the exception out.
                // This is to follow guideline #7 in  http://csdweb/sites/oslo/engsys/DesignGuidelines/Wiki%20Pages/IAsyncResult.aspx:
                //     "The callback is called exactly once, unless BeginXxx throws, in which case it isn’t called"
                // It also provides the user with better exception stack trace, faster error notification and saves potential WaitHandle construction
                if (completedSynchronously)
                {
                    throw;
                }

                this.Complete(completedSynchronously);
                return;
            }

            if (!hasTask)
            {
                // complete
                this.Complete(completedSynchronously);
                return;
            }

            // invoke task
            task = taskList.Current;
            try
            {
                this.currentTask = task;
                task.ExecuteStep(() =>
                    {
                        if (!task.CompletedSynchronously)
                        {
                            this.currentTask = null; ExecuteTaskSequence(taskList, false);
                        }
                    });
            }
            catch (Exception ex)
            {
                this.currentTask = null;
                this.Exception = ex;
                this.Complete(completedSynchronously);
                return;
            }

            if (task.CompletedSynchronously)
            {
                this.currentTask = null;
                goto Run;
            }
        }
    }
}
