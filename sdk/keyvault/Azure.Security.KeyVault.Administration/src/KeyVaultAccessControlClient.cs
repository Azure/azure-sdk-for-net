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
        private readonly ClientDiagnostics _diagnostics;
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

            options ??= new KeyVaultAccessControlClientOptions();
            string apiVersion = options.GetVersionString();

            HttpPipeline pipeline = HttpPipelineBuilder.Build(options,
                    new ChallengeBasedAuthenticationPolicy(credential));

            _diagnostics = new ClientDiagnostics(options);
            _definitionsRestClient = new RoleDefinitionsRestClient(_diagnostics, pipeline, apiVersion);
            _assignmentsRestClient = new RoleAssignmentsRestClient(_diagnostics, pipeline, apiVersion);
        }

        /// <summary>
        /// Get all role definitions that are applicable at scope and above.
        /// </summary>
        /// <param name="roleScope"> The scope of the role assignments. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="roleScope"/> is null.</exception>
        public virtual Pageable<RoleDefinition> GetRoleDefinitions(RoleAssignmentScope roleScope, CancellationToken cancellationToken = default)
        {
            return PageableHelpers.CreateEnumerable(_ =>
            {
                using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultAccessControlClient)}.{nameof(GetRoleDefinitions)}");
                scope.Start();
                try
                {
                    var response = _definitionsRestClient.List(vaultBaseUrl: VaultUri.AbsoluteUri, scope: roleScope.ToString(), cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }, (nextLink, _) =>
            {
                using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultAccessControlClient)}.{nameof(GetRoleDefinitions)}");
                scope.Start();
                try
                {
                    var response = _definitionsRestClient.ListNextPage(nextLink: nextLink, vaultBaseUrl: VaultUri.AbsoluteUri, scope: roleScope.ToString(), cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            });
        }

        /// <summary>
        /// Get all role definitions that are applicable at scope and above.
        /// </summary>
        /// <param name="roleScope"> The scope of the role definition. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="roleScope"/> is null.</exception>
        public virtual AsyncPageable<RoleDefinition> GetRoleDefinitionsAsync(RoleAssignmentScope roleScope, CancellationToken cancellationToken = default)
        {
            return PageableHelpers.CreateAsyncEnumerable(async _ =>
            {
                using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultAccessControlClient)}.{nameof(GetRoleDefinitions)}");
                scope.Start();
                try
                {
                    var response = await _definitionsRestClient.ListAsync(vaultBaseUrl: VaultUri.AbsoluteUri, scope: roleScope.ToString(), cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }, async (nextLink, _) =>
            {
                using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultAccessControlClient)}.{nameof(GetRoleDefinitions)}");
                scope.Start();
                try
                {
                    var response = await _definitionsRestClient.ListNextPageAsync(nextLink: nextLink, vaultBaseUrl: VaultUri.AbsoluteUri, scope: roleScope.ToString(), cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            });
        }

        /// <summary>
        /// Gets the <see cref="RoleAssignment"/>s for a scope.
        /// </summary>
        /// <param name="roleScope"> The scope of the role assignments. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="roleScope"/> is null.</exception>
        public virtual Pageable<RoleAssignment> GetRoleAssignments(RoleAssignmentScope roleScope, CancellationToken cancellationToken = default)
        {
            return PageableHelpers.CreateEnumerable(_ =>
            {
                using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultAccessControlClient)}.{nameof(GetRoleAssignments)}");
                scope.Start();
                try
                {
                    var response = _assignmentsRestClient.ListForScope(vaultBaseUrl: VaultUri.AbsoluteUri, scope: roleScope.ToString(), cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }, (nextLink, _) =>
            {
                using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultAccessControlClient)}.{nameof(GetRoleAssignments)}");
                scope.Start();
                try
                {
                    var response = _assignmentsRestClient.ListForScopeNextPage(nextLink: nextLink, vaultBaseUrl: VaultUri.AbsoluteUri, scope: roleScope.ToString(), cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            });
        }

        /// <summary>0
        /// Gets the <see cref="RoleAssignment"/>s for a scope.
        /// </summary>
        /// <param name="roleScope"> The scope of the role assignments. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="roleScope"/> is null.</exception>
        public virtual AsyncPageable<RoleAssignment> GetRoleAssignmentsAsync(RoleAssignmentScope roleScope, CancellationToken cancellationToken = default)
        {
            return PageableHelpers.CreateAsyncEnumerable(async _ =>
            {
                using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultAccessControlClient)}.{nameof(GetRoleAssignments)}");
                scope.Start();
                try
                {
                    var response = await _assignmentsRestClient.ListForScopeAsync(vaultBaseUrl: VaultUri.AbsoluteUri, scope: roleScope.ToString(), cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }, async (nextLink, _) =>
            {
                using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultAccessControlClient)}.{nameof(GetRoleAssignments)}");
                scope.Start();
                try
                {
                    var response = await _assignmentsRestClient.ListForScopeNextPageAsync(nextLink: nextLink, vaultBaseUrl: VaultUri.AbsoluteUri, scope: roleScope.ToString(), cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            });
        }

        /// <summary>
        /// Creates a <see cref="RoleAssignment"/>.
        /// </summary>
        /// <param name="roleScope"> The scope of the role assignment to create. </param>
        /// <param name="properties"> Properties for the role assignment. </param>
        /// <param name="name">The Name used to create the role assignment.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="roleScope"/> or <paramref name="properties"/> is null.</exception>
        public virtual Response<RoleAssignment> CreateRoleAssignment(RoleAssignmentScope roleScope, RoleAssignmentProperties properties, Guid name = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultAccessControlClient)}.{nameof(CreateRoleAssignment)}");
            scope.Start();
            try
            {
                var _name = name == default ? Guid.NewGuid().ToString() : name.ToString();
                return _assignmentsRestClient.Create(VaultUri.AbsoluteUri, roleScope.ToString(), _name, new RoleAssignmentCreateParameters(properties), cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates a <see cref="RoleAssignment"/>.
        /// </summary>
        /// <param name="roleScope"> The scope of the role assignment to create. </param>
        /// <param name="properties"> Properties for the role assignment. </param>
        /// <param name="name">The name used to create the role assignment.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="roleScope"/> or <paramref name="properties"/> is null.</exception>
        public virtual async Task<Response<RoleAssignment>> CreateRoleAssignmentAsync(RoleAssignmentScope roleScope, RoleAssignmentProperties properties, Guid name = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultAccessControlClient)}.{nameof(CreateRoleAssignment)}");
            scope.Start();
            try
            {
                var _name = name == default ? Guid.NewGuid().ToString() : name.ToString();
                return await _assignmentsRestClient.CreateAsync(VaultUri.AbsoluteUri, roleScope.ToString(), _name, new RoleAssignmentCreateParameters(properties), cancellationToken)
                .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Get the specified role assignment.
        /// </summary>
        /// <param name="roleScope"> The scope of the role assignment. </param>
        /// <param name="roleAssignmentName"> The name of the role assignment to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="roleScope"/> or <paramref name="roleAssignmentName"/> is null.</exception>
        public virtual Response<RoleAssignment> GetRoleAssignment(RoleAssignmentScope roleScope, string roleAssignmentName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultAccessControlClient)}.{nameof(GetRoleAssignment)}");
            scope.Start();
            try
            {
                return _assignmentsRestClient.Get(VaultUri.AbsoluteUri, roleScope.ToString(), roleAssignmentName, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Get the specified role assignment.
        /// </summary>
        /// <param name="roleScope"> The scope of the role assignment. </param>
        /// <param name="roleAssignmentName"> The name of the role assignment to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="roleScope"/> or <paramref name="roleAssignmentName"/> is null.</exception>
        public virtual async Task<Response<RoleAssignment>> GetRoleAssignmentAsync(RoleAssignmentScope roleScope, string roleAssignmentName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultAccessControlClient)}.{nameof(GetRoleAssignment)}");
            scope.Start();
            try
            {
                return await _assignmentsRestClient.GetAsync(VaultUri.AbsoluteUri, roleScope.ToString(), roleAssignmentName, cancellationToken)
                .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Delete the specified role assignment.
        /// </summary>
        /// <param name="roleScope"> The scope of the role assignment. </param>
        /// <param name="roleAssignmentName"> The name of the role assignment to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="roleScope"/> or <paramref name="roleAssignmentName"/> is null.</exception>
        public virtual Response<RoleAssignment> DeleteRoleAssignment(RoleAssignmentScope roleScope, string roleAssignmentName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultAccessControlClient)}.{nameof(DeleteRoleAssignment)}");
            scope.Start();
            try
            {
                return _assignmentsRestClient.Delete(VaultUri.AbsoluteUri, roleScope.ToString(), roleAssignmentName, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Delete the specified role assignment.
        /// </summary>
        /// <param name="roleScope"> The scope of the role assignment. </param>
        /// <param name="roleAssignmentName"> The name of the role assignment to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="roleScope"/> or <paramref name="roleAssignmentName"/> is null.</exception>
        public virtual async Task<Response<RoleAssignment>> DeleteRoleAssignmentAsync(RoleAssignmentScope roleScope, string roleAssignmentName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultAccessControlClient)}.{nameof(DeleteRoleAssignment)}");
            scope.Start();
            try
            {
                return await _assignmentsRestClient.DeleteAsync(VaultUri.AbsoluteUri, roleScope.ToString(), roleAssignmentName, cancellationToken)
                .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
