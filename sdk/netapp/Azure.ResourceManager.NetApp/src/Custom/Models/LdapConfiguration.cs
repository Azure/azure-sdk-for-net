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

namespace Azure.ResourceManager.NetApp.Models
{
    // The 2026 TypeSpec model removed the legacy LDAP account wrapper.
    // Preserve the shipped constructor/property shape for source compatibility.
    /// <summary> LDAP configuration. </summary>
    public partial class LdapConfiguration : IJsonModel<LdapConfiguration>, IPersistableModel<LdapConfiguration>
    {
        /// <summary> Initializes a new instance of <see cref="LdapConfiguration"/>. </summary>
        public LdapConfiguration()
        {
            LdapServers = new ChangeTrackingList<IPAddress>();
            DnsServers = new ChangeTrackingList<IPAddress>();
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

        protected virtual LdapConfiguration PersistableModelCreateCore(System.BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<LdapConfiguration>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeLdapConfiguration(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(LdapConfiguration)} does not support reading '{options.Format}' format.");
            }
        }

        protected virtual System.BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<LdapConfiguration>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerNetAppContext.Default);
                default:
                    throw new FormatException($"The model {nameof(LdapConfiguration)} does not support writing '{options.Format}' format.");
            }
        }

        LdapConfiguration IPersistableModel<LdapConfiguration>.Create(System.BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        string IPersistableModel<LdapConfiguration>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        System.BinaryData IPersistableModel<LdapConfiguration>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        void IJsonModel<LdapConfiguration>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        LdapConfiguration IJsonModel<LdapConfiguration>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<LdapConfiguration>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(LdapConfiguration)} does not support writing '{format}' format.");
            }
            if (Optional.IsDefined(Domain))
            {
                writer.WritePropertyName("domain"u8);
                writer.WriteStringValue(Domain);
            }
            if (Optional.IsCollectionDefined(LdapServers))
            {
                writer.WritePropertyName("ldapServers"u8);
                writer.WriteStartArray();
                foreach (IPAddress item in LdapServers)
                {
                    writer.WriteStringValue(item?.ToString());
                }
                writer.WriteEndArray();
            }
            SecureLdapType? secureLdapType = SecureLdapType;
            if (!Optional.IsDefined(secureLdapType) && Optional.IsDefined(IsLdapOverTlsEnabled))
            {
                secureLdapType = IsLdapOverTlsEnabled.Value ? global::Azure.ResourceManager.NetApp.Models.SecureLdapType.LdapOverTls : global::Azure.ResourceManager.NetApp.Models.SecureLdapType.None;
            }
            if (Optional.IsDefined(secureLdapType))
            {
                writer.WritePropertyName("secureLdapType"u8);
                writer.WriteStringValue(secureLdapType.Value.ToString());
            }
            if (Optional.IsDefined(ServerCACertificate))
            {
                writer.WritePropertyName("serverCACertificate"u8);
                writer.WriteStringValue(ServerCACertificate);
            }
            if (Optional.IsDefined(CertificateCNHost))
            {
                writer.WritePropertyName("certificateCNHost"u8);
                writer.WriteStringValue(CertificateCNHost);
            }
            if (Optional.IsCollectionDefined(DnsServers))
            {
                writer.WritePropertyName("dnsServers"u8);
                writer.WriteStartArray();
                foreach (IPAddress item in DnsServers)
                {
                    writer.WriteStringValue(item?.ToString());
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(LdapPort))
            {
                writer.WritePropertyName("ldapPort"u8);
                writer.WriteNumberValue(LdapPort.Value);
            }
            if (Optional.IsDefined(UserDN))
            {
                writer.WritePropertyName("userDN"u8);
                writer.WriteStringValue(UserDN);
            }
            if (Optional.IsDefined(GroupDN))
            {
                writer.WritePropertyName("groupDN"u8);
                writer.WriteStringValue(GroupDN);
            }
            if (Optional.IsDefined(NetGroupDN))
            {
                writer.WritePropertyName("netGroupDN"u8);
                writer.WriteStringValue(NetGroupDN);
            }
            if (Optional.IsDefined(BindAuthenticationLevel))
            {
                writer.WritePropertyName("bindAuthenticationLevel"u8);
                writer.WriteStringValue(BindAuthenticationLevel.Value.ToString());
            }
            if (Optional.IsDefined(BindDN))
            {
                writer.WritePropertyName("bindDN"u8);
                writer.WriteStringValue(BindDN);
            }
            if (Optional.IsDefined(BindPasswordAkvConfig))
            {
                writer.WritePropertyName("bindPasswordAkvConfig"u8);
                writer.WriteObjectValue(BindPasswordAkvConfig, options);
            }
            if (options.Format != "W" && _additionalBinaryDataProperties != null)
            {
                foreach (var item in _additionalBinaryDataProperties)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
                    writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        protected virtual LdapConfiguration JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<LdapConfiguration>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(LdapConfiguration)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeLdapConfiguration(document.RootElement, options);
        }
    }
}
