// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Protocols;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal class SecurityTokenValidationInputBinding : IBinding
    {
        private const string HttpRequestName = "$request";
        private readonly ISecurityTokenValidator _securityTokenValidator;

        public bool FromAttribute { get; }

        public SecurityTokenValidationInputBinding(ISecurityTokenValidator securityTokenValidator)
        {
            _securityTokenValidator = securityTokenValidator;
        }

        public Task<IValueProvider> BindAsync(object value, ValueBindingContext context)
        {
            if (((BindingContext)value).BindingData[HttpRequestName] is not HttpRequest request)
            {
                throw new NotSupportedException($"Argument {nameof(HttpRequest)} is null. {nameof(SecurityTokenValidationAttribute)} must work with HttpTrigger.");
            }

            if (_securityTokenValidator == null)
            {
                return Task.FromResult<IValueProvider>(new SecurityTokenValidationValueProvider(null, ""));
            }

            return Task.FromResult<IValueProvider>(new SecurityTokenValidationValueProvider(_securityTokenValidator.ValidateToken(request), ""));
        }

        public Task<IValueProvider> BindAsync(BindingContext context)
        {
            return BindAsync(context, null);
        }

        public ParameterDescriptor ToParameterDescriptor()
        {
            return new ParameterDescriptor();
        }
    }
}