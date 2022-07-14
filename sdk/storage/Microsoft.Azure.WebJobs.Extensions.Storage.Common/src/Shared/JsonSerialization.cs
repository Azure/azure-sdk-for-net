// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Protocols
{
    /// <summary>Provides the standard <see cref="JsonSerializerSettings"/> used by protocol data.</summary>
    internal static class JsonSerialization
    {
        private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings()
        {
            // The default value, DateParseHandling.DateTime, drops time zone information from DateTimeOffets.
            // This value appears to work well with both DateTimes (without time zone information) and DateTimeOffsets.
            DateParseHandling = DateParseHandling.DateTimeOffset,
            NullValueHandling = NullValueHandling.Ignore,
            Formatting = Formatting.Indented,
            MaxDepth = Constants.MaxDepthDefault,
        };

        private static readonly JsonSerializer JsonSerializer = JsonSerializer.CreateDefault(JsonSerializerSettings);

        /// <summary>Gets the standard <see cref="JsonSerializerSettings"/> used by protocol data.</summary>
        public static JsonSerializerSettings Settings
        {
            get { return JsonSerializerSettings; }
        }

        internal static JsonSerializer Serializer
        {
            get { return JsonSerializer; }
        }

        internal static void ApplySettings(JsonReader reader, JsonSerializerSettings settings)
        {
            if (reader == null)
            {
                return;
            }

            reader.Culture = settings.Culture;
            reader.DateFormatString = settings.DateFormatString;
            reader.DateParseHandling = settings.DateParseHandling;
            reader.DateTimeZoneHandling = settings.DateTimeZoneHandling;
            reader.FloatParseHandling = settings.FloatParseHandling;
            reader.MaxDepth = settings.MaxDepth;
        }

        internal static void ApplySettings(JsonWriter writer, JsonSerializerSettings settings)
        {
            if (writer == null)
            {
                return;
            }

            writer.Culture = settings.Culture;
            writer.DateFormatHandling = settings.DateFormatHandling;
            writer.DateFormatString = settings.DateFormatString;
            writer.DateTimeZoneHandling = settings.DateTimeZoneHandling;
            writer.FloatFormatHandling = settings.FloatFormatHandling;
            writer.Formatting = settings.Formatting;
            writer.StringEscapeHandling = settings.StringEscapeHandling;
        }

        internal static JsonTextReader CreateJsonTextReader(TextReader reader, JsonSerializerSettings settings)
        {
            JsonTextReader jsonReader = new JsonTextReader(reader);
            ApplySettings(jsonReader, settings);
            return jsonReader;
        }

        internal static JsonTextWriter CreateJsonTextWriter(TextWriter textWriter, JsonSerializerSettings settings)
        {
            JsonTextWriter jsonWriter = new JsonTextWriter(textWriter);
            ApplySettings(jsonWriter, settings);
            return jsonWriter;
        }

        public static bool IsJsonObject(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            input = input.Trim();
            return (input.StartsWith("{", StringComparison.OrdinalIgnoreCase) && input.EndsWith("}", StringComparison.OrdinalIgnoreCase));
        }

        internal static JObject ParseJObject(string json, JsonSerializerSettings settings)
        {
            if (json == null)
            {
                throw new ArgumentNullException(nameof(json));
            }

            StringReader stringReader = null;
            try
            {
                stringReader = new StringReader(json);
                using (JsonTextReader jsonReader = CreateJsonTextReader(stringReader, settings))
                {
                    stringReader = null;
                    JObject parsed = null;
                    if (IsJsonObject(json))
                    {
                        parsed = JObject.Load(jsonReader);
                    }
                    else
                    {
                        return null;
                    }

                    // Behave as similarly to JObject.Parse as possible (except for the settings used).
                    if (jsonReader.Read() && jsonReader.TokenType != JsonToken.Comment)
                    {
                        throw new JsonReaderException("Invalid content found after JSON object.");
                    }

                    return parsed;
                }
            }
            finally
            {
                if (stringReader != null)
                {
                    stringReader.Dispose();
                }
            }
        }
    }
}
