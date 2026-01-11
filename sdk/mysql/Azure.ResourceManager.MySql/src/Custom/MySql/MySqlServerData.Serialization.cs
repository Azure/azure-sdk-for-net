// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.MySql.Models;

namespace Azure.ResourceManager.MySql
{
    public partial class MySqlServerData : IUtf8JsonSerializable, IJsonModel<MySqlServerData>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<MySqlServerData>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<MySqlServerData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MySqlServerData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MySqlServerData)} does not support writing '{format}' format.");
            }

            base.JsonModelWriteCore(writer, options);
            if (Optional.IsDefined(Identity))
            {
                writer.WritePropertyName("identity"u8);
                ((IJsonModel<ManagedServiceIdentity>)Identity).Write(writer, options);
            }
            if (Optional.IsDefined(Sku))
            {
                writer.WritePropertyName("sku"u8);
                writer.WriteObjectValue(Sku, options);
            }
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(AdministratorLogin))
            {
                writer.WritePropertyName("administratorLogin"u8);
                writer.WriteStringValue(AdministratorLogin);
            }
            if (Optional.IsDefined(Version))
            {
                writer.WritePropertyName("version"u8);
                writer.WriteStringValue(Version.Value.ToString());
            }
            if (Optional.IsDefined(SslEnforcement))
            {
                writer.WritePropertyName("sslEnforcement"u8);
                writer.WriteStringValue(SslEnforcement.Value.ToSerialString());
            }
            if (Optional.IsDefined(MinimalTlsVersion))
            {
                writer.WritePropertyName("minimalTlsVersion"u8);
                writer.WriteStringValue(MinimalTlsVersion.Value.ToString());
            }
            if (options.Format != "W" && Optional.IsDefined(ByokEnforcement))
            {
                writer.WritePropertyName("byokEnforcement"u8);
                writer.WriteStringValue(ByokEnforcement);
            }
            if (Optional.IsDefined(InfrastructureEncryption))
            {
                writer.WritePropertyName("infrastructureEncryption"u8);
                writer.WriteStringValue(InfrastructureEncryption.Value.ToString());
            }
            if (Optional.IsDefined(UserVisibleState))
            {
                writer.WritePropertyName("userVisibleState"u8);
                writer.WriteStringValue(UserVisibleState.Value.ToString());
            }
            if (Optional.IsDefined(FullyQualifiedDomainName))
            {
                writer.WritePropertyName("fullyQualifiedDomainName"u8);
                writer.WriteStringValue(FullyQualifiedDomainName);
            }
            if (Optional.IsDefined(EarliestRestoreOn))
            {
                writer.WritePropertyName("earliestRestoreDate"u8);
                writer.WriteStringValue(EarliestRestoreOn.Value, "O");
            }
            if (Optional.IsDefined(StorageProfile))
            {
                writer.WritePropertyName("storageProfile"u8);
                writer.WriteObjectValue(StorageProfile, options);
            }
            if (Optional.IsDefined(ReplicationRole))
            {
                writer.WritePropertyName("replicationRole"u8);
                writer.WriteStringValue(ReplicationRole);
            }
            if (Optional.IsDefined(MasterServerId))
            {
                writer.WritePropertyName("masterServerId"u8);
                writer.WriteStringValue(MasterServerId);
            }
            if (Optional.IsDefined(ReplicaCapacity))
            {
                writer.WritePropertyName("replicaCapacity"u8);
                writer.WriteNumberValue(ReplicaCapacity.Value);
            }
            if (Optional.IsDefined(PublicNetworkAccess))
            {
                writer.WritePropertyName("publicNetworkAccess"u8);
                writer.WriteStringValue(PublicNetworkAccess.Value.ToString());
            }
            if (options.Format != "W" && Optional.IsCollectionDefined(PrivateEndpointConnections))
            {
                writer.WritePropertyName("privateEndpointConnections"u8);
                writer.WriteStartArray();
                foreach (var item in PrivateEndpointConnections)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        MySqlServerData IJsonModel<MySqlServerData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MySqlServerData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MySqlServerData)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeMySqlServerData(document.RootElement, options);
        }

        BinaryData IPersistableModel<MySqlServerData>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MySqlServerData>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerMySqlContext.Default);
                default:
                    throw new FormatException($"The model {nameof(MySqlServerData)} does not support writing '{options.Format}' format.");
            }
        }

        internal static MySqlServerData DeserializeMySqlServerData(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ManagedServiceIdentity identity = default;
            MySqlSku sku = default;
            IDictionary<string, string> tags = default;
            AzureLocation location = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            SystemData systemData = default;
            string administratorLogin = default;
            MySqlServerVersion? version = default;
            MySqlSslEnforcementEnum? sslEnforcement = default;
            MySqlMinimalTlsVersionEnum? minimalTlsVersion = default;
            string byokEnforcement = default;
            MySqlInfrastructureEncryption? infrastructureEncryption = default;
            MySqlServerState? userVisibleState = default;
            string fullyQualifiedDomainName = default;
            DateTimeOffset? earliestRestoreDate = default;
            MySqlStorageProfile storageProfile = default;
            string replicationRole = default;
            ResourceIdentifier masterServerId = default;
            int? replicaCapacity = default;
            MySqlPublicNetworkAccessEnum? publicNetworkAccess = default;
            IReadOnlyList<MySqlServerPrivateEndpointConnection> privateEndpointConnections = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("identity"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    identity = ModelReaderWriter.Read<ManagedServiceIdentity>(new BinaryData(Encoding.UTF8.GetBytes(property.Value.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerMySqlContext.Default);
                    continue;
                }
                if (property.NameEquals("sku"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    sku = MySqlSku.DeserializeMySqlSku(property.Value);
                    continue;
                }
                if (property.NameEquals("tags"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    tags = dictionary;
                    continue;
                }
                if (property.NameEquals("location"u8))
                {
                    location = new AzureLocation(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("id"u8))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    systemData = ModelReaderWriter.Read<SystemData>(new BinaryData(Encoding.UTF8.GetBytes(property.Value.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerMySqlContext.Default);
                    continue;
                }
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("administratorLogin"u8))
                        {
                            administratorLogin = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("version"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            version = new MySqlServerVersion(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("sslEnforcement"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            sslEnforcement = property0.Value.GetString().ToMySqlSslEnforcementEnum();
                            continue;
                        }
                        if (property0.NameEquals("minimalTlsVersion"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            minimalTlsVersion = new MySqlMinimalTlsVersionEnum(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("byokEnforcement"u8))
                        {
                            byokEnforcement = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("infrastructureEncryption"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            infrastructureEncryption = new MySqlInfrastructureEncryption(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("userVisibleState"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            userVisibleState = new MySqlServerState(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("fullyQualifiedDomainName"u8))
                        {
                            fullyQualifiedDomainName = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("earliestRestoreDate"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            earliestRestoreDate = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("storageProfile"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            storageProfile = MySqlStorageProfile.DeserializeMySqlStorageProfile(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("replicationRole"u8))
                        {
                            replicationRole = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("masterServerId"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            // Customized code start
                            if (string.IsNullOrEmpty(property0.Value.GetString()))
                                continue;
                            // Customized code end
                            masterServerId = new ResourceIdentifier(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("replicaCapacity"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            replicaCapacity = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("publicNetworkAccess"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            publicNetworkAccess = new MySqlPublicNetworkAccessEnum(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("privateEndpointConnections"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<MySqlServerPrivateEndpointConnection> array = new List<MySqlServerPrivateEndpointConnection>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(MySqlServerPrivateEndpointConnection.DeserializeMySqlServerPrivateEndpointConnection(item));
                            }
                            privateEndpointConnections = array;
                            continue;
                        }
                    }
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new MySqlServerData(
                id,
                name,
                type,
                systemData,
                tags ?? new ChangeTrackingDictionary<string, string>(),
                location,
                identity,
                sku,
                administratorLogin,
                version,
                sslEnforcement,
                minimalTlsVersion,
                byokEnforcement,
                infrastructureEncryption,
                userVisibleState,
                fullyQualifiedDomainName,
                earliestRestoreDate,
                storageProfile,
                replicationRole,
                masterServerId,
                replicaCapacity,
                publicNetworkAccess,
                privateEndpointConnections ?? new ChangeTrackingList<MySqlServerPrivateEndpointConnection>(),
                serializedAdditionalRawData);
        }

        MySqlServerData IPersistableModel<MySqlServerData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MySqlServerData>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeMySqlServerData(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(MySqlServerData)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<MySqlServerData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
