// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.AI.MetricsAdvisor.Models;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class DisposableNotificationHook : IAsyncDisposable
    {
        private readonly MetricsAdvisorAdministrationClient _adminClient;

        private DisposableNotificationHook(MetricsAdvisorAdministrationClient adminClient, string id)
        {
            _adminClient = adminClient;
            Id = id;
        }

        public string Id { get; }

        public static async Task<DisposableNotificationHook> CreateHookAsync(MetricsAdvisorAdministrationClient adminClient, NotificationHook hook)
        {
            string hookId = await adminClient.CreateHookAsync(hook);

            Assert.That(hookId, Is.Not.Null.And.Not.Empty);

            return new DisposableNotificationHook(adminClient, hookId);
        }

        public async ValueTask DisposeAsync() => await _adminClient.DeleteHookAsync(Id);
    }
}
