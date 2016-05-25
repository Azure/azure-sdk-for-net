namespace Microsoft.Azure.Batch
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
        /// Begins asynchronous call to monitor an CloudTask collection until each of its members has reached a desired state at least once.
        /// The State of each CloudTask instance is assumed to authoritative at the time of the call.
        /// Instances that are already at the desiredState are ignored.
        /// The CloudTask instances in the collection are treated as read-only.
        /// No updates are made to any of these instances.
        /// This means that when the call completes (timeout or not) the CloudTask instances should be refreshed before using.
        /// </summary>
        /// <param name="tasksToMonitor">The collection of tasks to monitor.</param>
        /// <param name="desiredState">The target state of the tasks.  The WaitAll will exit when all tasks have reached this state at least once.</param>
        /// <param name="timeout">The maximum amount of time this call will wait before timing out.</param>
        /// <param name="controlParams">Controls various settings of the monitor, such as delay between each poll.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        /// <returns>True if the WaitAll timed out, false if it did not.</returns>
        [Obsolete("Renamed to WhenAllAsync in 9/2015")]
        public Task<bool> WaitAllAsync(
                                        IEnumerable<CloudTask> tasksToMonitor,
                                        Common.TaskState desiredState,
                                        TimeSpan timeout,
                                        ODATAMonitorControl controlParams = null,
                                        IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            return this.WhenAllAsync(
                tasksToMonitor,
                desiredState,
                timeout,
                controlParams,
                additionalBehaviors);
        }

        /// <summary>
        /// Begins asynchronous call to monitor an CloudTask collection until each of its members has reached a desired state at least once.
        /// The State of each CloudTask instance is assumed to authoritative at the time of the call.
        /// Instances that are already at the desiredState are ignored.
        /// The CloudTask instances in the collection are treated as read-only.
        /// No updates are made to any of these instances.
        /// This means that when the call completes (timeout or not) the CloudTask instances should be refreshed before using.
        /// </summary>
        /// <param name="tasksToMonitor">The collection of tasks to monitor.</param>
        /// <param name="desiredState">The target state of the tasks.  The WhenAll will exit when all tasks have reached this state at least once.</param>
        /// <param name="timeout">The maximum amount of time this call will wait before timing out.</param>
        /// <param name="controlParams">Controls various settings of the monitor, such as delay between each poll.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        /// <returns>True if the WhenAll timed out, false if it did not.</returns>
        public Task<bool> WhenAllAsync(
            IEnumerable<CloudTask> tasksToMonitor,
            Common.TaskState desiredState,
            TimeSpan timeout,
            ODATAMonitorControl controlParams = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            return this.WhenAllImplAsync(
                tasksToMonitor,
                desiredState,
                timeout,
                CancellationToken.None,
                controlParams,
                additionalBehaviors,
                throwOnTimeout: false);
        }

        /// <summary>
        /// Begins asynchronous call to monitor an CloudTask collection until each of its members has reached a desired state at least once.
        /// The State of each CloudTask instance is assumed to authoritative at the time of the call.
        /// Instances that are already at the desiredState are ignored.
        /// The CloudTask instances in the collection are treated as read-only.
        /// No updates are made to any of these instances.
        /// This means that when the call completes (timeout or not) the CloudTask instances should be refreshed before using.
        /// If time time specified in the <paramref name="timeout"/> is exceeded a <see cref="TimeoutException"/> is thrown.
        /// </summary>
        /// <remarks>This method throws an exception if a timeout or cancellation occurs.</remarks>
        /// <param name="tasksToMonitor">The collection of tasks to monitor.</param>
        /// <param name="desiredState">The target state of the tasks.  The WaitAll will exit when all tasks have reached this state at least once.</param>
        /// <param name="timeout">The maximum amount of time this call will wait before timing out.</param>
        /// <param name="controlParams">Controls various settings of the monitor, such as delay between each poll.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        public async Task WhenAllAsync(
            IEnumerable<CloudTask> tasksToMonitor,
            Common.TaskState desiredState,
            TimeSpan timeout,
            CancellationToken cancellationToken,
            ODATAMonitorControl controlParams = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            await this.WhenAllImplAsync(
                tasksToMonitor,
                desiredState,
                timeout,
                cancellationToken,
                controlParams,
                additionalBehaviors,
                throwOnTimeout: true).ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Blocking call to monitor an CloudTask collection until each of its members has reached a desired state at least once.
        /// The State of each CloudTask instance is assumed to authoritative at the time of the call.
        /// Instances that are already at the desiredState are ignored.
        /// The CloudTask instances in the collection are treated as read-only.
        /// No updates are made to any of these instances.
        /// This means that when the call completes (timeout or not) the CloudTask instances should be refreshed before using.
        /// </summary>
        /// <param name="tasksToMonitor">The collection of tasks to monitor.</param>
        /// <param name="desiredState">The target state of the tasks.  The WaitAll will exit when all tasks have reached this state at least once.</param>
        /// <param name="timeout">The maximum amount of time this call will wait before timing out.</param>
        /// <param name="controlParams">Controls various settings of the monitor, such as delay between each poll.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        /// <returns>True if the WaitAll timed out, false if it did not.</returns>
        public bool WaitAll(
            IEnumerable<CloudTask> tasksToMonitor,
            Common.TaskState desiredState,
            TimeSpan timeout,
            ODATAMonitorControl controlParams = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (Task<bool> asyncTask = WhenAllAsync(tasksToMonitor, desiredState, timeout, controlParams, additionalBehaviors))
            {
                return asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        private async Task<bool> WhenAllImplAsync(
            IEnumerable<CloudTask> tasksToMonitor,
            Common.TaskState desiredState,
            TimeSpan timeout,
            CancellationToken cancellationToken,
            ODATAMonitorControl controlParams,
            IEnumerable<BatchClientBehavior> additionalBehaviors,
            bool throwOnTimeout)
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
            Task<bool> asyncTask = ODATAMonitor.WhenAllAsync<CloudTask>(
                                                    tasksToMonitor,
                                                    x =>
                                                    {
                                                        // return true if is desired state
                                                        bool hasReachedDesiredState = x.State == desiredState;

                                                        /*  TODO: add logging feature and include this at some logging level
                                                        if (hasReachedDesiredState)
                                                        {
                                                            Console.WriteLine("dropping task: " + x.Id + ", state: " + x.State);
                                                        }
                                                        */

                                                        return hasReachedDesiredState;
                                                    },

                                                    x => { return x.Id; },  // return the Id of the task
                                                    () => _parentUtilities.ParentBatchClient.JobOperations.ListTasksImpl(jobId, bhMgr, odataSuperOptimalPredicates),   // call this lambda to (re)fetch the list
                                                    timeout,
                                                    cancellationToken,
                                                    odataSuperOptimalPredicates,
                                                    controlParams,
                                                    throwOnTimeout);

            return await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }
        
#endregion TaskStateMonitor

    }
}
