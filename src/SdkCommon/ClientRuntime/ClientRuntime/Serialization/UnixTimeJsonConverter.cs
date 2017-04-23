// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Rest.Serialization
{
    public class UnixTimeJsonConverter : JsonConverter
    {
        public static readonly DateTime EpochDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Converts a byte array to a Base64Url encoded string
        /// </summary>
        /// <param name="input">The byte array to convert</param>
        /// <returns>The Base64Url encoded form of the input</returns>
        private static long? ToUnixTime(DateTime dateTime)
        {
            return (long?)dateTime.Subtract(EpochDate).TotalSeconds;
        }

        /// <summary>
        /// Converts a Base64Url encoded string to a byte array
        /// </summary>
        /// <param name="input">The Base64Url encoded string</param>
        /// <returns>The byte array represented by the enconded string</returns>
        private static DateTime? FromUnixTime(long? seconds)
        {
            if (seconds.HasValue)
            {
                return EpochDate.AddSeconds(seconds.Value);
            }
            return null;
        }

        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(DateTime?) || objectType == typeof(DateTime))
                return true;

            return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (objectType != typeof(DateTime?))
            {
                return serializer.Deserialize(reader, objectType);
            }
            else
            {
                var value = serializer.Deserialize<long?>(reader);

                if (value.HasValue)
                {
                    return FromUnixTime(value);
                }
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value.GetType() != typeof(DateTime))
            {
                JToken.FromObject(value).WriteTo(writer);
            }
            else
            {
                JToken.FromObject(ToUnixTime((DateTime)value)).WriteTo(writer);
            }
        }
    }
}