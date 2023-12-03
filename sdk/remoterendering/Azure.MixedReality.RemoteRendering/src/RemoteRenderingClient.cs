// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.MixedReality.Authentication;
using Azure.Core;

namespace Azure.MixedReality.RemoteRendering
{
    /// <summary>
    /// The client to use for interacting with the Azure Remote Rendering.
    /// </summary>
    public class RemoteRenderingClient
    {
        private const string OTelConversionIdKey = "az.remoterendering.conversion.id";
        private const string OTelSessionIdKey = "az.remoterendering.session.id";
        private readonly Guid _accountId;

        private readonly ClientDiagnostics _clientDiagnostics;

        private readonly HttpPipeline _pipeline;

        private readonly RemoteRenderingRestClient _restClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteRenderingClient" /> class.
        /// </summary>
        /// <param name="remoteRenderingEndpoint">The rendering service endpoint. This determines the region in which the rendering VM is created.</param>
        /// <param name="accountId">The Azure Remote Rendering account identifier.</param>
        /// <param name="accountDomain">The Azure Remote Rendering account domain.</param>
        /// <param name="keyCredential">The Azure Remote Rendering account primary or secondary key credential.</param>
        public RemoteRenderingClient(Uri remoteRenderingEndpoint, Guid accountId, string accountDomain, AzureKeyCredential keyCredential)
            : this(remoteRenderingEndpoint, accountId, accountDomain, new MixedRealityAccountKeyCredential(accountId, keyCredential), null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteRenderingClient" /> class.
        /// </summary>
        /// <param name="remoteRenderingEndpoint">The rendering service endpoint. This determines the region in which the rendering VM is created.</param>
        /// <param name="accountId">The Azure Remote Rendering account identifier.</param>
        /// <param name="accountDomain">The Azure Remote Rendering account domain.</param>
        /// <param name="keyCredential">The Azure Remote Rendering account primary or secondary key credential.</param>
        /// <param name="options">The options.</param>
        public RemoteRenderingClient(Uri remoteRenderingEndpoint, Guid accountId, string accountDomain, AzureKeyCredential keyCredential, RemoteRenderingClientOptions options)
            : this(remoteRenderingEndpoint, accountId, accountDomain, new MixedRealityAccountKeyCredential(accountId, keyCredential), options) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteRenderingClient" /> class.
        /// </summary>
        /// <param name="remoteRenderingEndpoint">The rendering service endpoint. This determines the region in which the rendering VM is created.</param>
        /// <param name="accountId">The Azure Remote Rendering account identifier.</param>
        /// <param name="accountDomain">The Azure Remote Rendering account domain.</param>
        /// <param name="accessToken">An access token used to access the specified Azure Remote Rendering account.</param>
        /// <param name="options">The options.</param>
        public RemoteRenderingClient(Uri remoteRenderingEndpoint, Guid accountId, string accountDomain, AccessToken accessToken, RemoteRenderingClientOptions options = null)
            : this(remoteRenderingEndpoint, accountId, accountDomain, new StaticAccessTokenCredential(accessToken), options) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteRenderingClient" /> class.
        /// </summary>
        /// <param name="remoteRenderingEndpoint">The rendering service endpoint. This determines the region in which the rendering VM is created.</param>
        /// <param name="accountId">The Azure Remote Rendering account identifier.</param>
        /// <param name="accountDomain">The Azure Remote Rendering account domain.</param>
        /// <param name="credential">The credential used to access the Mixed Reality service.</param>
        /// <param name="options">The options.</param>
        public RemoteRenderingClient(Uri remoteRenderingEndpoint, Guid accountId, string accountDomain, TokenCredential credential, RemoteRenderingClientOptions options = null)
        {
            Argument.AssertNotDefault(ref accountId, nameof(accountId));
            Argument.AssertNotNullOrWhiteSpace(accountDomain, nameof(accountDomain));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new RemoteRenderingClientOptions();

            Uri authenticationEndpoint = options.AuthenticationEndpoint ?? AuthenticationEndpoint.ConstructFromDomain(accountDomain);
            TokenCredential mrTokenCredential = MixedRealityTokenCredential.GetMixedRealityCredential(accountId, authenticationEndpoint, credential);

            _accountId = accountId;
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(mrTokenCredential, GetDefaultScope(remoteRenderingEndpoint)));
            _restClient = new RemoteRenderingRestClient(_clientDiagnostics, _pipeline, remoteRenderingEndpoint.ToString(), options.Version);
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
        /// <param name="options"> The settings for an asset conversion. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="conversionId"/> or <paramref name="options"/> is null. </exception>
        public virtual AssetConversionOperation StartConversion(string conversionId, AssetConversionOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RemoteRenderingClient)}.{nameof(StartConversion)}");
            scope.AddAttribute(OTelConversionIdKey, conversionId);
            scope.Start();
            try
            {
                var result = _restClient.CreateConversion(_accountId, conversionId, new CreateConversionSettings(options), cancellationToken);
                return new AssetConversionOperation(this, result);
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
        /// <param name="options"> Request body configuring the settings for an asset conversion. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="conversionId"/> or <paramref name="options"/> is null. </exception>
        public virtual async Task<AssetConversionOperation> StartConversionAsync(string conversionId, AssetConversionOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RemoteRenderingClient)}.{nameof(StartConversion)}");
            scope.AddAttribute(OTelConversionIdKey, conversionId);
            scope.Start();
            try
            {
                var result = await _restClient.CreateConversionAsync(_accountId, conversionId, new CreateConversionSettings(options), cancellationToken).ConfigureAwait(false);
                return new AssetConversionOperation(this, result);
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
        public virtual Response<AssetConversion> GetConversion(string conversionId, CancellationToken cancellationToken = default)
        {
            return GetConversionInternal(conversionId, $"{nameof(RemoteRenderingClient)}.{nameof(GetConversion)}", cancellationToken);
        }

        /// <summary> Gets the status of a previously created asset conversion. </summary>
        /// <param name="conversionId"> the conversion id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="conversionId"/> is null. </exception>
        public virtual async Task<Response<AssetConversion>> GetConversionAsync(string conversionId, CancellationToken cancellationToken = default)
        {
            return await GetConversionInternalAsync(conversionId, $"{nameof(RemoteRenderingClient)}.{nameof(GetConversion)}", cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a list of all conversions.</summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<AssetConversion> GetConversions(CancellationToken cancellationToken = default)
        {
            Page<AssetConversion> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(RemoteRenderingClient)}.{nameof(GetConversions)}");
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
            Page<AssetConversion> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(RemoteRenderingClient)}.{nameof(GetConversions)}");
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
        public virtual AsyncPageable<AssetConversion> GetConversionsAync(CancellationToken cancellationToken = default)
        {
            async Task<Page<AssetConversion>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(RemoteRenderingClient)}.{nameof(GetConversionsAync)}");
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
            async Task<Page<AssetConversion>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(RemoteRenderingClient)}.{nameof(GetConversionsAync)}");
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
        /// <param name="options"> Options of session to be created. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sessionId"/> or <paramref name="options"/> is null. </exception>
        public virtual StartRenderingSessionOperation StartSession(string sessionId, RenderingSessionOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RemoteRenderingClient)}.{nameof(StartSession)}");
            scope.AddAttribute(OTelSessionIdKey, sessionId);
            scope.Start();
            try
            {
                var result = _restClient.CreateSession(_accountId, sessionId, options, cancellationToken);
                return new StartRenderingSessionOperation(this, Response.FromValue(result.Value, result.GetRawResponse()));
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates a new rendering session. </summary>
        /// <param name="sessionId"> An ID uniquely identifying the rendering session for the given account. The ID is case sensitive, can contain any combination of alphanumeric characters including hyphens and underscores, and cannot contain more than 256 characters. </param>
        /// <param name="options"> Options of the session to be created. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sessionId"/> or <paramref name="options"/> is null. </exception>
        public virtual async Task<StartRenderingSessionOperation> StartSessionAsync(string sessionId, RenderingSessionOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RemoteRenderingClient)}.{nameof(StartSession)}");
            scope.AddAttribute(OTelSessionIdKey, sessionId);
            scope.Start();
            try
            {
                var result = await _restClient.CreateSessionAsync(_accountId, sessionId, options, cancellationToken).ConfigureAwait(false);
                return new StartRenderingSessionOperation(this, Response.FromValue(result.Value, result.GetRawResponse()));
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
        public virtual Response<RenderingSession> GetSession(string sessionId, CancellationToken cancellationToken = default)
        {
            return GetSessionInternal(sessionId, $"{nameof(RemoteRenderingClient)}.{nameof(GetSession)}", cancellationToken);
        }

        /// <summary> Gets properties of a particular rendering session. </summary>
        /// <param name="sessionId"> ID of a previously created session. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sessionId"/> is null. </exception>
        public virtual async Task<Response<RenderingSession>> GetSessionAsync(string sessionId, CancellationToken cancellationToken = default)
        {
            return await GetSessionInternalAsync(sessionId, $"{nameof(RemoteRenderingClient)}.{nameof(GetSession)}", cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Updates a particular rendering session. </summary>
        /// <param name="sessionId"> ID of a previously created session. </param>
        /// <param name="options"> Settings of the session to be updated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sessionId"/> or <paramref name="options"/> is null. </exception>
        public virtual Response<RenderingSession> UpdateSession(string sessionId, UpdateSessionOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RemoteRenderingClient)}.{nameof(UpdateSession)}");
            scope.AddAttribute(OTelSessionIdKey, sessionId);
            scope.Start();
            try
            {
                var result = _restClient.UpdateSession(_accountId, sessionId, options, cancellationToken);
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
        /// <param name="options"> Settings of the session to be updated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sessionId"/> or <paramref name="options"/> is null. </exception>
        public virtual async Task<Response<RenderingSession>> UpdateSessionAsync(string sessionId, UpdateSessionOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RemoteRenderingClient)}.{nameof(UpdateSession)}");
            scope.AddAttribute(OTelSessionIdKey, sessionId);
            scope.Start();
            try
            {
                var result = await _restClient.UpdateSessionAsync(_accountId, sessionId, options, cancellationToken).ConfigureAwait(false);
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
            scope.AddAttribute(OTelSessionIdKey, sessionId);
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RemoteRenderingClient)}.{nameof(StopSession)}");
            scope.AddAttribute(OTelSessionIdKey, sessionId);
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
        public virtual Pageable<RenderingSession> GetSessions(CancellationToken cancellationToken = default)
        {
            Page<RenderingSession> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(RemoteRenderingClient)}.{nameof(GetSessions)}");
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
            Page<RenderingSession> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(RemoteRenderingClient)}.{nameof(GetSessions)}");
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
        public virtual AsyncPageable<RenderingSession> GetSessionsAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<RenderingSession>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(RemoteRenderingClient)}.{nameof(GetSessions)}");
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
            async Task<Page<RenderingSession>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(RemoteRenderingClient)}.{nameof(GetSessions)}");
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

        private static string GetDefaultScope(Uri uri)
            => $"{uri.GetComponents(UriComponents.SchemeAndServer, UriFormat.SafeUnescaped)}/.default";

        /// <summary> Gets the status of a previously created asset conversion. </summary>
        /// <param name="conversionId"> the conversion id. </param>
        /// <param name="diagnosticScopeName">A string to for a diagnostic scope.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="conversionId"/> is null. </exception>
        internal Response<AssetConversion> GetConversionInternal(string conversionId, string diagnosticScopeName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope(diagnosticScopeName);
            scope.AddAttribute(OTelConversionIdKey, conversionId);
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
        /// <param name="diagnosticScopeName">A string to for a diagnostic scope.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="conversionId"/> is null. </exception>
        internal async Task<Response<AssetConversion>> GetConversionInternalAsync(string conversionId, string diagnosticScopeName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope(diagnosticScopeName);
            scope.AddAttribute(OTelConversionIdKey, conversionId);
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

        /// <summary> Gets properties of a particular rendering session. </summary>
        /// <param name="sessionId"> ID of a previously created session. </param>
        /// <param name="diagnosticScopeName">A string to for a diagnostic scope.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sessionId"/> is null. </exception>
        internal Response<RenderingSession> GetSessionInternal(string sessionId, string diagnosticScopeName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope(diagnosticScopeName);
            scope.AddAttribute(OTelSessionIdKey, sessionId);
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
        /// <param name="diagnosticScopeName">A string to for a diagnostic scope.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sessionId"/> is null. </exception>
        internal async Task<Response<RenderingSession>> GetSessionInternalAsync(string sessionId, string diagnosticScopeName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope(diagnosticScopeName);
            scope.AddAttribute(OTelSessionIdKey, sessionId);
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

        #endregion
    }
}
