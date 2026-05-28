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

        #region public constructors - all argument need null check

        /// <summary> Initializes a new instance of <see cref="CommunicationIdentityClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        public CommunicationIdentityClient(string connectionString)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                new CommunicationIdentityClientOptions())
        { }

        /// <summary> Initializes a new instance of <see cref="CommunicationIdentityClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public CommunicationIdentityClient(string connectionString, CommunicationIdentityClientOptions options)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                options ?? new CommunicationIdentityClientOptions())
        { }

        /// <summary> Initializes a new instance of <see cref="CommunicationIdentityClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="keyCredential">The <see cref="AzureKeyCredential"/> used to authenticate requests.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public CommunicationIdentityClient(Uri endpoint, AzureKeyCredential keyCredential, CommunicationIdentityClientOptions options = default)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(keyCredential, nameof(keyCredential)),
                options ?? new CommunicationIdentityClientOptions())
        { }

        /// <summary> Initializes a new instance of <see cref="CommunicationIdentityClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="tokenCredential">The <see cref="TokenCredential"/> used to authenticate requests, such as DefaultAzureCredential.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public CommunicationIdentityClient(Uri endpoint, TokenCredential tokenCredential, CommunicationIdentityClientOptions options = default)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(tokenCredential, nameof(tokenCredential)),
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
            RestClient = new CommunicationIdentityRestClient(_clientDiagnostics, httpPipeline, new Uri(endpoint), options.ApiVersion);
        }

        #endregion

        /// <summary>Initializes a new instance of <see cref="CommunicationIdentityClient"/> for mocking.</summary>
        protected CommunicationIdentityClient()
        {
            _clientDiagnostics = null;
            RestClient = null;
        }

        /// <summary>Gets user details. <see cref="CommunicationUserIdentifier"/>.</summary>
        /// <param name="communicationUser">Identifier of the identity. </param>"
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public virtual Response<CommunicationUserDetail> GetUserDetail(CommunicationUserIdentifier communicationUser, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CommunicationIdentityClient)}.{nameof(GetUserDetail)}");
            scope.Start();
            try
            {
                Response<CommunicationIdentity> response = RestClient.Get(communicationUser.Id, cancellationToken: cancellationToken);
                return BuildCommunicationUserDetail(response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>Gets user details. <see cref="CommunicationUserIdentifier"/>.</summary>
        /// <param name="communicationUser">The <see cref="CommunicationUserIdentifier"/> whose tokens should get revoked.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public virtual async Task<Response<CommunicationUserDetail>> GetUserDetailAsync(CommunicationUserIdentifier communicationUser, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CommunicationIdentityClient)}.{nameof(GetUserDetail)}");
            scope.Start();
            try
            {
                Response<CommunicationIdentity> response = await RestClient.GetAsync(communicationUser.Id, cancellationToken: cancellationToken).ConfigureAwait(false);
                return BuildCommunicationUserDetail(response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>Creates a new <see cref="CommunicationUserIdentifier"/>.</summary>
        /// <param name="customId">Custom Id to be associated with the user.</param>"
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public virtual Response<CommunicationUserIdentifier> CreateUser(string customId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CommunicationIdentityClient)}.{nameof(CreateUser)}");
            scope.Start();
            try
            {
                Response<CommunicationUserIdentifierAndToken> response = RestClient.Create(customId, Array.Empty<CommunicationTokenScope>(), cancellationToken: cancellationToken);
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
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public virtual Response<CommunicationUserIdentifier> CreateUser(CancellationToken cancellationToken = default) => CreateUser(default, cancellationToken);

        /// <summary>Asynchronously creates a new <see cref="CommunicationUserIdentifier"/> if the to doesn't exist or get the user otherwise/>.</summary>
        /// <param name="customId">Custom Id to be associated with the user.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public virtual async Task<Response<CommunicationUserIdentifier>> CreateUserAsync(string customId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CommunicationIdentityClient)}.{nameof(CreateUser)}");
            scope.Start();
            try
            {
                Response<CommunicationUserIdentifierAndToken> response = await RestClient.CreateAsync(customId, Array.Empty<CommunicationTokenScope>(), cancellationToken: cancellationToken).ConfigureAwait(false);
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
        public virtual async Task<Response<CommunicationUserIdentifier>> CreateUserAsync(CancellationToken cancellationToken = default) => await CreateUserAsync(default, cancellationToken).ConfigureAwait(false);

        /// <summary>Creates a new <see cref="CommunicationUserIdentifier"/>.</summary>
        /// <param name="customId">Custom Id to be associated with the user.</param>
        /// <param name="scopes">List of <see cref="CommunicationTokenScope"/> scopes for the token.</param>
        /// <param name="tokenExpiresIn">Custom validity period of the token within [1,24] hours range.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public virtual Response<CommunicationUserIdentifierAndToken> CreateUserAndToken(string customId, IEnumerable<CommunicationTokenScope> scopes, TimeSpan tokenExpiresIn, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CommunicationIdentityClient)}.{nameof(CreateUserAndToken)}");
            scope.Start();
            try
            {
                int? expiresIn = GetTokenExpirationInMinutes(tokenExpiresIn, nameof(tokenExpiresIn));

                return RestClient.Create(customId, scopes, expiresIn, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>Creates a new <see cref="CommunicationUserIdentifier"/>.</summary>
        /// <param name="customId">Custom Id to be associated with the user.</param>
        /// <param name="scopes">List of <see cref="CommunicationTokenScope"/> scopes for the token.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public virtual Response<CommunicationUserIdentifierAndToken> CreateUserAndToken(string customId, IEnumerable<CommunicationTokenScope> scopes, CancellationToken cancellationToken = default)
            =>  CreateUserAndToken(customId, scopes, default, cancellationToken);

        /// <summary>Creates a new <see cref="CommunicationUserIdentifier"/>.</summary>
        /// <param name="scopes">List of <see cref="CommunicationTokenScope"/> scopes for the token.</param>
        /// <param name="tokenExpiresIn">Custom validity period of the token within [1,24] hours range.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public virtual Response<CommunicationUserIdentifierAndToken> CreateUserAndToken(IEnumerable<CommunicationTokenScope> scopes, TimeSpan tokenExpiresIn, CancellationToken cancellationToken = default)
            => CreateUserAndToken(default, scopes, tokenExpiresIn, cancellationToken);

        /// <summary>Creates a new <see cref="CommunicationUserIdentifier"/>.</summary>
        /// <param name="scopes">The scopes that the token should have.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public virtual Response<CommunicationUserIdentifierAndToken> CreateUserAndToken(IEnumerable<CommunicationTokenScope> scopes, CancellationToken cancellationToken = default)
            => CreateUserAndToken(scopes, default, cancellationToken);

        /// <summary>Asynchronously creates a new <see cref="CommunicationUserIdentifier"/>.</summary>
        /// <param name="customId">Custom Id to be associated with the user.</param>
        /// <param name="scopes">List of <see cref="CommunicationTokenScope"/> scopes for the token.</param>
        /// <param name="tokenExpiresIn">Custom validity period of the token within [1,24] hours range.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public virtual async Task<Response<CommunicationUserIdentifierAndToken>> CreateUserAndTokenAsync(string customId, IEnumerable<CommunicationTokenScope> scopes, TimeSpan tokenExpiresIn, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CommunicationIdentityClient)}.{nameof(CreateUserAndToken)}");
            scope.Start();
            try
            {
                int? expiresIn = GetTokenExpirationInMinutes(tokenExpiresIn, nameof(tokenExpiresIn));

                return await RestClient.CreateAsync(customId, scopes, expiresIn, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>Asynchronously creates a new <see cref="CommunicationUserIdentifier"/>.</summary>
        /// <param name="customId">Custom Id to be associated with the user.</param>
        /// <param name="scopes">List of <see cref="CommunicationTokenScope"/> scopes for the token.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public virtual async Task<Response<CommunicationUserIdentifierAndToken>> CreateUserAndTokenAsync(string customId, IEnumerable<CommunicationTokenScope> scopes, CancellationToken cancellationToken = default)
            => await CreateUserAndTokenAsync(customId, scopes, default, cancellationToken).ConfigureAwait(false);

        /// <summary>Asynchronously creates a new <see cref="CommunicationUserIdentifier"/>.</summary>
        /// <param name="scopes">List of <see cref="CommunicationTokenScope"/> scopes for the token.</param>
        /// <param name="tokenExpiresIn">Custom validity period of the token within [1,24] hours range.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public virtual async Task<Response<CommunicationUserIdentifierAndToken>> CreateUserAndTokenAsync(IEnumerable<CommunicationTokenScope> scopes, TimeSpan tokenExpiresIn, CancellationToken cancellationToken = default)
            => await CreateUserAndTokenAsync(default, scopes, tokenExpiresIn, cancellationToken).ConfigureAwait(false);

        /// <summary>Asynchronously creates a new <see cref="CommunicationUserIdentifier"/>.</summary>
        /// <param name="scopes">The scopes that the token should have.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public virtual async Task<Response<CommunicationUserIdentifierAndToken>> CreateUserAndTokenAsync(IEnumerable<CommunicationTokenScope> scopes, CancellationToken cancellationToken = default)
            => await CreateUserAndTokenAsync(scopes, default, cancellationToken).ConfigureAwait(false);

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

        /// <summary>Gets a Communication Identity access token for a <see cref="CommunicationUserIdentifier"/>.</summary>
        /// <param name="communicationUser">The <see cref="CommunicationUserIdentifier"/> for whom to get a Communication Identity access token.</param>
        /// <param name="scopes">List of <see cref="CommunicationTokenScope"/> scopes for the token.</param>
        /// <param name="tokenExpiresIn">Custom validity period of the token within [1,24] hours range.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <exception cref="RequestFailedException">The server returned an error.</exception>
        public virtual Response<AccessToken> GetToken(CommunicationUserIdentifier communicationUser, IEnumerable<CommunicationTokenScope> scopes, TimeSpan tokenExpiresIn, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CommunicationIdentityClient)}.{nameof(GetToken)}");
            scope.Start();
            try
            {
                int? expiresIn = GetTokenExpirationInMinutes(tokenExpiresIn, nameof(tokenExpiresIn));

                Response<CommunicationIdentityAccessToken> response = RestClient.IssueAccessToken(communicationUser.Id, scopes, expiresIn, cancellationToken);

                return Response.FromValue(new AccessToken(response.Value.Token, response.Value.ExpiresOn), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>Gets a Communication Identity access token for a <see cref="CommunicationUserIdentifier"/>.</summary>
        /// <param name="communicationUser">The <see cref="CommunicationUserIdentifier"/> for whom to get a Communication Identity access token.</param>
        /// <param name="scopes">List of <see cref="CommunicationTokenScope"/> scopes for the token.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <exception cref="RequestFailedException">The server returned an error.</exception>
        public virtual Response<AccessToken> GetToken(CommunicationUserIdentifier communicationUser, IEnumerable<CommunicationTokenScope> scopes, CancellationToken cancellationToken = default)
        {
            return GetToken(communicationUser, scopes, default, cancellationToken);
        }

        /// <summary>Asynchronously gets a Communication Identity access token for a <see cref="CommunicationUserIdentifier"/>.</summary>
        /// <param name="communicationUser">The <see cref="CommunicationUserIdentifier"/> for whom to get a Communication Identity access token.</param>
        /// <param name="scopes">List of <see cref="CommunicationTokenScope"/> scopes for the token.</param>
        /// <param name="tokenExpiresIn">Custom validity period of the token within [1,24] hours range.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public virtual async Task<Response<AccessToken>> GetTokenAsync(CommunicationUserIdentifier communicationUser, IEnumerable<CommunicationTokenScope> scopes, TimeSpan tokenExpiresIn, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CommunicationIdentityClient)}.{nameof(GetToken)}");
            scope.Start();
            try
            {
                int? expiresIn = GetTokenExpirationInMinutes(tokenExpiresIn, nameof(tokenExpiresIn));

                Response<CommunicationIdentityAccessToken> response = await RestClient.IssueAccessTokenAsync(communicationUser.Id, scopes, expiresIn, cancellationToken).ConfigureAwait(false);

                return Response.FromValue(new AccessToken(response.Value.Token, response.Value.ExpiresOn), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>Asynchronously gets a Communication Identity access token for a <see cref="CommunicationUserIdentifier"/>.</summary>
        /// <param name="communicationUser">The <see cref="CommunicationUserIdentifier"/> for whom to get a Communication Identity access token.</param>
        /// <param name="scopes">List of <see cref="CommunicationTokenScope"/> scopes for the token.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public virtual async Task<Response<AccessToken>> GetTokenAsync(CommunicationUserIdentifier communicationUser, IEnumerable<CommunicationTokenScope> scopes, CancellationToken cancellationToken = default)
        {
            return await GetTokenAsync(communicationUser, scopes, default, cancellationToken).ConfigureAwait(false);
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

        /// <summary>Exchange an Azure AD access token of a Teams User for a Communication Identity access token.</summary>
        /// <param name="options"> <see cref="GetTokenForTeamsUserOptions"/> request options used to exchange an Azure AD access token of a Teams User for a new Communication Identity access token.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <exception cref="RequestFailedException">The server returned an error.</exception>
        public virtual Response<AccessToken> GetTokenForTeamsUser(GetTokenForTeamsUserOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CommunicationIdentityClient)}.{nameof(GetTokenForTeamsUser)}");
            scope.Start();
            try
            {
                Response<CommunicationIdentityAccessToken> response = RestClient.ExchangeTeamsUserAccessToken(options.TeamsUserAadToken, options.ClientId, options.UserObjectId, cancellationToken);
                return Response.FromValue(new AccessToken(response.Value.Token, response.Value.ExpiresOn), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>Asynchronously exchange an Azure AD access token of a Teams User for a Communication Identity access token.</summary>
        /// <param name="options"> <see cref="GetTokenForTeamsUserOptions"/> request options used to exchange an Azure AD access token of a Teams User for a new Communication Identity access token.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public virtual async Task<Response<AccessToken>> GetTokenForTeamsUserAsync(GetTokenForTeamsUserOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CommunicationIdentityClient)}.{nameof(GetTokenForTeamsUser)}");
            scope.Start();
            try
            {
                Response<CommunicationIdentityAccessToken> response = await RestClient.ExchangeTeamsUserAccessTokenAsync(options.TeamsUserAadToken, options.ClientId, options.UserObjectId, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new AccessToken(response.Value.Token, response.Value.ExpiresOn), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private static Response<CommunicationUserDetail> BuildCommunicationUserDetail(Response<CommunicationIdentity> response)
        {
            var customId = response.Value.CustomId;
            var responseId = response.Value.Id;
            var lastTokenIssuedAt = response.Value.LastTokenIssuedAt;

            return Response.FromValue(new CommunicationUserDetail(customId, lastTokenIssuedAt, responseId), response.GetRawResponse());
        }

        private static int? GetTokenExpirationInMinutes(TimeSpan tokenExpiresIn, string paramName)
        {
            try
            {
                return tokenExpiresIn == default ? null : Convert.ToInt32(tokenExpiresIn.TotalMinutes);
            }
            catch (OverflowException ex)
            {
                throw new ArgumentOutOfRangeException($"The {paramName} argument is out of permitted bounds [1,24] hours. Please refer to the documentation and set the value accordingly.", ex);
            }
        }
    }
}
