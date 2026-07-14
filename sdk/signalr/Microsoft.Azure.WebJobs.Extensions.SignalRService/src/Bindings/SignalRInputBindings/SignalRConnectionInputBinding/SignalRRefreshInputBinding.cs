// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
            IReadOnlyDictionary<string, object> bindingData)
        {
            if (string.IsNullOrEmpty(attrResolved.ConnectionToken))
            {
                return new SignalRConnectionInfoValueProvider(null, _userType, "");
            }

            var azureSignalRClient = await Utils.GetAzureSignalRClientAsync(attrResolved.ConnectionStringSetting, attrResolved.HubName, _managerStore).ConfigureAwait(false);
            bindingData.TryGetValue(HttpRequestName, out var requestObj);
            var request = requestObj as HttpRequest;

            var lifetimeSeconds = attrResolved.TokenLifetimeSeconds > 0
                ? attrResolved.TokenLifetimeSeconds
                : Constants.DefaultAccessTokenLifetimeSeconds;
            var expireTime = DateTimeOffset.UtcNow.AddSeconds(lifetimeSeconds);

            if (bindingData.ContainsKey(HttpRequestName) && _securityTokenValidator != null)
            {
                var tokenResult = _securityTokenValidator.ValidateToken(request);

                if (tokenResult.Status != SecurityTokenStatus.Valid)
                {
                    return new SignalRConnectionInfoValueProvider(null, _userType, "");
                }

                var signalRConnectionDetail = new SignalRConnectionDetail
                {
                    UserId = attrResolved.UserId,
                    Claims = azureSignalRClient.GetCustomClaims(attrResolved.IdToken, attrResolved.ClaimTypeList),
                };
                _signalRConnectionInfoConfigurer?.Configure(tokenResult, request, signalRConnectionDetail);
                var customizedInfo = await azureSignalRClient.RefreshConnectionInfoAsync(
                    attrResolved.ConnectionToken, expireTime, signalRConnectionDetail.Claims).ConfigureAwait(false);
                return new SignalRConnectionInfoValueProvider(customizedInfo, _userType, "");
            }

            var claims = azureSignalRClient.GetCustomClaims(attrResolved.IdToken, attrResolved.ClaimTypeList);
            var info = await azureSignalRClient.RefreshConnectionInfoAsync(
                attrResolved.ConnectionToken, expireTime, claims).ConfigureAwait(false);
            return new SignalRConnectionInfoValueProvider(info, _userType, "");
        }
    }
}
