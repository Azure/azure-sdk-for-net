// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal class HttpResponseMessageJsonConverter : JsonConverter<HttpResponseMessage>
    {
        public override HttpResponseMessage ReadJson(JsonReader reader, Type objectType, HttpResponseMessage existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize<HttpResponseMessage>(reader);
        }

        public override void WriteJson(JsonWriter writer, HttpResponseMessage value, JsonSerializer serializer)
        {
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
            var simpleRes = SimpleResponse.FromHttpResponse(value).GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
            serializer.Serialize(writer, JObject.FromObject(simpleRes));
        }

        // js accecpts simple HttpResponse object.
        [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
        private sealed class SimpleResponse
        {
            public Stream Body { get; set; }

            public int Status { get; set; }

            public Dictionary<string, StringValues> Headers { get; set; }

            public static async Task<SimpleResponse> FromHttpResponse(HttpResponseMessage response)
            {
                Stream body = null;
                if (response.Content != null)
                {
                    body = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
                }
                return new SimpleResponse
                {
                    Body = body,
                    Status = (int)response.StatusCode,
                    Headers = response.Headers.ToDictionary(x => x.Key, v => new StringValues(v.Value.ToArray()), StringComparer.OrdinalIgnoreCase)
                };
            }
        }
    }
}
