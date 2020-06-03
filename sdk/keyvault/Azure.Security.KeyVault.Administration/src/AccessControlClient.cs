// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Security.KeyVault;
using Azure.Security.KeyVault.Administration.Models;

namespace Azure.Security.KeyVault.Administration
{
    /// <summary>
    /// The Client.
    /// </summary>
    public class AccessControlClient
    {
        private readonly RoleDefinitionsRestClient _definitionsRestClient;
        private readonly RoleAssignmentsRestClient _assignmentsRestClient;

        /// <summary>
        /// The vault Uri.
        /// </summary>
        /// <value></value>
        public Uri VaultUri { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccessControlClient"/> class for mocking.
        /// </summary>
        protected AccessControlClient()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccessControlClient"/> class for the specified vault.
        /// </summary>
        /// <param name="vaultUri">A <see cref="Uri"/> to the vault on which the client operates. Appears as "DNS Name" in the Azure portal.</param>
        /// <param name="credential">A <see cref="TokenCredential"/> used to authenticate requests to the vault, such as DefaultAzureCredential.</param>
        /// <exception cref="ArgumentNullException"><paramref name="vaultUri"/> or <paramref name="credential"/> is null.</exception>
        public AccessControlClient(Uri vaultUri, TokenCredential credential)
            : this(vaultUri, credential, null)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccessControlClient"/> class for the specified vault.
        /// </summary>
        /// <param name="vaultUri">A <see cref="Uri"/> to the vault on which the client operates. Appears as "DNS Name" in the Azure portal.</param>
        /// <param name="credential">A <see cref="TokenCredential"/> used to authenticate requests to the vault, such as DefaultAzureCredential.</param>
        /// <param name="options"><see cref="AccessControlClientOptions"/> that allow to configure the management of the request sent to Key Vault.</param>
        /// <exception cref="ArgumentNullException"><paramref name="vaultUri"/> or <paramref name="credential"/> is null.</exception>
        public AccessControlClient(Uri vaultUri, TokenCredential credential, AccessControlClientOptions options)
        {
            VaultUri = vaultUri;
            Argument.AssertNotNull(vaultUri, nameof(vaultUri));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new AccessControlClientOptions();
            string apiVersion = options.GetVersionString();

            HttpPipeline pipeline = HttpPipelineBuilder.Build(options,
                    new ChallengeBasedAuthenticationPolicy(credential));

            var diagnostics = new ClientDiagnostics(options);
            _definitionsRestClient = new RoleDefinitionsRestClient(diagnostics, pipeline, apiVersion);
            _assignmentsRestClient = new RoleAssignmentsRestClient(diagnostics, pipeline, apiVersion);
        }

        /// <summary>
        /// Gets a list of <see cref="RoleDefinition"/>.
        /// </summary>
        /// <param name="scope"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Pageable<RoleDefinition> GetRoleDefinitions(Uri scope, CancellationToken cancellationToken = default)
        {
            return PageableHelpers.CreateEnumerable(_ =>
            {
                var response = _definitionsRestClient.List(vaultBaseUrl: VaultUri.AbsoluteUri, scope: scope.AbsoluteUri, cancellationToken: cancellationToken);
                return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
            }, (nextLink, _) =>
            {
                var response = _definitionsRestClient.ListNextPage(nextLink: nextLink, vaultBaseUrl: VaultUri.AbsoluteUri, scope: scope.AbsoluteUri, cancellationToken: cancellationToken);
                return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
            });
        }

        /// <summary>
        /// Gets a list of <see cref="RoleDefinition"/>.
        /// </summary>
        /// <param name="scope"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Pageable<RoleDefinition> GetRoleDefinitions(string scope, CancellationToken cancellationToken = default)
        {
            return PageableHelpers.CreateEnumerable(_ =>
            {
                var response = _definitionsRestClient.List(vaultBaseUrl: VaultUri.AbsoluteUri, scope: scope, cancellationToken: cancellationToken);
                return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
            }, (nextLink, _) =>
            {
                var response = _definitionsRestClient.ListNextPage(nextLink: nextLink, vaultBaseUrl: VaultUri.AbsoluteUri, scope: scope, cancellationToken: cancellationToken);
                return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
            });
        }

        /// <summary>
        /// Gets a list of <see cref="RoleDefinition"/>.
        /// </summary>
        /// <param name="scope"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual AsyncPageable<RoleDefinition> GetRoleDefinitionsAsync(Uri scope, CancellationToken cancellationToken = default)
        {
            return PageableHelpers.CreateAsyncEnumerable(async _ =>
            {
                var response = await _definitionsRestClient.ListAsync(vaultBaseUrl: VaultUri.AbsoluteUri, scope: scope.AbsoluteUri, cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
                return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
            }, async (nextLink, _) =>
            {
                var response = await _definitionsRestClient.ListNextPageAsync(nextLink: nextLink, vaultBaseUrl: VaultUri.AbsoluteUri, scope: scope.AbsoluteUri, cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
                return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
            });
        }

        /// <summary>
        /// Gets a list of <see cref="RoleDefinition"/>.
        /// </summary>
        /// <param name="scope"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual AsyncPageable<RoleDefinition> GetRoleDefinitionsAsync(string scope, CancellationToken cancellationToken = default)
        {
            return PageableHelpers.CreateAsyncEnumerable(async _ =>
            {
                var response = await _definitionsRestClient.ListAsync(vaultBaseUrl: VaultUri.AbsoluteUri, scope: scope, cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
                return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
            }, async (nextLink, _) =>
            {
                var response = await _definitionsRestClient.ListNextPageAsync(nextLink: nextLink, vaultBaseUrl: VaultUri.AbsoluteUri, scope: scope, cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
                return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
            });
        }

        // public virtual Pageable<RoleAssignment> GetRoleAssignments(Uri scope, CancellationToken cancellationToken = default) => null;
        // public virtual Pageable<RoleAssignment> GetRoleAssignments(string scope, CancellationToken cancellationToken = default) => null;
        // public virtual AsyncPageable<RoleAssignment> GetRoleAssignmentsAsync(Uri scope, CancellationToken cancellationToken = default) => null;
        // public virtual AsyncPageable<RoleAssignment> GetRoleAssignmentsAsync(string scope, CancellationToken cancellationToken = default) => null;

        // // The role assignment name will be created automatically. The swagger specification reads, "The name of the role assignment to create. It can be any valid GUID."
        // public virtual Response<RoleAssignment> CreateRoleAssignment(Uri scope, RoleAssignmentProperties properties, CancellationToken cancellationToken = default) => null;
        // public virtual Response<RoleAssignment> CreateRoleAssignment(string scope, RoleAssignmentProperties properties, CancellationToken cancellationToken = default) => null;
        // public virtual Task<Response<RoleAssignment>> CreateRoleAssignmentAsync(Uri scope, RoleAssignmentProperties properties, CancellationToken cancellationToken = default) => null;
        // public virtual Task<Response<RoleAssignment>> CreateRoleAssignmentAsync(string scope, RoleAssignmentProperties properties, CancellationToken cancellationToken = default) => null;

        // public virtual Response<RoleAssignment> GetRoleAssignment(string name, CancellationToken cancellationToken = default) => null;
        // public virtual Task<Response<RoleAssignment>> GetRoleAssignmentAsync(string name, CancellationToken cancellation = default) => null;

        // public virtual Response<RoleAssignment> DeleteRoleAssignment(string name, CancellationToken cancellationToken = default) => null;
        // public virtual Task<Response<RoleAssignment>> DeleteRoleAssignmentAsync(string name, CancellationToken cancellation = default) => null;
    }
}
