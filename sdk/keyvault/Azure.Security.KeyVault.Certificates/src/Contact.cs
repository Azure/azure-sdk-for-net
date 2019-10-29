// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// A contact for certificate management issues for a key vault
    /// </summary>
    public class Contact : IJsonDeserializable, IJsonSerializable
    {
        private const string NamePropertyName = "name";
        private const string EmailPropertyName = "email";
        private const string PhonePropertyName = "phone";

        private static readonly JsonEncodedText s_namePropertyNameBytes = JsonEncodedText.Encode(NamePropertyName);
        private static readonly JsonEncodedText s_emailPropertyNameBytes = JsonEncodedText.Encode(EmailPropertyName);
        private static readonly JsonEncodedText s_phonePropertyNameBytes = JsonEncodedText.Encode(PhonePropertyName);

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

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json)
        {
            if (!string.IsNullOrEmpty(Name))
            {
                json.WriteString(s_namePropertyNameBytes, Name);
            }

            if (!string.IsNullOrEmpty(Email))
            {
                json.WriteString(s_emailPropertyNameBytes, Email);
            }

            if (!string.IsNullOrEmpty(Phone))
            {
                json.WriteString(s_phonePropertyNameBytes, Phone);
            }
        }
    }
}
