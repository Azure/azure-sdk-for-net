// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using Newtonsoft.Json;
    using Serialization;

    internal class CustomBookConverter : ConverterBase
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(CustomBook);
        }

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

            var book = new CustomBook();

            ExpectAndAdvance(reader, JsonToken.StartObject);

            while (reader.TokenType != JsonToken.EndObject)
            {
                string propertyName = ExpectAndAdvance<string>(reader, JsonToken.PropertyName);
                switch (propertyName)
                {
                    case "ISBN":
                        book.InternationalStandardBookNumber = serializer.Deserialize<string>(reader);
                        break;

                    case "Title":
                        book.Name = serializer.Deserialize<string>(reader);
                        break;

                    case "Author":
                        book.AuthorName = serializer.Deserialize<string>(reader);
                        break;

                    case "PublishDate":
                        book.PublishDateTime = serializer.Deserialize<DateTime?>(reader);
                        break;

                    default:
                        // Ignore properties we don't understand.
                        break;
                }

                Advance(reader);
            }

            return book;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var book = (CustomBook)value;
            writer.WriteStartObject();
            writer.WritePropertyName("ISBN");
            serializer.Serialize(writer, book.InternationalStandardBookNumber);
            writer.WritePropertyName("Title");
            serializer.Serialize(writer, book.Name);
            writer.WritePropertyName("Author");
            serializer.Serialize(writer, book.AuthorName);
            writer.WritePropertyName("PublishDate");
            serializer.Serialize(writer, book.PublishDateTime);
            writer.WriteEndObject();
        }
    }
}
