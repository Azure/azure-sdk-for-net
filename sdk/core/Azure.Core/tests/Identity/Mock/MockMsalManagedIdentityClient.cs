// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Identity;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.ManagedIdentity;
namespace Azure.Core.Tests.Identity.Mock
{
    internal class MockMsalManagedIdentityClient : MsalManagedIdentityClient
    {
        public Func<CancellationToken, IManagedIdentityApplication> ClientAppFactory { get; set; }
        public Func<TokenRequestContext, CancellationToken, AuthenticationResult> AcquireTokenForManagedIdentityAsyncFactory { get; set; }

        private Microsoft.Identity.Client.ManagedIdentity.ManagedIdentitySource _detectedSource;
        private ManagedIdentityId _azureManagedIdentityId;

        public MockMsalManagedIdentityClient() { }

        public MockMsalManagedIdentityClient(AuthenticationResult result)
        {
            AcquireTokenForManagedIdentityAsyncFactory = (_, _) => result;
        }

        public MockMsalManagedIdentityClient(ManagedIdentityClientOptions options)
            : base(options)
        {
            _azureManagedIdentityId = options.ManagedIdentityId;
        }

        protected override ValueTask<IManagedIdentityApplication> CreateClientCoreAsync(bool async, bool enableCae, bool isTokenBindingAvailable, CancellationToken cancellationToken)
        {
            if (ClientAppFactory == null)
            {
                return base.CreateClientCoreAsync(async, enableCae, isTokenBindingAvailable, cancellationToken);
            }

            return new ValueTask<IManagedIdentityApplication>(ClientAppFactory(cancellationToken));
        }

        public override ValueTask<AuthenticationResult> AcquireTokenForManagedIdentityAsyncCore(bool async, TokenRequestContext requestContext, bool isTokenBindingAvailable, CancellationToken cancellationToken)
        {
            if (AcquireTokenForManagedIdentityAsyncFactory != null)
            {
                return new ValueTask<AuthenticationResult>(AcquireTokenForManagedIdentityAsyncFactory(requestContext, cancellationToken));
            }

            // For IMDS sources, bypass MSAL entirely to avoid its internal probing which
            // sends extra requests through the pipeline and conflicts with mock transports.
            // Non-IMDS sources (AppService, CloudShell, etc.) are detected from env vars
            // without HTTP probing, so MSAL handles them safely.
#pragma warning disable CS0618 // DefaultToImds is obsolete
            if (Pipeline != null &&
                (_detectedSource == Microsoft.Identity.Client.ManagedIdentity.ManagedIdentitySource.DefaultToImds ||
                 _detectedSource == Microsoft.Identity.Client.ManagedIdentity.ManagedIdentitySource.Imds))
#pragma warning restore CS0618
            {
                return new ValueTask<AuthenticationResult>(SendDirectImdsRequest(requestContext, cancellationToken));
            }

            return base.AcquireTokenForManagedIdentityAsyncCore(async, requestContext, isTokenBindingAvailable, cancellationToken);
        }

        public override ValueTask<ManagedIdentityCapabilities> GetManagedIdentityCapabilitiesAsync(TokenRequestContext context, CancellationToken cancellationToken)
        {
            // Use the static method to avoid real network probing in tests.
#pragma warning disable CS0618 // GetManagedIdentitySource is obsolete
            _detectedSource = ManagedIdentityApplication.GetManagedIdentitySource();
#pragma warning restore CS0618
            return new ValueTask<ManagedIdentityCapabilities>(CreateManagedIdentityCapabilities(_detectedSource));
        }

        private static ManagedIdentityCapabilities CreateManagedIdentityCapabilities(Microsoft.Identity.Client.ManagedIdentity.ManagedIdentitySource source)
        {
            ConstructorInfo ctor = typeof(ManagedIdentityCapabilities).GetConstructor(
                BindingFlags.Instance | BindingFlags.NonPublic,
                binder: null,
            types: [typeof(Microsoft.Identity.Client.ManagedIdentity.ManagedIdentitySource), typeof(Microsoft.Identity.Client.AppConfig.MtlsBindingStrength), typeof(string)],
                modifiers: null);

            return (ManagedIdentityCapabilities)ctor.Invoke([source, Microsoft.Identity.Client.AppConfig.MtlsBindingStrength.None, null]);
        }

        private AuthenticationResult SendDirectImdsRequest(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            string resource = ScopeUtilities.ScopesToResource(requestContext.Scopes);
            var request = Pipeline.HttpPipeline.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(ImdsManagedIdentityProbeSource.GetImdsUri());
            request.Uri.AppendQuery("api-version", "2018-02-01");
            // Don't URL-encode resource to match MSAL's behavior (tests assert on unencoded values)
            request.Uri.AppendQuery("resource", resource, false);
            request.Headers.Add("Metadata", "true");

            if (_azureManagedIdentityId != null)
            {
                string idParam = _azureManagedIdentityId._idType switch
                {
                    ManagedIdentityIdType.ClientId => Constants.ManagedIdentityClientId,
                    ManagedIdentityIdType.ResourceId => Constants.ManagedIdentityResourceId,
                    ManagedIdentityIdType.ObjectId => "object_id",
                    _ => null
                };
                if (idParam != null)
                {
                    request.Uri.AppendQuery(idParam, _azureManagedIdentityId._userAssignedId);
                }
            }

            Response response;
            try
            {
                response = Pipeline.HttpPipeline.SendRequest(request, cancellationToken);
            }
            catch (Exception ex) when (ex is RequestFailedException || ex is AggregateException)
            {
                // Wrap in MsalServiceException so ManagedIdentityClient.AuthenticateAsync
                // handles it the same way as a real MSAL timeout/connection failure.
                throw new MsalServiceException(MsalError.ManagedIdentityUnreachableNetwork, ex.Message, ex);
            }

            if (response.Status == 502 || response.Status == 504)
            {
                throw new MsalServiceException(
                    MsalError.ManagedIdentityUnreachableNetwork,
                    $"IMDS returned {response.Status}: {response.Content}",
                    new RequestFailedException(response));
            }

            if (response.IsError)
            {
                string body = response.Content?.ToString();
                if (string.IsNullOrEmpty(body))
                {
                    body = "Managed identity request failed.";
                }
                throw new MsalServiceException(
                    MsalError.ManagedIdentityRequestFailed,
                    body,
                    response.Status);
            }

            using var json = JsonDocument.Parse(response.Content.ToString());
            string accessToken = json.RootElement.GetProperty("access_token").GetString();
            long expiresOnSec = long.Parse(json.RootElement.GetProperty("expires_on").GetString(), CultureInfo.InvariantCulture);
            var expiresOn = DateTimeOffset.FromUnixTimeSeconds(expiresOnSec);

            return new AuthenticationResult(
                accessToken, false, null, expiresOn, expiresOn, null, null, null,
                requestContext.Scopes, Guid.Empty);
        }
    }
}
