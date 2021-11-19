// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal class WebPubSubJsonSerializer
    {
        public static JsonSerializer Serializer = JsonSerializer.Create(
            new JsonSerializerSettings
            {
                Converters = new List<JsonConverter>
                {
                    new StringEnumConverter(),
                    new BinaryDataJsonConverter(),
                    new JsonElementJsonConverter(),
                },
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
    }
}
