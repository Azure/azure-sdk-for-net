// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal class SignalRRefreshInputBinding : BindingBase<SignalRRefreshAttribute>
    {
        private const string HttpRequestName = "$request";
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

            if (_securityTokenValidator == null)
            {
                throw new InvalidOperationException("[SignalRRefresh] requires an ISecurityTokenValidator. Register one with AddDefaultAuth or provide a custom implementation.");
            }

            var connectionToken = attrResolved.ConnectionToken;
            if (string.IsNullOrWhiteSpace(connectionToken))
            {
                return new SignalRConnectionInfoValueProvider(null, _userType, "");
            }

            var tokenResult = _securityTokenValidator.ValidateToken(request);
            if (tokenResult.Status != SecurityTokenStatus.Valid)
            {
                return new SignalRConnectionInfoValueProvider(null, _userType, "");
            }

            var azureSignalRClient = await Utils.GetAzureSignalRClientAsync(attrResolved.ConnectionStringSetting, attrResolved.HubName, _managerStore).ConfigureAwait(false);
            var customClaims = azureSignalRClient.GetCustomClaims(attrResolved.IdToken, attrResolved.ClaimTypeList);
            var signalRConnectionDetail = new SignalRConnectionDetail
            {
                UserId = attrResolved.UserId,
                Claims = customClaims.Count > 0 ? customClaims : null,
                AuthenticationExpiresOn = tokenResult.ExpiresOn,
            };
            signalRConnectionDetail = _signalRConnectionInfoConfigurer.ConfigureAuthenticatedConnection(tokenResult, request, signalRConnectionDetail);
            if (signalRConnectionDetail is null)
            {
                return new SignalRConnectionInfoValueProvider(null, _userType, "");
            }

            var claims = signalRConnectionDetail.Claims is { Count: > 0 } ? signalRConnectionDetail.Claims : null;
            if (!string.IsNullOrEmpty(signalRConnectionDetail.UserId))
            {
                claims = claims?.Where(c => !string.Equals(c.Type, SignalRUserIdClaimType, StringComparison.OrdinalIgnoreCase)).ToList()
                    ?? new List<Claim>();
                claims.Add(new Claim(SignalRUserIdClaimType, signalRConnectionDetail.UserId));
            }

            var info = await azureSignalRClient.RefreshConnectionInfoAsync(
                connectionToken, signalRConnectionDetail.AuthenticationExpiresOn,
                claims, attrResolved.TokenLifetimeSeconds, cancellationToken).ConfigureAwait(false);
            return new SignalRConnectionInfoValueProvider(info, _userType, "");
        }
    }
}
