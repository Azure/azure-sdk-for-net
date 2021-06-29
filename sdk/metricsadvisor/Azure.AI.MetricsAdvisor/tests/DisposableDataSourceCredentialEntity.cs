// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.AI.MetricsAdvisor.Models;

namespace Azure.AI.MetricsAdvisor.Tests
{
    /// <summary>
    /// Represents an <see cref="DataSourceCredentialEntity"/> that has been created for testing purposes.
    /// In order to create a new instance of this class, the <see cref="CreateDataSourceCredentialEntityAsync"/>
    /// static method must be invoked. The created data source credential entity will be deleted upon disposal.
    /// </summary>
    public class DisposableDataSourceCredentialEntity : IAsyncDisposable
    {
        /// <summary>
        /// The client to use for deleting the data source credential entity upon disposal.
        /// </summary>
        private readonly MetricsAdvisorAdministrationClient _adminClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="DisposableDataSourceCredentialEntity"/> class.
        /// </summary>
        /// <param name="adminClient">The client to use for deleting the credential entity upon disposal.</param>
        /// <param name="credential">The data source credential entity this instance is associated with.</param>
        private DisposableDataSourceCredentialEntity(MetricsAdvisorAdministrationClient adminClient, DataSourceCredentialEntity credential)
        {
            _adminClient = adminClient;
            Credential = credential;
        }

        /// <summary>
        /// The data source credential entity this instance is associated with.
        /// </summary>
        public DataSourceCredentialEntity Credential { get; }

        /// <summary>
        /// Creates a data source credential entity using the specified <see cref="MetricsAdvisorAdministrationClient"/>.
        /// A <see cref="DisposableDataSourceCredentialEntity"/> is returned, from which the created credential
        /// can be obtained. Upon disposal, the created credential will be deleted.
        /// </summary>
        /// <param name="adminClient">The client to use for creating and for deleting the data source credential entity.</param>
        /// <param name="credential">Specifies how the created <see cref="DataSourceCredentialEntity"/> should be configured.</param>
        /// <returns>A <see cref="DisposableDataSourceCredentialEntity"/> instance from which the created credential entity can be obtained.</returns>
        public static async Task<DisposableDataSourceCredentialEntity> CreateDataSourceCredentialEntityAsync(MetricsAdvisorAdministrationClient adminClient, DataSourceCredentialEntity credential)
        {
            DataSourceCredentialEntity createdCredential = await adminClient.CreateDataSourceCredentialAsync(credential);
            return new DisposableDataSourceCredentialEntity(adminClient, createdCredential);
        }

        /// <summary>
        /// Creates a data source credential entity using the specified <see cref="MetricsAdvisorAdministrationClient"/>.
        /// A <see cref="DisposableDataSourceCredentialEntity"/> instance is returned, from which the created credential can
        /// be obtained. Except for the name, all of its required properties are initialized with mock values. Upon disposal,
        /// the created credential will be deleted.
        /// </summary>
        /// <param name="adminClient">The client to use for creating and for deleting the data source credential entity.</param>
        /// <param name="name">The name of the data source credential entity to be created.</param>
        /// <param name="authenticationType">Specifies which type of <see cref="DataSourceCredentialEntity"/> should be created.</param>
        /// <returns>A <see cref="DisposableDataSourceCredentialEntity"/> instance from which the created credential can be obtained.</returns>
        public static async Task<DisposableDataSourceCredentialEntity> CreateDataSourceCredentialEntityAsync(MetricsAdvisorAdministrationClient adminClient, string name, string authenticationType)
        {
            DataSourceCredentialEntity credential = authenticationType switch
            {
                "ServicePrincipal" => new DataSourceServicePrincipal(name, "mock", "mock", "mock"),
                "ServicePrincipalInKeyVault" => new DataSourceServicePrincipalInKeyVault(name, new Uri("https://mock.com/"), "mock", "mock", "mock", "mock", "mock"),
                "SharedKey" => new DataSourceDataLakeGen2SharedKey(name, "mock"),
                "SqlConnectionString" => new DataSourceSqlConnectionString(name, "mock"),
                _ => throw new ArgumentOutOfRangeException($"Invalid data source credential type: {authenticationType}")
            };

            return await CreateDataSourceCredentialEntityAsync(adminClient, credential).ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes the data source credential entity this instance is associated with.
        /// </summary>
        public async ValueTask DisposeAsync() => await _adminClient.DeleteDataSourceCredentialAsync(Credential.Id);
    }
}
