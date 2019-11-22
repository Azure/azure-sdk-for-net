// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Threading;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// A collection of subject alternative names (SANs) for a X.509 certificate. SANs can be DNS entries, emails, or unique principal names.
    /// </summary>
    public class SubjectAlternativeNames : IJsonSerializable, IJsonDeserializable
    {
        private const string DnsPropertyName = "dns_names";
        private const string EmailsPropertyName = "emails";
        private const string UpnsPropertyName = "upns";

        private static readonly JsonEncodedText s_dnsPropertyNameBytes = JsonEncodedText.Encode(DnsPropertyName);
        private static readonly JsonEncodedText s_emailsPropertyNameBytes = JsonEncodedText.Encode(EmailsPropertyName);
        private static readonly JsonEncodedText s_upnsPropertyNameBytes = JsonEncodedText.Encode(UpnsPropertyName);

        private Collection<string> _dnsNames;
        private Collection<string> _emails;
        private Collection<string> _userPrincipalNames;

        /// <summary>
        /// Initializes a new instance of the <see cref="CertificateContact"/> class.
        /// </summary>
        public SubjectAlternativeNames()
        {
        }

        /// <summary>
        /// Gets a collection of DNS names.
        /// </summary>
        public IList<string> DnsNames => LazyInitializer.EnsureInitialized(ref _dnsNames);

        /// <summary>
        /// Gets a collection of email addresses.
        /// </summary>
        public IList<string> Emails => LazyInitializer.EnsureInitialized(ref _emails);

        /// <summary>
        /// Gets a collection of user principal names (UPNs).
        /// </summary>
        public IList<string> UserPrincipalNames => LazyInitializer.EnsureInitialized(ref _userPrincipalNames);

        internal bool IsEmpty => _dnsNames.IsNullOrEmpty() && _emails.IsNullOrEmpty() && _userPrincipalNames.IsNullOrEmpty();

        void IJsonDeserializable.ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case DnsPropertyName:
                        foreach (JsonElement element in prop.Value.EnumerateArray())
                        {
                            DnsNames.Add(element.ToString());
                        }
                        break;

                    case EmailsPropertyName:
                        foreach (JsonElement element in prop.Value.EnumerateArray())
                        {
                            Emails.Add(element.ToString());
                        }
                        break;

                    case UpnsPropertyName:
                        foreach (JsonElement element in prop.Value.EnumerateArray())
                        {
                            UserPrincipalNames.Add(element.ToString());
                        }
                        break;
                }
            }
        }

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json)
        {
            if (!_dnsNames.IsNullOrEmpty())
            {
                json.WriteStartArray(s_dnsPropertyNameBytes);
                foreach (string dnsName in _dnsNames)
                {
                    json.WriteStringValue(dnsName);
                }
                json.WriteEndArray();
            }

            if (!_emails.IsNullOrEmpty())
            {
                json.WriteStartArray(s_emailsPropertyNameBytes);
                foreach (string email in _emails)
                {
                    json.WriteStringValue(email);
                }
                json.WriteEndArray();
            }

            if (!_userPrincipalNames.IsNullOrEmpty())
            {
                json.WriteStartArray(s_upnsPropertyNameBytes);
                foreach (string userPrincipalName in _userPrincipalNames)
                {
                    json.WriteStringValue(userPrincipalName);
                }
                json.WriteEndArray();
            }
        }
    }
}
