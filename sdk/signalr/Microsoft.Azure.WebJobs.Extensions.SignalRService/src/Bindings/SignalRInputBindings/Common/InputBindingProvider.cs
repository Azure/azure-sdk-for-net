// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    // this input binding provider doesn't support converter and pattern matcher
    internal class InputBindingProvider : IBindingProvider
    {
        private readonly ISecurityTokenValidator securityTokenValidator;
        private readonly ISignalRConnectionInfoConfigurer signalRConnectionInfoConfigurer;
        private readonly INameResolver nameResolver;
        private readonly IConfiguration configuration;

        // todo [wanl]: hubName uses [AutoResolve]
        public InputBindingProvider(IConfiguration configuration, INameResolver nameResolver, ISecurityTokenValidator securityTokenValidator, ISignalRConnectionInfoConfigurer signalRConnectionInfoConfigurer)
        {
            this.configuration = configuration;
            this.nameResolver = nameResolver;
            this.securityTokenValidator = securityTokenValidator;
            this.signalRConnectionInfoConfigurer = signalRConnectionInfoConfigurer;
        }

        public Task<IBinding> TryCreateAsync(BindingProviderContext context)
        {
            var parameterInfo = context.Parameter;

            if (parameterInfo.GetCustomAttribute<SignalRConnectionInfoAttribute>() != null)
            {
                return Task.FromResult<IBinding>(new SignalRConnectionInputBinding(context, configuration, nameResolver, securityTokenValidator, signalRConnectionInfoConfigurer));
            }
            if (parameterInfo.GetCustomAttribute<SecurityTokenValidationAttribute>() != null)
            {
                return Task.FromResult<IBinding>(new SecurityTokenValidationInputBinding(securityTokenValidator));
            }
            return Task.FromResult<IBinding>(null);
        }
    }
}