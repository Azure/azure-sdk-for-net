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
    using Microsoft.Rest.Azure;
    using Models = Microsoft.Azure.Batch.Protocol.Models;

    /// <summary>
    /// A job schedule that allows recurring jobs by specifying when to run jobs and a specification used to create each job.
    /// </summary>
    public partial class CloudJobSchedule : IRefreshable
    {

#region // CloudJobSchedule
        
        /// <summary>
        /// Commits this <see cref="CloudJobSchedule" /> to the Azure Batch service.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>The commit operation runs asynchronously.</para>
        /// </remarks>
        public async System.Threading.Tasks.Task CommitAsync(
            IEnumerable<BatchClientBehavior> additionalBehaviors = null, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // after this no prop access is allowed
            this.propertyContainer.IsReadOnly = true;

            // craft the behavior manager for this call
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            // fetch props with admin rights so we can make calls, etc.
            
            if (BindingState.Unbound == this.propertyContainer.BindingState)
            {
                // take all property changes and create a job schedule
                Models.JobScheduleAddParameter protoJobSchedule = this.GetTransportObject<Models.JobScheduleAddParameter>();

                System.Threading.Tasks.Task<AzureOperationHeaderResponse<Models.JobScheduleAddHeaders>> asyncTask = 
                    this.parentBatchClient.ProtocolLayer.AddJobSchedule(protoJobSchedule, bhMgr, cancellationToken);

                await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
            }
            else
            {
                Models.JobSpecification jobSpecification = UtilitiesInternal.CreateObjectWithNullCheck(this.JobSpecification, o => o.GetTransportObject());
                Models.Schedule schedule = UtilitiesInternal.CreateObjectWithNullCheck(this.Schedule, o => o.GetTransportObject());
                Models.MetadataItem[] metadata = UtilitiesInternal.ConvertToProtocolArray(this.Metadata);

                System.Threading.Tasks.Task<AzureOperationHeaderResponse<Models.JobScheduleUpdateHeaders>> asyncJobScheduleUpdate = 
                    this.parentBatchClient.ProtocolLayer.UpdateJobSchedule(
                        this.Id,
                        jobSpecification,
                        metadata,
                        schedule,
                        bhMgr,
                        cancellationToken);

                await asyncJobScheduleUpdate.ConfigureAwait(continueOnCapturedContext: false);
            }
        }

        /// <summary>
        /// Commits this <see cref="CloudJobSchedule" /> to the Azure Batch service.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="CommitAsync"/>.</para>
        /// </remarks>
        public void Commit(IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task asyncTask = CommitAsync(additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        /// <summary>
        /// Commits all pending changes to this <see cref="CloudJobSchedule" /> to the Azure Batch service.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>
        /// Updates an existing <see cref="CloudJobSchedule"/> on the Batch service by replacing its properties with the properties of this <see cref="CloudJobSchedule"/> which have been changed.
        /// Unchanged properties are ignored.
        /// All changes since the last time this entity was retrieved from the Batch service (either via <see cref="Refresh"/>, <see cref="JobScheduleOperations.GetJobSchedule"/>,
        /// or <see cref="JobScheduleOperations.ListJobSchedules"/>) are applied.
        /// Properties which are explicitly set to null will cause an exception because the Batch service does not support partial updates which set a property to null.
        /// If you need to set a property to null, use <see cref="Commit"/>.
        /// </para>
        /// <para>This operation runs asynchronously.</para>
        /// </remarks>
        public async System.Threading.Tasks.Task CommitChangesAsync(
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            UtilitiesInternal.ThrowOnUnbound(this.propertyContainer.BindingState);

            // after this no prop access is allowed
            this.propertyContainer.IsReadOnly = true;

            // craft the bahavior manager for this call
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            Models.JobSpecification jobSpecification = this.propertyContainer.JobSpecificationProperty.GetTransportObjectIfChanged<JobSpecification, Models.JobSpecification>();
            Models.Schedule schedule = this.propertyContainer.ScheduleProperty.GetTransportObjectIfChanged<Schedule, Models.Schedule>();
            Models.MetadataItem[] metadata = this.propertyContainer.MetadataProperty.GetTransportObjectIfChanged<MetadataItem, Models.MetadataItem>();

            System.Threading.Tasks.Task asyncJobScheduleUpdate =
                this.parentBatchClient.ProtocolLayer.PatchJobSchedule(
                    this.Id,
                    jobSpecification,
                    metadata,
                    schedule,
                    bhMgr,
                    cancellationToken);

            await asyncJobScheduleUpdate.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Commits all pending changes to this <see cref="CloudJobSchedule" /> to the Azure Batch service.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>
        /// Updates an existing <see cref="CloudJobSchedule"/> on the Batch service by replacing its properties with the properties of this <see cref="CloudJobSchedule"/> which have been changed.
        /// Unchanged properties are ignored.
        /// All changes since the last time this entity was retrieved from the Batch service (either via <see cref="Refresh"/>, <see cref="JobScheduleOperations.GetJobSchedule"/>,
        /// or <see cref="JobScheduleOperations.ListJobSchedules"/>) are applied.
        /// Properties which are explicitly set to null will cause an exception because the Batch service does not support partial updates which set a property to null.
        /// If you need to set a property to null, use <see cref="Commit"/>.
        /// </para>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="CommitChangesAsync"/>.</para>
        /// </remarks>
        public void CommitChanges(IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task asyncTask = this.CommitChangesAsync(additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }


        /// <summary>
        /// Enables this <see cref="CloudJobSchedule" />, allowing jobs to be created according to the <see cref="Schedule"/>.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>The enable operation runs asynchronously.</para>
        /// </remarks>
        public System.Threading.Tasks.Task EnableAsync(IEnumerable<BatchClientBehavior> additionalBehaviors = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // throw if if this object is unbound
            UtilitiesInternal.ThrowOnUnbound(this.propertyContainer.BindingState);

            // craft the behavior manager for this call
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);
            
            // start call
            System.Threading.Tasks.Task asyncTask = this.parentBatchClient.ProtocolLayer.EnableJobSchedule(this.Id, bhMgr, cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Enables this <see cref="CloudJobSchedule" />, allowing jobs to be created according to the <see cref="Schedule"/>.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="EnableAsync"/>.</para>
        /// </remarks>
        public void Enable(IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task asyncTask = EnableAsync(additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        /// <summary>
        /// Disables this <see cref="CloudJobSchedule" />.  Disabled schedules do not create new jobs, but may be re-enabled later.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>The disable operation runs asynchronously.</para>
        /// <para>To re-enable the schedule, call <see cref="EnableAsync"/>.</para>
        /// </remarks>
        public System.Threading.Tasks.Task DisableAsync(IEnumerable<BatchClientBehavior> additionalBehaviors = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // throw if if this object is unbound
            UtilitiesInternal.ThrowOnUnbound(this.propertyContainer.BindingState);

            // craft the behavior manager for this call
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);
            
            // start call
            System.Threading.Tasks.Task asyncTask = this.parentBatchClient.ProtocolLayer.DisableJobSchedule(this.Id, bhMgr, cancellationToken);

            return asyncTask;
        }

        /// <summary>
        /// Disables this <see cref="CloudJobSchedule" />.  Disabled schedules do not create new jobs, but may be re-enabled later.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <remarks>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="DisableAsync"/>.</para>
        /// <para>To re-enable the schedule, call <see cref="Enable"/>.</para>
        /// </remarks>
        public void Disable(IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task asyncTask = DisableAsync(additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        /// <summary>
        /// Deletes this <see cref="CloudJobSchedule" />.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>The delete operation requests that the job schedule be deleted.  The request puts the schedule in the <see cref="Common.JobScheduleState.Deleting"/> state.
        /// The Batch service will delete any existing jobs and tasks under the schedule, including any active job, and perform the actual job schedule deletion without any further client action.</para>
        /// <para>The delete operation runs asynchronously.</para>
        /// </remarks>
        public async System.Threading.Tasks.Task DeleteAsync(IEnumerable<BatchClientBehavior> additionalBehaviors = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // throw if if this object is unbound
            UtilitiesInternal.ThrowOnUnbound(this.propertyContainer.BindingState);

            // craft the behavior manager for this call
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            System.Threading.Tasks.Task asyncTask = this.parentBatchClient.ProtocolLayer.DeleteJobSchedule(this.Id, bhMgr, cancellationToken);

            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Deletes this <see cref="CloudJobSchedule" />.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>The delete operation requests that the job schedule be deleted.  The request puts the schedule in the <see cref="Common.JobScheduleState.Deleting"/> state.
        /// The Batch service will delete any existing jobs and tasks under the schedule, including any active job, and perform the actual job schedule deletion without any further client action.</para>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="DeleteAsync"/>.</para>
        /// </remarks>
        public void Delete(IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task asyncTask = DeleteAsync(additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        /// <summary>
        /// Terminates this <see cref="CloudJobSchedule" />.  Terminated schedules remain in the system but do not create new jobs.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>The terminate operation requests that the job schedule be terminated.  The request puts the schedule in the <see cref="Common.JobScheduleState.Terminating"/> state.
        /// The Batch service will wait for any active job to terminate, and perform the actual job schedule termination without any further client action.</para>
        /// <para>The terminate operation runs asynchronously.</para>
        /// </remarks>
        public async System.Threading.Tasks.Task TerminateAsync(
            IEnumerable<BatchClientBehavior> additionalBehaviors = null, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // throw if if this object is unbound
            UtilitiesInternal.ThrowOnUnbound(this.propertyContainer.BindingState);

            // craft the behavior manager for this call
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            System.Threading.Tasks.Task asyncTask = this.parentBatchClient.ProtocolLayer.TerminateJobSchedule(this.Id, bhMgr, cancellationToken);

            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Terminates this <see cref="CloudJobSchedule" />.  Terminated schedules remain in the system but do not create new jobs.
        /// </summary>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// <para>The terminate operation requests that the job schedule be terminated.  The request puts the schedule in the <see cref="Common.JobScheduleState.Terminating"/> state.
        /// The Batch service will wait for any active job to terminate, and perform the actual job schedule termination without any further client action.</para>
        /// <para>This is a blocking operation. For a non-blocking equivalent, see <see cref="TerminateAsync"/>.</para>
        /// </remarks>
        public void Terminate(IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task asyncTask = TerminateAsync(additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

        /// <summary>
        /// Enumerates the <see cref="CloudJob">jobs</see> created under this <see cref="CloudJobSchedule"/>.
        /// </summary>
        /// <param name="detailLevel">A <see cref="DetailLevel"/> used for filtering the list and for controlling which properties are retrieved from the service.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/> and <paramref name="detailLevel"/>.</param>
        /// <returns>An <see cref="IPagedEnumerable{CloudJob}"/> that can be used to enumerate jobs asynchronously or synchronously.</returns>
        /// <remarks>This method returns immediately; the jobs are retrieved from the Batch service only when the collection is enumerated.
        /// Retrieval is non-atomic; jobs are retrieved in pages during enumeration of the collection.</remarks>
        public IPagedEnumerable<CloudJob> ListJobs(DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            // throw if if this object is unbound
            UtilitiesInternal.ThrowOnUnbound(this.propertyContainer.BindingState);

            // craft the behavior manager for this call
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            IPagedEnumerable<CloudJob> jobs = this.parentBatchClient.JobScheduleOperations.ListJobsImpl(this.Id, bhMgr, detailLevel);

            return jobs;
        }

#endregion // CloudJobSchedule


#region IRefreshable

        /// <summary>
        /// Refreshes the current <see cref="CloudJobSchedule"/>.
        /// </summary>
        /// <param name="detailLevel">The detail level for the refresh.  If a detail level which omits the <see cref="Id"/> property is specified, refresh will fail.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> representing the asynchronous refresh operation.</returns>
        public async System.Threading.Tasks.Task RefreshAsync(
            DetailLevel detailLevel = null, 
            IEnumerable<BatchClientBehavior> additionalBehaviors = null, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // craft the behavior manager for this call
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors, detailLevel);

            // start call
            System.Threading.Tasks.Task<AzureOperationResponse<Models.CloudJobSchedule, Models.JobScheduleGetHeaders>> asyncTask = 
                this.parentBatchClient.ProtocolLayer.GetJobSchedule(this.Id, bhMgr, cancellationToken);

            AzureOperationResponse<Models.CloudJobSchedule, Models.JobScheduleGetHeaders> response = await asyncTask.ConfigureAwait(continueOnCapturedContext: false);

            // get job schedule from response
            Models.CloudJobSchedule newProtocolJobSchedule = response.Body;

            this.propertyContainer = new PropertyContainer(newProtocolJobSchedule);
        }

        /// <summary>
        /// Refreshes the current <see cref="CloudJobSchedule"/>.
        /// </summary>
        /// <param name="detailLevel">The detail level for the refresh.  If a detail level which omits the <see cref="Id"/> property is specified, refresh will fail.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        public void Refresh(DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task asyncTask = RefreshAsync(detailLevel, additionalBehaviors))
            {
                asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
            }
        }

#endregion IRefreshable

    }
}
