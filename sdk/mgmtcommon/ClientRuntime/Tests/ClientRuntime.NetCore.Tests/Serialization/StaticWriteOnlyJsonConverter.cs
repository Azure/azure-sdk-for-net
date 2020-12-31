// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Newtonsoft.Json;

using System;

namespace Microsoft.Rest.ClientRuntime.Tests.Serialization
{
    /// <summary>
    /// <see cref="JsonConverter"/> which writes its class name and can't read.
    /// </summary>
    public class StaticWriteOnlyJsonConverter : JsonConverter
    {
        public override bool CanRead => false;

        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(nameof(StaticWriteOnlyJsonConverter));
        }
    }
}
