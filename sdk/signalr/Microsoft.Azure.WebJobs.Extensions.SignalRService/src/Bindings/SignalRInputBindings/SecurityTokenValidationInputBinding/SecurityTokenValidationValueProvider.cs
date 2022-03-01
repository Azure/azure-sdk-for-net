// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal class SecurityTokenValidationValueProvider : IValueProvider
    {
        private readonly SecurityTokenResult _result;
        private readonly string _invokeString;

        // todo: fix invoke string in another PR
        public SecurityTokenValidationValueProvider(SecurityTokenResult result, string invokeString)
        {
            _result = result;
            _invokeString = invokeString;
        }

        public Task<object> GetValueAsync()
        {
            return Task.FromResult<object>(_result);
        }

        public string ToInvokeString()
        {
            return _invokeString;
        }

        public Type Type => typeof(SecurityTokenResult);
    }
}