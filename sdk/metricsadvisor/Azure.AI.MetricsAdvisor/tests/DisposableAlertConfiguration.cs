// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.AI.MetricsAdvisor.Models;

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
        /// <param name="configuration">The alert configuration this instance is associated with.</param>
        private DisposableAlertConfiguration(MetricsAdvisorAdministrationClient adminClient, AnomalyAlertConfiguration configuration)
        {
            _adminClient = adminClient;
            Configuration = configuration;
        }

        /// <summary>
        /// The alert configuration this instance is associated with.
        /// </summary>
        public AnomalyAlertConfiguration Configuration { get; }

        /// <summary>
        /// Creates an alert configuration using the specified <see cref="MetricsAdvisorAdministrationClient"/>.
        /// A <see cref="DisposableAlertConfiguration"/> instance is returned, from which the created configuration
        /// can be obtained. Upon disposal, the associated configuration will be deleted.
        /// </summary>
        /// <param name="adminClient">The client to use for creating and for deleting the configuration.</param>
        /// <param name="configuration">Specifies how the created <see cref="AnomalyAlertConfiguration"/> should be configured.</param>
        /// <returns>A <see cref="DisposableAlertConfiguration"/> instance from which the created configuration can be obtained.</returns>
        public static async Task<DisposableAlertConfiguration> CreateAlertConfigurationAsync(MetricsAdvisorAdministrationClient adminClient, AnomalyAlertConfiguration alertConfiguration)
        {
            AnomalyAlertConfiguration createdConfig = await adminClient.CreateAlertConfigurationAsync(alertConfiguration);
            return new DisposableAlertConfiguration(adminClient, createdConfig);
        }

        /// <summary>
        /// Deletes the configuration this instance is associated with.
        /// </summary>
        public async ValueTask DisposeAsync() => await _adminClient.DeleteAlertConfigurationAsync(Configuration.Id);
    }
}
