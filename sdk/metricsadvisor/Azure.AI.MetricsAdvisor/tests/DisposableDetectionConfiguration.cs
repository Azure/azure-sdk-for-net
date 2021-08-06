// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.AI.MetricsAdvisor.Models;

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
        /// <param name="configuration">The detection configuration this instance is associated with.</param>
        private DisposableDetectionConfiguration(MetricsAdvisorAdministrationClient adminClient, AnomalyDetectionConfiguration configuration)
        {
            _adminClient = adminClient;
            Configuration = configuration;
        }

        /// <summary>
        /// The detection configuration this instance is associated with.
        /// </summary>
        public AnomalyDetectionConfiguration Configuration { get; }

        /// <summary>
        /// Creates a detection configuration using the specified <see cref="MetricsAdvisorAdministrationClient"/>.
        /// A <see cref="DisposableDetectionConfiguration"/> instance is returned, from which the created configuration
        /// can be obtained. Upon disposal, the associated configuration will be deleted.
        /// </summary>
        /// <param name="adminClient">The client to use for creating and for deleting the configuration.</param>
        /// <param name="configuration">Specifies how the created <see cref="AnomalyDetectionConfiguration"/> should be configured.</param>
        /// <returns>A <see cref="DisposableDetectionConfiguration"/> instance from which the created configuration can be obtained.</returns>
        public static async Task<DisposableDetectionConfiguration> CreateDetectionConfigurationAsync(MetricsAdvisorAdministrationClient adminClient, AnomalyDetectionConfiguration configuration)
        {
            AnomalyDetectionConfiguration createdConfig = await adminClient.CreateDetectionConfigurationAsync(configuration);
            return new DisposableDetectionConfiguration(adminClient, createdConfig);
        }

        /// <summary>
        /// Deletes the configuration this instance is associated with.
        /// </summary>
        public async ValueTask DisposeAsync() => await _adminClient.DeleteDetectionConfigurationAsync(Configuration.Id);
    }
}
