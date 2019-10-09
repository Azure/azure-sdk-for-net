// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// Details of an administrator of a certificate <see cref="Issuer"/>
    /// </summary>
    public class AdministratorDetails
    {
        /// <summary>
        /// The email address of the administrator
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The first name of the administrator
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the administrator
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The phone number of the administrator
        /// </summary>
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

        private static readonly JsonEncodedText s_firstNamePropertyNameBytes = JsonEncodedText.Encode(FirstNamePropertyName);
        private static readonly JsonEncodedText s_lastNamePropertyNameBytes = JsonEncodedText.Encode(LastNamePropertyName);
        private static readonly JsonEncodedText s_emailPropertyNameBytes = JsonEncodedText.Encode(EmailPropertyName);
        private static readonly JsonEncodedText s_phonePropertyNameBytes = JsonEncodedText.Encode(PhonePropertyName);

        internal void WriteProperties(Utf8JsonWriter json)
        {
            if (!string.IsNullOrEmpty(FirstName))
            {
                json.WriteString(s_firstNamePropertyNameBytes, FirstName);
            }

            if (!string.IsNullOrEmpty(LastName))
            {
                json.WriteString(s_lastNamePropertyNameBytes, LastName);
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
