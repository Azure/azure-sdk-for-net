// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal class SignalRConnectionInfoValueProvider : IValueProvider
    {
        private readonly SignalRConnectionInfo _info;
        private readonly string _invokeString;

        public Type Type { get; }

        // todo: fix invoke string in another PR
        public SignalRConnectionInfoValueProvider(SignalRConnectionInfo info, Type type, string invokeString)
        {
            _info = info;
            _invokeString = invokeString;
            Type = type;
        }

        public Task<object> GetValueAsync()
        {
            return Task.FromResult(GetUserTypeInfo());
        }

        public string ToInvokeString()
        {
            return _invokeString;
        }

        private object GetUserTypeInfo()
        {
            if (Type == typeof(JObject))
            {
                return JObject.FromObject(_info);
            }
            if (Type == typeof(string))
            {
                return JObject.FromObject(_info).ToString();
            }

            return _info;
        }
    }
}