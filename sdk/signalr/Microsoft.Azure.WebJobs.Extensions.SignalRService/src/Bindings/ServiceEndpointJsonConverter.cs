// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.SignalR;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal class ServiceEndpointJsonConverter : JsonConverter<ServiceEndpoint>
    {
        private const string FakeAccessKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public override ServiceEndpoint ReadJson(JsonReader reader, Type objectType, ServiceEndpoint existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return ToEqualServiceEndpoint(serializer.Deserialize<LiteServiceEndpoint>(reader));
        }

        public override void WriteJson(JsonWriter writer, ServiceEndpoint value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, new LiteServiceEndpoint(value));
        }

        private static ServiceEndpoint ToEqualServiceEndpoint(LiteServiceEndpoint e)
        {
            if (e == null)
            {
                return null;
            }

            var connectionString = $"Endpoint={e.Endpoint};AccessKey={FakeAccessKey};Version=1.0;";
            return new ServiceEndpoint(connectionString, e.EndpointType, e.Name);
        }
    }
}