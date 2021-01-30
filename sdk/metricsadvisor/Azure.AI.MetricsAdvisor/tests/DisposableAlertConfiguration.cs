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
    /// Represents an <see cref="AnomalyAlertConfiguration"/> that has been created for testing purposes.
    /// In order to create a new instance of this class, the <see cref="CreateAlertConfigurationAsync"/>
    /// static method must be invoked. The created configuration will be deleted upon disposal.
    /// </summary>
    public class DisposableAlertConfiguration : IAsyncDisposable
    {
        /// <summary>
        /// The client to use for deleting the configuration upon disposal.
        /// </summary>
        private readonly MetricsAdvisorAdministrationClient _adminClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="DisposableAlertConfiguration"/> class.
        /// </summary>
        /// <param name="adminClient">The client to use for deleting the configuration upon disposal.</param>
        /// <param name="id">The identifier of the alert configuration this instance is associated with.</param>
        private DisposableAlertConfiguration(MetricsAdvisorAdministrationClient adminClient, string id)
        {
            _adminClient = adminClient;
            Id = id;
        }

        /// <summary>
        /// The identifier of the alert configuration this instance is associated with.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Creates an alert configuration using the specified <see cref="MetricsAdvisorAdministrationClient"/>.
        /// A <see cref="DisposableAlertConfiguration"/> instance is returned, from which the ID of the created
        /// configuration can be obtained. Upon disposal, the associated configuration will be deleted.
        /// </summary>
        /// <param name="adminClient">The client to use for creating and for deleting the configuration.</param>
        /// <param name="hook">Specifies how the created <see cref="AnomalyAlertConfiguration"/> should be configured.</param>
        /// <returns>A <see cref="DisposableAlertConfiguration"/> instance from which the ID of the created configuration can be obtained.</returns>
        public static async Task<DisposableAlertConfiguration> CreateAlertConfigurationAsync(MetricsAdvisorAdministrationClient adminClient, AnomalyAlertConfiguration alertConfiguration)
        {
            string configId = await adminClient.CreateAlertConfigurationAsync(alertConfiguration);

            Assert.That(configId, Is.Not.Null.And.Not.Empty);

            return new DisposableAlertConfiguration(adminClient, configId);
        }

        /// <summary>
        /// Deletes the configuration this instance is associated with.
        /// </summary>
        public async ValueTask DisposeAsync() => await _adminClient.DeleteAlertConfigurationAsync(Id);
    }
}
