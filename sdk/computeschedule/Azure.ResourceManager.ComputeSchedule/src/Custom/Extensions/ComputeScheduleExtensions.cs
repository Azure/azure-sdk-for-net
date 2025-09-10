// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.ComputeSchedule.Mocking;
using Azure.ResourceManager.ComputeSchedule.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.ComputeSchedule
{
    public static partial class ComputeScheduleExtensions
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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableComputeScheduleSubscriptionResource.SubmitVirtualMachineDeallocate(string,SubmitDeallocateContent,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="locationparameter"> The location name. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="locationparameter"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/>, <paramref name="locationparameter"/> or <paramref name="content"/> is null. </exception>
        public static async Task<Response<DeallocateResourceOperationResult>> SubmitVirtualMachineDeallocateAsync(this SubscriptionResource subscriptionResource, string locationparameter, SubmitDeallocateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return await GetMockableComputeScheduleSubscriptionResource(subscriptionResource).SubmitVirtualMachineDeallocateAsync(locationparameter, content, cancellationToken).ConfigureAwait(false);
        }

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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableComputeScheduleSubscriptionResource.SubmitVirtualMachineDeallocate(string,SubmitDeallocateContent,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="locationparameter"> The location name. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="locationparameter"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/>, <paramref name="locationparameter"/> or <paramref name="content"/> is null. </exception>
        public static Response<DeallocateResourceOperationResult> SubmitVirtualMachineDeallocate(this SubscriptionResource subscriptionResource, string locationparameter, SubmitDeallocateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableComputeScheduleSubscriptionResource(subscriptionResource).SubmitVirtualMachineDeallocate(locationparameter, content, cancellationToken);
        }

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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableComputeScheduleSubscriptionResource.SubmitVirtualMachineStart(string,SubmitStartContent,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="locationparameter"> The location name. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="locationparameter"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/>, <paramref name="locationparameter"/> or <paramref name="content"/> is null. </exception>
        public static async Task<Response<StartResourceOperationResult>> SubmitVirtualMachineStartAsync(this SubscriptionResource subscriptionResource, string locationparameter, SubmitStartContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return await GetMockableComputeScheduleSubscriptionResource(subscriptionResource).SubmitVirtualMachineStartAsync(locationparameter, content, cancellationToken).ConfigureAwait(false);
        }

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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableComputeScheduleSubscriptionResource.SubmitVirtualMachineStart(string,SubmitStartContent,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="locationparameter"> The location name. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="locationparameter"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/>, <paramref name="locationparameter"/> or <paramref name="content"/> is null. </exception>
        public static Response<StartResourceOperationResult> SubmitVirtualMachineStart(this SubscriptionResource subscriptionResource, string locationparameter, SubmitStartContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableComputeScheduleSubscriptionResource(subscriptionResource).SubmitVirtualMachineStart(locationparameter, content, cancellationToken);
        }

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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableComputeScheduleSubscriptionResource.SubmitVirtualMachineHibernate(string,SubmitHibernateContent,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="locationparameter"> The location name. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="locationparameter"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/>, <paramref name="locationparameter"/> or <paramref name="content"/> is null. </exception>
        public static async Task<Response<HibernateResourceOperationResult>> SubmitVirtualMachineHibernateAsync(this SubscriptionResource subscriptionResource, string locationparameter, SubmitHibernateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return await GetMockableComputeScheduleSubscriptionResource(subscriptionResource).SubmitVirtualMachineHibernateAsync(locationparameter, content, cancellationToken).ConfigureAwait(false);
        }

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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableComputeScheduleSubscriptionResource.SubmitVirtualMachineHibernate(string,SubmitHibernateContent,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="locationparameter"> The location name. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="locationparameter"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/>, <paramref name="locationparameter"/> or <paramref name="content"/> is null. </exception>
        public static Response<HibernateResourceOperationResult> SubmitVirtualMachineHibernate(this SubscriptionResource subscriptionResource, string locationparameter, SubmitHibernateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableComputeScheduleSubscriptionResource(subscriptionResource).SubmitVirtualMachineHibernate(locationparameter, content, cancellationToken);
        }

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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableComputeScheduleSubscriptionResource.ExecuteVirtualMachineStart(string,ExecuteStartContent,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="locationparameter"> The location name. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="locationparameter"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/>, <paramref name="locationparameter"/> or <paramref name="content"/> is null. </exception>
        public static async Task<Response<StartResourceOperationResult>> ExecuteVirtualMachineStartAsync(this SubscriptionResource subscriptionResource, string locationparameter, ExecuteStartContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return await GetMockableComputeScheduleSubscriptionResource(subscriptionResource).ExecuteVirtualMachineStartAsync(locationparameter, content, cancellationToken).ConfigureAwait(false);
        }

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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableComputeScheduleSubscriptionResource.ExecuteVirtualMachineStart(string,ExecuteStartContent,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="locationparameter"> The location name. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="locationparameter"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/>, <paramref name="locationparameter"/> or <paramref name="content"/> is null. </exception>
        public static Response<StartResourceOperationResult> ExecuteVirtualMachineStart(this SubscriptionResource subscriptionResource, string locationparameter, ExecuteStartContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableComputeScheduleSubscriptionResource(subscriptionResource).ExecuteVirtualMachineStart(locationparameter, content, cancellationToken);
        }

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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableComputeScheduleSubscriptionResource.ExecuteVirtualMachineHibernate(string,ExecuteHibernateContent,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="locationparameter"> The location name. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="locationparameter"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/>, <paramref name="locationparameter"/> or <paramref name="content"/> is null. </exception>
        public static async Task<Response<HibernateResourceOperationResult>> ExecuteVirtualMachineHibernateAsync(this SubscriptionResource subscriptionResource, string locationparameter, ExecuteHibernateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return await GetMockableComputeScheduleSubscriptionResource(subscriptionResource).ExecuteVirtualMachineHibernateAsync(locationparameter, content, cancellationToken).ConfigureAwait(false);
        }

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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableComputeScheduleSubscriptionResource.ExecuteVirtualMachineHibernate(string,ExecuteHibernateContent,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="locationparameter"> The location name. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="locationparameter"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/>, <paramref name="locationparameter"/> or <paramref name="content"/> is null. </exception>
        public static Response<HibernateResourceOperationResult> ExecuteVirtualMachineHibernate(this SubscriptionResource subscriptionResource, string locationparameter, ExecuteHibernateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableComputeScheduleSubscriptionResource(subscriptionResource).ExecuteVirtualMachineHibernate(locationparameter, content, cancellationToken);
        }
    }
}
