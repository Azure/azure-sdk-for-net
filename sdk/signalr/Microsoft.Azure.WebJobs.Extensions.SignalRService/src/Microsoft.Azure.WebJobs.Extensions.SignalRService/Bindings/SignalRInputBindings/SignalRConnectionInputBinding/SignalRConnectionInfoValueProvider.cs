// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal class SignalRConnectionInfoValueProvider : IValueProvider
    {
        private SignalRConnectionInfo info;
        private string invokeString;

        // todo: fix invoke string in another PR
        public SignalRConnectionInfoValueProvider(SignalRConnectionInfo info, Type type, string invokeString)
        {
            this.info = info;
            this.invokeString = invokeString;
            this.Type = type;
        }

        public Task<object> GetValueAsync()
        {
            return Task.FromResult(GetUserTypeInfo());
        }

        public string ToInvokeString()
        {
            return invokeString;
        }

        public Type Type { get; }

        private object GetUserTypeInfo()
        {
            if (Type == typeof(JObject))
            {
                return JObject.FromObject(info);
            }
            if (Type == typeof(string))
            {
                return JObject.FromObject(info).ToString();
            }

            return info;
        }
    }
}