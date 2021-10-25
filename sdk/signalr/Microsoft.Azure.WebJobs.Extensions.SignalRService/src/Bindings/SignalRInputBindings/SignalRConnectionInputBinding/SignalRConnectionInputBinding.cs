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
    internal class SignalRConnectionInputBinding : BindingBase<SignalRConnectionInfoAttribute>
    {
        private const string HttpRequestName = "$request";
        private readonly ISecurityTokenValidator securityTokenValidator;
        private readonly ISignalRConnectionInfoConfigurer signalRConnectionInfoConfigurer;
        private readonly IServiceManagerStore managerStore;
        private readonly Type userType;

        public SignalRConnectionInputBinding(
            BindingProviderContext context,
            IConfiguration configuration,
            INameResolver nameResolver,
            ISecurityTokenValidator securityTokenValidator,
            ISignalRConnectionInfoConfigurer signalRConnectionInfoConfigurer) : base(context, configuration, nameResolver)
        {
            this.securityTokenValidator = securityTokenValidator;
            this.signalRConnectionInfoConfigurer = signalRConnectionInfoConfigurer;
            managerStore = StaticServiceHubContextStore.ServiceManagerStore;
            userType = context.Parameter.ParameterType;
        }

        protected override async Task<IValueProvider> BuildAsync(SignalRConnectionInfoAttribute attrResolved,
            IReadOnlyDictionary<string, object> bindingData)
        {
            var azureSignalRClient = await Utils.GetAzureSignalRClientAsync(attrResolved.ConnectionStringSetting, attrResolved.HubName, managerStore).ConfigureAwait(false);
            bindingData.TryGetValue(HttpRequestName, out var requestObj);
            var request = requestObj as HttpRequest;
            var httpContext = request?.HttpContext;

            if (bindingData.ContainsKey(HttpRequestName) && securityTokenValidator != null)
            {
                var tokenResult = securityTokenValidator.ValidateToken(request);

                if (tokenResult.Status != SecurityTokenStatus.Valid)
                {
                    return new SignalRConnectionInfoValueProvider(null, userType, "");
                }

                var signalRConnectionDetail = new SignalRConnectionDetail
                {
                    UserId = attrResolved.UserId,
                    Claims = azureSignalRClient.GetCustomClaims(attrResolved.IdToken, attrResolved.ClaimTypeList),
                };
                signalRConnectionInfoConfigurer?.Configure(tokenResult, request, signalRConnectionDetail);
                var customizedInfo = await azureSignalRClient.GetClientConnectionInfoAsync(signalRConnectionDetail.UserId,
                    signalRConnectionDetail.Claims, httpContext).ConfigureAwait(false);
                return new SignalRConnectionInfoValueProvider(customizedInfo, userType, "");
            }

            var info = await azureSignalRClient.GetClientConnectionInfoAsync(attrResolved.UserId, attrResolved.IdToken,
                attrResolved.ClaimTypeList, httpContext).ConfigureAwait(false);
            return new SignalRConnectionInfoValueProvider(info, userType, "");
        }
    }
}