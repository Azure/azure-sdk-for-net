// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.AI.MetricsAdvisor.Models;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    /// <summary>
    /// Represents a <see cref="NotificationHook"/> that has been created for testing purposes. In
    /// order to create a new instance of this class, the <see cref="CreateHookAsync"/> static method
    /// must be invoked. The created hook will be deleted upon disposal.
    /// </summary>
    public class DisposableNotificationHook : IAsyncDisposable
    {
        /// <summary>
        /// The client to use for deleting the hook upon disposal.
        /// </summary>
        private readonly MetricsAdvisorAdministrationClient _adminClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="DisposableNotificationHook"/> class.
        /// </summary>
        /// <param name="adminClient">The client to use for deleting the hook upon disposal.</param>
        /// <param name="id">The identifier of the hook this instance is associated with.</param>
        private DisposableNotificationHook(MetricsAdvisorAdministrationClient adminClient, string id)
        {
            _adminClient = adminClient;
            Id = id;
        }

        /// <summary>
        /// The identifier of the hook this instance is associated with.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Creates a hook using the specified <see cref="MetricsAdvisorAdministrationClient"/>. A
        /// <see cref="DisposableNotificationHook"/> instance is returned, from which the ID of the
        /// created hook can be obtained. Upon disposal, the associated hook will be deleted.
        /// </summary>
        /// <param name="adminClient">The client to use for creating and for deleting the hook.</param>
        /// <param name="hook">Specifies how the created <see cref="NotificationHook"/> should be configured.</param>
        /// <returns>A <see cref="DisposableNotificationHook"/> instance from which the ID of the created hook can be obtained.</returns>
        public static async Task<DisposableNotificationHook> CreateHookAsync(MetricsAdvisorAdministrationClient adminClient, NotificationHook hook)
        {
            string hookId = await adminClient.CreateHookAsync(hook);

            Assert.That(hookId, Is.Not.Null.And.Not.Empty);

            return new DisposableNotificationHook(adminClient, hookId);
        }

        /// <summary>
        /// Deletes the hook this instance is associated with.
        /// </summary>
        public async ValueTask DisposeAsync() => await _adminClient.DeleteHookAsync(Id);
    }
}
