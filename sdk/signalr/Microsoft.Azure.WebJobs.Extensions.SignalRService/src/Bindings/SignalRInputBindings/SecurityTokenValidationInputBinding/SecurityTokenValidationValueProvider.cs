// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal class SecurityTokenValidationValueProvider : IValueProvider
    {
        private readonly SecurityTokenResult result;
        private readonly string invokeString;

        // todo: fix invoke string in another PR
        public SecurityTokenValidationValueProvider(SecurityTokenResult result, string invokeString)
        {
            this.result = result;
            this.invokeString = invokeString;
        }

        public Task<object> GetValueAsync()
        {
            return Task.FromResult<object>(result);
        }

        public string ToInvokeString()
        {
            return invokeString;
        }

        public Type Type => typeof(SecurityTokenResult);
    }
}