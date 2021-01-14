// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.MixedReality.Authentication;
using Azure.MixedReality.RemoteRendering.Models;
using Azure.Core;

namespace Azure.MixedReality.RemoteRendering
{
    /// <summary>
    /// The client to use for interacting with the Azure Remote Rendering.
    /// </summary>
    public class RemoteRenderingClient
    {
        private readonly RemoteRenderingAccount _account;

        private readonly Guid _accountId;

        private readonly ClientDiagnostics _clientDiagnostics;

        // TODO Don't think I need to own one of these, since the rest pipeline does already.
        private readonly HttpPipeline _pipeline;

        private readonly MixedRealityRemoteRenderingRestClient _restClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteRenderingClient" /> class.
        /// </summary>
        /// <param name="account">The Azure Remote Rendering account details.</param>
        /// <param name="accessToken">An access token used to access the specified Azure Remote Rendering account.</param>
        /// <param name="options">The options.</param>
        public RemoteRenderingClient(RemoteRenderingAccount account, AccessToken accessToken, RemoteRenderingClientOptions? options = null)
            : this(account, new StaticAccessTokenCredential(accessToken), options) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteRenderingClient" /> class.
        /// </summary>
        /// <param name="account">The Azure Remote Rendering account details.</param>
        /// <param name="keyCredential">The Azure Remote Rendering account primary or secondary key credential.</param>
        /// <param name="options">The options.</param>
        public RemoteRenderingClient(RemoteRenderingAccount account, AzureKeyCredential keyCredential, RemoteRenderingClientOptions? options = null)
            : this(account, new MixedRealityAccountKeyCredential(account.AccountId, keyCredential), options) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteRenderingClient" /> class.
        /// </summary>
        /// <param name="account">The Azure Remote Rendering account details.</param>
        /// <param name="credential">The credential used to access the Mixed Reality service.</param>
        /// <param name="options">The options.</param>
        public RemoteRenderingClient(RemoteRenderingAccount account, TokenCredential credential, RemoteRenderingClientOptions? options = null)
        {
            Argument.AssertNotNull(account, nameof(account));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new RemoteRenderingClientOptions();

            Uri authenticationEndpoint = options.AuthenticationEndpoint ?? AuthenticationEndpoint.ConstructFromDomain(account.AccountDomain);
            TokenCredential mrTokenCredential = MixedRealityTokenCredential.GetMixedRealityCredential(account.AccountId, authenticationEndpoint, credential);
            Uri serviceEndpoint = options.ServiceEndpoint ?? ConstructRemoteRenderingEndpointUrl(account.AccountDomain);

            _account = account;
            // TODO Would be better is account.AccountId _was_ a GUID already.
            _accountId = new System.Guid(account.AccountId);
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(mrTokenCredential, GetDefaultScope(serviceEndpoint)));
            _restClient = new MixedRealityRemoteRenderingRestClient(_clientDiagnostics, _pipeline, serviceEndpoint/*, options.Version*/);
        }

#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

        /// <summary> Initializes a new instance of RemoteRenderingClient for mocking. </summary>
        protected RemoteRenderingClient()
        {
        }

#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

        #region Conversions

        /// <summary>
        /// Creates a conversion using an asset stored in an Azure Blob Storage account.
        /// If the remote rendering account has been linked with the storage account no Shared Access Signatures (storageContainerReadListSas, storageContainerWriteSas) for storage access need to be provided.
        /// Documentation how to link your Azure Remote Rendering account with the Azure Blob Storage account can be found in the [documentation](https://docs.microsoft.com/azure/remote-rendering/how-tos/create-an-account#link-storage-accounts).
        /// All files in the input container starting with the blobPrefix will be retrieved to perform the conversion. To cut down on conversion times only necessary files should be available under the blobPrefix.
        /// .
        /// </summary>
        /// <param name="conversionId"> An ID uniquely identifying the conversion for the given account. The ID is case sensitive, can contain any combination of alphanumeric characters including hyphens and underscores, and cannot contain more than 256 characters. </param>
        /// <param name="settings"> The settings for an asset conversion. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="conversionId"/> or <paramref name="settings"/> is null. </exception>
        public virtual Response<ConversionInformation> CreateConversion(string conversionId, ConversionSettings settings, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RemoteRenderingClient)}.{nameof(CreateConversion)}");
            scope.AddAttribute(nameof(conversionId), conversionId);
            scope.Start();
            try
            {
                var result = _restClient.CreateConversion(_accountId, conversionId, new CreateConversionSettings(settings), cancellationToken);
                return Response.FromValue(result.Value, result.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates a conversion using an asset stored in an Azure Blob Storage account.
        /// If the remote rendering account has been linked with the storage account no Shared Access Signatures (storageContainerReadListSas, storageContainerWriteSas) for storage access need to be provided.
        /// Documentation how to link your Azure Remote Rendering account with the Azure Blob Storage account can be found in the [documentation](https://docs.microsoft.com/azure/remote-rendering/how-tos/create-an-account#link-storage-accounts).
        /// All files in the input container starting with the blobPrefix will be retrieved to perform the conversion. To cut down on conversion times only necessary files should be available under the blobPrefix.
        /// .
        /// </summary>
        /// <param name="conversionId"> An ID uniquely identifying the conversion for the given account. The ID is case sensitive, can contain any combination of alphanumeric characters including hyphens and underscores, and cannot contain more than 256 characters. </param>
        /// <param name="settings"> Request body configuring the settings for an asset conversion. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="conversionId"/> or <paramref name="settings"/> is null. </exception>
        public virtual async Task<Response<ConversionInformation>> CreateConversionAsync(string conversionId, ConversionSettings settings, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RemoteRenderingClient)}.{nameof(CreateConversionAsync)}");
            scope.AddAttribute(nameof(conversionId), conversionId);
            scope.Start();
            try
            {
                var result = await _restClient.CreateConversionAsync(_accountId, conversionId, new CreateConversionSettings(settings), cancellationToken).ConfigureAwait(false);
                return Response.FromValue(result.Value, result.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets the status of a previously created asset conversion. </summary>
        /// <param name="conversionId"> the conversion id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="conversionId"/> is null. </exception>
        public virtual Response<ConversionInformation> GetConversion(string conversionId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RemoteRenderingClient)}.{nameof(GetConversion)}");
            scope.AddAttribute(nameof(conversionId), conversionId);
            scope.Start();
            try
            {
                var result = _restClient.GetConversion(_accountId, conversionId, cancellationToken);
                return Response.FromValue(result.Value, result.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets the status of a previously created asset conversion. </summary>
        /// <param name="conversionId"> the conversion id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="conversionId"/> is null. </exception>
        public virtual async Task<Response<ConversionInformation>> GetConversionAsync(string conversionId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RemoteRenderingClient)}.{nameof(GetConversionAsync)}");
            scope.AddAttribute(nameof(conversionId), conversionId);
            scope.Start();
            try
            {
                var result = await _restClient.GetConversionAsync(_accountId, conversionId, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(result.Value, result.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets a list of all conversions.</summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<ConversionInformation> ListConversions(CancellationToken cancellationToken = default)
        {
            Page<ConversionInformation> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(RemoteRenderingClient)}.{nameof(ListConversions)}");
                scope.Start();
                try
                {
                    var result = _restClient.ListConversions(_accountId, cancellationToken);
                    return Page.FromValues(result.Value.Conversions, result.Value.NextLink, result.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ConversionInformation> NextPageFunc(string? nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(RemoteRenderingClient)}.{nameof(ListConversions)}");
                scope.Start();
                try
                {
                    var result = _restClient.ListConversionsNextPage(nextLink, _accountId, cancellationToken);
                    return Page.FromValues(result.Value.Conversions, result.Value.NextLink, result.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Gets a list of all conversions.</summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<ConversionInformation> ListConversionsAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ConversionInformation>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(RemoteRenderingClient)}.{nameof(ListConversionsAsync)}");
                scope.Start();
                try
                {
                    var result = await _restClient.ListConversionsAsync(_accountId, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(result.Value.Conversions, result.Value.NextLink, result.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ConversionInformation>> NextPageFunc(string? nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(RemoteRenderingClient)}.{nameof(ListConversionsAsync)}");
                scope.Start();
                try
                {
                    var result = await _restClient.ListConversionsNextPageAsync(nextLink, _accountId, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(result.Value.Conversions, result.Value.NextLink, result.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        #endregion
        #region Sessions

        /// <summary> Creates a new rendering session. </summary>
        /// <param name="sessionId"> An ID uniquely identifying the rendering session for the given account. The ID is case sensitive, can contain any combination of alphanumeric characters including hyphens and underscores, and cannot contain more than 256 characters. </param>
        /// <param name="settings"> Settings of the session to be created. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sessionId"/> or <paramref name="settings"/> is null. </exception>
        public virtual Response<SessionProperties> CreateSession(string sessionId, CreateSessionSettings settings, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RemoteRenderingClient)}.{nameof(CreateSession)}");
            scope.AddAttribute(nameof(sessionId), sessionId);
            scope.Start();
            try
            {
                var result = _restClient.CreateSession(_accountId, sessionId, settings, cancellationToken);
                return Response.FromValue(result.Value, result.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates a new rendering session. </summary>
        /// <param name="sessionId"> An ID uniquely identifying the rendering session for the given account. The ID is case sensitive, can contain any combination of alphanumeric characters including hyphens and underscores, and cannot contain more than 256 characters. </param>
        /// <param name="settings"> Settings of the session to be created. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sessionId"/> or <paramref name="settings"/> is null. </exception>
        public virtual async Task<Response<SessionProperties>> CreateSessionAsync(string sessionId, CreateSessionSettings settings, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RemoteRenderingClient)}.{nameof(CreateSessionAsync)}");
            scope.AddAttribute(nameof(sessionId), sessionId);
            scope.Start();
            try
            {
                var result = await _restClient.CreateSessionAsync(_accountId, sessionId, settings, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(result.Value, result.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets properties of a particular rendering session. </summary>
        /// <param name="sessionId"> ID of a previously created session. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sessionId"/> is null. </exception>
        public virtual Response<SessionProperties> GetSession(string sessionId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RemoteRenderingClient)}.{nameof(GetSession)}");
            scope.AddAttribute(nameof(sessionId), sessionId);
            scope.Start();
            try
            {
                var result = _restClient.GetSession(_accountId, sessionId, cancellationToken);
                return Response.FromValue(result.Value, result.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets properties of a particular rendering session. </summary>
        /// <param name="sessionId"> ID of a previously created session. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sessionId"/> is null. </exception>
        public virtual async Task<Response<SessionProperties>> GetSessionAsync(string sessionId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RemoteRenderingClient)}.{nameof(GetSessionAsync)}");
            scope.AddAttribute(nameof(sessionId), sessionId);
            scope.Start();
            try
            {
                var result = await _restClient.GetSessionAsync(_accountId, sessionId, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(result.Value, result.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Updates a particular rendering session. </summary>
        /// <param name="sessionId"> ID of a previously created session. </param>
        /// <param name="body"> Settings of the session to be updated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sessionId"/> or <paramref name="body"/> is null. </exception>
        public virtual Response<SessionProperties> UpdateSession(string sessionId, UpdateSessionBody body, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RemoteRenderingClient)}.{nameof(UpdateSession)}");
            scope.AddAttribute(nameof(sessionId), sessionId);
            scope.Start();
            try
            {
                var result = _restClient.UpdateSession(_accountId, sessionId, body, cancellationToken);
                return Response.FromValue(result.Value, result.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Updates a particular rendering session. </summary>
        /// <param name="sessionId"> ID of a previously created session. </param>
        /// <param name="body"> Settings of the session to be updated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sessionId"/> or <paramref name="body"/> is null. </exception>
        public virtual async Task<Response<SessionProperties>> UpdateSessionAsync(string sessionId, UpdateSessionBody body, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RemoteRenderingClient)}.{nameof(UpdateSessionAsync)}");
            scope.AddAttribute(nameof(sessionId), sessionId);
            scope.Start();
            try
            {
                var result = await _restClient.UpdateSessionAsync(_accountId, sessionId, body, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(result.Value, result.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Stops a particular rendering session. </summary>
        /// <param name="sessionId"> ID of the session to stop. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sessionId"/> is null. </exception>
        public virtual Response StopSession(string sessionId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RemoteRenderingClient)}.{nameof(StopSession)}");
            scope.AddAttribute(nameof(sessionId), sessionId);
            scope.Start();
            try
            {
                return _restClient.StopSession(_accountId, sessionId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Stops a particular rendering session. </summary>
        /// <param name="sessionId"> ID of the session to stop. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sessionId"/> is null. </exception>
        public virtual async Task<Response> StopSessionAsync(string sessionId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RemoteRenderingClient)}.{nameof(StopSessionAsync)}");
            scope.AddAttribute(nameof(sessionId), sessionId);
            scope.Start();

            try
            {
                return await _restClient.StopSessionAsync(_accountId, sessionId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Get a list of all rendering sessions. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<SessionProperties> ListSessions(CancellationToken cancellationToken = default)
        {
            Page<SessionProperties> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(RemoteRenderingClient)}.{nameof(ListSessions)}");
                scope.Start();
                try
                {
                    var result = _restClient.ListSessions(_accountId, cancellationToken);
                    return Page.FromValues(result.Value.Sessions, result.Value.NextLink, result.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SessionProperties> NextPageFunc(string? nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(RemoteRenderingClient)}.{nameof(ListSessions)}");
                scope.Start();
                try
                {
                    var result = _restClient.ListSessionsNextPage(nextLink, _accountId, cancellationToken);
                    return Page.FromValues(result.Value.Sessions, result.Value.NextLink, result.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Get a list of all rendering sessions. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<SessionProperties> ListSessionsAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SessionProperties>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(RemoteRenderingClient)}.{nameof(ListSessionsAsync)}");
                scope.Start();
                try
                {
                    var result = await _restClient.ListSessionsAsync(_accountId, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(result.Value.Sessions, result.Value.NextLink, result.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SessionProperties>> NextPageFunc(string? nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(RemoteRenderingClient)}.{nameof(ListSessionsAsync)}");
                scope.Start();
                try
                {
                    var result = await _restClient.ListSessionsNextPageAsync(nextLink, _accountId, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(result.Value.Sessions, result.Value.NextLink, result.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        #endregion
        #region Private methods

        private static Uri ConstructRemoteRenderingEndpointUrl(string accountDomain)
        {
            Argument.AssertNotNullOrWhiteSpace(accountDomain, nameof(accountDomain));

            if (!Uri.TryCreate($"https://manage.sa.{accountDomain}", UriKind.Absolute, out Uri result))
            {
                throw new ArgumentException("The value could not be used to construct a valid endpoint.", nameof(accountDomain));
            }

            return result;
        }

        private static string GetDefaultScope(Uri uri)
            => $"{uri.GetComponents(UriComponents.SchemeAndServer, UriFormat.SafeUnescaped)}/.default";

        private static string GenerateCv()
            => Convert.ToBase64String(Guid.NewGuid().ToByteArray()).TrimEnd('=');

        #endregion
    }
}
