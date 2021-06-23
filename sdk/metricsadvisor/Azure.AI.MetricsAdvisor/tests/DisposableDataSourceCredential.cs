// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.AI.MetricsAdvisor.Models;

namespace Azure.AI.MetricsAdvisor.Tests
{
    /// <summary>
    /// Represents an <see cref="DataSourceCredential"/> that has been created for testing purposes.
    /// In order to create a new instance of this class, the <see cref="CreateDataSourceCredentialAsync"/>
    /// static method must be invoked. The created data source credential will be deleted upon disposal.
    /// </summary>
    public class DisposableDataSourceCredential : IAsyncDisposable
    {
        /// <summary>
        /// The client to use for deleting the data source credential upon disposal.
        /// </summary>
        private readonly MetricsAdvisorAdministrationClient _adminClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="DisposableDataSourceCredential"/> class.
        /// </summary>
        /// <param name="adminClient">The client to use for deleting the credential entity upon disposal.</param>
        /// <param name="credential">The data source credential this instance is associated with.</param>
        private DisposableDataSourceCredential(MetricsAdvisorAdministrationClient adminClient, DataSourceCredential credential)
        {
            _adminClient = adminClient;
            Credential = credential;
        }

        /// <summary>
        /// The data source credential this instance is associated with.
        /// </summary>
        public DataSourceCredential Credential { get; }

        /// <summary>
        /// Creates a data source credential using the specified <see cref="MetricsAdvisorAdministrationClient"/>.
        /// A <see cref="DisposableDataSourceCredential"/> instance is returned, from which the created credential
        /// can be obtained. Upon disposal, the created credential will be deleted.
        /// </summary>
        /// <param name="adminClient">The client to use for creating and for deleting the data source credential.</param>
        /// <param name="credential">Specifies how the created <see cref="DataSourceCredential"/> should be configured.</param>
        /// <returns>A <see cref="DisposableDataSourceCredential"/> instance from which the created credential can be obtained.</returns>
        public static async Task<DisposableDataSourceCredential> CreateDataSourceCredentialAsync(MetricsAdvisorAdministrationClient adminClient, DataSourceCredential credential)
        {
            DataSourceCredential createdCredential = await adminClient.CreateDataSourceCredentialAsync(credential);
            return new DisposableDataSourceCredential(adminClient, createdCredential);
        }

        /// <summary>
        /// Creates a data source credential using the specified <see cref="MetricsAdvisorAdministrationClient"/>.
        /// A <see cref="DisposableDataSourceCredential"/> instance is returned, from which the created credential can
        /// be obtained. Except for the name, all of its required properties are initialized with mock values. Upon disposal,
        /// the created credential will be deleted.
        /// </summary>
        /// <param name="adminClient">The client to use for creating and for deleting the data source credential.</param>
        /// <param name="name">The name of the data source credential to be created.</param>
        /// <param name="authenticationType">Specifies which type of <see cref="DataSourceCredential"/> should be created.</param>
        /// <returns>A <see cref="DisposableDataSourceCredential"/> instance from which the created credential can be obtained.</returns>
        public static async Task<DisposableDataSourceCredential> CreateDataSourceCredentialAsync(MetricsAdvisorAdministrationClient adminClient, string name, string authenticationType)
        {
            DataSourceCredential credential = authenticationType switch
            {
                "ServicePrincipal" => new ServicePrincipalDataSourceCredential(name, "mock", "mock", "mock"),
                "ServicePrincipalInKeyVault" => new ServicePrincipalInKeyVaultDataSourceCredential(name, new Uri("https://mock.com/"), "mock", "mock", "mock", "mock", "mock"),
                "SharedKey" => new DataLakeGen2SharedKeyDataSourceCredential(name, "mock"),
                "SqlConnectionString" => new SqlConnectionStringDataSourceCredential(name, "mock"),
                _ => throw new ArgumentOutOfRangeException($"Invalid data source credential type: {authenticationType}")
            };

            return await CreateDataSourceCredentialAsync(adminClient, credential).ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes the data source credential this instance is associated with.
        /// </summary>
        public async ValueTask DisposeAsync() => await _adminClient.DeleteDataSourceCredentialAsync(Credential.Id);
    }
}
