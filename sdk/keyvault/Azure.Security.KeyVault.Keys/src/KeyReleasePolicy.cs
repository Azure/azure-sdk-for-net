// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// The policy rules under which the key can be exported.
    /// </summary>
    public class KeyReleasePolicy : IJsonSerializable, IJsonDeserializable
    {
        private const string ContentTypePropertyName = "contentType";
        private const string DataPropertyName = "data";

        private static readonly JsonEncodedText s_contentTypePropertyNameBytes = JsonEncodedText.Encode(ContentTypePropertyName);
        private static readonly JsonEncodedText s_dataPropertyNameBytes = JsonEncodedText.Encode(DataPropertyName);

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyReleasePolicy"/> class.
        /// </summary>
        /// <param name="data">The blob-encoded policy rules under which the key can be released.</param>
        /// <exception cref="ArgumentNullException"><paramref name="data"/> is null.</exception>
        public KeyReleasePolicy(byte[] data)
        {
            Argument.AssertNotNull(data, nameof(data));
            Data = data;
        }

        /// <summary>
        /// Gets or sets the content type and version of key release policy.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets the blob-encoded policy rules under which the key can be released.
        /// </summary>
        public byte[] Data { get; private set; }

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
            if (!string.IsNullOrEmpty(ContentType))
            {
                json.WriteString(s_contentTypePropertyNameBytes, ContentType);
            }

            json.WriteString(s_dataPropertyNameBytes, Base64Url.Encode(Data));
        }

        void IJsonDeserializable.ReadProperties(JsonElement json) => ReadProperties(json);

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json) => WriteProperties(json);
    }
}
