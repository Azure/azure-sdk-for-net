// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using Azure.Core;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// A certificate issuer used to sign certificates managed by Azure Key Vault.
    /// </summary>
    public class CertificateIssuer : IJsonDeserializable, IJsonSerializable
    {
        private const string CredentialsPropertyName = "credentials";
        private const string OrgDetailsPropertyName = "org_details";
        private const string AttributesPropertyName = "attributes";
        private const string AccountIdPropertyName = "account_id";
        private const string PasswordPropertyName = "pwd";
        private const string OrganizationIdPropertyName = "id";
        private const string AdminDetailsPropertyName = "admin_details";
        private const string CreatedPropertyName = "created";
        private const string UpdatedPropertyName = "updated";
        private const string EnabledPropertyName = "enabled";

        private static readonly JsonEncodedText s_credentialsPropertyNameBytes = JsonEncodedText.Encode(CredentialsPropertyName);
        private static readonly JsonEncodedText s_orgDetailsPropertyNameBytes = JsonEncodedText.Encode(OrgDetailsPropertyName);
        private static readonly JsonEncodedText s_attributesPropertyNameBytes = JsonEncodedText.Encode(AttributesPropertyName);
        private static readonly JsonEncodedText s_enabledPropertyNameBytes = JsonEncodedText.Encode(EnabledPropertyName);
        private static readonly JsonEncodedText s_accountIdPropertyNameBytes = JsonEncodedText.Encode(AccountIdPropertyName);
        private static readonly JsonEncodedText s_passwordPropertyNameBytes = JsonEncodedText.Encode(PasswordPropertyName);
        private static readonly JsonEncodedText s_organizationIdPropertyNameBytes = JsonEncodedText.Encode(OrganizationIdPropertyName);
        private static readonly JsonEncodedText s_adminDetailsPropertyNameBytes = JsonEncodedText.Encode(AdminDetailsPropertyName);

        private List<AdministratorContact> _administratorContacts;
        private IssuerProperties _properties;

        internal CertificateIssuer(IssuerProperties properties = null)
        {
            _properties = properties ?? new IssuerProperties();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CertificateIssuer"/> class.
        /// You can use this constructor to initialize a <see cref="CertificateIssuer"/> for
        /// <see cref="CertificateClient.UpdateIssuer(CertificateIssuer, CancellationToken)"/> or
        /// <see cref="CertificateClient.UpdateIssuerAsync(CertificateIssuer, CancellationToken)"/>.
        /// </summary>
        /// <param name="name">The name of the issuer, including values from <see cref="WellKnownIssuerNames"/>.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        public CertificateIssuer(string name)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            _properties = new IssuerProperties(name);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CertificateIssuer"/> class.
        /// You can use this constructor to initialize a <see cref="CertificateIssuer"/> for
        /// <see cref="CertificateClient.CreateIssuer(CertificateIssuer, CancellationToken)"/> or
        /// <see cref="CertificateClient.CreateIssuerAsync(CertificateIssuer, CancellationToken)"/>.
        /// </summary>
        /// <param name="name">The name of the issuer, including values from <see cref="WellKnownIssuerNames"/>.</param>
        /// <param name="provider">The provider name of the certificate issuer.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> or <paramref name="provider"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> or <paramref name="provider"/> is null.</exception>
        public CertificateIssuer(string name, string provider)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(provider, nameof(provider));

            _properties = new IssuerProperties(name)
            {
                Provider = provider,
            };
        }

        /// <summary>
        /// Gets the unique identifier of the certificate issuer.
        /// </summary>
        public Uri Id => _properties.Id;

        /// <summary>
        /// Gets the name of the certificate issuer.
        /// </summary>
        public string Name => _properties.Name;

        /// <summary>
        /// Gets or sets the provider name of the certificate issuer.
        /// </summary>
        public string Provider => _properties.Provider;

        /// <summary>
        /// Gets or sets the account identifier or username used to authenticate to the certificate issuer.
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// Gets or sets the password or key used to authenticate to the certificate issuer.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the organizational identifier for the issuer.
        /// </summary>
        public string OrganizationId { get; set; }

        /// <summary>
        /// Gets a list of contacts who administer the certificate issuer account.
        /// </summary>
        public IList<AdministratorContact> AdministratorContacts => LazyInitializer.EnsureInitialized(ref _administratorContacts);

        /// <summary>
        /// Gets a <see cref="DateTimeOffset"/> indicating when the certificate was created.
        /// </summary>
        public DateTimeOffset? CreatedOn { get; internal set; }

        /// <summary>
        /// Gets a <see cref="DateTimeOffset"/> indicating when the certificate was updated.
        /// </summary>
        public DateTimeOffset? UpdatedOn { get; internal set; }

        /// <summary>
        /// Gets or sets a value indicating whether the issuer can currently be used to issue certificates. If null, the server default will be used.
        /// </summary>
        public bool? Enabled { get; set; }

        internal virtual void ReadProperty(JsonProperty prop)
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
                    _properties.ReadProperty(prop);
                    break;
            }
        }

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
                        foreach (JsonElement elem in prop.Value.EnumerateArray())
                        {
                            var admin = new AdministratorContact();
                            admin.ReadProperties(elem);
                            AdministratorContacts.Add(admin);
                        }
                        break;
                }
            }
        }

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
                        CreatedOn = DateTimeOffset.FromUnixTimeSeconds(prop.Value.GetInt64());
                        break;

                    case UpdatedPropertyName:
                        UpdatedOn = DateTimeOffset.FromUnixTimeSeconds(prop.Value.GetInt64());
                        break;
                }
            }
        }

        internal virtual void WriteProperties(Utf8JsonWriter json)
        {
            _properties.WriteProperties(json);

            if (!string.IsNullOrEmpty(AccountId) || !string.IsNullOrEmpty(Password))
            {
                json.WriteStartObject(s_credentialsPropertyNameBytes);

                WriteCredentialsProperties(json);

                json.WriteEndObject();
            }

            if (!string.IsNullOrEmpty(OrganizationId) || !_administratorContacts.IsNullOrEmpty())
            {
                json.WriteStartObject(s_orgDetailsPropertyNameBytes);

                WriteOrgDetailsProperties(json);

                json.WriteEndObject();
            }

            if (Enabled.HasValue)
            {
                json.WriteStartObject(s_attributesPropertyNameBytes);

                json.WriteBoolean(s_enabledPropertyNameBytes, Enabled.Value);

                json.WriteEndObject();
            }
        }

        private void WriteCredentialsProperties(Utf8JsonWriter json)
        {
            if (!string.IsNullOrEmpty(AccountId))
            {
                json.WriteString(s_accountIdPropertyNameBytes, AccountId);
            }

            if (!string.IsNullOrEmpty(Password))
            {
                json.WriteString(s_passwordPropertyNameBytes, Password);
            }
        }

        private void WriteOrgDetailsProperties(Utf8JsonWriter json)
        {
            if (!string.IsNullOrEmpty(OrganizationId))
            {
                json.WriteString(s_organizationIdPropertyNameBytes, AccountId);
            }

            if (!_administratorContacts.IsNullOrEmpty())
            {
                json.WriteStartArray(s_adminDetailsPropertyNameBytes);

                foreach (AdministratorContact admin in _administratorContacts)
                {
                    json.WriteStartObject();

                    admin.WriteProperties(json);

                    json.WriteEndObject();
                }

                json.WriteEndArray();
            }
        }

        void IJsonDeserializable.ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                ReadProperty(prop);
            }
        }

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json) => WriteProperties(json);
    }
}
