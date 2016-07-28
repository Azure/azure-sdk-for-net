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
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest.Azure;
    using Models = Microsoft.Azure.Batch.Protocol.Models;

    /// <summary>
    /// Performs operations on Azure Batch job schedules.
    /// </summary>
    /// <seealso cref="CloudJobSchedule"/>
    public class JobScheduleOperations : IInheritedBehaviors
    {

#region // constructors

        private JobScheduleOperations()
        {
        }

        internal JobScheduleOperations(BatchClient parentBatchScheduler, IEnumerable<BatchClientBehavior> inheritedBehaviors)
        {
            this.ParentBatchClient = parentBatchScheduler;

            // set up the behavior inheritance
            InheritUtil.InheritClientBehaviorsAndSetPublicProperty(this, inheritedBehaviors);
        }

#endregion //constructors


#region IInheritedBehaviors

        /// <summary>
        /// Gets or sets a list of behaviors that modify or customize requests to the Batch service
        /// made via this <see cref="JobScheduleOperations"/>.
        /// </summary>
        /// <remarks>
        /// <para>These behaviors are inherited by child objects.</para>
        /// <para>Modifications are applied in the order of the collection. The last write wins.</para>
        /// </remarks>
        public IList<BatchClientBehavior> CustomBehaviors { get; set; }

#endregion IInheritedBehaviors

#region // JobScheduleOperations

        /// <summary>
        /// Enumerates the <see cref="CloudJobSchedule">job schedules</see> in the Batch account.
        /// </summary>
        /// <param name="detailLevel">A <see cref="DetailLevel"/> used for filtering the list and for controlling which properties are retrieved from the service.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/> and <paramref name="detailLevel"/>.</param>
        /// <returns>An <see cref="IPagedEnumerable{CloudJobSchedule}"/> that can be used to enumerate job schedules asynchronously or synchronously.</returns>
        /// <remarks>This method returns immediately; the job schedules are retrieved from the Batch service only when the collection is enumerated.
        /// Retrieval is non-atomic; schedules are retrieved in pages during enumeration of the collection.</remarks>
        public IPagedEnumerable<CloudJobSchedule> ListJobSchedules(DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            // set up behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            PagedEnumerable<CloudJobSchedule> enumerable = new PagedEnumerable<CloudJobSchedule>( // the lamda will be the enumerator factory
                () =>
                {
                    // here is the actual strongly typed enumerator
                    AsyncListJobSchedulesEnumerator typedEnumerator = new AsyncListJobSchedulesEnumerator(this, bhMgr, detailLevel);

                    // here is the base
                    PagedEnumeratorBase<CloudJobSchedule> enumeratorBase = typedEnumerator;

                    return enumeratorBase;
                });

            return enumerable;
        }

        /// <summary>
        /// Gets the specified <see cref="CloudJobSchedule"/>.
        /// </summary>
        /// <param name="jobScheduleId">The id of the job schedule to get.</param>
        /// <param name="detailLevel">A <see cref="DetailLevel"/> used for controlling which properties are retrieved from the service.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/> and <paramref name="detailLevel"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="CloudJobSchedule"/> containing information about the specified Azure Batch job schedule.</returns>
        /// <remarks>The get job schedule operation runs asynchronously.</remarks>
        public async System.Threading.Tasks.Task<CloudJobSchedule> GetJobScheduleAsync(
            string jobScheduleId, 
            DetailLevel detailLevel = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // set up behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors, detailLevel);

            using (System.Threading.Tasks.Task<AzureOperationResponse<Models.CloudJobSchedule, Models.JobScheduleGetHeaders>> asyncTask = 
                this.ParentBatchClient.ProtocolLayer.GetJobSchedule(jobScheduleId, bhMgr, cancellationToken))
            {
                AzureOperationResponse<Models.CloudJobSchedule, Models.JobScheduleGetHeaders> result = await asyncTask.ConfigureAwait(continueOnCapturedContext: false);

                // construct a new object bound to the protocol layer object
                CloudJobSchedule newWI = new CloudJobSchedule(this.ParentBatchClient, result.Body, this.CustomBehaviors);

                return newWI;
            }
        }

        /// <summary>
        /// Gets the specified <see cref="CloudJobSchedule"/>.
        /// </summary>
        /// <param name="jobScheduleId">The id of the job schedule to get.</param>
        /// <param name="detailLevel">A <see cref="DetailLevel"/> used for controlling which properties are retrieved from the service.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/> and <paramref name="detailLevel"/>.</param>
        /// <returns>A <see cref="CloudJobSchedule"/> containing information about the specified Azure Batch job schedule.</returns>
        /// <remarks>This is a blocking operation. For a non-blocking equivalent, see <see cref="GetJobScheduleAsync"/>.</remarks>
        public CloudJobSchedule GetJobSchedule(string jobScheduleId, DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task<CloudJobSchedule> asyncTask = this.GetJobScheduleAsync(jobScheduleId, detailLevel, additionalBehaviors))
            {
                CloudJobSchedule result = asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);

                return result;
            }
        }

        /// <summary>
        /// Creates an instance of CloudJobSchedule that is unbound and does not have a consistency relationship to any job schedule in the Batch Service.
        /// </summary>
        /// <returns>A <see cref="CloudJobSchedule"/> representing a new job schedule that has not been submitted to the Batch service.</returns>
        public CloudJobSchedule CreateJobSchedule()
        {
            CloudJobSchedule newJobSchedule = new CloudJobSchedule(this.ParentBatchClient, this.CustomBehaviors);

            return newJobSchedule;
        }

        /// <summary>
        /// Creates an instance of CloudJobSchedule that is unbound and does not have a consistency relationship to any job schedule in the Batch Service.
        /// </summary>
        /// <param name="jobScheduleId">The id of the job schedule.</param>
        /// <param name="schedule">The schedule that determines when jobs will be created.</param>
        /// <param name="jobSpecification">a <see cref="JobSpecification" /> containing details of the jobs to be created according to the <paramref name="schedule"/>.</param>
        /// <returns>A <see cref="CloudJobSchedule"/> representing a new job schedule that has not been submitted to the Batch service.</returns>
        public CloudJobSchedule CreateJobSchedule(string jobScheduleId, Schedule schedule, JobSpecification jobSpecification)
        {
            CloudJobSchedule newJobSchedule = new CloudJobSchedule(this.ParentBatchClient, this.CustomBehaviors)
                                              {
                                                  Id = jobScheduleId,
                                                  Schedule = schedule,
                                                  JobSpecification = jobSpecification
                                              };
            
            return newJobSchedule;
        }

        /// <summary>
        /// Enables the specified job schedule, allowing jobs to be created according to its <see cref="CloudJobSchedule.Schedule"/>.
        /// </summary>
        /// <param name="jobScheduleId">The id of the job schedule.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>The enable operation runs asynchronously.</para>
        /// </remarks>
        public System.Threading.Tasks.Task EnableJobScheduleAsync(string jobScheduleId, IEnumerable<BatchClientBehavior> additionalBehaviors = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // set up behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);
            
            System.Threading.Tasks.Task asyncTask = this.ParentBatchClient.ProtocolLayer.EnableJobSchedule(jobScheduleId, bhMgr, cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Enables the specified job schedule, allowing jobs to be created according to its <see cref="CloudJobSchedule.Schedule"/>.
        /// </summary>
        /// <param name="jobScheduleId">The id of the job schedule.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="EnableJobScheduleAsync"/>.</para>
        /// </remarks>
        public void EnableJobSchedule(string jobScheduleId, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task asyncTask = this.EnableJobScheduleAsync(jobScheduleId, additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        /// <summary>
        /// Disables the specified job schedule.  Disabled schedules do not create new jobs, but may be re-enabled later.
        /// </summary>
        /// <param name="jobScheduleId">The id of the job schedule.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>The disable operation runs asynchronously.</para>
        /// <para>To re-enable the schedule, call <see cref="EnableJobScheduleAsync"/>.</para>
        /// </remarks>
        public System.Threading.Tasks.Task DisableJobScheduleAsync(string jobScheduleId, IEnumerable<BatchClientBehavior> additionalBehaviors = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // set up behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);
            
            System.Threading.Tasks.Task asyncTask = this.ParentBatchClient.ProtocolLayer.DisableJobSchedule(jobScheduleId, bhMgr, cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Disables the specified job schedule.  Disabled schedules do not create new jobs, but may be re-enabled later.
        /// </summary>
        /// <param name="jobScheduleId">The id of the job schedule.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="DisableJobScheduleAsync"/>.</para>
        /// <para>To re-enable the schedule, call <see cref="EnableJobSchedule"/>.</para>
        /// </remarks>
        public void DisableJobSchedule(string jobScheduleId, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task asyncTask = this.DisableJobScheduleAsync(jobScheduleId, additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        /// <summary>
        /// Deletes the specified job schedule.
        /// </summary>
        /// <param name="jobScheduleId">The id of the job schedule.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>The delete operation requests that the job schedule be deleted.  The request puts the schedule in the <see cref="Common.JobScheduleState.Deleting"/> state.
        /// The Batch service will delete any existing jobs and tasks under the schedule, including any active job, and perform the actual job schedule deletion without any further client action.</para>
        /// <para>The delete operation runs asynchronously.</para>
        /// </remarks>
        public async System.Threading.Tasks.Task DeleteJobScheduleAsync(
            string jobScheduleId, 
            IEnumerable<BatchClientBehavior> additionalBehaviors = null, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // set up behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);
            
            Task asyncTask = this.ParentBatchClient.ProtocolLayer.DeleteJobSchedule(jobScheduleId, bhMgr, cancellationToken);

            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Deletes the specified job schedule.
        /// </summary>
        /// <param name="jobScheduleId">The id of the job schedule.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>The delete operation requests that the job schedule be deleted.  The request puts the schedule in the <see cref="Common.JobScheduleState.Deleting"/> state.
        /// The Batch service will delete any existing jobs and tasks under the schedule, including any active job, and perform the actual job schedule deletion without any further client action.</para>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="DeleteJobScheduleAsync"/>.</para>
        /// </remarks>
        public void DeleteJobSchedule(string jobScheduleId, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task asyncTask = this.DeleteJobScheduleAsync(jobScheduleId, additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        /// <summary>
        /// Terminates the specified job schedule.
        /// </summary>
        /// <param name="jobScheduleId">The id of the job schedule.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>The terminate operation requests that the job schedule be terminated.  The request puts the schedule in the <see cref="Common.JobScheduleState.Terminating"/> state.
        /// The Batch service will wait for any active job to terminate, and perform the actual job schedule termination without any further client action.</para>
        /// <para>The terminate operation runs asynchronously.</para>
        /// </remarks>
        public async System.Threading.Tasks.Task TerminateJobScheduleAsync(
            string jobScheduleId, 
            IEnumerable<BatchClientBehavior> additionalBehaviors = null, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // set up behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            Task asyncTask = this.ParentBatchClient.ProtocolLayer.TerminateJobSchedule(jobScheduleId, bhMgr, cancellationToken);

            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Terminates the specified job schedule.
        /// </summary>
        /// <param name="jobScheduleId">The id of the job schedule.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>The terminate operation requests that the job schedule be terminated.  The request puts the schedule in the <see cref="Common.JobScheduleState.Terminating"/> state.
        /// The Batch service will wait for any active job to terminate, and perform the actual job schedule termination without any further client action.</para>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="TerminateJobScheduleAsync"/>.</para>
        /// </remarks>
        public void TerminateJobSchedule(string jobScheduleId, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task asyncTask = this.TerminateJobScheduleAsync(jobScheduleId, additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        internal IPagedEnumerable<CloudJob> ListJobsImpl(string jobScheduleId, BehaviorManager bhMgr, DetailLevel detailLevel)
        {
            PagedEnumerable<CloudJob> enumerable = new PagedEnumerable<CloudJob>( // the lamda will be the enumerator factory
                () =>
                {
                    // here is the actual strongly typed enumerator that lists-by-job-schedule
                    AsyncListJobsEnumerator typedEnumerator = new AsyncListJobsEnumerator(this.ParentBatchClient, jobScheduleId, bhMgr, detailLevel);

                    // here is the base
                    PagedEnumeratorBase<CloudJob> enumeratorBase = typedEnumerator;

                    return enumeratorBase;
                });

            return enumerable;
        }

        /// <summary>
        /// Enumerates the <see cref="CloudJob">jobs</see> created under the specified job schedule.
        /// </summary>
        /// <param name="jobScheduleId">The id of the job schedule.</param>
        /// <param name="detailLevel">A <see cref="DetailLevel"/> used for filtering the list and for controlling which properties are retrieved from the service.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/> and <paramref name="detailLevel"/>.</param>
        /// <returns>An <see cref="IPagedEnumerable{CloudJob}"/> that can be used to enumerate jobs asynchronously or synchronously.</returns>
        /// <remarks>This method returns immediately; the jobs are retrieved from the Batch service only when the collection is enumerated.
        /// Retrieval is non-atomic; jobs are retrieved in pages during enumeration of the collection.</remarks>
        public IPagedEnumerable<CloudJob> ListJobs(string jobScheduleId, DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            // set up behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            IPagedEnumerable<CloudJob> enumerable = ListJobsImpl(jobScheduleId, bhMgr, detailLevel);

            return enumerable;
        }

#endregion // JobScheduleOperations

#region // internal/private

        internal BatchClient ParentBatchClient { get; set;}

#endregion // internal/private
    }
}
