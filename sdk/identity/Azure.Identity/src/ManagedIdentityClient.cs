// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    internal class ManagedIdentityClient
    {
        private const string MsiEndpointEnvironemntVariable = "MSI_ENDPOINT";
        private const string MsiSecretEnvironemntVariable = "MSI_SECRET";
        private static Lazy<ManagedIdentityClient> s_sharedClient = new Lazy<ManagedIdentityClient>(() => new ManagedIdentityClient());
        private static readonly Uri ImdsEndpoint = new Uri("http://169.254.169.254/metadata/identity/oauth2/token");
        private static SemaphoreSlim s_initLock = new SemaphoreSlim(1, 1);
        private static MsiType s_msiType;
        private static Uri s_endpoint;

        private const string ImdsApiVersion = "2018-02-01";
        private const string AppServiceMsiApiVersion = "2017-09-01";


        private readonly IdentityClientOptions _options;
        private readonly HttpPipeline _pipeline;

        public ManagedIdentityClient(IdentityClientOptions options = null)
        {
            _options = options ?? new IdentityClientOptions();

            _pipeline = HttpPipelineBuilder.Build(_options, bufferResponse: true);
        }

        private enum MsiType
        {
            Unknown = 0,
            Imds = 1,
            AppService = 2,
            CloudShell = 3,
            Unavailable = 4
        }

        public static ManagedIdentityClient SharedClient { get { return s_sharedClient.Value; } }

        public virtual async Task<AccessToken> AuthenticateAsync(string[] scopes, string clientId = null, CancellationToken cancellationToken = default)
        {
            MsiType msiType = GetMsiType(cancellationToken);

            // if msi is unavailable or we were unable to determine the type return a default access token
            if (msiType == MsiType.Unavailable || msiType == MsiType.Unknown)
            {
                return default;
            }

            using (Request request = CreateAuthRequest(msiType, scopes, clientId))
            {
                var response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                if (response.Status == 200 || response.Status == 201)
                {
                    var result = await DeserializeAsync(response.ContentStream, cancellationToken).ConfigureAwait(false);

                    return result;
                }

                throw response.CreateRequestFailedException();
            }
        }

        public virtual AccessToken Authenticate(string[] scopes, string clientId = null, CancellationToken cancellationToken = default)
        {
            MsiType msiType = GetMsiType(cancellationToken);

            // if msi is unavailable or we were unable to determine the type return a default access token
            if (msiType == MsiType.Unavailable || msiType == MsiType.Unknown)
            {
                return default;
            }

            using (Request request = CreateAuthRequest(msiType, scopes, clientId))
            {
                var response = _pipeline.SendRequest(request, cancellationToken);

                if (response.Status == 200 || response.Status == 201)
                {
                    var result = Deserialize(response.ContentStream);

                    return result;
                }

                throw response.CreateRequestFailedException();
            }
        }

        private Request CreateAuthRequest(MsiType msiType, string[] scopes, string clientId)
        {
            switch (msiType)
            {
                case MsiType.Imds:
                    return CreateImdsAuthRequest(scopes, clientId);
                case MsiType.AppService:
                    return CreateAppServiceAuthRequest(scopes, clientId);
                case MsiType.CloudShell:
                    return CreateCloudShellAuthRequest(scopes, clientId);
                default:
                    return default;
            }

        }

        private async ValueTask<MsiType> GetMsiTypeAsync(CancellationToken cancellationToken)
        { // if we haven't already determined the msi type
            if (s_msiType == MsiType.Unknown)
            {
                // aquire the init lock 
                await s_initLock.WaitAsync(cancellationToken).ConfigureAwait(false);

                try
                {
                    // check again if the we already determined the msiType now that we hold the lock
                    if (s_msiType == MsiType.Unknown)
                    {
                        string endpointEnvVar = Environment.GetEnvironmentVariable(MsiEndpointEnvironemntVariable);
                        string secretEnvVar = Environment.GetEnvironmentVariable(MsiSecretEnvironemntVariable);

                        // if the env var MSI_ENDPOINT is set
                        if (!string.IsNullOrEmpty(endpointEnvVar))
                        {
                            s_endpoint = new Uri(endpointEnvVar);

                            // if BOTH the env vars MSI_ENDPOINT and MSI_SECRET are set the MsiType is AppService
                            if (!string.IsNullOrEmpty(secretEnvVar))
                            {
                                s_secret = secretEnvVar;
                                s_msiType = MsiType.AppService;
                            }
                            // if ONLY the env var MSI_ENDPOINT is set the MsiType is CloudShell
                            else
                            {
                                s_msiType = MsiType.CloudShell;
                            }
                        }
                        // if MSI_ENDPOINT is NOT set AND the IMDS endpoint is available the MsiType is Imds
                        else if (await ImdsAvailableAsync(cancellationToken).ConfigureAwait(false))
                        {
                            s_endpoint = ImdsEndpoint;
                            s_msiType = MsiType.Imds;
                        }
                        // if MSI_ENDPOINT is NOT set and IMDS enpoint is not available ManagedIdentity is not available
                        else
                        {
                            s_msiType = MsiType.Unavailable;
                        }
                    }
                }
                // release the init lock
                finally
                {
                    s_initLock.Release();
                }
            }

            return s_msiType;
        }


        private MsiType GetMsiType(CancellationToken cancellationToken)
        {
            // if we haven't already determined the msi type
            if (s_msiType == MsiType.Unknown)
            {
                // aquire the init lock 
                s_initLock.Wait(cancellationToken);

                try
                {
                    // check again if the we already determined the msiType now that we hold the lock
                    if (s_msiType == MsiType.Unknown)
                    {
                        string endpointEnvVar = Environment.GetEnvironmentVariable(MsiEndpointEnvironemntVariable);
                        string secretEnvVar = Environment.GetEnvironmentVariable(MsiSecretEnvironemntVariable);

                        // if the env var MSI_ENDPOINT is set
                        if (!string.IsNullOrEmpty(endpointEnvVar))
                        {
                            s_endpoint = new Uri(endpointEnvVar);

                            // if BOTH the env vars MSI_ENDPOINT and MSI_SECRET are set the MsiType is AppService
                            if (!string.IsNullOrEmpty(secretEnvVar))
                            {
                                s_msiType = MsiType.AppService;
                            }
                            // if ONLY the env var MSI_ENDPOINT is set the MsiType is CloudShell
                            else
                            {
                                s_msiType = MsiType.CloudShell;
                            }
                        }
                        // if MSI_ENDPOINT is NOT set AND the IMDS endpoint is available the MsiType is Imds
                        else if (ImdsAvailable(cancellationToken))
                        {
                            s_endpoint = ImdsEndpoint;
                            s_msiType = MsiType.Imds;
                        }
                        // if MSI_ENDPOINT is NOT set and IMDS enpoint is not available ManagedIdentity is not available
                        else
                        {
                            s_msiType = MsiType.Unavailable;
                        }
                    }
                }
                // release the init lock
                finally
                {
                    s_initLock.Release();
                }
            }

            return s_msiType;
        }

        private bool ImdsAvailable(CancellationToken cancellationToken)
        {            
            // send a request without the Metadata header.  This will result in a failed request,
            // but we're just interested in if we get a response before the timeout of 500ms
            // if we don't get a response we assume the imds endpoint is not available
            using (Request request = _pipeline.CreateRequest())
            {
                request.Method = HttpPipelineMethod.Get;

                request.UriBuilder.Uri = ImdsEndpoint;

                request.UriBuilder.AppendQuery("api-version", ImdsApiVersion);

                var imdsTimeout = new CancellationTokenSource(500).Token;

                try
                {
                    var response = _pipeline.SendRequest(request, CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, imdsTimeout).Token);
                
                    return true;
                }
                // we only want to handle the case when the imdsTimeout resulted in the request being cancelled.
                // this indicates that the request timed out and that imds is not available.  Otherwise the operation
                // was user cancelled.  In this case we don't wan't to handle the exception so s_identityAvailable will
                // remain unset, as we still haven't determined if the imds endpoint is available.
                catch (OperationCanceledException ex) when (ex.CancellationToken == imdsTimeout)
                {
                    return false;
                }
            }

        }

        private async Task<bool> ImdsAvailableAsync(CancellationToken cancellationToken)
        {
            // send a request without the Metadata header.  This will result in a failed request,
            // but we're just interested in if we get a response before the timeout of 500ms
            // if we don't get a response we assume the imds endpoint is not available
            using (Request request = _pipeline.CreateRequest())
            {
                request.Method = HttpPipelineMethod.Get;

                request.UriBuilder.Uri = ImdsEndpoint;

                request.UriBuilder.AppendQuery("api-version", ImdsApiVersion);

                var imdsTimeout = new CancellationTokenSource(500).Token;

                try
                {
                    var response = await _pipeline.SendRequestAsync(request, CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, imdsTimeout).Token).ConfigureAwait(false);

                    return true;
                }
                // we only want to handle the case when the imdsTimeout resulted in the request being cancelled.
                // this indicates that the request timed out and that imds is not available.  Otherwise the operation
                // was user cancelled.  In this case we don't wan't to handle the exception so s_identityAvailable will
                // remain unset, as we still haven't determined if the imds endpoint is available.
                catch (OperationCanceledException ex) when (ex.CancellationToken == imdsTimeout)
                {
                    return false;
                }
            }
        }

        private Request CreateImdsAuthRequest(string[] scopes, string clientId)
        {
            // covert the scopes to a resource string
            string resource = ScopeUtilities.ScopesToResource(scopes);

            Request request = _pipeline.CreateRequest();

            request.Method = HttpPipelineMethod.Get;

            request.Headers.Add("Metadata", "true");

            request.UriBuilder.Uri = s_endpoint;

            request.UriBuilder.AppendQuery("api-version", ImdsApiVersion);

            request.UriBuilder.AppendQuery("resource", Uri.EscapeDataString(resource));

            if (!string.IsNullOrEmpty(clientId))
            {
                request.UriBuilder.AppendQuery("client_id", Uri.EscapeDataString(clientId));
            }

            return request;
        }

        private Request CreateAppServiceAuthRequest(string[] scopes, string clientId)
        {
            // covert the scopes to a resource string
            string resource = ScopeUtilities.ScopesToResource(scopes);

            Request request = _pipeline.CreateRequest();

            request.Method = HttpPipelineMethod.Get;

            request.Headers.Add("secret", Environment.GetEnvironmentVariable(MsiSecretEnvironemntVariable));

            request.UriBuilder.Uri = s_endpoint;

            request.UriBuilder.AppendQuery("api-version", AppServiceMsiApiVersion);

            request.UriBuilder.AppendQuery("resource", Uri.EscapeDataString(resource));

            if (!string.IsNullOrEmpty(clientId))
            {
                request.UriBuilder.AppendQuery("client_id", Uri.EscapeDataString(clientId));
            }

            return request;
        }

        private Request CreateCloudShellAuthRequest(string[] scopes, string clientId)
        {
            // covert the scopes to a resource string
            string resource = ScopeUtilities.ScopesToResource(scopes);

            Request request = _pipeline.CreateRequest();

            request.Method = HttpPipelineMethod.Post;

            request.Headers.Add(HttpHeader.Common.FormUrlEncodedContentType);

            request.UriBuilder.Uri = s_endpoint;

            request.Headers.Add("Metadata", "true");

            var bodyStr = $"resource={Uri.EscapeDataString(resource)}";

            if (!string.IsNullOrEmpty(clientId))
            {
                bodyStr += $"&client_id={Uri.EscapeDataString(clientId)}";
            }

            ReadOnlyMemory<byte> content = Encoding.UTF8.GetBytes(bodyStr).AsMemory();

            request.Content = HttpPipelineRequestContent.Create(content);

            return request;
        }

        private async Task<AccessToken> DeserializeAsync(Stream content, CancellationToken cancellationToken)
        {
            using (JsonDocument json = await JsonDocument.ParseAsync(content, default, cancellationToken).ConfigureAwait(false))
            {
                return Deserialize(json.RootElement);
            }
        }

        private AccessToken Deserialize(Stream content)
        {
            using (JsonDocument json = JsonDocument.Parse(content))
            {
                return Deserialize(json.RootElement);
            }
        }

        private AccessToken Deserialize(JsonElement json)
        {
            string accessToken = null;

            DateTimeOffset expiresOn = DateTimeOffset.MaxValue;

            if (json.TryGetProperty("access_token", out JsonElement accessTokenProp))
            {
                accessToken = accessTokenProp.GetString();
            }

            if (json.TryGetProperty("expires_on", out JsonElement expiresOnProp))
            {
                // if s_msiType is AppService expires_on will be a string formatted datetimeoffset
                if (s_msiType == MsiType.AppService)
                {
                    expiresOn = DateTimeOffset.Parse(expiresOnProp.GetString());
                }
                // otherwise expires_on will be a unix timestamp seconds from epoch
                else
                {
                    expiresOn = DateTime.UtcNow + TimeSpan.FromSeconds(expiresOnProp.GetInt64());
                }
            }

            return new AccessToken(accessToken, expiresOn);
        }
    }
}