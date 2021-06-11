// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.AI.MetricsAdvisor.Models;

namespace Azure.AI.MetricsAdvisor.Tests
{
    /// <summary>
    /// Represents an <see cref="DatasourceCredential"/> that has been created for testing purposes.
    /// In order to create a new instance of this class, the <see cref="CreateDatasourceCredentialAsync"/>
    /// static method must be invoked. The created datasource credential will be deleted upon disposal.
    /// </summary>
    public class DisposableDatasourceCredential : IAsyncDisposable
    {
        /// <summary>
        /// The client to use for deleting the datasource credential upon disposal.
        /// </summary>
        private readonly MetricsAdvisorAdministrationClient _adminClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="DisposableDatasourceCredential"/> class.
        /// </summary>
        /// <param name="adminClient">The client to use for deleting the credential entity upon disposal.</param>
        /// <param name="credential">The datasource credential this instance is associated with.</param>
        private DisposableDatasourceCredential(MetricsAdvisorAdministrationClient adminClient, DatasourceCredential credential)
        {
            _adminClient = adminClient;
            Credential = credential;
        }

        /// <summary>
        /// The datasource credential this instance is associated with.
        /// </summary>
        public DatasourceCredential Credential { get; }

        /// <summary>
        /// Creates a datasource credential using the specified <see cref="MetricsAdvisorAdministrationClient"/>.
        /// A <see cref="DisposableDatasourceCredential"/> instance is returned, from which the created credential
        /// can be obtained. Upon disposal, the created credential will be deleted.
        /// </summary>
        /// <param name="adminClient">The client to use for creating and for deleting the datasource credential.</param>
        /// <param name="credential">Specifies how the created <see cref="DatasourceCredential"/> should be configured.</param>
        /// <returns>A <see cref="DisposableDatasourceCredential"/> instance from which the created credential can be obtained.</returns>
        public static async Task<DisposableDatasourceCredential> CreateDatasourceCredentialAsync(MetricsAdvisorAdministrationClient adminClient, DatasourceCredential credential)
        {
            DatasourceCredential createdCredential = await adminClient.CreateDatasourceCredentialAsync(credential);
            return new DisposableDatasourceCredential(adminClient, createdCredential);
        }

        /// <summary>
        /// Creates a datasource credential using the specified <see cref="MetricsAdvisorAdministrationClient"/>.
        /// A <see cref="DisposableDatasourceCredential"/> instance is returned, from which the created credential can
        /// be obtained. Except for the name, all of its required properties are initialized with mock values. Upon disposal,
        /// the created credential will be deleted.
        /// </summary>
        /// <param name="adminClient">The client to use for creating and for deleting the datasource credential.</param>
        /// <param name="name">The name of the datasource credential to be created.</param>
        /// <param name="authenticationType">Specifies which type of <see cref="DatasourceCredential"/> should be created.</param>
        /// <returns>A <see cref="DisposableDatasourceCredential"/> instance from which the created credential can be obtained.</returns>
        public static async Task<DisposableDatasourceCredential> CreateDatasourceCredentialAsync(MetricsAdvisorAdministrationClient adminClient, string name, string authenticationType)
        {
            DatasourceCredential credential = authenticationType switch
            {
                "ServicePrincipal" => new ServicePrincipalDatasourceCredential(name, "mock", "mock", "mock"),
                "ServicePrincipalInKeyVault" => new ServicePrincipalInKeyVaultDatasourceCredential(name, new Uri("https://mock.com/"), "mock", "mock", "mock", "mock", "mock"),
                "SharedKey" => new DataLakeGen2SharedKeyDatasourceCredential(name, "mock"),
                "SqlConnectionString" => new SqlConnectionStringDatasourceCredential(name, "mock"),
                _ => throw new ArgumentOutOfRangeException($"Invalid datasource credential type: {authenticationType}")
            };

            return await CreateDatasourceCredentialAsync(adminClient, credential).ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes the datasource credential this instance is associated with.
        /// </summary>
        public async ValueTask DisposeAsync() => await _adminClient.DeleteDatasourceCredentialAsync(Credential.Id);
    }
}
