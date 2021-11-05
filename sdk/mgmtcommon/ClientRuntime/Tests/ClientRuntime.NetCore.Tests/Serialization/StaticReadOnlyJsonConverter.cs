// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Newtonsoft.Json;

using System;

namespace Microsoft.Rest.ClientRuntime.Tests.Serialization
{
    /// <summary>
    /// <see cref="JsonConverter"/> which reads its class name and can't write.
    /// </summary>
    public class StaticReadOnlyJsonConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return nameof(StaticReadOnlyJsonConverter);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
