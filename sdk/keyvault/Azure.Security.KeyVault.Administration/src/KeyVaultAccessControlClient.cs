// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Security.KeyVault.Administration.Models;

namespace Azure.Security.KeyVault.Administration
{
    /// <summary>
    /// The KeyVaultAccessControlClient provides synchronous and asynchronous methods to view and manage Role Based Access for the Azure Key Vault.
    /// The client supports creating, listing, updating, and deleting <see cref="RoleAssignment"/>.
    /// The client also supports listing <see cref="RoleDefinition" />.
    /// </summary>
    public class KeyVaultAccessControlClient
    {
        private readonly RoleDefinitionsRestClient _definitionsRestClient;
        private readonly RoleAssignmentsRestClient _assignmentsRestClient;

        /// <summary>
        /// The vault Uri.
        /// </summary>
        /// <value></value>
        public virtual Uri VaultUri { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyVaultAccessControlClient"/> class for mocking.
        /// </summary>
        protected KeyVaultAccessControlClient()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyVaultAccessControlClient"/> class for the specified vault.
        /// </summary>
        /// <param name="vaultUri">A <see cref="Uri"/> to the vault on which the client operates. Appears as "DNS Name" in the Azure portal.</param>
        /// <param name="credential">A <see cref="TokenCredential"/> used to authenticate requests to the vault, such as DefaultAzureCredential.</param>
        /// <exception cref="ArgumentNullException"><paramref name="vaultUri"/> or <paramref name="credential"/> is null.</exception>
        public KeyVaultAccessControlClient(Uri vaultUri, TokenCredential credential)
            : this(vaultUri, credential, null)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyVaultAccessControlClient"/> class for the specified vault.
        /// </summary>
        /// <param name="vaultUri">A <see cref="Uri"/> to the vault on which the client operates. Appears as "DNS Name" in the Azure portal.</param>
        /// <param name="credential">A <see cref="TokenCredential"/> used to authenticate requests to the vault, such as DefaultAzureCredential.</param>
        /// <param name="options"><see cref="KeyVaultAccessControlClientOptions"/> that allow to configure the management of the request sent to Key Vault.</param>
        /// <exception cref="ArgumentNullException"><paramref name="vaultUri"/> or <paramref name="credential"/> is null.</exception>
        public KeyVaultAccessControlClient(Uri vaultUri, TokenCredential credential, KeyVaultAccessControlClientOptions options)
        {
            Argument.AssertNotNull(vaultUri, nameof(vaultUri));
            Argument.AssertNotNull(credential, nameof(credential));

            VaultUri = vaultUri;
            Argument.AssertNotNull(vaultUri, nameof(vaultUri));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new KeyVaultAccessControlClientOptions();
            string apiVersion = options.GetVersionString();

            HttpPipeline pipeline = HttpPipelineBuilder.Build(options,
                    new ChallengeBasedAuthenticationPolicy(credential));

            var diagnostics = new ClientDiagnostics(options);
            _definitionsRestClient = new RoleDefinitionsRestClient(diagnostics, pipeline, apiVersion);
            _assignmentsRestClient = new RoleAssignmentsRestClient(diagnostics, pipeline, apiVersion);
        }

        /// <summary>
        /// Get all role definitions that are applicable at scope and above.
        /// </summary>
        /// <param name="scope"> The scope of the role assignments. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual Pageable<RoleDefinition> GetRoleDefinitions(RoleAssignmentScope scope, CancellationToken cancellationToken = default)
        {
            return PageableHelpers.CreateEnumerable(_ =>
            {
                var response = _definitionsRestClient.List(vaultBaseUrl: VaultUri.AbsoluteUri, scope: scope.ToString(), cancellationToken: cancellationToken);
                return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
            }, (nextLink, _) =>
            {
                var response = _definitionsRestClient.ListNextPage(nextLink: nextLink, vaultBaseUrl: VaultUri.AbsoluteUri, scope: scope.ToString(), cancellationToken: cancellationToken);
                return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
            });
        }

        /// <summary>
        /// Get all role definitions that are applicable at scope and above.
        /// </summary>
        /// <param name="scope"> The scope of the role definition. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual AsyncPageable<RoleDefinition> GetRoleDefinitionsAsync(RoleAssignmentScope scope, CancellationToken cancellationToken = default)
        {
            return PageableHelpers.CreateAsyncEnumerable(async _ =>
            {
                var response = await _definitionsRestClient.ListAsync(vaultBaseUrl: VaultUri.AbsoluteUri, scope: scope.ToString(), cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
                return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
            }, async (nextLink, _) =>
            {
                var response = await _definitionsRestClient.ListNextPageAsync(nextLink: nextLink, vaultBaseUrl: VaultUri.AbsoluteUri, scope: scope.ToString(), cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
                return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
            });
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="scope"> The scope of the role assignments. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual Pageable<RoleAssignment> GetRoleAssignments(RoleAssignmentScope scope, CancellationToken cancellationToken = default)
        {
            return PageableHelpers.CreateEnumerable(_ =>
            {
                var response = _assignmentsRestClient.ListForScope(vaultBaseUrl: VaultUri.AbsoluteUri, scope: scope.ToString(), cancellationToken: cancellationToken);
                return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
            }, (nextLink, _) =>
            {
                var response = _assignmentsRestClient.ListForScopeNextPage(nextLink: nextLink, vaultBaseUrl: VaultUri.AbsoluteUri, scope: scope.ToString(), cancellationToken: cancellationToken);
                return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
            });
        }

        /// <summary>0
        /// Gets the <see cref="RoleAssignment"/>s for a scope.
        /// </summary>
        /// <param name="scope"> The scope of the role assignments. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual AsyncPageable<RoleAssignment> GetRoleAssignmentsAsync(RoleAssignmentScope scope, CancellationToken cancellationToken = default)
        {
            return PageableHelpers.CreateAsyncEnumerable(async _ =>
            {
                var response = await _assignmentsRestClient.ListForScopeAsync(vaultBaseUrl: VaultUri.AbsoluteUri, scope: scope.ToString(), cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
                return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
            }, async (nextLink, _) =>
            {
                var response = await _assignmentsRestClient.ListForScopeNextPageAsync(nextLink: nextLink, vaultBaseUrl: VaultUri.AbsoluteUri, scope: scope.ToString(), cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
                return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
            });
        }

        /// <summary>
        /// Creates a <see cref="RoleAssignment"/>.
        /// </summary>
        /// <param name="scope"> The scope of the role assignment to create. </param>
        /// <param name="properties"> Properties for the role assignment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual Response<RoleAssignment> CreateRoleAssignment(RoleAssignmentScope scope, RoleAssignmentProperties properties, CancellationToken cancellationToken = default) =>
            _assignmentsRestClient.Create(VaultUri.AbsoluteUri, scope.ToString(), Guid.NewGuid().ToString(), properties, cancellationToken);

        /// <summary>
        /// Creates a <see cref="RoleAssignment"/>.
        /// </summary>
        /// <param name="scope"> The scope of the role assignment to create. </param>
        /// <param name="properties"> Properties for the role assignment. </param>
        /// <param name="name">The Name used to create the role assignment.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual Response<RoleAssignment> CreateRoleAssignment(RoleAssignmentScope scope, RoleAssignmentProperties properties, string name = null, CancellationToken cancellationToken = default) =>
            _assignmentsRestClient.Create(VaultUri.AbsoluteUri, scope.ToString(), name ?? Guid.NewGuid().ToString(), properties, cancellationToken);

        /// <summary>
        /// Creates a <see cref="RoleAssignment"/>.
        /// </summary>
        /// <param name="scope"> The scope of the role assignment to create. </param>
        /// <param name="properties"> Properties for the role assignment. </param>
        /// <param name="name">The name used to create the role assignment.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual async Task<Response<RoleAssignment>> CreateRoleAssignmentAsync(RoleAssignmentScope scope, RoleAssignmentProperties properties, string name = null, CancellationToken cancellationToken = default) =>
            await _assignmentsRestClient.CreateAsync(VaultUri.AbsoluteUri, scope.ToString(), name ?? Guid.NewGuid().ToString(), properties, cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Get the specified role assignment.
        /// </summary>
        /// <param name="scope"> The scope of the role assignment. </param>
        /// <param name="roleAssignmentName"> The name of the role assignment to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual Response<RoleAssignment> GetRoleAssignment(RoleAssignmentScope scope, string roleAssignmentName, CancellationToken cancellationToken = default) =>
            _assignmentsRestClient.Get(VaultUri.AbsoluteUri, scope.ToString(), roleAssignmentName, cancellationToken);

        /// <summary>
        /// Get the specified role assignment.
        /// </summary>
        /// <param name="scope"> The scope of the role assignment. </param>
        /// <param name="roleAssignmentName"> The name of the role assignment to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual async Task<Response<RoleAssignment>> GetRoleAssignmentAsync(RoleAssignmentScope scope, string roleAssignmentName, CancellationToken cancellationToken = default) =>
            await _assignmentsRestClient.GetAsync(VaultUri.AbsoluteUri, scope.ToString(), roleAssignmentName, cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Delete the specified role assignment.
        /// </summary>
        /// <param name="scope"> The scope of the role assignment. </param>
        /// <param name="roleAssignmentName"> The name of the role assignment to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual Response<RoleAssignment> DeleteRoleAssignment(RoleAssignmentScope scope, string roleAssignmentName, CancellationToken cancellationToken = default) =>
            _assignmentsRestClient.Delete(VaultUri.AbsoluteUri, scope.ToString(), roleAssignmentName, cancellationToken);

        /// <summary>
        /// Delete the specified role assignment.
        /// </summary>
        /// <param name="scope"> The scope of the role assignment. </param>
        /// <param name="roleAssignmentName"> The name of the role assignment to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual async Task<Response<RoleAssignment>> DeleteRoleAssignmentAsync(RoleAssignmentScope scope, string roleAssignmentName, CancellationToken cancellationToken = default) =>
            await _assignmentsRestClient.DeleteAsync(VaultUri.AbsoluteUri, scope.ToString(), roleAssignmentName, cancellationToken)
                .ConfigureAwait(false);
    }
}
