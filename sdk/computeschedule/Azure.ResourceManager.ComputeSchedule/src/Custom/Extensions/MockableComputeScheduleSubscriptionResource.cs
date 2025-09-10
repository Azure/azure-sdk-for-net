// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.ComputeSchedule.Models;

namespace Azure.ResourceManager.ComputeSchedule.Mocking
{
    // Add the following overrides to resolve api-compat issue, the locationparameter changed from to string AzureLocation
    public partial class MockableComputeScheduleSubscriptionResource
    {
        /// <summary>
        /// VirtualMachinesSubmitDeallocate: Schedule deallocate operation for a batch of virtual machines at datetime in future.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.ComputeSchedule/locations/{locationparameter}/virtualMachinesSubmitDeallocate</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ScheduledActions_SubmitVirtualMachineDeallocate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-10-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="locationparameter"> The location name. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="locationparameter"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="locationparameter"/> or <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DeallocateResourceOperationResult>> SubmitVirtualMachineDeallocateAsync(string locationparameter, SubmitDeallocateContent content, CancellationToken cancellationToken = default)
            => await SubmitVirtualMachineDeallocateAsync(new AzureLocation(locationparameter), content, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// VirtualMachinesSubmitDeallocate: Schedule deallocate operation for a batch of virtual machines at datetime in future.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.ComputeSchedule/locations/{locationparameter}/virtualMachinesSubmitDeallocate</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ScheduledActions_SubmitVirtualMachineDeallocate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-10-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="locationparameter"> The location name. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="locationparameter"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="locationparameter"/> or <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DeallocateResourceOperationResult> SubmitVirtualMachineDeallocate(string locationparameter, SubmitDeallocateContent content, CancellationToken cancellationToken = default)
            => SubmitVirtualMachineDeallocate(new AzureLocation(locationparameter), content, cancellationToken);

        /// <summary>
        /// VirtualMachinesSubmitStart: Schedule start operation for a batch of virtual machines at datetime in future.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.ComputeSchedule/locations/{locationparameter}/virtualMachinesSubmitStart</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ScheduledActions_SubmitVirtualMachineStart</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-10-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="locationparameter"> The location name. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="locationparameter"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="locationparameter"/> or <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<StartResourceOperationResult>> SubmitVirtualMachineStartAsync(string locationparameter, SubmitStartContent content, CancellationToken cancellationToken = default)
            => await SubmitVirtualMachineStartAsync(new AzureLocation(locationparameter), content, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// VirtualMachinesSubmitStart: Schedule start operation for a batch of virtual machines at datetime in future.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.ComputeSchedule/locations/{locationparameter}/virtualMachinesSubmitStart</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ScheduledActions_SubmitVirtualMachineStart</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-10-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="locationparameter"> The location name. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="locationparameter"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="locationparameter"/> or <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<StartResourceOperationResult> SubmitVirtualMachineStart(string locationparameter, SubmitStartContent content, CancellationToken cancellationToken = default)
            => SubmitVirtualMachineStart(new AzureLocation(locationparameter), content, cancellationToken);

        /// <summary>
        /// VirtualMachinesSubmitHibernate: Schedule hibernate operation for a batch of virtual machines at datetime in future.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.ComputeSchedule/locations/{locationparameter}/virtualMachinesSubmitHibernate</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ScheduledActions_SubmitVirtualMachineHibernate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-10-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="locationparameter"> The location name. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="locationparameter"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="locationparameter"/> or <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<HibernateResourceOperationResult>> SubmitVirtualMachineHibernateAsync(string locationparameter, SubmitHibernateContent content, CancellationToken cancellationToken = default)
            => await SubmitVirtualMachineHibernateAsync(new AzureLocation(locationparameter), content, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// VirtualMachinesSubmitHibernate: Schedule hibernate operation for a batch of virtual machines at datetime in future.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.ComputeSchedule/locations/{locationparameter}/virtualMachinesSubmitHibernate</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ScheduledActions_SubmitVirtualMachineHibernate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-10-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="locationparameter"> The location name. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="locationparameter"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="locationparameter"/> or <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<HibernateResourceOperationResult> SubmitVirtualMachineHibernate(string locationparameter, SubmitHibernateContent content, CancellationToken cancellationToken = default)
            => SubmitVirtualMachineHibernate(new AzureLocation(locationparameter), content, cancellationToken);

        /// <summary>
        /// VirtualMachinesExecuteStart: Execute start operation for a batch of virtual machines, this operation is triggered as soon as Computeschedule receives it.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.ComputeSchedule/locations/{locationparameter}/virtualMachinesExecuteStart</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ScheduledActions_ExecuteVirtualMachineStart</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-10-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="locationparameter"> The location name. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="locationparameter"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="locationparameter"/> or <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<StartResourceOperationResult>> ExecuteVirtualMachineStartAsync(string locationparameter, ExecuteStartContent content, CancellationToken cancellationToken = default)
            => await ExecuteVirtualMachineStartAsync(new AzureLocation(locationparameter), content, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// VirtualMachinesExecuteStart: Execute start operation for a batch of virtual machines, this operation is triggered as soon as Computeschedule receives it.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.ComputeSchedule/locations/{locationparameter}/virtualMachinesExecuteStart</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ScheduledActions_ExecuteVirtualMachineStart</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-10-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="locationparameter"> The location name. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="locationparameter"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="locationparameter"/> or <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<StartResourceOperationResult> ExecuteVirtualMachineStart(string locationparameter, ExecuteStartContent content, CancellationToken cancellationToken = default)
            => ExecuteVirtualMachineStart(new AzureLocation(locationparameter), content, cancellationToken);

        /// <summary>
        /// VirtualMachinesExecuteHibernate: Execute hibernate operation for a batch of virtual machines, this operation is triggered as soon as Computeschedule receives it.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.ComputeSchedule/locations/{locationparameter}/virtualMachinesExecuteHibernate</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ScheduledActions_ExecuteVirtualMachineHibernate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-10-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="locationparameter"> The location name. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="locationparameter"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="locationparameter"/> or <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<HibernateResourceOperationResult>> ExecuteVirtualMachineHibernateAsync(string locationparameter, ExecuteHibernateContent content, CancellationToken cancellationToken = default)
            => await ExecuteVirtualMachineHibernateAsync(new AzureLocation(locationparameter), content, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// VirtualMachinesExecuteHibernate: Execute hibernate operation for a batch of virtual machines, this operation is triggered as soon as Computeschedule receives it.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.ComputeSchedule/locations/{locationparameter}/virtualMachinesExecuteHibernate</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ScheduledActions_ExecuteVirtualMachineHibernate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-10-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="locationparameter"> The location name. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="locationparameter"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="locationparameter"/> or <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<HibernateResourceOperationResult> ExecuteVirtualMachineHibernate(string locationparameter, ExecuteHibernateContent content, CancellationToken cancellationToken = default)
            => ExecuteVirtualMachineHibernate(new AzureLocation(locationparameter), content, cancellationToken);

        /// <summary>
        /// VirtualMachinesGetOperationStatus: Polling endpoint to read status of operations performed on virtual machines
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.ComputeSchedule/locations/{locationparameter}/virtualMachinesGetOperationStatus</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ScheduledActions_GetVirtualMachineOperationStatus</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-10-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="locationparameter"> The location name. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="locationparameter"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="locationparameter"/> or <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<GetOperationStatusResult>> GetVirtualMachineOperationStatusAsync(string locationparameter, GetOperationStatusContent content, CancellationToken cancellationToken = default)
            => await GetVirtualMachineOperationStatusAsync(new AzureLocation(locationparameter), content, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// VirtualMachinesGetOperationStatus: Polling endpoint to read status of operations performed on virtual machines
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.ComputeSchedule/locations/{locationparameter}/virtualMachinesGetOperationStatus</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ScheduledActions_GetVirtualMachineOperationStatus</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-10-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="locationparameter"> The location name. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="locationparameter"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="locationparameter"/> or <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<GetOperationStatusResult> GetVirtualMachineOperationStatus(string locationparameter, GetOperationStatusContent content, CancellationToken cancellationToken = default)
            => GetVirtualMachineOperationStatus(new AzureLocation(locationparameter), content, cancellationToken);

        /// <summary>
        /// VirtualMachinesGetOperationErrors: Get error details on operation errors (like transient errors encountered, additional logs) if they exist.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.ComputeSchedule/locations/{locationparameter}/virtualMachinesGetOperationErrors</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ScheduledActions_GetVirtualMachineOperationErrors</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-10-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="locationparameter"> The location name. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="locationparameter"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="locationparameter"/> or <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<GetOperationErrorsResult>> GetVirtualMachineOperationErrorsAsync(string locationparameter, GetOperationErrorsContent content, CancellationToken cancellationToken = default)
            => await GetVirtualMachineOperationErrorsAsync(new AzureLocation(locationparameter), content, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// VirtualMachinesGetOperationErrors: Get error details on operation errors (like transient errors encountered, additional logs) if they exist.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.ComputeSchedule/locations/{locationparameter}/virtualMachinesGetOperationErrors</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ScheduledActions_GetVirtualMachineOperationErrors</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-10-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="locationparameter"> The location name. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="locationparameter"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="locationparameter"/> or <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<GetOperationErrorsResult> GetVirtualMachineOperationErrors(string locationparameter, GetOperationErrorsContent content, CancellationToken cancellationToken = default)
            => GetVirtualMachineOperationErrors(new AzureLocation(locationparameter), content, cancellationToken);

        /// <summary>
        /// VirtualMachinesExecuteDeallocate: Execute deallocate operation for a batch of virtual machines, this operation is triggered as soon as Computeschedule receives it.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.ComputeSchedule/locations/{locationparameter}/virtualMachinesExecuteDeallocate</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ScheduledActions_ExecuteVirtualMachineDeallocate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-10-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="locationparameter"> The location name. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="locationparameter"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="locationparameter"/> or <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DeallocateResourceOperationResult>> ExecuteVirtualMachineDeallocateAsync(string locationparameter, ExecuteDeallocateContent content, CancellationToken cancellationToken = default)
            => await ExecuteVirtualMachineDeallocateAsync(new AzureLocation(locationparameter), content, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// VirtualMachinesExecuteDeallocate: Execute deallocate operation for a batch of virtual machines, this operation is triggered as soon as Computeschedule receives it.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.ComputeSchedule/locations/{locationparameter}/virtualMachinesExecuteDeallocate</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ScheduledActions_ExecuteVirtualMachineDeallocate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-10-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="locationparameter"> The location name. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="locationparameter"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="locationparameter"/> or <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DeallocateResourceOperationResult> ExecuteVirtualMachineDeallocate(string locationparameter, ExecuteDeallocateContent content, CancellationToken cancellationToken = default)
            => ExecuteVirtualMachineDeallocate(new AzureLocation(locationparameter), content, cancellationToken);

        /// <summary>
        /// VirtualMachinesCancelOperations: Cancel a previously submitted (start/deallocate/hibernate) request
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.ComputeSchedule/locations/{locationparameter}/virtualMachinesCancelOperations</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ScheduledActions_CancelVirtualMachineOperations</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-10-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="locationparameter"> The location name. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="locationparameter"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="locationparameter"/> or <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<CancelOperationsResult>> CancelVirtualMachineOperationsAsync(string locationparameter, CancelOperationsContent content, CancellationToken cancellationToken = default)
            => await CancelVirtualMachineOperationsAsync(new AzureLocation(locationparameter), content, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// VirtualMachinesCancelOperations: Cancel a previously submitted (start/deallocate/hibernate) request
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.ComputeSchedule/locations/{locationparameter}/virtualMachinesCancelOperations</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ScheduledActions_CancelVirtualMachineOperations</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-10-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="locationparameter"> The location name. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="locationparameter"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="locationparameter"/> or <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<CancelOperationsResult> CancelVirtualMachineOperations(string locationparameter, CancelOperationsContent content, CancellationToken cancellationToken = default)
            => CancelVirtualMachineOperations(new AzureLocation(locationparameter), content, cancellationToken);
    }
}
