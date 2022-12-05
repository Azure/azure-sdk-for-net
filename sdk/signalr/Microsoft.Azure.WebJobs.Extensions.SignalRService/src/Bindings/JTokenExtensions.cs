// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal static class JTokenExtensions
    {
        public static bool TryToObject<TOutput>(this JToken input, out TOutput output)
        {
            try
            {
                output = input.ToObject<TOutput>(ServiceEndpointJsonConverter.JsonSerializer);
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