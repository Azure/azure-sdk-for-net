// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
            if (string.IsNullOrEmpty(attrResolved.ConnectionToken))
            {
                return new SignalRConnectionInfoValueProvider(null, _userType, "");
            }

            if (!bindingData.ContainsKey(HttpRequestName) || _securityTokenValidator == null)
            {
                return new SignalRConnectionInfoValueProvider(null, _userType, "");
            }

            bindingData.TryGetValue(HttpRequestName, out var requestObj);
            var request = requestObj as HttpRequest;
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
            signalRConnectionDetail = _signalRConnectionInfoConfigurer?.Configure?.Invoke(tokenResult, request, signalRConnectionDetail)
                ?? signalRConnectionDetail;
            var info = await azureSignalRClient.RefreshConnectionInfoAsync(
                attrResolved.ConnectionToken, signalRConnectionDetail.AuthenticationExpiresOn,
                signalRConnectionDetail.Claims, attrResolved.TokenLifetimeSeconds, cancellationToken).ConfigureAwait(false);
            return new SignalRConnectionInfoValueProvider(info, _userType, "");
        }
    }
}
