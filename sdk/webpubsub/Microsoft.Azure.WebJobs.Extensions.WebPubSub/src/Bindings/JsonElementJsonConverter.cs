// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Newtonsoft.Json;

using SystemJson = System.Text.Json;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal class JsonElementJsonConverter : JsonConverter<SystemJson.JsonElement>
    {
        public override bool CanRead => false;
        public override bool CanWrite => true;

        public override SystemJson.JsonElement ReadJson(JsonReader reader, Type objectType, SystemJson.JsonElement existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, SystemJson.JsonElement value, JsonSerializer serializer)
        {
            writer.WriteRawValue(value.GetRawText());
        }
    }
}