// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// A collection of subject alternative names (SANs) for a X.509 certificate. SANs can be DNS entries, emails, or unique principal names.
    /// </summary>
    public class SubjectAlternativeNames : IEnumerable<string>, IJsonSerializable, IJsonDeserializable
    {
        private IEnumerable<string> _names;
        private JsonEncodedText _nameType;

        private const string DnsPropertyName = "dns_names";
        private const string EmailsPropertyName = "emails";
        private const string UpnsPropertyName = "upns";

        private static readonly JsonEncodedText s_dnsPropertyNameBytes = JsonEncodedText.Encode(DnsPropertyName);
        private static readonly JsonEncodedText s_emailsPropertyNameBytes = JsonEncodedText.Encode(EmailsPropertyName);
        private static readonly JsonEncodedText s_upnsPropertyNameBytes = JsonEncodedText.Encode(UpnsPropertyName);

        internal SubjectAlternativeNames()
        {
        }

        private SubjectAlternativeNames(JsonEncodedText nameType, IEnumerable<string> names)
        {
            _nameType = nameType;
            _names = names;
        }

        /// <summary>
        /// Creates a collection of subject alternative names (SANs) containing DNS names.
        /// </summary>
        /// <param name="names">The DNS entries.</param>
        /// <returns>A <see cref="SubjectAlternativeNames"/> of DNS entries.</returns>
        /// <exception cref="ArgumentException"><paramref name="names"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="names"/> is null.</exception>
        public static SubjectAlternativeNames FromDns(params string[] names)
        {
            Argument.AssertNotNullOrEmpty(names, nameof(names));

            return new SubjectAlternativeNames(s_dnsPropertyNameBytes, names);
        }

        /// <summary>
        /// Creates a collection of subject alternative names (SANs) containing DNS names.
        /// </summary>
        /// <param name="names">The DNS entries.</param>
        /// <returns>A <see cref="SubjectAlternativeNames"/> of DNS entries.</returns>
        /// <exception cref="ArgumentException"><paramref name="names"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="names"/> is null.</exception>
        public static SubjectAlternativeNames FromDns(IEnumerable<string> names)
        {
            Argument.AssertNotNullOrEmpty(names, nameof(names));

            return new SubjectAlternativeNames(s_dnsPropertyNameBytes, names);
        }

        /// <summary>
        /// Creates a collection of subject alternative names (SANs) containing email addresses.
        /// </summary>
        /// <param name="names">The email entries.</param>
        /// <returns>A <see cref="SubjectAlternativeNames"/> of email entries.</returns>
        /// <exception cref="ArgumentException"><paramref name="names"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="names"/> is null.</exception>
        public static SubjectAlternativeNames FromEmail(params string[] names)
        {
            Argument.AssertNotNullOrEmpty(names, nameof(names));

            return new SubjectAlternativeNames(s_emailsPropertyNameBytes, names);
        }

        /// <summary>
        /// Creates a collection of subject alternative names (SANs) containing email addresses.
        /// </summary>
        /// <param name="names">The email entries.</param>
        /// <returns>A <see cref="SubjectAlternativeNames"/> of email entries.</returns>
        /// <exception cref="ArgumentException"><paramref name="names"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="names"/> is null.</exception>
        public static SubjectAlternativeNames FromEmail(IEnumerable<string> names)
        {
            Argument.AssertNotNullOrEmpty(names, nameof(names));

            return new SubjectAlternativeNames(s_emailsPropertyNameBytes, names);
        }

        /// <summary>
        /// Creates a collection of subject alternative names (SANs) containing unique principal names (UPNs).
        /// </summary>
        /// <param name="names">The unique principal names (UPNs) entries.</param>
        /// <returns>A <see cref="SubjectAlternativeNames"/> of unique principal names (UPNs) entries.</returns>
        /// <exception cref="ArgumentException"><paramref name="names"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="names"/> is null.</exception>
        public static SubjectAlternativeNames FromUpn(params string[] names)
        {
            Argument.AssertNotNullOrEmpty(names, nameof(names));

            return new SubjectAlternativeNames(s_upnsPropertyNameBytes, names);
        }

        /// <summary>
        /// Creates a collection of subject alternative names (SANs) containing unique principal names (UPNs).
        /// </summary>
        /// <param name="names">The unique principal names (UPNs) entries.</param>
        /// <returns>A <see cref="SubjectAlternativeNames"/> of unique principal names (UPNs) entries.</returns>
        /// <exception cref="ArgumentException"><paramref name="names"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="names"/> is null.</exception>
        public static SubjectAlternativeNames FromUpn(IEnumerable<string> names)
        {
            Argument.AssertNotNullOrEmpty(names, nameof(names));

            return new SubjectAlternativeNames(s_upnsPropertyNameBytes, names);
        }

        /// <summary>
        /// Gets the subject alternative names (SANs) for this instance.
        /// </summary>
        /// <returns>The subject alternative names (SANs) for this instance.</returns>
        public IEnumerator<string> GetEnumerator()
        {
            return _names.GetEnumerator();
        }

        /// <summary>
        /// Gets the subject alternative names (SANs) for this instance.
        /// </summary>
        /// <returns>The subject alternative names (SANs) for this instance.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _names.GetEnumerator();
        }

        void IJsonDeserializable.ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case DnsPropertyName:
                        _nameType = s_dnsPropertyNameBytes;
                        break;

                    case EmailsPropertyName:
                        _nameType = s_emailsPropertyNameBytes;
                        break;

                    case UpnsPropertyName:
                        _nameType = s_upnsPropertyNameBytes;
                        break;

                    default:
                        continue;
                }

                List<string> altNames = new List<string>();

                foreach (JsonElement element in prop.Value.EnumerateArray())
                {
                    altNames.Add(element.ToString());
                }

                _names = altNames;

                break;
            }
        }

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json)
        {
            json.WriteStartArray(_nameType);

            foreach (string name in _names)
            {
                json.WriteStringValue(name);
            }

            json.WriteEndArray();
        }
    }
}
