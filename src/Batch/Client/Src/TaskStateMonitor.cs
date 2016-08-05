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

﻿namespace Microsoft.Azure.Batch
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides utilities to help monitor CloudTask states.
    /// </summary>
    public class TaskStateMonitor : IInheritedBehaviors
    {
        private readonly Utilities _parentUtilities;

#region constructors

        private TaskStateMonitor()
        {
        }

        internal TaskStateMonitor(Utilities parentUtilities, IEnumerable<BatchClientBehavior> baseBehaviors)
        {
            _parentUtilities = parentUtilities;

            // inherit from parent
            InheritUtil.InheritClientBehaviorsAndSetPublicProperty(this, baseBehaviors);
        }

#endregion constructors


#region IInheritedBehaviors

        /// <summary>
        /// Gets or sets a list of behaviors that modify or customize requests to the Batch service
        /// made via this <see cref="TaskStateMonitor"/>.
        /// </summary>
        /// <remarks>
        /// <para>These behaviors are inherited by child objects.</para>
        /// <para>Modifications are applied in the order of the collection. The last write wins.</para>
        /// </remarks>
        public IList<BatchClientBehavior> CustomBehaviors { get; set; }

        #endregion IInheritedBehaviors

        #region TaskStateMonitor

        /// <summary>
        /// Monitors a <see cref="CloudTask"/> collection until each of its members has reached a desired state at least once.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The state of each <see cref="CloudTask"/> instance is assumed to be authoritative at the time of the call.
        /// Instances that are already at the <paramref name="desiredState"/> are ignored.
        /// The <see cref="CloudTask"/> instances in the collection are treated as read-only.
        /// This means that when the call completes (timeout or not) the <see cref="CloudTask"/> instances should be refreshed before using.
        /// </para>
        /// <para>
        /// This method runs asynchronously.
        /// </para>
        /// </remarks>
        /// <param name="tasksToMonitor">The collection of tasks to monitor.</param>
        /// <param name="desiredState">The target state of the tasks. The method will exit when all tasks have reached this state at least once.</param>
        /// <param name="timeout">The maximum amount of time this call will wait before timing out.</param>
        /// <param name="controlParams">Controls various settings of the monitor, such as delay between each poll.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <exception cref="TimeoutException">Thrown if the <paramref name="timeout"/> has elapsed.</exception>
        public async Task WhenAll(
            IEnumerable<CloudTask> tasksToMonitor,
            Common.TaskState desiredState,
            TimeSpan timeout,
            ODATAMonitorControl controlParams = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (CancellationTokenSource tokenSource = new CancellationTokenSource(timeout))
            {
                try
                {
                    await this.WhenAllImplAsync(
                        tasksToMonitor,
                        desiredState,
                        tokenSource.Token,
                        controlParams,
                        additionalBehaviors).ConfigureAwait(continueOnCapturedContext: false);
                }
                catch (OperationCanceledException cancellationException)
                {
                    if (cancellationException.CancellationToken == tokenSource.Token)
                    {
                        throw new TimeoutException(
                            string.Format(BatchErrorMessages.ODataMonitorTimedOut, timeout),
                            cancellationException);
                    }

                    throw;
                }
            }
        }

        /// <summary>
        /// Monitors a <see cref="CloudTask"/> collection until each of its members has reached a desired state at least once.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The state of each <see cref="CloudTask"/> instance is assumed to be authoritative at the time of the call.
        /// Instances that are already at the <paramref name="desiredState"/> are ignored.
        /// The <see cref="CloudTask"/> instances in the collection are treated as read-only.
        /// This means that when the call completes (timeout or not) the <see cref="CloudTask"/> instances should be refreshed before using.
        /// </para>
        /// <para>
        /// This method runs asynchronously.
        /// </para>
        /// </remarks>
        /// <param name="tasksToMonitor">The collection of tasks to monitor.</param>
        /// <param name="desiredState">The target state of the tasks. The method will exit when all tasks have reached this state at least once.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <param name="controlParams">Controls various settings of the monitor, such as delay between each poll.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <exception cref="OperationCanceledException">Thrown if the <paramref name="cancellationToken"/> was cancelled.</exception>
        public async Task WhenAll(
            IEnumerable<CloudTask> tasksToMonitor,
            Common.TaskState desiredState,
            CancellationToken cancellationToken,
            ODATAMonitorControl controlParams = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            await this.WhenAllImplAsync(
                tasksToMonitor,
                desiredState,
                cancellationToken,
                controlParams,
                additionalBehaviors).ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Monitors a <see cref="CloudTask"/> collection until each of its members has reached a desired state at least once.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The state of each <see cref="CloudTask"/> instance is assumed to be authoritative at the time of the call.
        /// Instances that are already at the <paramref name="desiredState"/> are ignored.
        /// The <see cref="CloudTask"/> instances in the collection are treated as read-only.
        /// This means that when the call completes (timeout or not) the <see cref="CloudTask"/> instances should be refreshed before using.
        /// </para>
        /// <para>
        /// This is a blocking operation. For a non-blocking equivalent, see
        /// <see cref="WhenAll(System.Collections.Generic.IEnumerable{Microsoft.Azure.Batch.CloudTask},Microsoft.Azure.Batch.Common.TaskState,System.TimeSpan,Microsoft.Azure.Batch.ODATAMonitorControl,System.Collections.Generic.IEnumerable{Microsoft.Azure.Batch.BatchClientBehavior})"/>.
        /// </para>
        /// </remarks>
        /// <param name="tasksToMonitor">The collection of tasks to monitor.</param>
        /// <param name="desiredState">The target state of the tasks. The method will exit when all tasks have reached this state at least once.</param>
        /// <param name="timeout">The maximum amount of time this call will wait before timing out.</param>
        /// <param name="controlParams">Controls various settings of the monitor, such as delay between each poll.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <exception cref="TimeoutException">Thrown if the <paramref name="timeout"/> has elapsed.</exception>
        public void WaitAll(
            IEnumerable<CloudTask> tasksToMonitor,
            Common.TaskState desiredState,
            TimeSpan timeout,
            ODATAMonitorControl controlParams = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (Task asyncTask = this.WhenAll(tasksToMonitor, desiredState, timeout, controlParams, additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        private async Task WhenAllImplAsync(
            IEnumerable<CloudTask> tasksToMonitor,
            Common.TaskState desiredState,
            CancellationToken cancellationToken,
            ODATAMonitorControl controlParams,
            IEnumerable<BatchClientBehavior> additionalBehaviors)
        {
            if (null == tasksToMonitor)
            {
                throw new ArgumentNullException("tasksToMonitor");
            }

            // we only need the id and state for this monitor.  the filter clause will be updated by the monitor
            ODATADetailLevel odataSuperOptimalPredicates = new ODATADetailLevel() { SelectClause = "id,state" };

            // for validation and list calls we need the parent name values
            string jobId = null;

            // set up behaviors
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            // set up control params if needed
            if (null == controlParams)
            {
                controlParams = new ODATAMonitorControl(); // use defaults
            }

            tasksToMonitor = await UtilitiesInternal.EnumerateIfNeededAsync(tasksToMonitor, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);

            // validation: job schedule id and jobId
            foreach (CloudTask curTask in tasksToMonitor)
            {
                // can only monitor bound objects
                if (curTask.BindingState != BindingState.Bound)
                {
                    Exception ex = UtilitiesInternal.OperationForbiddenOnUnboundObjects;

                    throw ex;
                }

                // set or validate job Id
                if (null == jobId)
                {
                    jobId = curTask.ParentJobId;
                }
                else
                {
                    // all instances must have same parent
                    if (!jobId.Equals(curTask.ParentJobId, StringComparison.InvariantCultureIgnoreCase))
                    {
                        Exception ex = UtilitiesInternal.MonitorRequiresConsistentHierarchyChain;

                        throw ex;
                    }
                }
            }

            // start call
            Task asyncTask = ODATAMonitor.WhenAllAsync(
                tasksToMonitor,
                x =>
                {
                    // return true if is desired state
                    bool hasReachedDesiredState = x.State == desiredState;
                    return hasReachedDesiredState;
                },
                x => { return x.Id; },  // return the Id of the task
                () => _parentUtilities.ParentBatchClient.JobOperations.ListTasksImpl(jobId, bhMgr, odataSuperOptimalPredicates),   // call this lambda to (re)fetch the list
                cancellationToken,
                odataSuperOptimalPredicates,
                controlParams);

            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }

#endregion TaskStateMonitor

    }
}
