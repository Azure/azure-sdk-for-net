// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// A policy that describes the conditions when a key can be exported.
    /// </summary>
    public class KeyReleasePolicy : IJsonDeserializable, IJsonSerializable
    {
        private const string ContentTypePropertyName = "contentType";
        private const string DataPropertyName = "data";

        private static readonly JsonEncodedText s_contentTypePropertyNameBytes = JsonEncodedText.Encode(ContentTypePropertyName);
        private static readonly JsonEncodedText s_dataPropertyNameBytes = JsonEncodedText.Encode(DataPropertyName);

        /// <summary>
        /// Creates a new instance of the <see cref="KeyReleasePolicy"/> class.
        /// </summary>
        /// <param name="data">The encoded release policy under which a key can be exported.</param>
        /// <exception cref="ArgumentNullException"><paramref name="data"/> is null.</exception>
        public KeyReleasePolicy(byte[] data)
        {
            Argument.AssertNotNull(data, nameof(data));

            Data = data;
        }

        internal KeyReleasePolicy()
        {
        }

        /// <summary>
        /// Gets or sets the content type and version of key release policy.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets the encoded release policy under which a key can be exported.
        /// </summary>
        public byte[] Data { get; internal set; }

        internal void ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case ContentTypePropertyName:
                        ContentType = prop.Value.GetString();
                        break;

                    case DataPropertyName:
                        Data = Base64Url.Decode(prop.Value.GetString());
                        break;
                }
            }
        }

       internal void WriteProperties(Utf8JsonWriter json)
        {
            if (ContentType != null)
            {
                json.WriteString(s_contentTypePropertyNameBytes, ContentType);
            }

            json.WriteString(s_dataPropertyNameBytes, Base64Url.Encode(Data));
        }

        void IJsonDeserializable.ReadProperties(JsonElement json) =>
            ReadProperties(json);

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json) =>
            WriteProperties(json);
    }
}
