// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.ResourceManager.NetApp.Models;

namespace Azure.ResourceManager.NetApp
{
    [ModelReaderWriterBuildable(typeof(EntraIdConfig))]
    [ModelReaderWriterBuildable(typeof(EntraIdConfigPatch))]
    [ModelReaderWriterBuildable(typeof(EntraIdAkvConfig))]
    [ModelReaderWriterBuildable(typeof(EntraIdAkvConfigPatch))]
    public partial class AzureResourceManagerNetAppContext
    {
    }

    // The 2026 TypeSpec model removed the legacy account-level Entra ID and LDAP
    // configuration objects. Preserve the old public properties for source compat.
    public partial class NetAppAccountData
    {
        /// <summary> Entra ID configuration. </summary>
        public EntraIdConfig EntraIdConfig
        {
            get => Properties is null ? default : Properties.EntraIdConfig;
            set
            {
                if (Properties is null)
                {
                    Properties = new AccountProperties();
                }
                Properties.EntraIdConfig = value;
            }
        }

        /// <summary> LDAP configuration. </summary>
        public LdapConfiguration LdapConfiguration
        {
            get => Properties is null ? default : Properties.LdapConfiguration;
            set
            {
                if (Properties is null)
                {
                    Properties = new AccountProperties();
                }
                Properties.LdapConfiguration = value;
            }
        }
    }
}

namespace Azure.ResourceManager.NetApp.Models
{
    // The stable 2026-09-01 AccountProperties has no Entra ID member; hold the value client-side
    // so NetAppAccountData.EntraIdConfig keeps working.
    internal partial class AccountProperties
    {
        public EntraIdConfig EntraIdConfig { get; set; }

        // Custom serialization replaces the generated members so entraIdConfig is read and written on the wire.
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AccountProperties>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AccountProperties)} does not support writing '{format}' format.");
            }
            if (options.Format != "W" && Optional.IsDefined(ProvisioningState))
            {
                writer.WritePropertyName("provisioningState"u8);
                writer.WriteStringValue(ProvisioningState);
            }
            if (Optional.IsCollectionDefined(ActiveDirectories))
            {
                writer.WritePropertyName("activeDirectories"u8);
                writer.WriteStartArray();
                foreach (NetAppAccountActiveDirectory item in ActiveDirectories)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(Encryption))
            {
                writer.WritePropertyName("encryption"u8);
                writer.WriteObjectValue(Encryption, options);
            }
            if (options.Format != "W" && Optional.IsDefined(DisableShowmount, _disableShowmountIsDefined))
            {
                if (DisableShowmount != null)
                {
                    writer.WritePropertyName("disableShowmount"u8);
                    writer.WriteBooleanValue(DisableShowmount.Value);
                }
                else
                {
                    writer.WriteNull("disableShowmount"u8);
                }
            }
            if (Optional.IsDefined(NfsV4IdDomain, _nfsV4IdDomainIsDefined))
            {
                if (NfsV4IdDomain != null)
                {
                    writer.WritePropertyName("nfsV4IDDomain"u8);
                    writer.WriteStringValue(NfsV4IdDomain);
                }
                else
                {
                    writer.WriteNull("nfsV4IDDomain"u8);
                }
            }
            if (options.Format != "W" && Optional.IsDefined(MultiAdStatus))
            {
                writer.WritePropertyName("multiAdStatus"u8);
                writer.WriteStringValue(MultiAdStatus.Value.ToString());
            }
            if (Optional.IsDefined(LdapConfiguration))
            {
                writer.WritePropertyName("ldapConfiguration"u8);
                writer.WriteObjectValue(LdapConfiguration, options);
            }
            if (Optional.IsDefined(EntraIdConfig))
            {
                writer.WritePropertyName("entraIdConfig"u8);
                writer.WriteObjectValue(EntraIdConfig, options);
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

        internal static AccountProperties DeserializeAccountProperties(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string provisioningState = default;
            IList<NetAppAccountActiveDirectory> activeDirectories = default;
            NetAppAccountEncryption encryption = default;
            bool disableShowmountIsDefined = false;
            bool? disableShowmount = default;
            bool nfsV4IdDomainIsDefined = false;
            string nfsV4IdDomain = default;
            MultiAdStatus? multiAdStatus = default;
            LdapConfiguration ldapConfiguration = default;
            EntraIdConfig entraIdConfig = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("provisioningState"u8))
                {
                    provisioningState = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("activeDirectories"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<NetAppAccountActiveDirectory> array = new List<NetAppAccountActiveDirectory>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(NetAppAccountActiveDirectory.DeserializeNetAppAccountActiveDirectory(item, options));
                    }
                    activeDirectories = array;
                    continue;
                }
                if (prop.NameEquals("encryption"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    encryption = NetAppAccountEncryption.DeserializeNetAppAccountEncryption(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("disableShowmount"u8))
                {
                    disableShowmountIsDefined = true;
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        disableShowmount = null;
                        continue;
                    }
                    disableShowmount = prop.Value.GetBoolean();
                    continue;
                }
                if (prop.NameEquals("nfsV4IDDomain"u8))
                {
                    nfsV4IdDomainIsDefined = true;
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        nfsV4IdDomain = null;
                        continue;
                    }
                    nfsV4IdDomain = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("multiAdStatus"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    multiAdStatus = new MultiAdStatus(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("ldapConfiguration"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    ldapConfiguration = LdapConfiguration.DeserializeLdapConfiguration(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("entraIdConfig"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    entraIdConfig = EntraIdConfig.DeserializeEntraIdConfig(prop.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, prop.Value.GetUtf8Bytes());
                }
            }
            return new AccountProperties(
                provisioningState,
                activeDirectories ?? new ChangeTrackingList<NetAppAccountActiveDirectory>(),
                encryption,
                disableShowmount,
                nfsV4IdDomain,
                multiAdStatus,
                ldapConfiguration,
                additionalBinaryDataProperties)
            {
                _disableShowmountIsDefined = disableShowmountIsDefined,
                _nfsV4IdDomainIsDefined = nfsV4IdDomainIsDefined,
                EntraIdConfig = entraIdConfig
            };
        }
    }
}
