// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    internal class ContactList : IJsonDeserializable, IJsonSerializable
    {
        private const string ContactsPropertyName = "contacts";

        private static readonly JsonEncodedText s_contactsPropertyNameBytes = JsonEncodedText.Encode(ContactsPropertyName);

        private IEnumerable<CertificateContact> _contacts;

        public ContactList()
        {
        }

        public ContactList(IEnumerable<CertificateContact> contacts)
        {
            _contacts = contacts;
        }

        public IList<CertificateContact> ToList()
        {
            if (!(_contacts is IList<CertificateContact> ret))
            {
                ret = _contacts.ToList();

                _contacts = ret;
            }

            return ret;
        }

        void IJsonDeserializable.ReadProperties(JsonElement json)
        {
            var contacts = new List<CertificateContact>();

            if (json.TryGetProperty(ContactsPropertyName, out JsonElement contactsElement))
            {
                foreach (JsonElement entry in contactsElement.EnumerateArray())
                {
                    var contact = new CertificateContact();

                    ((IJsonDeserializable)contact).ReadProperties(entry);

                    contacts.Add(contact);
                }
            }

            _contacts = contacts;
        }

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json)
        {
            if (_contacts != null)
            {
                json.WriteStartArray(s_contactsPropertyNameBytes);

                foreach (CertificateContact contact in _contacts)
                {
                    json.WriteStartObject();

                    ((IJsonSerializable)contact).WriteProperties(json);

                    json.WriteEndObject();
                }

                json.WriteEndArray();
            }
        }
    }
}
