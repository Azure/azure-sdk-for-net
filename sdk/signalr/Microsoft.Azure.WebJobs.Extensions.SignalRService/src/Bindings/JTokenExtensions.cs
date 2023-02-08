// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal static class JTokenExtensions
    {
        public static readonly JsonSerializer JsonSerializers = JsonSerializer.Create(new JsonSerializerSettings
        {
            Converters = new JsonConverter[] { new ServiceEndpointJsonConverter(), new SignalRMessageConverter() }
        });

        public static bool TryToObject<TOutput>(this JToken input, out TOutput output)
        {
            try
            {
                output = input.ToObject<TOutput>(JsonSerializers);
            }
            catch
            {
                output = default;
                return false;
            }

            return true;
        }
    }
}