// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Identity.Models;
using Azure.Communication.Pipeline;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.Identity
{
    /// <summary>
    /// The Azure Communication Services Identity client.
    /// </summary>
    public class CommunicationIdentityClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        internal CommunicationIdentityRestClient RestClient { get; }
        internal CommunicationIdentityRestClient TurnRestClient { get; }

        #region public constructors - all argument need null check

        /// <summary> Initializes a new instance of <see cref="CommunicationIdentityClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        public CommunicationIdentityClient(string connectionString)
            : this(
                ConnectionString.Parse(AssertNotNullOrEmpty(connectionString, nameof(connectionString))),
                new CommunicationIdentityClientOptions())
        { }

        /// <summary> Initializes a new instance of <see cref="CommunicationIdentityClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public CommunicationIdentityClient(string connectionString, CommunicationIdentityClientOptions options)
            : this(
                ConnectionString.Parse(AssertNotNullOrEmpty(connectionString, nameof(connectionString))),
                options ?? new CommunicationIdentityClientOptions())
        { }

        /// <summary> Initializes a new instance of <see cref="CommunicationIdentityClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="keyCredential">The <see cref="AzureKeyCredential"/> used to authenticate requests.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public CommunicationIdentityClient(Uri endpoint, AzureKeyCredential keyCredential, CommunicationIdentityClientOptions options = default)
            : this(
                AssertNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                AssertNotNull(keyCredential, nameof(keyCredential)),
                options ?? new CommunicationIdentityClientOptions())
        { }

        /// <summary> Initializes a new instance of <see cref="CommunicationIdentityClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="tokenCredential">The <see cref="TokenCredential"/> used to authenticate requests, such as DefaultAzureCredential.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public CommunicationIdentityClient(Uri endpoint, TokenCredential tokenCredential, CommunicationIdentityClientOptions options = default)
            : this(
                AssertNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                AssertNotNull(tokenCredential, nameof(tokenCredential)),
                options ?? new CommunicationIdentityClientOptions())
        { }

        #endregion

        #region private constructors

        private CommunicationIdentityClient(ConnectionString connectionString, CommunicationIdentityClientOptions options)
            : this(connectionString.GetRequired("endpoint"), options.BuildHttpPipeline(connectionString), options)
        { }

        private CommunicationIdentityClient(string endpoint, AzureKeyCredential keyCredential, CommunicationIdentityClientOptions options)
            : this(endpoint, options.BuildHttpPipeline(keyCredential), options)
        { }

        private CommunicationIdentityClient(string endpoint, TokenCredential tokenCredential, CommunicationIdentityClientOptions options)
            : this(endpoint, options.BuildHttpPipeline(tokenCredential), options)
        { }

        private CommunicationIdentityClient(string endpoint, HttpPipeline httpPipeline, CommunicationIdentityClientOptions options)
        {
            _clientDiagnostics = new ClientDiagnostics(options);
            RestClient = new CommunicationIdentityRestClient(_clientDiagnostics, httpPipeline, endpoint, options.ApiVersion);
            TurnRestClient = new CommunicationIdentityRestClient(_clientDiagnostics, httpPipeline, endpoint, "2021-12-12");
        }

        #endregion

        /// <summary>Initializes a new instance of <see cref="CommunicationIdentityClient"/> for mocking.</summary>
        protected CommunicationIdentityClient()
        {
            _clientDiagnostics = null;
            RestClient = null;
            TurnRestClient = null;
        }

        /// <summary>Creates a new <see cref="CommunicationUserIdentifier"/>.</summary>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public virtual Response<CommunicationUserIdentifier> CreateUser(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CommunicationIdentityClient)}.{nameof(CreateUser)}");
            scope.Start();
            try
            {
                Response<CommunicationIdentityAccessTokenResult> response = RestClient.Create(Array.Empty<CommunicationTokenScope>(), cancellationToken);
                var id = response.Value.Identity.Id;
                return Response.FromValue(new CommunicationUserIdentifier(id), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>Asynchronously creates a new <see cref="CommunicationUserIdentifier"/>.</summary>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public virtual async Task<Response<CommunicationUserIdentifier>> CreateUserAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CommunicationIdentityClient)}.{nameof(CreateUser)}");
            scope.Start();
            try
            {
                Response<CommunicationIdentityAccessTokenResult> response = await RestClient.CreateAsync(Array.Empty<CommunicationTokenScope>(), cancellationToken).ConfigureAwait(false);
                var id = response.Value.Identity.Id;
                return Response.FromValue(new CommunicationUserIdentifier(id), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>Creates a new <see cref="CommunicationUserIdentifier"/>.</summary>
        /// <param name="scopes">The scopes that the token should have.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public virtual Response<(CommunicationUserIdentifier user, AccessToken token)>
            CreateUserWithToken(IEnumerable<CommunicationTokenScope> scopes, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CommunicationIdentityClient)}.{nameof(CreateUserWithToken)}");
            scope.Start();
            try
            {
                Response<CommunicationIdentityAccessTokenResult> response = RestClient.Create(scopes, cancellationToken);
                var id = response.Value.Identity.Id;
                CommunicationIdentityAccessToken rawToken = response.Value.AccessToken;
                return Response.FromValue((new CommunicationUserIdentifier(id), new AccessToken(rawToken.Token, rawToken.ExpiresOn)), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>Asynchronously creates a new <see cref="CommunicationUserIdentifier"/>.</summary>
        /// <param name="scopes">The scopes that the token should have.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public virtual async Task<Response<(CommunicationUserIdentifier user, AccessToken token)>>
            CreateUserWithTokenAsync(IEnumerable<CommunicationTokenScope> scopes, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CommunicationIdentityClient)}.{nameof(CreateUserWithToken)}");
            scope.Start();
            try
            {
                Response<CommunicationIdentityAccessTokenResult> response = await RestClient.CreateAsync(scopes, cancellationToken).ConfigureAwait(false);
                var id = response.Value.Identity.Id;
                CommunicationIdentityAccessToken rawToken = response.Value.AccessToken;
                return Response.FromValue((new CommunicationUserIdentifier(id), new AccessToken(rawToken.Token, rawToken.ExpiresOn)), response.GetRawResponse());
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
                return RestClient.Delete(communicationUser.Id, cancellationToken);
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
        public virtual async Task<Response> DeleteUserAsync(CommunicationUserIdentifier communicationUser, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CommunicationIdentityClient)}.{nameof(DeleteUser)}");
            scope.Start();
            try
            {
                return await RestClient.DeleteAsync(communicationUser.Id, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>Gets a token for a <see cref="CommunicationUserIdentifier"/>.</summary>
        /// <param name="communicationUser">The <see cref="CommunicationUserIdentifier"/> for whom to get a token.</param>
        /// <param name="scopes">The scopes that the token should have.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <exception cref="RequestFailedException">The server returned an error.</exception>
        public virtual Response<AccessToken> GetToken(CommunicationUserIdentifier communicationUser, IEnumerable<CommunicationTokenScope> scopes, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CommunicationIdentityClient)}.{nameof(GetToken)}");
            scope.Start();
            try
            {
                Response<CommunicationIdentityAccessToken> response = RestClient.IssueAccessToken(communicationUser.Id, scopes, cancellationToken);
                return Response.FromValue(new AccessToken(response.Value.Token, response.Value.ExpiresOn), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>Asynchronously gets a token for a <see cref="CommunicationUserIdentifier"/>.</summary>
        /// <param name="communicationUser">The <see cref="CommunicationUserIdentifier"/> for whom to get a token.</param>
        /// <param name="scopes">The scopes that the token should have.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public virtual async Task<Response<AccessToken>> GetTokenAsync(CommunicationUserIdentifier communicationUser, IEnumerable<CommunicationTokenScope> scopes, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CommunicationIdentityClient)}.{nameof(GetToken)}");
            scope.Start();
            try
            {
                Response<CommunicationIdentityAccessToken> response = await RestClient.IssueAccessTokenAsync(communicationUser.Id, scopes, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new AccessToken(response.Value.Token, response.Value.ExpiresOn), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>Revokes all the tokens created for a user.</summary>
        /// <param name="communicationUser">The <see cref="CommunicationUserIdentifier"/> whose tokens will be revoked.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <exception cref="RequestFailedException">The server returned an error.</exception>
        public virtual Response RevokeTokens(CommunicationUserIdentifier communicationUser, CancellationToken cancellationToken = default)
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

        /// <summary>Asynchronously revokes all the tokens created for a <see cref="CommunicationUserIdentifier"/>.</summary>
        /// <param name="communicationUser">The <see cref="CommunicationUserIdentifier"/> whose tokens should get revoked.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public virtual async Task<Response> RevokeTokensAsync(CommunicationUserIdentifier communicationUser, CancellationToken cancellationToken = default)
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

        /// <summary>Gets a TURN credential for a <see cref="CommunicationUserIdentifier"/>.</summary>
        /// <param name="communicationUser">The <see cref="CommunicationUserIdentifier"/> for whom to issue a token.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <exception cref="RequestFailedException">The server returned an error.</exception>
        public virtual Response<CommunicationTurnCredentialsResponse> GetTurnCredentials(CommunicationUserIdentifier communicationUser, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CommunicationIdentityClient)}.{nameof(GetTurnCredentials)}");
            scope.Start();
            try
            {
                return TurnRestClient.IssueTurnCredentials(communicationUser.Id, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>Asynchronously gets a TURN credential for a <see cref="CommunicationUserIdentifier"/>.</summary>
        /// <param name="communicationUser">The <see cref="CommunicationUserIdentifier"/> for whom to issue a token.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public virtual async Task<Response<CommunicationTurnCredentialsResponse>> GetTurnCredentialsAsync(CommunicationUserIdentifier communicationUser, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CommunicationIdentityClient)}.{nameof(GetTurnCredentials)}");
            scope.Start();
            try
            {
                return await TurnRestClient.IssueTurnCredentialsAsync(communicationUser.Id, cancellationToken).ConfigureAwait(false);
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

        private static string AssertNotNullOrEmpty(string argument, string argumentName)
        {
            Argument.AssertNotNullOrEmpty(argument, argumentName);
            return argument;
        }
    }
}
