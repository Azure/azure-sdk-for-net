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
    /// Represents a <see cref="DataFeed"/> that has been created for testing purposes. In order to
    /// create a new instance of this class, the <see cref="CreateDataFeedAsync"/> static method must
    /// be invoked. The created data feed will be deleted upon disposal.
    /// </summary>
    public class DisposableDataFeed : IAsyncDisposable
    {
        /// <summary>
        /// The client to use for deleting the data feed upon disposal.
        /// </summary>
        private readonly MetricsAdvisorAdministrationClient _adminClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="DisposableDataFeed"/> class.
        /// </summary>
        /// <param name="adminClient">The client to use for deleting the data feed upon disposal.</param>
        /// <param name="id">The identifier of the data feed this instance is associated with.</param>
        private DisposableDataFeed(MetricsAdvisorAdministrationClient adminClient, string id)
        {
            _adminClient = adminClient;
            Id = id;
        }

        /// <summary>
        /// The identifier of the data feed this instance is associated with.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Creates a data feed using the specified <see cref="MetricsAdvisorAdministrationClient"/>.
        /// A <see cref="DisposableDataFeed"/> instance is returned, from which the ID of the created
        /// data feed can be obtained. Upon disposal, the associated data feed will be deleted.
        /// </summary>
        /// <param name="adminClient">The client to use for creating and for deleting the data feed.</param>
        /// <param name="hook">Specifies how the created <see cref="DataFeed"/> should be configured.</param>
        /// <returns>A <see cref="DisposableDataFeed"/> instance from which the ID of the created data feed can be obtained.</returns>
        public static async Task<DisposableDataFeed> CreateDataFeedAsync(MetricsAdvisorAdministrationClient adminClient, DataFeed dataFeed)
        {
            string dataFeedId = await adminClient.CreateDataFeedAsync(dataFeed);

            Assert.That(dataFeedId, Is.Not.Null.And.Not.Empty);

            return new DisposableDataFeed(adminClient, dataFeedId);
        }

        /// <summary>
        /// Deletes the data feed this instance is associated with.
        /// </summary>
        public async ValueTask DisposeAsync() => await _adminClient.DeleteDataFeedAsync(Id);
    }
}
