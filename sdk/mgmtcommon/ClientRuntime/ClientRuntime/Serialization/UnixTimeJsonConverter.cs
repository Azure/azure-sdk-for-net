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
        /// Converts a <see cref="DateTime"/> to Unix time in seconds.
        /// </summary>
        /// <param name="dateTime">Date to convert.</param>
        /// <returns>Number of seconds since the Unix epoch.</returns>
        private static long ToUnixTime(DateTime dateTime)
        {
            return (long)dateTime.Subtract(EpochDate).TotalSeconds;
        }

        /// <summary>
        /// Converts a <see cref="DateTimeOffset"/> to Unix time in seconds.
        /// </summary>
        /// <param name="dateTimeOffset">Date to convert.</param>
        /// <returns>Number of seconds since the Unix epoch.</returns>
        private static long ToUnixTime(DateTimeOffset dateTimeOffset)
        {
            return ToUnixTime(dateTimeOffset.UtcDateTime);
        }

        /// <summary>
        /// Converts a Unix time in seconds to a <see cref="DateTime"/>.
        /// </summary>
        /// <param name="seconds">Number of seconds since the Unix epoch.</param>
        /// <returns>UTC <see cref="DateTime"/> <paramref name="seconds"/> since
        /// the Unix epoch.</returns>
        private static DateTime FromUnixTime(long seconds)
        {
            return EpochDate.AddSeconds(seconds);
        }

        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(DateTime?) || objectType == typeof(DateTime))
                return true;

            if (objectType == typeof(DateTimeOffset?) || objectType == typeof(DateTimeOffset))
                return true;

            return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (objectType == typeof(DateTime?) || objectType == typeof(DateTime))
            {
                var value = serializer.Deserialize<long?>(reader);

                if (value.HasValue)
                {
                    return FromUnixTime(value.Value);
                }
            }
            else if (objectType == typeof(DateTimeOffset?) || objectType == typeof(DateTimeOffset))
            {
                var value = serializer.Deserialize<long?>(reader);

                if (value.HasValue)
                {
                    return new DateTimeOffset(FromUnixTime(value.Value));
                }
            }
            else
            {
                return serializer.Deserialize(reader, objectType);
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is DateTime dateTime)
            {
                writer.WriteValue(ToUnixTime(dateTime));
            }
            else if (value is DateTimeOffset dateTimeOffset)
            {
                writer.WriteValue(ToUnixTime(dateTimeOffset));
            }
            else
            {
                JToken.FromObject(value).WriteTo(writer);
            }
        }
    }
}