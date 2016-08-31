// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.KeyVault.WebKey
{
    public class Base64UrlJsonConverter : JsonConverter
    {
        /// <summary>
        /// Converts a byte array to a Base64Url encoded string
        /// </summary>
        /// <param name="input">The byte array to convert</param>
        /// <returns>The Base64Url encoded form of the input</returns>
        private static string ToBase64UrlString(byte[] input)
        {
            if (input == null)
                throw new ArgumentNullException("input");

            return Convert.ToBase64String(input).TrimEnd('=').Replace('+', '-').Replace('/', '_');
        }

        /// <summary>
        /// Converts a Base64Url encoded string to a byte array
        /// </summary>
        /// <param name="input">The Base64Url encoded string</param>
        /// <returns>The byte array represented by the enconded string</returns>
        private static byte[] FromBase64UrlString(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentNullException("input");

            return Convert.FromBase64String(Pad(input.Replace('-', '+').Replace('_', '/')));
        }

        /// <summary>
        /// Adds padding to the input
        /// </summary>
        /// <param name="input"> the input string </param>
        /// <returns> the padded string </returns>
        private static string Pad(string input)
        {
            var count = 3 - ((input.Length + 3) % 4);

            if (count == 0)
            {
                return input;
            }

            return input + new string('=', count);
        }

        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(byte[]))
                return true;

            return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (objectType != typeof(byte[]))
            {
                return serializer.Deserialize(reader, objectType);
            }
            else
            {
                var value = serializer.Deserialize<string>(reader);

                if (!string.IsNullOrEmpty(value))
                {
                    return FromBase64UrlString(value);
                }
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value.GetType() != typeof(byte[]))
            {
                JToken.FromObject(value).WriteTo(writer);
            }
            else
            {
                JToken.FromObject(ToBase64UrlString((byte[])value)).WriteTo(writer);
            }
        }
    }
}