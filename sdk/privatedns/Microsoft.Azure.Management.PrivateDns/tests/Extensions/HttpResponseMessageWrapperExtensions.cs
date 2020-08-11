// ------------------------------------------------------------------------------------------------
// <copyright file="HttpResponseMessageWrapperExtensions.cs" company="Microsoft Corporation">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace PrivateDns.Tests.Extensions
{
    using System;
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    internal static class HttpResponseMessageWrapperExtensions
    {
        public static string ExtractAsyncErrorCode(this HttpResponseMessageWrapper response)
        {
            if (response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }

            var deserializedResponse = JsonConvert.DeserializeObject<AsyncOperationResponse>(response.Content);
            return deserializedResponse?.Error?.Code;
        }

        [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
        public class AsyncOperationResponse
        {
            [JsonProperty]
            public AsyncOperationError Error { get; set; }
        }

        [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
        public class AsyncOperationError
        {
            [JsonProperty]
            public string Code { get; set; }
        }
    }
}
