// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.SignalR.Common;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal class SignalRRefreshInputBinding : BindingBase<SignalRRefreshAttribute>
    {
        private const string HttpRequestName = "$request";
        private const string ConnectionTokenHeaderName = "X-SignalR-Connection-Token";
        private const string SignalRUserIdClaimType = "asrs.s.uid";
        private readonly ISecurityTokenValidator _securityTokenValidator;
        private readonly ISignalRConnectionInfoConfigurer _signalRConnectionInfoConfigurer;
        private readonly IServiceManagerStore _managerStore;
        private readonly Type _userType;

        public SignalRRefreshInputBinding(
            BindingProviderContext context,
            IConfiguration configuration,
            INameResolver nameResolver,
            ISecurityTokenValidator securityTokenValidator,
            ISignalRConnectionInfoConfigurer signalRConnectionInfoConfigurer) : base(context, configuration, nameResolver)
        {
            _securityTokenValidator = securityTokenValidator;
            _signalRConnectionInfoConfigurer = signalRConnectionInfoConfigurer;
            _managerStore = StaticServiceHubContextStore.ServiceManagerStore;
            _userType = context.Parameter.ParameterType;
        }

        protected override async Task<IValueProvider> BuildAsync(SignalRRefreshAttribute attrResolved,
            IReadOnlyDictionary<string, object> bindingData,
            CancellationToken cancellationToken)
        {
            if (!bindingData.TryGetValue(HttpRequestName, out var requestObj) || requestObj is not HttpRequest request)
            {
                throw new InvalidOperationException("[SignalRRefresh] requires an HTTP-triggered function.");
            }

            var connectionToken = attrResolved.ConnectionToken;
            if (connectionToken is null && request.Headers.TryGetValue(ConnectionTokenHeaderName, out var headerToken))
            {
                connectionToken = headerToken.ToString();
            }

            if (string.IsNullOrWhiteSpace(connectionToken))
            {
                return CreateValueProvider(SignalRRefreshStatus.MissingConnectionToken);
            }

            SecurityTokenResult tokenResult = null;
            if (_securityTokenValidator != null)
            {
                try
                {
                    tokenResult = _securityTokenValidator.ValidateToken(request);
                }
                catch (SecurityTokenInvalidIssuerException)
                {
                    return CreateValueProvider(SignalRRefreshStatus.Unauthorized);
                }

                if (tokenResult.Status != SecurityTokenStatus.Valid)
                {
                    return CreateValueProvider(SignalRRefreshStatus.Unauthorized);
                }
            }

            var authenticationExpiresOn = attrResolved.ResolveAuthenticationExpiresOn();
            var azureSignalRClient = await Utils.GetAzureSignalRClientAsync(attrResolved.ConnectionStringSetting, attrResolved.HubName, _managerStore).ConfigureAwait(false);
            var customClaims = azureSignalRClient.GetCustomClaims(attrResolved.IdToken, attrResolved.ClaimTypeList);
            var signalRConnectionDetail = new SignalRConnectionDetail
            {
                UserId = attrResolved.UserId,
                Claims = customClaims.Count > 0 ? customClaims : null,
                AuthenticationExpiresOn = authenticationExpiresOn,
            };
            if (tokenResult != null)
            {
                signalRConnectionDetail = _signalRConnectionInfoConfigurer.ConfigureAuthenticatedConnection(tokenResult, request, signalRConnectionDetail);
                if (signalRConnectionDetail is null)
                {
                    return CreateValueProvider(SignalRRefreshStatus.Unauthorized);
                }
            }

            var claims = signalRConnectionDetail.Claims?.ToList();
            if (!string.IsNullOrEmpty(signalRConnectionDetail.UserId))
            {
                claims ??= new List<Claim>();
                claims.Insert(0, new Claim(SignalRUserIdClaimType, signalRConnectionDetail.UserId));
            }

            try
            {
                var info = await azureSignalRClient.RefreshConnectionInfoAsync(
                    connectionToken, signalRConnectionDetail.AuthenticationExpiresOn,
                    claims is { Count: > 0 } ? claims : null, attrResolved.TokenLifetimeSeconds, cancellationToken).ConfigureAwait(false);
                return CreateValueProvider(SignalRRefreshStatus.Succeeded, info);
            }
            catch (AzureSignalRException ex) when (_userType == typeof(SignalRRefreshResult) && ex.Message.Contains("different user"))
            {
                return CreateValueProvider(SignalRRefreshStatus.Forbidden);
            }
            catch (AzureSignalRException ex) when (_userType == typeof(SignalRRefreshResult) && ex.Message.Contains("not found"))
            {
                return CreateValueProvider(SignalRRefreshStatus.ConnectionNotFound);
            }
        }

        private IValueProvider CreateValueProvider(SignalRRefreshStatus status, SignalRConnectionInfo info = null) =>
            _userType == typeof(SignalRRefreshResult)
                ? new SignalRConnectionInfoValueProvider(new SignalRRefreshResult(status, info), "")
                : new SignalRConnectionInfoValueProvider(info, _userType, "");
    }
}
