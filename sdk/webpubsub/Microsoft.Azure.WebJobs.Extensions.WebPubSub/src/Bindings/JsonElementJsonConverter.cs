// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal class JsonElementJsonConverter : JsonConverter<JsonElement>
    {
        public override bool CanRead => false;
        public override bool CanWrite => true;

        public override JsonElement ReadJson(JsonReader reader, Type objectType, JsonElement existingValue, bool hasExistingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, JsonElement value, Newtonsoft.Json.JsonSerializer serializer)
        {
            writer.WriteRawValue(value.GetRawText());
        }
    }
}