// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// A certificate issuer used to sign certificates managed by Azure Key Vault
    /// </summary>
    public class Issuer : IssuerBase
    {
        internal Issuer() { }

        /// <summary>
        /// Creates an issuer with the specified name
        /// </summary>
        /// <param name="name">The name of the issuer</param>
        public Issuer(string name) : base(name)
        {
        }

        /// <summary>
        /// Well known issuer name for self signed certificates
        /// </summary>
        public static string Self => "self";

        /// <summary>
        /// Well known issuer name for certificates signed by the user with a private certificate authority
        /// </summary>
        public static string Unknown => "unknown";

        /// <summary>
        /// The account identifier or username used to authenticate to the certificate issuer
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// The password or key used to authenticate to the certificate issuer
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The organizational identifier for the issuer
        /// </summary>
        public string OrganizationId { get; set; }

        /// <summary>
        /// A list of contacts who administrate the certificate issuer account
        /// </summary>
        public IList<AdministratorDetails> Administrators { get; set; }

        /// <summary>
        /// The time the issuer was created in UTC
        /// </summary>
        public DateTimeOffset? Created { get; private set; }

        /// <summary>
        /// The last modified time of the issuer in UTC
        /// </summary>
        public DateTimeOffset? Updated { get; private set; }

        /// <summary>
        /// Specifies whether the issuer can currently be used to issue certificates
        /// </summary>
        public bool? Enabled { get; set; }

        private const string CredentialsPropertyName = "credentials";
        private const string OrgDetailsPropertyName = "org_details";
        private const string AttributesPropertyName = "attributes";

        internal override void ReadProperty(JsonProperty prop)
        {
            switch (prop.Name)
            {
                case CredentialsPropertyName:
                    ReadCredentialsProperties(prop.Value);
                    break;
                case OrgDetailsPropertyName:
                    ReadOrgDetailsProperties(prop.Value);
                    break;
                case AttributesPropertyName:
                    ReadAttributeProperties(prop.Value);
                    break;
                default:
                    base.ReadProperty(prop);
                    break;
            }
        }

        private const string AccountIdPropertyName = "account_id";
        private const string PasswordPropertyName = "pwd";

        private void ReadCredentialsProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case AccountIdPropertyName:
                        AccountId = prop.Value.GetString();
                        break;
                    case PasswordPropertyName:
                        Password = prop.Value.GetString();
                        break;
                }
            }
        }

        private const string OrganizationIdPropertyName = "id";
        private const string AdminDetailsPropertyName = "admin_details";

        private void ReadOrgDetailsProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case OrganizationIdPropertyName:
                        OrganizationId = prop.Value.GetString();
                        break;
                    case AdminDetailsPropertyName:
                        Administrators = new List<AdministratorDetails>();
                        foreach(JsonElement elem in prop.Value.EnumerateArray())
                        {
                            var admin = new AdministratorDetails();
                            admin.ReadProperties(elem);
                            Administrators.Add(admin);
                        }
                        Password = prop.Value.GetString();
                        break;
                }
            }
        }

        private const string CreatedPropertyName = "created";
        private const string UpdatedPropertyName = "updated";
        private const string EnabledPropertyName = "enabled";

        private void ReadAttributeProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case EnabledPropertyName:
                        Enabled = prop.Value.GetBoolean();
                        break;
                    case CreatedPropertyName:
                        Created = DateTimeOffset.FromUnixTimeSeconds(prop.Value.GetInt64());
                        break;
                    case UpdatedPropertyName:
                        Updated = DateTimeOffset.FromUnixTimeSeconds(prop.Value.GetInt64());
                        break;
                }
            }
        }

        private static readonly JsonEncodedText CredentialsPropertyNameBytes = JsonEncodedText.Encode(CredentialsPropertyName);
        private static readonly JsonEncodedText OrgDetailsPropertyNameBytes = JsonEncodedText.Encode(OrgDetailsPropertyName);
        private static readonly JsonEncodedText AttributesPropertyNameBytes = JsonEncodedText.Encode(AttributesPropertyName);
        private static readonly JsonEncodedText EnabledPropertyNameBytes = JsonEncodedText.Encode(EnabledPropertyName);

        internal override void WritePropertiesCore(Utf8JsonWriter json)
        {
            base.WritePropertiesCore(json);

            if(!string.IsNullOrEmpty(AccountId) || !string.IsNullOrEmpty(Password))
            {
                json.WriteStartObject(CredentialsPropertyNameBytes);

                WriteCredentialsProperties(json);

                json.WriteEndObject();
            }

            if (!string.IsNullOrEmpty(OrganizationId) || Administrators != null)
            {
                json.WriteStartObject(OrgDetailsPropertyNameBytes);

                WriteOrgDetailsProperties(json);

                json.WriteEndObject();
            }

            if (Enabled.HasValue)
            {
                json.WriteStartObject(AttributesPropertyNameBytes);

                json.WriteBoolean(EnabledPropertyNameBytes, Enabled.Value);

                json.WriteEndObject();
            }
        }

        private static readonly JsonEncodedText AccountIdPropertyNameBytes = JsonEncodedText.Encode(AccountIdPropertyName);
        private static readonly JsonEncodedText PasswordPropertyNameBytes = JsonEncodedText.Encode(PasswordPropertyName);

        private void WriteCredentialsProperties(Utf8JsonWriter json)
        {
            if(!string.IsNullOrEmpty(AccountId))
            {
                json.WriteString(AccountIdPropertyNameBytes, AccountId);
            }

            if (!string.IsNullOrEmpty(Password))
            {
                json.WriteString(PasswordPropertyNameBytes, Password);
            }
        }

        private static readonly JsonEncodedText OrganizationIdPropertyNameBytes = JsonEncodedText.Encode(OrganizationIdPropertyName);
        private static readonly JsonEncodedText AdminDetailsPropertyNameBytes = JsonEncodedText.Encode(AdminDetailsPropertyName);

        private void WriteOrgDetailsProperties(Utf8JsonWriter json)
        {
            if (!string.IsNullOrEmpty(OrganizationId))
            {
                json.WriteString(OrganizationIdPropertyNameBytes, AccountId);
            }

            if (Administrators != null)
            {
                json.WriteStartArray(AdminDetailsPropertyNameBytes);

                foreach(var admin in Administrators)
                {
                    json.WriteStartObject();

                    admin.WriteProperties(json);

                    json.WriteEndObject();
                }

                json.WriteEndArray();
            }
        }
    }

}
