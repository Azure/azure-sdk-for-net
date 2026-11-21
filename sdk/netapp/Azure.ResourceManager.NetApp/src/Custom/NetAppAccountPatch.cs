// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.NetApp.Models
{
    // Restore TrackedResourceData base type and read-only flattened properties that
    // existed on the previously shipped autorest SDK. The new spec models the patch
    // type as PatchModel<NetAppAccount> which strips id/location and read-only
    // properties; preserve them here for backward compatibility.
    public partial class NetAppAccountPatch : TrackedResourceData
    {
        private LdapConfiguration _ldapConfiguration;

        // ProvisioningState/DisableShowmount were read-only on the GA model. The new patch
        // type omits them entirely, so these stubs preserve source compatibility while
        // throwing on access — callers should read provisioning state from NetAppAccountData.
        /// <summary> Azure lifecycle management. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release. Read the provisioning state from NetAppAccountData instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ProvisioningState => throw new NotSupportedException("ProvisioningState is no longer available on NetAppAccountPatch. Read it from NetAppAccountData instead.");

        /// <summary> Shows the status of disableShowmount for all volumes under the subscription, null equals false. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release. Read DisableShowmount from NetAppAccountData instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? DisableShowmount => throw new NotSupportedException("DisableShowmount is no longer available on NetAppAccountPatch. Read it from NetAppAccountData instead.");

        /// <summary> MultiAD Status for the account. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release. Read MultiAdStatus from NetAppAccountData instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MultiAdStatus? MultiAdStatus => throw new NotSupportedException("MultiAdStatus is no longer available on NetAppAccountPatch. Read it from NetAppAccountData instead.");

        /// <summary> Entra ID configuration. </summary>
        public EntraIdConfigPatch EntraIdConfig
        {
            get => Properties?.EntraIdConfig;
            set
            {
                if (Properties is null)
                {
                    Properties = new AccountPropertiesPatch();
                }
                Properties.EntraIdConfig = value;
            }
        }

        /// <summary> LDAP configuration. </summary>
        public LdapConfiguration LdapConfiguration
        {
            get
            {
                if (_ldapConfiguration is null && Properties?.LdapConfiguration is not null)
                {
                    BinaryData data = ModelReaderWriter.Write(Properties.LdapConfiguration, ModelSerializationExtensions.WireOptions, AzureResourceManagerNetAppContext.Default);
                    _ldapConfiguration = ModelReaderWriter.Read<LdapConfiguration>(data, ModelSerializationExtensions.WireOptions, AzureResourceManagerNetAppContext.Default);
                }
                return _ldapConfiguration;
            }
            set
            {
                _ldapConfiguration = value;
                if (Properties is null)
                {
                    Properties = new AccountPropertiesPatch();
                }
                if (value is null)
                {
                    Properties.LdapConfiguration = null;
                    return;
                }
                BinaryData data = ModelReaderWriter.Write(value, ModelSerializationExtensions.WireOptions, AzureResourceManagerNetAppContext.Default);
                Properties.LdapConfiguration = ModelReaderWriter.Read<LdapConfigurationPatch>(data, ModelSerializationExtensions.WireOptions, AzureResourceManagerNetAppContext.Default);
            }
        }
    }

    // The stable 2026-09-01 AccountPropertiesPatch has no Entra ID member; hold the value client-side
    // so NetAppAccountPatch.EntraIdConfig keeps working.
    internal partial class AccountPropertiesPatch
    {
        public EntraIdConfigPatch EntraIdConfig { get; set; }

        // Custom serialization replaces the generated members so entraIdConfig is read and written on the wire.
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AccountPropertiesPatch>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AccountPropertiesPatch)} does not support writing '{format}' format.");
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

        internal static AccountPropertiesPatch DeserializeAccountPropertiesPatch(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<NetAppAccountActiveDirectory> activeDirectories = default;
            NetAppAccountEncryption encryption = default;
            bool nfsV4IdDomainIsDefined = false;
            string nfsV4IdDomain = default;
            LdapConfigurationPatch ldapConfiguration = default;
            EntraIdConfigPatch entraIdConfig = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
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
                if (prop.NameEquals("ldapConfiguration"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    ldapConfiguration = LdapConfigurationPatch.DeserializeLdapConfigurationPatch(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("entraIdConfig"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    entraIdConfig = EntraIdConfigPatch.DeserializeEntraIdConfigPatch(prop.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, prop.Value.GetUtf8Bytes());
                }
            }
            return new AccountPropertiesPatch(activeDirectories ?? new ChangeTrackingList<NetAppAccountActiveDirectory>(), encryption, nfsV4IdDomain, ldapConfiguration, additionalBinaryDataProperties)
            {
                _nfsV4IdDomainIsDefined = nfsV4IdDomainIsDefined,
                EntraIdConfig = entraIdConfig
            };
        }
    }
}
