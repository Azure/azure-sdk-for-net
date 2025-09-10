// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.ComputeSchedule.Models;

namespace Azure.ResourceManager.ComputeSchedule.Mocking
{
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
        public virtual Response<HibernateResourceOperationResult> ExecuteVirtualMachineHibernate(string locationparameter, ExecuteHibernateContent content, CancellationToken cancellationToken = default)
            => ExecuteVirtualMachineHibernate(new AzureLocation(locationparameter), content, cancellationToken);
    }
}
