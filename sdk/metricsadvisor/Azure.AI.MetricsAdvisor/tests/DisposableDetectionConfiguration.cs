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
    /// Represents an <see cref="AnomalyDetectionConfiguration"/> that has been created for testing purposes.
    /// In order to create a new instance of this class, the <see cref="CreateDetectionConfigurationAsync"/>
    /// static method must be invoked. The created configuration will be deleted upon disposal.
    /// </summary>
    public class DisposableDetectionConfiguration : IAsyncDisposable
    {
        /// <summary>
        /// The client to use for deleting the configuration upon disposal.
        /// </summary>
        private readonly MetricsAdvisorAdministrationClient _adminClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="DisposableDetectionConfiguration"/> class.
        /// </summary>
        /// <param name="adminClient">The client to use for deleting the configuration upon disposal.</param>
        /// <param name="id">The identifier of the detection configuration this instance is associated with.</param>
        private DisposableDetectionConfiguration(MetricsAdvisorAdministrationClient adminClient, string id)
        {
            _adminClient = adminClient;
            Id = id;
        }

        /// <summary>
        /// The identifier of the detection configuration this instance is associated with.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Creates a detection configuration using the specified <see cref="MetricsAdvisorAdministrationClient"/>.
        /// A <see cref="DisposableDetectionConfiguration"/> instance is returned, from which the ID of the created
        /// configuration can be obtained. Upon disposal, the associated configuration will be deleted.
        /// </summary>
        /// <param name="adminClient">The client to use for creating and for deleting the configuration.</param>
        /// <param name="hook">Specifies how the created <see cref="AnomalyDetectionConfiguration"/> should be configured.</param>
        /// <returns>A <see cref="DisposableDetectionConfiguration"/> instance from which the ID of the created configuration can be obtained.</returns>
        public static async Task<DisposableDetectionConfiguration> CreateDetectionConfigurationAsync(MetricsAdvisorAdministrationClient adminClient, AnomalyDetectionConfiguration detectionConfiguration)
        {
            string configId = await adminClient.CreateDetectionConfigurationAsync(detectionConfiguration);

            Assert.That(configId, Is.Not.Null.And.Not.Empty);

            return new DisposableDetectionConfiguration(adminClient, configId);
        }

        /// <summary>
        /// Deletes the configuration this instance is associated with.
        /// </summary>
        public async ValueTask DisposeAsync() => await _adminClient.DeleteDetectionConfigurationAsync(Id);
    }
}
