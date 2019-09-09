// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    public class AdministratorDetails
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        private const string FirstNamePropertyName = "first_name";
        private const string LastNamePropertyName = "last_name";
        private const string EmailPropertyName = "email";
        private const string PhonePropertyName = "phone";

        internal void ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case FirstNamePropertyName:
                        FirstName = prop.Value.GetString();
                        break;
                    case LastNamePropertyName:
                        LastName = prop.Value.GetString();
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

        private static readonly JsonEncodedText FirstNamePropertyNameBytes = JsonEncodedText.Encode(FirstNamePropertyName);
        private static readonly JsonEncodedText LastNamePropertyNameBytes = JsonEncodedText.Encode(LastNamePropertyName);
        private static readonly JsonEncodedText EmailPropertyNameBytes = JsonEncodedText.Encode(EmailPropertyName);
        private static readonly JsonEncodedText PhonePropertyNameBytes = JsonEncodedText.Encode(PhonePropertyName);

        internal void WriteProperties(Utf8JsonWriter json)
        {
            if (!string.IsNullOrEmpty(FirstName))
            {
                json.WriteString(FirstNamePropertyNameBytes, FirstName);
            }

            if (!string.IsNullOrEmpty(LastName))
            {
                json.WriteString(LastNamePropertyNameBytes, LastName);
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
