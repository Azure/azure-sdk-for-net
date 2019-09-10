﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// A collection of subject alternative names (SANs) for a x509 certificate. SANs can be DNS entries, emails, or unique prinicpal names.
    /// </summary>
    public class SubjectAlternativeNames : IEnumerable<string>, IJsonSerializable, IJsonDeserializable
    {
        private IEnumerable<string> _names;
        private JsonEncodedText _nameType;

        private const string DnsPropertyName = "dns_names";
        private static readonly JsonEncodedText DnsPropertyNameBytes = JsonEncodedText.Encode(DnsPropertyName);
        private const string EmailsPropertyName = "emails";
        private static readonly JsonEncodedText EmailsPropertyNameBytes = JsonEncodedText.Encode(EmailsPropertyName);
        private const string UpnsPropertyName = "upns";
        private static readonly JsonEncodedText UpnsPropertyNameBytes = JsonEncodedText.Encode(UpnsPropertyName);

        internal SubjectAlternativeNames()
        {
        }

        private SubjectAlternativeNames(JsonEncodedText nameType, IEnumerable<string> names)
        {
            _nameType = nameType;
            _names = names;
        }

        /// <summary>
        /// Creates a collection of DNS subject alternative names (SANs)
        /// </summary>
        /// <param name="names">The SAN entries</param>
        /// <returns>The created subject alternative name collection</returns>
        public static SubjectAlternativeNames FromDns(params string[] names)
        {
            if (names == null) throw new ArgumentNullException(nameof(names));

            if (names.Length == 0) throw new ArgumentException("The specified names must be non-null and non-empty");

            return new SubjectAlternativeNames(DnsPropertyNameBytes, names);
        }

        /// <summary>
        /// Creates a collection of DNS subject alternative names (SANs)
        /// </summary>
        /// <param name="names">The SAN entries</param>
        /// <returns>The created subject alternative name collection</returns>
        public static SubjectAlternativeNames FromDns(IEnumerable<string> names)
        {
            if (names == null) throw new ArgumentNullException(nameof(names));

            if (!names.Any()) throw new ArgumentException("The specified names must be non-null and non-empty");

            return new SubjectAlternativeNames(DnsPropertyNameBytes, names);
        }

        /// <summary>
        /// Creates a collection of email subject alternative names (SANs)
        /// </summary>
        /// <param name="names">The SAN entries</param>
        /// <returns>The created subject alternative name collection</returns>
        public static SubjectAlternativeNames FromEmail(params string[] names)
        {
            if (names == null) throw new ArgumentNullException(nameof(names));

            if (names.Length == 0) throw new ArgumentException("The specified names must be non-null and non-empty");

            return new SubjectAlternativeNames(EmailsPropertyNameBytes, names);
        }

        /// <summary>
        /// Creates a collection of email subject alternative names (SANs)
        /// </summary>
        /// <param name="names">The SAN entries</param>
        /// <returns>The created subject alternative name collection</returns>
        public static SubjectAlternativeNames FromEmail(IEnumerable<string> names)
        {
            if (names == null) throw new ArgumentNullException(nameof(names));

            if (!names.Any()) throw new ArgumentException("The specified names must be non-null and non-empty");

            return new SubjectAlternativeNames(EmailsPropertyNameBytes, names);
        }

        /// <summary>
        /// Creates a collection of unique principal name (UPN) subject alternative names (SANs)
        /// </summary>
        /// <param name="names">The SAN entries</param>
        /// <returns>The created subject alternative name collection</returns>
        public static SubjectAlternativeNames FromUpn(params string[] names)
        {
            if (names == null) throw new ArgumentNullException(nameof(names));

            if (names.Length == 0) throw new ArgumentException("The specified names must be non-null and non-empty");

            return new SubjectAlternativeNames(UpnsPropertyNameBytes, names);
        }

        /// <summary>
        /// Creates a collection of unique principal name (UPN) subject alternative names (SANs)
        /// </summary>
        /// <param name="names">The SAN entries</param>
        /// <returns>The created subject alternative name collection</returns>
        public static SubjectAlternativeNames FromUpn(IEnumerable<string> names)
        {
            if (names == null) throw new ArgumentNullException(nameof(names));

            if (!names.Any()) throw new ArgumentException("The specified names must be non-null and non-empty");

            return new SubjectAlternativeNames(UpnsPropertyNameBytes, names);
        }

        /// <summary>
        /// Gets an enumerator for the SAN collection
        /// </summary>
        /// <returns>The created enumerator</returns>
        public IEnumerator<string> GetEnumerator()
        {
            return _names.GetEnumerator();
        }

        /// <summary>
        /// Gets an enumerator for the SAN collection
        /// </summary>
        /// <returns>The created enumerator</returns>
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
                        _nameType = DnsPropertyNameBytes;
                        break;
                    case EmailsPropertyName:
                        _nameType = EmailsPropertyNameBytes;
                        break;
                    case UpnsPropertyName:
                        _nameType = UpnsPropertyNameBytes;
                        break;
                    default:
                        continue;
                }

                List<string> altNames = new List<string>();

                foreach (var element in prop.Value.EnumerateArray())
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
