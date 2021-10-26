// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal class WebPubSubContextValueProvider : IValueProvider
    {
        private readonly WebPubSubContext _request;

        public Type Type { get; }

        public WebPubSubContextValueProvider(WebPubSubContext request, Type type)
        {
            _request = request;
            Type = type;
        }

        public Task<object> GetValueAsync()
        {
            return Task.FromResult(GetRequest());
        }

        public string ToInvokeString()
        {
            return nameof(WebPubSubContext);
        }

        private object GetRequest()
        {
            if (Type == typeof(JObject))
            {
                return JObject.FromObject(_request);
            }
            if (Type == typeof(string))
            {
                return JObject.FromObject(_request).ToString();
            }

            return _request;
        }
    }
}
