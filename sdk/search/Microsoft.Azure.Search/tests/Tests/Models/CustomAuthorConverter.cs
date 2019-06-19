// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using Newtonsoft.Json;
    using Serialization;

    internal class CustomAuthorConverter<TAuthor> : JsonConverter where TAuthor : CustomAuthor, new()
    {
        public void Install(ISearchIndexClient client)
        {
            client.SerializationSettings.Converters.Add(this);
            client.DeserializationSettings.Converters.Add(this);
        }

        public override bool CanConvert(Type objectType) => objectType == typeof(TAuthor);

        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            // Check for null first.
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            var author = new TAuthor { FullName = string.Empty };

            reader.ExpectAndAdvance(JsonToken.StartObject);

            while (reader.TokenType != JsonToken.EndObject)
            {
                string propertyName = reader.ExpectAndAdvance<string>(JsonToken.PropertyName);
                switch (propertyName)
                {
                    case "FirstName":
                        author.FullName = serializer.Deserialize<string>(reader) + author.FullName;
                        break;

                    case "LastName":
                        string lastName = serializer.Deserialize<string>(reader);
                        string separator = string.IsNullOrWhiteSpace(lastName) ? string.Empty : " ";
                        author.FullName += separator + lastName;
                        break;

                    default:
                        // Ignore properties we don't understand.
                        break;
                }

                reader.Advance();
            }

            return author;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var author = (TAuthor)value;

            string[] names = author.FullName.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            string firstName = names.Length > 0 ? names[0] : string.Empty;
            string lastName = names.Length > 1 ? names[1] : string.Empty;

            writer.WriteStartObject();
            writer.WritePropertyName("FirstName");
            serializer.Serialize(writer, firstName);
            writer.WritePropertyName("LastName");
            serializer.Serialize(writer, lastName);
            writer.WriteEndObject();
        }
    }
}
