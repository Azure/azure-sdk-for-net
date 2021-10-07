// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal class WebPubSubRequestValueProvider : IValueProvider
    {
        private readonly WebPubSubRequest _request;

        public Type Type { get; }

        public WebPubSubRequestValueProvider(WebPubSubRequest request, Type type)
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
            return nameof(WebPubSubRequest);
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
