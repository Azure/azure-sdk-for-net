// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal class WebPubSubJsonSerializer
    {
        private readonly JsonSerializer _serializer;

        public JsonSerializer Serializer => _serializer;

        public WebPubSubJsonSerializer()
        {
            var settings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter>
                {
                    new StringEnumConverter(),
                    new BinaryDataJsonConverter(),
                    new StateDictionaryJsonConverter(),
                },
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            _serializer = JsonSerializer.Create(settings);
        }
    }
}
