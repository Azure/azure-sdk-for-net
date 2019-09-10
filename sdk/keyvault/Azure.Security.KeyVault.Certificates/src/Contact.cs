// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// A contact for certificate management issues for a key vault
    /// </summary>
    public class Contact : IJsonDeserializable, IJsonSerializable
    {
        /// <summary>
        /// Email address of the contact
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Name of the contact
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Phone number of the contact
        /// </summary>
        public string Phone { get; set; }

        private const string NamePropertyName = "name";
        private const string EmailPropertyName = "email";
        private const string PhonePropertyName = "phone";

        void IJsonDeserializable.ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case NamePropertyName:
                        Name = prop.Value.GetString();
                        break;
                    case EmailPropertyName:
                        Email = prop.Value.GetString();
                        break;
                    case PhonePropertyName:
                        Phone = prop.Value.GetString();
                        break;
                }
            }
        }

        private static readonly JsonEncodedText NamePropertyNameBytes = JsonEncodedText.Encode(NamePropertyName);
        private static readonly JsonEncodedText EmailPropertyNameBytes = JsonEncodedText.Encode(EmailPropertyName);
        private static readonly JsonEncodedText PhonePropertyNameBytes = JsonEncodedText.Encode(PhonePropertyName);

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json)
        {
            if (!string.IsNullOrEmpty(Name))
            {
                json.WriteString(NamePropertyNameBytes, Name);
            }

            if (!string.IsNullOrEmpty(Email))
            {
                json.WriteString(EmailPropertyNameBytes, Email);
            }

            if (!string.IsNullOrEmpty(Phone))
            {
                json.WriteString(PhonePropertyNameBytes, Phone);
            }
        }
    }
}
