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
    /// Represents an <see cref="DataSourceCredentialEntity"/> that has been created for testing purposes.
    /// In order to create a new instance of this class, the <see cref="CreateCredentialEntityAsync"/>
    /// static method must be invoked. The created credential entity will be deleted upon disposal.
    /// </summary>
    public class DisposableCredentialEntity : IAsyncDisposable
    {
        /// <summary>
        /// The client to use for deleting the credential entity upon disposal.
        /// </summary>
        private readonly MetricsAdvisorAdministrationClient _adminClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="DisposableCredentialEntity"/> class.
        /// </summary>
        /// <param name="adminClient">The client to use for deleting the credential entity upon disposal.</param>
        /// <param name="id">The identifier of the credential entity this instance is associated with.</param>
        private DisposableCredentialEntity(MetricsAdvisorAdministrationClient adminClient, string id)
        {
            _adminClient = adminClient;
            Id = id;
        }

        /// <summary>
        /// The identifier of the credential entity this instance is associated with.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Creates a credential entity using the specified <see cref="MetricsAdvisorAdministrationClient"/>.
        /// A <see cref="DataSourceCredentialEntity"/> instance is returned, from which the ID of the created
        /// entity can be obtained. Upon disposal, the associated entity will be deleted.
        /// </summary>
        /// <param name="adminClient">The client to use for creating and for deleting the credential entity.</param>
        /// <param name="credentialEntity">Specifies how the created <see cref="DataSourceCredentialEntity"/> should be configured.</param>
        /// <returns>A <see cref="DisposableCredentialEntity"/> instance from which the ID of the created entity can be obtained.</returns>
        public static async Task<DisposableCredentialEntity> CreateCredentialEntityAsync(MetricsAdvisorAdministrationClient adminClient, DataSourceCredentialEntity credentialEntity)
        {
            DataSourceCredentialEntity createdCredential = await adminClient.CreateCredentialEntityAsync(credentialEntity);

            Assert.That(createdCredential, Is.Not.Null);
            Assert.That(createdCredential.Id, Is.Not.Null.And.Not.Empty);

            return new DisposableCredentialEntity(adminClient, createdCredential.Id);
        }

        /// <summary>
        /// Deletes the credential entity this instance is associated with.
        /// </summary>
        public async ValueTask DisposeAsync() => await _adminClient.DeleteCredentialEntityAsync(Id);
    }
}
