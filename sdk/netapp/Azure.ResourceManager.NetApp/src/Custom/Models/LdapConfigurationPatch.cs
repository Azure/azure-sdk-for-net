// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    // The 2026 TypeSpec model removed the legacy LDAP patch wrapper.
    // Preserve the shipped constructor/property shape for source compatibility.
    /// <summary> LDAP configuration patch. </summary>
    public partial class LdapConfigurationPatch : IJsonModel<LdapConfigurationPatch>, IPersistableModel<LdapConfigurationPatch>
    {
        /// <summary> Initializes a new instance of <see cref="LdapConfigurationPatch"/>. </summary>
        public LdapConfigurationPatch()
        {
            LdapServers = new ChangeTrackingList<IPAddress>();
        }

        /// <summary> The certificate CN host. </summary>
        public string CertificateCNHost { get; set; }

        /// <summary> The LDAP domain. </summary>
        public string Domain { get; set; }

        /// <summary> Indicates whether LDAP over TLS is enabled. </summary>
        public bool? IsLdapOverTlsEnabled { get; set; }

        /// <summary> The LDAP servers. </summary>
        public IList<IPAddress> LdapServers { get; }

        /// <summary> The server CA certificate. </summary>
        public string ServerCACertificate { get; set; }

        protected virtual LdapConfigurationPatch PersistableModelCreateCore(System.BinaryData data, ModelReaderWriterOptions options)
        {
            var reader = new Utf8JsonReader(data.ToArray());
            return JsonModelCreateCore(ref reader, options);
        }

        protected virtual System.BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            return BinaryData.FromString("{}");
        }

        LdapConfigurationPatch IPersistableModel<LdapConfigurationPatch>.Create(System.BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        string IPersistableModel<LdapConfigurationPatch>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        System.BinaryData IPersistableModel<LdapConfigurationPatch>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        void IJsonModel<LdapConfigurationPatch>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        LdapConfigurationPatch IJsonModel<LdapConfigurationPatch>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
        }

        protected virtual LdapConfigurationPatch JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            return new LdapConfigurationPatch();
        }
    }
}
