// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Administration.Models;
using Azure.Communication.Pipeline;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.Administration
{
    /// <summary>
    /// The Azure Communication Services Identity client.
    /// </summary>
    public class CommunicationIdentityClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        internal InternalCommunicationIdentityRestClient RestClient { get; }

        /// <summary> Initializes a new instance of <see cref="CommunicationIdentityClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public CommunicationIdentityClient(string connectionString, CommunicationIdentityClientOptions? options = default)
            : this(
                  options ?? new CommunicationIdentityClientOptions(),
                  ConnectionString.Parse(AssertNotNull(connectionString, nameof(connectionString))))
        { }

        private CommunicationIdentityClient(CommunicationIdentityClientOptions options, ConnectionString connectionString)
        {
            _clientDiagnostics = new ClientDiagnostics(options);
            RestClient = new InternalCommunicationIdentityRestClient(
                _clientDiagnostics,
                options.BuildHttpPipline(connectionString),
                connectionString.GetRequired("endpoint"));
        }

        /// <summary>Initializes a new instance of <see cref="CommunicationIdentityClient"/> for mocking.</summary>
        protected CommunicationIdentityClient()
        {
            _clientDiagnostics = null!;
            RestClient = null!;
        }

        /// <summary>Asynchronously creates a new <see cref="CommunicationUserIdentifier"/>.</summary>
        /// <param name="scopes">The scopes that the access token should have.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public virtual async Task<Response<CommunicationUserIdentifier>> CreateUserAsync(IEnumerable<CommunicationIdentityTokenScope> scopes, CancellationToken cancellationToken = default)
        {
            await Task.Yield();
            throw new NotImplementedException();
        }

        /// <summary>Asynchronously creates a new <see cref="CommunicationUserIdentifier"/>.</summary>
        /// <param name="scopes">The scopes that the access token should have.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public virtual Response<CommunicationUserIdentifier> CreateUser(IEnumerable<CommunicationIdentityTokenScope> scopes, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>Asynchronously deletes a <see cref="CommunicationUserIdentifier"/>, revokes its tokens and deletes its data.</summary>
        /// <param name="communicationUser"> The user to be deleted.</param>
        /// <param name="cancellationToken"> The cancellation token to use.</param>
        public virtual async Task<Response> DeleteUserAsync(CommunicationUserIdentifier communicationUser, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CommunicationIdentityClient)}.{nameof(DeleteUser)}");
            scope.Start();
            try
            {
                return await RestClient.DeleteIdentityAsync(communicationUser.Id, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>Asynchronously deletes a <see cref="CommunicationUserIdentifier"/>, revokes its tokens and deletes its data.</summary>
        /// <param name="communicationUser"> The user to be deleted.</param>
        /// <param name="cancellationToken"> The cancellation token to use.</param>
        /// <exception cref="RequestFailedException">The server returned an error.</exception>
        public virtual Response DeleteUser(CommunicationUserIdentifier communicationUser, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CommunicationIdentityClient)}.{nameof(DeleteUser)}");
            scope.Start();
            try
            {
                return RestClient.DeleteIdentity(communicationUser.Id, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>Asynchronously revokes all the access tokens created for a <see cref="CommunicationUserIdentifier"/>.</summary>
        /// <param name="communicationUser">The <see cref="CommunicationUserIdentifier"/> whose tokens should get revoked.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public virtual async Task<Response> RevokeAccessTokensAsync(CommunicationUserIdentifier communicationUser, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CommunicationIdentityClient)}.{nameof(RevokeTokens)}");
            scope.Start();
            try
            {
                return await RestClient.RevokeAccessTokensAsync(communicationUser.Id, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>Revokes all the access tokens created for a user.</summary>
        /// <param name="communicationUser">The <see cref="CommunicationUserIdentifier"/> whose tokens will be revoked.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <exception cref="RequestFailedException">The server returned an error.</exception>
        public virtual Response RevokeAccessTokens(CommunicationUserIdentifier communicationUser, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CommunicationIdentityClient)}.{nameof(RevokeTokens)}");
            scope.Start();
            try
            {
                return RestClient.RevokeAccessTokens(communicationUser.Id, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>Asynchronously issues an access token for a <see cref="CommunicationUserIdentifier"/>.</summary>
        /// <param name="communicationUser">The <see cref="CommunicationUserIdentifier"/> for whom to issue a token.</param>
        /// <param name="scopes">The scopes that the access token should have.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public virtual async Task<Response<CommunicationIdentityAccessToken>> IssueAccessTokenAsync(CommunicationUserIdentifier communicationUser, IEnumerable<CommunicationIdentityTokenScope> scopes, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CommunicationIdentityClient)}.{nameof(IssueToken)}");
            scope.Start();
            try
            {
                return await RestClient.IssueAccessTokenAsync(communicationUser.Id, scopes, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>Issues an access token for a <see cref="CommunicationUserIdentifier"/>.</summary>
        /// <param name="communicationUser">The <see cref="CommunicationUserIdentifier"/> for whom to issue a token.</param>
        /// <param name="scopes">The scopes that the token should have.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <exception cref="RequestFailedException">The server returned an error.</exception>
        public virtual Response<CommunicationIdentityAccessToken> IssueAccessToken(CommunicationUserIdentifier communicationUser, IEnumerable<CommunicationIdentityTokenScope> scopes, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CommunicationIdentityClient)}.{nameof(IssueToken)}");
            scope.Start();
            try
            {
                return RestClient.IssueAccessToken(communicationUser.Id, scopes, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private static T AssertNotNull<T>(T argument, string argumentName)
            where T : class
        {
            Argument.AssertNotNull(argument, argumentName);
            return argument;
        }
    }
}
