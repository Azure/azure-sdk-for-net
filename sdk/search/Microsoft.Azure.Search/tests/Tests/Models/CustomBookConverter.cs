// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using Newtonsoft.Json;
    using Serialization;

    internal class CustomBookConverter<TBook, TAuthor> : JsonConverter
        where TBook : CustomBookBase<TAuthor>, new()
        where TAuthor : CustomAuthor
    {
        public void Install(ISearchIndexClient client)
        {
            client.SerializationSettings.Converters.Add(this);
            client.DeserializationSettings.Converters.Add(this);
        }

        public override bool CanConvert(Type objectType) => objectType == typeof(TBook);

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

            var book = new TBook();

            reader.ExpectAndAdvance(JsonToken.StartObject);

            while (reader.TokenType != JsonToken.EndObject)
            {
                string propertyName = reader.ExpectAndAdvance<string>(JsonToken.PropertyName);
                switch (propertyName)
                {
                    case "ISBN":
                        book.InternationalStandardBookNumber = serializer.Deserialize<string>(reader);
                        break;

                    case "Title":
                        book.Name = serializer.Deserialize<string>(reader);
                        break;

                    case "Author":
                        book.AuthorName = serializer.Deserialize<TAuthor>(reader);
                        break;

                    case "PublishDate":
                        book.PublishDateTime = serializer.Deserialize<DateTime?>(reader);
                        break;

                    default:
                        // Ignore properties we don't understand.
                        break;
                }

                reader.Advance();
            }

            return book;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var book = (TBook)value;
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
